using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Management;
using System.Resources;

namespace HWD
{
	public delegate void addItemDelegate(ListViewItem lvitem);

	public class Details : System.Windows.Forms.Form
	{
		private HWD.DetailsControls.PortScan portscan;
		private HWD.DetailsControls.Performance perf;
		private HWD.DetailsControls.SharedItems shareditems;
		private HWD.DetailsControls.EventLog eventlog;
		private HWD.DetailsControls.HotFix hotfixc;
		private HWD.DetailsControls.Process proc;
		private HWD.DetailsControls.Services services;
		private HWD.DetailsControls.Software software;
		private HWD.DetailsControls.Hardware hardware;
		public string name;
		public string computer;
		public bool hotfixfile;
		public static bool anotherLogin;
		public static string username;
		public static string password;
		public static string insys;
		private System.ComponentModel.IContainer components;
		private ResourceManager m_ResourceManager;
		private Crownwood.DotNetMagic.Controls.TabControl tabControl2;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage1;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage5;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage8;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage3;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage9;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage2;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage4;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage6;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage7;
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar1;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button1;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle btnCancel;

		public ResourceManager rsxmgr
		{
			set
			{
				this.m_ResourceManager = value;
			}

		}

		public Details()
		{
			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Details));
			this.tabControl2 = new Crownwood.DotNetMagic.Controls.TabControl();
			this.tabPage1 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.tabPage5 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.tabPage2 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.tabPage8 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.tabPage3 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.tabPage9 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.tabPage4 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.tabPage6 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.tabPage7 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.titleBar1 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.button1 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.btnCancel = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.tabControl2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl2
			// 
			this.tabControl2.Appearance = Crownwood.DotNetMagic.Controls.VisualAppearance.MultiBox;
			this.tabControl2.BackColor = System.Drawing.SystemColors.Control;
			this.tabControl2.ButtonActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.tabControl2.ButtonInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.tabControl2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.tabControl2.HotTextColor = System.Drawing.SystemColors.ActiveCaption;
			this.tabControl2.ImageList = null;
			this.tabControl2.Location = new System.Drawing.Point(0, 40);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.OfficeDockSides = false;
			this.tabControl2.OfficeHeaderBorder = true;
			this.tabControl2.OfficeStyle = Crownwood.DotNetMagic.Controls.OfficeStyle.LightEnhanced;
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(616, 320);
			this.tabControl2.TabIndex = 10;
			this.tabControl2.TabPages.AddRange(new Crownwood.DotNetMagic.Controls.TabPage[] {
																								this.tabPage1,
																								this.tabPage5,
																								this.tabPage2,
																								this.tabPage8,
																								this.tabPage3,
																								this.tabPage9,
																								this.tabPage4,
																								this.tabPage6,
																								this.tabPage7});
			this.tabControl2.TextColor = System.Drawing.SystemColors.ControlText;
			this.tabControl2.TextInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.tabControl2.TextTips = true;
			this.tabControl2.SelectionChanged += new Crownwood.DotNetMagic.Controls.SelectTabHandler(this.tabControl2_SelectionChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.InactiveBackColor = System.Drawing.Color.Empty;
			this.tabPage1.InactiveTextBackColor = System.Drawing.Color.Empty;
			this.tabPage1.InactiveTextColor = System.Drawing.Color.Empty;
			this.tabPage1.Location = new System.Drawing.Point(1, 1);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.SelectBackColor = System.Drawing.Color.Empty;
			this.tabPage1.SelectTextBackColor = System.Drawing.Color.Empty;
			this.tabPage1.SelectTextColor = System.Drawing.Color.Empty;
			this.tabPage1.Size = new System.Drawing.Size(614, 289);
			this.tabPage1.TabIndex = 3;
			this.tabPage1.Title = "Hardware";
			this.tabPage1.ToolTip = "Page";
			// 
			// tabPage5
			// 
			this.tabPage5.InactiveBackColor = System.Drawing.Color.Empty;
			this.tabPage5.InactiveTextBackColor = System.Drawing.Color.Empty;
			this.tabPage5.InactiveTextColor = System.Drawing.Color.Empty;
			this.tabPage5.Location = new System.Drawing.Point(1, 1);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.SelectBackColor = System.Drawing.Color.Empty;
			this.tabPage5.Selected = false;
			this.tabPage5.SelectTextBackColor = System.Drawing.Color.Empty;
			this.tabPage5.SelectTextColor = System.Drawing.Color.Empty;
			this.tabPage5.Size = new System.Drawing.Size(614, 289);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Title = "Performance";
			this.tabPage5.ToolTip = "Page";
			// 
			// tabPage2
			// 
			this.tabPage2.InactiveBackColor = System.Drawing.Color.Empty;
			this.tabPage2.InactiveTextBackColor = System.Drawing.Color.Empty;
			this.tabPage2.InactiveTextColor = System.Drawing.Color.Empty;
			this.tabPage2.Location = new System.Drawing.Point(1, 1);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.SelectBackColor = System.Drawing.Color.Empty;
			this.tabPage2.Selected = false;
			this.tabPage2.SelectTextBackColor = System.Drawing.Color.Empty;
			this.tabPage2.SelectTextColor = System.Drawing.Color.Empty;
			this.tabPage2.Size = new System.Drawing.Size(614, 289);
			this.tabPage2.TabIndex = 8;
			this.tabPage2.Title = "Software";
			this.tabPage2.ToolTip = "Page";
			// 
			// tabPage8
			// 
			this.tabPage8.InactiveBackColor = System.Drawing.Color.Empty;
			this.tabPage8.InactiveTextBackColor = System.Drawing.Color.Empty;
			this.tabPage8.InactiveTextColor = System.Drawing.Color.Empty;
			this.tabPage8.Location = new System.Drawing.Point(1, 1);
			this.tabPage8.Name = "tabPage8";
			this.tabPage8.SelectBackColor = System.Drawing.Color.Empty;
			this.tabPage8.Selected = false;
			this.tabPage8.SelectTextBackColor = System.Drawing.Color.Empty;
			this.tabPage8.SelectTextColor = System.Drawing.Color.Empty;
			this.tabPage8.Size = new System.Drawing.Size(614, 289);
			this.tabPage8.TabIndex = 5;
			this.tabPage8.Title = "Hotfixes";
			this.tabPage8.ToolTip = "Page";
			// 
			// tabPage3
			// 
			this.tabPage3.InactiveBackColor = System.Drawing.Color.Empty;
			this.tabPage3.InactiveTextBackColor = System.Drawing.Color.Empty;
			this.tabPage3.InactiveTextColor = System.Drawing.Color.Empty;
			this.tabPage3.Location = new System.Drawing.Point(1, 1);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.SelectBackColor = System.Drawing.Color.Empty;
			this.tabPage3.Selected = false;
			this.tabPage3.SelectTextBackColor = System.Drawing.Color.Empty;
			this.tabPage3.SelectTextColor = System.Drawing.Color.Empty;
			this.tabPage3.Size = new System.Drawing.Size(614, 289);
			this.tabPage3.TabIndex = 6;
			this.tabPage3.Title = "Processes";
			this.tabPage3.ToolTip = "Page";
			// 
			// tabPage9
			// 
			this.tabPage9.InactiveBackColor = System.Drawing.Color.Empty;
			this.tabPage9.InactiveTextBackColor = System.Drawing.Color.Empty;
			this.tabPage9.InactiveTextColor = System.Drawing.Color.Empty;
			this.tabPage9.Location = new System.Drawing.Point(1, 1);
			this.tabPage9.Name = "tabPage9";
			this.tabPage9.SelectBackColor = System.Drawing.Color.Empty;
			this.tabPage9.Selected = false;
			this.tabPage9.SelectTextBackColor = System.Drawing.Color.Empty;
			this.tabPage9.SelectTextColor = System.Drawing.Color.Empty;
			this.tabPage9.Size = new System.Drawing.Size(614, 289);
			this.tabPage9.TabIndex = 7;
			this.tabPage9.Title = "Event Log";
			this.tabPage9.ToolTip = "Page";
			// 
			// tabPage4
			// 
			this.tabPage4.InactiveBackColor = System.Drawing.Color.Empty;
			this.tabPage4.InactiveTextBackColor = System.Drawing.Color.Empty;
			this.tabPage4.InactiveTextColor = System.Drawing.Color.Empty;
			this.tabPage4.Location = new System.Drawing.Point(1, 1);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.SelectBackColor = System.Drawing.Color.Empty;
			this.tabPage4.Selected = false;
			this.tabPage4.SelectTextBackColor = System.Drawing.Color.Empty;
			this.tabPage4.SelectTextColor = System.Drawing.Color.Empty;
			this.tabPage4.Size = new System.Drawing.Size(614, 289);
			this.tabPage4.TabIndex = 9;
			this.tabPage4.Title = "Services";
			this.tabPage4.ToolTip = "Page";
			// 
			// tabPage6
			// 
			this.tabPage6.InactiveBackColor = System.Drawing.Color.Empty;
			this.tabPage6.InactiveTextBackColor = System.Drawing.Color.Empty;
			this.tabPage6.InactiveTextColor = System.Drawing.Color.Empty;
			this.tabPage6.Location = new System.Drawing.Point(1, 1);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.SelectBackColor = System.Drawing.Color.Empty;
			this.tabPage6.Selected = false;
			this.tabPage6.SelectTextBackColor = System.Drawing.Color.Empty;
			this.tabPage6.SelectTextColor = System.Drawing.Color.Empty;
			this.tabPage6.Size = new System.Drawing.Size(614, 289);
			this.tabPage6.TabIndex = 10;
			this.tabPage6.Title = "Shared Items";
			this.tabPage6.ToolTip = "Page";
			// 
			// tabPage7
			// 
			this.tabPage7.InactiveBackColor = System.Drawing.Color.Empty;
			this.tabPage7.InactiveTextBackColor = System.Drawing.Color.Empty;
			this.tabPage7.InactiveTextColor = System.Drawing.Color.Empty;
			this.tabPage7.Location = new System.Drawing.Point(1, 1);
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.SelectBackColor = System.Drawing.Color.Empty;
			this.tabPage7.Selected = false;
			this.tabPage7.SelectTextBackColor = System.Drawing.Color.Empty;
			this.tabPage7.SelectTextColor = System.Drawing.Color.Empty;
			this.tabPage7.Size = new System.Drawing.Size(614, 289);
			this.tabPage7.TabIndex = 11;
			this.tabPage7.Title = "Ports";
			this.tabPage7.ToolTip = "Page";
			// 
			// titleBar1
			// 
			this.titleBar1.GradientActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(136)), ((System.Byte)(144)), ((System.Byte)(156)));
			this.titleBar1.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
			this.titleBar1.GradientDirection = Crownwood.DotNetMagic.Controls.GradientDirection.TopToBottom;
			this.titleBar1.GradientInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(230)), ((System.Byte)(231)), ((System.Byte)(228)));
			this.titleBar1.Icon = ((System.Drawing.Icon)(resources.GetObject("titleBar1.Icon")));
			this.titleBar1.Location = new System.Drawing.Point(0, 0);
			this.titleBar1.MouseOverColor = System.Drawing.Color.Empty;
			this.titleBar1.Name = "titleBar1";
			this.titleBar1.PostText = "Online";
			this.titleBar1.PreText = "Details";
			this.titleBar1.Size = new System.Drawing.Size(616, 40);
			this.titleBar1.TabIndex = 11;
			this.titleBar1.Text = "-";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(448, 368);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 32);
			this.button1.TabIndex = 12;
			this.button1.Text = "&OK";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(536, 368);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(72, 32);
			this.btnCancel.TabIndex = 13;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// Details
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(616, 404);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.titleBar1);
			this.Controls.Add(this.tabControl2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(622, 432);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(622, 432);
			this.Name = "Details";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "HWD - Details";
			this.Load += new System.EventHandler(this.Details_Load);
			this.tabControl2.ResumeLayout(false);
			this.ResumeLayout(false);
			
		}
		#endregion

		private void Details_Load(object sender, System.EventArgs e)
		{
			this.titleBar1.Text = this.name;
			HWD.Details.insys = this.name;
			ConnectionOptions co = new ConnectionOptions();
			if (HWD.Details.anotherLogin == true && HWD.Details.username.Length > 0)
			{
				co.Username = HWD.Details.username;
				co.Password = HWD.Details.password;
			}
			System.Management.ManagementScope ms = new System.Management.ManagementScope("\\\\" + this.name + "\\root\\cimv2", co);
			try 
			{
				ManagementObjectCollection queryCollection = new ManagementObjectSearcher(ms, new ObjectQuery("SELECT * FROM Win32_NetworkAdapter")).Get();
			} 
			catch 
			{
				MessageBox.Show(this, "Failed connection to system.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				this.DialogResult = DialogResult.Abort;
			}
			this.btnCancel.Text = m_ResourceManager.GetString("dbtnCancel");
			this.LoadMods();
		}

		private void ChangeStatus(string text)
		{
			this.titleBar1.PostText = text;
			this.Update();
		}

		private void LoadMods()
		{
			this.titleBar1.PostText = "Loading mods...";

			this.portscan = new HWD.DetailsControls.PortScan();
			this.portscan.Location = new System.Drawing.Point(0, 0);
			this.portscan.Name = "portscan";
			this.portscan.Size = new System.Drawing.Size(614, 289);
			this.portscan.Dock = DockStyle.Fill;
			this.tabPage7.Controls.Add(this.portscan);
			this.tabPage7.Text = m_ResourceManager.GetString("dtabPage7");
			this.portscan.rsxmgr = this.m_ResourceManager;

			this.perf = new HWD.DetailsControls.Performance();
			this.perf.Location = new System.Drawing.Point(0, 0);
			this.perf.Name = "perf";
			this.perf.Size = new System.Drawing.Size(614, 289);
			this.perf.Dock = DockStyle.Fill;
			this.tabPage5.Controls.Add(this.perf);
			this.tabPage5.Text = m_ResourceManager.GetString("dtabPage5");
			this.perf.rsxmgr = this.m_ResourceManager;

			this.shareditems = new HWD.DetailsControls.SharedItems();
			this.shareditems.Location = new System.Drawing.Point(0, 0);
			this.shareditems.Name = "shareditems";
			this.shareditems.Size = new System.Drawing.Size(614, 289);
			this.shareditems.Dock = DockStyle.Fill;
			this.tabPage6.Controls.Add(this.shareditems);
			this.tabPage6.Text = m_ResourceManager.GetString("dtabPage6");
			this.shareditems.rsxmgr = this.m_ResourceManager;

			this.eventlog = new HWD.DetailsControls.EventLog();
			this.eventlog.Location = new System.Drawing.Point(0, 0);
			this.eventlog.Name = "eventlog";
			this.eventlog.Size = new System.Drawing.Size(614, 289);
			this.eventlog.Dock = DockStyle.Fill;
			this.tabPage9.Controls.Add(this.eventlog);
			this.tabPage9.Text = m_ResourceManager.GetString("dtabPage9"); 
			this.eventlog.rsxmgr = this.m_ResourceManager;
			this.eventlog.ChangeStatus += new HWD.DetailsControls.EventLog.Status(this.ChangeStatus);

			if (this.hotfixfile)
			{
				this.hotfixc = new HWD.DetailsControls.HotFix();
				this.hotfixc.Location = new System.Drawing.Point(0, 0);
				this.hotfixc.Name = "hotfixc";
				this.hotfixc.Size = new System.Drawing.Size(614, 289);
				this.hotfixc.Dock = DockStyle.Fill;
				this.tabPage8.Controls.Add(this.hotfixc);
				this.tabPage8.Text = m_ResourceManager.GetString("dtabPage8");
				this.hotfixc.rsxmgr = this.m_ResourceManager;
				this.hotfixc.ChangeStatus += new HWD.DetailsControls.HotFix.Status(this.ChangeStatus);
			} 
			else 
			{
				this.tabControl2.TabPages.Remove(this.tabPage8);
			}

			this.proc = new HWD.DetailsControls.Process();
			this.proc.Location = new System.Drawing.Point(0, 0);
			this.proc.Name = "proc";
			this.proc.Size = new System.Drawing.Size(614, 289);
			this.proc.Dock = DockStyle.Fill;
			this.tabPage3.Controls.Add(this.proc);
			this.proc.ChangeStatus += new HWD.DetailsControls.Process.Status(this.ChangeStatus);

			this.services = new HWD.DetailsControls.Services();
			this.services.Location = new System.Drawing.Point(0, 0);
			this.services.Name = "portscan";
			this.services.Size = new System.Drawing.Size(614, 289);
			this.services.Dock = DockStyle.Fill;
			this.tabPage4.Controls.Add(this.services);
			this.tabPage4.Text = m_ResourceManager.GetString("dtabPage4");
			this.services.rsxmgr = this.m_ResourceManager;
			this.services.ChangeStatus += new HWD.DetailsControls.Services.Status(this.ChangeStatus);

			this.software = new HWD.DetailsControls.Software();
			this.software.Location = new System.Drawing.Point(0, 0);
			this.software.Name = "software";
			this.software.Size = new System.Drawing.Size(614, 289);
			this.software.Dock = DockStyle.Fill;
			this.tabPage2.Controls.Add(this.software);
			this.software.rsxmgr = this.m_ResourceManager;
			this.software.ChangeStatus += new HWD.DetailsControls.Software.Status(this.ChangeStatus);

			this.hardware = new HWD.DetailsControls.Hardware();
			this.hardware.Location = new System.Drawing.Point(0, 0);
			this.hardware.Name = "hardware";
			this.hardware.Size = new System.Drawing.Size(614, 289);
			this.hardware.Dock = DockStyle.Fill;
			this.tabPage1.Controls.Add(this.hardware);
			this.hardware.rsxmgr = this.m_ResourceManager;
			this.hardware.ChangeStatus += new HWD.DetailsControls.Hardware.Status(this.ChangeStatus);

			this.titleBar1.PostText = "Online";
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		public static System.Management.ManagementObjectCollection Consulta(string strQuery)
		{
			ManagementObjectCollection queryCollection;

			try
			{
				ConnectionOptions co = new ConnectionOptions();
				if (HWD.Details.anotherLogin && HWD.Details.username.Length > 0)
				{
					co.Username = HWD.Details.username;
					co.Password = HWD.Details.password;
				}
				System.Management.ManagementScope ms = new System.Management.ManagementScope("\\\\" + HWD.Details.insys + "\\root\\cimv2", co);
				queryCollection = new ManagementObjectSearcher(ms,new System.Management.ObjectQuery(strQuery)).Get();
			}
			catch
			{
				queryCollection=null;
			}
			return queryCollection;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		private void tabControl2_SelectionChanged(Crownwood.DotNetMagic.Controls.TabControl sender, Crownwood.DotNetMagic.Controls.TabPage oldPage, Crownwood.DotNetMagic.Controls.TabPage newPage)
		{
		
		}
	}
}
