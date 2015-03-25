using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Xml;
using System.Management;
using System.Globalization;
using Crownwood.DotNetMagic.Controls;
using System.Threading;
using XYNetSocketLib;
using System.Resources;
using JCMLib;

namespace CWD
{
	public class Mein : System.Windows.Forms.Form
	{
		private Crownwood.DotNetMagic.Controls.TabControl tabControl1;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage1;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage2;
		private Crownwood.DotNetMagic.Controls.TreeControl treeControl1;
		private Crownwood.DotNetMagic.Controls.Node node2;
		private Crownwood.DotNetMagic.Controls.Node node7;
		private Crownwood.DotNetMagic.Controls.Node node3;
		private Crownwood.DotNetMagic.Controls.Node node6;
		private Crownwood.DotNetMagic.Controls.Node node4;
		private Crownwood.DotNetMagic.Controls.Node node5;
		private Crownwood.DotNetMagic.Controls.Node node1;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar1;
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar2;
		private System.Windows.Forms.Label label1;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle buttonWithStyle2;
		private XYNetSocketLib.XYNetServer xServer;
		private XYNetSocketLib.XYNetClient xClient;
		private string myIP;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle buttonWithStyle1;
		private string xMess = string.Empty;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private ListViewItem tItem;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle buttonWithStyle3;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ImageList imageList1;
		private JCMLib.NotifyIconEx trayIcon = new NotifyIconEx();
		private System.Windows.Forms.Timer timer1;
		private System.Data.DataSet ds;
		private System.Windows.Forms.Timer timer2;
		private int tries;
		private int ipt;
		private ResourceManager m_ResourceManager = new ResourceManager("CWD.Localization", System.Reflection.Assembly.GetExecutingAssembly());
		private CultureInfo m_EnglishCulture = new CultureInfo("en-US");
		private Crownwood.DotNetMagic.Controls.TabPage tabPage4;
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox1;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle buttonWithStyle5;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle buttonWithStyle4;
		private CultureInfo m_SpanishCulture = new CultureInfo("es-MX");
		private bool terminate = false;

		public Mein()
		{
			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			InitializeComponent();
			Thread.CurrentThread.CurrentUICulture = m_EnglishCulture;

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
			this.buttonWithStyle3 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.buttonWithStyle2 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.label1 = new System.Windows.Forms.Label();
			this.titleBar1 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.tabPage2 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.buttonWithStyle1 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.titleBar2 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.treeControl1 = new Crownwood.DotNetMagic.Controls.TreeControl();
			this.node1 = new Crownwood.DotNetMagic.Controls.Node();
			this.node2 = new Crownwood.DotNetMagic.Controls.Node();
			this.node3 = new Crownwood.DotNetMagic.Controls.Node();
			this.node4 = new Crownwood.DotNetMagic.Controls.Node();
			this.node5 = new Crownwood.DotNetMagic.Controls.Node();
			this.node6 = new Crownwood.DotNetMagic.Controls.Node();
			this.node7 = new Crownwood.DotNetMagic.Controls.Node();
			this.tabPage4 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.titleBar3 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			this.label4 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.buttonWithStyle5 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.buttonWithStyle4 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Appearance = Crownwood.DotNetMagic.Controls.VisualAppearance.MultiBox;
			this.tabControl1.BackColor = System.Drawing.SystemColors.Control;
			this.tabControl1.ButtonActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.tabControl1.ButtonInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tabControl1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.tabControl1.HotTextColor = System.Drawing.SystemColors.ActiveCaption;
			this.tabControl1.ImageList = null;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.OfficeDockSides = false;
			this.tabControl1.PositionTop = true;
			this.tabControl1.SelectedIndex = 2;
			this.tabControl1.Size = new System.Drawing.Size(432, 360);
			this.tabControl1.TabIndex = 0;
			this.tabControl1.TabPages.AddRange(new Crownwood.DotNetMagic.Controls.TabPage[] {
																								this.tabPage1,
																								this.tabPage2,
																								this.tabPage4});
			this.tabControl1.TextColor = System.Drawing.SystemColors.ControlText;
			this.tabControl1.TextInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.tabControl1.TextTips = true;
			this.tabControl1.SelectionChanged += new Crownwood.DotNetMagic.Controls.SelectTabHandler(this.tabControl1_SelectionChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.buttonWithStyle3);
			this.tabPage1.Controls.Add(this.listView1);
			this.tabPage1.Controls.Add(this.buttonWithStyle2);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.titleBar1);
			this.tabPage1.InactiveBackColor = System.Drawing.Color.Empty;
			this.tabPage1.InactiveTextBackColor = System.Drawing.Color.Empty;
			this.tabPage1.InactiveTextColor = System.Drawing.Color.Empty;
			this.tabPage1.Location = new System.Drawing.Point(1, 30);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.SelectBackColor = System.Drawing.Color.Empty;
			this.tabPage1.Selected = false;
			this.tabPage1.SelectTextBackColor = System.Drawing.Color.Empty;
			this.tabPage1.SelectTextColor = System.Drawing.Color.Empty;
			this.tabPage1.Size = new System.Drawing.Size(430, 329);
			this.tabPage1.TabIndex = 3;
			this.tabPage1.Title = "Tickets";
			this.tabPage1.ToolTip = "Page";
			// 
			// buttonWithStyle3
			// 
			this.buttonWithStyle3.Enabled = false;
			this.buttonWithStyle3.Location = new System.Drawing.Point(344, 296);
			this.buttonWithStyle3.Name = "buttonWithStyle3";
			this.buttonWithStyle3.Size = new System.Drawing.Size(80, 24);
			this.buttonWithStyle3.TabIndex = 7;
			this.buttonWithStyle3.Text = "Send changes";
			this.buttonWithStyle3.Click += new System.EventHandler(this.buttonWithStyle3_Click);
			// 
			// listView1
			// 
			this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1,
																						this.columnHeader5,
																						this.columnHeader3,
																						this.columnHeader4,
																						this.columnHeader2,
																						this.columnHeader6});
			this.listView1.FullRowSelect = true;
			this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView1.HideSelection = false;
			this.listView1.LargeImageList = this.imageList1;
			this.listView1.Location = new System.Drawing.Point(32, 24);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(392, 264);
			this.listView1.SmallImageList = this.imageList1;
			this.listView1.TabIndex = 6;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "ID";
			this.columnHeader1.Width = 31;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Kind";
			this.columnHeader5.Width = 69;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Title";
			this.columnHeader3.Width = 65;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Description";
			this.columnHeader4.Width = 140;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Status";
			this.columnHeader2.Width = 81;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Showit";
			this.columnHeader6.Width = 1;
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// buttonWithStyle2
			// 
			this.buttonWithStyle2.Enabled = false;
			this.buttonWithStyle2.Location = new System.Drawing.Point(32, 296);
			this.buttonWithStyle2.Name = "buttonWithStyle2";
			this.buttonWithStyle2.Size = new System.Drawing.Size(80, 24);
			this.buttonWithStyle2.TabIndex = 3;
			this.buttonWithStyle2.Text = "New";
			this.buttonWithStyle2.Click += new System.EventHandler(this.buttonWithStyle2_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Current tickets:";
			// 
			// titleBar1
			// 
			this.titleBar1.Direction = Crownwood.DotNetMagic.Common.Direction.Vertical;
			this.titleBar1.Dock = System.Windows.Forms.DockStyle.Left;
			this.titleBar1.GradientActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(53)), ((System.Byte)(115)), ((System.Byte)(214)));
			this.titleBar1.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
			this.titleBar1.GradientDirection = Crownwood.DotNetMagic.Controls.GradientDirection.TopToBottom;
			this.titleBar1.GradientInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(96)), ((System.Byte)(178)));
			this.titleBar1.Location = new System.Drawing.Point(0, 0);
			this.titleBar1.MouseOverColor = System.Drawing.Color.Empty;
			this.titleBar1.Name = "titleBar1";
			this.titleBar1.PostText = "Offline";
			this.titleBar1.Size = new System.Drawing.Size(24, 329);
			this.titleBar1.TabIndex = 0;
			this.titleBar1.Text = "Tickets";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.buttonWithStyle1);
			this.tabPage2.Controls.Add(this.titleBar2);
			this.tabPage2.Controls.Add(this.treeControl1);
			this.tabPage2.InactiveBackColor = System.Drawing.Color.Empty;
			this.tabPage2.InactiveTextBackColor = System.Drawing.Color.Empty;
			this.tabPage2.InactiveTextColor = System.Drawing.Color.Empty;
			this.tabPage2.Location = new System.Drawing.Point(1, 30);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.SelectBackColor = System.Drawing.Color.Empty;
			this.tabPage2.Selected = false;
			this.tabPage2.SelectTextBackColor = System.Drawing.Color.Empty;
			this.tabPage2.SelectTextColor = System.Drawing.Color.Empty;
			this.tabPage2.Size = new System.Drawing.Size(430, 329);
			this.tabPage2.TabIndex = 4;
			this.tabPage2.Title = "My System";
			this.tabPage2.ToolTip = "Page";
			// 
			// buttonWithStyle1
			// 
			this.buttonWithStyle1.Location = new System.Drawing.Point(344, 296);
			this.buttonWithStyle1.Name = "buttonWithStyle1";
			this.buttonWithStyle1.Size = new System.Drawing.Size(80, 24);
			this.buttonWithStyle1.TabIndex = 22;
			this.buttonWithStyle1.Text = "Get Info";
			this.buttonWithStyle1.Click += new System.EventHandler(this.buttonWithStyle1_Click_1);
			// 
			// titleBar2
			// 
			this.titleBar2.Direction = Crownwood.DotNetMagic.Common.Direction.Vertical;
			this.titleBar2.Dock = System.Windows.Forms.DockStyle.Left;
			this.titleBar2.GradientActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(53)), ((System.Byte)(115)), ((System.Byte)(214)));
			this.titleBar2.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
			this.titleBar2.GradientDirection = Crownwood.DotNetMagic.Controls.GradientDirection.TopToBottom;
			this.titleBar2.GradientInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(96)), ((System.Byte)(178)));
			this.titleBar2.Location = new System.Drawing.Point(0, 0);
			this.titleBar2.MouseOverColor = System.Drawing.Color.Empty;
			this.titleBar2.Name = "titleBar2";
			this.titleBar2.Size = new System.Drawing.Size(24, 329);
			this.titleBar2.TabIndex = 21;
			this.titleBar2.Text = "My System";
			// 
			// treeControl1
			// 
			this.treeControl1.GroupFont = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.treeControl1.HotBackColor = System.Drawing.Color.Empty;
			this.treeControl1.HotForeColor = System.Drawing.Color.Empty;
			this.treeControl1.Location = new System.Drawing.Point(25, 0);
			this.treeControl1.MinimumNodeHeight = 14;
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
			this.treeControl1.Size = new System.Drawing.Size(405, 288);
			this.treeControl1.TabIndex = 20;
			this.treeControl1.Text = "treeControl1";
			this.treeControl1.ViewControllers = Crownwood.DotNetMagic.Controls.ViewControllers.Group;
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
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.buttonWithStyle4);
			this.tabPage4.Controls.Add(this.label4);
			this.tabPage4.Controls.Add(this.textBox1);
			this.tabPage4.Controls.Add(this.buttonWithStyle5);
			this.tabPage4.Controls.Add(this.groupBox1);
			this.tabPage4.Controls.Add(this.titleBar3);
			this.tabPage4.InactiveBackColor = System.Drawing.Color.Empty;
			this.tabPage4.InactiveTextBackColor = System.Drawing.Color.Empty;
			this.tabPage4.InactiveTextColor = System.Drawing.Color.Empty;
			this.tabPage4.Location = new System.Drawing.Point(1, 30);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.SelectBackColor = System.Drawing.Color.Empty;
			this.tabPage4.SelectTextBackColor = System.Drawing.Color.Empty;
			this.tabPage4.SelectTextColor = System.Drawing.Color.Empty;
			this.tabPage4.Size = new System.Drawing.Size(430, 329);
			this.tabPage4.TabIndex = 6;
			this.tabPage4.Title = "Options";
			this.tabPage4.ToolTip = "Page";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Location = new System.Drawing.Point(32, 40);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(192, 56);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Language";
			// 
			// radioButton2
			// 
			this.radioButton2.Checked = true;
			this.radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioButton2.Location = new System.Drawing.Point(8, 24);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(80, 24);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "English";
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// radioButton1
			// 
			this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioButton1.Location = new System.Drawing.Point(96, 24);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(80, 24);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.Text = "Español";
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// titleBar3
			// 
			this.titleBar3.Direction = Crownwood.DotNetMagic.Common.Direction.Vertical;
			this.titleBar3.Dock = System.Windows.Forms.DockStyle.Left;
			this.titleBar3.GradientActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(53)), ((System.Byte)(115)), ((System.Byte)(214)));
			this.titleBar3.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
			this.titleBar3.GradientDirection = Crownwood.DotNetMagic.Controls.GradientDirection.TopToBottom;
			this.titleBar3.GradientInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(96)), ((System.Byte)(178)));
			this.titleBar3.Location = new System.Drawing.Point(0, 0);
			this.titleBar3.MouseOverColor = System.Drawing.Color.Empty;
			this.titleBar3.Name = "titleBar3";
			this.titleBar3.Size = new System.Drawing.Size(24, 329);
			this.titleBar3.TabIndex = 1;
			this.titleBar3.Text = "Options";
			// 
			// panel1
			// 
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 356);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(432, 8);
			this.panel1.TabIndex = 1;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.tabControl1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(432, 360);
			this.panel2.TabIndex = 2;
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// timer2
			// 
			this.timer2.Enabled = true;
			this.timer2.Interval = 20000;
			this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(32, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "Server:";
			// 
			// textBox1
			// 
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox1.Location = new System.Drawing.Point(88, 8);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(136, 21);
			this.textBox1.TabIndex = 5;
			this.textBox1.Text = "localhost";
			// 
			// buttonWithStyle5
			// 
			this.buttonWithStyle5.Location = new System.Drawing.Point(319, 8);
			this.buttonWithStyle5.Name = "buttonWithStyle5";
			this.buttonWithStyle5.Size = new System.Drawing.Size(104, 32);
			this.buttonWithStyle5.TabIndex = 4;
			this.buttonWithStyle5.Text = "Get AppPolicie";
			// 
			// buttonWithStyle4
			// 
			this.buttonWithStyle4.Location = new System.Drawing.Point(320, 56);
			this.buttonWithStyle4.Name = "buttonWithStyle4";
			this.buttonWithStyle4.Size = new System.Drawing.Size(104, 32);
			this.buttonWithStyle4.TabIndex = 7;
			this.buttonWithStyle4.Text = "Exit";
			this.buttonWithStyle4.Click += new System.EventHandler(this.buttonWithStyle4_Click);
			// 
			// Mein
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(432, 364);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(438, 392);
			this.MinimumSize = new System.Drawing.Size(438, 392);
			this.Name = "Mein";
			this.Text = "CWD";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Mein_Closing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			bool init = true;
			bool mux;

			Mutex m = new Mutex(init, "CWD", out mux);
				
			if (!(init && mux))
				MessageBox.Show("Already Running");
			else 
			{
				Application.EnableVisualStyles();
				Application.DoEvents();
				Application.Run(new Mein());
			}
		}
		private void UpdateUI()
		{
			this.label1.Text = m_ResourceManager.GetString("label1");
			this.buttonWithStyle2.Text = m_ResourceManager.GetString("button2");
			this.buttonWithStyle3.Text = m_ResourceManager.GetString("button3");
			this.tabPage2.Title = m_ResourceManager.GetString("MySystem");
			this.titleBar2.Text = m_ResourceManager.GetString("MySystem");
			this.label4.Text = m_ResourceManager.GetString("Server")+":";
		}
		private void Form1_Load(object sender, System.EventArgs e)
		{
			IPHostEntry hostInfo = Dns.GetHostByName(Dns.GetHostName());
			myIP = hostInfo.AddressList[0].ToString();
			xServer = new XYNetServer(myIP,16000,2,5);
			xServer.SetStringInputHandler(new StringInputHandlerDelegate(Receive));
			if(!xServer.StartServer())
				MessageBox.Show("Unable to load connection");
			this.xMess = "SERVER";
			this.LoadTrayIcon();
			this.timer2.Start();
		}

		private void LoadTrayIcon()
		{
			this.trayIcon.Icon = new Icon(GetType(), "App.ico");
			this.trayIcon.Text = "CWD";
			this.trayIcon.Visible = true;
			this.trayIcon.DoubleClick += new EventHandler(OnDoubleClickIcon);
		}

		private void OnDoubleClickIcon(object sender, EventArgs e)
		{
			this.Show();
		}

		private void LoadData()
		{
			this.listView1.Items.Clear();
			this.ds = new DataSet();
			this.ds.Namespace = "Tickets";
			if (System.IO.File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\CWD\\tickets.xml"))
			{
				this.ds.ReadXml(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\CWD\\tickets.xml");
				if (this.ds.Tables.Count > 0) 
					foreach (DataRow dr in this.ds.Tables["ticket"].Rows)
					{
						if (dr["Showit"].ToString() == "1") 
						{
							int icon = 0;
							string[] items = new string[6];
							items[0] = dr["ID"].ToString();
							items[1] = dr["Kind"].ToString();
							items[2] = dr["Title"].ToString();
							items[3] = dr["Desc"].ToString();
							items[4] = dr["Status"].ToString().Trim();
							if (items[4] == "ON WORK")
								icon = 1;
							else if (items[4] == "COMPLETE")
								icon = 2;
							items[5] = "1";
							ListViewItem lv = new ListViewItem(items, icon);
							this.listView1.Items.Add(lv);
						}
					}
				else 
					CreateTable();
			}
			else
				CreateTable();
		}

		private void CreateTable()
		{
			this.ds.Tables.Add("ticket");
			this.ds.Tables["ticket"].Columns.Add("ID");
			this.ds.Tables["ticket"].Columns.Add("Kind");
			this.ds.Tables["ticket"].Columns.Add("Title");
			this.ds.Tables["ticket"].Columns.Add("Desc");
			this.ds.Tables["ticket"].Columns.Add("Status");
			this.ds.Tables["ticket"].Columns.Add("Showit");
			try 
			{
				System.IO.Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\CWD");
				this.ds.WriteXml(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\CWD\\tickets.xml");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				this.trayIcon.ShowBalloon("File System Error","Unabled to create tickets file.",JCMLib.NotifyIconEx.NotifyInfoFlags.Error, 100);
			}
		}

		private void SaveData()
		{
			try 
			{
				this.ds.Tables["ticket"].Rows.Clear();
				foreach(ListViewItem i in this.listView1.Items)
				{
					DataRow drw = this.ds.Tables["ticket"].NewRow();
					drw["ID"] = i.SubItems[0].Text;
					drw["Kind"] = i.SubItems[1].Text;
					drw["Title"] = i.SubItems[2].Text;
					drw["Desc"] = i.SubItems[3].Text;
					drw["Status"] = i.SubItems[4].Text;
					drw["Showit"] = i.SubItems[5].Text;
					this.ds.Tables["ticket"].Rows.Add(drw);
				}
				this.ds.WriteXml(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\CWD\\tickets.xml");
				this.LoadData();
			} 
			catch 
			{

			}
			GC.Collect();
		}

		private void tabControl1_SelectionChanged(Crownwood.DotNetMagic.Controls.TabControl sender, Crownwood.DotNetMagic.Controls.TabPage oldPage, Crownwood.DotNetMagic.Controls.TabPage newPage)
		{
		
		}

		#region CWD WMI Methods
		private System.Management.ManagementObjectCollection Consulta(string strQuery)
		{
			ManagementObjectCollection queryCollection;
			try
			{
				System.Management.ManagementScope ms = new System.Management.ManagementScope("\\\\" + Environment.MachineName + "\\root\\cimv2", new ConnectionOptions());
				queryCollection = new ManagementObjectSearcher(ms, new System.Management.ObjectQuery(strQuery)).Get();
			}
			catch
			{
				queryCollection=null;
			}
			return queryCollection;
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
		private void scanMore()
		{
			bool errors = false; 
			try 
			{
				foreach (System.Management.ManagementObject mo in Consulta("SELECT * FROM Win32_Processor"))
				{
					Node tmpnd = new Node("Processor: " + mo["Name"].ToString().Trim());
					this.node1.Nodes.Add(tmpnd);
				}
			} 
			catch	{ errors = true; }
			try 
			{
				foreach (System.Management.ManagementObject mo in Consulta("SELECT * FROM Win32_BaseBoard"))
				{
					Node tmpnd = new Node("Base Board: " + mo["Manufacturer"]);
					this.node1.Nodes.Add(tmpnd);
				}
				this.Update();
			} 
			catch	{ errors = true; }
			try 
			{
				foreach (System.Management.ManagementObject mo in Consulta("SELECT * FROM Win32_NetworkAdapter WHERE AdapterTypeId = 0"))
				{
					Node tmpnd = new Node("NIC: " + mo["ProductName"] + " (" + mo["MACAddress"] + ")");
					this.node2.Nodes.Add(tmpnd);
				}
				this.Update();
			} 
			catch	{ errors = true; }
			try 
			{
				foreach (System.Management.ManagementObject mo in Consulta("SELECT * FROM Win32_DesktopMonitor WHERE Availability = 3"))
				{
					Node tmpnd = new Node("Monitor: " + mo["MonitorType"]);
					this.node3.Nodes.Add(tmpnd);
				}
			} 
			catch	{ errors = true; }
			try 
			{
				foreach (System.Management.ManagementObject mo in Consulta("SELECT * FROM Win32_VideoController"))
				{
					Node tmpnd = new Node("Video Card: " + mo["Caption"]);
					this.node3.Nodes.Add(tmpnd);
				}
				this.Update();
			} 
			catch	{ errors = true; }
			try 
			{
				foreach (System.Management.ManagementObject mo in Consulta("SELECT * FROM Win32_Printer"))
				{
					Node tmpnd = new Node("Name: " + mo["Caption"]);
					this.node4.Nodes.Add(tmpnd);
				}
				this.Update();
			} 
			catch	{ errors = true; }
			try 
			{
				foreach (System.Management.ManagementObject mo in Consulta("SELECT * FROM Win32_DiskDrive WHERE MediaLoaded = TRUE"))
				{
					Node tmpnd = new Node("Name: " + mo["Caption"] + " (" + formatSize(Convert.ToInt64(mo["Size"].ToString()),false) + ")");
					this.node5.Nodes.Add(tmpnd);				}
				this.Update();
			} 
			catch	{ errors = true; }
			try 
			{
				foreach (System.Management.ManagementObject mo in Consulta("SELECT * FROM Win32_CDROMDrive"))
				{
					Node tmpnd = new Node("Name: " + mo["Caption"] + " (" + mo["Id"] + ")");
					this.node6.Nodes.Add(tmpnd);				}
				this.Update();
			} 
			catch	{ errors = true; }
			try 
			{
				foreach (System.Management.ManagementObject mo in Consulta("SELECT * FROM Win32_SoundDevice"))
				{
					Node tmpnd = new Node("Name: " + mo["Description"]);
					this.node7.Nodes.Add(tmpnd);
				}
				this.Update();
			} 
			catch	{ errors = true; }
			
			if(errors)
				MessageBox.Show(this, "Error scanning system, information could be incomplete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

			this.titleBar2.PostText = "";
		}

		#endregion

		private void buttonWithStyle5_Click(object sender, System.EventArgs e)
		{
			this.xMess = "POLICIE";
			this.SendMess(this.textBox1.Text, "POLICIE,"+Environment.MachineName+","+Environment.UserName);
		}

		private void SendMess(string host, string mess)
		{
			xClient = new XYNetClient(host, 16001);
			if (xClient.Connect()) 
				xClient.SendStringData(mess);
			else 
				this.trayIcon.ShowBalloon("Error","Unabled to connect to server.",JCMLib.NotifyIconEx.NotifyInfoFlags.Error, 1000);
			xClient = null;
		}

		private void Receive(string sRemoteAddress, int nRemotePort, string sData)
		{
			XmlDocument xmldoc = new XmlDocument();
			switch(xMess) 
			{
				case "POLICIE":
					this.trayIcon.ShowBalloon("Policies","Updating policies.",JCMLib.NotifyIconEx.NotifyInfoFlags.Info, 100);
					this.StopService("CWDMonitor");
					xmldoc.LoadXml(sData);
					xmldoc.Save(System.Environment.GetFolderPath(System.Environment.SpecialFolder.System) + "\\CWD\\bads.xml");
					this.StartService("CWDMonitor");
					xMess = string.Empty;
					break;
				case "SERVER":
					this.timer1.Dispose();
					this.textBox1.Text = sData;
					this.trayIcon.ShowBalloon("Connected","Your current server is: " + sData.Trim(),JCMLib.NotifyIconEx.NotifyInfoFlags.Info, 100);
					this.titleBar1.PostText = "Getting tickets...";
					this.buttonWithStyle2.Enabled = true;
					this.buttonWithStyle3.Enabled = true;
					if (System.IO.File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\CWD\\tickets.xml"))
						xmldoc.Load(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\CWD\\tickets.xml");
					else
						xmldoc.LoadXml("<?xml version=\"1.0\" standalone=\"yes\"?>\n<NewDataSet xmlns=\"Tickets\" />");
					this.SendMess(this.textBox1.Text,"TICKETS|"+Environment.MachineName+"|"+Environment.UserName+"|"+xmldoc.InnerXml);
					this.xMess = "TICKETS";
					break;
				case "TICKETS":
					this.titleBar1.PostText = "";
					xmldoc.LoadXml(sData);
					xmldoc.Save(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\CWD\\tickets.xml");
					xMess = string.Empty;
					this.LoadData();
					this.xMess = "POLICIE";
					this.SendMess(this.textBox1.Text, "POLICIE,"+Environment.MachineName+","+Environment.UserName);
					break;
				default:
					MessageBox.Show(sData);
					break;
			}
			xmldoc = null;
		}

		private void Mein_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (!Environment.HasShutdownStarted || !terminate) 
			{
				e.Cancel = true;
				Hide();
			}
		}

		private void StopService(string name)
		{
			foreach (ManagementObject mo in Consulta("SELECT * FROM Win32_Service WHERE Name = '" + name + "'"))
				if (mo["Started"].Equals(true))
					mo.InvokeMethod("StopService", null);
		}

		private void StartService(string name)
		{
			foreach (ManagementObject mo in Consulta("SELECT * FROM Win32_Service WHERE Name = '" + name + "'"))
				if (mo["Started"].Equals(false))
					mo.InvokeMethod("StartService", null);
		}
		
		private void SetMulticast()
		{
			try	
			{
				Socket sokete = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
				IPAddress ip = IPAddress.Parse("224.0.0.1");
				//sokete.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(ip));
				sokete.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, 3);
				IPEndPoint ipep=new IPEndPoint(ip, 5000);
				sokete.Connect(ipep);
				byte[] myname = System.Text.ASCIIEncoding.ASCII.GetBytes(Environment.MachineName);
				sokete.Send(myname,myname.Length,SocketFlags.None);
				sokete.Close();
				GC.Collect();
			} 
			catch(Exception er) 
			{
				MessageBox.Show(er.ToString());
				this.timer1.Dispose();
			}
		}

		private void notifyIcon1_DoubleClick(object sender, System.EventArgs e)
		{
			Show();
		}

		private void buttonWithStyle1_Click_1(object sender, System.EventArgs e)
		{
			this.titleBar2.PostText = "Scanning...";
			Thread th = new Thread(new ThreadStart(scanMore));
			th.IsBackground = true;
			th.Start();
			this.buttonWithStyle1.Enabled = false;
		}
		
		private void buttonWithStyle2_Click(object sender, System.EventArgs e)
		{
			CWD.ticket tick = new ticket();
			tick.EditMode = false;
			if (tick.ShowDialog() == DialogResult.OK)
			{
				ListViewItem lv = new ListViewItem(tick.Data);
				this.listView1.Items.Add(lv);
				this.SaveData();
			}
			tick.Dispose();
		}

		private void listView1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			System.Windows.Forms.ListView listViewObject = (System.Windows.Forms.ListView) sender;
			ContextMenu mnuContextMenu = new ContextMenu();
			MenuItem menuItem = new MenuItem("Edit");
			MenuItem menuItem2 = new MenuItem("Close");
			MenuItem menuItem3 = new MenuItem("Delete");

			if (e.Button == System.Windows.Forms.MouseButtons.Right) 
			{
				try 
				{
					tItem = listViewObject.GetItemAt(e.X,e.Y);
					this.ipt = listViewObject.GetItemAt(e.X,e.Y).Index;
					if (tItem.Index > -1)
					{
						listViewObject.ContextMenu = mnuContextMenu;
				
						mnuContextMenu.MenuItems.Add(menuItem);
						mnuContextMenu.MenuItems.Add(menuItem2);
						mnuContextMenu.MenuItems.Add(menuItem3);
						menuItem.Click  += new System.EventHandler(this.menuItem_Click);
						menuItem2.Click  += new System.EventHandler(this.menuItem2_Click);
						menuItem3.Click  += new System.EventHandler(this.menuItem3_Click);
					}
				} 
				catch 
				{

				}
			}
		}
		private void menuItem_Click(object sender, System.EventArgs e)
		{
			CWD.ticket tick = new ticket();
			tick.EditMode = true;
			string[] tStr = new string[6];
			tStr[0] = tItem.SubItems[0].Text;
			tStr[1] = tItem.SubItems[1].Text;
			tStr[2] = tItem.SubItems[2].Text;
			tStr[3] = tItem.SubItems[3].Text;
			tStr[4] = tItem.SubItems[4].Text;
			tStr[5] = tItem.SubItems[5].Text;
			tick.Data = tStr;
			if (tick.ShowDialog() == DialogResult.OK)
			{
				MessageBox.Show(this.ipt.ToString());
				this.listView1.Items[this.ipt].SubItems[3].Text = tick.Data[3];
				this.SaveData();
			}
			tick.Dispose();
		}
		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			this.listView1.Items[tItem.Index].SubItems[4].Text = "CLOSED";
			this.SaveData();
		}
		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			this.listView1.Items[tItem.Index].SubItems[5].Text = "0";
			this.SaveData();
		}

		private void buttonWithStyle3_Click(object sender, System.EventArgs e)
		{
			XmlDocument xmldoc = new XmlDocument();
			xmldoc.Load(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\CWD\\tickets.xml");
			this.SendMess(this.textBox1.Text,"TICKETS|"+Environment.MachineName+"|"+Environment.UserName+"|"+xmldoc.InnerXml);
			this.xMess = "TICKETS";
			xmldoc = null;
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if (tries < 6)
			{
				this.SetMulticast();
				tries++;
			} 
			else 
			{
				this.timer1.Dispose();
				this.trayIcon.ShowBalloon("Server","Unabled to find a valid HWD Server.\nCWD oprions will be disabled.",JCMLib.NotifyIconEx.NotifyInfoFlags.Error, 100);
			}
		}

		private void timer2_Tick(object sender, System.EventArgs e)
		{
			this.LoadData();
		}

		private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
		{
			Thread.CurrentThread.CurrentUICulture = this.m_EnglishCulture;
			this.UpdateUI();
		}

		private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
		{
			Thread.CurrentThread.CurrentUICulture = this.m_SpanishCulture;
			this.UpdateUI();
		}

		private void buttonWithStyle4_Click(object sender, System.EventArgs e)
		{
			terminate = true;
			Application.Exit();
		}
	}
}
