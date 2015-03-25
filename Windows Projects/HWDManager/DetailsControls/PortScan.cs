using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Crownwood.DotNetMagic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Resources;

namespace HWD.DetailsControls
{
	public delegate void countOneDelegate();

	public class PortScan : System.Windows.Forms.UserControl
	{
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button10;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle btnScan;
		private System.Windows.Forms.ListView lsvStatus;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		private System.Windows.Forms.ColumnHeader columnHeader15;
		private System.Windows.Forms.ColumnHeader columnHeader16;
		private System.Windows.Forms.ColumnHeader columnHeader17;
		private System.Windows.Forms.ColumnHeader columnHeader18;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.CheckBox chkAll;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.NumericUpDown upTwo;
		private System.Windows.Forms.NumericUpDown upOne;
		private bool stopScan = true;
		private ListViewItem lvItem;
		private long timeElapsed;
		private System.TimeSpan time;
		private IPHostEntry iphe;
		private System.Data.DataTable dt;
		private System.Data.DataSet ds;
		private System.Windows.Forms.ImageList imageList1;
		private System.ComponentModel.IContainer components;
		private System.Resources.ResourceManager m_ResourceManager;
		private string insys = HWD.Details.insys;

		public System.Resources.ResourceManager rsxmgr
		{
			set
			{
				this.m_ResourceManager = value;
			}

		}

		public PortScan()
		{
			InitializeComponent();
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PortScan));
			this.button10 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.btnScan = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.lsvStatus = new System.Windows.Forms.ListView();
			this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.chkAll = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.upTwo = new System.Windows.Forms.NumericUpDown();
			this.upOne = new System.Windows.Forms.NumericUpDown();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			((System.ComponentModel.ISupportInitialize)(this.upTwo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.upOne)).BeginInit();
			this.SuspendLayout();
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(512, 4);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(96, 32);
			this.button10.TabIndex = 37;
			this.button10.Text = "Load XML";
			this.button10.Click += new System.EventHandler(this.button10_Click);
			// 
			// btnScan
			// 
			this.btnScan.Enabled = false;
			this.btnScan.Location = new System.Drawing.Point(408, 4);
			this.btnScan.Name = "btnScan";
			this.btnScan.Size = new System.Drawing.Size(96, 32);
			this.btnScan.TabIndex = 36;
			this.btnScan.Text = "Scan";
			this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
			// 
			// lsvStatus
			// 
			this.lsvStatus.BackColor = System.Drawing.Color.White;
			this.lsvStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lsvStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader13,
																						this.columnHeader14,
																						this.columnHeader15,
																						this.columnHeader16,
																						this.columnHeader17,
																						this.columnHeader18});
			this.lsvStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lsvStatus.FullRowSelect = true;
			this.lsvStatus.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lsvStatus.LargeImageList = this.imageList1;
			this.lsvStatus.Location = new System.Drawing.Point(0, 73);
			this.lsvStatus.Name = "lsvStatus";
			this.lsvStatus.Size = new System.Drawing.Size(614, 216);
			this.lsvStatus.SmallImageList = this.imageList1;
			this.lsvStatus.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lsvStatus.TabIndex = 35;
			this.lsvStatus.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader13
			// 
			this.columnHeader13.Text = "Port";
			this.columnHeader13.Width = 71;
			// 
			// columnHeader14
			// 
			this.columnHeader14.Text = "Status";
			this.columnHeader14.Width = 87;
			// 
			// columnHeader15
			// 
			this.columnHeader15.Text = "Type";
			this.columnHeader15.Width = 76;
			// 
			// columnHeader16
			// 
			this.columnHeader16.Text = "Port Name";
			this.columnHeader16.Width = 104;
			// 
			// columnHeader17
			// 
			this.columnHeader17.Text = "Description";
			this.columnHeader17.Width = 131;
			// 
			// columnHeader18
			// 
			this.columnHeader18.Text = "Time Elapsed";
			this.columnHeader18.Width = 120;
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(16, 44);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(592, 24);
			this.progressBar1.TabIndex = 34;
			// 
			// chkAll
			// 
			this.chkAll.Enabled = false;
			this.chkAll.Location = new System.Drawing.Point(280, 12);
			this.chkAll.Name = "chkAll";
			this.chkAll.Size = new System.Drawing.Size(96, 24);
			this.chkAll.TabIndex = 33;
			this.chkAll.Text = "Show All";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(16, 12);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 16);
			this.label7.TabIndex = 32;
			this.label7.Text = "Port Range:";
			// 
			// upTwo
			// 
			this.upTwo.Enabled = false;
			this.upTwo.Location = new System.Drawing.Point(176, 12);
			this.upTwo.Name = "upTwo";
			this.upTwo.Size = new System.Drawing.Size(80, 20);
			this.upTwo.TabIndex = 31;
			// 
			// upOne
			// 
			this.upOne.Enabled = false;
			this.upOne.Location = new System.Drawing.Point(88, 12);
			this.upOne.Name = "upOne";
			this.upOne.Size = new System.Drawing.Size(80, 20);
			this.upOne.TabIndex = 30;
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// PortScan
			// 
			this.Controls.Add(this.button10);
			this.Controls.Add(this.btnScan);
			this.Controls.Add(this.lsvStatus);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.chkAll);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.upTwo);
			this.Controls.Add(this.upOne);
			this.Name = "PortScan";
			this.Size = new System.Drawing.Size(614, 289);
			this.Load += new System.EventHandler(this.PortScan_Load);
			((System.ComponentModel.ISupportInitialize)(this.upTwo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.upOne)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnScan_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			if (this.stopScan) 
			{
				if (this.insys.Length > 3 || this.upOne.Value < this.upTwo.Value)
				{
					try 
					{
						Dns.Resolve(this.insys);
					} 
					catch 
					{
						this.Cursor = Cursors.Default;
						MessageBox.Show("Unknown host");
						return;
					}
					this.lsvStatus.Items.Clear();
					this.progressBar1.Minimum = (int) this.upOne.Value;
					this.progressBar1.Value = this.progressBar1.Minimum;
					this.progressBar1.Maximum = (int) this.upTwo.Value;
					this.chkAll.Enabled = false;
					this.upOne.Enabled = false;
					this.upTwo.Enabled = false;
					this.btnScan.Enabled = false;
					for (int i = (int) this.upOne.Value; i < ((int) this.upTwo.Value)+1; i++) 
					{
						Port por = new Port(i);
						ThreadPool.QueueUserWorkItem(new WaitCallback(this.Scann), por);
					}
				} 
				else 
					MessageBox.Show("ERROR");
			} 
			else 
			{
				this.chkAll.Enabled = true;
				this.upOne.Enabled = true;
				this.upTwo.Enabled = true;
				this.stopScan = true;
				this.btnScan.Text = "Scan";
			}
			this.Cursor = Cursors.Default;
		}

		private bool connectSocket(int port, ProtocolType protocol)
		{
			Socket tmpS = null;
    
			try
			{
				iphe = Dns.Resolve(this.insys);
				IPEndPoint ipe = new IPEndPoint(iphe.AddressList[0], port);

				if (protocol == ProtocolType.Tcp) 
					tmpS = new Socket(ipe.AddressFamily, SocketType.Stream, protocol);
				else 
					tmpS = new Socket(ipe.AddressFamily, SocketType.Dgram, protocol);

				tmpS.Connect(ipe);

				if(tmpS.Connected)
				{
					tmpS.Close();
					return true;
				}
				else 
				{
					return false;
				}
			}
			catch
			{
				return false;
			}
		}

		public void Scann(Object stateInfo)
		{
			int icon = 0;
			Port por = (Port) stateInfo;
			int i = por.i;
			string[] values = null;
			bool con;
			values = new string[6];
			values[0] = i.ToString();
			values[2] = "TCP";

			DataRow dr = this.dt.Rows.Find(new object[] {i});
			values[3] = "unknown";
			values[4] = "";
			if (dr != null) 
			{
				values[3] = dr["name"].ToString();
				values[4] = dr["desc"].ToString();
			}
			
			this.timeElapsed = DateTime.Now.Ticks;
			con = this.connectSocket(i, ProtocolType.Tcp);
			this.time = new System.TimeSpan(DateTime.Now.Ticks - this.timeElapsed);
			if(con)
			{
				values[1] = "Opened";
			} 
			else
			{
				values[1] = "Closed";
				icon = 1;
			}
			if (con || this.chkAll.Checked) 
			{
				values[5] = this.time.Milliseconds.ToString();
				lvItem = new ListViewItem(values, icon);	
				Invoke(new addItemDelegate(this.addItem), new object[] {lvItem});
			}

			this.Invoke(new countOneDelegate(countOne));
		}

		private void addItem(ListViewItem lvItem) 
		{
			this.lsvStatus.Items.Add(lvItem);
		}

		public void countOne()
		{
			if (this.progressBar1.Value == this.progressBar1.Maximum)
			{
				this.chkAll.Enabled = true;
				this.upOne.Enabled = true;
				this.upTwo.Enabled = true;
				this.btnScan.Enabled = true;
				this.progressBar1.Value = this.progressBar1.Maximum;
			} 
			else 
			{
				this.progressBar1.Value++;
			}
		}

		private void button10_Click(object sender, System.EventArgs e)
		{
			try 
			{
				this.ds = new DataSet();
				this.ds.ReadXml("ports.xml");
				this.dt = this.ds.Tables[0];
				DataColumn[] dc = new DataColumn[1];
				this.dt.Columns["id"].Unique = true;
				dc[0] = this.dt.Columns["id"];
				this.dt.PrimaryKey = dc;

				decimal min = Convert.ToDecimal(this.dt.Rows[0]["id"].ToString());
				decimal max = Convert.ToDecimal(this.dt.Rows[this.dt.Rows.Count-1]["id"].ToString());
				this.upOne.Minimum = min;
				this.upOne.Maximum = max;
				this.upOne.Value = min;
				this.upTwo.Minimum = min;
				this.upTwo.Maximum = max;
				this.upTwo.Value = max;
				this.chkAll.Enabled = true;
				this.upOne.Enabled = true;
				this.upTwo.Enabled = true;
				this.btnScan.Enabled = true;
				this.button10.Enabled = false;
			} 
			catch 
			{
				MessageBox.Show("Can't load XML file");
			}
		}

		private void PortScan_Load(object sender, System.EventArgs e)
		{
			this.columnHeader13.Text = m_ResourceManager.GetString("dcolumnHeader13"); 
			this.columnHeader15.Text = m_ResourceManager.GetString("dcolumnHeader7"); 
			this.columnHeader16.Text = m_ResourceManager.GetString("dcolumnHeader16");
			this.columnHeader17.Text = m_ResourceManager.GetString("dcolumnHeader17");
			this.columnHeader18.Text = m_ResourceManager.GetString("dcolumnHeader18");
		}
	}

	public class Port
	{
		public int i;
		public Port(int number) 
		{
			i = number;
		}
	}
}
