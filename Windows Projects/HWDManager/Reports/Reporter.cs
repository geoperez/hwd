using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Management;
using System.Globalization;
using System.Data;
using System.Threading;
using System.Resources;

namespace HWD
{
	public delegate void addRowItemDelegate(DataRow r);
	public delegate void addItemReporterDelegate(string[] p);

	public class Reporter : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.ProgressBar progressBar1;
		private HWD.userData userData1;
		private System.Data.DataTable dt;
		private System.Data.DataView dataView1;
		public bool anotherLogin;
		public string username;
		public string password;
		private ManagementObjectSearcher query;
		private ManagementObjectCollection queryCollection;
		private System.Management.ObjectQuery oq;
		private ConnectionOptions co = new ConnectionOptions();
		private string strQuery;
		private string caption;
		private string toprint;
		private ReportPrinting.ReportDocument reportDocument1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtValue;
		private System.Windows.Forms.Label label3;
		private ResourceManager m_ResourceManager;
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar1;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button1;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button2;
		private System.Windows.Forms.ListView lstItems;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;

		public HWD.userData dataSet
		{
			set
			{
				this.userData1 = value;
			}

			get
			{
				return this.userData1;
			}

		}

		public ResourceManager rsxmgr
		{
			set
			{
				this.m_ResourceManager = value;
			}

		}

		private System.ComponentModel.Container components = null;

		public Reporter()
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Reporter));
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.dataView1 = new System.Data.DataView();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.userData1 = new HWD.userData();
			this.reportDocument1 = new ReportPrinting.ReportDocument();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtValue = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.titleBar1 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.button1 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.button2 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.lstItems = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.userData1)).BeginInit();
			this.SuspendLayout();
			// 
			// comboBox1
			// 
			this.comboBox1.BackColor = System.Drawing.Color.White;
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Items.AddRange(new object[] {
														   "Printers",
														   "MAC Address",
														   "Application*",
														   "HotFix*"});
			this.comboBox1.Location = new System.Drawing.Point(8, 72);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(152, 21);
			this.comboBox1.TabIndex = 0;
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(8, 120);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(544, 24);
			this.progressBar1.Step = 1;
			this.progressBar1.TabIndex = 3;
			// 
			// userData1
			// 
			this.userData1.DataSetName = "userData";
			this.userData1.Locale = new System.Globalization.CultureInfo("es-MX");
			// 
			// reportDocument1
			// 
			this.reportDocument1.Body = null;
			this.reportDocument1.DocumentUnit = System.Drawing.GraphicsUnit.Inch;
			this.reportDocument1.PageFooter = null;
			this.reportDocument1.PageFooterMaxHeight = 1F;
			this.reportDocument1.PageHeader = null;
			this.reportDocument1.PageHeaderMaxHeight = 1F;
			this.reportDocument1.ReportMaker = null;
			this.reportDocument1.ResetAfterPrint = true;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "Report";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(168, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "Value";
			// 
			// txtValue
			// 
			this.txtValue.BackColor = System.Drawing.Color.White;
			this.txtValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtValue.Location = new System.Drawing.Point(168, 72);
			this.txtValue.Name = "txtValue";
			this.txtValue.Size = new System.Drawing.Size(152, 20);
			this.txtValue.TabIndex = 7;
			this.txtValue.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 16);
			this.label3.TabIndex = 8;
			this.label3.Text = "* Need a value";
			// 
			// titleBar1
			// 
			this.titleBar1.Dock = System.Windows.Forms.DockStyle.Top;
			this.titleBar1.GradientActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(136)), ((System.Byte)(144)), ((System.Byte)(156)));
			this.titleBar1.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
			this.titleBar1.GradientDirection = Crownwood.DotNetMagic.Controls.GradientDirection.TopToBottom;
			this.titleBar1.GradientInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(230)), ((System.Byte)(231)), ((System.Byte)(228)));
			this.titleBar1.Icon = ((System.Drawing.Icon)(resources.GetObject("titleBar1.Icon")));
			this.titleBar1.Location = new System.Drawing.Point(0, 0);
			this.titleBar1.MouseOverColor = System.Drawing.Color.Empty;
			this.titleBar1.Name = "titleBar1";
			this.titleBar1.PostText = "Ready";
			this.titleBar1.Size = new System.Drawing.Size(562, 40);
			this.titleBar1.TabIndex = 22;
			this.titleBar1.Text = "Reporter";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(352, 56);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 36);
			this.button1.TabIndex = 23;
			this.button1.Text = "Scan";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(456, 56);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(96, 36);
			this.button2.TabIndex = 24;
			this.button2.Text = "Preview";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// lstItems
			// 
			this.lstItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					   this.columnHeader1,
																					   this.columnHeader2});
			this.lstItems.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lstItems.FullRowSelect = true;
			this.lstItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lstItems.Location = new System.Drawing.Point(0, 152);
			this.lstItems.Name = "lstItems";
			this.lstItems.Size = new System.Drawing.Size(562, 300);
			this.lstItems.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lstItems.TabIndex = 25;
			this.lstItems.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Computer Name";
			this.columnHeader1.Width = 196;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Caption";
			this.columnHeader2.Width = 342;
			// 
			// Reporter
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(562, 452);
			this.Controls.Add(this.lstItems);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.titleBar1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtValue);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.comboBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximumSize = new System.Drawing.Size(568, 480);
			this.MinimumSize = new System.Drawing.Size(568, 480);
			this.Name = "Reporter";
			this.ShowInTaskbar = false;
			this.Text = "HWD - Reporter";
			this.Load += new System.EventHandler(this.Reporter_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.userData1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void Reporter_Load(object sender, System.EventArgs e)
		{
			this.dt = this.userData1.Tables["MWD"];
			this.dataView1.Table = this.dt;
			this.UpdateUI();
		}

		private void UpdateUI()
		{
			this.button1.Text = m_ResourceManager.GetString("rbutton1");
			this.button2.Text = m_ResourceManager.GetString("rbutton2");
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.dt.Rows.Clear();
			string app = this.txtValue.Text;
			switch(this.comboBox1.SelectedItem.ToString())
			{
				case "Printers":
					this.progressBar1.Maximum = this.userData1.Tables["HWD"].Rows.Count;
					this.strQuery = "SELECT * FROM Win32_Printer";
					this.caption = "Caption";
					foreach(DataRow drs in this.userData1.Tables["HWD"].Rows) 
					{
						SystemScan par = new SystemScan(drs["Username"].ToString(), drs["ComputerName"].ToString());
						ThreadPool.QueueUserWorkItem(new WaitCallback(ScanItems), par);
					}
					this.button2.Enabled = true;
					this.toprint = "Printers";
					break;
				case "MAC Address":
					this.progressBar1.Maximum = this.userData1.Tables["HWD"].Rows.Count;
					this.strQuery = "SELECT * FROM Win32_NetworkAdapter";
					this.caption = "MACAddress";
					foreach(DataRow drs in this.userData1.Tables["HWD"].Rows) 
					{
						SystemScan par = new SystemScan(drs["Username"].ToString(), drs["ComputerName"].ToString());
						ThreadPool.QueueUserWorkItem(new WaitCallback(ScanItems), par);
					}
					this.button2.Enabled = true;
					this.toprint = "MAC Address";
					break;
				case "Application*":
					if (app.Length > 0) 
					{
						this.progressBar1.Maximum = this.userData1.Tables["HWD"].Rows.Count;
						this.strQuery = "SELECT * FROM Win32_Product WHERE Name like '%" + app + "%'";
						this.caption = "Caption";
						foreach(DataRow drs in this.userData1.Tables["HWD"].Rows) 
						{
							SystemScan par = new SystemScan(drs["Username"].ToString(), drs["ComputerName"].ToString());
							ThreadPool.QueueUserWorkItem(new WaitCallback(ScanItems), par);
						}
						this.button2.Enabled = true;
						this.toprint = "Application " + app;
					} 
					else 
					{
						MessageBox.Show("This reporter needs a value");
					}
					break;
				case "HotFix*":
					if (app.Length > 0) 
					{
						this.progressBar1.Maximum = this.userData1.Tables["HWD"].Rows.Count;
						this.strQuery = "SELECT * FROM Win32_QuickFixEngineering WHERE Description like '%" + app + "%' OR HotFixID like '%" + app + "%'";
						this.caption = "Caption";
						foreach(DataRow drs in this.userData1.Tables["HWD"].Rows) 
						{
							SystemScan par = new SystemScan(drs["Username"].ToString(), drs["ComputerName"].ToString());
							ThreadPool.QueueUserWorkItem(new WaitCallback(ScanItems), par);
						}
						this.button2.Enabled = true;
						this.toprint = "HotFix " + app;
					} 
					else 
					{
						MessageBox.Show("This reporter needs a value");
					}
					break;
				default:
					MessageBox.Show("What are you trying to do?");
					break;
			}
			if (this.caption != "")
				this.lstItems.Columns[1].Text = this.caption;

			this.button1.Enabled = false;
		}

		private void addRow(DataRow r)
		{
			this.dt.Rows.Add(r);
		}

		private void addItem(string[] p)
		{
			ListViewItem lvi = new ListViewItem(p);
			this.lstItems.Items.Add(lvi);
		}

		private void ScanItems(Object pars)
		{
			this.titleBar1.PostText = "Scanning...";
			SystemScan par = (SystemScan) pars;
			this.progressBar1.Value++;
			try 
			{
				if (this.anotherLogin && this.username.Length > 0)
				{
					co.Username = this.username;
					co.Password = this.password;
				}

				System.Management.ManagementScope ms = new System.Management.ManagementScope("\\\\" + par.ComputerName + "\\root\\cimv2", co);
				oq = new System.Management.ObjectQuery(strQuery);
				query = new ManagementObjectSearcher(ms,oq);
				queryCollection = query.Get();

				foreach(ManagementObject mo in queryCollection)
				{
					DataRow dr = this.dt.NewRow();
	
					dr["ComputerName"] = par.ComputerName;
					dr["UserName"] = par.Username;
					dr["ItemCaption"] = mo[caption].ToString();
					
					Invoke(new addRowItemDelegate(addRow),new object[]{dr});

					string[] vals = new string[2];
					vals[0] = par.ComputerName;
					vals[1] = mo[caption].ToString();
					
					Invoke(new addItemReporterDelegate(addItem), new object[] {vals});
				}
			}
			catch 
			{
				return;
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			if (this.dataView1.Table.Rows.Count > 1) 
			{
				this.Cursor = Cursors.WaitCursor;
				try
				{
					ReportMWD tmpRep = new ReportMWD();
					tmpRep.dataview = this.dataView1;
					tmpRep.Title = "Report of - " + this.toprint;
					preview pre = new preview();
					pre.irp = tmpRep;
					pre.ShowDialog();
				}
				catch 
				{
					MessageBox.Show(this, "Unable Report", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				this.Cursor = Cursors.Default;
			}
		}
	}

	public class SystemScan 
	{
		public string Username;
		public string ComputerName;

		public SystemScan(string user, string machine) 
		{
			Username = user;
			ComputerName = machine;
		}
	}

}
