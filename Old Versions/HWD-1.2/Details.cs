#define DEBUG
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Management;
using System.Globalization;
using LineChart;
using System.Threading;
using System.Xml;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Resources;
using Crownwood.DotNetMagic.Common;
using Crownwood.DotNetMagic.Controls;

namespace HWD
{
	public delegate void addItemDelegate(ListViewItem lvitem);
	public delegate void countOneDelegate();
	public class Details : System.Windows.Forms.Form
	{
		public int ID;
		public bool hotfixfile;
		public bool anotherLogin;
		public string username;
		public string password;
		private string insys;
		private Point rightMouseDownPoint;
		private ManagementObjectSearcher query;
		private ManagementObjectCollection queryCollection;
		private System.Management.ObjectQuery oq;
		private ConnectionOptions co = new ConnectionOptions();
		private System.Diagnostics.PerformanceCounter performanceCounter1;
		private System.Windows.Forms.Timer timer1;
		private System.Diagnostics.PerformanceCounter performanceCounter2;
		private ReportPrinting.ReportDocument reportDocument1;
		private HWD.userData userData1;
		private System.Data.DataView dviUser;
		private System.Data.DataView dviSoftware;
		private System.ComponentModel.IContainer components;
		private LineChart.Line2D gr1 = new Line2D();
		private LineChart.Line2D gr2 = new Line2D();
		private ArrayList arrX1 = new ArrayList();
		private ArrayList arrY1 = new ArrayList();
		private ArrayList arrX2 = new ArrayList();
		private ArrayList arrY2 = new ArrayList();
		private int i = 0;
		private string ServiceName;
		private string ServiceAction;
		private ListViewItem ServiceItem;
		private bool stopScan = true;
		private ListViewItem lvItem;
		private long timeElapsed;
		private System.TimeSpan time;
		private System.Data.DataSet ds = new DataSet();
		private System.Windows.Forms.ContextMenu cmnHotfix;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Data.DataView dviHotfix;
		private System.Data.DataSet tempds;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Data.DataTable dt;
		private ResourceManager m_ResourceManager;
		private bool rpReady = false;
		private string rpPrinters = string.Empty;
		private string rpProcessors = string.Empty;
		private string rpNICs = string.Empty;
		private string rpHDs = string.Empty;
		private string rpCDs = string.Empty;
		private string ProcessID;
		private System.Windows.Forms.ImageList imageList1;
		private ListViewItem ProcessItem;
		private Crownwood.DotNetMagic.Controls.TabControl tabControl2;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox cboLocation;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cboKind;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtNotes;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage5;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage8;
		private System.Windows.Forms.Label lblPer1;
		private System.Windows.Forms.PictureBox graph2;
		private System.Windows.Forms.PictureBox graph1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListView lstPro;
		private System.Windows.Forms.ColumnHeader columnHeader25;
		private System.Windows.Forms.ColumnHeader columnHeader22;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ListView listView3;
		private System.Windows.Forms.ColumnHeader columnHeader24;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.ColumnHeader columnHeader20;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage3;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage9;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage2;
		private System.Windows.Forms.DataGrid dataGrid1;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage4;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage6;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage7;
		private System.Windows.Forms.ListView listViewServiceslistView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.CheckBox chkAll;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.NumericUpDown upTwo;
		private System.Windows.Forms.NumericUpDown upOne;
		private System.Windows.Forms.ListView lsvStatus;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		private System.Windows.Forms.ColumnHeader columnHeader15;
		private System.Windows.Forms.ColumnHeader columnHeader16;
		private System.Windows.Forms.ColumnHeader columnHeader17;
		private System.Windows.Forms.ColumnHeader columnHeader18;
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar1;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button1;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle btnCancel;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button3;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button4;
		private Crownwood.DotNetMagic.Controls.TreeControl treeControl1;
		private Crownwood.DotNetMagic.Controls.Node node1;
		private Crownwood.DotNetMagic.Controls.Node node2;
		private Crownwood.DotNetMagic.Controls.Node node3;
		private Crownwood.DotNetMagic.Controls.Node node4;
		private Crownwood.DotNetMagic.Controls.Node node5;
		private Crownwood.DotNetMagic.Controls.Node node6;
		private System.Windows.Forms.Label lblPer2;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button6;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button5;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button2;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button9;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button13;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button12;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button11;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button7;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button8;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle btnScan;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button10;
		private IPHostEntry iphe;

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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Details));
			this.dviUser = new System.Data.DataView();
			this.userData1 = new HWD.userData();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.cmnHotfix = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.dviHotfix = new System.Data.DataView();
			this.dviSoftware = new System.Data.DataView();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.performanceCounter1 = new System.Diagnostics.PerformanceCounter();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.performanceCounter2 = new System.Diagnostics.PerformanceCounter();
			this.reportDocument1 = new ReportPrinting.ReportDocument();
			this.tempds = new System.Data.DataSet();
			this.tabControl2 = new Crownwood.DotNetMagic.Controls.TabControl();
			this.tabPage1 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.tabPage5 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.tabPage8 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.tabPage3 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.tabPage9 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.tabPage2 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.tabPage4 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.tabPage6 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.tabPage7 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label12 = new System.Windows.Forms.Label();
			this.cboLocation = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cboKind = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtNotes = new System.Windows.Forms.TextBox();
			this.lblPer1 = new System.Windows.Forms.Label();
			this.graph2 = new System.Windows.Forms.PictureBox();
			this.graph1 = new System.Windows.Forms.PictureBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.dataGrid2 = new System.Windows.Forms.DataGrid();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.lstPro = new System.Windows.Forms.ListView();
			this.columnHeader25 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader22 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.listView3 = new System.Windows.Forms.ListView();
			this.columnHeader24 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader20 = new System.Windows.Forms.ColumnHeader();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.listViewServiceslistView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.chkAll = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.upTwo = new System.Windows.Forms.NumericUpDown();
			this.upOne = new System.Windows.Forms.NumericUpDown();
			this.lsvStatus = new System.Windows.Forms.ListView();
			this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
			this.titleBar1 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.button1 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.btnCancel = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.button3 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.button4 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.treeControl1 = new Crownwood.DotNetMagic.Controls.TreeControl();
			this.node1 = new Crownwood.DotNetMagic.Controls.Node();
			this.node2 = new Crownwood.DotNetMagic.Controls.Node();
			this.node3 = new Crownwood.DotNetMagic.Controls.Node();
			this.node4 = new Crownwood.DotNetMagic.Controls.Node();
			this.node5 = new Crownwood.DotNetMagic.Controls.Node();
			this.node6 = new Crownwood.DotNetMagic.Controls.Node();
			this.lblPer2 = new System.Windows.Forms.Label();
			this.button6 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.button5 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.button2 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.button9 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.button13 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.button12 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.button11 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.button7 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.button8 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.btnScan = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.button10 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			((System.ComponentModel.ISupportInitialize)(this.dviUser)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.userData1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dviHotfix)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dviSoftware)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.performanceCounter2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tempds)).BeginInit();
			this.tabControl2.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.tabPage8.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage9.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.tabPage7.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.upTwo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.upOne)).BeginInit();
			this.SuspendLayout();
			// 
			// userData1
			// 
			this.userData1.DataSetName = "userData";
			this.userData1.Locale = new System.Globalization.CultureInfo("es-MX");
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// cmnHotfix
			// 
			this.cmnHotfix.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "Install...";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem2});
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "Explore";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// performanceCounter1
			// 
			this.performanceCounter1.CategoryName = "Paging File";
			this.performanceCounter1.CounterName = "% Usage";
			this.performanceCounter1.InstanceName = "_Total";
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// performanceCounter2
			// 
			this.performanceCounter2.CategoryName = "Processor";
			this.performanceCounter2.CounterName = "% Processor Time";
			this.performanceCounter2.InstanceName = "_Total";
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
			// tempds
			// 
			this.tempds.DataSetName = "NewDataSet";
			this.tempds.Locale = new System.Globalization.CultureInfo("es-MX");
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
			this.tabPage1.Controls.Add(this.treeControl1);
			this.tabPage1.Controls.Add(this.button4);
			this.tabPage1.Controls.Add(this.button3);
			this.tabPage1.Controls.Add(this.groupBox1);
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
			this.tabPage5.Controls.Add(this.button6);
			this.tabPage5.Controls.Add(this.lblPer2);
			this.tabPage5.Controls.Add(this.lblPer1);
			this.tabPage5.Controls.Add(this.graph2);
			this.tabPage5.Controls.Add(this.graph1);
			this.tabPage5.Controls.Add(this.label10);
			this.tabPage5.Controls.Add(this.label8);
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
			// tabPage8
			// 
			this.tabPage8.Controls.Add(this.button9);
			this.tabPage8.Controls.Add(this.dataGrid2);
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
			this.tabPage3.Controls.Add(this.button12);
			this.tabPage3.Controls.Add(this.button13);
			this.tabPage3.Controls.Add(this.textBox1);
			this.tabPage3.Controls.Add(this.label2);
			this.tabPage3.Controls.Add(this.lstPro);
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
			this.tabPage9.Controls.Add(this.button11);
			this.tabPage9.Controls.Add(this.listView3);
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
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.button2);
			this.tabPage2.Controls.Add(this.button5);
			this.tabPage2.Controls.Add(this.dataGrid1);
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
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.button7);
			this.tabPage4.Controls.Add(this.listViewServiceslistView1);
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
			this.tabPage6.Controls.Add(this.button8);
			this.tabPage6.Controls.Add(this.listView1);
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
			this.tabPage7.Controls.Add(this.button10);
			this.tabPage7.Controls.Add(this.btnScan);
			this.tabPage7.Controls.Add(this.lsvStatus);
			this.tabPage7.Controls.Add(this.progressBar1);
			this.tabPage7.Controls.Add(this.chkAll);
			this.tabPage7.Controls.Add(this.label7);
			this.tabPage7.Controls.Add(this.upTwo);
			this.tabPage7.Controls.Add(this.upOne);
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
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
			this.groupBox1.Controls.Add(this.checkBox1);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.cboLocation);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.cboKind);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.txtNotes);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox1.Location = new System.Drawing.Point(11, 56);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(280, 200);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "System Admin Info";
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(120, 88);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(120, 24);
			this.checkBox1.TabIndex = 9;
			this.checkBox1.Text = "Active?";
			// 
			// label12
			// 
			this.label12.BackColor = System.Drawing.Color.Transparent;
			this.label12.Location = new System.Drawing.Point(8, 64);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(100, 16);
			this.label12.TabIndex = 8;
			this.label12.Text = "Location:";
			// 
			// cboLocation
			// 
			this.cboLocation.BackColor = System.Drawing.Color.White;
			this.cboLocation.DataSource = this.userData1;
			this.cboLocation.DisplayMember = "LWD.LocationName";
			this.cboLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboLocation.Location = new System.Drawing.Point(120, 56);
			this.cboLocation.Name = "cboLocation";
			this.cboLocation.Size = new System.Drawing.Size(121, 20);
			this.cboLocation.TabIndex = 7;
			this.cboLocation.ValueMember = "Location";
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Location = new System.Drawing.Point(8, 128);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 16);
			this.label6.TabIndex = 2;
			this.label6.Text = "Notes:";
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Location = new System.Drawing.Point(8, 32);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 16);
			this.label4.TabIndex = 0;
			this.label4.Text = "Kind:";
			// 
			// cboKind
			// 
			this.cboKind.BackColor = System.Drawing.Color.White;
			this.cboKind.DataSource = this.userData1;
			this.cboKind.DisplayMember = "KWD.KindName";
			this.cboKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboKind.Location = new System.Drawing.Point(120, 24);
			this.cboKind.Name = "cboKind";
			this.cboKind.Size = new System.Drawing.Size(121, 20);
			this.cboKind.TabIndex = 3;
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Location = new System.Drawing.Point(8, 96);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 16);
			this.label5.TabIndex = 1;
			this.label5.Text = "Status";
			// 
			// txtNotes
			// 
			this.txtNotes.BackColor = System.Drawing.Color.White;
			this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtNotes.Location = new System.Drawing.Point(120, 120);
			this.txtNotes.Multiline = true;
			this.txtNotes.Name = "txtNotes";
			this.txtNotes.Size = new System.Drawing.Size(152, 56);
			this.txtNotes.TabIndex = 5;
			this.txtNotes.Text = "";
			// 
			// lblPer1
			// 
			this.lblPer1.BackColor = System.Drawing.Color.Black;
			this.lblPer1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblPer1.ForeColor = System.Drawing.Color.GreenYellow;
			this.lblPer1.Location = new System.Drawing.Point(552, 72);
			this.lblPer1.Name = "lblPer1";
			this.lblPer1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lblPer1.Size = new System.Drawing.Size(56, 16);
			this.lblPer1.TabIndex = 22;
			this.lblPer1.Text = "0";
			// 
			// graph2
			// 
			this.graph2.BackColor = System.Drawing.Color.Black;
			this.graph2.Location = new System.Drawing.Point(24, 192);
			this.graph2.Name = "graph2";
			this.graph2.Size = new System.Drawing.Size(584, 80);
			this.graph2.TabIndex = 21;
			this.graph2.TabStop = false;
			// 
			// graph1
			// 
			this.graph1.BackColor = System.Drawing.Color.Black;
			this.graph1.Location = new System.Drawing.Point(24, 72);
			this.graph1.Name = "graph1";
			this.graph1.Size = new System.Drawing.Size(584, 80);
			this.graph1.TabIndex = 20;
			this.graph1.TabStop = false;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(16, 168);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(136, 16);
			this.label10.TabIndex = 19;
			this.label10.Text = "CPU Usage";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(16, 48);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(128, 16);
			this.label8.TabIndex = 18;
			this.label8.Text = "Memory Usage";
			// 
			// dataGrid2
			// 
			this.dataGrid2.AlternatingBackColor = System.Drawing.Color.LightGray;
			this.dataGrid2.BackColor = System.Drawing.Color.Gainsboro;
			this.dataGrid2.BackgroundColor = System.Drawing.Color.Silver;
			this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid2.CaptionBackColor = System.Drawing.Color.LightSteelBlue;
			this.dataGrid2.CaptionForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid2.CaptionText = "Hotfixes to Install";
			this.dataGrid2.CaptionVisible = false;
			this.dataGrid2.ContextMenu = this.cmnHotfix;
			this.dataGrid2.DataMember = "";
			this.dataGrid2.DataSource = this.dviHotfix;
			this.dataGrid2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dataGrid2.FlatMode = true;
			this.dataGrid2.Font = new System.Drawing.Font("Tahoma", 8F);
			this.dataGrid2.ForeColor = System.Drawing.Color.Black;
			this.dataGrid2.GridLineColor = System.Drawing.Color.DimGray;
			this.dataGrid2.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
			this.dataGrid2.HeaderBackColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid2.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.dataGrid2.HeaderForeColor = System.Drawing.Color.White;
			this.dataGrid2.LinkColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid2.Location = new System.Drawing.Point(0, 49);
			this.dataGrid2.Name = "dataGrid2";
			this.dataGrid2.ParentRowsBackColor = System.Drawing.Color.DarkGray;
			this.dataGrid2.ParentRowsForeColor = System.Drawing.Color.Black;
			this.dataGrid2.PreferredColumnWidth = 85;
			this.dataGrid2.ReadOnly = true;
			this.dataGrid2.SelectionBackColor = System.Drawing.Color.CadetBlue;
			this.dataGrid2.SelectionForeColor = System.Drawing.Color.White;
			this.dataGrid2.Size = new System.Drawing.Size(614, 240);
			this.dataGrid2.TabIndex = 17;
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.Color.White;
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox1.Location = new System.Drawing.Point(88, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(128, 18);
			this.textBox1.TabIndex = 20;
			this.textBox1.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 16);
			this.label2.TabIndex = 19;
			this.label2.Text = "New Process:";
			// 
			// lstPro
			// 
			this.lstPro.BackColor = System.Drawing.Color.White;
			this.lstPro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstPro.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					 this.columnHeader25,
																					 this.columnHeader22,
																					 this.columnHeader9});
			this.lstPro.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lstPro.FullRowSelect = true;
			this.lstPro.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lstPro.Location = new System.Drawing.Point(0, 49);
			this.lstPro.Name = "lstPro";
			this.lstPro.Size = new System.Drawing.Size(614, 240);
			this.lstPro.SmallImageList = this.imageList1;
			this.lstPro.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lstPro.TabIndex = 18;
			this.lstPro.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader25
			// 
			this.columnHeader25.Text = "ID";
			this.columnHeader25.Width = 74;
			// 
			// columnHeader22
			// 
			this.columnHeader22.Text = "Process";
			this.columnHeader22.Width = 189;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "User";
			this.columnHeader9.Width = 150;
			// 
			// listView3
			// 
			this.listView3.BackColor = System.Drawing.Color.White;
			this.listView3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader24,
																						this.columnHeader10,
																						this.columnHeader12,
																						this.columnHeader20});
			this.listView3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.listView3.FullRowSelect = true;
			this.listView3.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView3.Location = new System.Drawing.Point(0, 49);
			this.listView3.Name = "listView3";
			this.listView3.Size = new System.Drawing.Size(614, 240);
			this.listView3.SmallImageList = this.imageList1;
			this.listView3.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.listView3.TabIndex = 18;
			this.listView3.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader24
			// 
			this.columnHeader24.Text = "Type";
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "Event Code";
			this.columnHeader10.Width = 101;
			// 
			// columnHeader12
			// 
			this.columnHeader12.Text = "Source";
			this.columnHeader12.Width = 70;
			// 
			// columnHeader20
			// 
			this.columnHeader20.Text = "Message";
			this.columnHeader20.Width = 298;
			// 
			// dataGrid1
			// 
			this.dataGrid1.AlternatingBackColor = System.Drawing.Color.LightGray;
			this.dataGrid1.BackColor = System.Drawing.Color.Gainsboro;
			this.dataGrid1.BackgroundColor = System.Drawing.Color.Silver;
			this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid1.CaptionBackColor = System.Drawing.Color.LightSteelBlue;
			this.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.CaptionText = "Installed Software";
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.DataSource = this.dviSoftware;
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dataGrid1.FlatMode = true;
			this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8F);
			this.dataGrid1.ForeColor = System.Drawing.Color.Black;
			this.dataGrid1.GridLineColor = System.Drawing.Color.DimGray;
			this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
			this.dataGrid1.HeaderBackColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.dataGrid1.HeaderForeColor = System.Drawing.Color.White;
			this.dataGrid1.LinkColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.Location = new System.Drawing.Point(0, 49);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.DarkGray;
			this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.Black;
			this.dataGrid1.PreferredColumnWidth = 85;
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
			this.dataGrid1.SelectionForeColor = System.Drawing.Color.White;
			this.dataGrid1.Size = new System.Drawing.Size(614, 240);
			this.dataGrid1.TabIndex = 10;
			// 
			// listViewServiceslistView1
			// 
			this.listViewServiceslistView1.BackColor = System.Drawing.Color.White;
			this.listViewServiceslistView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listViewServiceslistView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																										this.columnHeader1,
																										this.columnHeader2,
																										this.columnHeader3,
																										this.columnHeader4});
			this.listViewServiceslistView1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.listViewServiceslistView1.FullRowSelect = true;
			this.listViewServiceslistView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewServiceslistView1.Location = new System.Drawing.Point(0, 49);
			this.listViewServiceslistView1.Name = "listViewServiceslistView1";
			this.listViewServiceslistView1.Size = new System.Drawing.Size(614, 240);
			this.listViewServiceslistView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.listViewServiceslistView1.TabIndex = 13;
			this.listViewServiceslistView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Service";
			this.columnHeader1.Width = 220;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Start Mode";
			this.columnHeader2.Width = 90;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Status";
			this.columnHeader3.Width = 90;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Account";
			this.columnHeader4.Width = 100;
			// 
			// listView1
			// 
			this.listView1.BackColor = System.Drawing.Color.White;
			this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader5,
																						this.columnHeader7,
																						this.columnHeader6,
																						this.columnHeader8});
			this.listView1.ContextMenu = this.contextMenu1;
			this.listView1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.listView1.FullRowSelect = true;
			this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView1.Location = new System.Drawing.Point(0, 49);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(614, 240);
			this.listView1.SmallImageList = this.imageList1;
			this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.listView1.TabIndex = 15;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Shared Name";
			this.columnHeader5.Width = 220;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Type";
			this.columnHeader7.Width = 90;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Path";
			this.columnHeader6.Width = 90;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Comments";
			this.columnHeader8.Width = 100;
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(16, 48);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(592, 24);
			this.progressBar1.TabIndex = 24;
			// 
			// chkAll
			// 
			this.chkAll.Enabled = false;
			this.chkAll.Location = new System.Drawing.Point(280, 16);
			this.chkAll.Name = "chkAll";
			this.chkAll.Size = new System.Drawing.Size(96, 24);
			this.chkAll.TabIndex = 23;
			this.chkAll.Text = "Show All";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(16, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 16);
			this.label7.TabIndex = 22;
			this.label7.Text = "Port Range:";
			// 
			// upTwo
			// 
			this.upTwo.Enabled = false;
			this.upTwo.Location = new System.Drawing.Point(176, 16);
			this.upTwo.Name = "upTwo";
			this.upTwo.Size = new System.Drawing.Size(80, 18);
			this.upTwo.TabIndex = 20;
			// 
			// upOne
			// 
			this.upOne.Enabled = false;
			this.upOne.Location = new System.Drawing.Point(88, 16);
			this.upOne.Name = "upOne";
			this.upOne.Size = new System.Drawing.Size(80, 18);
			this.upOne.TabIndex = 19;
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
			this.lsvStatus.Location = new System.Drawing.Point(0, 73);
			this.lsvStatus.Name = "lsvStatus";
			this.lsvStatus.Size = new System.Drawing.Size(614, 216);
			this.lsvStatus.SmallImageList = this.imageList1;
			this.lsvStatus.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lsvStatus.TabIndex = 26;
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
			this.titleBar1.PostText = "Offline";
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
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(16, 8);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(96, 32);
			this.button3.TabIndex = 17;
			this.button3.Text = "Report";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(128, 8);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(96, 32);
			this.button4.TabIndex = 18;
			this.button4.Text = "Scan Hardware";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// treeControl1
			// 
			this.treeControl1.Dock = System.Windows.Forms.DockStyle.Right;
			this.treeControl1.GroupFont = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.treeControl1.HotBackColor = System.Drawing.Color.Empty;
			this.treeControl1.HotForeColor = System.Drawing.Color.Empty;
			this.treeControl1.ImageList = this.imageList1;
			this.treeControl1.Location = new System.Drawing.Point(302, 0);
			this.treeControl1.MinimumNodeHeight = 11;
			this.treeControl1.Name = "treeControl1";
			this.treeControl1.Nodes.AddRange(new Crownwood.DotNetMagic.Controls.Node[] {
																						   this.node1,
																						   this.node2,
																						   this.node3,
																						   this.node4,
																						   this.node5,
																						   this.node6});
			this.treeControl1.SelectedNode = null;
			this.treeControl1.SelectedNoFocusBackColor = System.Drawing.SystemColors.Control;
			this.treeControl1.Size = new System.Drawing.Size(312, 289);
			this.treeControl1.TabIndex = 19;
			this.treeControl1.Text = "treeControl1";
			this.treeControl1.ViewControllers = Crownwood.DotNetMagic.Controls.ViewControllers.Group;
			// 
			// node1
			// 
			this.node1.BackColor = System.Drawing.SystemColors.Window;
			this.node1.Checked = false;
			this.node1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.node1.Image = ((System.Drawing.Image)(resources.GetObject("node1.Image")));
			this.node1.NodeFont = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.node1.Text = "Processors";
			// 
			// node2
			// 
			this.node2.BackColor = System.Drawing.SystemColors.Window;
			this.node2.Checked = false;
			this.node2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.node2.Image = ((System.Drawing.Image)(resources.GetObject("node2.Image")));
			this.node2.NodeFont = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.node2.Text = "Network Adapters";
			// 
			// node3
			// 
			this.node3.BackColor = System.Drawing.SystemColors.Window;
			this.node3.Checked = false;
			this.node3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.node3.Image = ((System.Drawing.Image)(resources.GetObject("node3.Image")));
			this.node3.NodeFont = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.node3.Text = "Video Adapters & Monitors";
			// 
			// node4
			// 
			this.node4.BackColor = System.Drawing.SystemColors.Window;
			this.node4.Checked = false;
			this.node4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.node4.Image = ((System.Drawing.Image)(resources.GetObject("node4.Image")));
			this.node4.NodeFont = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.node4.Text = "Printers";
			// 
			// node5
			// 
			this.node5.BackColor = System.Drawing.SystemColors.Window;
			this.node5.Checked = false;
			this.node5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.node5.Image = ((System.Drawing.Image)(resources.GetObject("node5.Image")));
			this.node5.NodeFont = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.node5.Text = "Hard Disks";
			// 
			// node6
			// 
			this.node6.BackColor = System.Drawing.SystemColors.Window;
			this.node6.Checked = false;
			this.node6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.node6.Image = ((System.Drawing.Image)(resources.GetObject("node6.Image")));
			this.node6.NodeFont = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.node6.Text = "CD-ROM Drives";
			// 
			// lblPer2
			// 
			this.lblPer2.BackColor = System.Drawing.Color.Black;
			this.lblPer2.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblPer2.ForeColor = System.Drawing.Color.GreenYellow;
			this.lblPer2.Location = new System.Drawing.Point(552, 192);
			this.lblPer2.Name = "lblPer2";
			this.lblPer2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lblPer2.Size = new System.Drawing.Size(56, 16);
			this.lblPer2.TabIndex = 23;
			this.lblPer2.Text = "0%";
			// 
			// button6
			// 
			this.button6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.button6.Location = new System.Drawing.Point(16, 8);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(96, 32);
			this.button6.TabIndex = 24;
			this.button6.Text = "Activate";
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button5
			// 
			this.button5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.button5.Location = new System.Drawing.Point(16, 8);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(96, 32);
			this.button5.TabIndex = 25;
			this.button5.Text = "Report";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(512, 8);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(96, 32);
			this.button2.TabIndex = 26;
			this.button2.Text = "Scan Software";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(512, 8);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(96, 32);
			this.button9.TabIndex = 27;
			this.button9.Text = "Get Hotfixes";
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// button13
			// 
			this.button13.Location = new System.Drawing.Point(224, 8);
			this.button13.Name = "button13";
			this.button13.Size = new System.Drawing.Size(96, 32);
			this.button13.TabIndex = 27;
			this.button13.Text = "Create";
			this.button13.Click += new System.EventHandler(this.button13_Click);
			// 
			// button12
			// 
			this.button12.Location = new System.Drawing.Point(512, 8);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(96, 32);
			this.button12.TabIndex = 28;
			this.button12.Text = "Get Processes";
			this.button12.Click += new System.EventHandler(this.button12_Click);
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(512, 8);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(96, 32);
			this.button11.TabIndex = 27;
			this.button11.Text = "Get Log";
			this.button11.Click += new System.EventHandler(this.button11_Click_1);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(512, 8);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(96, 32);
			this.button7.TabIndex = 27;
			this.button7.Text = "Get Services";
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(512, 8);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(96, 32);
			this.button8.TabIndex = 27;
			this.button8.Text = "Get Items";
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// btnScan
			// 
			this.btnScan.Enabled = false;
			this.btnScan.Location = new System.Drawing.Point(408, 8);
			this.btnScan.Name = "btnScan";
			this.btnScan.Size = new System.Drawing.Size(96, 32);
			this.btnScan.TabIndex = 28;
			this.btnScan.Text = "Scan";
			this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(512, 8);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(96, 32);
			this.button10.TabIndex = 29;
			this.button10.Text = "Load XML";
			this.button10.Click += new System.EventHandler(this.button10_Click);
			// 
			// Details
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(616, 407);
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
			((System.ComponentModel.ISupportInitialize)(this.dviUser)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.userData1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dviHotfix)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dviSoftware)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.performanceCounter2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tempds)).EndInit();
			this.tabControl2.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.tabPage8.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage9.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.tabPage6.ResumeLayout(false);
			this.tabPage7.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.upTwo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.upOne)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void UpdateUI()
		{
			this.button2.Text = m_ResourceManager.GetString("dbutton2");
			this.button3.Text = m_ResourceManager.GetString("dbtnReport");
			this.button4.Text = m_ResourceManager.GetString("dbutton4");
			this.button5.Text = m_ResourceManager.GetString("dbtnReport");
			this.button6.Text = m_ResourceManager.GetString("dbutton6");
			this.button7.Text = m_ResourceManager.GetString("dbutton7");
			this.button8.Text = m_ResourceManager.GetString("dbutton8");
			this.button9.Text = m_ResourceManager.GetString("dbutton9");
			this.label4.Text = m_ResourceManager.GetString("dlabel4");
			this.label6.Text = m_ResourceManager.GetString("dlabel6");
			this.label8.Text = m_ResourceManager.GetString("dlabel8");
			this.label10.Text = m_ResourceManager.GetString("dlabel10");
			this.label12.Text = m_ResourceManager.GetString("dlabel12");
			this.btnCancel.Text = m_ResourceManager.GetString("dbtnCancel");
			this.tabPage3.Text = m_ResourceManager.GetString("dtabPage3");
			this.tabPage4.Text = m_ResourceManager.GetString("dtabPage4");
			this.tabPage5.Text = m_ResourceManager.GetString("dtabPage5");
			this.tabPage6.Text = m_ResourceManager.GetString("dtabPage6");
			this.tabPage7.Text = m_ResourceManager.GetString("dtabPage7");
			this.tabPage8.Text = m_ResourceManager.GetString("dtabPage8");
			this.tabPage9.Text = m_ResourceManager.GetString("dtabPage9");
			this.dataGrid1.CaptionText = m_ResourceManager.GetString("ddataGrid1");
			this.dataGrid2.CaptionText = m_ResourceManager.GetString("ddataGrid2");
			this.menuItem1.Text = m_ResourceManager.GetString("dmenuItem1"); 
			this.menuItem2.Text = m_ResourceManager.GetString("dmenuItem2"); 
			this.columnHeader1.Text = m_ResourceManager.GetString("dcolumnHeader1"); 
			this.columnHeader2.Text = m_ResourceManager.GetString("dcolumnHeader2"); 
			this.columnHeader4.Text = m_ResourceManager.GetString("dcolumnHeader4"); 
			this.columnHeader5.Text = m_ResourceManager.GetString("dcolumnHeader5"); 
			this.columnHeader6.Text = m_ResourceManager.GetString("dcolumnHeader6"); 
			this.columnHeader7.Text = m_ResourceManager.GetString("dcolumnHeader7"); 
			this.columnHeader8.Text = m_ResourceManager.GetString("dcolumnHeader8"); 
			this.columnHeader10.Text = m_ResourceManager.GetString("dcolumnHeader10"); 
			this.columnHeader12.Text = m_ResourceManager.GetString("dcolumnHeader12");
			this.columnHeader13.Text = m_ResourceManager.GetString("dcolumnHeader13"); 
			this.columnHeader15.Text = m_ResourceManager.GetString("dcolumnHeader7"); 
			this.columnHeader16.Text = m_ResourceManager.GetString("dcolumnHeader16");
			this.columnHeader17.Text = m_ResourceManager.GetString("dcolumnHeader17");
			this.columnHeader18.Text = m_ResourceManager.GetString("dcolumnHeader18");
			this.columnHeader20.Text = m_ResourceManager.GetString("dcolumnHeader20");  
			this.columnHeader24.Text = m_ResourceManager.GetString("dcolumnHeader7"); 
		}

		private void Details_Load(object sender, System.EventArgs e)
		{
			this.InitDB();
			if (this.anotherLogin == true && this.username.Length > 0)
			{
				co.Username = this.username;
				co.Password = this.password;
			}
			System.Management.ManagementScope ms = new System.Management.ManagementScope("\\\\" + this.insys + "\\root\\cimv2", co);
			try 
			{
				oq = new System.Management.ObjectQuery("SELECT * FROM Win32_NetworkAdapter");
				query = new ManagementObjectSearcher(ms,oq);

				queryCollection = query.Get();
				this.titleBar1.PostText = "Online";
			} 
			catch 
			{
				MessageBox.Show(this, "Failed connection to system.\nScans are disable.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				this.button2.Enabled = false;
				this.button4.Enabled = false;
				this.button6.Enabled = false;
				this.button7.Enabled = false;
				this.button8.Enabled = false;
				this.button9.Enabled = false;
				this.button10.Enabled = false;
				this.button11.Enabled = false;
				this.btnScan.Enabled = false;
			}

			if (!this.hotfixfile)
			{
				this.button9.Enabled = false;
			}
			this.InitGraph();
			this.UpdateUI();
		}

		private void InitGraph()
		{
			this.gr1.Width = this.graph1.Width;
			this.gr1.Height = this.graph1.Height;
			this.gr2.Width = this.graph2.Width;
			this.gr2.Height = this.graph2.Height;

			this.gr1.InitializeGraph();
			this.gr2.InitializeGraph();
			this.graph1.Image = this.gr1.GetGraph();
			this.graph2.Image = this.gr2.GetGraph();
		}

		private void InitDB()
		{
			this.dviUser.Table = this.userData1.Tables["HWD"];
			this.dviUser.RowFilter = "ID = " + this.ID.ToString();
			this.titleBar1.Text = this.dviUser[0]["ComputerName"].ToString();
			this.insys = this.dviUser[0]["ComputerName"].ToString();
			if (this.dviUser[0]["Status"].ToString() == "True")
			{
				this.checkBox1.Checked = true;
			} 
			this.txtNotes.Text = this.dviUser[0]["Notes"].ToString();
			this.dviSoftware.Table = this.userData1.Tables["SWD"];
			this.dviSoftware.RowFilter = "ComputerName = '" + this.insys +"'";
			if (this.dviSoftware.Count > 0)
			{
				this.button2.Enabled = false;
			}
		}
		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;

			try 
			{
				foreach (ManagementObject mo in Consulta("SELECT * FROM Win32_Product"))
				{
					DataRow dr = this.dviSoftware.Table.NewRow();
					dr["ComputerName"] = this.insys;
					dr["SoftwareName"] = mo["Name"].ToString();
					dr["Version"] = mo["version"].ToString();
					dr["Vendor"] = mo["Vendor"].ToString();
					this.dviSoftware.Table.Rows.Add(dr);
					this.Update();
				}
				this.button2.Enabled = false;
			} 
			catch
			{
				MessageBox.Show("Failed connection to system.");
			}
			this.Cursor = Cursors.Default;
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
				ndr["ID"] = this.dviUser[0]["ID"].ToString();	
				ndr["ComputerName"] = this.dviUser[0]["ComputerName"].ToString();
				ndr["UserName"] = this.dviUser[0]["UserName"].ToString();
				ndr["OS"] = this.dviUser[0]["OS"].ToString();
				ndr["Model"] = this.dviUser[0]["Model"].ToString();
				ndr["Manufacturer"] = this.dviUser[0]["Manufacturer"].ToString();
				ndr["SerialNumber"] = this.dviUser[0]["SerialNumber"].ToString();
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
			catch
			{
				MessageBox.Show(this, "Unable Report.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			this.Cursor = Cursors.Default;
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			this.scanMore();
		}

		private void scanMore()
		{
			this.Cursor = Cursors.WaitCursor;
			this.rpReady = true;
			try 
			{
				foreach (ManagementObject mo in Consulta("SELECT * FROM Win32_Processor"))
				{
					Node tmpnd = new Node("Caption: " + mo["Caption"]);
					this.node1.Nodes.Add(tmpnd);
					this.rpProcessors = mo["Caption"] + "\n\t\t" + this.rpProcessors;
				}
				this.Update();

				foreach (ManagementObject mo in Consulta("SELECT * FROM Win32_NetworkAdapter"))
				{
					Node tmpnd = new Node("NIC Name: " + mo["ProductName"] + " (" + mo["MACAddress"] + ")");
					this.node2.Nodes.Add(tmpnd);
					this.rpNICs = mo["ProductName"] + " (" + mo["MACAddress"] + ")\n\t\t" + this.rpNICs;
				}
				this.Update();

				foreach (ManagementObject mo in Consulta("SELECT * FROM Win32_DesktopMonitor"))
				{
					Node tmpnd = new Node("Monitor: " + mo["MonitorType"]);
					this.node3.Nodes.Add(tmpnd);
					//createChildNode(nodeCollection, "Screen Height: " + mo["ScreenHeight"], 2);
					//createChildNode(nodeCollection, "Screen Width: " + mo["ScreenWidth"], 2);
				}
				foreach (ManagementObject mo in Consulta("SELECT * FROM Win32_VideoController"))
				{
					Node tmpnd = new Node("Video Card: " + mo["Caption"]);
					this.node3.Nodes.Add(tmpnd);
					//createChildNode(nodeCollection, "BPP: " + mo["CurrentBitsPerPixel"], 2);
				}
				this.Update();

				foreach (ManagementObject mo in Consulta("SELECT * FROM Win32_Printer"))
				{
					Node tmpnd = new Node("Name: " + mo["Caption"]);
					this.node4.Nodes.Add(tmpnd);
					//createChildNode(nodeCollection, "Location: " + mo["Location"], 3);
					this.rpPrinters = mo["Caption"] + "\n\t\t" + this.rpPrinters;
				}
				this.Update();

				foreach (ManagementObject mo in Consulta("SELECT * FROM Win32_DiskDrive"))
				{
					Node tmpnd = new Node("Name: " + mo["Caption"] + " (" + formatSize(Convert.ToInt64(mo["Size"].ToString()),false));
					this.node5.Nodes.Add(tmpnd);
					this.rpHDs = mo["Caption"] + " (" + formatSize(Convert.ToInt64(mo["Size"].ToString()),false) + ")\n\t\t" + this.rpHDs;
				}
				this.Update();

				foreach (ManagementObject mo in Consulta("SELECT * FROM Win32_CDROMDrive"))
				{
					Node tmpnd = new Node("Name: " + mo["Caption"] + " (" + mo["Drive"] + ")");
					this.node6.Nodes.Add(tmpnd);
					this.rpCDs = mo["Caption"] + "\n\t\t" + this.rpCDs;
				}
				this.Update();
			}
			catch
			{
				MessageBox.Show(this, "Failed connection to System.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			
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
				{
					stringSize = "0";
				}
				else 
				{
					stringSize = "1";
				}
			}
			else 
			{
				if (booleanFormatOnly == false)
				{
					lKBSize = lSize / 1024;
				}
				else 
				{
					lKBSize = lSize;
				}

				stringSize = lKBSize.ToString("n",myNfi);
				stringSize = stringSize.Replace(".00", "");
			}

			return stringSize + " KB";

		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			try 
			{
				ReportSWD tmpRep = new ReportSWD();
				tmpRep.dataview = this.dviSoftware;
				preview pre = new preview();
				pre.irp = tmpRep;
				pre.ShowDialog();
			}
			catch 
			{
				MessageBox.Show(this, "Unable Report.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			this.Cursor = Cursors.Default;
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			this.arrX1.Add(i);
			this.arrY1.Add(this.performanceCounter1.NextValue());
			this.lblPer1.Text = Math.Round(this.performanceCounter1.NextValue(),2).ToString();
			this.gr1.XAxis = this.arrX1;
			this.gr1.YAxis = this.arrY1;
			this.gr1.CreateGraph(Color.Red);
			this.graph1.Image = this.gr1.GetGraph();

			this.arrX2.Add(i);
			this.arrY2.Add(this.performanceCounter2.NextValue());
			this.lblPer2.Text = Math.Round(this.performanceCounter2.NextValue(),2).ToString()+"%";
			this.gr2.XAxis = this.arrX2;
			this.gr2.YAxis = this.arrY2;
			this.gr2.CreateGraph(Color.Red);
			this.graph2.Image = this.gr2.GetGraph();
			
			if(this.i > 300) 
			{
				this.i = 0;
				this.arrX1.Clear();
				this.arrY1.Clear();
				this.arrX2.Clear();
				this.arrY2.Clear();
			}
			this.i++;
		}

		private void button6_Click(object sender, System.EventArgs e)
		{
			this.performanceCounter1.MachineName = this.insys;
			this.performanceCounter2.MachineName = this.insys;
			this.timer1.Enabled = true;
			this.button6.Enabled = false;
		}

		private void button7_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			string[] lvData =  new string[4];

			try 
			{
				foreach (ManagementObject mo in Consulta("SELECT * FROM Win32_Service"))
				{
					lvData[0] = mo["Name"].ToString();
					lvData[1] = mo["StartMode"].ToString();
					if (mo["Started"].Equals(true))
						lvData[2] = "Started";
					else
						lvData[2] = "Stop";
					lvData[3] = mo["StartName"].ToString();
					
					ListViewItem lvItem = new ListViewItem(lvData,0);
					this.listViewServiceslistView1.Items.Add(lvItem);
				}
			}

			catch
			{
				MessageBox.Show(this, "Failed connection to System.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			this.button7.Enabled = false;
			this.Cursor = Cursors.Default;
		}

		private void listViewServiceslistView1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			System.Windows.Forms.ListView listViewObject = (System.Windows.Forms.ListView) sender;
			ContextMenu mnuContextMenu = new ContextMenu();
			MenuItem menuItem = new MenuItem();

			if (e.Button == System.Windows.Forms.MouseButtons.Right) 
			{
				ServiceName = listViewObject.GetItemAt(e.X, e.Y).Text;
				ServiceItem = listViewObject.GetItemAt(e.X,e.Y);
				
				listViewObject.ContextMenu = mnuContextMenu;
				try
				{
					foreach (ManagementObject mo in Consulta("SELECT * FROM Win32_Service Where Name = '" + ServiceName + "'"))
					{
						if (mo["Started"].Equals(true))
						{
							menuItem.Text = "Stop";
							ServiceAction = "StopService";
						}
						else
						{
							menuItem.Text = "Start";
							ServiceAction = "StartService";
						}
						mnuContextMenu.MenuItems.Add(menuItem);

						menuItem.Click  += new System.EventHandler(this.menuItem_Click);
					}
				}
				catch (Exception e1)
				{
					MessageBox.Show("Error: " + e1);
				}
			}
			this.Cursor = Cursors.Default;
		}

		private void menuItem_Click(object sender, System.EventArgs e)
		{   
			this.Cursor = Cursors.WaitCursor;
			ListViewItem lvItem;

			ManagementOperationObserver observer = new ManagementOperationObserver();
			HWD.Handler completionHandlerObj = new HWD.Handler();
			observer.ObjectReady += new ObjectReadyEventHandler(completionHandlerObj.Done);

			foreach (ManagementObject mo in Consulta("SELECT * FROM Win32_Service Where Name = '" + ServiceName + "'"))
			{
				mo.InvokeMethod(observer, ServiceAction, null);
			}
			
			int intCount = 0;
			while (!completionHandlerObj.IsComplete) 
			{ 
				if (intCount > 10)
				{
					MessageBox.Show("Terminate process timed out.", "Terminate Process Status");
					break;
				}
				System.Threading.Thread.Sleep(500); 

				intCount++;
			} 

			if (completionHandlerObj.ReturnObject.Properties["returnValue"].Value.ToString() == "0")
			{ 
				lvItem = ServiceItem;

				if (ServiceAction == "StartService")
					lvItem.SubItems[2].Text = "Started";
				else
					lvItem.SubItems[2].Text = "Stop";
			}
			else
			{
				string stringAction;

				if (ServiceAction == "StartService")
					stringAction = "start";
				else
					stringAction = "stop";

				MessageBox.Show("Failed to " + stringAction + " service " + ServiceName + ".", "Start/Stop Service Failure");
			}

			ServiceName = "";
			ServiceAction = "";
			ServiceItem = null;

			this.Update();
			this.Cursor = Cursors.Default;
		}

		private void button8_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			string [] sitems = new string[4];

			foreach(ManagementObject mo in Consulta("SELECT * FROM Win32_Share"))
			{
				sitems[0] = mo["Name"].ToString();
				switch(mo["Type"].ToString())
				{
					case "1":
						sitems[1] ="Disk";break;
					case "2":
						sitems[1] ="Print Queue";break;
					case "3":
						sitems[1] ="Device";break;
					case "4":
						sitems[1] ="IPC";break;
					case "2147483648":
						sitems[1] ="Disk Drive Admin";break;
					case "2147483649":
						sitems[1] ="Print Queue Admin";break;
					case "2147483650":
						sitems[1] ="Device Admin";break;
					case "2147483651":
						sitems[1] ="IPC Admin";break;


				}
				sitems[2] = mo["Path"].ToString();
				sitems[3] = mo["Description"].ToString();
				ListViewItem lvItem = new ListViewItem(sitems,6);
				this.listView1.Items.Add(lvItem);
			}
			this.button8.Enabled = false;
			this.Cursor = Cursors.Default;
		}

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
				{
					MessageBox.Show("ERROR");
				}
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
				{
					tmpS = new Socket(ipe.AddressFamily, SocketType.Stream, protocol);
				}
				else 
				{
					tmpS = new Socket(ipe.AddressFamily, SocketType.Dgram, protocol);
				}

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
			int icon = 7;
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
				icon = 8;
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

		private System.Management.ManagementObjectCollection Consulta(string strQuery)
		{
			try
			{
				if (this.anotherLogin && this.username.Length > 0)
				{
					co.Username = this.username;
					co.Password = this.password;
				}
				System.Management.ManagementScope ms = new System.Management.ManagementScope("\\\\" + this.insys + "\\root\\cimv2", co);
				oq = new System.Management.ObjectQuery(strQuery);
				query = new ManagementObjectSearcher(ms,oq);
				queryCollection = query.Get();
			}
			catch
			{
				queryCollection=null;
			}
			return queryCollection;
		}
		private void button9_Click(object sender, System.EventArgs e)
		{
			try 
			{
				string OS = string.Empty;
				this.Cursor = Cursors.WaitCursor;
				this.tempds.ReadXml("hwdhf.xml");
				this.tempds.Tables[0].Columns.Remove("ProductID");
				this.dviHotfix.Table = this.tempds.Tables[0];
				foreach( ManagementObject mo in Consulta("SELECT * FROM Win32_OperatingSystem"))
				{
					OS = mo["Caption"].ToString().Replace("Microsoft ", "");
				}
				this.dviHotfix.RowFilter = "Product like '%" + OS + "%'";
				foreach( ManagementObject mo in Consulta("SELECT * FROM Win32_QuickFixEngineering"))
				{
					string id = mo["HotFixID"].ToString();
					string desc = mo["Description"].ToString();
					if (id != "File 1")
					{
						int k = 0;
						foreach(DataRow dr in this.tempds.Tables[0].Rows)
						{
							string myid = dr["ID"].ToString();
							if (id.IndexOf(myid) > 0 || desc.IndexOf(myid) > 0 || dr["UrlPatch"].ToString().IndexOf(".exe") < 1) 
							{
								this.tempds.Tables[0].Rows[k].Delete();
								break;
							}
							k++;
						}
					}
				}
				this.dviHotfix.Table = this.tempds.Tables[0];
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.ToString());
			}
			this.button9.Enabled = false;
			this.Cursor = Cursors.Default;
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			Point pt = dataGrid2.PointToClient(rightMouseDownPoint); 

			try
			{
				HotFixInstaller hotInstall = new HotFixInstaller();
				hotInstall.computername = this.insys;
				hotInstall.url = dataGrid2[dataGrid2.HitTest(pt).Row, 4].ToString();
				if (this.anotherLogin)
				{
					hotInstall.anotherLogin = true;
					hotInstall.username = this.username;
					hotInstall.password = this.password;
				}
				hotInstall.Show();
			} 
			catch
			{
				MessageBox.Show(this,"Can't load HotFix Installer");
			}
		}

		private void dataGrid2_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			rightMouseDownPoint = Cursor.Position;
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			if (listView1.SelectedItems.Count <1)
				return;
			Process process = new Process();
			process.StartInfo.UseShellExecute = true;			
			process.StartInfo.FileName = "Explorer";
			process.StartInfo.Arguments = "\\\\" + this.insys + "\\" + listView1.SelectedItems[0].Text;			
			process.Start();
		}

		private void button11_Click_1(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			string [] sitems = new string[4];
			try 
			{
				foreach(ManagementObject mo in Consulta("SELECT * FROM Win32_NTLogEvent"))
				{
					sitems[0] = mo["Type"].ToString();
					sitems[1] = mo["EventCode"].ToString();
					sitems[2] = mo["SourceName"].ToString();
					sitems[3] = mo["Message"].ToString();
					sitems[3].Replace("\n\r", " ");
					ListViewItem lvItem = new ListViewItem(sitems,9);
					this.listView3.Items.Add(lvItem);
				}
			} 
			catch
			{
				this.Cursor = Cursors.Default;
			}
			this.button11.Enabled = false;
			this.Cursor = Cursors.Default;
		}

		private void button12_Click(object sender, System.EventArgs e)
		{
			ManagementOperationObserver observer = new ManagementOperationObserver(); 
			Handler completionHandlerObj = new Handler(); 
			observer.ObjectReady += new ObjectReadyEventHandler(completionHandlerObj.Done);

			this.Cursor = Cursors.WaitCursor;
			string [] sitems = new string[3];
			try 
			{
				foreach(ManagementObject mo in Consulta("SELECT * FROM Win32_Process"))
				{
					sitems[0] = mo["ProcessID"].ToString();
					sitems[1] = mo["Name"].ToString();
					mo.InvokeMethod(observer,"GetOwner", null);
			
					while (!completionHandlerObj.IsComplete) 
					{ 
						System.Threading.Thread.Sleep(500); 
					} 

					if (completionHandlerObj.ReturnObject["returnValue"].ToString() == "0")
					{
						sitems[2] = completionHandlerObj.ReturnObject.Properties["User"].Value.ToString();
					}
					else
					{ 
						sitems[2] = "-";
					}
					ListViewItem lvItem = new ListViewItem(sitems,0);
					this.lstPro.Items.Add(lvItem);
				}
			} 
			catch
			{
				this.Cursor = Cursors.Default;
			}
			this.button12.Enabled = false;
			this.Cursor = Cursors.Default;
		}

		private void lstPro_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			System.Windows.Forms.ListView listViewObject = (System.Windows.Forms.ListView) sender;
			ContextMenu mnuContextMenu = new ContextMenu();
			MenuItem menuItem;

			if (e.Button == System.Windows.Forms.MouseButtons.Right) 
			{
				ProcessItem = listViewObject.GetItemAt(e.X,e.Y);
				this.lstPro.ContextMenu = mnuContextMenu;

				try
				{
					ProcessID = ProcessItem.SubItems[0].Text;

					menuItem = new MenuItem();
					menuItem.Text = "Terminate Process";
					mnuContextMenu.MenuItems.Add(menuItem);
					menuItem.Click  += new System.EventHandler(this.menuItemTerminate_Click);
				}
				catch
				{
					
				}
			}
		}

		private void menuItemTerminate_Click(object sender, System.EventArgs e)
		{   
			ListViewItem lvItem;

			ManagementOperationObserver observer = new ManagementOperationObserver(); 
			Handler completionHandlerObj = new Handler(); 
			observer.ObjectReady  += new ObjectReadyEventHandler(completionHandlerObj.Done);
			
			foreach (ManagementObject mo in Consulta("Select * from Win32_Process Where ProcessID = '" + ProcessID + "'"))
			{
				mo.InvokeMethod(observer, "Terminate", null);
			}
			
			int intCount = 0;
			while (!completionHandlerObj.IsComplete) 
			{ 
				if (intCount == 10)
				{
					MessageBox.Show("Terminate process timed out.", "Terminate Process Status");
					break;
				}
				System.Threading.Thread.Sleep(500); 
				intCount++;
			} 

			if (intCount != 10)
			{
				if (completionHandlerObj.ReturnObject.Properties["returnValue"].Value.ToString() == "0")
				{ 
					lvItem = ProcessItem;
					lvItem.Remove();
				}
				else
				{
					MessageBox.Show("Error terminating process.", "Terminate Process");
				}
			}
			ProcessID = "";
			ProcessItem = null;
			this.Update();
		}

		private void button13_Click(object sender, System.EventArgs e)
		{
			ManagementOperationObserver observer = new ManagementOperationObserver(); 
			Handler completionHandlerObj = new Handler(); 
			observer.ObjectReady  += new ObjectReadyEventHandler(completionHandlerObj.Done);
			if (this.anotherLogin && this.username.Length > 0)
			{
				co.Username = this.username;
				co.Password = this.password;
			}
			System.Management.ManagementScope ms = new System.Management.ManagementScope("\\\\" + this.insys + "\\root\\cimv2", co);

			ManagementPath path = new ManagementPath( "Win32_Process");
			ManagementClass processClass = new ManagementClass(ms,path,null);

			object[] methodArgs = {this.textBox1.Text, null, null, 0};

			processClass.InvokeMethod (observer, "Create", methodArgs);

			int intCount = 0;
			while (!completionHandlerObj.IsComplete) 
			{ 
				if (intCount > 10)
				{
					MessageBox.Show("Create process timed out.", "Terminate Process Status");
					break;
				}
				System.Threading.Thread.Sleep(500); 
				intCount++;
			} 

			if (intCount != 10)
			{
				if (completionHandlerObj.ReturnObject.Properties["returnValue"].Value.ToString() == "0")
				{
					this.Refresh();
				}
				else
				{
					MessageBox.Show("Error creating new process.", "Create New Process");
				}
			}
			this.Update();
		}

		private void tabControl2_SelectionChanged(Crownwood.DotNetMagic.Controls.TabControl sender, Crownwood.DotNetMagic.Controls.TabPage oldPage, Crownwood.DotNetMagic.Controls.TabPage newPage)
		{
		
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}
	}

	public class Handler
	{
		private bool isComplete = false;
		private ManagementBaseObject returnObject;
             
		public void Done(object sender, ObjectReadyEventArgs e)
		{ 
			isComplete = true;
			returnObject = e.NewObject;
		}


		public bool IsComplete 
		{
			get 
			{
				return isComplete;
			}
		}

		public ManagementBaseObject ReturnObject 
		{
			get 
			{
				return returnObject;
			}
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
