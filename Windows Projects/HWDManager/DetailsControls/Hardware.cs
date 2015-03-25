using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Crownwood.DotNetMagic.Controls;
using System.Globalization;

namespace HWD.DetailsControls
{
	public class Hardware : System.Windows.Forms.UserControl
	{
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button4;
		private Crownwood.DotNetMagic.Controls.Node node1;
		private Crownwood.DotNetMagic.Controls.TreeControl treeControl1;
		private Crownwood.DotNetMagic.Controls.Node node2;
		private Crownwood.DotNetMagic.Controls.Node node3;
		private Crownwood.DotNetMagic.Controls.Node node4;
		private Crownwood.DotNetMagic.Controls.Node node5;
		private Crownwood.DotNetMagic.Controls.Node node6;
		private Crownwood.DotNetMagic.Controls.Node node7;
		private HWD.userData userData1;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button3;
		private ReportPrinting.ReportDocument reportDocument1;
		private bool rpReady = false;
		private string rpPrinters = string.Empty;
		private string rpProcessors = string.Empty;
		private string rpNICs = string.Empty;
		private string rpHDs = string.Empty;
		private string rpCDs = string.Empty;
		private System.ComponentModel.Container components = null;
		public delegate void Status(string e);
		public event Status ChangeStatus;
		private System.Resources.ResourceManager m_ResourceManager;

		public System.Resources.ResourceManager rsxmgr
		{
			set
			{
				this.m_ResourceManager = value;
			}

		}

		public Hardware()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Hardware));
			this.button4 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.node1 = new Crownwood.DotNetMagic.Controls.Node();
			this.treeControl1 = new Crownwood.DotNetMagic.Controls.TreeControl();
			this.node2 = new Crownwood.DotNetMagic.Controls.Node();
			this.node3 = new Crownwood.DotNetMagic.Controls.Node();
			this.node4 = new Crownwood.DotNetMagic.Controls.Node();
			this.node5 = new Crownwood.DotNetMagic.Controls.Node();
			this.node6 = new Crownwood.DotNetMagic.Controls.Node();
			this.node7 = new Crownwood.DotNetMagic.Controls.Node();
			this.userData1 = new HWD.userData();
			this.button3 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.reportDocument1 = new ReportPrinting.ReportDocument();
			((System.ComponentModel.ISupportInitialize)(this.userData1)).BeginInit();
			this.SuspendLayout();
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(8, 48);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(96, 32);
			this.button4.TabIndex = 21;
			this.button4.Text = "Scan Hardware";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// node1
			// 
			this.node1.BackColor = System.Drawing.SystemColors.Window;
			this.node1.Checked = true;
			this.node1.CheckState = Crownwood.DotNetMagic.Controls.CheckState.Checked;
			this.node1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.node1.Image = ((System.Drawing.Image)(resources.GetObject("node1.Image")));
			this.node1.NodeFont = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.node1.Text = "Processors";
			// 
			// treeControl1
			// 
			this.treeControl1.Dock = System.Windows.Forms.DockStyle.Right;
			this.treeControl1.GroupFont = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.treeControl1.HotBackColor = System.Drawing.Color.Empty;
			this.treeControl1.HotForeColor = System.Drawing.Color.Empty;
			this.treeControl1.Location = new System.Drawing.Point(126, 0);
			this.treeControl1.MinimumNodeHeight = 11;
			this.treeControl1.Name = "treeControl1";
			this.treeControl1.Nodes.AddRange(new Crownwood.DotNetMagic.Controls.Node[] {
																						   this.node1,
																						   this.node2,
																						   this.node3,
																						   this.node4,
																						   this.node5,
																						   this.node6,
																						   this.node7});
			this.treeControl1.SelectedNode = null;
			this.treeControl1.SelectedNoFocusBackColor = System.Drawing.SystemColors.Control;
			this.treeControl1.Size = new System.Drawing.Size(488, 289);
			this.treeControl1.TabIndex = 22;
			this.treeControl1.Text = "treeControl1";
			this.treeControl1.ViewControllers = Crownwood.DotNetMagic.Controls.ViewControllers.Group;
			// 
			// node2
			// 
			this.node2.BackColor = System.Drawing.SystemColors.Window;
			this.node2.Checked = true;
			this.node2.CheckState = Crownwood.DotNetMagic.Controls.CheckState.Checked;
			this.node2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.node2.Image = ((System.Drawing.Image)(resources.GetObject("node2.Image")));
			this.node2.NodeFont = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.node2.Text = "Network Adapters";
			// 
			// node3
			// 
			this.node3.BackColor = System.Drawing.SystemColors.Window;
			this.node3.Checked = true;
			this.node3.CheckState = Crownwood.DotNetMagic.Controls.CheckState.Checked;
			this.node3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.node3.Image = ((System.Drawing.Image)(resources.GetObject("node3.Image")));
			this.node3.NodeFont = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.node3.Text = "Video Adapters & Monitors";
			// 
			// node4
			// 
			this.node4.BackColor = System.Drawing.SystemColors.Window;
			this.node4.Checked = true;
			this.node4.CheckState = Crownwood.DotNetMagic.Controls.CheckState.Checked;
			this.node4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.node4.Image = ((System.Drawing.Image)(resources.GetObject("node4.Image")));
			this.node4.NodeFont = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.node4.Text = "Printers";
			// 
			// node5
			// 
			this.node5.BackColor = System.Drawing.SystemColors.Window;
			this.node5.Checked = true;
			this.node5.CheckState = Crownwood.DotNetMagic.Controls.CheckState.Checked;
			this.node5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.node5.Image = ((System.Drawing.Image)(resources.GetObject("node5.Image")));
			this.node5.NodeFont = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.node5.Text = "Hard Disks";
			// 
			// node6
			// 
			this.node6.BackColor = System.Drawing.SystemColors.Window;
			this.node6.Checked = true;
			this.node6.CheckState = Crownwood.DotNetMagic.Controls.CheckState.Checked;
			this.node6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.node6.Image = ((System.Drawing.Image)(resources.GetObject("node6.Image")));
			this.node6.NodeFont = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.node6.Text = "CD-ROM Drives";
			// 
			// node7
			// 
			this.node7.BackColor = System.Drawing.SystemColors.Window;
			this.node7.Checked = true;
			this.node7.CheckState = Crownwood.DotNetMagic.Controls.CheckState.Checked;
			this.node7.ForeColor = System.Drawing.SystemColors.ControlText;
			this.node7.Image = ((System.Drawing.Image)(resources.GetObject("node7.Image")));
			this.node7.NodeFont = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.node7.Text = "Sound Cards";
			// 
			// userData1
			// 
			this.userData1.DataSetName = "userData";
			this.userData1.Locale = new System.Globalization.CultureInfo("es-MX");
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(8, 8);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(96, 32);
			this.button3.TabIndex = 20;
			this.button3.Text = "Report";
			this.button3.Click += new System.EventHandler(this.button3_Click);
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
			// Hardware
			// 
			this.Controls.Add(this.button4);
			this.Controls.Add(this.treeControl1);
			this.Controls.Add(this.button3);
			this.Name = "Hardware";
			this.Size = new System.Drawing.Size(614, 289);
			this.Load += new System.EventHandler(this.Hardware_Load);
			((System.ComponentModel.ISupportInitialize)(this.userData1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void Hardware_Load(object sender, System.EventArgs e)
		{
			if (m_ResourceManager != null) 
			{
				this.button3.Text = m_ResourceManager.GetString("dbtnReport");
				this.button4.Text = m_ResourceManager.GetString("dbutton4");
			}
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			try 
			{
				if(!this.rpReady && this.button4.Enabled) 
				{
					this.scanMore();
				}
				HWD.userData.HWDCDataTable tm = new HWD.userData.HWDCDataTable();
				DataRow ndr = tm.NewRow();
				foreach (System.Management.ManagementObject mo in HWD.Details.Consulta("SELECT * FROM Win32_ComputerSystem"))
				{
					ndr["Manufacturer"] = mo["Manufacturer"].ToString();
					ndr["Model"] = mo["model"].ToString();
					try { ndr["UserName"] = mo["UserName"].ToString(); }
					catch { ndr["UserName"] = "";	}
				}
				foreach (System.Management.ManagementObject mo in HWD.Details.Consulta("SELECT * FROM Win32_bios"))
					ndr["SerialNumber"] = mo["SerialNumber"].ToString();
				
				foreach (System.Management.ManagementObject mo in HWD.Details.Consulta("SELECT * FROM Win32_OperatingSystem"))
				{
					ndr["OS"] = mo["Caption"].ToString() + " " + mo["Version"].ToString();
					ndr["ComputerName"] = mo["csname"].ToString();
				}

				ndr["ID"] = "0";	
				ndr["Printers"] = this.rpPrinters;
				ndr["NICs"] = this.rpNICs;
				ndr["CDs"] = this.rpCDs;
				ndr["HDs"] = this.rpHDs;
				ndr["Processors"] = this.rpProcessors;
				tm.Rows.Add(ndr);
				DataView tmpdv = new DataView(tm);
				ReportUSR tmpRep = new ReportUSR();
				tmpRep.dataview = tmpdv;
				preview pre = new preview();
				pre.irp = tmpRep;
				pre.ShowDialog();
			}
			catch (Exception er)
			{
				MessageBox.Show(er.ToString());
				MessageBox.Show(this, "Unable Report", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			this.Cursor = Cursors.Default;
		}

		private void changeStatus(string stringStatus)
		{
			if (ChangeStatus != null)
				ChangeStatus(stringStatus);
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			this.changeStatus("Scanning hardware...");
			this.scanMore();
			this.changeStatus("Online");
		}

		private void scanMore()
		{
			this.Cursor = Cursors.WaitCursor;
			this.rpReady = true;
			bool errors = false; 
			try 
			{
				foreach (System.Management.ManagementObject mo in HWD.Details.Consulta("SELECT * FROM Win32_Processor"))
				{
					Node tmpnd = new Node("Processor: " + mo["Name"].ToString().Trim());
					this.node1.Nodes.Add(tmpnd);
					this.rpProcessors = mo["Name"].ToString().Trim() + "\n\t\t" + this.rpProcessors;
				}
			} catch	{ errors = true; }
			try 
			{
				foreach (System.Management.ManagementObject mo in HWD.Details.Consulta("SELECT * FROM Win32_BaseBoard"))
				{
					Node tmpnd = new Node("Base Board: " + mo["Manufacturer"]);
					this.node1.Nodes.Add(tmpnd);
					this.rpProcessors = mo["Manufacturer"] + "\n\t\t" + this.rpProcessors;
				}
				this.Update();
			} catch	{ errors = true; }
			try 
			{
				foreach (System.Management.ManagementObject mo in HWD.Details.Consulta("SELECT * FROM Win32_NetworkAdapter WHERE AdapterTypeId = 0"))
				{
					Node tmpnd = new Node("NIC: " + mo["ProductName"] + " (" + mo["MACAddress"] + ")");
					this.node2.Nodes.Add(tmpnd);
					this.rpNICs = mo["ProductName"] + " (" + mo["MACAddress"] + ")\n\t\t" + this.rpNICs;
				}
				this.Update();
			} catch	{ errors = true; }
			try 
			{
				foreach (System.Management.ManagementObject mo in HWD.Details.Consulta("SELECT * FROM Win32_DesktopMonitor WHERE Availability = 3"))
				{
					Node tmpnd = new Node("Monitor: " + mo["MonitorType"]);
					this.node3.Nodes.Add(tmpnd);
				}
			} catch	{ errors = true; }
			try 
			{
				foreach (System.Management.ManagementObject mo in HWD.Details.Consulta("SELECT * FROM Win32_VideoController"))
				{
					Node tmpnd = new Node("Video Card: " + mo["Caption"]);
					this.node3.Nodes.Add(tmpnd);
				}
				this.Update();
			} catch	{ errors = true; }
			try 
			{
				foreach (System.Management.ManagementObject mo in HWD.Details.Consulta("SELECT * FROM Win32_Printer"))
				{
					Node tmpnd = new Node("Name: " + mo["Caption"]);
					this.node4.Nodes.Add(tmpnd);
					this.rpPrinters = mo["Caption"] + "\n\t\t" + this.rpPrinters;
				}
				this.Update();
			} catch	{ errors = true; }
			try 
			{
				foreach (System.Management.ManagementObject mo in HWD.Details.Consulta("SELECT * FROM Win32_DiskDrive WHERE MediaLoaded = TRUE"))
				{
					Node tmpnd = new Node("Name: " + mo["Caption"] + " (" + formatSize(Convert.ToInt64(mo["Size"].ToString()),false) + ")");
					this.node5.Nodes.Add(tmpnd);
					this.rpHDs = mo["Caption"] + " (" + formatSize(Convert.ToInt64(mo["Size"].ToString()),false) + ")\n\t\t" + this.rpHDs;
				}
				this.Update();
			} catch	{ errors = true; }
			try 
			{
				foreach (System.Management.ManagementObject mo in HWD.Details.Consulta("SELECT * FROM Win32_CDROMDrive"))
				{
					Node tmpnd = new Node("Name: " + mo["Caption"] + " (" + mo["Id"] + ")");
					this.node6.Nodes.Add(tmpnd);
					this.rpCDs = mo["Caption"] + "\n\t\t" + this.rpCDs;
				}
				this.Update();
			} catch	{ errors = true; }
			try 
			{
				foreach (System.Management.ManagementObject mo in HWD.Details.Consulta("SELECT * FROM Win32_SoundDevice"))
				{
					Node tmpnd = new Node("Name: " + mo["Description"]);
					this.node7.Nodes.Add(tmpnd);
				}
				this.Update();
			} catch	{ errors = true; }
			
			if(errors)
				MessageBox.Show(this, "Error scanning system, information could be incomplete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

			this.button4.Enabled = false;
			this.Cursor = Cursors.Default;
		}
		private string formatSize(Int64 lSize, bool booleanFormatOnly)
		{
			string stringSize = "";
			NumberFormatInfo myNfi = new NumberFormatInfo();

			Int64 lKBSize = 0;

			if (lSize < 1024 ) 
			{
				if (lSize == 0) 
					stringSize = "0";
				else 
					stringSize = "1";
			}
			else 
			{
				if (booleanFormatOnly == false)
					lKBSize = lSize / 1024;
				else 
					lKBSize = lSize;

				stringSize = lKBSize.ToString("n",myNfi);
				stringSize = stringSize.Replace(".00", "");
			}

			return stringSize + " KB";

		}	
	}
}
