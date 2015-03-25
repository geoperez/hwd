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
		private Point rightMouseDownPoint;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button button3;
		private ManagementObjectSearcher query;
		private ManagementObjectCollection queryCollection;
		private System.Management.ObjectQuery oq;
		private System.Windows.Forms.Label label3;
		private ConnectionOptions co = new ConnectionOptions();
		private System.Windows.Forms.TextBox txtStatus;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TreeView treeSysInfo;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Diagnostics.PerformanceCounter performanceCounter1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Label label8;
		private System.Diagnostics.PerformanceCounter performanceCounter2;
		private System.Windows.Forms.Label label10;
		private ReportPrinting.ReportDocument reportDocument1;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox cboLocation;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cboKind;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtNotes;
		private System.Windows.Forms.ComboBox cboStatus;
		private System.Windows.Forms.GroupBox groupBox1;
		private HWD.userData userData1;
		private System.Data.DataView dviUser;
		private System.Data.DataView dviSoftware;
		private System.Windows.Forms.PictureBox graph1;
		private System.Windows.Forms.PictureBox graph2;
		private System.ComponentModel.IContainer components;
		private LineChart.Line2D gr1 = new Line2D();
		private LineChart.Line2D gr2 = new Line2D();
		private ArrayList arrX1 = new ArrayList();
		private ArrayList arrY1 = new ArrayList();
		private ArrayList arrX2 = new ArrayList();
		private ArrayList arrY2 = new ArrayList();
		private System.Windows.Forms.Label lblPer1;
		private System.Windows.Forms.Label lblPer2;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ListView listViewServiceslistView1;
		private int i = 0;
		private string ServiceName;
		private string ServiceAction;
		private System.Windows.Forms.TabPage tabPage6;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.TabPage tabPage7;
		private System.Windows.Forms.TabPage tabPage8;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.NumericUpDown upOne;
		private System.Windows.Forms.NumericUpDown upTwo;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		private System.Windows.Forms.ColumnHeader columnHeader15;
		private System.Windows.Forms.ColumnHeader columnHeader16;
		private System.Windows.Forms.CheckBox chkAll;
		private System.Windows.Forms.ProgressBar progressBar1;
		private ListViewItem ServiceItem;
		private bool stopScan = true;
		private ListViewItem lvItem;
		private long timeElapsed;
		private System.TimeSpan time;
		private System.Data.DataSet ds = new DataSet();
		private System.Windows.Forms.ColumnHeader columnHeader17;
		private System.Windows.Forms.ColumnHeader columnHeader18;
		private System.Windows.Forms.Button btnScan;
		private System.Windows.Forms.ListView lsvStatus;
		private System.Windows.Forms.TabPage tabPage9;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.ListView listView3;
		private System.Windows.Forms.ColumnHeader columnHeader24;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.ColumnHeader columnHeader20;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.ContextMenu cmnHotfix;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Data.DataView dviHotfix;
		private System.Data.DataSet tempds;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Data.DataTable dt;
		private ResourceManager m_ResourceManager;

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
			this.label1 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.dviUser = new System.Data.DataView();
			this.userData1 = new HWD.userData();
			this.button2 = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label12 = new System.Windows.Forms.Label();
			this.cboLocation = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cboKind = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtNotes = new System.Windows.Forms.TextBox();
			this.cboStatus = new System.Windows.Forms.ComboBox();
			this.button3 = new System.Windows.Forms.Button();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.treeSysInfo = new System.Windows.Forms.TreeView();
			this.button4 = new System.Windows.Forms.Button();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.lblPer2 = new System.Windows.Forms.Label();
			this.lblPer1 = new System.Windows.Forms.Label();
			this.graph2 = new System.Windows.Forms.PictureBox();
			this.graph1 = new System.Windows.Forms.PictureBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.button6 = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.button5 = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.dviSoftware = new System.Data.DataView();
			this.tabPage8 = new System.Windows.Forms.TabPage();
			this.dataGrid2 = new System.Windows.Forms.DataGrid();
			this.cmnHotfix = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.dviHotfix = new System.Data.DataView();
			this.button9 = new System.Windows.Forms.Button();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.listViewServiceslistView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.button7 = new System.Windows.Forms.Button();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.button8 = new System.Windows.Forms.Button();
			this.tabPage9 = new System.Windows.Forms.TabPage();
			this.listView3 = new System.Windows.Forms.ListView();
			this.columnHeader24 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader20 = new System.Windows.Forms.ColumnHeader();
			this.button11 = new System.Windows.Forms.Button();
			this.tabPage7 = new System.Windows.Forms.TabPage();
			this.button10 = new System.Windows.Forms.Button();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.chkAll = new System.Windows.Forms.CheckBox();
			this.lsvStatus = new System.Windows.Forms.ListView();
			this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
			this.label7 = new System.Windows.Forms.Label();
			this.btnScan = new System.Windows.Forms.Button();
			this.upTwo = new System.Windows.Forms.NumericUpDown();
			this.upOne = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.txtStatus = new System.Windows.Forms.TextBox();
			this.performanceCounter1 = new System.Diagnostics.PerformanceCounter();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.performanceCounter2 = new System.Diagnostics.PerformanceCounter();
			this.reportDocument1 = new ReportPrinting.ReportDocument();
			this.tempds = new System.Data.DataSet();
			((System.ComponentModel.ISupportInitialize)(this.dviUser)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.userData1)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dviSoftware)).BeginInit();
			this.tabPage8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dviHotfix)).BeginInit();
			this.tabPage4.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.tabPage9.SuspendLayout();
			this.tabPage7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.upTwo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.upOne)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.performanceCounter2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tempds)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.SaddleBrown;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.OldLace;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(624, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "-";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnCancel
			// 
			this.btnCancel.BackColor = System.Drawing.Color.SaddleBrown;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCancel.ForeColor = System.Drawing.Color.OldLace;
			this.btnCancel.Location = new System.Drawing.Point(528, 352);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 32);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "&Cancel";
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.SaddleBrown;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button1.ForeColor = System.Drawing.Color.OldLace;
			this.button1.Location = new System.Drawing.Point(440, 352);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 32);
			this.button1.TabIndex = 1;
			this.button1.Text = "&OK";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox1
			// 
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox1.Location = new System.Drawing.Point(248, 360);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(112, 20);
			this.textBox1.TabIndex = 3;
			this.textBox1.Text = "textBox1";
			this.textBox1.Visible = false;
			// 
			// userData1
			// 
			this.userData1.DataSetName = "userData";
			this.userData1.Locale = new System.Globalization.CultureInfo("es-MX");
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.SaddleBrown;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button2.ForeColor = System.Drawing.Color.OldLace;
			this.button2.Location = new System.Drawing.Point(496, 8);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(104, 31);
			this.button2.TabIndex = 5;
			this.button2.Text = "Scan &Software";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage5);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage8);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.tabPage6);
			this.tabControl1.Controls.Add(this.tabPage9);
			this.tabControl1.Controls.Add(this.tabPage7);
			this.tabControl1.Location = new System.Drawing.Point(0, 24);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(616, 320);
			this.tabControl1.TabIndex = 6;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.Color.Tan;
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Controls.Add(this.button3);
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(608, 291);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Hardware";
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.Tan;
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.cboLocation);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.cboKind);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.txtNotes);
			this.groupBox1.Controls.Add(this.cboStatus);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox1.Location = new System.Drawing.Point(8, 56);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(320, 184);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Misc";
			// 
			// label12
			// 
			this.label12.BackColor = System.Drawing.Color.Tan;
			this.label12.Location = new System.Drawing.Point(8, 64);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(100, 16);
			this.label12.TabIndex = 8;
			this.label12.Text = "Location:";
			// 
			// cboLocation
			// 
			this.cboLocation.BackColor = System.Drawing.Color.OldLace;
			this.cboLocation.DisplayMember = "Location";
			this.cboLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboLocation.Items.AddRange(new object[] {
															 "Guadalajara",
															 "Culiacan"});
			this.cboLocation.Location = new System.Drawing.Point(120, 56);
			this.cboLocation.Name = "cboLocation";
			this.cboLocation.Size = new System.Drawing.Size(121, 21);
			this.cboLocation.TabIndex = 7;
			this.cboLocation.ValueMember = "Location";
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.Tan;
			this.label6.Location = new System.Drawing.Point(8, 128);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 16);
			this.label6.TabIndex = 2;
			this.label6.Text = "Notes:";
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Tan;
			this.label4.Location = new System.Drawing.Point(8, 32);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 16);
			this.label4.TabIndex = 0;
			this.label4.Text = "Kind:";
			// 
			// cboKind
			// 
			this.cboKind.BackColor = System.Drawing.Color.OldLace;
			this.cboKind.DisplayMember = "Kind";
			this.cboKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboKind.Items.AddRange(new object[] {
														 "Workstation",
														 "Notebook",
														 "Server"});
			this.cboKind.Location = new System.Drawing.Point(120, 24);
			this.cboKind.Name = "cboKind";
			this.cboKind.Size = new System.Drawing.Size(121, 21);
			this.cboKind.TabIndex = 3;
			this.cboKind.ValueMember = "Kind";
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.Tan;
			this.label5.Location = new System.Drawing.Point(8, 96);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 16);
			this.label5.TabIndex = 1;
			this.label5.Text = "Status";
			// 
			// txtNotes
			// 
			this.txtNotes.BackColor = System.Drawing.Color.OldLace;
			this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtNotes.Location = new System.Drawing.Point(120, 120);
			this.txtNotes.Multiline = true;
			this.txtNotes.Name = "txtNotes";
			this.txtNotes.Size = new System.Drawing.Size(176, 56);
			this.txtNotes.TabIndex = 5;
			this.txtNotes.Text = "";
			// 
			// cboStatus
			// 
			this.cboStatus.BackColor = System.Drawing.Color.OldLace;
			this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboStatus.Items.AddRange(new object[] {
														   "Active",
														   "Inactive"});
			this.cboStatus.Location = new System.Drawing.Point(120, 88);
			this.cboStatus.Name = "cboStatus";
			this.cboStatus.Size = new System.Drawing.Size(120, 21);
			this.cboStatus.TabIndex = 4;
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.Color.SaddleBrown;
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button3.ForeColor = System.Drawing.Color.OldLace;
			this.button3.Location = new System.Drawing.Point(8, 8);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(104, 32);
			this.button3.TabIndex = 7;
			this.button3.Text = "&Report";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// tabPage3
			// 
			this.tabPage3.BackColor = System.Drawing.Color.Tan;
			this.tabPage3.Controls.Add(this.treeSysInfo);
			this.tabPage3.Controls.Add(this.button4);
			this.tabPage3.Location = new System.Drawing.Point(4, 25);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(608, 291);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "More Info";
			// 
			// treeSysInfo
			// 
			this.treeSysInfo.BackColor = System.Drawing.Color.OldLace;
			this.treeSysInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.treeSysInfo.ImageIndex = -1;
			this.treeSysInfo.Location = new System.Drawing.Point(8, 8);
			this.treeSysInfo.Name = "treeSysInfo";
			this.treeSysInfo.SelectedImageIndex = -1;
			this.treeSysInfo.Size = new System.Drawing.Size(480, 272);
			this.treeSysInfo.TabIndex = 10;
			// 
			// button4
			// 
			this.button4.BackColor = System.Drawing.Color.SaddleBrown;
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button4.ForeColor = System.Drawing.Color.OldLace;
			this.button4.Location = new System.Drawing.Point(496, 8);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(104, 32);
			this.button4.TabIndex = 9;
			this.button4.Text = "Sc&an System";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// tabPage5
			// 
			this.tabPage5.BackColor = System.Drawing.Color.Tan;
			this.tabPage5.Controls.Add(this.lblPer2);
			this.tabPage5.Controls.Add(this.lblPer1);
			this.tabPage5.Controls.Add(this.graph2);
			this.tabPage5.Controls.Add(this.graph1);
			this.tabPage5.Controls.Add(this.label10);
			this.tabPage5.Controls.Add(this.label8);
			this.tabPage5.Controls.Add(this.button6);
			this.tabPage5.Location = new System.Drawing.Point(4, 25);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new System.Drawing.Size(608, 291);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "Performance";
			// 
			// lblPer2
			// 
			this.lblPer2.BackColor = System.Drawing.Color.Black;
			this.lblPer2.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblPer2.ForeColor = System.Drawing.Color.GreenYellow;
			this.lblPer2.Location = new System.Drawing.Point(544, 192);
			this.lblPer2.Name = "lblPer2";
			this.lblPer2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lblPer2.Size = new System.Drawing.Size(56, 16);
			this.lblPer2.TabIndex = 16;
			this.lblPer2.Text = "0%";
			// 
			// lblPer1
			// 
			this.lblPer1.BackColor = System.Drawing.Color.Black;
			this.lblPer1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblPer1.ForeColor = System.Drawing.Color.GreenYellow;
			this.lblPer1.Location = new System.Drawing.Point(544, 72);
			this.lblPer1.Name = "lblPer1";
			this.lblPer1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lblPer1.Size = new System.Drawing.Size(56, 16);
			this.lblPer1.TabIndex = 15;
			this.lblPer1.Text = "0%";
			// 
			// graph2
			// 
			this.graph2.BackColor = System.Drawing.Color.Black;
			this.graph2.Location = new System.Drawing.Point(16, 192);
			this.graph2.Name = "graph2";
			this.graph2.Size = new System.Drawing.Size(584, 80);
			this.graph2.TabIndex = 14;
			this.graph2.TabStop = false;
			// 
			// graph1
			// 
			this.graph1.BackColor = System.Drawing.Color.Black;
			this.graph1.Location = new System.Drawing.Point(16, 72);
			this.graph1.Name = "graph1";
			this.graph1.Size = new System.Drawing.Size(584, 80);
			this.graph1.TabIndex = 13;
			this.graph1.TabStop = false;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(8, 168);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(136, 16);
			this.label10.TabIndex = 12;
			this.label10.Text = "CPU Usage";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 48);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(144, 16);
			this.label8.TabIndex = 9;
			this.label8.Text = "Memory Usage";
			// 
			// button6
			// 
			this.button6.BackColor = System.Drawing.Color.SaddleBrown;
			this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button6.ForeColor = System.Drawing.Color.OldLace;
			this.button6.Location = new System.Drawing.Point(496, 8);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(104, 32);
			this.button6.TabIndex = 8;
			this.button6.Text = "Ac&tivate";
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.Color.Tan;
			this.tabPage2.Controls.Add(this.button5);
			this.tabPage2.Controls.Add(this.button2);
			this.tabPage2.Controls.Add(this.dataGrid1);
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(608, 291);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Software";
			// 
			// button5
			// 
			this.button5.BackColor = System.Drawing.Color.SaddleBrown;
			this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button5.ForeColor = System.Drawing.Color.OldLace;
			this.button5.Location = new System.Drawing.Point(8, 8);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(104, 32);
			this.button5.TabIndex = 8;
			this.button5.Text = "R&eport";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// dataGrid1
			// 
			this.dataGrid1.AlternatingBackColor = System.Drawing.Color.OldLace;
			this.dataGrid1.BackColor = System.Drawing.Color.OldLace;
			this.dataGrid1.BackgroundColor = System.Drawing.Color.Tan;
			this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid1.CaptionBackColor = System.Drawing.Color.SaddleBrown;
			this.dataGrid1.CaptionForeColor = System.Drawing.Color.OldLace;
			this.dataGrid1.CaptionText = "Installed Software";
			this.dataGrid1.DataMember = "";
			this.dataGrid1.DataSource = this.dviSoftware;
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dataGrid1.FlatMode = true;
			this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8F);
			this.dataGrid1.ForeColor = System.Drawing.Color.DarkSlateGray;
			this.dataGrid1.GridLineColor = System.Drawing.Color.Tan;
			this.dataGrid1.HeaderBackColor = System.Drawing.Color.Wheat;
			this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.dataGrid1.HeaderForeColor = System.Drawing.Color.SaddleBrown;
			this.dataGrid1.LinkColor = System.Drawing.Color.DarkSlateBlue;
			this.dataGrid1.Location = new System.Drawing.Point(0, 51);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.OldLace;
			this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.DarkSlateGray;
			this.dataGrid1.PreferredColumnWidth = 85;
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.SelectionBackColor = System.Drawing.Color.SlateGray;
			this.dataGrid1.SelectionForeColor = System.Drawing.Color.White;
			this.dataGrid1.Size = new System.Drawing.Size(608, 240);
			this.dataGrid1.TabIndex = 6;
			// 
			// tabPage8
			// 
			this.tabPage8.BackColor = System.Drawing.Color.Tan;
			this.tabPage8.Controls.Add(this.dataGrid2);
			this.tabPage8.Controls.Add(this.button9);
			this.tabPage8.Location = new System.Drawing.Point(4, 25);
			this.tabPage8.Name = "tabPage8";
			this.tabPage8.Size = new System.Drawing.Size(608, 291);
			this.tabPage8.TabIndex = 8;
			this.tabPage8.Text = "Hotfixes";
			// 
			// dataGrid2
			// 
			this.dataGrid2.AlternatingBackColor = System.Drawing.Color.OldLace;
			this.dataGrid2.BackColor = System.Drawing.Color.OldLace;
			this.dataGrid2.BackgroundColor = System.Drawing.Color.Tan;
			this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid2.CaptionBackColor = System.Drawing.Color.SaddleBrown;
			this.dataGrid2.CaptionForeColor = System.Drawing.Color.OldLace;
			this.dataGrid2.CaptionText = "Hotfixes to Install";
			this.dataGrid2.ContextMenu = this.cmnHotfix;
			this.dataGrid2.DataMember = "";
			this.dataGrid2.DataSource = this.dviHotfix;
			this.dataGrid2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dataGrid2.FlatMode = true;
			this.dataGrid2.Font = new System.Drawing.Font("Tahoma", 8F);
			this.dataGrid2.ForeColor = System.Drawing.Color.DarkSlateGray;
			this.dataGrid2.GridLineColor = System.Drawing.Color.Tan;
			this.dataGrid2.HeaderBackColor = System.Drawing.Color.Wheat;
			this.dataGrid2.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.dataGrid2.HeaderForeColor = System.Drawing.Color.SaddleBrown;
			this.dataGrid2.LinkColor = System.Drawing.Color.DarkSlateBlue;
			this.dataGrid2.Location = new System.Drawing.Point(0, 51);
			this.dataGrid2.Name = "dataGrid2";
			this.dataGrid2.ParentRowsBackColor = System.Drawing.Color.OldLace;
			this.dataGrid2.ParentRowsForeColor = System.Drawing.Color.DarkSlateGray;
			this.dataGrid2.PreferredColumnWidth = 85;
			this.dataGrid2.ReadOnly = true;
			this.dataGrid2.SelectionBackColor = System.Drawing.Color.SlateGray;
			this.dataGrid2.SelectionForeColor = System.Drawing.Color.White;
			this.dataGrid2.Size = new System.Drawing.Size(608, 240);
			this.dataGrid2.TabIndex = 15;
			this.dataGrid2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGrid2_MouseDown);
			this.dataGrid2.DoubleClick += new System.EventHandler(this.menuItem1_Click);
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
			// button9
			// 
			this.button9.BackColor = System.Drawing.Color.SaddleBrown;
			this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button9.ForeColor = System.Drawing.Color.OldLace;
			this.button9.Location = new System.Drawing.Point(496, 8);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(104, 32);
			this.button9.TabIndex = 14;
			this.button9.Text = "Get Hotfixes";
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// tabPage4
			// 
			this.tabPage4.BackColor = System.Drawing.Color.Tan;
			this.tabPage4.Controls.Add(this.listViewServiceslistView1);
			this.tabPage4.Controls.Add(this.button7);
			this.tabPage4.Location = new System.Drawing.Point(4, 25);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(608, 291);
			this.tabPage4.TabIndex = 5;
			this.tabPage4.Text = "Services";
			// 
			// listViewServiceslistView1
			// 
			this.listViewServiceslistView1.BackColor = System.Drawing.Color.OldLace;
			this.listViewServiceslistView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listViewServiceslistView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																										this.columnHeader1,
																										this.columnHeader2,
																										this.columnHeader3,
																										this.columnHeader4});
			this.listViewServiceslistView1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.listViewServiceslistView1.FullRowSelect = true;
			this.listViewServiceslistView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewServiceslistView1.Location = new System.Drawing.Point(0, 43);
			this.listViewServiceslistView1.Name = "listViewServiceslistView1";
			this.listViewServiceslistView1.Size = new System.Drawing.Size(608, 248);
			this.listViewServiceslistView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.listViewServiceslistView1.TabIndex = 11;
			this.listViewServiceslistView1.View = System.Windows.Forms.View.Details;
			this.listViewServiceslistView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewServiceslistView1_MouseDown);
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
			// button7
			// 
			this.button7.BackColor = System.Drawing.Color.SaddleBrown;
			this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button7.ForeColor = System.Drawing.Color.OldLace;
			this.button7.Location = new System.Drawing.Point(496, 8);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(104, 32);
			this.button7.TabIndex = 10;
			this.button7.Text = "Get Services";
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// tabPage6
			// 
			this.tabPage6.BackColor = System.Drawing.Color.Tan;
			this.tabPage6.Controls.Add(this.listView1);
			this.tabPage6.Controls.Add(this.button8);
			this.tabPage6.Location = new System.Drawing.Point(4, 25);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Size = new System.Drawing.Size(608, 291);
			this.tabPage6.TabIndex = 6;
			this.tabPage6.Text = "Shared Items";
			// 
			// listView1
			// 
			this.listView1.BackColor = System.Drawing.Color.OldLace;
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
			this.listView1.Location = new System.Drawing.Point(0, 43);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(608, 248);
			this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.listView1.TabIndex = 13;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.DoubleClick += new System.EventHandler(this.menuItem2_Click);
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
			// button8
			// 
			this.button8.BackColor = System.Drawing.Color.SaddleBrown;
			this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button8.ForeColor = System.Drawing.Color.OldLace;
			this.button8.Location = new System.Drawing.Point(496, 8);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(104, 32);
			this.button8.TabIndex = 12;
			this.button8.Text = "Get Items";
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// tabPage9
			// 
			this.tabPage9.BackColor = System.Drawing.Color.Tan;
			this.tabPage9.Controls.Add(this.listView3);
			this.tabPage9.Controls.Add(this.button11);
			this.tabPage9.Location = new System.Drawing.Point(4, 25);
			this.tabPage9.Name = "tabPage9";
			this.tabPage9.Size = new System.Drawing.Size(608, 291);
			this.tabPage9.TabIndex = 9;
			this.tabPage9.Text = "Event Log";
			// 
			// listView3
			// 
			this.listView3.BackColor = System.Drawing.Color.OldLace;
			this.listView3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader24,
																						this.columnHeader10,
																						this.columnHeader12,
																						this.columnHeader20});
			this.listView3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.listView3.FullRowSelect = true;
			this.listView3.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView3.Location = new System.Drawing.Point(0, 43);
			this.listView3.Name = "listView3";
			this.listView3.Size = new System.Drawing.Size(608, 248);
			this.listView3.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.listView3.TabIndex = 16;
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
			// button11
			// 
			this.button11.BackColor = System.Drawing.Color.SaddleBrown;
			this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button11.ForeColor = System.Drawing.Color.OldLace;
			this.button11.Location = new System.Drawing.Point(496, 8);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(104, 32);
			this.button11.TabIndex = 13;
			this.button11.Text = "Get Log";
			this.button11.Click += new System.EventHandler(this.button11_Click_1);
			// 
			// tabPage7
			// 
			this.tabPage7.BackColor = System.Drawing.Color.Tan;
			this.tabPage7.Controls.Add(this.button10);
			this.tabPage7.Controls.Add(this.progressBar1);
			this.tabPage7.Controls.Add(this.chkAll);
			this.tabPage7.Controls.Add(this.lsvStatus);
			this.tabPage7.Controls.Add(this.label7);
			this.tabPage7.Controls.Add(this.btnScan);
			this.tabPage7.Controls.Add(this.upTwo);
			this.tabPage7.Controls.Add(this.upOne);
			this.tabPage7.Location = new System.Drawing.Point(4, 25);
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.Size = new System.Drawing.Size(608, 291);
			this.tabPage7.TabIndex = 7;
			this.tabPage7.Text = "Ports";
			// 
			// button10
			// 
			this.button10.BackColor = System.Drawing.Color.SaddleBrown;
			this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button10.ForeColor = System.Drawing.Color.OldLace;
			this.button10.Location = new System.Drawing.Point(496, 8);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(104, 32);
			this.button10.TabIndex = 18;
			this.button10.Text = "Load XML";
			this.button10.Click += new System.EventHandler(this.button10_Click);
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(8, 48);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(592, 24);
			this.progressBar1.TabIndex = 17;
			// 
			// chkAll
			// 
			this.chkAll.Enabled = false;
			this.chkAll.Location = new System.Drawing.Point(272, 16);
			this.chkAll.Name = "chkAll";
			this.chkAll.Size = new System.Drawing.Size(96, 24);
			this.chkAll.TabIndex = 16;
			this.chkAll.Text = "Show All";
			// 
			// lsvStatus
			// 
			this.lsvStatus.BackColor = System.Drawing.Color.OldLace;
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
			this.lsvStatus.Location = new System.Drawing.Point(0, 75);
			this.lsvStatus.Name = "lsvStatus";
			this.lsvStatus.Size = new System.Drawing.Size(608, 216);
			this.lsvStatus.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lsvStatus.TabIndex = 15;
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
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 16);
			this.label7.TabIndex = 14;
			this.label7.Text = "Port Range:";
			// 
			// btnScan
			// 
			this.btnScan.BackColor = System.Drawing.Color.SaddleBrown;
			this.btnScan.Enabled = false;
			this.btnScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnScan.ForeColor = System.Drawing.Color.OldLace;
			this.btnScan.Location = new System.Drawing.Point(384, 8);
			this.btnScan.Name = "btnScan";
			this.btnScan.Size = new System.Drawing.Size(104, 32);
			this.btnScan.TabIndex = 13;
			this.btnScan.Text = "Scan";
			this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
			// 
			// upTwo
			// 
			this.upTwo.Enabled = false;
			this.upTwo.Location = new System.Drawing.Point(168, 16);
			this.upTwo.Name = "upTwo";
			this.upTwo.Size = new System.Drawing.Size(80, 20);
			this.upTwo.TabIndex = 1;
			// 
			// upOne
			// 
			this.upOne.Enabled = false;
			this.upOne.Location = new System.Drawing.Point(80, 16);
			this.upOne.Name = "upOne";
			this.upOne.Size = new System.Drawing.Size(80, 20);
			this.upOne.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 360);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 16);
			this.label3.TabIndex = 8;
			this.label3.Text = "Status";
			// 
			// txtStatus
			// 
			this.txtStatus.BackColor = System.Drawing.Color.Red;
			this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtStatus.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.txtStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtStatus.ForeColor = System.Drawing.Color.White;
			this.txtStatus.Location = new System.Drawing.Point(56, 360);
			this.txtStatus.Name = "txtStatus";
			this.txtStatus.ReadOnly = true;
			this.txtStatus.TabIndex = 9;
			this.txtStatus.TabStop = false;
			this.txtStatus.Text = "Offline";
			this.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
			// Details
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Tan;
			this.ClientSize = new System.Drawing.Size(616, 391);
			this.Controls.Add(this.txtStatus);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(622, 416);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(622, 416);
			this.Name = "Details";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "HWD - Details";
			this.Load += new System.EventHandler(this.Details_Load);
			((System.ComponentModel.ISupportInitialize)(this.dviUser)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.userData1)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dviSoftware)).EndInit();
			this.tabPage8.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dviHotfix)).EndInit();
			this.tabPage4.ResumeLayout(false);
			this.tabPage6.ResumeLayout(false);
			this.tabPage9.ResumeLayout(false);
			this.tabPage7.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.upTwo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.upOne)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.performanceCounter2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tempds)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void UpdateUI()
		{
			this.button2.Text = m_ResourceManager.GetString("dbutton2");
			this.button3.Text = m_ResourceManager.GetString("dbtnReport");
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
			this.InitGraph();
			if (this.anotherLogin == true && this.username.Length > 0)
			{
				co.Username = this.username;
				co.Password = this.password;
			}
			System.Management.ManagementScope ms = new System.Management.ManagementScope("\\\\" + this.textBox1.Text + "\\root\\cimv2", co);
			try 
			{
				oq = new System.Management.ObjectQuery("SELECT * FROM Win32_NetworkAdapter");
				query = new ManagementObjectSearcher(ms,oq);

				queryCollection = query.Get();
				this.txtStatus.BackColor = Color.Green;
				this.txtStatus.Text = "Online";
			} 
			catch 
			{
				MessageBox.Show(this, "Failed connection to system.\nScans are disable.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				this.button2.Enabled = false;
				this.button4.Enabled = false;
				this.button6.Enabled = false;
				this.button9.Enabled = false;
				this.button10.Enabled = false;
				this.btnScan.Enabled = false;
			}

			if (!this.hotfixfile)
			{
				this.button9.Enabled = false;
			}

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
			this.label1.Text = "System Details - " + this.dviUser[0]["ComputerName"].ToString();
			this.textBox1.Text = this.dviUser[0]["ComputerName"].ToString();
			this.cboKind.DataSource = this.userData1.Tables["KWD"];
			this.cboKind.DisplayMember = "KindName";
			this.cboKind.ValueMember = "IDKind";
			this.cboLocation.DataSource = this.userData1.Tables["LWD"];
			this.cboLocation.DisplayMember = "LocationName";
			this.cboLocation.ValueMember = "IDLocation";
			if (this.dviUser[0]["Status"].ToString() == "True")
			{
				this.cboStatus.Text = "Active";
			} 
			else 
			{
				this.cboStatus.Text = "Inactive";
			}
			this.txtNotes.Text = this.dviUser[0]["Notes"].ToString();
			this.dviSoftware.Table = this.userData1.Tables["SWD"];
			this.dviSoftware.RowFilter = "ComputerName = '" + this.textBox1.Text +"'";
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
					dr["ComputerName"] = this.textBox1.Text;
					dr["SoftwareName"] = mo["Name"].ToString();
					dr["Version"] = mo["version"].ToString();
					dr["Vendor"] = mo["Vendor"].ToString();
					this.dviSoftware.Table.Rows.Add(dr);
					this.Update();
				}
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
				ReportUSR tmpRep = new ReportUSR();
				tmpRep.dataview = this.dviUser;
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
			this.Cursor = Cursors.WaitCursor;
			TreeNodeCollection nodeCollection;

			try 
			{
				nodeCollection = createParentNode("Network Adapters");
				foreach (ManagementObject mo in Consulta("SELECT * FROM Win32_NetworkAdapter"))
				{
					createChildNode(nodeCollection, "NIC Name: " + mo["ProductName"]);
					createChildNode(nodeCollection, "MAC Address: " + mo["MACAddress"]);
				}
				this.Update();

				nodeCollection = createParentNode("Video Adapters & Monitors");
				foreach (ManagementObject mo in Consulta("SELECT * FROM Win32_DesktopMonitor"))
				{
					createChildNode(nodeCollection, "Monitor: " + mo["MonitorType"]);
					createChildNode(nodeCollection, "Screen Height: " + mo["ScreenHeight"]);
					createChildNode(nodeCollection, "Screen Width: " + mo["ScreenWidth"]);
				}
				foreach (ManagementObject mo in Consulta("SELECT * FROM Win32_VideoController"))
				{
					createChildNode(nodeCollection, "Video Card: " + mo["Caption"]);
					createChildNode(nodeCollection, "BPP: " + mo["CurrentBitsPerPixel"]);
				}
				this.Update();

				nodeCollection = createParentNode("Printers");
				foreach (ManagementObject mo in Consulta("SELECT * FROM Win32_Printer"))
				{
					createChildNode(nodeCollection, "Name: " + mo["Caption"]);
					createChildNode(nodeCollection, "Location: " + mo["Location"]);
				}
				this.Update();

				nodeCollection = createParentNode("Disk Drives");
				foreach (ManagementObject mo in Consulta("SELECT * FROM Win32_DiskDrive"))
				{
					createChildNode(nodeCollection, "Caption: " + mo["Caption"]);
					createChildNode(nodeCollection, "Size: " + formatSize(Convert.ToInt64(mo["Size"].ToString()),false));
				}
				this.Update();

				nodeCollection = createParentNode("CD-ROM Drives");
				foreach (ManagementObject mo in Consulta("SELECT * FROM Win32_CDROMDrive"))
				{
					createChildNode(nodeCollection, "Caption: " + mo["Caption"]);
					createChildNode(nodeCollection, "Drive: " + mo["Drive"]);
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
		private TreeNodeCollection createParentNode(string stringName)
		{
			TreeNode nodeTreeNode = new TreeNode(stringName);
			treeSysInfo.Nodes.Add(nodeTreeNode);
			return nodeTreeNode.Nodes;

		}
		private void createChildNode(TreeNodeCollection nodeCollection, string stringCaption)
		{
			TreeNode nodeTreeNode = new TreeNode(stringCaption);
			nodeCollection.Add(nodeTreeNode);
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
			this.lblPer1.Text = Math.Round(this.performanceCounter1.NextValue(),2).ToString()+"%";
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
			this.performanceCounter1.MachineName = this.textBox1.Text;
			this.performanceCounter2.MachineName = this.textBox1.Text;
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
			ManagementObjectCollection queryCollection;

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
			ManagementObjectCollection queryCollection;
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
				ListViewItem lvItem = new ListViewItem(sitems,0);
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
				if (this.textBox1.Text.Length > 3 || this.upOne.Value < this.upTwo.Value)
				{
					try 
					{
						Dns.Resolve(this.textBox1.Text);
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

		private bool connectSocket(string server, int port, ProtocolType protocol)
		{
			IPHostEntry iphe = null;
			Socket tmpS = null;
    
			try
			{
				iphe = Dns.Resolve(server);

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
			con = this.connectSocket(this.textBox1.Text, i, ProtocolType.Tcp);
			this.time = new System.TimeSpan(DateTime.Now.Ticks - this.timeElapsed);
			if(con)
			{
				values[1] = "Opened";
			} 
			else
			{
				values[1] = "Closed";
			}
			if (con || this.chkAll.Checked) 
			{
				values[5] = this.time.Milliseconds.ToString();
				lvItem = new ListViewItem(values,0);	
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
				if (this.anotherLogin == true && this.username.Length > 0)
				{
					co.Username = this.username;
					co.Password = this.password;
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
					if (id != "File 1")
					{
						int k = 0;
						foreach(DataRow dr in this.tempds.Tables[0].Rows)
						{
							if (dr["ID"].ToString() == id) 
							{
								this.tempds.Tables[0].Rows[k].Delete();
								break;
							}
							k++;
						}
					}
				}
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
				hotInstall.computername = this.textBox1.Text;
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
			process.StartInfo.Arguments = "\\\\" + this.textBox1.Text + "\\" + listView1.SelectedItems[0].Text;			
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
					ListViewItem lvItem = new ListViewItem(sitems,0);
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
