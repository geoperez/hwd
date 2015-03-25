using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Diagnostics;
using Microsoft.Win32;
using System.Threading;
using JCMLib;

namespace TWDManager
{
	public class Mein : System.Windows.Forms.Form
	{
		#region Objects
		internal System.Data.SqlClient.SqlConnection sqlConnection1;
		private Crownwood.DotNetMagic.Controls.TabControl tabControl1;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage1;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage2;
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar1;
		private System.ComponentModel.IContainer components;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle buttonWithStyle2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ListView lstTickets;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		private XmlDocument xmldoc = new XmlDocument();
		private string query;
		private ListViewItem tItem;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar2;
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar3;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle buttonWithStyle1;
		private System.Windows.Forms.DateTimePicker dateIni;
		private System.Windows.Forms.DateTimePicker dateEnd;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.CheckBox checkBox4;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle buttonWithStyle3;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ListView lstTech;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage3;
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar4;
		private string HWDPath = Registry.LocalMachine.OpenSubKey(@"Software\HWD\").GetValue("Path").ToString();
		private int ptti = 0;
		private int ptte = 0;
		private JCMLib.NotifyIconEx trayIcon = new NotifyIconEx();
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label7;
		private int lasttick = 0;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label9;
		private ReportPrinting.ReportDocument reportDocument1;
		private System.Windows.Forms.MenuItem menuItem11;
		private int myID = -1;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem13;
		private string techuser;
		private string datSys;
		#endregion

		public Mein(System.Data.SqlClient.SqlConnection sqlConn, string type)
		{	
			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.sqlConnection1	= sqlConn;
			this.xmldoc.Load(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\TWD\\config.xml");
			this.datSys = type;
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
			this.tabControl1 = new Crownwood.DotNetMagic.Controls.TabControl();
			this.tabPage1 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.lstTech = new System.Windows.Forms.ListView();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.buttonWithStyle2 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.titleBar1 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.tabPage2 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.buttonWithStyle3 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.dateEnd = new System.Windows.Forms.DateTimePicker();
			this.dateIni = new System.Windows.Forms.DateTimePicker();
			this.buttonWithStyle1 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.titleBar3 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.titleBar2 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.tabPage3 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.titleBar4 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.lstTickets = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label9 = new System.Windows.Forms.Label();
			this.reportDocument1 = new ReportPrinting.ReportDocument();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Appearance = Crownwood.DotNetMagic.Controls.VisualAppearance.MultiBox;
			this.tabControl1.BackColor = System.Drawing.SystemColors.Control;
			this.tabControl1.ButtonActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.tabControl1.ButtonInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Left;
			this.tabControl1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.tabControl1.HotTextColor = System.Drawing.SystemColors.ActiveCaption;
			this.tabControl1.ImageList = null;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.OfficeDockSides = false;
			this.tabControl1.PositionTop = true;
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(280, 390);
			this.tabControl1.TabIndex = 0;
			this.tabControl1.TabPages.AddRange(new Crownwood.DotNetMagic.Controls.TabPage[] {
																								this.tabPage1,
																								this.tabPage2,
																								this.tabPage3});
			this.tabControl1.TextColor = System.Drawing.SystemColors.ControlText;
			this.tabControl1.TextInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.tabControl1.TextTips = true;
			this.tabControl1.SelectionChanged += new Crownwood.DotNetMagic.Controls.SelectTabHandler(this.tabControl1_SelectionChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.textBox3);
			this.tabPage1.Controls.Add(this.label7);
			this.tabPage1.Controls.Add(this.lstTech);
			this.tabPage1.Controls.Add(this.label6);
			this.tabPage1.Controls.Add(this.textBox2);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.textBox1);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.textBox8);
			this.tabPage1.Controls.Add(this.textBox7);
			this.tabPage1.Controls.Add(this.label8);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.buttonWithStyle2);
			this.tabPage1.Controls.Add(this.titleBar1);
			this.tabPage1.InactiveBackColor = System.Drawing.Color.Empty;
			this.tabPage1.InactiveTextBackColor = System.Drawing.Color.Empty;
			this.tabPage1.InactiveTextColor = System.Drawing.Color.Empty;
			this.tabPage1.Location = new System.Drawing.Point(1, 30);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.SelectBackColor = System.Drawing.Color.Empty;
			this.tabPage1.SelectTextBackColor = System.Drawing.Color.Empty;
			this.tabPage1.SelectTextColor = System.Drawing.Color.Empty;
			this.tabPage1.Size = new System.Drawing.Size(278, 359);
			this.tabPage1.TabIndex = 3;
			this.tabPage1.Title = "Ticket";
			this.tabPage1.ToolTip = "Page";
			// 
			// textBox3
			// 
			this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox3.Location = new System.Drawing.Point(104, 8);
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(160, 18);
			this.textBox3.TabIndex = 26;
			this.textBox3.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(32, 8);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(48, 16);
			this.label7.TabIndex = 25;
			this.label7.Text = "Kind:";
			// 
			// lstTech
			// 
			this.lstTech.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstTech.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					  this.columnHeader7,
																					  this.columnHeader8});
			this.lstTech.FullRowSelect = true;
			this.lstTech.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lstTech.HideSelection = false;
			this.lstTech.Location = new System.Drawing.Point(104, 128);
			this.lstTech.MultiSelect = false;
			this.lstTech.Name = "lstTech";
			this.lstTech.Size = new System.Drawing.Size(160, 64);
			this.lstTech.TabIndex = 24;
			this.lstTech.View = System.Windows.Forms.View.Details;
			this.lstTech.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstTech_MouseDown);
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "ID";
			this.columnHeader7.Width = 30;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Name";
			this.columnHeader8.Width = 127;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(32, 128);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 16);
			this.label6.TabIndex = 23;
			this.label6.Text = "Asigned to:";
			// 
			// textBox2
			// 
			this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox2.Location = new System.Drawing.Point(104, 224);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(160, 18);
			this.textBox2.TabIndex = 22;
			this.textBox2.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(32, 224);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 21;
			this.label2.Text = "Complete on:";
			// 
			// textBox1
			// 
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox1.Location = new System.Drawing.Point(104, 200);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(160, 18);
			this.textBox1.TabIndex = 20;
			this.textBox1.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 200);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 10);
			this.label1.TabIndex = 19;
			this.label1.Text = "Created on:";
			// 
			// textBox8
			// 
			this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox8.Location = new System.Drawing.Point(104, 56);
			this.textBox8.Multiline = true;
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(160, 64);
			this.textBox8.TabIndex = 18;
			this.textBox8.Text = "";
			// 
			// textBox7
			// 
			this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox7.Location = new System.Drawing.Point(104, 32);
			this.textBox7.Name = "textBox7";
			this.textBox7.ReadOnly = true;
			this.textBox7.Size = new System.Drawing.Size(160, 18);
			this.textBox7.TabIndex = 17;
			this.textBox7.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(32, 56);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 16);
			this.label8.TabIndex = 10;
			this.label8.Text = "Description:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(32, 32);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 16);
			this.label5.TabIndex = 7;
			this.label5.Text = "Title:";
			// 
			// buttonWithStyle2
			// 
			this.buttonWithStyle2.Enabled = false;
			this.buttonWithStyle2.Location = new System.Drawing.Point(208, 320);
			this.buttonWithStyle2.Name = "buttonWithStyle2";
			this.buttonWithStyle2.Size = new System.Drawing.Size(64, 32);
			this.buttonWithStyle2.TabIndex = 2;
			this.buttonWithStyle2.Text = "Save";
			this.buttonWithStyle2.Click += new System.EventHandler(this.buttonWithStyle2_Click);
			// 
			// titleBar1
			// 
			this.titleBar1.Direction = Crownwood.DotNetMagic.Common.Direction.Vertical;
			this.titleBar1.Dock = System.Windows.Forms.DockStyle.Left;
			this.titleBar1.GradientActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(136)), ((System.Byte)(144)), ((System.Byte)(156)));
			this.titleBar1.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
			this.titleBar1.GradientDirection = Crownwood.DotNetMagic.Controls.GradientDirection.TopToBottom;
			this.titleBar1.GradientInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(230)), ((System.Byte)(231)), ((System.Byte)(228)));
			this.titleBar1.Location = new System.Drawing.Point(0, 0);
			this.titleBar1.MouseOverColor = System.Drawing.Color.Empty;
			this.titleBar1.Name = "titleBar1";
			this.titleBar1.Size = new System.Drawing.Size(24, 359);
			this.titleBar1.TabIndex = 0;
			this.titleBar1.Text = "Ticket";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.buttonWithStyle3);
			this.tabPage2.Controls.Add(this.checkBox4);
			this.tabPage2.Controls.Add(this.checkBox3);
			this.tabPage2.Controls.Add(this.groupBox1);
			this.tabPage2.Controls.Add(this.label4);
			this.tabPage2.Controls.Add(this.label3);
			this.tabPage2.Controls.Add(this.dateEnd);
			this.tabPage2.Controls.Add(this.dateIni);
			this.tabPage2.Controls.Add(this.buttonWithStyle1);
			this.tabPage2.Controls.Add(this.titleBar3);
			this.tabPage2.Controls.Add(this.titleBar2);
			this.tabPage2.InactiveBackColor = System.Drawing.Color.Empty;
			this.tabPage2.InactiveTextBackColor = System.Drawing.Color.Empty;
			this.tabPage2.InactiveTextColor = System.Drawing.Color.Empty;
			this.tabPage2.Location = new System.Drawing.Point(1, 30);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.SelectBackColor = System.Drawing.Color.Empty;
			this.tabPage2.Selected = false;
			this.tabPage2.SelectTextBackColor = System.Drawing.Color.Empty;
			this.tabPage2.SelectTextColor = System.Drawing.Color.Empty;
			this.tabPage2.Size = new System.Drawing.Size(278, 359);
			this.tabPage2.TabIndex = 4;
			this.tabPage2.Title = "Filter";
			this.tabPage2.ToolTip = "Page";
			// 
			// buttonWithStyle3
			// 
			this.buttonWithStyle3.Enabled = false;
			this.buttonWithStyle3.Location = new System.Drawing.Point(208, 328);
			this.buttonWithStyle3.Name = "buttonWithStyle3";
			this.buttonWithStyle3.Size = new System.Drawing.Size(64, 32);
			this.buttonWithStyle3.TabIndex = 11;
			this.buttonWithStyle3.Text = "Reset";
			this.buttonWithStyle3.Click += new System.EventHandler(this.buttonWithStyle3_Click);
			// 
			// checkBox4
			// 
			this.checkBox4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.checkBox4.Location = new System.Drawing.Point(8, 56);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(152, 16);
			this.checkBox4.TabIndex = 10;
			this.checkBox4.Text = "Include completed tickets";
			this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
			// 
			// checkBox3
			// 
			this.checkBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.checkBox3.Location = new System.Drawing.Point(8, 32);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(144, 16);
			this.checkBox3.TabIndex = 9;
			this.checkBox3.Text = "Include deleted tickets";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.checkBox2);
			this.groupBox1.Controls.Add(this.checkBox1);
			this.groupBox1.Location = new System.Drawing.Point(8, 120);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(264, 40);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			// 
			// checkBox2
			// 
			this.checkBox2.Enabled = false;
			this.checkBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.checkBox2.Location = new System.Drawing.Point(136, 16);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(96, 16);
			this.checkBox2.TabIndex = 1;
			this.checkBox2.Text = "Complete on";
			// 
			// checkBox1
			// 
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.checkBox1.Location = new System.Drawing.Point(8, 16);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(96, 16);
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Text = "Created on";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 192);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 17);
			this.label4.TabIndex = 7;
			this.label4.Text = "End:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 168);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = "Begin:";
			// 
			// dateEnd
			// 
			this.dateEnd.Location = new System.Drawing.Point(56, 192);
			this.dateEnd.Name = "dateEnd";
			this.dateEnd.Size = new System.Drawing.Size(216, 18);
			this.dateEnd.TabIndex = 5;
			// 
			// dateIni
			// 
			this.dateIni.Location = new System.Drawing.Point(56, 168);
			this.dateIni.Name = "dateIni";
			this.dateIni.Size = new System.Drawing.Size(216, 18);
			this.dateIni.TabIndex = 4;
			// 
			// buttonWithStyle1
			// 
			this.buttonWithStyle1.Location = new System.Drawing.Point(136, 328);
			this.buttonWithStyle1.Name = "buttonWithStyle1";
			this.buttonWithStyle1.Size = new System.Drawing.Size(64, 32);
			this.buttonWithStyle1.TabIndex = 3;
			this.buttonWithStyle1.Text = "Filter";
			this.buttonWithStyle1.Click += new System.EventHandler(this.buttonWithStyle1_Click);
			// 
			// titleBar3
			// 
			this.titleBar3.GradientActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(136)), ((System.Byte)(144)), ((System.Byte)(156)));
			this.titleBar3.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
			this.titleBar3.GradientDirection = Crownwood.DotNetMagic.Controls.GradientDirection.TopToBottom;
			this.titleBar3.GradientInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(230)), ((System.Byte)(231)), ((System.Byte)(228)));
			this.titleBar3.Location = new System.Drawing.Point(0, 88);
			this.titleBar3.MouseOverColor = System.Drawing.Color.Empty;
			this.titleBar3.Name = "titleBar3";
			this.titleBar3.Size = new System.Drawing.Size(280, 24);
			this.titleBar3.TabIndex = 1;
			this.titleBar3.Text = "Date Range";
			// 
			// titleBar2
			// 
			this.titleBar2.GradientActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(136)), ((System.Byte)(144)), ((System.Byte)(156)));
			this.titleBar2.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
			this.titleBar2.GradientDirection = Crownwood.DotNetMagic.Controls.GradientDirection.TopToBottom;
			this.titleBar2.GradientInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(230)), ((System.Byte)(231)), ((System.Byte)(228)));
			this.titleBar2.Location = new System.Drawing.Point(0, 0);
			this.titleBar2.MouseOverColor = System.Drawing.Color.Empty;
			this.titleBar2.Name = "titleBar2";
			this.titleBar2.Size = new System.Drawing.Size(280, 24);
			this.titleBar2.TabIndex = 0;
			this.titleBar2.Text = "General";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.label9);
			this.tabPage3.Controls.Add(this.numericUpDown1);
			this.tabPage3.Controls.Add(this.titleBar4);
			this.tabPage3.InactiveBackColor = System.Drawing.Color.Empty;
			this.tabPage3.InactiveTextBackColor = System.Drawing.Color.Empty;
			this.tabPage3.InactiveTextColor = System.Drawing.Color.Empty;
			this.tabPage3.Location = new System.Drawing.Point(1, 30);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.SelectBackColor = System.Drawing.Color.Empty;
			this.tabPage3.Selected = false;
			this.tabPage3.SelectTextBackColor = System.Drawing.Color.Empty;
			this.tabPage3.SelectTextColor = System.Drawing.Color.Empty;
			this.tabPage3.Size = new System.Drawing.Size(278, 359);
			this.tabPage3.TabIndex = 5;
			this.tabPage3.Title = "Options";
			this.tabPage3.ToolTip = "Page";
			// 
			// titleBar4
			// 
			this.titleBar4.Direction = Crownwood.DotNetMagic.Common.Direction.Vertical;
			this.titleBar4.Dock = System.Windows.Forms.DockStyle.Left;
			this.titleBar4.GradientActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(136)), ((System.Byte)(144)), ((System.Byte)(156)));
			this.titleBar4.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
			this.titleBar4.GradientDirection = Crownwood.DotNetMagic.Controls.GradientDirection.TopToBottom;
			this.titleBar4.GradientInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(230)), ((System.Byte)(231)), ((System.Byte)(228)));
			this.titleBar4.Location = new System.Drawing.Point(0, 0);
			this.titleBar4.MouseOverColor = System.Drawing.Color.Empty;
			this.titleBar4.Name = "titleBar4";
			this.titleBar4.Size = new System.Drawing.Size(24, 359);
			this.titleBar4.TabIndex = 1;
			this.titleBar4.Text = "Options";
			// 
			// lstTickets
			// 
			this.lstTickets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstTickets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						 this.columnHeader1,
																						 this.columnHeader2,
																						 this.columnHeader3,
																						 this.columnHeader4,
																						 this.columnHeader5,
																						 this.columnHeader6});
			this.lstTickets.Dock = System.Windows.Forms.DockStyle.Right;
			this.lstTickets.FullRowSelect = true;
			this.lstTickets.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lstTickets.HideSelection = false;
			this.lstTickets.Location = new System.Drawing.Point(280, 0);
			this.lstTickets.MultiSelect = false;
			this.lstTickets.Name = "lstTickets";
			this.lstTickets.Size = new System.Drawing.Size(512, 390);
			this.lstTickets.SmallImageList = this.imageList1;
			this.lstTickets.TabIndex = 1;
			this.lstTickets.View = System.Windows.Forms.View.Details;
			this.lstTickets.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstTickets_MouseDown);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "ID";
			this.columnHeader1.Width = 35;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Computer";
			this.columnHeader2.Width = 83;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Username";
			this.columnHeader3.Width = 87;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Title";
			this.columnHeader4.Width = 124;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Status";
			this.columnHeader5.Width = 84;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Created on";
			this.columnHeader6.Width = 91;
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem1,
																						 this.menuItem5,
																						 this.menuItem11,
																						 this.menuItem6,
																						 this.menuItem7,
																						 this.menuItem13,
																						 this.menuItem12});
			this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2,
																					  this.menuItem3,
																					  this.menuItem4});
			this.menuItem1.Text = "Status";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "New";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "On work";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Text = "Complete";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 1;
			this.menuItem5.Text = "Delete";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 3;
			this.menuItem6.Text = "-";
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 4;
			this.menuItem7.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem8,
																					  this.menuItem9,
																					  this.menuItem10});
			this.menuItem7.Text = "Launch";
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 0;
			this.menuItem8.Text = "HWD Details";
			this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 1;
			this.menuItem9.Text = "Remote Desktop";
			this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 2;
			this.menuItem10.Text = "Computer Managment";
			this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 60000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(112, 8);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(40, 18);
			this.numericUpDown1.TabIndex = 2;
			this.numericUpDown1.Value = new System.Decimal(new int[] {
																		 6,
																		 0,
																		 0,
																		 0});
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(32, 8);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(72, 16);
			this.label9.TabIndex = 3;
			this.label9.Text = "Refresh time:";
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
			// menuItem11
			// 
			this.menuItem11.Index = 2;
			this.menuItem11.Text = "Add Entry";
			this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 6;
			this.menuItem12.Text = "Print Report";
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 5;
			this.menuItem13.Text = "-";
			// 
			// Mein
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 390);
			this.Controls.Add(this.lstTickets);
			this.Controls.Add(this.tabControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximumSize = new System.Drawing.Size(800, 424);
			this.MinimumSize = new System.Drawing.Size(800, 424);
			this.Name = "Mein";
			this.Text = "TWD Manager";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Mein_Closing);
			this.Load += new System.EventHandler(this.Mein_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void Mein_Load(object sender, System.EventArgs e)
		{
			Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
			if (this.datSys == "sql") 
			{
				this.sqlConnection1.Open();
				this.CheckTech();
				this.query = "SELECT * FROM HWD_TICKETS WHERE Showit = 1 AND Tech in (0," +this.myID+ ")";
				this.PopulatedItems();
			} 
			else { MessageBox.Show("You are workin offline. TWDManager will be disable to performance actions."); }
			this.LoadTrayIcon();
		}
		private void CheckTech()
		{
			SqlCommand sqlcommand = new SqlCommand("SELECT * FROM HWD_TECHS WHERE Username = '"+Environment.UserName+"'", this.sqlConnection1);
			SqlDataReader sqlrd = sqlcommand.ExecuteReader();
			while(sqlrd.Read())
			{
				this.myID = sqlrd.GetInt32(0);
				this.techuser = sqlrd.GetString(1);
			}
			sqlrd.Close();
			if (this.myID == -1)
			{
				MessageBox.Show("You aren't authorizated to manage tickets.");
				Application.Exit();
			}
				
		}
		private void LoadTrayIcon()
		{
			this.trayIcon.Icon = new Icon(GetType(), "App.ico");
			this.trayIcon.Text = "TWDManager";
			this.trayIcon.Visible = true;
			this.trayIcon.DoubleClick += new EventHandler(OnDoubleClickIcon);
		}

		private void OnDoubleClickIcon(object sender, EventArgs e)
		{
			this.Show();
		}
		private void PopulatedItems()
		{
			Thread th = new Thread(new ThreadStart(PopulatedItemsThread));
			th.IsBackground = true;
			th.Start();
		}
		private void PopulatedTech()
		{
			this.lstTech.Items.Clear();
			SqlCommand sqlcommand = new SqlCommand("SELECT * FROM HWD_TECHS", this.sqlConnection1);
			SqlDataReader sqlread = sqlcommand.ExecuteReader();
			string[] str = new string[2];
			str[0] = "0";
			str[1] = "Unassigned";
			ListViewItem lvi = new ListViewItem(str);
			this.lstTech.Items.Add(lvi);
			while (sqlread.Read())
			{
				str[0] = sqlread.GetInt32(0).ToString();
				str[1] = sqlread.GetString(2).Trim();
				lvi = new ListViewItem(str);
				this.lstTech.Items.Add(lvi);
			}
			sqlread.Close();
		}

		private void PopulatedItemsThread()
		{
			if (this.datSys == "sql") 
			{
				this.titleBar1.PostText = "Getting tickets...";
				this.lstTickets.Items.Clear();
				SqlCommand sqlcommand = new SqlCommand(this.query, this.sqlConnection1);
				SqlDataReader sqlread = sqlcommand.ExecuteReader();
				int last = this.lasttick;
				while (sqlread.Read())
				{
					int icon = 0;
					string[] str = new string[6];
					str[0] = sqlread.GetInt32(0).ToString();
					last = sqlread.GetInt32(0);
					str[1] = sqlread.GetString(1).Trim();
					str[2] = sqlread.GetString(2).Trim();
					str[3] = sqlread.GetString(4).Trim();
					str[4] = sqlread.GetString(6).Trim();
					str[5] = sqlread.GetDateTime(9).ToShortDateString() + " " + sqlread.GetDateTime(9).ToShortTimeString();
					if (sqlread.GetString(6).Trim() == "ON WORK")
						icon = 1;
					else if(sqlread.GetString(6).Trim() == "COMPLETE")
						icon = 2;
					ListViewItem lvi = new ListViewItem(str, icon);
					this.lstTickets.Items.Add(lvi);
				}
				sqlread.Close();
				this.ClearDetails();
				this.titleBar1.PostText = "";
				this.PopulatedTech();
				if (this.lasttick == 0)
					this.lasttick = last;
				else
					this.CheckLast(last);
			}
		}

		private void CheckLast(int last)
		{
			if (this.lasttick < last)
			{
				this.lasttick = last;
				string mess = "Title: " + this.lstTickets.Items[this.lstTickets.Items.Count-1].SubItems[3].Text + "\nFrom: "  + this.lstTickets.Items[this.lstTickets.Items.Count-1].SubItems[1].Text + "\\" + this.lstTickets.Items[this.lstTickets.Items.Count-1].SubItems[2].Text;
				this.trayIcon.ShowBalloon("New ticket", mess, JCMLib.NotifyIconEx.NotifyInfoFlags.Info, 2000);
			}
		}
		private void lstTickets_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			System.Windows.Forms.ListView listViewObject = (System.Windows.Forms.ListView) sender;

			if (e.Button == System.Windows.Forms.MouseButtons.Right && listViewObject.Items.Count > 0) 
			{
				try 
				{
					tItem = listViewObject.GetItemAt(e.X,e.Y);
					this.menuItem2.Checked = false;
					this.menuItem3.Checked = false;
					this.menuItem4.Checked = false;

					listViewObject.ContextMenu = this.contextMenu1;
					switch (tItem.SubItems[4].Text)
					{
						case "ON WORK":
							this.menuItem3.Checked = true;
							break;
						case "COMPLETE":
							this.menuItem4.Checked = true;
							break;
						default:
							this.menuItem2.Checked = true;
							break;
					}
				} 
				catch 
				{

				}
			}
			else if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				try 
				{
					this.ptti = this.lstTickets.GetItemAt(e.X,e.Y).Index;
					this.RetrieveItem();
				}
				catch
				{

				}
			}
		}

		private void CloseTicket()
		{
			if (MessageBox.Show(this, "Do you want to add a logger entry of this system?", "Add a logger entry", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				TWDManager.Logger log = new Logger();
				log.Sqlcon = this.sqlConnection1;
				log.Tech = this.techuser;
				log.Machinename = tItem.SubItems[1].Text;
				log.ShowDialog(this);
			}
		}
		private void RetrieveItem()
		{
			this.timer1.Stop();
			this.titleBar1.PostText = "Getting data...";
			try 
			{
				this.ClearDetails();
				string ID = this.lstTickets.Items[this.ptti].SubItems[0].Text;
				SqlCommand sqlcommand = new SqlCommand("SELECT * FROM HWD_TICKETS WHERE ID = " + ID, this.sqlConnection1);
				SqlDataReader sqlread = sqlcommand.ExecuteReader();
				while (sqlread.Read())
				{
					this.textBox1.Text = sqlread.GetDateTime(9).ToShortDateString() + " " + sqlread.GetDateTime(9).ToShortTimeString();
					if (!sqlread.IsDBNull(10))
						this.textBox2.Text = sqlread.GetDateTime(10).ToShortDateString() + " " + sqlread.GetDateTime(10).ToShortTimeString();
					this.textBox3.Text = sqlread.GetString(3).Trim();
					this.textBox7.Text = sqlread.GetString(4).Trim();
					this.textBox8.Text = sqlread.GetString(5).Trim();
					foreach (ListViewItem i in this.lstTech.Items)
					{
						if(i.SubItems[0].Text == sqlread.GetInt32(8).ToString())
						{
							this.lstTech.Items[i.Index].Selected = true;
							this.ptte = i.Index;
							break;
						} 
					}
				}
				sqlread.Close();
				this.buttonWithStyle2.Enabled = true;
			} 
			catch (Exception er)
			{
				MessageBox.Show(er.ToString());
			}
			this.titleBar1.PostText = "";
			this.timer1.Start();
		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			this.runClient(this.HWDPath, @"/details ");
		}

		private void menuItem9_Click(object sender, System.EventArgs e)
		{
			this.runClient("mstsc", "/v:");
		}

		private void menuItem10_Click(object sender, System.EventArgs e)
		{
			this.runClient("mmc.exe", @"%windir%\system32\compmgmt.msc /computer=");
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			if(!RunQuery("UPDATE HWD_TICKETS SET Showit = 0 WHERE ID = " + tItem.SubItems[0].Text))
				this.trayIcon.ShowBalloon("DB Error", "Can't save data in database.", JCMLib.NotifyIconEx.NotifyInfoFlags.Error, 1000);
			else
				this.PopulatedItems();
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			if(!RunQuery("UPDATE HWD_TICKETS SET Status = 'NEW' WHERE ID = " + tItem.SubItems[0].Text))
				this.trayIcon.ShowBalloon("DB Error", "Can't save data in database.", JCMLib.NotifyIconEx.NotifyInfoFlags.Error, 1000);
			else
				this.PopulatedItems();
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			if(!RunQuery("UPDATE HWD_TICKETS SET Status = 'ON WORK' WHERE ID = " + tItem.SubItems[0].Text))
				this.trayIcon.ShowBalloon("DB Error", "Can't save data in database.", JCMLib.NotifyIconEx.NotifyInfoFlags.Error, 1000);
			else
				this.PopulatedItems();
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			if(!RunQuery("UPDATE HWD_TICKETS SET Status = 'COMPLETE', CompleteDate = '" + DateTime.Now.ToString() + "' WHERE ID = " + tItem.SubItems[0].Text))
				this.trayIcon.ShowBalloon("DB Error", "Can't save data in database.", JCMLib.NotifyIconEx.NotifyInfoFlags.Error, 1000);
			else
				this.PopulatedItems();
			this.CloseTicket();
		}
		
		private bool RunQuery(string query)
		{
			bool ret = false;
			try 
			{
				SqlCommand sqlcommand = new SqlCommand(query, this.sqlConnection1);
				if (sqlcommand.ExecuteNonQuery() > 0)
					ret = true;
			} 
			catch //(Exception asd)
			{
				//MessageBox.Show(asd.ToString());
			}
			return ret;
		}

		private void runClient(string app, string par)
		{
			string computer =  par + tItem.SubItems[1].Text;
			ProcessStartInfo pr = new System.Diagnostics.ProcessStartInfo(app, computer);
			pr.WindowStyle = ProcessWindowStyle.Maximized;
			Process.Start(pr);
		}

		private void ClearDetails()
		{
			this.textBox1.Text = "";
			this.textBox2.Text = "";
			this.textBox3.Text = "";
			this.textBox7.Text = "";
			this.textBox8.Text = "";
			this.buttonWithStyle2.Enabled = false;
		}

		private void checkBox4_CheckedChanged(object sender, System.EventArgs e)
		{
			if(!this.checkBox4.Checked)
				this.checkBox2.Enabled = false;
			else
				this.checkBox2.Enabled = true;
		}

		private void buttonWithStyle1_Click(object sender, System.EventArgs e)
		{
			string mquery = "SELECT * FROM HWD_TICKETS WHERE ";
			if(!this.checkBox3.Checked)
				mquery += "Showit = 1 AND Tech in (0," +this.myID+ ") AND ";
			if(!this.checkBox4.Checked)
				mquery += "Status != 'COMPLETE' AND ";
			if(this.checkBox1.Checked && (this.dateIni.Value > this.dateEnd.Value))
				mquery += "(CreateOn BETWEN '" + this.dateIni.Value.ToString() + "' AND '" + this.dateEnd.Value.ToString() + "') AND ";
			if(this.checkBox2.Checked && this.checkBox2.Enabled && (this.dateIni.Value > this.dateEnd.Value))
				mquery += "(CompleteOn BETWEN '" + this.dateIni.Value.ToString() + "' AND '" + this.dateEnd.Value.ToString() + "') AND ";
			this.query = mquery.Substring(0,mquery.Length-4);
			this.buttonWithStyle3.Enabled = true;
			this.PopulatedItems();
		}

		private void buttonWithStyle3_Click(object sender, System.EventArgs e)
		{
			this.query = "SELECT * FROM HWD_TICKETS WHERE Showit = 1 AND Tech in (0," +this.myID+ ")";
			this.PopulatedItems();
		}

		private void buttonWithStyle2_Click(object sender, System.EventArgs e)
		{
			
			string mquery = "UPDATE HWD_TICKETS SET Description = '" + this.textBox8.Text + "', " + "Tech = " + this.lstTech.Items[this.ptte].SubItems[0].Text + " WHERE ID = " + this.lstTickets.Items[this.ptti].SubItems[0].Text;
			if(!this.RunQuery(mquery))
				this.trayIcon.ShowBalloon("DB Error", "Can't save data in database.", JCMLib.NotifyIconEx.NotifyInfoFlags.Error, 1000);
			else
				this.PopulatedItems();
		}

		private void lstTech_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			try 
			{
				this.ptte = this.lstTech.GetItemAt(e.X, e.Y).Index;
			}
			catch
			{

			}
		}

		private void Mein_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this.Hide();
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if (this.datSys == "sql") { this.PopulatedItems(); }
		}

		private void tabControl1_SelectionChanged(Crownwood.DotNetMagic.Controls.TabControl sender, Crownwood.DotNetMagic.Controls.TabPage oldPage, Crownwood.DotNetMagic.Controls.TabPage newPage)
		{
		
		}

		private void contextMenu1_Popup(object sender, System.EventArgs e)
		{
		
		}

		private void menuItem11_Click(object sender, System.EventArgs e)
		{
			this.CloseTicket();
		}
	}
}
