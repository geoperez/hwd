using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.IO;
using System.Management;
using System.Diagnostics;

namespace HWD
{
	public delegate void updateListDelegate(int i, string tag);

	public class HotFixInstaller : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListView lsvMachines;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.ComponentModel.IContainer components;
		public bool anotherLogin;
		public string username;
		public string password;
		public string url;
		public string computername;
		public bool restart;
		private Crownwood.DotNetMagic.Controls.TabControl tabControl2;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage4;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage5;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage6;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtUrl;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtComputer;
		private System.Windows.Forms.CheckBox chkRestart;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button9;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button1;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button2;
		private System.Windows.Forms.ImageList imageList1;
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar1;
		private ListViewItem lvi;

		public HotFixInstaller()
		{
			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(HotFixInstaller));
			this.lsvMachines = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.tabControl2 = new Crownwood.DotNetMagic.Controls.TabControl();
			this.tabPage4 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.button9 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.label1 = new System.Windows.Forms.Label();
			this.txtUrl = new System.Windows.Forms.TextBox();
			this.tabPage5 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.button1 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.label2 = new System.Windows.Forms.Label();
			this.txtComputer = new System.Windows.Forms.TextBox();
			this.tabPage6 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.button2 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.chkRestart = new System.Windows.Forms.CheckBox();
			this.titleBar1 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.tabControl2.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.SuspendLayout();
			// 
			// lsvMachines
			// 
			this.lsvMachines.BackColor = System.Drawing.Color.White;
			this.lsvMachines.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						  this.columnHeader1,
																						  this.columnHeader2});
			this.lsvMachines.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lsvMachines.Location = new System.Drawing.Point(0, 133);
			this.lsvMachines.Name = "lsvMachines";
			this.lsvMachines.Size = new System.Drawing.Size(504, 160);
			this.lsvMachines.StateImageList = this.imageList1;
			this.lsvMachines.TabIndex = 0;
			this.lsvMachines.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Computer Name";
			this.columnHeader1.Width = 224;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Status";
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// tabControl2
			// 
			this.tabControl2.BackColor = System.Drawing.SystemColors.Control;
			this.tabControl2.ButtonActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.tabControl2.ButtonInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.tabControl2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.tabControl2.HotTextColor = System.Drawing.SystemColors.ActiveCaption;
			this.tabControl2.ImageList = null;
			this.tabControl2.Location = new System.Drawing.Point(0, 40);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.OfficeDockSides = false;
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(504, 88);
			this.tabControl2.TabIndex = 19;
			this.tabControl2.TabPages.AddRange(new Crownwood.DotNetMagic.Controls.TabPage[] {
																								this.tabPage4,
																								this.tabPage5,
																								this.tabPage6});
			this.tabControl2.TextColor = System.Drawing.SystemColors.ControlText;
			this.tabControl2.TextInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.tabControl2.TextTips = true;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.button9);
			this.tabPage4.Controls.Add(this.progressBar1);
			this.tabPage4.Controls.Add(this.label1);
			this.tabPage4.Controls.Add(this.txtUrl);
			this.tabPage4.InactiveBackColor = System.Drawing.Color.Empty;
			this.tabPage4.InactiveTextBackColor = System.Drawing.Color.Empty;
			this.tabPage4.InactiveTextColor = System.Drawing.Color.Empty;
			this.tabPage4.Location = new System.Drawing.Point(1, 1);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.SelectBackColor = System.Drawing.Color.Empty;
			this.tabPage4.SelectTextBackColor = System.Drawing.Color.Empty;
			this.tabPage4.SelectTextColor = System.Drawing.Color.Empty;
			this.tabPage4.Size = new System.Drawing.Size(502, 63);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Title = "Download Patch";
			this.tabPage4.ToolTip = "Page";
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(400, 8);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(96, 36);
			this.button9.TabIndex = 22;
			this.button9.Text = "Download";
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(11, 32);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(368, 24);
			this.progressBar1.Step = 1;
			this.progressBar1.TabIndex = 21;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(11, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 18;
			this.label1.Text = "URL Patch:";
			// 
			// txtUrl
			// 
			this.txtUrl.BackColor = System.Drawing.Color.White;
			this.txtUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtUrl.Location = new System.Drawing.Point(91, 8);
			this.txtUrl.Name = "txtUrl";
			this.txtUrl.Size = new System.Drawing.Size(256, 18);
			this.txtUrl.TabIndex = 20;
			this.txtUrl.Text = "";
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.button1);
			this.tabPage5.Controls.Add(this.label2);
			this.tabPage5.Controls.Add(this.txtComputer);
			this.tabPage5.InactiveBackColor = System.Drawing.Color.Empty;
			this.tabPage5.InactiveTextBackColor = System.Drawing.Color.Empty;
			this.tabPage5.InactiveTextColor = System.Drawing.Color.Empty;
			this.tabPage5.Location = new System.Drawing.Point(1, 1);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.SelectBackColor = System.Drawing.Color.Empty;
			this.tabPage5.Selected = false;
			this.tabPage5.SelectTextBackColor = System.Drawing.Color.Empty;
			this.tabPage5.SelectTextColor = System.Drawing.Color.Empty;
			this.tabPage5.Size = new System.Drawing.Size(502, 63);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Title = "Add Computer";
			this.tabPage5.ToolTip = "Page";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(400, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 36);
			this.button1.TabIndex = 23;
			this.button1.Text = "Add";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 32);
			this.label2.TabIndex = 20;
			this.label2.Text = "Computer Name:";
			// 
			// txtComputer
			// 
			this.txtComputer.BackColor = System.Drawing.Color.White;
			this.txtComputer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtComputer.Location = new System.Drawing.Point(88, 8);
			this.txtComputer.Name = "txtComputer";
			this.txtComputer.Size = new System.Drawing.Size(256, 18);
			this.txtComputer.TabIndex = 22;
			this.txtComputer.Text = "";
			// 
			// tabPage6
			// 
			this.tabPage6.Controls.Add(this.button2);
			this.tabPage6.Controls.Add(this.chkRestart);
			this.tabPage6.InactiveBackColor = System.Drawing.Color.Empty;
			this.tabPage6.InactiveTextBackColor = System.Drawing.Color.Empty;
			this.tabPage6.InactiveTextColor = System.Drawing.Color.Empty;
			this.tabPage6.Location = new System.Drawing.Point(1, 1);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.SelectBackColor = System.Drawing.Color.Empty;
			this.tabPage6.Selected = false;
			this.tabPage6.SelectTextBackColor = System.Drawing.Color.Empty;
			this.tabPage6.SelectTextColor = System.Drawing.Color.Empty;
			this.tabPage6.Size = new System.Drawing.Size(502, 63);
			this.tabPage6.TabIndex = 5;
			this.tabPage6.Title = "Install Patch";
			this.tabPage6.ToolTip = "Page";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(400, 8);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(96, 36);
			this.button2.TabIndex = 23;
			this.button2.Text = "Install";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// chkRestart
			// 
			this.chkRestart.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkRestart.Location = new System.Drawing.Point(16, 8);
			this.chkRestart.Name = "chkRestart";
			this.chkRestart.Size = new System.Drawing.Size(152, 24);
			this.chkRestart.TabIndex = 20;
			this.chkRestart.Text = "Restart after install patch";
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
			this.titleBar1.PostText = "First Download Patch";
			this.titleBar1.Size = new System.Drawing.Size(504, 40);
			this.titleBar1.TabIndex = 20;
			this.titleBar1.Text = "HotFix Installer";
			// 
			// HotFixInstaller
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(504, 293);
			this.Controls.Add(this.titleBar1);
			this.Controls.Add(this.tabControl2);
			this.Controls.Add(this.lsvMachines);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximumSize = new System.Drawing.Size(512, 320);
			this.MinimumSize = new System.Drawing.Size(512, 320);
			this.Name = "HotFixInstaller";
			this.Text = "Hotfix Installer";
			this.Load += new System.EventHandler(this.HotFixInstaller_Load);
			this.Closed += new System.EventHandler(this.HotFixInstaller_Closed);
			this.tabControl2.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.tabPage6.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public void runApp(Object stateInfo)
		{
			parRun par = (parRun) stateInfo;
			try 
			{
				System.Management.ConnectionOptions co = new ConnectionOptions();
				if (this.anotherLogin == true && this.username.Length > 0)
				{
					co.Username = this.username;
					co.Password = this.password;
				}
				ManagementScope ms = new ManagementScope("\\\\" + par.ComputerName + "\\root\\cimv2", co);
				ms.Connect();
				ManagementClass mc  = new ManagementClass("Win32_Process");
				mc.Scope = ms;
				System.Management.ManagementBaseObject parameters;
				parameters=mc.GetMethodParameters("Create");
				ManagementClass mc2 = new ManagementClass("Win32_ProcessStartup");
				mc2.Scope = ms;
				if (this.chkRestart.Checked) 
				{
					parameters["CommandLine"] = par.App + " /quiet /forcerestart /f";
				} 
				else 
				{
					parameters["CommandLine"] = par.App + " /quiet /norestart";
				}
				parameters["ProcessStartupInformation"]=mc2;
				mc.InvokeMethod("Create",parameters,null);
				this.Invoke(new updateListDelegate(UpdateList), new object[] {par.I, "Installed"});
			}
			catch 
			{
				this.Invoke(new updateListDelegate(UpdateList), new object[] {par.I, "Error"});
			}
		}

		private void DownloadFile(string remoteFilename, string localFilename)
		{
			int bytesProcessed = 0;

			Stream remoteStream  = null;
			Stream localStream   = null;
			WebResponse response = null;

			try
			{
				WebRequest request = WebRequest.Create(remoteFilename);
				if (request != null)
				{
					response = request.GetResponse();
					if (response != null)
					{
						remoteStream = response.GetResponseStream();

						localStream = File.Create(localFilename);

						byte[] buffer = new byte[4096];
						int bytesRead;
						do
						{
							bytesRead = remoteStream.Read (buffer, 0, buffer.Length);
							localStream.Write (buffer, 0, bytesRead);
							bytesProcessed += bytesRead;
							this.Invoke(new AvanceDownload(UpdateProgress), new object[] {bytesProcessed,response.ContentLength});
						} while (bytesRead > 0);
					}
				}
			}
			catch(Exception e)
			{
				MessageBox.Show(e.ToString());
			}
			finally
			{
				if (response     != null) response.Close();
				if (remoteStream != null) remoteStream.Close();
				if (localStream  != null) localStream.Close();
			}
			return;
		}

		public void shareFolder(bool on)
		{
			if (on) 
			{
				ProcessStartInfo prs = new ProcessStartInfo("net.exe", "share hwdtemp="+Environment.CurrentDirectory);
				prs.WindowStyle = ProcessWindowStyle.Hidden;
				Process.Start(prs);
			} 
			else 
			{
				ProcessStartInfo prs = new ProcessStartInfo("net.exe", "share hwdtemp /DELETE");
				prs.WindowStyle = ProcessWindowStyle.Hidden;
				Process.Start(prs);
			}
		}

		private void UpdateProgress(long receivedBytes, long totalBytes)
		{
			this.progressBar1.Value = Convert.ToInt32(Math.Floor((receivedBytes * 100) / totalBytes));
		}

		private void UpdateList(int i, string tag)
		{
			this.lsvMachines.Items[i].SubItems[1].Text = tag;
		}

		private void button9_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			if (File.Exists("temp.exe"))
			{
				File.Delete("temp.exe");
			}
			this.DownloadFile(this.url, "temp.exe");
			this.button9.Enabled = false;
			this.button1.Enabled = true;
			this.button2.Enabled = true;
			this.titleBar1.PostText = "Install Patch";
			this.Cursor = Cursors.Default;
		}

		private void HotFixInstaller_Load(object sender, System.EventArgs e)
		{
			this.button1.Enabled = false;
			this.button2.Enabled = false;
			if (this.computername.Length > 1) 
			{
				lvi = new ListViewItem(new string[] {this.computername, "Pending"}, 0);
				this.lsvMachines.Items.Add(lvi);
			}
			this.txtUrl.Text = this.url;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if (this.txtComputer.Text.Length > 1)
			{
				lvi = new ListViewItem(new string[] {this.txtComputer.Text, "Pending"}, 0);
				this.lsvMachines.Items.Add(lvi);
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.button2.Enabled = false;
			this.shareFolder(true);
			string UNC = "\\\\" + Environment.MachineName + "\\hwdtemp\\temp.exe";
			int k = 0;
			foreach(ListViewItem lv in this.lsvMachines.Items)
			{
				string computer = lv.SubItems[0].Text;
				lv.SubItems[1].Text = "Installing...";
				parRun par = new parRun(computer, UNC, k);
				ThreadPool.QueueUserWorkItem(new WaitCallback(runApp), par);
				k++;
			}
		}

		private void HotFixInstaller_Closed(object sender, System.EventArgs e)
		{
			if (File.Exists("temp.exe"))
			{
				File.Delete("temp.exe");
			}
			this.shareFolder(false);
		}
	}

	public class parRun 
	{
		public string ComputerName;
		public string App;
		public int I;

		public parRun(string machine, string app, int i) 
		{
			App = app;
			ComputerName = machine;
			I = i;
		}
	}
}
