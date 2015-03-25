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
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListView lsvMachines;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.TextBox txtUrl;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtComputer;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.CheckBox chkRestart;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.ComponentModel.Container components = null;
		public bool anotherLogin;
		public string username;
		public string password;
		public string url;
		public string computername;
		public bool restart;
		private ListViewItem lvi;

		public HotFixInstaller()
		{
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(HotFixInstaller));
			this.lsvMachines = new System.Windows.Forms.ListView();
			this.label1 = new System.Windows.Forms.Label();
			this.button9 = new System.Windows.Forms.Button();
			this.txtUrl = new System.Windows.Forms.TextBox();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txtComputer = new System.Windows.Forms.TextBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.chkRestart = new System.Windows.Forms.CheckBox();
			this.button2 = new System.Windows.Forms.Button();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// lsvMachines
			// 
			this.lsvMachines.BackColor = System.Drawing.Color.OldLace;
			this.lsvMachines.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						  this.columnHeader1,
																						  this.columnHeader2});
			this.lsvMachines.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lsvMachines.Location = new System.Drawing.Point(0, 85);
			this.lsvMachines.Name = "lsvMachines";
			this.lsvMachines.Size = new System.Drawing.Size(504, 208);
			this.lsvMachines.TabIndex = 0;
			this.lsvMachines.View = System.Windows.Forms.View.Details;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "URL Patch:";
			// 
			// button9
			// 
			this.button9.BackColor = System.Drawing.Color.SaddleBrown;
			this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button9.ForeColor = System.Drawing.Color.OldLace;
			this.button9.Location = new System.Drawing.Point(384, 8);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(104, 32);
			this.button9.TabIndex = 15;
			this.button9.Text = "Download";
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// txtUrl
			// 
			this.txtUrl.BackColor = System.Drawing.Color.OldLace;
			this.txtUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtUrl.Location = new System.Drawing.Point(88, 8);
			this.txtUrl.Name = "txtUrl";
			this.txtUrl.Size = new System.Drawing.Size(256, 20);
			this.txtUrl.TabIndex = 16;
			this.txtUrl.Text = "";
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
			// tabControl1
			// 
			this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(504, 88);
			this.tabControl1.TabIndex = 18;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.Color.Tan;
			this.tabPage1.Controls.Add(this.progressBar1);
			this.tabPage1.Controls.Add(this.button9);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.txtUrl);
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(496, 59);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Download Patch";
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.Color.Tan;
			this.tabPage2.Controls.Add(this.button1);
			this.tabPage2.Controls.Add(this.label2);
			this.tabPage2.Controls.Add(this.txtComputer);
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(496, 59);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Add Computer";
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.SaddleBrown;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button1.ForeColor = System.Drawing.Color.OldLace;
			this.button1.Location = new System.Drawing.Point(384, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(104, 32);
			this.button1.TabIndex = 18;
			this.button1.Text = "Add";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 32);
			this.label2.TabIndex = 17;
			this.label2.Text = "Computer Name:";
			// 
			// txtComputer
			// 
			this.txtComputer.BackColor = System.Drawing.Color.OldLace;
			this.txtComputer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtComputer.Location = new System.Drawing.Point(88, 8);
			this.txtComputer.Name = "txtComputer";
			this.txtComputer.Size = new System.Drawing.Size(256, 20);
			this.txtComputer.TabIndex = 19;
			this.txtComputer.Text = "";
			// 
			// tabPage3
			// 
			this.tabPage3.BackColor = System.Drawing.Color.Tan;
			this.tabPage3.Controls.Add(this.button2);
			this.tabPage3.Controls.Add(this.chkRestart);
			this.tabPage3.Location = new System.Drawing.Point(4, 25);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(496, 59);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Install Patch";
			// 
			// chkRestart
			// 
			this.chkRestart.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkRestart.Location = new System.Drawing.Point(8, 8);
			this.chkRestart.Name = "chkRestart";
			this.chkRestart.Size = new System.Drawing.Size(152, 24);
			this.chkRestart.TabIndex = 18;
			this.chkRestart.Text = "Restart after install patch";
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.SaddleBrown;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button2.ForeColor = System.Drawing.Color.OldLace;
			this.button2.Location = new System.Drawing.Point(384, 8);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(104, 32);
			this.button2.TabIndex = 19;
			this.button2.Text = "Install";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(8, 32);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(368, 24);
			this.progressBar1.Step = 1;
			this.progressBar1.TabIndex = 17;
			// 
			// HotFixInstaller
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Tan;
			this.ClientSize = new System.Drawing.Size(504, 293);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.lsvMachines);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximumSize = new System.Drawing.Size(512, 320);
			this.MinimumSize = new System.Drawing.Size(512, 320);
			this.Name = "HotFixInstaller";
			this.Text = "Hotfix Installer";
			this.Load += new System.EventHandler(this.HotFixInstaller_Load);
			this.Closed += new System.EventHandler(this.HotFixInstaller_Closed);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
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
			this.Cursor = Cursors.Default;
		}

		private void HotFixInstaller_Load(object sender, System.EventArgs e)
		{
			this.button1.Enabled = false;
			this.button2.Enabled = false;
			if (this.computername.Length > 1) 
			{
				lvi = new ListViewItem(new string[] {this.computername, "Pending"});
				this.lsvMachines.Items.Add(lvi);
			}
			this.txtUrl.Text = this.url;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if (this.txtComputer.Text.Length > 1)
			{
				lvi = new ListViewItem(new string[] {this.txtComputer.Text, "Pending"});
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
