using System;
using Gdk;
using Gtk;
using System.Data;
using System.Data.SqlClient;

namespace HWD
{
	public class Auth
	{
		private Gtk.Window sWin;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		public Entry txtUser;
		public Entry txtPwd;
		public static System.Data.SqlClient.SqlConnection sqlConn;
		public Entry cboServer;
		private Button button3;
		private Button button1;
		private Button button2;
		public Combo cmbCatalog;
		private Table table;
		private int o = 0;
		private string strConn;
		

		private void InitializeComponent()
		{
			this.sWin = new Gtk.Window("Session Login");
			this.sWin.SetDefaultSize(300, 200);
			this.label1 = new Label("User:");
			this.label2 = new Label("Password:");
			this.label3 = new Label("Server:");
			this.label4 = new Label("Catalog:");
			this.txtUser = new Entry();
			this.txtPwd = new Entry();
			this.cboServer = new Entry();
			this.cmbCatalog = new Combo();
			this.button3 = new Button(Gtk.Stock.Refresh);
			this.button3.UseStock = true;
			this.button1 = new Button("Log in");
			this.button2 = new Button(Gtk.Stock.Quit);
			this.button2.UseStock = true;
			this.table = new Table(3,5,false);
			
			this.button1.Clicked += new EventHandler(button1_Click);
			this.button2.Clicked += new EventHandler(button2_Click);
			this.button3.Clicked += new EventHandler(button3_Click);
			
			this.table.Attach(this.label1, 0, 1, 0, 1);
			this.table.Attach(this.txtUser, 1, 2, 0, 1);
			this.table.Attach(this.label2, 0, 1, 1, 2);
			this.table.Attach(this.txtPwd, 1, 2, 1, 2);
			this.table.Attach(this.label3, 0, 1, 2, 3);
			this.table.Attach(this.cboServer, 1, 2, 2, 3);
			this.table.Attach(this.label4, 0, 1, 3, 4);
			this.table.Attach(this.cmbCatalog, 1, 2, 3, 4);
			this.table.Attach(this.button3, 2, 3, 3, 4);
			this.table.Attach(this.button1, 0, 1, 4, 5);
			this.table.Attach(this.button2, 2, 3, 4, 5);
			
			this.sWin.Add(table);
			this.sWin.DeleteEvent += new DeleteEventHandler(delete);
			this.sWin.ShowAll();
		}
		
		public void delete(object o , DeleteEventArgs args)
  		{
			Application.Quit();
  		}
		
		private void button1_Click(object sender, System.EventArgs e)
		{
			LaunchMein();
		}

		private void LaunchMein()
		{
			this.o++;
			this.strConn = "user id=" + this.txtUser.Text + ";password=" + this.txtPwd.Text +";data source=" + this.cboServer.Text + ";persist security info=True;initial catalog=" + this.cmbCatalog.Entry.Text;

			Auth.sqlConn = new System.Data.SqlClient.SqlConnection(strConn);
			try 
			{
				Auth.sqlConn.Open();
				this.sWin.Destroy();
				HWDGtk mein = new HWDGtk();
			}
			catch (Exception er)
			{
				if (this.o == 1)
					LaunchMein();
				else
					Application.Quit();
			}	
		}
		private void button2_Click(object sender, System.EventArgs e)
		{
			Application.Quit();
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			SqlCommand    comm;
			SqlDataReader reader;
			Auth.sqlConn = new SqlConnection("user id=" + this.txtUser.Text + ";password=" + this.txtPwd.Text + ";data source=" + this.cboServer.Text + ";persist security info=True;initial catalog=master;");

			  try
			  {
			    	Auth.sqlConn.Open();
				comm = new SqlCommand("select name from sysdatabases", Auth.sqlConn);
				reader = comm.ExecuteReader(CommandBehavior.CloseConnection);
				string tmp = string.Empty;
				
				while(reader.Read())
					tmp += reader.GetString(0)+",";
				string[] list = tmp.Split(',');
				cmbCatalog.PopdownStrings = list;
				reader.Close();
			  }
			  catch
			  {
			  	Console.WriteLine("Can´t connect to Sql Server");
			  }	
		}

		public Auth()
		{
			InitializeComponent();
		}

		[STAThread]
		static void Main(string[] args)
		{
			Application.Init();
			Auth myAuth = new Auth();
			Application.Run();
		} 
	}
}