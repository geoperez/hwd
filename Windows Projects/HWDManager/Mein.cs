using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Management;
using System.Globalization;
using System.Xml;
using System.Threading;
using System.IO;
using System.Resources;
using System.Diagnostics;

namespace HWD
{   
	#region Delegates

	public delegate void GetInfoDelegate(string machine, bool starting);
    public delegate void addRowDelegate(DataRow r);
    public delegate void addErrorDelegate(string msg);

	#endregion

	public class Mein : System.Windows.Forms.Form
	{
		#region Objects
		internal System.Data.SqlClient.SqlConnection sqlConnection1;
		private ListViewItem tItem;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private Point rightMouseDownPoint;
		private System.Windows.Forms.SaveFileDialog saveXML;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Data.DataView dviSystems;
		private ReportPrinting.ReportDocument reportDocument1;
		private System.Data.DataTable AccessDataTypes;
		private System.ComponentModel.IContainer components;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand3;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand3;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand3;
		private HWD.userData userData1;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand4;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand4;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand4;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		private System.Data.DataView dviTemp;
        private Thread th;
        private bool terminaThread;
		private System.Timers.Timer timer1;
		private System.Xml.XmlDocument xmldoc = new XmlDocument();
		private bool hotfixfile = false;
		private ManagementObjectSearcher query;
		private ManagementObjectCollection queryCollection;
		private System.Management.ObjectQuery oq;
		private ConnectionOptions co = new ConnectionOptions();
		private HWD.splash fsplash;
		private NumberFormatInfo myNfi = new NumberFormatInfo();
		private System.Windows.Forms.MenuItem mnRemote;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem mnMan;
		private Crownwood.DotNetMagic.Controls.StatusBarControl statusBarControl1;
		private Crownwood.DotNetMagic.Controls.StatusPanel statusPanel1;
		private Crownwood.DotNetMagic.Controls.StatusPanel statusPanel2;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar13;
		private Crownwood.DotNetMagic.Controls.TabControl tabControl2;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage1;
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar11;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button3;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button1;
		private System.Windows.Forms.Label lblPass;
		private System.Windows.Forms.Label lblUser;
		private System.Windows.Forms.TextBox txtPass;
		private System.Windows.Forms.TextBox txtUser;
		private System.Windows.Forms.CheckBox chkLogin;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage4;
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar10;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button8;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button7;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtFilter;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cboField;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cboOperator;
		private System.Windows.Forms.Label label4;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage3;
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar8;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button6;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button11;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button10;
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar9;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage2;
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar7;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button5;
		private System.Windows.Forms.ListBox listBox1;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage5;
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar5;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button12;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button9;
		private System.Windows.Forms.CheckBox chkXML;
		private System.Windows.Forms.RadioButton radioSpanish;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.RadioButton radioEnglish;
		private System.Windows.Forms.TextBox txthotdate;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox chkAutoSave;
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar6;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage6;
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar4;
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar3;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Label label5;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage7;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle buttonWithStyle3;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle buttonWithStyle4;
		private System.Windows.Forms.TextBox textBox3;
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar2;
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar1;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle buttonWithStyle2;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle buttonWithStyle1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.DataGridBoolColumn dataGridStatusColumn;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private HWD.DataGridComboBoxColumn dataColumLocation;
		private HWD.DataGridComboBoxColumn dataColumKind;
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar12;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button2;
		private System.Windows.Forms.ListBox listBox2;
		private System.Windows.Forms.ListBox listBox3;
		private string dataSys;
		private bool doScanOnLoad;
		private string sysscanOnLoad;
		private string sysscan;
		private ResourceManager m_ResourceManager = new ResourceManager("HWD.Localization", System.Reflection.Assembly.GetExecutingAssembly());
		private CultureInfo m_EnglishCulture = new CultureInfo("en-US");
		private System.Windows.Forms.ToolTip toolTip1;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage8;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle buttonWithStyle5;
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar14;
		private Crownwood.DotNetMagic.Controls.TabControl tabControl1;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage9;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage10;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar15;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle buttonWithStyle6;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem6;
		private CultureInfo m_SpanishCulture = new CultureInfo("es-MX");
		#endregion

		#region Mein Class
		public Mein(System.Data.SqlClient.SqlConnection sqlConn, string type, string systems)
		{	
			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.Hide();
			this.fsplash = new splash();
			this.fsplash.Show();
			if (type == "sql") 
			{
				this.sqlConnection1	= sqlConn;
				this.dataSys = "sql";
			} 
			else 
			{
				this.dataSys = "xml";
			}
			if (systems.Length >  0) 
			{
				doScanOnLoad = true;
				sysscanOnLoad = systems;
			}
			this.xmldoc.Load(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\HWD\\config.xml");
			InitializeComponent();
			if (this.xmldoc.FirstChild["Language"].InnerText == "es-MX")
			{
				Thread.CurrentThread.CurrentUICulture = m_SpanishCulture;
				this.radioSpanish.Checked = true;
			} 
			else 
			{
				Thread.CurrentThread.CurrentUICulture = m_EnglishCulture;
			}
			this.UpdateUI();
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
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Mein));
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.mnRemote = new System.Windows.Forms.MenuItem();
			this.mnMan = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.dviSystems = new System.Data.DataView();
			this.userData1 = new HWD.userData();
			this.AccessDataTypes = new System.Data.DataTable();
			this.saveXML = new System.Windows.Forms.SaveFileDialog();
			this.reportDocument1 = new ReportPrinting.ReportDocument();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.dviTemp = new System.Data.DataView();
			this.timer1 = new System.Timers.Timer();
			this.statusBarControl1 = new Crownwood.DotNetMagic.Controls.StatusBarControl();
			this.statusPanel1 = new Crownwood.DotNetMagic.Controls.StatusPanel();
			this.statusPanel2 = new Crownwood.DotNetMagic.Controls.StatusPanel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.tabControl1 = new Crownwood.DotNetMagic.Controls.TabControl();
			this.tabPage10 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.tabPage9 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridStatusColumn = new System.Windows.Forms.DataGridBoolColumn();
			this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataColumLocation = new HWD.DataGridComboBoxColumn();
			this.dataColumKind = new HWD.DataGridComboBoxColumn();
			this.titleBar13 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.tabControl2 = new Crownwood.DotNetMagic.Controls.TabControl();
			this.tabPage1 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.titleBar11 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.button3 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.button1 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.lblPass = new System.Windows.Forms.Label();
			this.lblUser = new System.Windows.Forms.Label();
			this.txtPass = new System.Windows.Forms.TextBox();
			this.txtUser = new System.Windows.Forms.TextBox();
			this.chkLogin = new System.Windows.Forms.CheckBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPage4 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.titleBar10 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.button8 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.button7 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtFilter = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cboField = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cboOperator = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tabPage3 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.titleBar8 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.button6 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.button11 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.button10 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.titleBar9 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.tabPage8 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.buttonWithStyle6 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.titleBar15 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.buttonWithStyle5 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.titleBar14 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.tabPage7 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.listBox3 = new System.Windows.Forms.ListBox();
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.titleBar12 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.button2 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.buttonWithStyle3 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.buttonWithStyle4 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.titleBar2 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.titleBar1 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.buttonWithStyle2 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.buttonWithStyle1 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.tabPage2 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.titleBar7 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.button5 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.tabPage5 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.titleBar5 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.button12 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.button9 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.chkXML = new System.Windows.Forms.CheckBox();
			this.radioSpanish = new System.Windows.Forms.RadioButton();
			this.label7 = new System.Windows.Forms.Label();
			this.radioEnglish = new System.Windows.Forms.RadioButton();
			this.txthotdate = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.chkAutoSave = new System.Windows.Forms.CheckBox();
			this.titleBar6 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.tabPage6 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.titleBar4 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.titleBar3 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.label5 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.dviSystems)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.userData1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.AccessDataTypes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dviTemp)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.timer1)).BeginInit();
			this.panel2.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage10.SuspendLayout();
			this.tabPage9.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.tabControl2.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage8.SuspendLayout();
			this.tabPage7.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem1,
																						 this.menuItem6,
																						 this.menuItem4,
																						 this.menuItem2,
																						 this.mnRemote,
																						 this.mnMan,
																						 this.menuItem5,
																						 this.menuItem3});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "&Details...";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 1;
			this.menuItem6.Text = "-";
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Text = "&Install CWD...";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 3;
			this.menuItem2.Text = "-";
			// 
			// mnRemote
			// 
			this.mnRemote.Index = 4;
			this.mnRemote.Text = "&Remote Desktop";
			this.mnRemote.Click += new System.EventHandler(this.mnRemote_Click);
			// 
			// mnMan
			// 
			this.mnMan.Index = 5;
			this.mnMan.Text = "Computer &Manager";
			this.mnMan.Click += new System.EventHandler(this.mnMan_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 6;
			this.menuItem5.Text = "-";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 7;
			this.menuItem3.Text = "&Delete";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// dviSystems
			// 
			this.dviSystems.Sort = "ComputerName";
			this.dviSystems.Table = this.userData1.HWD;
			// 
			// userData1
			// 
			this.userData1.DataSetName = "userData";
			this.userData1.Locale = new System.Globalization.CultureInfo("es-MX");
			// 
			// saveXML
			// 
			this.saveXML.DefaultExt = "xml";
			this.saveXML.FileName = "report";
			this.saveXML.Filter = "XML Files|*.xml";
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
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.DeleteCommand = this.sqlDeleteCommand3;
			this.sqlDataAdapter3.InsertCommand = this.sqlInsertCommand3;
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "LWD", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("IDLocation", "IDLocation"),
																																																			 new System.Data.Common.DataColumnMapping("LocationName", "LocationName")})});
			this.sqlDataAdapter3.UpdateCommand = this.sqlUpdateCommand3;
			// 
			// sqlDeleteCommand3
			// 
			this.sqlDeleteCommand3.CommandText = "DELETE FROM HWD_LOCATIONS WHERE (IDLocation = @Original_IDLocation) AND (Location" +
				"Name = @Original_LocationName OR @Original_LocationName IS NULL AND LocationName" +
				" IS NULL)";
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IDLocation", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IDLocation", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LocationName", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LocationName", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand3
			// 
			this.sqlInsertCommand3.CommandText = "INSERT INTO HWD_LOCATIONS(LocationName) VALUES (@LocationName); SELECT IDLocation" +
				", LocationName FROM HWD_LOCATIONS WHERE (IDLocation = @@IDENTITY)";
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LocationName", System.Data.SqlDbType.NVarChar, 20, "LocationName"));
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT IDLocation, LocationName FROM HWD_LOCATIONS";
			// 
			// sqlUpdateCommand3
			// 
			this.sqlUpdateCommand3.CommandText = @"UPDATE HWD_LOCATIONS SET LocationName = @LocationName WHERE (IDLocation = @Original_IDLocation) AND (LocationName = @Original_LocationName OR @Original_LocationName IS NULL AND LocationName IS NULL); SELECT IDLocation, LocationName FROM HWD_LOCATIONS WHERE (IDLocation = @IDLocation)";
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LocationName", System.Data.SqlDbType.NVarChar, 20, "LocationName"));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IDLocation", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IDLocation", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LocationName", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LocationName", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IDLocation", System.Data.SqlDbType.Int, 4, "IDLocation"));
			// 
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.DeleteCommand = this.sqlDeleteCommand4;
			this.sqlDataAdapter4.InsertCommand = this.sqlInsertCommand4;
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "KINDS", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("IDKind", "IDKind"),
																																																			   new System.Data.Common.DataColumnMapping("KindName", "KindName")})});
			this.sqlDataAdapter4.UpdateCommand = this.sqlUpdateCommand4;
			// 
			// sqlDeleteCommand4
			// 
			this.sqlDeleteCommand4.CommandText = "DELETE FROM HWD_KINDS WHERE (IDKind = @Original_IDKind) AND (KindName = @Original" +
				"_KindName OR @Original_KindName IS NULL AND KindName IS NULL)";
			this.sqlDeleteCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IDKind", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IDKind", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_KindName", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "KindName", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand4
			// 
			this.sqlInsertCommand4.CommandText = "INSERT INTO HWD_KINDS(KindName) VALUES (@KindName); SELECT IDKind, KindName FROM " +
				"HWD_KINDS WHERE (IDKind = @@IDENTITY)";
			this.sqlInsertCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@KindName", System.Data.SqlDbType.VarChar, 10, "KindName"));
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "SELECT IDKind, KindName FROM HWD_KINDS";
			// 
			// sqlUpdateCommand4
			// 
			this.sqlUpdateCommand4.CommandText = "UPDATE HWD_KINDS SET KindName = @KindName WHERE (IDKind = @Original_IDKind) AND (" +
				"KindName = @Original_KindName OR @Original_KindName IS NULL AND KindName IS NULL" +
				"); SELECT IDKind, KindName FROM HWD_KINDS WHERE (IDKind = @IDKind)";
			this.sqlUpdateCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@KindName", System.Data.SqlDbType.VarChar, 10, "KindName"));
			this.sqlUpdateCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IDKind", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IDKind", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_KindName", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "KindName", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IDKind", System.Data.SqlDbType.Int, 4, "IDKind"));
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "HWD", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("ID", "ID"),
																																																			 new System.Data.Common.DataColumnMapping("ComputerName", "ComputerName"),
																																																			 new System.Data.Common.DataColumnMapping("OS", "OS"),
																																																			 new System.Data.Common.DataColumnMapping("Username", "Username"),
																																																			 new System.Data.Common.DataColumnMapping("Manufacturer", "Manufacturer"),
																																																			 new System.Data.Common.DataColumnMapping("Model", "Model"),
																																																			 new System.Data.Common.DataColumnMapping("SerialNumber", "SerialNumber"),
																																																			 new System.Data.Common.DataColumnMapping("RAM", "RAM"),
																																																			 new System.Data.Common.DataColumnMapping("Processor", "Processor"),
																																																			 new System.Data.Common.DataColumnMapping("IDKind", "IDKind"),
																																																			 new System.Data.Common.DataColumnMapping("IDLocation", "IDLocation"),
																																																			 new System.Data.Common.DataColumnMapping("Status", "Status"),
																																																			 new System.Data.Common.DataColumnMapping("Notes", "Notes")})});
			this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = @"DELETE FROM HWD_SYSTEMS WHERE (ComputerName = @Original_ComputerName) AND (ID = @Original_ID) AND (IDKind = @Original_IDKind OR @Original_IDKind IS NULL AND IDKind IS NULL) AND (IDLocation = @Original_IDLocation OR @Original_IDLocation IS NULL AND IDLocation IS NULL) AND (Manufacturer = @Original_Manufacturer OR @Original_Manufacturer IS NULL AND Manufacturer IS NULL) AND (Model = @Original_Model OR @Original_Model IS NULL AND Model IS NULL) AND (Notes = @Original_Notes OR @Original_Notes IS NULL AND Notes IS NULL) AND (OS = @Original_OS OR @Original_OS IS NULL AND OS IS NULL) AND (Processor = @Original_Processor OR @Original_Processor IS NULL AND Processor IS NULL) AND (RAM = @Original_RAM OR @Original_RAM IS NULL AND RAM IS NULL) AND (SerialNumber = @Original_SerialNumber OR @Original_SerialNumber IS NULL AND SerialNumber IS NULL) AND (Status = @Original_Status OR @Original_Status IS NULL AND Status IS NULL) AND (Username = @Original_Username OR @Original_Username IS NULL AND Username IS NULL)";
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ComputerName", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ComputerName", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ID", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IDKind", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IDKind", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IDLocation", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IDLocation", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Manufacturer", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Manufacturer", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Model", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Model", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Notes", System.Data.SqlDbType.NVarChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Notes", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_OS", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OS", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Processor", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Processor", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RAM", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RAM", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SerialNumber", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SerialNumber", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Status", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Status", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Username", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Username", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = @"INSERT INTO HWD_SYSTEMS(ComputerName, OS, Username, Manufacturer, Model, SerialNumber, RAM, Processor, IDKind, IDLocation, Status, Notes) VALUES (@ComputerName, @OS, @Username, @Manufacturer, @Model, @SerialNumber, @RAM, @Processor, @IDKind, @IDLocation, @Status, @Notes); SELECT ID, ComputerName, OS, Username, Manufacturer, Model, SerialNumber, RAM, Processor, IDKind, IDLocation, Status, Notes FROM HWD WHERE (ComputerName = @ComputerName)";
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ComputerName", System.Data.SqlDbType.NVarChar, 50, "ComputerName"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OS", System.Data.SqlDbType.NVarChar, 50, "OS"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Username", System.Data.SqlDbType.NVarChar, 30, "Username"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Manufacturer", System.Data.SqlDbType.NVarChar, 20, "Manufacturer"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Model", System.Data.SqlDbType.NVarChar, 30, "Model"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SerialNumber", System.Data.SqlDbType.NVarChar, 20, "SerialNumber"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RAM", System.Data.SqlDbType.NVarChar, 20, "RAM"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Processor", System.Data.SqlDbType.NVarChar, 50, "Processor"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IDKind", System.Data.SqlDbType.Int, 4, "IDKind"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IDLocation", System.Data.SqlDbType.Int, 4, "IDLocation"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Status", System.Data.SqlDbType.Bit, 1, "Status"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Notes", System.Data.SqlDbType.NVarChar, 255, "Notes"));
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT ID, ComputerName, OS, Username, Manufacturer, Model, SerialNumber, RAM, Pr" +
				"ocessor, IDKind, IDLocation, Status, Notes FROM HWD_SYSTEMS";
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE HWD_SYSTEMS SET ComputerName = @ComputerName, OS = @OS, Username = @Username, Manufacturer = @Manufacturer, Model = @Model, SerialNumber = @SerialNumber, RAM = @RAM, Processor = @Processor, IDKind = @IDKind, IDLocation = @IDLocation, Status = @Status, Notes = @Notes WHERE (ComputerName = @Original_ComputerName) AND (IDKind = @Original_IDKind OR @Original_IDKind IS NULL AND IDKind IS NULL) AND (IDLocation = @Original_IDLocation OR @Original_IDLocation IS NULL AND IDLocation IS NULL) AND (Manufacturer = @Original_Manufacturer OR @Original_Manufacturer IS NULL AND Manufacturer IS NULL) AND (Model = @Original_Model OR @Original_Model IS NULL AND Model IS NULL) AND (Notes = @Original_Notes OR @Original_Notes IS NULL AND Notes IS NULL) AND (OS = @Original_OS OR @Original_OS IS NULL AND OS IS NULL) AND (Processor = @Original_Processor OR @Original_Processor IS NULL AND Processor IS NULL) AND (RAM = @Original_RAM OR @Original_RAM IS NULL AND RAM IS NULL) AND (SerialNumber = @Original_SerialNumber OR @Original_SerialNumber IS NULL AND SerialNumber IS NULL) AND (Status = @Original_Status OR @Original_Status IS NULL AND Status IS NULL) AND (Username = @Original_Username OR @Original_Username IS NULL AND Username IS NULL); SELECT ID, ComputerName, OS, Username, Manufacturer, Model, SerialNumber, RAM, Processor, IDKind, IDLocation, Status, Notes FROM HWD WHERE (ComputerName = @ComputerName)";
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ComputerName", System.Data.SqlDbType.NVarChar, 50, "ComputerName"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OS", System.Data.SqlDbType.NVarChar, 50, "OS"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Username", System.Data.SqlDbType.NVarChar, 30, "Username"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Manufacturer", System.Data.SqlDbType.NVarChar, 20, "Manufacturer"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Model", System.Data.SqlDbType.NVarChar, 30, "Model"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SerialNumber", System.Data.SqlDbType.NVarChar, 20, "SerialNumber"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RAM", System.Data.SqlDbType.NVarChar, 20, "RAM"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Processor", System.Data.SqlDbType.NVarChar, 50, "Processor"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IDKind", System.Data.SqlDbType.Int, 4, "IDKind"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IDLocation", System.Data.SqlDbType.Int, 4, "IDLocation"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Status", System.Data.SqlDbType.Bit, 1, "Status"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Notes", System.Data.SqlDbType.NVarChar, 255, "Notes"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ComputerName", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ComputerName", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IDKind", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IDKind", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IDLocation", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IDLocation", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Manufacturer", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Manufacturer", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Model", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Model", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Notes", System.Data.SqlDbType.NVarChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Notes", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_OS", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OS", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Processor", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Processor", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RAM", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RAM", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SerialNumber", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SerialNumber", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Status", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Status", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Username", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Username", System.Data.DataRowVersion.Original, null));
			// 
			// timer1
			// 
			this.timer1.Interval = 300000;
			this.timer1.SynchronizingObject = this;
			this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Elapsed);
			// 
			// statusBarControl1
			// 
			this.statusBarControl1.AccessibleRole = System.Windows.Forms.AccessibleRole.StatusBar;
			this.statusBarControl1.Location = new System.Drawing.Point(0, 506);
			this.statusBarControl1.Name = "statusBarControl1";
			this.statusBarControl1.Office2003GradBack = true;
			this.statusBarControl1.Size = new System.Drawing.Size(852, 24);
			this.statusBarControl1.StatusPanels.AddRange(new Crownwood.DotNetMagic.Controls.StatusPanel[] {
																											  this.statusPanel1,
																											  this.statusPanel2});
			this.statusBarControl1.TabIndex = 11;
			// 
			// statusPanel1
			// 
			this.statusPanel1.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.statusPanel1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.statusPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusPanel1.Location = new System.Drawing.Point(2, 2);
			this.statusPanel1.Name = "statusPanel1";
			this.statusPanel1.Size = new System.Drawing.Size(412, 18);
			this.statusPanel1.TabIndex = 0;
			this.statusPanel1.Text = "Ready";
			// 
			// statusPanel2
			// 
			this.statusPanel2.Alignment = System.Drawing.StringAlignment.Far;
			this.statusPanel2.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.statusPanel2.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.statusPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusPanel2.Location = new System.Drawing.Point(2, 2);
			this.statusPanel2.Name = "statusPanel2";
			this.statusPanel2.Size = new System.Drawing.Size(412, 18);
			this.statusPanel2.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.Controls.Add(this.comboBox1);
			this.panel2.Controls.Add(this.tabControl1);
			this.panel2.Controls.Add(this.titleBar13);
			this.panel2.Location = new System.Drawing.Point(0, 120);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(852, 384);
			this.panel2.TabIndex = 11;
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Items.AddRange(new object[] {
														   "Large Icons",
														   "List",
														   "Details"});
			this.comboBox1.Location = new System.Drawing.Point(752, 6);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(88, 21);
			this.comboBox1.TabIndex = 12;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// tabControl1
			// 
			this.tabControl1.Appearance = Crownwood.DotNetMagic.Controls.VisualAppearance.MultiBox;
			this.tabControl1.BackColor = System.Drawing.SystemColors.Control;
			this.tabControl1.ButtonActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.tabControl1.ButtonInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tabControl1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.tabControl1.HotTextColor = System.Drawing.SystemColors.ActiveCaption;
			this.tabControl1.ImageList = null;
			this.tabControl1.Location = new System.Drawing.Point(0, 32);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.OfficeDockSides = false;
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(852, 340);
			this.tabControl1.TabIndex = 11;
			this.tabControl1.TabPages.AddRange(new Crownwood.DotNetMagic.Controls.TabPage[] {
																								this.tabPage10,
																								this.tabPage9});
			this.tabControl1.TextColor = System.Drawing.SystemColors.ControlText;
			this.tabControl1.TextInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.tabControl1.TextTips = true;
			// 
			// tabPage10
			// 
			this.tabPage10.Controls.Add(this.listView1);
			this.tabPage10.InactiveBackColor = System.Drawing.Color.Empty;
			this.tabPage10.InactiveTextBackColor = System.Drawing.Color.Empty;
			this.tabPage10.InactiveTextColor = System.Drawing.Color.Empty;
			this.tabPage10.Location = new System.Drawing.Point(1, 1);
			this.tabPage10.Name = "tabPage10";
			this.tabPage10.SelectBackColor = System.Drawing.Color.Empty;
			this.tabPage10.SelectTextBackColor = System.Drawing.Color.Empty;
			this.tabPage10.SelectTextColor = System.Drawing.Color.Empty;
			this.tabPage10.Size = new System.Drawing.Size(850, 309);
			this.tabPage10.TabIndex = 4;
			this.tabPage10.Title = "Explorer-Style";
			this.tabPage10.ToolTip = "Page";
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1,
																						this.columnHeader2,
																						this.columnHeader3,
																						this.columnHeader4,
																						this.columnHeader5});
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.listView1.FullRowSelect = true;
			this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView1.HideSelection = false;
			this.listView1.LargeImageList = this.imageList1;
			this.listView1.Location = new System.Drawing.Point(0, 0);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(850, 309);
			this.listView1.SmallImageList = this.imageList1;
			this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.listView1.TabIndex = 2;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Computer Name";
			this.columnHeader1.Width = 134;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Model";
			this.columnHeader2.Width = 169;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Manufacturer";
			this.columnHeader3.Width = 154;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Serial Number";
			this.columnHeader4.Width = 122;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "OS";
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// tabPage9
			// 
			this.tabPage9.Controls.Add(this.dataGrid1);
			this.tabPage9.InactiveBackColor = System.Drawing.Color.Empty;
			this.tabPage9.InactiveTextBackColor = System.Drawing.Color.Empty;
			this.tabPage9.InactiveTextColor = System.Drawing.Color.Empty;
			this.tabPage9.Location = new System.Drawing.Point(1, 1);
			this.tabPage9.Name = "tabPage9";
			this.tabPage9.SelectBackColor = System.Drawing.Color.Empty;
			this.tabPage9.Selected = false;
			this.tabPage9.SelectTextBackColor = System.Drawing.Color.Empty;
			this.tabPage9.SelectTextColor = System.Drawing.Color.Empty;
			this.tabPage9.Size = new System.Drawing.Size(850, 309);
			this.tabPage9.TabIndex = 3;
			this.tabPage9.Title = "Table";
			this.tabPage9.ToolTip = "Page";
			// 
			// dataGrid1
			// 
			this.dataGrid1.AlternatingBackColor = System.Drawing.Color.LightGray;
			this.dataGrid1.BackColor = System.Drawing.Color.Gainsboro;
			this.dataGrid1.BackgroundColor = System.Drawing.Color.Silver;
			this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid1.CaptionBackColor = System.Drawing.Color.LightSteelBlue;
			this.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.CaptionText = "Hardware Info";
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.ContextMenu = this.contextMenu1;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.DataSource = this.dviSystems;
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid1.FlatMode = true;
			this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8F);
			this.dataGrid1.ForeColor = System.Drawing.Color.Black;
			this.dataGrid1.GridLineColor = System.Drawing.Color.DimGray;
			this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
			this.dataGrid1.HeaderBackColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.dataGrid1.HeaderForeColor = System.Drawing.Color.White;
			this.dataGrid1.LinkColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.Location = new System.Drawing.Point(0, 0);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.DarkGray;
			this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.Black;
			this.dataGrid1.PreferredColumnWidth = 85;
			this.dataGrid1.SelectionBackColor = System.Drawing.Color.SteelBlue;
			this.dataGrid1.SelectionForeColor = System.Drawing.Color.White;
			this.dataGrid1.Size = new System.Drawing.Size(850, 309);
			this.dataGrid1.TabIndex = 0;
			this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle2});
			this.dataGrid1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGrid1_MouseDown);
			this.dataGrid1.DoubleClick += new System.EventHandler(this.menuItem1_Click);
			// 
			// dataGridTableStyle2
			// 
			this.dataGridTableStyle2.AlternatingBackColor = System.Drawing.Color.LightGray;
			this.dataGridTableStyle2.BackColor = System.Drawing.Color.Gainsboro;
			this.dataGridTableStyle2.DataGrid = this.dataGrid1;
			this.dataGridTableStyle2.ForeColor = System.Drawing.Color.Black;
			this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn6,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn3,
																												  this.dataGridTextBoxColumn4,
																												  this.dataGridTextBoxColumn5,
																												  this.dataGridTextBoxColumn7,
																												  this.dataGridTextBoxColumn8,
																												  this.dataGridTextBoxColumn9,
																												  this.dataGridStatusColumn,
																												  this.dataGridTextBoxColumn12,
																												  this.dataColumLocation,
																												  this.dataColumKind});
			this.dataGridTableStyle2.GridLineColor = System.Drawing.Color.DimGray;
			this.dataGridTableStyle2.HeaderBackColor = System.Drawing.Color.MidnightBlue;
			this.dataGridTableStyle2.HeaderForeColor = System.Drawing.Color.White;
			this.dataGridTableStyle2.LinkColor = System.Drawing.Color.MidnightBlue;
			this.dataGridTableStyle2.MappingName = "";
			this.dataGridTableStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
			this.dataGridTableStyle2.SelectionForeColor = System.Drawing.Color.White;
			// 
			// dataGridTextBoxColumn6
			// 
			this.dataGridTextBoxColumn6.Format = "";
			this.dataGridTextBoxColumn6.FormatInfo = null;
			this.dataGridTextBoxColumn6.HeaderText = "ID";
			this.dataGridTextBoxColumn6.MappingName = "ID";
			this.dataGridTextBoxColumn6.ReadOnly = true;
			this.dataGridTextBoxColumn6.Width = 20;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "User";
			this.dataGridTextBoxColumn2.MappingName = "Username";
			this.dataGridTextBoxColumn2.Width = 75;
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "Computer Name";
			this.dataGridTextBoxColumn1.MappingName = "ComputerName";
			this.dataGridTextBoxColumn1.Width = 75;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "OS";
			this.dataGridTextBoxColumn3.MappingName = "OS";
			this.dataGridTextBoxColumn3.Width = 75;
			// 
			// dataGridTextBoxColumn4
			// 
			this.dataGridTextBoxColumn4.Format = "";
			this.dataGridTextBoxColumn4.FormatInfo = null;
			this.dataGridTextBoxColumn4.HeaderText = "Manufacturer";
			this.dataGridTextBoxColumn4.MappingName = "Manufacturer";
			this.dataGridTextBoxColumn4.Width = 75;
			// 
			// dataGridTextBoxColumn5
			// 
			this.dataGridTextBoxColumn5.Format = "";
			this.dataGridTextBoxColumn5.FormatInfo = null;
			this.dataGridTextBoxColumn5.HeaderText = "Model";
			this.dataGridTextBoxColumn5.MappingName = "Model";
			this.dataGridTextBoxColumn5.Width = 75;
			// 
			// dataGridTextBoxColumn7
			// 
			this.dataGridTextBoxColumn7.Format = "";
			this.dataGridTextBoxColumn7.FormatInfo = null;
			this.dataGridTextBoxColumn7.HeaderText = "Serial Number";
			this.dataGridTextBoxColumn7.MappingName = "SerialNumber";
			this.dataGridTextBoxColumn7.Width = 75;
			// 
			// dataGridTextBoxColumn8
			// 
			this.dataGridTextBoxColumn8.Format = "";
			this.dataGridTextBoxColumn8.FormatInfo = null;
			this.dataGridTextBoxColumn8.HeaderText = "RAM";
			this.dataGridTextBoxColumn8.MappingName = "RAM";
			this.dataGridTextBoxColumn8.Width = 75;
			// 
			// dataGridTextBoxColumn9
			// 
			this.dataGridTextBoxColumn9.Format = "";
			this.dataGridTextBoxColumn9.FormatInfo = null;
			this.dataGridTextBoxColumn9.HeaderText = "Processor";
			this.dataGridTextBoxColumn9.MappingName = "Processor";
			this.dataGridTextBoxColumn9.Width = 75;
			// 
			// dataGridStatusColumn
			// 
			this.dataGridStatusColumn.AllowNull = false;
			this.dataGridStatusColumn.FalseValue = false;
			this.dataGridStatusColumn.HeaderText = "Status";
			this.dataGridStatusColumn.MappingName = "Status";
			this.dataGridStatusColumn.NullValue = ((object)(resources.GetObject("dataGridStatusColumn.NullValue")));
			this.dataGridStatusColumn.TrueValue = true;
			this.dataGridStatusColumn.Width = 75;
			// 
			// dataGridTextBoxColumn12
			// 
			this.dataGridTextBoxColumn12.Format = "";
			this.dataGridTextBoxColumn12.FormatInfo = null;
			this.dataGridTextBoxColumn12.HeaderText = "Notes";
			this.dataGridTextBoxColumn12.MappingName = "Notes";
			this.dataGridTextBoxColumn12.Width = 75;
			// 
			// dataColumLocation
			// 
			this.dataColumLocation.Format = "";
			this.dataColumLocation.FormatInfo = null;
			this.dataColumLocation.HeaderText = "Location";
			this.dataColumLocation.MappingName = "IDLocation";
			this.dataColumLocation.Width = 75;
			// 
			// dataColumKind
			// 
			this.dataColumKind.Format = "";
			this.dataColumKind.FormatInfo = null;
			this.dataColumKind.HeaderText = "Kind";
			this.dataColumKind.MappingName = "IDKind";
			this.dataColumKind.Width = 75;
			// 
			// titleBar13
			// 
			this.titleBar13.Dock = System.Windows.Forms.DockStyle.Top;
			this.titleBar13.GradientActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(53)), ((System.Byte)(115)), ((System.Byte)(214)));
			this.titleBar13.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
			this.titleBar13.GradientDirection = Crownwood.DotNetMagic.Controls.GradientDirection.TopToBottom;
			this.titleBar13.GradientInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(96)), ((System.Byte)(178)));
			this.titleBar13.Location = new System.Drawing.Point(0, 0);
			this.titleBar13.MouseOverColor = System.Drawing.Color.Empty;
			this.titleBar13.Name = "titleBar13";
			this.titleBar13.Size = new System.Drawing.Size(852, 32);
			this.titleBar13.TabIndex = 10;
			this.titleBar13.Text = "Systems";
			// 
			// tabControl2
			// 
			this.tabControl2.Appearance = Crownwood.DotNetMagic.Controls.VisualAppearance.MultiBox;
			this.tabControl2.BackColor = System.Drawing.SystemColors.Control;
			this.tabControl2.ButtonActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.tabControl2.ButtonInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.tabControl2.Dock = System.Windows.Forms.DockStyle.Top;
			this.tabControl2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.tabControl2.HotTextColor = System.Drawing.SystemColors.ActiveCaption;
			this.tabControl2.HotTrack = true;
			this.tabControl2.ImageList = null;
			this.tabControl2.Location = new System.Drawing.Point(0, 0);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.OfficeDockSides = false;
			this.tabControl2.OfficeHeaderBorder = true;
			this.tabControl2.OfficeStyle = Crownwood.DotNetMagic.Controls.OfficeStyle.LightEnhanced;
			this.tabControl2.PositionTop = true;
			this.tabControl2.SelectedIndex = 7;
			this.tabControl2.Size = new System.Drawing.Size(852, 120);
			this.tabControl2.TabIndex = 9;
			this.tabControl2.TabPages.AddRange(new Crownwood.DotNetMagic.Controls.TabPage[] {
																								this.tabPage1,
																								this.tabPage4,
																								this.tabPage3,
																								this.tabPage8,
																								this.tabPage7,
																								this.tabPage2,
																								this.tabPage5,
																								this.tabPage6});
			this.tabControl2.TextColor = System.Drawing.SystemColors.ControlText;
			this.tabControl2.TextInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.tabControl2.TextTips = true;
			this.tabControl2.SelectionChanged += new Crownwood.DotNetMagic.Controls.SelectTabHandler(this.tabControl2_SelectionChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.titleBar11);
			this.tabPage1.Controls.Add(this.button3);
			this.tabPage1.Controls.Add(this.button1);
			this.tabPage1.Controls.Add(this.lblPass);
			this.tabPage1.Controls.Add(this.lblUser);
			this.tabPage1.Controls.Add(this.txtPass);
			this.tabPage1.Controls.Add(this.txtUser);
			this.tabPage1.Controls.Add(this.chkLogin);
			this.tabPage1.Controls.Add(this.textBox1);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Icon = ((System.Drawing.Icon)(resources.GetObject("tabPage1.Icon")));
			this.tabPage1.InactiveBackColor = System.Drawing.Color.Empty;
			this.tabPage1.InactiveTextBackColor = System.Drawing.Color.Empty;
			this.tabPage1.InactiveTextColor = System.Drawing.Color.Empty;
			this.tabPage1.Location = new System.Drawing.Point(1, 30);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.SelectBackColor = System.Drawing.Color.Empty;
			this.tabPage1.Selected = false;
			this.tabPage1.SelectTextBackColor = System.Drawing.Color.Empty;
			this.tabPage1.SelectTextColor = System.Drawing.Color.Empty;
			this.tabPage1.Size = new System.Drawing.Size(850, 89);
			this.tabPage1.StartFocus = this.textBox1;
			this.tabPage1.TabIndex = 3;
			this.tabPage1.Title = "Scan System";
			this.tabPage1.ToolTip = "Scan System to add it to HWD Database.";
			// 
			// titleBar11
			// 
			this.titleBar11.Direction = Crownwood.DotNetMagic.Common.Direction.Vertical;
			this.titleBar11.Dock = System.Windows.Forms.DockStyle.Left;
			this.titleBar11.GradientActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(53)), ((System.Byte)(115)), ((System.Byte)(214)));
			this.titleBar11.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
			this.titleBar11.GradientDirection = Crownwood.DotNetMagic.Controls.GradientDirection.TopToBottom;
			this.titleBar11.GradientInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(96)), ((System.Byte)(178)));
			this.titleBar11.Location = new System.Drawing.Point(0, 0);
			this.titleBar11.MouseOverColor = System.Drawing.Color.Empty;
			this.titleBar11.Name = "titleBar11";
			this.titleBar11.Size = new System.Drawing.Size(24, 89);
			this.titleBar11.TabIndex = 30;
			this.titleBar11.Text = "Scan System";
			// 
			// button3
			// 
			this.button3.Enabled = false;
			this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
			this.button3.Location = new System.Drawing.Point(544, 16);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(112, 48);
			this.button3.TabIndex = 22;
			this.button3.Text = "Stop";
			this.toolTip1.SetToolTip(this.button3, "Stop active scanning.");
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button1
			// 
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.Location = new System.Drawing.Point(416, 16);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(112, 48);
			this.button1.TabIndex = 21;
			this.button1.Text = "Look up";
			this.toolTip1.SetToolTip(this.button1, "Look up the host range or machine name.");
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// lblPass
			// 
			this.lblPass.Location = new System.Drawing.Point(208, 64);
			this.lblPass.Name = "lblPass";
			this.lblPass.Size = new System.Drawing.Size(64, 16);
			this.lblPass.TabIndex = 19;
			this.lblPass.Text = "Password:";
			this.lblPass.Visible = false;
			// 
			// lblUser
			// 
			this.lblUser.Location = new System.Drawing.Point(208, 32);
			this.lblUser.Name = "lblUser";
			this.lblUser.Size = new System.Drawing.Size(64, 16);
			this.lblUser.TabIndex = 18;
			this.lblUser.Text = "User:";
			this.lblUser.Visible = false;
			// 
			// txtPass
			// 
			this.txtPass.BackColor = System.Drawing.Color.White;
			this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPass.Location = new System.Drawing.Point(272, 64);
			this.txtPass.Name = "txtPass";
			this.txtPass.PasswordChar = '*';
			this.txtPass.Size = new System.Drawing.Size(128, 18);
			this.txtPass.TabIndex = 17;
			this.txtPass.Text = "";
			this.txtPass.Visible = false;
			// 
			// txtUser
			// 
			this.txtUser.BackColor = System.Drawing.Color.White;
			this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtUser.Location = new System.Drawing.Point(272, 32);
			this.txtUser.Name = "txtUser";
			this.txtUser.Size = new System.Drawing.Size(128, 18);
			this.txtUser.TabIndex = 16;
			this.txtUser.Text = "";
			this.toolTip1.SetToolTip(this.txtUser, "Type a valid user.");
			this.txtUser.Visible = false;
			// 
			// chkLogin
			// 
			this.chkLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkLogin.Location = new System.Drawing.Point(200, 8);
			this.chkLogin.Name = "chkLogin";
			this.chkLogin.Size = new System.Drawing.Size(120, 24);
			this.chkLogin.TabIndex = 15;
			this.chkLogin.Text = "Use another login";
			this.toolTip1.SetToolTip(this.chkLogin, "Enable to use another login to performance scans.");
			this.chkLogin.Click += new System.EventHandler(this.chkLogin_CheckedChanged);
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.Color.White;
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox1.Location = new System.Drawing.Point(32, 48);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(128, 18);
			this.textBox1.TabIndex = 11;
			this.textBox1.Text = "";
			this.toolTip1.SetToolTip(this.textBox1, "Type your host range or Machine name to scan.");
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 32);
			this.label1.TabIndex = 14;
			this.label1.Text = "Host Range or Machine Name:";
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.titleBar10);
			this.tabPage4.Controls.Add(this.button8);
			this.tabPage4.Controls.Add(this.button7);
			this.tabPage4.Controls.Add(this.groupBox1);
			this.tabPage4.Icon = ((System.Drawing.Icon)(resources.GetObject("tabPage4.Icon")));
			this.tabPage4.InactiveBackColor = System.Drawing.Color.Empty;
			this.tabPage4.InactiveTextBackColor = System.Drawing.Color.Empty;
			this.tabPage4.InactiveTextColor = System.Drawing.Color.Empty;
			this.tabPage4.Location = new System.Drawing.Point(1, 30);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.SelectBackColor = System.Drawing.Color.Empty;
			this.tabPage4.Selected = false;
			this.tabPage4.SelectTextBackColor = System.Drawing.Color.Empty;
			this.tabPage4.SelectTextColor = System.Drawing.Color.Empty;
			this.tabPage4.Size = new System.Drawing.Size(850, 89);
			this.tabPage4.StartFocus = this.cboField;
			this.tabPage4.TabIndex = 7;
			this.tabPage4.Title = "Filter";
			this.tabPage4.ToolTip = "Filter with Expression Builder to helps you manage your info.";
			// 
			// titleBar10
			// 
			this.titleBar10.Direction = Crownwood.DotNetMagic.Common.Direction.Vertical;
			this.titleBar10.Dock = System.Windows.Forms.DockStyle.Left;
			this.titleBar10.GradientActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(53)), ((System.Byte)(115)), ((System.Byte)(214)));
			this.titleBar10.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
			this.titleBar10.GradientDirection = Crownwood.DotNetMagic.Controls.GradientDirection.TopToBottom;
			this.titleBar10.GradientInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(96)), ((System.Byte)(178)));
			this.titleBar10.Location = new System.Drawing.Point(0, 0);
			this.titleBar10.MouseOverColor = System.Drawing.Color.Empty;
			this.titleBar10.Name = "titleBar10";
			this.titleBar10.Size = new System.Drawing.Size(24, 89);
			this.titleBar10.TabIndex = 30;
			this.titleBar10.Text = "Filter";
			// 
			// button8
			// 
			this.button8.Enabled = false;
			this.button8.Image = ((System.Drawing.Image)(resources.GetObject("button8.Image")));
			this.button8.Location = new System.Drawing.Point(488, 16);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(112, 48);
			this.button8.TabIndex = 16;
			this.button8.Text = "Clear Filters";
			this.toolTip1.SetToolTip(this.button8, "Reset all filters.");
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// button7
			// 
			this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
			this.button7.Location = new System.Drawing.Point(360, 16);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(112, 48);
			this.button7.TabIndex = 15;
			this.button7.Text = "Apply Filter";
			this.toolTip1.SetToolTip(this.button7, "Apply the expression to filter in your data.");
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtFilter);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.cboField);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.cboOperator);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Location = new System.Drawing.Point(40, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(312, 64);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Expression Builder";
			// 
			// txtFilter
			// 
			this.txtFilter.BackColor = System.Drawing.Color.White;
			this.txtFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtFilter.Location = new System.Drawing.Point(200, 32);
			this.txtFilter.Name = "txtFilter";
			this.txtFilter.TabIndex = 4;
			this.txtFilter.Text = "";
			this.toolTip1.SetToolTip(this.txtFilter, "Type the desired string to filter.");
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(120, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 9;
			this.label3.Text = "Operator";
			// 
			// cboField
			// 
			this.cboField.BackColor = System.Drawing.Color.White;
			this.cboField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboField.ItemHeight = 12;
			this.cboField.Items.AddRange(new object[] {
														  "ComputerName",
														  "OS",
														  "UserName",
														  "Manufacturer",
														  "Model",
														  "SerialNumber",
														  "Kind",
														  "Location"});
			this.cboField.Location = new System.Drawing.Point(16, 32);
			this.cboField.Name = "cboField";
			this.cboField.Size = new System.Drawing.Size(96, 20);
			this.cboField.TabIndex = 6;
			this.toolTip1.SetToolTip(this.cboField, "Choose a Field to Filter.");
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 16);
			this.label2.TabIndex = 8;
			this.label2.Text = "Field";
			// 
			// cboOperator
			// 
			this.cboOperator.BackColor = System.Drawing.Color.White;
			this.cboOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboOperator.ItemHeight = 12;
			this.cboOperator.Items.AddRange(new object[] {
															 "=",
															 "<>",
															 "like"});
			this.cboOperator.Location = new System.Drawing.Point(120, 32);
			this.cboOperator.Name = "cboOperator";
			this.cboOperator.Size = new System.Drawing.Size(72, 20);
			this.cboOperator.TabIndex = 7;
			this.toolTip1.SetToolTip(this.cboOperator, "Choose an Operator to Filter.");
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(200, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 10;
			this.label4.Text = "String";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.titleBar8);
			this.tabPage3.Controls.Add(this.button6);
			this.tabPage3.Controls.Add(this.button11);
			this.tabPage3.Controls.Add(this.button10);
			this.tabPage3.Controls.Add(this.titleBar9);
			this.tabPage3.Icon = ((System.Drawing.Icon)(resources.GetObject("tabPage3.Icon")));
			this.tabPage3.InactiveBackColor = System.Drawing.Color.Empty;
			this.tabPage3.InactiveTextBackColor = System.Drawing.Color.Empty;
			this.tabPage3.InactiveTextColor = System.Drawing.Color.Empty;
			this.tabPage3.Location = new System.Drawing.Point(1, 30);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.SelectBackColor = System.Drawing.Color.Empty;
			this.tabPage3.Selected = false;
			this.tabPage3.SelectTextBackColor = System.Drawing.Color.Empty;
			this.tabPage3.SelectTextColor = System.Drawing.Color.Empty;
			this.tabPage3.Size = new System.Drawing.Size(850, 89);
			this.tabPage3.TabIndex = 6;
			this.tabPage3.Title = "Reports";
			this.tabPage3.ToolTip = "Manage Reports to Print and Export settings.";
			// 
			// titleBar8
			// 
			this.titleBar8.Direction = Crownwood.DotNetMagic.Common.Direction.Vertical;
			this.titleBar8.Dock = System.Windows.Forms.DockStyle.Left;
			this.titleBar8.GradientActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(53)), ((System.Byte)(115)), ((System.Byte)(214)));
			this.titleBar8.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
			this.titleBar8.GradientDirection = Crownwood.DotNetMagic.Controls.GradientDirection.TopToBottom;
			this.titleBar8.GradientInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(96)), ((System.Byte)(178)));
			this.titleBar8.Location = new System.Drawing.Point(0, 0);
			this.titleBar8.MouseOverColor = System.Drawing.Color.Empty;
			this.titleBar8.Name = "titleBar8";
			this.titleBar8.Size = new System.Drawing.Size(24, 89);
			this.titleBar8.TabIndex = 29;
			this.titleBar8.Text = "Reports";
			// 
			// button6
			// 
			this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
			this.button6.Location = new System.Drawing.Point(472, 16);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(112, 48);
			this.button6.TabIndex = 20;
			this.button6.Text = "To XML";
			this.toolTip1.SetToolTip(this.button6, "Export HWD Database to XML File.");
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button11
			// 
			this.button11.Image = ((System.Drawing.Image)(resources.GetObject("button11.Image")));
			this.button11.Location = new System.Drawing.Point(160, 16);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(112, 48);
			this.button11.TabIndex = 19;
			this.button11.Text = "Reporter";
			this.toolTip1.SetToolTip(this.button11, "Reporter helps you to make custom reports onfly.");
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// button10
			// 
			this.button10.Image = ((System.Drawing.Image)(resources.GetObject("button10.Image")));
			this.button10.Location = new System.Drawing.Point(40, 16);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(112, 48);
			this.button10.TabIndex = 17;
			this.button10.Text = "Hardware";
			this.toolTip1.SetToolTip(this.button10, "Prepare a Hardware Report of the data showed in the datagrid.");
			this.button10.Click += new System.EventHandler(this.button10_Click);
			// 
			// titleBar9
			// 
			this.titleBar9.Direction = Crownwood.DotNetMagic.Common.Direction.Vertical;
			this.titleBar9.GradientActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(53)), ((System.Byte)(115)), ((System.Byte)(214)));
			this.titleBar9.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
			this.titleBar9.GradientDirection = Crownwood.DotNetMagic.Controls.GradientDirection.TopToBottom;
			this.titleBar9.GradientInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(96)), ((System.Byte)(178)));
			this.titleBar9.Location = new System.Drawing.Point(432, 0);
			this.titleBar9.MouseOverColor = System.Drawing.Color.Empty;
			this.titleBar9.Name = "titleBar9";
			this.titleBar9.Size = new System.Drawing.Size(24, 89);
			this.titleBar9.TabIndex = 28;
			this.titleBar9.Text = "Export";
			// 
			// tabPage8
			// 
			this.tabPage8.Controls.Add(this.buttonWithStyle6);
			this.tabPage8.Controls.Add(this.titleBar15);
			this.tabPage8.Controls.Add(this.buttonWithStyle5);
			this.tabPage8.Controls.Add(this.titleBar14);
			this.tabPage8.Icon = ((System.Drawing.Icon)(resources.GetObject("tabPage8.Icon")));
			this.tabPage8.InactiveBackColor = System.Drawing.Color.Empty;
			this.tabPage8.InactiveTextBackColor = System.Drawing.Color.Empty;
			this.tabPage8.InactiveTextColor = System.Drawing.Color.Empty;
			this.tabPage8.Location = new System.Drawing.Point(1, 30);
			this.tabPage8.Name = "tabPage8";
			this.tabPage8.SelectBackColor = System.Drawing.Color.Empty;
			this.tabPage8.Selected = false;
			this.tabPage8.SelectTextBackColor = System.Drawing.Color.Empty;
			this.tabPage8.SelectTextColor = System.Drawing.Color.Empty;
			this.tabPage8.Size = new System.Drawing.Size(850, 89);
			this.tabPage8.TabIndex = 10;
			this.tabPage8.Title = "Clients";
			this.tabPage8.ToolTip = "Page";
			// 
			// buttonWithStyle6
			// 
			this.buttonWithStyle6.Location = new System.Drawing.Point(456, 16);
			this.buttonWithStyle6.Name = "buttonWithStyle6";
			this.buttonWithStyle6.Size = new System.Drawing.Size(112, 48);
			this.buttonWithStyle6.TabIndex = 34;
			this.buttonWithStyle6.Text = "Technics";
			this.toolTip1.SetToolTip(this.buttonWithStyle6, "Save your current options.");
			this.buttonWithStyle6.Click += new System.EventHandler(this.buttonWithStyle6_Click);
			// 
			// titleBar15
			// 
			this.titleBar15.Direction = Crownwood.DotNetMagic.Common.Direction.Vertical;
			this.titleBar15.GradientActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(53)), ((System.Byte)(115)), ((System.Byte)(214)));
			this.titleBar15.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
			this.titleBar15.GradientDirection = Crownwood.DotNetMagic.Controls.GradientDirection.TopToBottom;
			this.titleBar15.GradientInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(96)), ((System.Byte)(178)));
			this.titleBar15.Location = new System.Drawing.Point(413, 0);
			this.titleBar15.MouseOverColor = System.Drawing.Color.Empty;
			this.titleBar15.Name = "titleBar15";
			this.titleBar15.Size = new System.Drawing.Size(24, 89);
			this.titleBar15.TabIndex = 33;
			this.titleBar15.Text = "Technics";
			// 
			// buttonWithStyle5
			// 
			this.buttonWithStyle5.Image = ((System.Drawing.Image)(resources.GetObject("buttonWithStyle5.Image")));
			this.buttonWithStyle5.Location = new System.Drawing.Point(40, 16);
			this.buttonWithStyle5.Name = "buttonWithStyle5";
			this.buttonWithStyle5.Size = new System.Drawing.Size(112, 48);
			this.buttonWithStyle5.TabIndex = 32;
			this.buttonWithStyle5.Text = "Blocked Apps";
			this.toolTip1.SetToolTip(this.buttonWithStyle5, "Save your current options.");
			this.buttonWithStyle5.Click += new System.EventHandler(this.buttonWithStyle5_Click);
			// 
			// titleBar14
			// 
			this.titleBar14.Direction = Crownwood.DotNetMagic.Common.Direction.Vertical;
			this.titleBar14.GradientActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(53)), ((System.Byte)(115)), ((System.Byte)(214)));
			this.titleBar14.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
			this.titleBar14.GradientDirection = Crownwood.DotNetMagic.Controls.GradientDirection.TopToBottom;
			this.titleBar14.GradientInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(96)), ((System.Byte)(178)));
			this.titleBar14.Location = new System.Drawing.Point(0, 0);
			this.titleBar14.MouseOverColor = System.Drawing.Color.Empty;
			this.titleBar14.Name = "titleBar14";
			this.titleBar14.Size = new System.Drawing.Size(24, 89);
			this.titleBar14.TabIndex = 31;
			this.titleBar14.Text = "Applications";
			// 
			// tabPage7
			// 
			this.tabPage7.Controls.Add(this.listBox3);
			this.tabPage7.Controls.Add(this.listBox2);
			this.tabPage7.Controls.Add(this.titleBar12);
			this.tabPage7.Controls.Add(this.button2);
			this.tabPage7.Controls.Add(this.buttonWithStyle3);
			this.tabPage7.Controls.Add(this.buttonWithStyle4);
			this.tabPage7.Controls.Add(this.textBox3);
			this.tabPage7.Controls.Add(this.titleBar2);
			this.tabPage7.Controls.Add(this.titleBar1);
			this.tabPage7.Controls.Add(this.buttonWithStyle2);
			this.tabPage7.Controls.Add(this.buttonWithStyle1);
			this.tabPage7.Controls.Add(this.textBox2);
			this.tabPage7.Icon = ((System.Drawing.Icon)(resources.GetObject("tabPage7.Icon")));
			this.tabPage7.InactiveBackColor = System.Drawing.Color.Empty;
			this.tabPage7.InactiveTextBackColor = System.Drawing.Color.Empty;
			this.tabPage7.InactiveTextColor = System.Drawing.Color.Empty;
			this.tabPage7.Location = new System.Drawing.Point(1, 30);
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.SelectBackColor = System.Drawing.Color.Empty;
			this.tabPage7.Selected = false;
			this.tabPage7.SelectTextBackColor = System.Drawing.Color.Empty;
			this.tabPage7.SelectTextColor = System.Drawing.Color.Empty;
			this.tabPage7.Size = new System.Drawing.Size(850, 89);
			this.tabPage7.TabIndex = 9;
			this.tabPage7.Title = "Data";
			this.tabPage7.ToolTip = "Page";
			this.toolTip1.SetToolTip(this.tabPage7, "Add Location and Kind items, and save data in your data store system.");
			// 
			// listBox3
			// 
			this.listBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listBox3.DataSource = this.userData1.KWD;
			this.listBox3.DisplayMember = "KindName";
			this.listBox3.ItemHeight = 12;
			this.listBox3.Location = new System.Drawing.Point(328, 32);
			this.listBox3.Name = "listBox3";
			this.listBox3.Size = new System.Drawing.Size(144, 50);
			this.listBox3.TabIndex = 35;
			// 
			// listBox2
			// 
			this.listBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listBox2.DataSource = this.userData1.LWD;
			this.listBox2.DisplayMember = "LocationName";
			this.listBox2.ItemHeight = 12;
			this.listBox2.Location = new System.Drawing.Point(40, 32);
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size(144, 50);
			this.listBox2.TabIndex = 34;
			// 
			// titleBar12
			// 
			this.titleBar12.Direction = Crownwood.DotNetMagic.Common.Direction.Vertical;
			this.titleBar12.GradientActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(53)), ((System.Byte)(115)), ((System.Byte)(214)));
			this.titleBar12.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
			this.titleBar12.GradientDirection = Crownwood.DotNetMagic.Controls.GradientDirection.TopToBottom;
			this.titleBar12.GradientInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(96)), ((System.Byte)(178)));
			this.titleBar12.Location = new System.Drawing.Point(576, 0);
			this.titleBar12.MouseOverColor = System.Drawing.Color.Empty;
			this.titleBar12.Name = "titleBar12";
			this.titleBar12.Size = new System.Drawing.Size(24, 89);
			this.titleBar12.TabIndex = 33;
			this.titleBar12.Text = "Data";
			// 
			// button2
			// 
			this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
			this.button2.Location = new System.Drawing.Point(616, 16);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(112, 48);
			this.button2.TabIndex = 32;
			this.button2.Text = "Save Data";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// buttonWithStyle3
			// 
			this.buttonWithStyle3.Location = new System.Drawing.Point(480, 40);
			this.buttonWithStyle3.Name = "buttonWithStyle3";
			this.buttonWithStyle3.Size = new System.Drawing.Size(80, 24);
			this.buttonWithStyle3.TabIndex = 9;
			this.buttonWithStyle3.Text = "Delete";
			this.toolTip1.SetToolTip(this.buttonWithStyle3, "Delete selected item.");
			this.buttonWithStyle3.Click += new System.EventHandler(this.buttonWithStyle3_Click);
			// 
			// buttonWithStyle4
			// 
			this.buttonWithStyle4.Location = new System.Drawing.Point(480, 8);
			this.buttonWithStyle4.Name = "buttonWithStyle4";
			this.buttonWithStyle4.Size = new System.Drawing.Size(80, 24);
			this.buttonWithStyle4.TabIndex = 8;
			this.buttonWithStyle4.Text = "Add";
			this.toolTip1.SetToolTip(this.buttonWithStyle4, "Add current Kind item.");
			this.buttonWithStyle4.Click += new System.EventHandler(this.buttonWithStyle4_Click);
			// 
			// textBox3
			// 
			this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox3.Location = new System.Drawing.Point(328, 8);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(144, 18);
			this.textBox3.TabIndex = 7;
			this.textBox3.Text = "";
			// 
			// titleBar2
			// 
			this.titleBar2.Direction = Crownwood.DotNetMagic.Common.Direction.Vertical;
			this.titleBar2.GradientActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(53)), ((System.Byte)(115)), ((System.Byte)(214)));
			this.titleBar2.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
			this.titleBar2.GradientDirection = Crownwood.DotNetMagic.Controls.GradientDirection.TopToBottom;
			this.titleBar2.GradientInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(96)), ((System.Byte)(178)));
			this.titleBar2.Location = new System.Drawing.Point(288, 0);
			this.titleBar2.MouseOverColor = System.Drawing.Color.Empty;
			this.titleBar2.Name = "titleBar2";
			this.titleBar2.Size = new System.Drawing.Size(24, 89);
			this.titleBar2.TabIndex = 5;
			this.titleBar2.Text = "Kind";
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
			this.titleBar1.Size = new System.Drawing.Size(24, 89);
			this.titleBar1.TabIndex = 4;
			this.titleBar1.Text = "Location";
			// 
			// buttonWithStyle2
			// 
			this.buttonWithStyle2.Location = new System.Drawing.Point(192, 40);
			this.buttonWithStyle2.Name = "buttonWithStyle2";
			this.buttonWithStyle2.Size = new System.Drawing.Size(80, 24);
			this.buttonWithStyle2.TabIndex = 3;
			this.buttonWithStyle2.Text = "Delete";
			this.toolTip1.SetToolTip(this.buttonWithStyle2, "Delete selected item.");
			this.buttonWithStyle2.Click += new System.EventHandler(this.buttonWithStyle2_Click);
			// 
			// buttonWithStyle1
			// 
			this.buttonWithStyle1.Location = new System.Drawing.Point(192, 8);
			this.buttonWithStyle1.Name = "buttonWithStyle1";
			this.buttonWithStyle1.Size = new System.Drawing.Size(80, 24);
			this.buttonWithStyle1.TabIndex = 2;
			this.buttonWithStyle1.Text = "Add";
			this.toolTip1.SetToolTip(this.buttonWithStyle1, "Add current location value.");
			this.buttonWithStyle1.Click += new System.EventHandler(this.buttonWithStyle1_Click);
			// 
			// textBox2
			// 
			this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox2.Location = new System.Drawing.Point(40, 8);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(144, 18);
			this.textBox2.TabIndex = 1;
			this.textBox2.Text = "";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.titleBar7);
			this.tabPage2.Controls.Add(this.button5);
			this.tabPage2.Controls.Add(this.listBox1);
			this.tabPage2.Icon = ((System.Drawing.Icon)(resources.GetObject("tabPage2.Icon")));
			this.tabPage2.InactiveBackColor = System.Drawing.Color.Empty;
			this.tabPage2.InactiveTextBackColor = System.Drawing.Color.Empty;
			this.tabPage2.InactiveTextColor = System.Drawing.Color.Empty;
			this.tabPage2.Location = new System.Drawing.Point(1, 30);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.SelectBackColor = System.Drawing.Color.Empty;
			this.tabPage2.Selected = false;
			this.tabPage2.SelectTextBackColor = System.Drawing.Color.Empty;
			this.tabPage2.SelectTextColor = System.Drawing.Color.Empty;
			this.tabPage2.Size = new System.Drawing.Size(850, 89);
			this.tabPage2.StartFocus = this.listBox1;
			this.tabPage2.TabIndex = 4;
			this.tabPage2.Title = "Error Log";
			this.tabPage2.ToolTip = "Page";
			this.toolTip1.SetToolTip(this.tabPage2, "Display scan errors and other logged info.");
			// 
			// titleBar7
			// 
			this.titleBar7.Direction = Crownwood.DotNetMagic.Common.Direction.Vertical;
			this.titleBar7.Dock = System.Windows.Forms.DockStyle.Left;
			this.titleBar7.GradientActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(53)), ((System.Byte)(115)), ((System.Byte)(214)));
			this.titleBar7.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
			this.titleBar7.GradientDirection = Crownwood.DotNetMagic.Controls.GradientDirection.TopToBottom;
			this.titleBar7.GradientInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(96)), ((System.Byte)(178)));
			this.titleBar7.Location = new System.Drawing.Point(0, 0);
			this.titleBar7.MouseOverColor = System.Drawing.Color.Empty;
			this.titleBar7.Name = "titleBar7";
			this.titleBar7.Size = new System.Drawing.Size(24, 89);
			this.titleBar7.TabIndex = 29;
			this.titleBar7.Text = "Error Log";
			// 
			// button5
			// 
			this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
			this.button5.Location = new System.Drawing.Point(672, 16);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(112, 48);
			this.button5.TabIndex = 11;
			this.button5.Text = "Clear log";
			this.toolTip1.SetToolTip(this.button5, "Clear the error log.");
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// listBox1
			// 
			this.listBox1.BackColor = System.Drawing.Color.White;
			this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(40, 8);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(624, 74);
			this.listBox1.TabIndex = 10;
			this.toolTip1.SetToolTip(this.listBox1, "This are the custom errors.");
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.titleBar5);
			this.tabPage5.Controls.Add(this.button12);
			this.tabPage5.Controls.Add(this.button9);
			this.tabPage5.Controls.Add(this.chkXML);
			this.tabPage5.Controls.Add(this.radioSpanish);
			this.tabPage5.Controls.Add(this.label7);
			this.tabPage5.Controls.Add(this.radioEnglish);
			this.tabPage5.Controls.Add(this.txthotdate);
			this.tabPage5.Controls.Add(this.label6);
			this.tabPage5.Controls.Add(this.chkAutoSave);
			this.tabPage5.Controls.Add(this.titleBar6);
			this.tabPage5.Icon = ((System.Drawing.Icon)(resources.GetObject("tabPage5.Icon")));
			this.tabPage5.InactiveBackColor = System.Drawing.Color.Empty;
			this.tabPage5.InactiveTextBackColor = System.Drawing.Color.Empty;
			this.tabPage5.InactiveTextColor = System.Drawing.Color.Empty;
			this.tabPage5.Location = new System.Drawing.Point(1, 30);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.SelectBackColor = System.Drawing.Color.Empty;
			this.tabPage5.Selected = false;
			this.tabPage5.SelectTextBackColor = System.Drawing.Color.Empty;
			this.tabPage5.SelectTextColor = System.Drawing.Color.Empty;
			this.tabPage5.Size = new System.Drawing.Size(850, 89);
			this.tabPage5.TabIndex = 5;
			this.tabPage5.Title = "Options";
			this.tabPage5.ToolTip = "Page";
			this.toolTip1.SetToolTip(this.tabPage5, "Options allow choose data and language setting.");
			// 
			// titleBar5
			// 
			this.titleBar5.Direction = Crownwood.DotNetMagic.Common.Direction.Vertical;
			this.titleBar5.Dock = System.Windows.Forms.DockStyle.Left;
			this.titleBar5.GradientActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(53)), ((System.Byte)(115)), ((System.Byte)(214)));
			this.titleBar5.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
			this.titleBar5.GradientDirection = Crownwood.DotNetMagic.Controls.GradientDirection.TopToBottom;
			this.titleBar5.GradientInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(96)), ((System.Byte)(178)));
			this.titleBar5.Location = new System.Drawing.Point(0, 0);
			this.titleBar5.MouseOverColor = System.Drawing.Color.Empty;
			this.titleBar5.Name = "titleBar5";
			this.titleBar5.Size = new System.Drawing.Size(24, 89);
			this.titleBar5.TabIndex = 28;
			this.titleBar5.Text = "Options";
			// 
			// button12
			// 
			this.button12.Image = ((System.Drawing.Image)(resources.GetObject("button12.Image")));
			this.button12.Location = new System.Drawing.Point(608, 16);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(112, 48);
			this.button12.TabIndex = 27;
			this.button12.Text = "Get Definition";
			this.toolTip1.SetToolTip(this.button12, "Launch HWD HotFix Updater to download a new definition file from Microsoft.");
			this.button12.Click += new System.EventHandler(this.button12_Click);
			// 
			// button9
			// 
			this.button9.Image = ((System.Drawing.Image)(resources.GetObject("button9.Image")));
			this.button9.Location = new System.Drawing.Point(280, 16);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(112, 48);
			this.button9.TabIndex = 26;
			this.button9.Text = "Save Options";
			this.toolTip1.SetToolTip(this.button9, "Save your current options.");
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// chkXML
			// 
			this.chkXML.BackColor = System.Drawing.Color.Transparent;
			this.chkXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkXML.Location = new System.Drawing.Point(32, 32);
			this.chkXML.Name = "chkXML";
			this.chkXML.Size = new System.Drawing.Size(120, 16);
			this.chkXML.TabIndex = 24;
			this.chkXML.Text = "AutoSave XML";
			this.toolTip1.SetToolTip(this.chkXML, "Allow to save DB to XML to offline support.");
			// 
			// radioSpanish
			// 
			this.radioSpanish.BackColor = System.Drawing.Color.Transparent;
			this.radioSpanish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioSpanish.Location = new System.Drawing.Point(168, 56);
			this.radioSpanish.Name = "radioSpanish";
			this.radioSpanish.Size = new System.Drawing.Size(104, 16);
			this.radioSpanish.TabIndex = 23;
			this.radioSpanish.Text = "Spanish";
			this.radioSpanish.Click += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// label7
			// 
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.Location = new System.Drawing.Point(160, 8);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(88, 16);
			this.label7.TabIndex = 22;
			this.label7.Text = "Language";
			// 
			// radioEnglish
			// 
			this.radioEnglish.BackColor = System.Drawing.Color.Transparent;
			this.radioEnglish.Checked = true;
			this.radioEnglish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioEnglish.Location = new System.Drawing.Point(168, 32);
			this.radioEnglish.Name = "radioEnglish";
			this.radioEnglish.Size = new System.Drawing.Size(104, 16);
			this.radioEnglish.TabIndex = 21;
			this.radioEnglish.TabStop = true;
			this.radioEnglish.Text = "English";
			this.radioEnglish.Click += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// txthotdate
			// 
			this.txthotdate.BackColor = System.Drawing.Color.White;
			this.txthotdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txthotdate.Location = new System.Drawing.Point(464, 40);
			this.txthotdate.Name = "txthotdate";
			this.txthotdate.ReadOnly = true;
			this.txthotdate.Size = new System.Drawing.Size(128, 18);
			this.txthotdate.TabIndex = 20;
			this.txthotdate.Text = "No present";
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Location = new System.Drawing.Point(464, 8);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 32);
			this.label6.TabIndex = 19;
			this.label6.Text = "Hotfixes definition date:";
			// 
			// chkAutoSave
			// 
			this.chkAutoSave.BackColor = System.Drawing.Color.Transparent;
			this.chkAutoSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkAutoSave.Location = new System.Drawing.Point(32, 8);
			this.chkAutoSave.Name = "chkAutoSave";
			this.chkAutoSave.Size = new System.Drawing.Size(120, 16);
			this.chkAutoSave.TabIndex = 18;
			this.chkAutoSave.Text = "AutoSave Data";
			this.toolTip1.SetToolTip(this.chkAutoSave, "Allow HWD save data in certain time.");
			// 
			// titleBar6
			// 
			this.titleBar6.Direction = Crownwood.DotNetMagic.Common.Direction.Vertical;
			this.titleBar6.GradientActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(53)), ((System.Byte)(115)), ((System.Byte)(214)));
			this.titleBar6.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
			this.titleBar6.GradientDirection = Crownwood.DotNetMagic.Controls.GradientDirection.TopToBottom;
			this.titleBar6.GradientInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(96)), ((System.Byte)(178)));
			this.titleBar6.Location = new System.Drawing.Point(432, 0);
			this.titleBar6.MouseOverColor = System.Drawing.Color.Empty;
			this.titleBar6.Name = "titleBar6";
			this.titleBar6.Size = new System.Drawing.Size(24, 89);
			this.titleBar6.TabIndex = 28;
			this.titleBar6.Text = "Hotfix Definition";
			// 
			// tabPage6
			// 
			this.tabPage6.Controls.Add(this.titleBar4);
			this.tabPage6.Controls.Add(this.titleBar3);
			this.tabPage6.Controls.Add(this.label17);
			this.tabPage6.Controls.Add(this.label16);
			this.tabPage6.Controls.Add(this.label15);
			this.tabPage6.Controls.Add(this.label14);
			this.tabPage6.Controls.Add(this.label13);
			this.tabPage6.Controls.Add(this.label12);
			this.tabPage6.Controls.Add(this.label11);
			this.tabPage6.Controls.Add(this.label10);
			this.tabPage6.Controls.Add(this.label9);
			this.tabPage6.Controls.Add(this.label8);
			this.tabPage6.Controls.Add(this.pictureBox1);
			this.tabPage6.Controls.Add(this.linkLabel1);
			this.tabPage6.Controls.Add(this.label5);
			this.tabPage6.Icon = ((System.Drawing.Icon)(resources.GetObject("tabPage6.Icon")));
			this.tabPage6.InactiveBackColor = System.Drawing.Color.Empty;
			this.tabPage6.InactiveTextBackColor = System.Drawing.Color.Empty;
			this.tabPage6.InactiveTextColor = System.Drawing.Color.Empty;
			this.tabPage6.Location = new System.Drawing.Point(1, 30);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.SelectBackColor = System.Drawing.Color.Empty;
			this.tabPage6.SelectTextBackColor = System.Drawing.Color.Empty;
			this.tabPage6.SelectTextColor = System.Drawing.Color.Empty;
			this.tabPage6.Size = new System.Drawing.Size(850, 89);
			this.tabPage6.TabIndex = 8;
			this.tabPage6.Title = "About...";
			this.tabPage6.ToolTip = "Page";
			// 
			// titleBar4
			// 
			this.titleBar4.Direction = Crownwood.DotNetMagic.Common.Direction.Vertical;
			this.titleBar4.GradientActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(53)), ((System.Byte)(115)), ((System.Byte)(214)));
			this.titleBar4.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
			this.titleBar4.GradientDirection = Crownwood.DotNetMagic.Controls.GradientDirection.TopToBottom;
			this.titleBar4.GradientInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(96)), ((System.Byte)(178)));
			this.titleBar4.Location = new System.Drawing.Point(360, 0);
			this.titleBar4.MouseOverColor = System.Drawing.Color.Empty;
			this.titleBar4.Name = "titleBar4";
			this.titleBar4.Size = new System.Drawing.Size(24, 89);
			this.titleBar4.TabIndex = 27;
			this.titleBar4.Text = "Credits";
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
			this.titleBar3.Size = new System.Drawing.Size(24, 89);
			this.titleBar3.TabIndex = 26;
			this.titleBar3.Text = "Copyright";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(599, 23);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(160, 16);
			this.label17.TabIndex = 25;
			this.label17.Text = "WMI Implementation of Paul Li";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(591, 7);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(168, 16);
			this.label16.TabIndex = 24;
			this.label16.Text = "WMI Queries based on:";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(744, 64);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(96, 16);
			this.label15.TabIndex = 23;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(744, 48);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(72, 16);
			this.label14.TabIndex = 22;
			this.label14.Text = "Build version:";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(120, 64);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(168, 16);
			this.label13.TabIndex = 21;
			this.label13.Text = "Coders: hxxbin and Iunknown";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(399, 71);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(184, 16);
			this.label12.TabIndex = 20;
			this.label12.Text = "CabinetFile of aplaxas";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(399, 55);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(184, 16);
			this.label11.TabIndex = 19;
			this.label11.Text = "ServerComboBox of Phil Bolduc ";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(399, 39);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(184, 16);
			this.label10.TabIndex = 18;
			this.label10.Text = "Line2D of Sivakumar Mahalingam";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(399, 23);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(160, 16);
			this.label9.TabIndex = 17;
			this.label9.Text = "Report Printing of Mike Mayer ";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(391, 7);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(168, 16);
			this.label8.TabIndex = 16;
			this.label8.Text = "This software uses classes from:";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(32, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(88, 80);
			this.pictureBox1.TabIndex = 15;
			this.pictureBox1.TabStop = false;
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point(120, 40);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(208, 24);
			this.linkLabel1.TabIndex = 14;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "http://www.hailstan.com/hwd";
			this.toolTip1.SetToolTip(this.linkLabel1, "Visit HWDSuite Web Site");
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(120, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(208, 40);
			this.label5.TabIndex = 13;
			this.label5.Text = "HWDManager is a module from HWDSuite by Hailstan 2004-2005";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.tabControl2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(852, 504);
			this.panel1.TabIndex = 10;
			// 
			// Mein
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(852, 530);
			this.Controls.Add(this.statusBarControl1);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(860, 560);
			this.Name = "Mein";
			this.Text = "HWDManager v1.6";
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Mein_Closing);
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dviSystems)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.userData1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.AccessDataTypes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dviTemp)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.timer1)).EndInit();
			this.panel2.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage10.ResumeLayout(false);
			this.tabPage9.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.tabControl2.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage8.ResumeLayout(false);
			this.tabPage7.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.tabPage6.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Mein General Methods

		private void runClient(string app, string par, System.Type tsender)
		{
			this.Cursor = Cursors.WaitCursor;
			this.statusPanel1.Text = "Connecting to system..."; 
			try
			{
				string name;
				if (tsender == dataGrid1.GetType()) 
				{
					Point pt = dataGrid1.PointToClient(rightMouseDownPoint); 
					name = dataGrid1[dataGrid1.HitTest(pt).Row, 2].ToString();
				} 
				else 
				{
					name = tItem.SubItems[0].Text;
				}
				ProcessStartInfo pr = new System.Diagnostics.ProcessStartInfo(app, name);
				pr.WindowStyle = ProcessWindowStyle.Maximized;
				Process.Start(pr);
			} 
			catch
			{
				this.listBox1.Items.Add("Can't connect with Remote Desktop");
			}
			this.Cursor = Cursors.Default;
			this.statusPanel1.Text = "Ready";
		}

		private void UpdateUI()
		{
			this.label1.Text = m_ResourceManager.GetString("labelHostRange");
			this.label2.Text = m_ResourceManager.GetString("label2");
			this.label3.Text = m_ResourceManager.GetString("label3");
			this.label4.Text = m_ResourceManager.GetString("label4");
			this.label6.Text = m_ResourceManager.GetString("label6");
			this.label7.Text = m_ResourceManager.GetString("label7");
			this.radioEnglish.Text = m_ResourceManager.GetString("radioEnglish");
			this.radioSpanish.Text = m_ResourceManager.GetString("radioSpanish");
			this.button1.Text = m_ResourceManager.GetString("button1");
			this.button2.Text = m_ResourceManager.GetString("button2");
			this.button3.Text = m_ResourceManager.GetString("button3");
			this.button5.Text = m_ResourceManager.GetString("button5");
			this.button6.Text = m_ResourceManager.GetString("button6");
			this.button7.Text = m_ResourceManager.GetString("button7");
			this.button8.Text = m_ResourceManager.GetString("button8");
			this.button9.Text = m_ResourceManager.GetString("button9");
			this.button11.Text = m_ResourceManager.GetString("button11");
			this.button12.Text = m_ResourceManager.GetString("button12");
			this.tabPage1.Title = m_ResourceManager.GetString("tabPage1");
			this.titleBar11.Text = m_ResourceManager.GetString("tabPage1");
			this.tabPage2.Title = m_ResourceManager.GetString("tabPage2");
			this.tabPage3.Title = m_ResourceManager.GetString("tabPage3");
			this.tabPage5.Title = m_ResourceManager.GetString("tabPage5");
			this.tabPage6.Title = m_ResourceManager.GetString("tabPage6");
			this.tabPage4.Title = m_ResourceManager.GetString("tabPage4");
			this.lblPass.Text = m_ResourceManager.GetString("lblPass");
			this.lblUser.Text = m_ResourceManager.GetString("lblUser");
			this.chkLogin.Text = m_ResourceManager.GetString("chkLogin");
			this.chkAutoSave.Text = m_ResourceManager.GetString("chkAutoSave");
			this.groupBox1.Text = m_ResourceManager.GetString("groupBox1");
			this.menuItem1.Text = m_ResourceManager.GetString("menuItem1");
			this.menuItem3.Text = m_ResourceManager.GetString("menuItem3");
		}

        private void addRow(DataRow r)
        {
			this.dviSystems.Table.Rows.Add(r);
			this.PopulateListView();
        }

        private void addError(string err)
        {
			this.listBox1.Items.Add(err);
        }

		private string formatSize(Int64 lSize, bool booleanFormatOnly)
		{
			string stringSize = "";
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
		
		private void InitOptions() 
		{
			if (this.xmldoc.FirstChild["AutoSave"].InnerText == "1") 
			{
				this.chkAutoSave.Checked = true;
				this.timer1.Enabled = true;
			}
			if (this.xmldoc.FirstChild["AutoXML"].InnerText == "1") 
			{
				this.chkXML.Checked = true;
			}
			if (File.Exists("hwdhf.xml"))
			{
				this.txthotdate.Text = File.GetLastWriteTime("hwdhf.xml").ToShortDateString();
				this.hotfixfile = true;
			}
		}
		#endregion

		#region Mein WMI Methods

		private System.Management.ManagementObjectCollection Consulta(string strQuery, string machine)
		{
			try
			{
				if (this.chkLogin.Checked && this.txtUser.Text.Length > 0)
				{
					co.Username = this.txtUser.Text;
					co.Password = this.txtPass.Text;
				}
				System.Management.ManagementScope ms = new System.Management.ManagementScope("\\\\" + machine + "\\root\\cimv2", co);
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

		private void doScan(string systems)
		{
			this.sysscan = systems;
			th  = new Thread(new ThreadStart(Escanea));
			th.IsBackground = true;
			th.Start();
			this.terminaThread  = false;
			this.button1.Enabled = false;
			this.button3.Enabled = true;
			this.textBox1.Enabled = false;
			this.chkLogin.Enabled = false;
		}

		public void Escanea()
		{
			if ((this.sysscan.Length > 2) && (this.sysscan.IndexOf('.') < 0))
			{
				foreach(string stringMachineName in this.sysscan.Split(','))
				{
					if (stringMachineName.Length > 3)
					{
						Invoke(new GetInfoDelegate(scanInfo),new object[]{stringMachineName,true});
						getSystemInfo(stringMachineName);
						Invoke(new GetInfoDelegate(scanInfo),new object[]{stringMachineName,false});
					}
				}
			} 
			else if ((this.sysscan.IndexOf('-') > 1) && (this.sysscan.IndexOf('.') >= 2))
			{
				string[] ip = this.sysscan.Split('.');
				string[] range = ip[3].Split('-');
			
				for (int k = Convert.ToInt32(range[0]); k < (Convert.ToInt32(range[1])+1) && terminaThread==false; k++)
				{
					string stringMachineName = ip[0] + "." + ip[1] + "." + ip[2] + "." + k.ToString();
					try 
					{
						stringMachineName = System.Net.Dns.GetHostByAddress(stringMachineName).HostName;
						this.sysscan = stringMachineName;
						Invoke(new GetInfoDelegate(scanInfo),new object[]{stringMachineName,true});
						getSystemInfo(stringMachineName);
						Invoke(new GetInfoDelegate(scanInfo),new object[]{stringMachineName ,false});
					} 
					catch 
					{
						this.listBox1.Items.Add(stringMachineName + " is down");
					}
				}
			}
			else
				MessageBox.Show(this, "Incorrect");
			this.button1.Enabled = true;
			this.button3.Enabled = false;
			this.textBox1.Enabled = true;
			this.chkLogin.Enabled = true;
		}
		private  void scanInfo(string stringMachineName, bool starting)
		{
			if(starting)
			{
				this.dataGrid1.CaptionText = "Looking " + stringMachineName;
				this.statusPanel1.Text = "Looking " + stringMachineName;
				this.Update();
			}
			else
			{
				this.dataGrid1.CaptionText = "Hardware info";
				this.statusPanel1.Text = "Ready";
				this.Update();
			}
		}

		private  void getSystemInfo(string stringMachineName)
		{
			try
			{
				DataRow dr = this.dviSystems.Table.NewRow();

				foreach (ManagementObject mo in Consulta("SELECT * FROM Win32_OperatingSystem", stringMachineName))
				{
					dr["OS"] = mo["Caption"].ToString() + " " + mo["Version"].ToString();
					dr["ComputerName"] = mo["csname"].ToString();
				}
				if(terminaThread==true)
					return;

				foreach ( ManagementObject mo in Consulta("SELECT * FROM Win32_ComputerSystem", stringMachineName))
				{
					dr["Manufacturer"] = mo["Manufacturer"].ToString();
					dr["Model"] = mo["model"].ToString();
					dr["RAM"] = formatSize(Int64.Parse(mo["totalphysicalmemory"].ToString()), false);
					try 
					{
						dr["UserName"] = mo["UserName"].ToString();
					}
					catch 
					{
						dr["UserName"] = "";
					}
				}
				if(terminaThread==true)
					return;

				foreach ( ManagementObject mo in Consulta("SELECT * FROM Win32_processor", stringMachineName))
					dr["Processor"] = mo["Name"].ToString().Trim();
				if(terminaThread==true)
					return;

				foreach ( ManagementObject mo in Consulta("SELECT * FROM Win32_bios", stringMachineName))
					dr["SerialNumber"] = mo["SerialNumber"].ToString();
				if(terminaThread==true)
					return;

				if (this.dviSystems.Table.Rows.Contains(dr["ComputerName"]))
					Invoke(new addErrorDelegate(addError),new object[]{stringMachineName + " already in list"});
				else
				{
					dr["Status"] = (bool) true;
					Invoke(new addRowDelegate(addRow),new object[]{dr});
				}

			}
			catch (Exception er)
			{
				Invoke(new addErrorDelegate(addError),new object[]{er.ToString()});//"Failed in " + stringMachineName});
			}

		}
		#endregion

		#region Mein DB Methods

		private void UpdateDB()
		{
			this.Cursor = Cursors.WaitCursor;
			this.statusPanel1.Text = "Updating Database...";
			if (this.dataSys == "sql") 
			{
				try
				{
					this.sqlDataAdapter1.Update(this.userData1);
					this.sqlDataAdapter3.Update(this.userData1);
					this.sqlDataAdapter4.Update(this.userData1);
				} 
				catch
				{
					MessageBox.Show(this, "Can't Update DB", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			} 
			else 
			{
				this.SaveXML();
			}
			this.Cursor = Cursors.Default;
			this.statusPanel1.Text = "Ready";
			GC.Collect();
		}

		private void SaveXML()
		{
			XmlDocument xmldoc = new XmlDocument();
			xmldoc.LoadXml(this.userData1.GetXml());
			xmldoc.Save(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\HWD\\data.xml");
		}

		private void InitDB()
		{
			if (this.dataSys == "sql") 
			{
				this.sqlDataAdapter1.SelectCommand.Connection = this.sqlConnection1;
				this.sqlDataAdapter3.SelectCommand.Connection = this.sqlConnection1;
				this.sqlDataAdapter4.SelectCommand.Connection = this.sqlConnection1;
				this.sqlDataAdapter1.InsertCommand.Connection = this.sqlConnection1;
				this.sqlDataAdapter3.InsertCommand.Connection = this.sqlConnection1;
				this.sqlDataAdapter4.InsertCommand.Connection = this.sqlConnection1;
				this.sqlDataAdapter1.DeleteCommand.Connection = this.sqlConnection1;
				this.sqlDataAdapter3.DeleteCommand.Connection = this.sqlConnection1;
				this.sqlDataAdapter4.DeleteCommand.Connection = this.sqlConnection1;
				this.sqlDataAdapter1.UpdateCommand.Connection = this.sqlConnection1;
				this.sqlDataAdapter3.UpdateCommand.Connection = this.sqlConnection1;
				this.sqlDataAdapter4.UpdateCommand.Connection = this.sqlConnection1;
				this.sqlDataAdapter1.Fill(this.userData1);
				this.sqlDataAdapter3.Fill(this.userData1);
				this.sqlDataAdapter4.Fill(this.userData1);
			} 
			else 
			{
				try 
				{
					this.userData1.ReadXml(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\HWD\\data.xml");

				}
				catch 
				{
					this.SaveXML();
				}
			}
			this.PopulateListView();
		}

		private void PopulateListView()
		{
			this.listView1.Items.Clear();
			foreach (DataRow hr in this.dviSystems.Table.Rows)
			{
				string[] dat = new string[5];
				dat[0] = hr["ComputerName"].ToString();
				dat[1] = hr["Model"].ToString();
				dat[2] = hr["Manufacturer"].ToString();
				dat[3] = hr["SerialNumber"].ToString();
				dat[4] = hr["OS"].ToString();
				ListViewItem lv = new ListViewItem(dat,0);
				this.listView1.Items.Add(lv);
			}
		}

		#endregion

		#region Mein Handlers
		private void button1_Click(object sender, System.EventArgs e)
		{
			this.doScan(this.textBox1.Text);
		}
		private void button2_Click(object sender, System.EventArgs e)
		{
			this.UpdateDB();
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			this.terminaThread = true;
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			this.statusPanel1.Text = "Getting info from system...";
			string name;
			if (sender.GetType() == dataGrid1.GetType()) 
			{
				Point pt = dataGrid1.PointToClient(rightMouseDownPoint); 
				name = dataGrid1[dataGrid1.HitTest(pt).Row, 2].ToString();
			} 
			else 
			{
				name = tItem.SubItems[0].Text;
			}
			Details dl = new Details();
			dl.name = name;
			dl.hotfixfile = this.hotfixfile;
			HWD.Details.anotherLogin = this.chkLogin.Checked;
			HWD.Details.username = this.txtUser.Text;
			HWD.Details.password = this.txtPass.Text;
			dl.rsxmgr = this.m_ResourceManager;
			dl.ShowDialog();
			this.Cursor = Cursors.Default;
			this.statusPanel1.Text = "Ready";
		}

		private void dataGrid1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			rightMouseDownPoint = Cursor.Position; 
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

		private void Form1_Load(object sender, System.EventArgs e)
		{
			this.comboBox1.SelectedIndex = 2;
			this.fsplash.timer1.Enabled = true;
			this.InitDB();
			this.dataGridTableStyle2.MappingName = this.dviSystems.Table.TableName;
			this.dataColumLocation.ComboBox.DataSource = this.userData1.Tables["LWD"];
			this.dataColumLocation.ComboBox.DisplayMember = "LocationName";
			this.dataColumLocation.ComboBox.ValueMember = "IDLocation";
			this.dataColumKind.ComboBox.DataSource = this.userData1.Tables["KWD"];
			this.dataColumKind.ComboBox.DisplayMember = "KindName";
			this.dataColumKind.ComboBox.ValueMember = "IDKind";
			this.panel2.Height = this.Height - 200;
			this.tabControl1.Height = this.panel2.Height - 32;
			this.statusPanel2.Text = this.dviSystems.Count.ToString() + " records";
			this.InitOptions();
			this.Show();
			this.label15.Text = Application.ProductVersion;
			if (this.doScanOnLoad)
			{
				this.doScan(this.sysscanOnLoad);
			}
		}

		private void Form1_Resize(object sender, System.EventArgs e)
		{
			this.panel2.Height = this.Height - 200;
			this.tabControl1.Height = this.panel2.Height - 32;
		}
		private void button5_Click(object sender, System.EventArgs e)
		{
			this.listBox1.Items.Clear();
		}

		private void button6_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			this.statusPanel1.Text = "Saving XML Data File...";
			this.saveXML.ShowDialog(this);
			if(this.saveXML.FileName.Length > 2)
			{
				XmlDocument xmldoc = new XmlDocument();
				xmldoc.LoadXml(this.userData1.GetXml());
				xmldoc.Save(this.saveXML.FileName);
			}
			this.Cursor = Cursors.Default;
			this.statusPanel1.Text = "Ready";
		}

		private void button7_Click(object sender, System.EventArgs e)
		{
			if (this.cboField.SelectedIndex == -1 )
				return;
			if (this.cboField.SelectedItem.ToString() == "Location")
			{

				this.dviTemp.Table = this.userData1.Tables["LWD"];
				this.dviTemp.RowFilter = "LocationName like '%" + this.txtFilter.Text + "%'";
				if (this.dviTemp.Count > 0) 
					this.dviSystems.RowFilter = "IDLocation = " + this.dviTemp[0]["IDLocation"];
			} 
			else if (this.cboField.SelectedItem.ToString() == "Kind")
			{
				this.dviTemp.Table = this.userData1.Tables["KWD"];
				this.dviTemp.RowFilter = "KindName like '%" + this.txtFilter.Text + "%'";
				if (this.dviTemp.Count > 0) 
					this.dviSystems.RowFilter = "IDKind = " + this.dviTemp[0]["IDKind"];
			}
			else 
			{
				if (this.cboOperator.SelectedItem.ToString() == "like") 
					this.dviSystems.RowFilter = this.cboField.SelectedItem.ToString() + " like '%" + this.txtFilter.Text + "%'";
				else 
					this.dviSystems.RowFilter = this.cboField.SelectedItem.ToString() + " " + this.cboOperator.SelectedItem.ToString() + " '" + this.txtFilter.Text + "'";
			}
			this.PopulateListView();
			this.statusPanel2.Text = this.dviSystems.Count.ToString() + " records";
			this.button8.Enabled = true;
		}

		private void button8_Click(object sender, System.EventArgs e)
		{
			this.dviSystems.RowFilter = "";
			this.PopulateListView();
			this.statusPanel2.Text = this.dviSystems.Count.ToString() + " records";
			this.button8.Enabled = false;
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			string name;
			if (sender.GetType() == dataGrid1.GetType()) 
			{
				Point pt = dataGrid1.PointToClient(rightMouseDownPoint); 
				name = dataGrid1[dataGrid1.HitTest(pt).Row, 2].ToString();
				DialogResult dr = MessageBox.Show(this, "Really wants to delete the system entry " + name, "Delete Entry", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dr == DialogResult.Yes)
				{
					this.dviSystems.Delete(dataGrid1.HitTest(pt).Row);
					this.UpdateDB();
				}
			}
		}

		private void button10_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			try
			{
				ReportHWD tmpRep = new ReportHWD();
				tmpRep.dataview = this.dviSystems;
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

		private void chkLogin_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.chkLogin.Checked == true)
			{
				this.txtUser.Visible = true;
				this.txtPass.Visible = true;
				this.lblUser.Visible = true;
				this.lblPass.Visible = true;
			} 
			else 
			{
				this.txtUser.Visible = false;
				this.txtPass.Visible = false;
				this.lblUser.Visible = false;
				this.lblPass.Visible = false;
			}
		}
        
		private void button3_Click1(object sender, System.EventArgs e)
		{
			this.button1.Enabled = true;
			this.button3.Enabled = false;
			this.textBox1.Enabled = true;
			this.chkLogin.Enabled = true;
			terminaThread  = true;
  			th.Join(0);
		}

		private void button9_Click(object sender, System.EventArgs e)
		{
			if (this.chkAutoSave.Checked) 
				this.xmldoc.FirstChild["AutoSave"].InnerText = "1";
			else 
				this.xmldoc.FirstChild["AutoSave"].InnerText = "0";

			if (this.radioSpanish.Checked) 
				this.xmldoc.FirstChild["Language"].InnerText = "es-MX";
			else 
				this.xmldoc.FirstChild["Language"].InnerText = "en-US";

			this.xmldoc.Save(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\HWD\\config.xml");
	}

		private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			this.UpdateDB();
			if (this.dataSys == "sql") 
				this.SaveXML();
		}

		private void button11_Click(object sender, System.EventArgs e)
		{
			Reporter rpr = new Reporter();
			rpr.anotherLogin = this.chkLogin.Checked;
			rpr.username = this.txtUser.Text;
			rpr.password = this.txtPass.Text;
			rpr.dataSet = this.userData1;
			rpr.rsxmgr = this.m_ResourceManager;
			rpr.ShowDialog(this);
		}

		private void button12_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			HWD.HotFixUpdaterForm hfForm = new HotFixUpdaterForm();
			hfForm.ShowDialog(this);
			if(hfForm.DialogResult != DialogResult.Cancel)
			{
				this.txthotdate.Text = File.GetLastWriteTime("hwdhf.xml").ToShortDateString();
				this.hotfixfile = true;
			}
			this.Cursor = Cursors.Default;
		}

		private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
		{
			Thread.CurrentThread.CurrentUICulture = this.m_EnglishCulture;
			this.UpdateUI();
		}

		private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
		{
			Thread.CurrentThread.CurrentUICulture = this.m_SpanishCulture;
			this.UpdateUI();
		}

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			ProcessStartInfo pr = new System.Diagnostics.ProcessStartInfo("explorer", "http://www.hailstan.com/hwd");
			pr.WindowStyle = ProcessWindowStyle.Normal;
			Process.Start(pr);
		}

		private void mnRemote_Click(object sender, System.EventArgs e)
		{
			this.runClient("mstsc", "/v:", sender.GetType());
		}

		private void mnMan_Click(object sender, System.EventArgs e)
		{
			this.runClient("mmc.exe", @"%windir%\system32\compmgmt.msc /computer=", sender.GetType());
		}

		private void tabControl2_SelectionChanged(Crownwood.DotNetMagic.Controls.TabControl sender, Crownwood.DotNetMagic.Controls.TabPage oldPage, Crownwood.DotNetMagic.Controls.TabPage newPage)
		{
		
		}

		private void buttonWithStyle1_Click(object sender, System.EventArgs e)
		{
			if (this.textBox2.Text != string.Empty) 
			{
				DataRow drl = this.userData1.LWD.NewRow();
				drl["LocationName"] = this.textBox2.Text;
				this.userData1.LWD.Rows.Add(drl);
				this.textBox2.Text = "";
			}
		}

		private void buttonWithStyle4_Click(object sender, System.EventArgs e)
		{
			if (this.textBox3.Text != string.Empty) 
			{
				DataRow drl = this.userData1.KWD.NewRow();
				drl["KindName"] = this.textBox3.Text;
				this.userData1.KWD.Rows.Add(drl);
				this.textBox3.Text = "";
			}
		}

		private void buttonWithStyle2_Click(object sender, System.EventArgs e)
		{
			if (this.userData1.LWD.Rows.Count >= 1)
				this.userData1.LWD.Rows.RemoveAt(this.listBox2.SelectedIndex);
		}

		private void buttonWithStyle3_Click(object sender, System.EventArgs e)
		{
			if (this.userData1.KWD.Rows.Count >= 1)
				this.userData1.KWD.Rows.RemoveAt(this.listBox3.SelectedIndex);
		}

		private void buttonWithStyle5_Click(object sender, System.EventArgs e)
		{
			if (this.dataSys == "sql") 
			{
				HWD.Apps apps = new Apps();
				apps.sqlCon = this.sqlConnection1;
				apps.ShowDialog(this);
			} 
			else { MessageBox.Show("You are using Offline System, this feature is not allowed"); }
		}

		private void Mein_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			Application.Exit();
		}
		
		private void listView1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			System.Windows.Forms.ListView listViewObject = (System.Windows.Forms.ListView) sender;

			if (e.Button == System.Windows.Forms.MouseButtons.Right) 
			{
				try 
				{
					tItem = listViewObject.GetItemAt(e.X,e.Y);
					if (tItem.Index > -1)
					{
						listViewObject.ContextMenu = this.contextMenu1;
					}
				} 
				catch 
				{

				}
			}
		}

		private void buttonWithStyle6_Click(object sender, System.EventArgs e)
		{
			if(this.dataSys == "sql") 
			{
				HWD.Techs techs = new Techs();
				techs.sqlCon = this.sqlConnection1;
				techs.ShowDialog(this);
			} 
			else { MessageBox.Show("Techinics form can be displayed offline"); }
		}

		#endregion

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("RUN CWDeploy here");
		}
	}
}
