using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Crownwood.DotNetMagic.Controls;

namespace HWD.DetailsControls
{
	public enum OSLanguague
	{
		Arabic = 0x0001,
		Chinese = 0x0004,
		English = 0x0009,
		Arabic_SaudiArabia = 0x0401,
		Bulgarian = 0x0402,
		Catalan = 0x0403,
		Chinese_Taiwan = 0x0404,
		Czech = 0x0405,
		Danish = 0x0406,
		German_Germany = 0x0407,
		Greek = 0x0408,
		English_UnitedStates = 0x0409,
		Spanish_TraditionalSort = 0x040A,
		Finnish = 0x040B,
		French_France = 0x040C,
		Hebrew = 0x040D,
		Hungarian = 0x040E,
		Icelandic = 0x040F,
		Italian_Italy = 0x0410,
		Japanese = 0x0411,
		Korean = 0x0412,
		Dutch_Netherlands = 0x0413,
		Norwegian_Bokmal = 0x0414,
		Polish = 0x0415,
		Portuguese_Brazil = 0x0416,
		RhaetoRomanic = 0x0417,
		Romanian = 0x0418,
		Russian = 0x0419,
		Croatian = 0x041A,
		Slovak = 0x041B,
		Albanian = 0x041C,
		Swedish = 0x041D,
		Thai = 0x041E,
		Turkish = 0x041F,
		Urdu = 0x0420,
		Indonesian = 0x0421,
		Ukrainian = 0x0422,
		Belarusian = 0x0423,
		Slovenian = 0x0424,
		Estonian = 0x0425,
		Latvian = 0x0426,
		Lithuanian = 0x0427,
		Farsi = 0x0429,
		Vietnamese = 0x042A,
		Basque = 0x042D,
		Serbian = 0x042E,
		Macedonian_FYROM = 0x042F,
		Sutu = 0x0430,
		Tsonga = 0x0431,
		Tswana = 0x0432,
		Xhosa = 0x0434,
		Zulu = 0x0435,
		Afrikaans = 0x0436,
		Faeroese = 0x0438,
		Hindi = 0x0439,
		Maltese = 0x043A,
		Gaelic = 0x043C,
		Yiddish = 0x043D,
		Malay_Malaysia = 0x043E,
		Arabic_Iraq = 0x0801,
		Chinese_PRC = 0x0804,
		German_Switzerland = 0x0807,
		English_UnitedKingdom = 0x0809,
		Spanish_Mexico = 0x080A,
		French_Belgium = 0x080C,
		Italian_Switzerland = 0x0810,
		Dutch_Belgium = 0x0813,
		Norwegian_Nynorsk = 0x0814,
		Portuguese_Portugal = 0x0816,
		Romanian_Moldova = 0x0818,
		Russian_Moldova = 0x0819,
		Serbian_Latin = 0x081A,
		Swedish_Finland = 0x081D,
		Arabic_Egypt = 0x0C01,
		Chinese_HongKongSAR = 0x0C04,
		German_Austria = 0x0C07,
		English_Australia = 0x0C09,
		Spanish_InternationalSort = 0x0C0A,
		French_Canada = 0x0C0C,
		Serbian_Cyrillic = 0x0C1A,
		Arabic_Libya = 0x1001,
		Chinese_Singapore = 0x1004,
		German_Luxembourg = 0x1007,
		English_Canada = 0x1009,
		Spanish_Guatemala = 0x100A,
		French_Switzerland = 0x100C,
		Arabic_Algeria = 0x1401,
		German_Liechtenstein = 0x1407,
		English_NewZealand = 0x1409,
		Spanish_CostaRica = 0x140A,
		French_Luxembourg = 0x140C,
		Arabic_Morocco = 0x1801,
		English_Ireland = 0x1809,
		Spanish_Panama = 0x180A,
		Arabic_Tunisia = 0x1C01,
		English_SouthAfrica = 0x1C09,
		Spanish_DominicanRepublic = 0x1C0A,
		Arabic_Oman = 0x2001,
		English_Jamaica = 0x2009,
		Spanish_Venezuela = 0x200A,
		Arabic_Yemen = 0x2401,
		Spanish_Colombia = 0x240A,
		Arabic_Syria = 0x2801,
		English_Belize = 0x2809,
		Spanish_Peru = 0x280A,
		Arabic_Jordan = 0x2C01,
		English_Trinidad = 0x2C09,
		Spanish_Argentina = 0x2C0A,
		Arabic_Lebanon = 0x3001,
		Spanish_Ecuador = 0x300A,
		Arabic_Kuwait = 0x3401,
		Spanish_Chile = 0x340A,
		Arabic_UAE = 0x3801,
		Spanish_Uruguay = 0x380A,
		Arabic_Bahrain = 0x3C01,
		Spanish_Paraguay = 0x3C0A,
		Arabic_Qatar = 0x4001,
		Spanish_Bolivia = 0x400A,
		Spanish_ElSalvador = 0x440A,
		Spanish_Honduras = 0x480A,
		Spanish_Nicaragua = 0x4C0A,
		Spanish_PuertoRico = 0x500A
	}

	public class Software : System.Windows.Forms.UserControl
	{
		private Crownwood.DotNetMagic.Controls.TreeControl treeControl2;
		private Crownwood.DotNetMagic.Controls.Node node8;
		private Crownwood.DotNetMagic.Controls.Node node9;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button2;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button5;
		private ReportPrinting.ReportDocument reportDocument1;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
	
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

		public Software()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Software));
			this.treeControl2 = new Crownwood.DotNetMagic.Controls.TreeControl();
			this.node8 = new Crownwood.DotNetMagic.Controls.Node();
			this.node9 = new Crownwood.DotNetMagic.Controls.Node();
			this.button2 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.button5 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.reportDocument1 = new ReportPrinting.ReportDocument();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// treeControl2
			// 
			this.treeControl2.Dock = System.Windows.Forms.DockStyle.Right;
			this.treeControl2.GroupFont = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.treeControl2.HotBackColor = System.Drawing.Color.Empty;
			this.treeControl2.HotForeColor = System.Drawing.Color.Empty;
			this.treeControl2.Location = new System.Drawing.Point(126, 0);
			this.treeControl2.MinimumNodeHeight = 11;
			this.treeControl2.Name = "treeControl2";
			this.treeControl2.Nodes.AddRange(new Crownwood.DotNetMagic.Controls.Node[] {
																						   this.node8,
																						   this.node9});
			this.treeControl2.SelectedNode = null;
			this.treeControl2.SelectedNoFocusBackColor = System.Drawing.SystemColors.Control;
			this.treeControl2.Size = new System.Drawing.Size(488, 289);
			this.treeControl2.TabIndex = 30;
			this.treeControl2.Text = "treeControl2";
			this.treeControl2.ViewControllers = Crownwood.DotNetMagic.Controls.ViewControllers.Group;
			// 
			// node8
			// 
			this.node8.BackColor = System.Drawing.SystemColors.Window;
			this.node8.Checked = true;
			this.node8.CheckState = Crownwood.DotNetMagic.Controls.CheckState.Checked;
			this.node8.ForeColor = System.Drawing.SystemColors.ControlText;
			this.node8.Image = ((System.Drawing.Image)(resources.GetObject("node8.Image")));
			this.node8.NodeFont = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.node8.Text = "OS";
			// 
			// node9
			// 
			this.node9.BackColor = System.Drawing.SystemColors.Window;
			this.node9.Checked = true;
			this.node9.CheckState = Crownwood.DotNetMagic.Controls.CheckState.Checked;
			this.node9.ForeColor = System.Drawing.SystemColors.ControlText;
			this.node9.Image = ((System.Drawing.Image)(resources.GetObject("node9.Image")));
			this.node9.NodeFont = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.node9.Text = "Most Popular";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(8, 48);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(96, 32);
			this.button2.TabIndex = 29;
			this.button2.Text = "Scan Software";
			this.button2.Click += new System.EventHandler(this.buttonWithStyle1_Click);
			// 
			// button5
			// 
			this.button5.Enabled = false;
			this.button5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.button5.Location = new System.Drawing.Point(8, 8);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(96, 32);
			this.button5.TabIndex = 28;
			this.button5.Text = "Report";
			this.button5.Click += new System.EventHandler(this.button5_Click);
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
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Location = new System.Drawing.Point(8, 88);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(112, 64);
			this.groupBox1.TabIndex = 31;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Software to scan";
			// 
			// radioButton1
			// 
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(8, 16);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(96, 16);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Most Popular";
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(8, 40);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(88, 16);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.Text = "All";
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// Software
			// 
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.treeControl2);
			this.Controls.Add(this.button2);
			this.Name = "Software";
			this.Size = new System.Drawing.Size(614, 289);
			this.Load += new System.EventHandler(this.Software_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void changeStatus(string stringStatus)
		{
			if (ChangeStatus != null)
				ChangeStatus(stringStatus);
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			/*this.Cursor = Cursors.WaitCursor;
			try 
			{
				ReportSWD tmpRep = new ReportSWD();
				//tmpRep.dataview = this.dviSoftware;
				preview pre = new preview();
				pre.irp = tmpRep;
				pre.ShowDialog();
			}
			catch 
			{
				MessageBox.Show(this, "Unable Report.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			this.Cursor = Cursors.Default;*/
			MessageBox.Show(this, "Software Report is disabled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void buttonWithStyle1_Click(object sender, System.EventArgs e)
		{
			this.radioButton1.Enabled = false;
			this.radioButton2.Enabled = false;
			this.Update();
			this.Cursor = Cursors.WaitCursor;
			try 
			{
				foreach(System.Management.ManagementObject mo in HWD.Details.Consulta("SELECT * FROM Win32_OperatingSystem"))
				{
					HWD.DetailsControls.OSLanguague oscode = (HWD.DetailsControls.OSLanguague) Convert.ToInt32(mo["OSLanguage"].ToString());
					
					Node tmpnd = new Node("Name: " + mo["Caption"]);
					this.node8.Nodes.Add(tmpnd);
					tmpnd = new Node("Version: " + mo["Version"]);
					this.node8.Nodes.Add(tmpnd);
					tmpnd = new Node("Build Type: " + mo["BuildType"]);
					this.node8.Nodes.Add(tmpnd);
					tmpnd = new Node("Language: " + oscode.ToString());
					this.node8.Nodes.Add(tmpnd);
					tmpnd = new Node("Serial Number: " + mo["SerialNumber"]);
					this.node8.Nodes.Add(tmpnd);
					tmpnd = new Node("System Directory: " + mo["SystemDirectory"]);
					this.node8.Nodes.Add(tmpnd);
					tmpnd = new Node("Windows Directory: " + mo["WindowsDirectory"]);
					this.node8.Nodes.Add(tmpnd);
				}
			} 
			catch
			{
				
			}
			string tuser = string.Empty;
			foreach (System.Management.ManagementObject mo in HWD.Details.Consulta("SELECT * FROM Win32_ComputerSystem"))
			{
				try 
				{
					tuser = mo["UserName"].ToString();
				}
				catch 
				{
					MessageBox.Show(this, "In order to perform a software scan, an user must be logged into the system." , "Scan Error" ,MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Cursor = Cursors.Default;
					return;
				}
			}
			if (tuser != string.Empty)
			{
				if (this.node9.Text == "Most Popular")
				{
					this.addSoftwareNode("Microsoft");
					this.addSoftwareNode("Adobe");
					this.addSoftwareNode("Macromedia");
					this.addSoftwareNode("Corel");
					this.addSoftwareNode("Borland");
				} 
				else 
				{
					try 
					{
						foreach(System.Management.ManagementObject mo in HWD.Details.Consulta("SELECT * FROM Win32_Product"))
						{
							Node tmpnd = new Node(mo["Name"].ToString()+" version "+mo["version"].ToString());
							this.node9.Nodes.Add(tmpnd);
						}
					} 
					catch (Exception exp)
					{
						MessageBox.Show(exp.ToString());
					}
				}
			}
			this.Cursor = Cursors.Default;
		}

		private void addSoftwareNode(string Company)
		{
			try 
			{
				Node tmpmas = new Node(Company + " Software");
				foreach(System.Management.ManagementObject mo in HWD.Details.Consulta("SELECT * FROM Win32_Product WHERE Vendor like '%" + Company + "%'"))
				{
					Node tmpnd = new Node(mo["Name"].ToString()+" version "+mo["version"].ToString());
					tmpmas.Nodes.Add(tmpnd);
				}
				if (tmpmas.Nodes.Count > 0) 
				{
					this.node9.Nodes.Add(tmpmas);
				}
			} 
			catch
			{
			
			}
			this.Update();
		}

		private void Software_Load(object sender, System.EventArgs e)
		{
			//this.button2.Text = m_ResourceManager.GetString("dbutton2");
			//this.button5.Text = m_ResourceManager.GetString("dbtnReport");
		}

		private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
		{
			this.node9.Text = "All";
		}

		private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
		{
			this.node9.Text = "Most Popular";
		}	
	}
}
