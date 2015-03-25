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

namespace HWD
{   public delegate void GetInfoDelegate(string machine, bool starting);
    public delegate void addRowDelegate(DataRow r);
    public delegate void addErrorDelegate(string msg);

	public class Mein : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		internal System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private Point rightMouseDownPoint;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.SaveFileDialog saveXML;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.TextBox txtFilter;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.ComboBox cboOperator;
		private System.Windows.Forms.ComboBox cboField;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Data.DataView dviSystems;
		private System.Windows.Forms.Button button10;
		private ReportPrinting.ReportDocument reportDocument1;
		private System.Data.DataTable AccessDataTypes;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand2;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand2;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand2;
		private System.Data.DataView dviSoftwares;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand3;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand3;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand3;
		private HWD.userData userData1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.DataGridBoolColumn dataGridStatusColumn;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand4;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand4;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand4;
		private HWD.DataGridComboBoxColumn dataColumLocation;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		private HWD.DataGridComboBoxColumn dataColumKind;
		private System.Data.DataView dviTemp;
		private System.Windows.Forms.TextBox txtUser;
		private System.Windows.Forms.TextBox txtPass;
		private System.Windows.Forms.CheckBox chkLogin;
		private System.Windows.Forms.Label lblUser;
		private System.Windows.Forms.Label lblPass;
		private System.Windows.Forms.TabPage tabPage5;
        private Thread th;
        private bool terminaThread;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.CheckBox chkAutoSave;
		private System.Timers.Timer timer1;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.TabPage tabPage6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txthotdate;
		private System.Xml.XmlDocument xmldoc = new XmlDocument();
		private bool hotfixfile = false;
		private ManagementObjectSearcher query;
		private ManagementObjectCollection queryCollection;
		private System.Management.ObjectQuery oq;
		private ConnectionOptions co = new ConnectionOptions();
		private ResourceManager     m_ResourceManager = new ResourceManager("HWD.Localization", 
			System.Reflection.Assembly.GetExecutingAssembly());
		private CultureInfo         m_EnglishCulture = new CultureInfo("en-US");
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.RadioButton radioEnglish;
		private System.Windows.Forms.RadioButton radioSpanish;
		private CultureInfo         m_SpanishCulture = new CultureInfo("es-MX");
		private HWD.splash fsplash;
		private NumberFormatInfo myNfi = new NumberFormatInfo();
		private System.Windows.Forms.CheckBox chkXML;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private string dataSys;


		public Mein(System.Data.SqlClient.SqlConnection sqlConn, string type)
		{	
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
        {
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Mein));
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.dviSystems = new System.Data.DataView();
			this.userData1 = new HWD.userData();
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
			this.AccessDataTypes = new System.Data.DataTable();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.button3 = new System.Windows.Forms.Button();
			this.lblPass = new System.Windows.Forms.Label();
			this.lblUser = new System.Windows.Forms.Label();
			this.txtPass = new System.Windows.Forms.TextBox();
			this.txtUser = new System.Windows.Forms.TextBox();
			this.chkLogin = new System.Windows.Forms.CheckBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.button11 = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.chkXML = new System.Windows.Forms.CheckBox();
			this.radioSpanish = new System.Windows.Forms.RadioButton();
			this.label7 = new System.Windows.Forms.Label();
			this.radioEnglish = new System.Windows.Forms.RadioButton();
			this.txthotdate = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.button12 = new System.Windows.Forms.Button();
			this.chkAutoSave = new System.Windows.Forms.CheckBox();
			this.button9 = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.button5 = new System.Windows.Forms.Button();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.label5 = new System.Windows.Forms.Label();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtFilter = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cboField = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cboOperator = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.button8 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.saveXML = new System.Windows.Forms.SaveFileDialog();
			this.reportDocument1 = new ReportPrinting.ReportDocument();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand2 = new System.Data.SqlClient.SqlCommand();
			this.dviSoftwares = new System.Data.DataView();
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
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dviSystems)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.userData1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.AccessDataTypes)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dviSoftwares)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dviTemp)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.timer1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGrid1
			// 
			this.dataGrid1.AlternatingBackColor = System.Drawing.Color.OldLace;
			this.dataGrid1.BackColor = System.Drawing.Color.OldLace;
			this.dataGrid1.BackgroundColor = System.Drawing.Color.Tan;
			this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid1.CaptionBackColor = System.Drawing.Color.SaddleBrown;
			this.dataGrid1.CaptionForeColor = System.Drawing.Color.OldLace;
			this.dataGrid1.CaptionText = "Hardware Info";
			this.dataGrid1.ContextMenu = this.contextMenu1;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.DataSource = this.dviSystems;
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dataGrid1.FlatMode = true;
			this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8F);
			this.dataGrid1.ForeColor = System.Drawing.Color.DarkSlateGray;
			this.dataGrid1.GridLineColor = System.Drawing.Color.Tan;
			this.dataGrid1.HeaderBackColor = System.Drawing.Color.Wheat;
			this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.dataGrid1.HeaderForeColor = System.Drawing.Color.SaddleBrown;
			this.dataGrid1.LinkColor = System.Drawing.Color.DarkSlateBlue;
			this.dataGrid1.Location = new System.Drawing.Point(0, 120);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.OldLace;
			this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.DarkSlateGray;
			this.dataGrid1.PreferredColumnWidth = 85;
			this.dataGrid1.SelectionBackColor = System.Drawing.Color.SlateGray;
			this.dataGrid1.SelectionForeColor = System.Drawing.Color.White;
			this.dataGrid1.Size = new System.Drawing.Size(855, 400);
			this.dataGrid1.TabIndex = 0;
			this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle2});
			this.dataGrid1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGrid1_MouseDown);
			this.dataGrid1.DoubleClick += new System.EventHandler(this.menuItem1_Click);
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem1,
																						 this.menuItem2,
																						 this.menuItem3});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "Details";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "-";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.Text = "Delete";
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
			// dataGridTableStyle2
			// 
			this.dataGridTableStyle2.AlternatingBackColor = System.Drawing.Color.OldLace;
			this.dataGridTableStyle2.BackColor = System.Drawing.Color.OldLace;
			this.dataGridTableStyle2.DataGrid = this.dataGrid1;
			this.dataGridTableStyle2.ForeColor = System.Drawing.Color.DarkSlateGray;
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
			this.dataGridTableStyle2.GridLineColor = System.Drawing.Color.Tan;
			this.dataGridTableStyle2.HeaderBackColor = System.Drawing.Color.Wheat;
			this.dataGridTableStyle2.HeaderForeColor = System.Drawing.Color.SaddleBrown;
			this.dataGridTableStyle2.LinkColor = System.Drawing.Color.DarkSlateBlue;
			this.dataGridTableStyle2.MappingName = "";
			this.dataGridTableStyle2.SelectionBackColor = System.Drawing.Color.SlateGray;
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
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.Color.OldLace;
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox1.Location = new System.Drawing.Point(8, 48);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(128, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "";
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.SaddleBrown;
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button1.ForeColor = System.Drawing.Color.OldLace;
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.button1.Location = new System.Drawing.Point(400, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(88, 80);
			this.button1.TabIndex = 2;
			this.button1.Text = "Look up";
			this.button1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.SaddleBrown;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button2.ForeColor = System.Drawing.Color.OldLace;
			this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
			this.button2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.button2.Location = new System.Drawing.Point(752, 8);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(88, 80);
			this.button2.TabIndex = 3;
			this.button2.Text = "Save Data";
			this.button2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// listBox1
			// 
			this.listBox1.BackColor = System.Drawing.Color.OldLace;
			this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listBox1.Location = new System.Drawing.Point(8, 8);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(736, 80);
			this.listBox1.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(136, 32);
			this.label1.TabIndex = 4;
			this.label1.Text = "Host Range or Machine Name:";
			// 
			// tabControl1
			// 
			this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage5);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage6);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(855, 120);
			this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
			this.tabControl1.TabIndex = 8;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.Color.Tan;
			this.tabPage1.Controls.Add(this.button3);
			this.tabPage1.Controls.Add(this.lblPass);
			this.tabPage1.Controls.Add(this.lblUser);
			this.tabPage1.Controls.Add(this.txtPass);
			this.tabPage1.Controls.Add(this.txtUser);
			this.tabPage1.Controls.Add(this.chkLogin);
			this.tabPage1.Controls.Add(this.textBox1);
			this.tabPage1.Controls.Add(this.button2);
			this.tabPage1.Controls.Add(this.button1);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.ImageIndex = 0;
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(847, 91);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Scan Systems";
			this.tabPage1.ToolTipText = "Scan Systems by IP Range";
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.Color.SaddleBrown;
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button3.ForeColor = System.Drawing.Color.OldLace;
			this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
			this.button3.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.button3.Location = new System.Drawing.Point(493, 7);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(87, 83);
			this.button3.TabIndex = 10;
			this.button3.Text = "Stop";
			this.button3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.button3.Click += new System.EventHandler(this.button3_Click1);
			// 
			// lblPass
			// 
			this.lblPass.Location = new System.Drawing.Point(176, 64);
			this.lblPass.Name = "lblPass";
			this.lblPass.Size = new System.Drawing.Size(64, 16);
			this.lblPass.TabIndex = 9;
			this.lblPass.Text = "Password:";
			this.lblPass.Visible = false;
			// 
			// lblUser
			// 
			this.lblUser.Location = new System.Drawing.Point(176, 32);
			this.lblUser.Name = "lblUser";
			this.lblUser.Size = new System.Drawing.Size(64, 16);
			this.lblUser.TabIndex = 8;
			this.lblUser.Text = "User:";
			this.lblUser.Visible = false;
			// 
			// txtPass
			// 
			this.txtPass.BackColor = System.Drawing.Color.OldLace;
			this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPass.Location = new System.Drawing.Point(248, 64);
			this.txtPass.Name = "txtPass";
			this.txtPass.PasswordChar = '*';
			this.txtPass.Size = new System.Drawing.Size(128, 20);
			this.txtPass.TabIndex = 7;
			this.txtPass.Text = "";
			this.txtPass.Visible = false;
			// 
			// txtUser
			// 
			this.txtUser.BackColor = System.Drawing.Color.OldLace;
			this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtUser.Location = new System.Drawing.Point(248, 32);
			this.txtUser.Name = "txtUser";
			this.txtUser.Size = new System.Drawing.Size(128, 20);
			this.txtUser.TabIndex = 6;
			this.txtUser.Text = "";
			this.txtUser.Visible = false;
			// 
			// chkLogin
			// 
			this.chkLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkLogin.Location = new System.Drawing.Point(176, 8);
			this.chkLogin.Name = "chkLogin";
			this.chkLogin.Size = new System.Drawing.Size(120, 24);
			this.chkLogin.TabIndex = 5;
			this.chkLogin.Text = "Use another login";
			this.chkLogin.CheckedChanged += new System.EventHandler(this.chkLogin_CheckedChanged);
			// 
			// tabPage3
			// 
			this.tabPage3.BackColor = System.Drawing.Color.Tan;
			this.tabPage3.Controls.Add(this.button11);
			this.tabPage3.Controls.Add(this.button10);
			this.tabPage3.Controls.Add(this.button6);
			this.tabPage3.Controls.Add(this.button4);
			this.tabPage3.ImageIndex = 1;
			this.tabPage3.Location = new System.Drawing.Point(4, 25);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(847, 91);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Reports";
			this.tabPage3.ToolTipText = "Reports";
			// 
			// button11
			// 
			this.button11.BackColor = System.Drawing.Color.SaddleBrown;
			this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button11.ForeColor = System.Drawing.Color.OldLace;
			this.button11.Image = ((System.Drawing.Image)(resources.GetObject("button11.Image")));
			this.button11.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.button11.Location = new System.Drawing.Point(200, 8);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(88, 80);
			this.button11.TabIndex = 12;
			this.button11.Text = "Reporter";
			this.button11.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// button10
			// 
			this.button10.BackColor = System.Drawing.Color.SaddleBrown;
			this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button10.ForeColor = System.Drawing.Color.OldLace;
			this.button10.Image = ((System.Drawing.Image)(resources.GetObject("button10.Image")));
			this.button10.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.button10.Location = new System.Drawing.Point(8, 8);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(88, 80);
			this.button10.TabIndex = 11;
			this.button10.Text = "Hardware";
			this.button10.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.button10.Click += new System.EventHandler(this.button10_Click);
			// 
			// button6
			// 
			this.button6.BackColor = System.Drawing.Color.SaddleBrown;
			this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button6.ForeColor = System.Drawing.Color.OldLace;
			this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
			this.button6.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.button6.Location = new System.Drawing.Point(752, 8);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(88, 80);
			this.button6.TabIndex = 9;
			this.button6.Text = "Export XML";
			this.button6.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button4
			// 
			this.button4.BackColor = System.Drawing.Color.SaddleBrown;
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button4.ForeColor = System.Drawing.Color.OldLace;
			this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
			this.button4.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.button4.Location = new System.Drawing.Point(104, 8);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(88, 80);
			this.button4.TabIndex = 8;
			this.button4.Text = "Software";
			this.button4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// tabPage5
			// 
			this.tabPage5.BackColor = System.Drawing.Color.Tan;
			this.tabPage5.Controls.Add(this.chkXML);
			this.tabPage5.Controls.Add(this.radioSpanish);
			this.tabPage5.Controls.Add(this.label7);
			this.tabPage5.Controls.Add(this.radioEnglish);
			this.tabPage5.Controls.Add(this.txthotdate);
			this.tabPage5.Controls.Add(this.label6);
			this.tabPage5.Controls.Add(this.button12);
			this.tabPage5.Controls.Add(this.chkAutoSave);
			this.tabPage5.Controls.Add(this.button9);
			this.tabPage5.Location = new System.Drawing.Point(4, 25);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new System.Drawing.Size(847, 91);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "Options";
			// 
			// chkXML
			// 
			this.chkXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkXML.Location = new System.Drawing.Point(8, 32);
			this.chkXML.Name = "chkXML";
			this.chkXML.Size = new System.Drawing.Size(120, 16);
			this.chkXML.TabIndex = 16;
			this.chkXML.Text = "AutoSave XML";
			// 
			// radioSpanish
			// 
			this.radioSpanish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioSpanish.Location = new System.Drawing.Point(144, 56);
			this.radioSpanish.Name = "radioSpanish";
			this.radioSpanish.Size = new System.Drawing.Size(104, 16);
			this.radioSpanish.TabIndex = 15;
			this.radioSpanish.Text = "Spanish";
			this.radioSpanish.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(136, 8);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(88, 16);
			this.label7.TabIndex = 14;
			this.label7.Text = "Language";
			// 
			// radioEnglish
			// 
			this.radioEnglish.Checked = true;
			this.radioEnglish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioEnglish.Location = new System.Drawing.Point(144, 32);
			this.radioEnglish.Name = "radioEnglish";
			this.radioEnglish.Size = new System.Drawing.Size(104, 16);
			this.radioEnglish.TabIndex = 13;
			this.radioEnglish.TabStop = true;
			this.radioEnglish.Text = "English";
			this.radioEnglish.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// txthotdate
			// 
			this.txthotdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txthotdate.Location = new System.Drawing.Point(368, 40);
			this.txthotdate.Name = "txthotdate";
			this.txthotdate.ReadOnly = true;
			this.txthotdate.Size = new System.Drawing.Size(128, 20);
			this.txthotdate.TabIndex = 12;
			this.txthotdate.Text = "No present";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(368, 8);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(88, 32);
			this.label6.TabIndex = 11;
			this.label6.Text = "Hotfixes definition date:";
			// 
			// button12
			// 
			this.button12.BackColor = System.Drawing.Color.SaddleBrown;
			this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button12.ForeColor = System.Drawing.Color.OldLace;
			this.button12.Image = ((System.Drawing.Image)(resources.GetObject("button12.Image")));
			this.button12.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.button12.Location = new System.Drawing.Point(520, 8);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(88, 80);
			this.button12.TabIndex = 10;
			this.button12.Text = "Get Definition";
			this.button12.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.button12.Click += new System.EventHandler(this.button12_Click);
			// 
			// chkAutoSave
			// 
			this.chkAutoSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkAutoSave.Location = new System.Drawing.Point(8, 8);
			this.chkAutoSave.Name = "chkAutoSave";
			this.chkAutoSave.Size = new System.Drawing.Size(120, 16);
			this.chkAutoSave.TabIndex = 5;
			this.chkAutoSave.Text = "AutoSave Data";
			// 
			// button9
			// 
			this.button9.BackColor = System.Drawing.Color.SaddleBrown;
			this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button9.ForeColor = System.Drawing.Color.OldLace;
			this.button9.Image = ((System.Drawing.Image)(resources.GetObject("button9.Image")));
			this.button9.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.button9.Location = new System.Drawing.Point(256, 8);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(88, 80);
			this.button9.TabIndex = 4;
			this.button9.Text = "Save Options";
			this.button9.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.Color.Tan;
			this.tabPage2.Controls.Add(this.button5);
			this.tabPage2.Controls.Add(this.listBox1);
			this.tabPage2.ImageIndex = 2;
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(847, 91);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Error Log";
			this.tabPage2.ToolTipText = "Error Log";
			// 
			// button5
			// 
			this.button5.BackColor = System.Drawing.Color.SaddleBrown;
			this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button5.ForeColor = System.Drawing.Color.OldLace;
			this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
			this.button5.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.button5.Location = new System.Drawing.Point(752, 8);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(88, 80);
			this.button5.TabIndex = 9;
			this.button5.Text = "Clear Log";
			this.button5.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// tabPage6
			// 
			this.tabPage6.BackColor = System.Drawing.Color.Tan;
			this.tabPage6.Controls.Add(this.label13);
			this.tabPage6.Controls.Add(this.label12);
			this.tabPage6.Controls.Add(this.label11);
			this.tabPage6.Controls.Add(this.label10);
			this.tabPage6.Controls.Add(this.label9);
			this.tabPage6.Controls.Add(this.label8);
			this.tabPage6.Controls.Add(this.pictureBox1);
			this.tabPage6.Controls.Add(this.linkLabel1);
			this.tabPage6.Controls.Add(this.label5);
			this.tabPage6.Location = new System.Drawing.Point(4, 25);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Size = new System.Drawing.Size(847, 91);
			this.tabPage6.TabIndex = 5;
			this.tabPage6.Text = "About..";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(96, 64);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(168, 16);
			this.label13.TabIndex = 8;
			this.label13.Text = "Coders: hxx and Iunknown";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(400, 72);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(184, 16);
			this.label12.TabIndex = 7;
			this.label12.Text = "CabinetFile of aplaxas";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(400, 56);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(184, 16);
			this.label11.TabIndex = 6;
			this.label11.Text = "ServerComboBox of Phil Bolduc ";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(400, 40);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(184, 16);
			this.label10.TabIndex = 5;
			this.label10.Text = "Line2D of Sivakumar Mahalingam";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(400, 24);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(160, 16);
			this.label9.TabIndex = 4;
			this.label9.Text = "Report Printing of Mike Mayer ";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(392, 8);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(168, 16);
			this.label8.TabIndex = 3;
			this.label8.Text = "This software uses classes from:";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(8, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(88, 80);
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point(96, 40);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(208, 24);
			this.linkLabel1.TabIndex = 1;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "http://workspaces.gotodotnet.com/hwd";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(96, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(208, 40);
			this.label5.TabIndex = 0;
			this.label5.Text = "HWD is an open source software under the OSL (Open Source License) v2.0.";
			// 
			// tabPage4
			// 
			this.tabPage4.BackColor = System.Drawing.Color.Tan;
			this.tabPage4.Controls.Add(this.groupBox1);
			this.tabPage4.Controls.Add(this.button8);
			this.tabPage4.Controls.Add(this.button7);
			this.tabPage4.Location = new System.Drawing.Point(4, 25);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(847, 91);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Filter";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtFilter);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.cboField);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.cboOperator);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(312, 80);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Expression Builder";
			// 
			// txtFilter
			// 
			this.txtFilter.BackColor = System.Drawing.Color.OldLace;
			this.txtFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtFilter.Location = new System.Drawing.Point(200, 32);
			this.txtFilter.Name = "txtFilter";
			this.txtFilter.TabIndex = 4;
			this.txtFilter.Text = "";
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
			this.cboField.BackColor = System.Drawing.Color.OldLace;
			this.cboField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
			this.cboField.Size = new System.Drawing.Size(96, 21);
			this.cboField.TabIndex = 6;
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
			this.cboOperator.BackColor = System.Drawing.Color.OldLace;
			this.cboOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboOperator.Items.AddRange(new object[] {
															 "=",
															 "<>",
															 "like"});
			this.cboOperator.Location = new System.Drawing.Point(120, 32);
			this.cboOperator.Name = "cboOperator";
			this.cboOperator.Size = new System.Drawing.Size(72, 21);
			this.cboOperator.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(200, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 10;
			this.label4.Text = "String";
			// 
			// button8
			// 
			this.button8.BackColor = System.Drawing.Color.SaddleBrown;
			this.button8.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button8.ForeColor = System.Drawing.Color.OldLace;
			this.button8.Image = ((System.Drawing.Image)(resources.GetObject("button8.Image")));
			this.button8.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.button8.Location = new System.Drawing.Point(424, 8);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(88, 80);
			this.button8.TabIndex = 5;
			this.button8.Text = "Clear Filters";
			this.button8.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// button7
			// 
			this.button7.BackColor = System.Drawing.Color.SaddleBrown;
			this.button7.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button7.ForeColor = System.Drawing.Color.OldLace;
			this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
			this.button7.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.button7.Location = new System.Drawing.Point(328, 8);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(88, 80);
			this.button7.TabIndex = 3;
			this.button7.Text = "Apply Filters";
			this.button7.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 518);
			this.statusBar.Name = "statusBar";
			this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						 this.statusBarPanel1,
																						 this.statusBarPanel2});
			this.statusBar.ShowPanels = true;
			this.statusBar.Size = new System.Drawing.Size(855, 15);
			this.statusBar.TabIndex = 9;
			// 
			// statusBarPanel1
			// 
			this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarPanel1.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
			this.statusBarPanel1.MinWidth = 100;
			this.statusBarPanel1.Text = "Ready";
			this.statusBarPanel1.Width = 778;
			// 
			// statusBarPanel2
			// 
			this.statusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.statusBarPanel2.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
			this.statusBarPanel2.Text = "0 records";
			this.statusBarPanel2.Width = 61;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.dataGrid1);
			this.panel1.Controls.Add(this.tabControl1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(855, 520);
			this.panel1.TabIndex = 10;
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
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.DeleteCommand = this.sqlDeleteCommand2;
			this.sqlDataAdapter2.InsertCommand = this.sqlInsertCommand2;
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "SWD", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("ID", "ID"),
																																																			 new System.Data.Common.DataColumnMapping("ComputerName", "ComputerName"),
																																																			 new System.Data.Common.DataColumnMapping("SoftwareName", "SoftwareName"),
																																																			 new System.Data.Common.DataColumnMapping("Version", "Version"),
																																																			 new System.Data.Common.DataColumnMapping("Vendor", "Vendor")})});
			this.sqlDataAdapter2.UpdateCommand = this.sqlUpdateCommand2;
			// 
			// sqlDeleteCommand2
			// 
			this.sqlDeleteCommand2.CommandText = @"DELETE FROM SWD WHERE (ID = @Original_ID) AND (ComputerName = @Original_ComputerName) AND (SoftwareName = @Original_SoftwareName) AND (Vendor = @Original_Vendor OR @Original_Vendor IS NULL AND Vendor IS NULL) AND (Version = @Original_Version OR @Original_Version IS NULL AND Version IS NULL)";
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ID", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ComputerName", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ComputerName", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SoftwareName", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SoftwareName", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Vendor", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Vendor", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Version", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Version", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand2
			// 
			this.sqlInsertCommand2.CommandText = "INSERT INTO SWD(ComputerName, SoftwareName, Version, Vendor) VALUES (@ComputerNam" +
				"e, @SoftwareName, @Version, @Vendor); SELECT ID, ComputerName, SoftwareName, Ver" +
				"sion, Vendor FROM SWD WHERE (ID = @@IDENTITY)";
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ComputerName", System.Data.SqlDbType.NVarChar, 50, "ComputerName"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SoftwareName", System.Data.SqlDbType.NVarChar, 50, "SoftwareName"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Version", System.Data.SqlDbType.VarChar, 20, "Version"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Vendor", System.Data.SqlDbType.VarChar, 20, "Vendor"));
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT ID, ComputerName, SoftwareName, Version, Vendor FROM SWD";
			// 
			// sqlUpdateCommand2
			// 
			this.sqlUpdateCommand2.CommandText = @"UPDATE SWD SET ComputerName = @ComputerName, SoftwareName = @SoftwareName, Version = @Version, Vendor = @Vendor WHERE (ID = @Original_ID) AND (ComputerName = @Original_ComputerName) AND (SoftwareName = @Original_SoftwareName) AND (Vendor = @Original_Vendor OR @Original_Vendor IS NULL AND Vendor IS NULL) AND (Version = @Original_Version OR @Original_Version IS NULL AND Version IS NULL); SELECT ID, ComputerName, SoftwareName, Version, Vendor FROM SWD WHERE (ID = @ID)";
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ComputerName", System.Data.SqlDbType.NVarChar, 50, "ComputerName"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SoftwareName", System.Data.SqlDbType.NVarChar, 50, "SoftwareName"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Version", System.Data.SqlDbType.VarChar, 20, "Version"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Vendor", System.Data.SqlDbType.VarChar, 20, "Vendor"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ID", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ComputerName", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ComputerName", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SoftwareName", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SoftwareName", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Vendor", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Vendor", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Version", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Version", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.Int, 4, "ID"));
			// 
			// dviSoftwares
			// 
			this.dviSoftwares.Sort = "ComputerName";
			this.dviSoftwares.Table = this.userData1.SWD;
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
			this.sqlDeleteCommand3.CommandText = "DELETE FROM LWD WHERE (IDLocation = @Original_IDLocation) AND (LocationName = @Or" +
				"iginal_LocationName OR @Original_LocationName IS NULL AND LocationName IS NULL)";
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IDLocation", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IDLocation", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LocationName", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LocationName", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand3
			// 
			this.sqlInsertCommand3.CommandText = "INSERT INTO LWD(LocationName) VALUES (@LocationName); SELECT IDLocation, Location" +
				"Name FROM LWD WHERE (IDLocation = @@IDENTITY)";
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LocationName", System.Data.SqlDbType.NVarChar, 20, "LocationName"));
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT IDLocation, LocationName FROM LWD";
			// 
			// sqlUpdateCommand3
			// 
			this.sqlUpdateCommand3.CommandText = @"UPDATE LWD SET LocationName = @LocationName WHERE (IDLocation = @Original_IDLocation) AND (LocationName = @Original_LocationName OR @Original_LocationName IS NULL AND LocationName IS NULL); SELECT IDLocation, LocationName FROM LWD WHERE (IDLocation = @IDLocation)";
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
																									  new System.Data.Common.DataTableMapping("Table", "KWD", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("IDKind", "IDKind"),
																																																			 new System.Data.Common.DataColumnMapping("KindName", "KindName")})});
			this.sqlDataAdapter4.UpdateCommand = this.sqlUpdateCommand4;
			// 
			// sqlDeleteCommand4
			// 
			this.sqlDeleteCommand4.CommandText = "DELETE FROM KWD WHERE (IDKind = @Original_IDKind) AND (KindName = @Original_KindN" +
				"ame OR @Original_KindName IS NULL AND KindName IS NULL)";
			this.sqlDeleteCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IDKind", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IDKind", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_KindName", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "KindName", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand4
			// 
			this.sqlInsertCommand4.CommandText = "INSERT INTO KWD(KindName) VALUES (@KindName); SELECT IDKind, KindName FROM KWD WH" +
				"ERE (IDKind = @@IDENTITY)";
			this.sqlInsertCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@KindName", System.Data.SqlDbType.VarChar, 10, "KindName"));
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "SELECT IDKind, KindName FROM KWD";
			// 
			// sqlUpdateCommand4
			// 
			this.sqlUpdateCommand4.CommandText = "UPDATE KWD SET KindName = @KindName WHERE (IDKind = @Original_IDKind) AND (KindNa" +
				"me = @Original_KindName OR @Original_KindName IS NULL AND KindName IS NULL); SEL" +
				"ECT IDKind, KindName FROM KWD WHERE (IDKind = @IDKind)";
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
			this.sqlDeleteCommand1.CommandText = @"DELETE FROM HWD WHERE (ComputerName = @Original_ComputerName) AND (ID = @Original_ID) AND (IDKind = @Original_IDKind OR @Original_IDKind IS NULL AND IDKind IS NULL) AND (IDLocation = @Original_IDLocation OR @Original_IDLocation IS NULL AND IDLocation IS NULL) AND (Manufacturer = @Original_Manufacturer OR @Original_Manufacturer IS NULL AND Manufacturer IS NULL) AND (Model = @Original_Model OR @Original_Model IS NULL AND Model IS NULL) AND (Notes = @Original_Notes OR @Original_Notes IS NULL AND Notes IS NULL) AND (OS = @Original_OS OR @Original_OS IS NULL AND OS IS NULL) AND (Processor = @Original_Processor OR @Original_Processor IS NULL AND Processor IS NULL) AND (RAM = @Original_RAM OR @Original_RAM IS NULL AND RAM IS NULL) AND (SerialNumber = @Original_SerialNumber OR @Original_SerialNumber IS NULL AND SerialNumber IS NULL) AND (Status = @Original_Status OR @Original_Status IS NULL AND Status IS NULL) AND (Username = @Original_Username OR @Original_Username IS NULL AND Username IS NULL)";
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
			this.sqlInsertCommand1.CommandText = @"INSERT INTO HWD(ComputerName, OS, Username, Manufacturer, Model, SerialNumber, RAM, Processor, IDKind, IDLocation, Status, Notes) VALUES (@ComputerName, @OS, @Username, @Manufacturer, @Model, @SerialNumber, @RAM, @Processor, @IDKind, @IDLocation, @Status, @Notes); SELECT ID, ComputerName, OS, Username, Manufacturer, Model, SerialNumber, RAM, Processor, IDKind, IDLocation, Status, Notes FROM HWD WHERE (ComputerName = @ComputerName)";
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
				"ocessor, IDKind, IDLocation, Status, Notes FROM HWD";
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE HWD SET ComputerName = @ComputerName, OS = @OS, Username = @Username, Manufacturer = @Manufacturer, Model = @Model, SerialNumber = @SerialNumber, RAM = @RAM, Processor = @Processor, IDKind = @IDKind, IDLocation = @IDLocation, Status = @Status, Notes = @Notes WHERE (ComputerName = @Original_ComputerName) AND (IDKind = @Original_IDKind OR @Original_IDKind IS NULL AND IDKind IS NULL) AND (IDLocation = @Original_IDLocation OR @Original_IDLocation IS NULL AND IDLocation IS NULL) AND (Manufacturer = @Original_Manufacturer OR @Original_Manufacturer IS NULL AND Manufacturer IS NULL) AND (Model = @Original_Model OR @Original_Model IS NULL AND Model IS NULL) AND (Notes = @Original_Notes OR @Original_Notes IS NULL AND Notes IS NULL) AND (OS = @Original_OS OR @Original_OS IS NULL AND OS IS NULL) AND (Processor = @Original_Processor OR @Original_Processor IS NULL AND Processor IS NULL) AND (RAM = @Original_RAM OR @Original_RAM IS NULL AND RAM IS NULL) AND (SerialNumber = @Original_SerialNumber OR @Original_SerialNumber IS NULL AND SerialNumber IS NULL) AND (Status = @Original_Status OR @Original_Status IS NULL AND Status IS NULL) AND (Username = @Original_Username OR @Original_Username IS NULL AND Username IS NULL); SELECT ID, ComputerName, OS, Username, Manufacturer, Model, SerialNumber, RAM, Processor, IDKind, IDLocation, Status, Notes FROM HWD WHERE (ComputerName = @ComputerName)";
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
			// Mein
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Tan;
			this.ClientSize = new System.Drawing.Size(855, 533);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(860, 560);
			this.Name = "Mein";
			this.Text = "HWD v0.9";
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dviSystems)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.userData1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.AccessDataTypes)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage6.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dviSoftwares)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dviTemp)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.timer1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

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
			this.tabPage1.Text = m_ResourceManager.GetString("tabPage1");
			this.tabPage2.Text = m_ResourceManager.GetString("tabPage2");
			this.tabPage3.Text = m_ResourceManager.GetString("tabPage3");
			this.tabPage5.Text = m_ResourceManager.GetString("tabPage5");
			this.tabPage6.Text = m_ResourceManager.GetString("tabPage6");
			this.tabPage4.Text = m_ResourceManager.GetString("tabPage4");
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
        }
        private void addError(string err)
        {
          this.listBox1.Items.Add(err);
        }
        private  void scanInfo(string stringMachineName, bool starting)
        {
         if(starting)
         {
           	this.Cursor = Cursors.WaitCursor;
		  	this.dataGrid1.CaptionText = "Looking " + stringMachineName;
		 	this.statusBarPanel1.Text = "Looking " + stringMachineName;
		 	this.Update();
         }
         else
         {
            this.dataGrid1.CaptionText = "Hardware info";
		   	this.statusBarPanel1.Text = "Ready";
		  	this.Update();
		   	this.Cursor = Cursors.Default;
         }
        }
		private  void getSystemInfo(string stringMachineName)
		{
            if(terminaThread==true)
                  return;
			try
			{
				DataRow dr = this.dviSystems.Table.NewRow();

				foreach ( ManagementObject mo in Consulta("SELECT * FROM Win32_OperatingSystem"))
				{
					dr["OS"] = mo["Caption"].ToString() + " " + mo["Version"].ToString();
					dr["ComputerName"] = mo["csname"].ToString();
				}
                if(terminaThread==true)
                  return;

				foreach ( ManagementObject mo in Consulta("SELECT * FROM Win32_ComputerSystem"))
				{
					dr["Manufacturer"] = mo["Manufacturer"].ToString();
					dr["Model"] = mo["model"].ToString();
					dr["RAM"] = formatSize(Int64.Parse(mo["totalphysicalmemory"].ToString()), false);
					dr["UserName"] = mo["UserName"].ToString();
				}
                if(terminaThread==true)
                  return;

				foreach ( ManagementObject mo in Consulta("SELECT * FROM Win32_processor"))
				{

					dr["Processor"] = mo["Manufacturer"].ToString() + mo["Caption"].ToString() + " " + formatSpeed(Int64.Parse(mo["MaxClockSpeed"].ToString()));
				}
                if(terminaThread==true)
                  return;

				foreach ( ManagementObject mo in Consulta("SELECT * FROM Win32_bios"))
				{
					dr["SerialNumber"] = mo["SerialNumber"].ToString();
				}
                if(terminaThread==true)
                  return;

				if (this.dviSystems.Table.Rows.Contains(dr["ComputerName"]))
				{
					this.listBox1.Items.Add(stringMachineName + " already in list");
				}
				else
				{
					dr["Status"] = (bool) true;
                    Invoke(new addRowDelegate(addRow),new object[]{dr});
				}

			}
			catch //(Exception erd)
			{
			//	MessageBox.Show(erd.ToString());
                Invoke(new addErrorDelegate(addError),new object[]{"Failed in " + stringMachineName});
			}

		}

		private string formatSize(Int64 lSize, bool booleanFormatOnly)
		{
			string stringSize = "";
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

		private string formatSpeed(Int64 lSpeed)
		{
			float floatSpeed = 0;
			string stringSpeed = "";

			if (lSpeed < 1000 ) 
			{
				stringSpeed = lSpeed.ToString() + "MHz";
			}
			else 
			{
				floatSpeed = (float) lSpeed / 1000;
				stringSpeed = floatSpeed.ToString() + "GHz";
			}

			return stringSpeed;

		}

		private void button1_Click(object sender, System.EventArgs e)
		{
         		th  = new Thread(new ThreadStart(Escanea));
         		th.IsBackground = true;
         		th.Start();
         		this.terminaThread  = false;
        }

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.UpdateDB();
		}

		private void UpdateDB()
		{
			this.Cursor = Cursors.WaitCursor;
			this.statusBarPanel1.Text = "Updating Database...";
			if (this.dataSys == "sql") 
			{
				try
				{
					this.sqlDataAdapter1.Update(this.userData1);
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
			this.statusBarPanel1.Text = "Ready";
		}

		private void SaveXML()
		{
			XmlDocument xmldoc = new XmlDocument();
			xmldoc.LoadXml(this.userData1.GetXml());
			xmldoc.Save(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\HWD\\data.xml");
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			this.dviSystems.Table.Clear();
			this.sqlDataAdapter1.Fill(this.userData1);
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			this.statusBarPanel1.Text = "Getting info from system...";
			Point pt = dataGrid1.PointToClient(rightMouseDownPoint); 
			try
			{
				int ID = (int) dataGrid1[dataGrid1.HitTest(pt).Row, 0];
				Details dl = new Details();
				dl.ID = ID;
				dl.hotfixfile = this.hotfixfile;
				dl.anotherLogin = this.chkLogin.Checked;
				dl.username = this.txtUser.Text;
				dl.password = this.txtPass.Text;
				dl.dataSet = this.userData1;
				dl.rsxmgr = this.m_ResourceManager;
				dl.ShowDialog();
				this.Cursor = Cursors.Default;
				this.statusBarPanel1.Text = "Ready";
				if(dl.DialogResult == DialogResult.OK)
				{
					this.userData1 = dl.dataSet;
					this.UpdateDB();
				}
				dl.Dispose();
			} 
			catch (Exception er)
			{
				this.Cursor = Cursors.Default;
				this.statusBarPanel1.Text = "Ready";
				this.listBox1.Items.Add("There isn't a item selected");
				MessageBox.Show(er.ToString());
			}
		}

		private void dataGrid1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			rightMouseDownPoint = Cursor.Position; 
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			this.fsplash.timer1.Enabled = true;
			this.InitDB();
			this.dataGridTableStyle2.MappingName = this.dviSystems.Table.TableName;
			this.dataColumLocation.ComboBox.DataSource = this.userData1.Tables["LWD"];
			this.dataColumLocation.ComboBox.DisplayMember = "LocationName";
			this.dataColumLocation.ComboBox.ValueMember = "IDLocation";
			this.dataColumKind.ComboBox.DataSource = this.userData1.Tables["KWD"];
			this.dataColumKind.ComboBox.DisplayMember = "KindName";
			this.dataColumKind.ComboBox.ValueMember = "IDKind";
			this.panel1.Height = this.Height - 44;
			this.dataGrid1.Height = this.Height - 164;
			this.statusBarPanel2.Text = this.dviSystems.Count.ToString() + " records";
			this.InitOptions();
			this.Show();
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
				this.userData1.Tables["HotFix"].Rows.Add(new object[] {0,0,0,0,0});
			}
		}
		private void InitDB()
		{
			if (this.dataSys == "sql") 
			{
				this.sqlDataAdapter1.SelectCommand.Connection = this.sqlConnection1;
				this.sqlDataAdapter2.SelectCommand.Connection = this.sqlConnection1;
				this.sqlDataAdapter3.SelectCommand.Connection = this.sqlConnection1;
				this.sqlDataAdapter4.SelectCommand.Connection = this.sqlConnection1;
				this.sqlDataAdapter1.InsertCommand.Connection = this.sqlConnection1;
				this.sqlDataAdapter2.InsertCommand.Connection = this.sqlConnection1;
				this.sqlDataAdapter3.InsertCommand.Connection = this.sqlConnection1;
				this.sqlDataAdapter4.InsertCommand.Connection = this.sqlConnection1;
				this.sqlDataAdapter1.DeleteCommand.Connection = this.sqlConnection1;
				this.sqlDataAdapter2.DeleteCommand.Connection = this.sqlConnection1;
				this.sqlDataAdapter3.DeleteCommand.Connection = this.sqlConnection1;
				this.sqlDataAdapter4.DeleteCommand.Connection = this.sqlConnection1;
				this.sqlDataAdapter1.UpdateCommand.Connection = this.sqlConnection1;
				this.sqlDataAdapter2.UpdateCommand.Connection = this.sqlConnection1;
				this.sqlDataAdapter3.UpdateCommand.Connection = this.sqlConnection1;
				this.sqlDataAdapter4.UpdateCommand.Connection = this.sqlConnection1;
				this.sqlDataAdapter1.Fill(this.userData1);
				this.sqlDataAdapter2.Fill(this.userData1);
				this.sqlDataAdapter3.Fill(this.userData1);
				this.sqlDataAdapter4.Fill(this.userData1);
			} 
			else 
			{
				try 
				{
					this.userData1.ReadXml("data.xml");
				}
				catch 
				{
					this.SaveXML();
				}
			}
		}

		private void Form1_Resize(object sender, System.EventArgs e)
		{
			this.panel1.Height = this.Height - 44;
			this.dataGrid1.Height = this.Height - 164;
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			try 
			{
				ReportSWD tmpRep = new ReportSWD();
				tmpRep.dataview = this.dviSoftwares;
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

		private void button5_Click(object sender, System.EventArgs e)
		{
			this.listBox1.Items.Clear();
		}

		private void button6_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			this.statusBarPanel1.Text = "Saving XML Data File...";
			this.saveXML.ShowDialog(this);
			if(this.saveXML.FileName.Length > 2)
			{
				XmlDocument xmldoc = new XmlDocument();
				xmldoc.LoadXml(this.userData1.GetXml());
				xmldoc.Save(this.saveXML.FileName);
			}
			this.Cursor = Cursors.Default;
			this.statusBarPanel1.Text = "Ready";
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
				{
					this.dviSystems.RowFilter = "IDLocation = " + this.dviTemp[0]["IDLocation"];
				}
			} 
			else if (this.cboField.SelectedItem.ToString() == "Kind")
			{
				this.dviTemp.Table = this.userData1.Tables["KWD"];
				this.dviTemp.RowFilter = "KindName like '%" + this.txtFilter.Text + "%'";
				if (this.dviTemp.Count > 0) 
				{
					this.dviSystems.RowFilter = "IDKind = " + this.dviTemp[0]["IDKind"];
				}
			}
			else 
			{
				if (this.cboOperator.SelectedItem.ToString() == "like") 
				{
					this.dviSystems.RowFilter = this.cboField.SelectedItem.ToString() + " like '%" + this.txtFilter.Text + "%'";
				} 
				else 
				{
					this.dviSystems.RowFilter = this.cboField.SelectedItem.ToString() + " " + this.cboOperator.SelectedItem.ToString() + " '" + this.txtFilter.Text + "'";
				}
			}
			this.statusBarPanel2.Text = this.dviSystems.Count.ToString() + " records";
		}

		private void button8_Click(object sender, System.EventArgs e)
		{
			this.dviSystems.RowFilter = "";
			this.statusBarPanel2.Text = this.dviSystems.Count.ToString() + " records";
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			Point pt = dataGrid1.PointToClient(rightMouseDownPoint);
			int ID = (int) dataGrid1[dataGrid1.HitTest(pt).Row, 0];
			string Name = dataGrid1[dataGrid1.HitTest(pt).Row, 2].ToString();
			DialogResult dr = MessageBox.Show(this, "Really wants to delete the system entry " + Name, "Delete Entry", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dr == DialogResult.Yes)
			{
				this.dviSystems.Delete(dataGrid1.HitTest(pt).Row);
				this.UpdateDB();
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
        public void Escanea()
        {
          if ((this.textBox1.Text.Length > 2) && (this.textBox1.Text.IndexOf('.') < 0))
			{

                   Invoke(new GetInfoDelegate(scanInfo),new object[]{textBox1.Text,true});
                   getSystemInfo(textBox1.Text);
                   Invoke(new GetInfoDelegate(scanInfo),new object[]{textBox1.Text,false});
			} 
			else if ((this.textBox1.Text.IndexOf('-') > 1) && (this.textBox1.Text.IndexOf('.') >= 2))
			{
				string[] ip = this.textBox1.Text.Split('.');
				string[] range = ip[3].Split('-');
			
				for (int k = Convert.ToInt32(range[0]); k < (Convert.ToInt32(range[1])+1) && terminaThread==false; k++)
				{
				   string stringMachineName = ip[0] + "." + ip[1] + "." + ip[2] + "." + k.ToString();
                   Invoke(new GetInfoDelegate(scanInfo),new object[]{stringMachineName,true});
                   getSystemInfo(stringMachineName);
                   Invoke(new GetInfoDelegate(scanInfo),new object[]{stringMachineName ,false});
				}
			}
			else
			{
				MessageBox.Show(this, "Incorrect");
			}
        }
		
		private void button3_Click1(object sender, System.EventArgs e)
		{
		   terminaThread  = true;
  		   th.Join(0);
		}

		private void button9_Click(object sender, System.EventArgs e)
		{
			if (this.chkAutoSave.Checked) 
			{
				this.xmldoc.FirstChild["AutoSave"].InnerText = "1";
			} 
			else 
			{
				this.xmldoc.FirstChild["AutoSave"].InnerText = "0";
			}
			if (this.radioSpanish.Checked) 
			{
				this.xmldoc.FirstChild["Language"].InnerText = "es-MX";
			} 
			else 
			{
				this.xmldoc.FirstChild["Language"].InnerText = "en-US";
			}
			this.xmldoc.Save(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\HWD\\config.xml");
	}

		private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			this.UpdateDB();
			if (this.dataSys == "sql") 
			{
				this.SaveXML();
			}
		}

		private void button11_Click(object sender, System.EventArgs e)
		{
			Reporter rpr = new Reporter();
			rpr.anotherLogin = this.chkLogin.Checked;
			rpr.username = this.txtUser.Text;
			rpr.password = this.txtPass.Text;
			rpr.dataSet = this.userData1;
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

		private System.Management.ManagementObjectCollection Consulta(string strQuery)
		{
			try
			{
				if (this.chkLogin.Checked && this.txtUser.Text.Length > 0)
				{
					co.Username = this.txtUser.Text;
					co.Password = this.txtPass.Text;
				}
				System.Management.ManagementScope ms = new System.Management.ManagementScope("\\\\" + this.textBox1.Text + "\\root\\cimv2", co);
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
			
		}

	}
}
