using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Threading;
using cmpDWPing;
using Snmp;

namespace SWD
{
	public delegate void addItemDelegate(ListViewItem lvitem);
	public delegate void countOneDelegate();

	public class Mein : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListView listView1;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ImageList imageList1;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle buttonWithStyle1;
		private ListViewItem lvItem;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.NumericUpDown numericUpDown4;
		private System.Windows.Forms.NumericUpDown numericUpDown5;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.NumericUpDown numericUpDown3;
		private System.Windows.Forms.NumericUpDown numericUpDown2;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle buttonWithStyle2;
		private RFC1157.Mgmt mib = new RFC1157.Mgmt();
		private System.Windows.Forms.PictureBox pictureBox1;
		private string gateway = "";

		public Mein()
		{
			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			InitializeComponent();
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Mein));
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.buttonWithStyle1 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
			this.titleBar1 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.buttonWithStyle2 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1,
																						this.columnHeader3,
																						this.columnHeader2,
																						this.columnHeader4,
																						this.columnHeader5});
			this.listView1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.LargeImageList = this.imageList1;
			this.listView1.Location = new System.Drawing.Point(0, 126);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(814, 304);
			this.listView1.SmallImageList = this.imageList1;
			this.listView1.TabIndex = 0;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 192;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "IP Address";
			this.columnHeader3.Width = 98;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Status";
			this.columnHeader2.Width = 62;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "TTL";
			this.columnHeader4.Width = 65;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Extra";
			this.columnHeader5.Width = 143;
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// buttonWithStyle1
			// 
			this.buttonWithStyle1.Location = new System.Drawing.Point(456, 40);
			this.buttonWithStyle1.Name = "buttonWithStyle1";
			this.buttonWithStyle1.Size = new System.Drawing.Size(64, 48);
			this.buttonWithStyle1.TabIndex = 1;
			this.buttonWithStyle1.Text = "Scan Now!";
			this.buttonWithStyle1.Click += new System.EventHandler(this.buttonWithStyle1_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Items.AddRange(new object[] {
														   "Details",
														   "Icons",
														   "List"});
			this.comboBox1.Location = new System.Drawing.Point(8, 16);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(112, 21);
			this.comboBox1.Sorted = true;
			this.comboBox1.TabIndex = 2;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// numericUpDown4
			// 
			this.numericUpDown4.Location = new System.Drawing.Point(8, 16);
			this.numericUpDown4.Maximum = new System.Decimal(new int[] {
																		   255,
																		   0,
																		   0,
																		   0});
			this.numericUpDown4.Name = "numericUpDown4";
			this.numericUpDown4.Size = new System.Drawing.Size(48, 20);
			this.numericUpDown4.TabIndex = 6;
			this.numericUpDown4.Value = new System.Decimal(new int[] {
																		 1,
																		 0,
																		 0,
																		 0});
			// 
			// numericUpDown5
			// 
			this.numericUpDown5.Location = new System.Drawing.Point(56, 16);
			this.numericUpDown5.Maximum = new System.Decimal(new int[] {
																		   255,
																		   0,
																		   0,
																		   0});
			this.numericUpDown5.Name = "numericUpDown5";
			this.numericUpDown5.Size = new System.Drawing.Size(48, 20);
			this.numericUpDown5.TabIndex = 7;
			this.numericUpDown5.Value = new System.Decimal(new int[] {
																		 255,
																		 0,
																		 0,
																		 0});
			// 
			// titleBar1
			// 
			this.titleBar1.Dock = System.Windows.Forms.DockStyle.Top;
			this.titleBar1.GradientActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(200)), ((System.Byte)(200)));
			this.titleBar1.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
			this.titleBar1.GradientDirection = Crownwood.DotNetMagic.Controls.GradientDirection.TopToBottom;
			this.titleBar1.GradientInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(239)), ((System.Byte)(247)));
			this.titleBar1.Icon = ((System.Drawing.Icon)(resources.GetObject("titleBar1.Icon")));
			this.titleBar1.Location = new System.Drawing.Point(0, 0);
			this.titleBar1.MouseOverColor = System.Drawing.Color.Empty;
			this.titleBar1.Name = "titleBar1";
			this.titleBar1.Size = new System.Drawing.Size(814, 32);
			this.titleBar1.TabIndex = 8;
			this.titleBar1.Text = "SWD";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.numericUpDown3);
			this.groupBox1.Controls.Add(this.numericUpDown2);
			this.groupBox1.Controls.Add(this.numericUpDown1);
			this.groupBox1.Location = new System.Drawing.Point(8, 40);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(168, 48);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Subnet";
			// 
			// numericUpDown3
			// 
			this.numericUpDown3.Location = new System.Drawing.Point(112, 16);
			this.numericUpDown3.Maximum = new System.Decimal(new int[] {
																		   255,
																		   0,
																		   0,
																		   0});
			this.numericUpDown3.Name = "numericUpDown3";
			this.numericUpDown3.Size = new System.Drawing.Size(48, 20);
			this.numericUpDown3.TabIndex = 8;
			this.numericUpDown3.Value = new System.Decimal(new int[] {
																		 179,
																		 0,
																		 0,
																		 0});
			// 
			// numericUpDown2
			// 
			this.numericUpDown2.Location = new System.Drawing.Point(64, 16);
			this.numericUpDown2.Maximum = new System.Decimal(new int[] {
																		   255,
																		   0,
																		   0,
																		   0});
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size(48, 20);
			this.numericUpDown2.TabIndex = 7;
			this.numericUpDown2.Value = new System.Decimal(new int[] {
																		 54,
																		 0,
																		 0,
																		 0});
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(16, 16);
			this.numericUpDown1.Maximum = new System.Decimal(new int[] {
																		   255,
																		   0,
																		   0,
																		   0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(48, 20);
			this.numericUpDown1.TabIndex = 6;
			this.numericUpDown1.Value = new System.Decimal(new int[] {
																		 170,
																		 0,
																		 0,
																		 0});
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.numericUpDown5);
			this.groupBox2.Controls.Add(this.numericUpDown4);
			this.groupBox2.Location = new System.Drawing.Point(184, 40);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(112, 48);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Range";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.comboBox1);
			this.groupBox3.Location = new System.Drawing.Point(304, 40);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(128, 48);
			this.groupBox3.TabIndex = 11;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "View";
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(8, 96);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(560, 24);
			this.progressBar1.Step = 1;
			this.progressBar1.TabIndex = 12;
			// 
			// buttonWithStyle2
			// 
			this.buttonWithStyle2.Location = new System.Drawing.Point(528, 40);
			this.buttonWithStyle2.Name = "buttonWithStyle2";
			this.buttonWithStyle2.Size = new System.Drawing.Size(40, 48);
			this.buttonWithStyle2.TabIndex = 13;
			this.buttonWithStyle2.Text = "buttonWithStyle2";
			this.buttonWithStyle2.Click += new System.EventHandler(this.buttonWithStyle2_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(576, 40);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(232, 384);
			this.pictureBox1.TabIndex = 14;
			this.pictureBox1.TabStop = false;
			// 
			// Mein
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(814, 430);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.buttonWithStyle2);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.titleBar1);
			this.Controls.Add(this.buttonWithStyle1);
			this.Controls.Add(this.listView1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Mein";
			this.Text = "SWD v0.2 alpha";
			this.Load += new System.EventHandler(this.Mein_Load);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.EnableVisualStyles();
			Application.DoEvents();
			Application.Run(new Mein());
		}

		private void Mein_Load(object sender, System.EventArgs e)
		{
			this.comboBox1.SelectedIndex = 0;
		}

		private void buttonWithStyle1_Click(object sender, System.EventArgs e)
		{
			if (this.numericUpDown4.Value < this.numericUpDown5.Value) 
			{
				this.progressBar1.Minimum = (int) this.numericUpDown4.Value;
				this.progressBar1.Value = this.progressBar1.Minimum;
				this.progressBar1.Maximum = (int) this.numericUpDown5.Value+1;
				string subnet = this.numericUpDown1.Value.ToString() + "." + this.numericUpDown2.Value.ToString() + "." + this.numericUpDown3.Value.ToString() + ".";

				this.numericUpDown1.Enabled = false;
				this.numericUpDown2.Enabled = false;
				this.numericUpDown3.Enabled = false;
				this.numericUpDown4.Enabled = false;
				this.numericUpDown5.Enabled = false;
				this.buttonWithStyle1.Enabled = false;

				for (int i = (int) this.numericUpDown4.Value; i < (int) this.numericUpDown5.Value+1; i++)
				{
					Host h = new Host(subnet+i.ToString());
					ThreadPool.QueueUserWorkItem(new WaitCallback(this.Scann), h);
				}
			} 
			else 
			{
				MessageBox.Show("Error");
			}
		}

		public void Scann(Object stateInfo)
		{
			Host h = (Host) stateInfo;

			string[] values = new string[5];
			values[0] = Dns.Resolve(h.Name).HostName;
			values[1] = Dns.Resolve(h.Name).AddressList[0].ToString();
			cmpDWPing.CDWPing ping = new CDWPing();
			short up = ping.ping(values[0]);
			if (up == 0)
			{
				values[2] = "Down";
				values[3] = "0";
				values[4] = "";
			}
			else 
			{
				values[2] = "Up";
				values[3] = ping.AvgTTL.ToString();
				try 
				{
					ManagerSession sess = new ManagerSession(values[0],"public");
					ManagerItem mi = new ManagerItem(sess,mib.OID("mgmt.mib-2.system.sysDescr.0"));
					values[4] = mi.Value.ToString();
				} 
				catch
				{
					values[4] = "";
				}
			}
			if (values[4].ToUpper().IndexOf("JET") != -1)
				up = 2;
			if (up != 0 && values[0].Trim() != values[1].Trim())
			{
				lvItem = new ListViewItem(values, up);
				Invoke(new addItemDelegate(this.addItem), new object[] {lvItem});
			}
			Invoke(new countOneDelegate(countOne));
		}
		
		public void countOne()
		{
			if (this.progressBar1.Value >= this.progressBar1.Maximum-1)
			{
				this.numericUpDown1.Enabled = true;
				this.numericUpDown2.Enabled = true;
				this.numericUpDown3.Enabled = true;
				this.numericUpDown4.Enabled = true;
				this.numericUpDown5.Enabled = true;
				this.buttonWithStyle1.Enabled = true;
				this.progressBar1.Value = this.progressBar1.Maximum;
			} 
			else 
			{
				this.progressBar1.Value++;
			}
		}

		private void addItem(ListViewItem lvItem) 
		{
			this.listView1.Items.Add(lvItem);
		}

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			switch (this.comboBox1.Items[this.comboBox1.SelectedIndex].ToString())
			{
				case "Details":
					this.listView1.View = View.Details;
					break;
				case "List":
					this.listView1.View = View.List;
					break;
				default:
					this.listView1.View = View.LargeIcon;
					break;
			}	
		}

		private void buttonWithStyle2_Click(object sender, System.EventArgs e)
		{
			foreach (System.Management.ManagementObject mo in Consulta("SELECT IPAddress, DefaultIPGateway FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled=TRUE"))
			{
				//foreach(string st in (string[]) mo["IPAddress"])
				//	MessageBox.Show(st);
				foreach(string st2 in (string[]) mo["DefaultIPGateway"])
					gateway = st2;
			}
			Grapp gr = new Grapp();
			gr.InitializeGraph(this.pictureBox1.Width, this.pictureBox1.Height);
			this.pictureBox1.Image = gr.GetGraph(gateway);
		}

		public static System.Management.ManagementObjectCollection Consulta(string strQuery)
		{
			System.Management.ManagementObjectCollection queryCollection;

			try
			{
				System.Management.ConnectionOptions co = new System.Management.ConnectionOptions();
				System.Management.ManagementScope ms = new System.Management.ManagementScope("\\\\localhost\\root\\cimv2", co);
				queryCollection = new System.Management.ManagementObjectSearcher(ms,new System.Management.ObjectQuery(strQuery)).Get();
			}
			catch
			{
				queryCollection=null;
			}
			return queryCollection;
		}
	}

	public class Host
	{
		public string Name;
		public Host(string name) 
		{
			Name = name;
		}
	}
}
