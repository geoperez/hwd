using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Xml;
using System.Net;
using System.Net.Sockets;
using XYNetSocketLib;
using System.Text;
using System.Data.SqlClient;
using System.Threading;
using System.Globalization;

namespace HWDServer
{
	public class Mein : System.ServiceProcess.ServiceBase
	{
		private System.ComponentModel.Container components = null;
		private XYNetSocketLib.XYNetClient xClient;
		private XYNetSocketLib.XYNetServer xServer;
		private string myIP;
		private bool xStatus;
		private XmlDocument xmldoc;
		private StringBuilder sb;
		private SqlConnection sqlConn;
		private Socket sokete;

		public Mein()
		{
			Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
			InitializeComponent();
		}

		static void Main()
		{
			System.ServiceProcess.ServiceBase[] ServicesToRun;
			ServicesToRun = new System.ServiceProcess.ServiceBase[] { new Mein() };
			System.ServiceProcess.ServiceBase.Run(ServicesToRun);
		}

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.ServiceName = "HWDServer";
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		protected override void OnStart(string[] args)
		{
			xStatus = false;
			IPHostEntry hostInfo = Dns.GetHostByName(Dns.GetHostName());
			myIP = hostInfo.AddressList[0].ToString();
			xServer = new XYNetServer(myIP, 16001, 2, 10);
			xServer.SetStringInputHandler(new StringInputHandlerDelegate(Receive));
			if (xServer.StartServer() == false)
				this.Dispose();
			else 
			{
				if (CheckConnection())
				{
					xStatus = true;
					this.SetMulticast();
					System.Threading.Thread th  = new Thread(new ThreadStart(ReceiveMess));
					th.IsBackground = true;
					th.Start();
				}
				else
					this.Dispose();
			}
		}
 
		protected override void OnStop()
		{
			if(xStatus)
				xServer.StopServer();

			if (this.sqlConn.State == ConnectionState.Open)
				this.sqlConn.Close();
		}
		private void SetMulticast()
		{
			sokete =new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
			IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 5000);
			sokete.Bind(ipep);
			IPAddress ip=IPAddress.Parse("224.0.0.1");

			sokete.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(ip,IPAddress.Any));
		}
		private void ReceiveMess()
		{
			while(xStatus)
			{
				byte[] b = new byte[126];
				sokete.Receive(b);
				this.SendMess(System.Text.Encoding.ASCII.GetString(b).Trim(), Environment.MachineName);
			}
		}
		private bool CheckConnection()
		{
			this.xmldoc = new XmlDocument();
			this.xmldoc.Load(System.Environment.GetFolderPath(System.Environment.SpecialFolder.System) + "\\HWD\\config.xml");
			string SQLServer = this.xmldoc.FirstChild["SQLServer"].InnerText;
			string SQLUser = this.xmldoc.FirstChild["SQLUser"].InnerText;
			string SQLPwd = Utilities.Decrypt(this.xmldoc.FirstChild["SQLPwd"].InnerText);
			string SQLCatalog = this.xmldoc.FirstChild["SQLCatalog"].InnerText;

			string strConn = "user id=" + SQLUser + ";password=" + SQLPwd + ";data source=\"" + SQLServer +
				"\";persist security info=True;initial catalog=" + SQLCatalog;

			this.sqlConn = new SqlConnection(strConn);
			try 
			{
				this.sqlConn.Open();
				return true;
			}
			catch 
			{
				return false;
			}
		}
		private void Receive(string sHost, int nRemotePort, string sData)
		{
			if (sData.Substring(0,4) == "POLI")
					this.UpdatePolicie(sData, sHost);
			else if (sData.Substring(0,4) == "TICK")
					this.SaveTickets(sData, sHost);
			else
					SendMess(sHost,"I don't understand your command:\n\n\t"+sData+"\nTimespan: " + System.DateTime.Now.ToString());
		}

		private void UpdatePolicie(string data, string host)
		{
			string[] mdata = data.Split(',');
			this.sb = new StringBuilder();

			sb.Append("<bads>");
			SqlCommand sqlcommand = new SqlCommand("SELECT DISTINCT InternalName FROM HWD_BLOCKEDS WHERE Owner in ('ALL', '" + mdata[1] + "', '" + mdata[2] + "')", this.sqlConn);
			SqlDataReader sqlread = sqlcommand.ExecuteReader();
			while (sqlread.Read())
				sb.Append("<i>" + sqlread.GetString(0).Trim() + "</i>");
			sb.Append("</bads>");
			sqlread.Close();

			SendMess(host, this.sb.ToString());
		}
		private void SaveTickets(string data, string host)
		{
			try 
			{
				string[] mdata = data.Split('|');
				xmldoc = new XmlDocument();
				xmldoc.LoadXml(mdata[3]);
				foreach(XmlNode xmln in xmldoc.ChildNodes[1].ChildNodes)
				{
					string ID = xmln.ChildNodes[0].InnerText;
					string Kind = xmln.ChildNodes[1].InnerText;
					string Title = xmln.ChildNodes[2].InnerText;
					string Desc = xmln.ChildNodes[3].InnerText;
					string Status = xmln.ChildNodes[4].InnerText;
					bool insert;
					if (ID == "0")
						insert = true;
					else 
						insert = false;
					string Showit = xmln.ChildNodes[5].InnerText;
					this.SaveData(insert, ID, Kind, Title, Desc, Status, mdata[1], mdata[2], Showit);
				}
				this.SendTicket(mdata[1], mdata[2]);
			} 
			catch (Exception er)
			{
				EventLog.WriteEntry(er.ToString());
				SendMess(host, "Can't save tickets, please try again later.");
			}
		}
		private void SaveData(bool insert, string ID, string Kind, string Title, string Desc, string Status, string Machine, string User, string Showit)
		{
			string sqlquery;

			DateTimeFormatInfo dfi = new CultureInfo("en-US", false).DateTimeFormat;
			DateTime dt = new DateTime(DateTime.Today.Ticks);
			
			if (insert)
			{
				sqlquery = "INSERT INTO HWD_TICKETS (Machine, Username, Kind, Title, Description, Status, Showit, CreateDate) values" +
					"('" + Machine + "', '" + User + "', '" + Kind + "', '" + Title + "', '" + Desc + "', '" + Status + "', " + Showit + ", '" + dt.ToString(dfi) + "')";
			} 
			else 
			{
				if (Status.Trim() == "CLOSED")
					sqlquery = "UPDATE HWD_TICKETS SET Description = '"+ Desc +"', Status = 'CLOSED', Showit = " + Showit + " WHERE ID = " + ID;
				else
					sqlquery = "UPDATE HWD_TICKETS SET Description = '"+ Desc +"', Showit = " + Showit + " WHERE ID = " + ID;
			}
			SqlCommand sqlcom = new SqlCommand(sqlquery, this.sqlConn);
			sqlcom.ExecuteNonQuery();
			GC.Collect();
		}
		private void SendTicket(string Machine, string User)
		{
			this.sb = new StringBuilder();
			this.sb.Append("<?xml version=\"1.0\" standalone=\"yes\"?>");
			this.sb.Append("<NewDataSet xmlns=\"Tickets\">");
			string sqlquery = "SELECT * FROM HWD_TICKETS WHERE Machine = '" + Machine + "' AND Username = '" + User + "' AND Showit = 1";
			SqlCommand sqlcom = new SqlCommand(sqlquery,this.sqlConn);
			SqlDataReader sqlread = sqlcom.ExecuteReader();
			while (sqlread.Read())
			{
				this.sb.Append("\t<ticket>");
				this.sb.Append("\t\t<ID>" + sqlread.GetInt32(0).ToString() + "</ID>");
				this.sb.Append("\t\t<Kind>" + sqlread.GetString(3) + "</Kind>");
				this.sb.Append("\t\t<Title>" + sqlread.GetString(4) + "</Title>");
				this.sb.Append("\t\t<Desc>" + sqlread.GetString(5) + "</Desc>");
				this.sb.Append("\t\t<Status>" + sqlread.GetString(6) + "</Status>");
				this.sb.Append("\t\t<Showit>1</Showit>");
				this.sb.Append("\t</ticket>");
			}
			sqlread.Close();
			this.sb.Append("</NewDataSet>");
			this.SendMess(Machine, this.sb.ToString());
			GC.Collect();
		}
		private void SendMess(string host, string mess)
		{
			xClient = new XYNetClient(host,16000);
			if (xClient.Connect()) 
				xClient.SendStringData(mess);
			else 
				EventLog.WriteEntry(xClient.GetLastException().ToString());
			xClient.Reset();
		}
	}
}
