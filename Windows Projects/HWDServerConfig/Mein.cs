using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Xml;

namespace HWDServerConfig
{
	public class Mein : System.Windows.Forms.Form
	{
		private Crownwood.DotNetMagic.Controls.TabControl tabControl1;
		private Crownwood.DotNetMagic.Controls.TabPage tabPage1;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle buttonWithStyle1;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button3;
		public System.Windows.Forms.ComboBox cmbCatalog;
		public NetworkManagement.ServerComboBox cboServer;
		public System.Windows.Forms.TextBox txtPwd;
		public System.Windows.Forms.TextBox txtUser;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button1;

		private System.ComponentModel.Container components = null;

		public Mein()
		{
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Mein));
			this.tabControl1 = new Crownwood.DotNetMagic.Controls.TabControl();
			this.tabPage1 = new Crownwood.DotNetMagic.Controls.TabPage();
			this.button1 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.txtUser = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.button3 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.cmbCatalog = new System.Windows.Forms.ComboBox();
			this.cboServer = new NetworkManagement.ServerComboBox();
			this.txtPwd = new System.Windows.Forms.TextBox();
			this.buttonWithStyle1 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Appearance = Crownwood.DotNetMagic.Controls.VisualAppearance.MultiBox;
			this.tabControl1.BackColor = System.Drawing.SystemColors.Control;
			this.tabControl1.ButtonActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.tabControl1.ButtonInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tabControl1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.tabControl1.HotTextColor = System.Drawing.SystemColors.ActiveCaption;
			this.tabControl1.ImageList = null;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.OfficeDockSides = false;
			this.tabControl1.PositionTop = true;
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(352, 232);
			this.tabControl1.TabIndex = 0;
			this.tabControl1.TabPages.AddRange(new Crownwood.DotNetMagic.Controls.TabPage[] {
																								this.tabPage1});
			this.tabControl1.TextColor = System.Drawing.SystemColors.ControlText;
			this.tabControl1.TextInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.tabControl1.TextTips = true;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.button1);
			this.tabPage1.Controls.Add(this.txtUser);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.button3);
			this.tabPage1.Controls.Add(this.cmbCatalog);
			this.tabPage1.Controls.Add(this.cboServer);
			this.tabPage1.Controls.Add(this.txtPwd);
			this.tabPage1.InactiveBackColor = System.Drawing.Color.Empty;
			this.tabPage1.InactiveTextBackColor = System.Drawing.Color.Empty;
			this.tabPage1.InactiveTextColor = System.Drawing.Color.Empty;
			this.tabPage1.Location = new System.Drawing.Point(1, 30);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.SelectBackColor = System.Drawing.Color.Empty;
			this.tabPage1.SelectTextBackColor = System.Drawing.Color.Empty;
			this.tabPage1.SelectTextColor = System.Drawing.Color.Empty;
			this.tabPage1.Size = new System.Drawing.Size(350, 201);
			this.tabPage1.TabIndex = 3;
			this.tabPage1.Title = "SQL Connection";
			this.tabPage1.ToolTip = "Page";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 160);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(64, 36);
			this.button1.TabIndex = 25;
			this.button1.Text = "Save";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtUser
			// 
			this.txtUser.BackColor = System.Drawing.Color.White;
			this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtUser.Location = new System.Drawing.Point(120, 8);
			this.txtUser.Name = "txtUser";
			this.txtUser.Size = new System.Drawing.Size(144, 18);
			this.txtUser.TabIndex = 16;
			this.txtUser.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 80);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 16);
			this.label4.TabIndex = 20;
			this.label4.Text = "Catalog:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 16);
			this.label3.TabIndex = 18;
			this.label3.Text = "Server:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 17;
			this.label2.Text = "Password:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 15;
			this.label1.Text = "User:";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(272, 80);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(40, 24);
			this.button3.TabIndex = 24;
			this.button3.Text = "Get";
			this.button3.Click += new System.EventHandler(this.cboServer_SelectedIndexChanged);
			// 
			// cmbCatalog
			// 
			this.cmbCatalog.BackColor = System.Drawing.Color.White;
			this.cmbCatalog.Location = new System.Drawing.Point(120, 80);
			this.cmbCatalog.Name = "cmbCatalog";
			this.cmbCatalog.Size = new System.Drawing.Size(144, 20);
			this.cmbCatalog.TabIndex = 21;
			// 
			// cboServer
			// 
			this.cboServer.AutoRefresh = false;
			this.cboServer.BackColor = System.Drawing.Color.White;
			this.cboServer.DomainName = null;
			this.cboServer.Location = new System.Drawing.Point(120, 56);
			this.cboServer.Name = "cboServer";
			this.cboServer.ServerType = NetworkManagement.ServerType.None;
			this.cboServer.Size = new System.Drawing.Size(144, 20);
			this.cboServer.TabIndex = 14;
			this.cboServer.SelectedIndexChanged += new System.EventHandler(this.cboServer_SelectedIndexChanged);
			// 
			// txtPwd
			// 
			this.txtPwd.BackColor = System.Drawing.Color.White;
			this.txtPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPwd.Location = new System.Drawing.Point(120, 32);
			this.txtPwd.MaxLength = 32;
			this.txtPwd.Name = "txtPwd";
			this.txtPwd.PasswordChar = '*';
			this.txtPwd.Size = new System.Drawing.Size(144, 18);
			this.txtPwd.TabIndex = 19;
			this.txtPwd.Text = "";
			// 
			// buttonWithStyle1
			// 
			this.buttonWithStyle1.Location = new System.Drawing.Point(280, 240);
			this.buttonWithStyle1.Name = "buttonWithStyle1";
			this.buttonWithStyle1.Size = new System.Drawing.Size(64, 32);
			this.buttonWithStyle1.TabIndex = 1;
			this.buttonWithStyle1.Text = "Close";
			this.buttonWithStyle1.Click += new System.EventHandler(this.buttonWithStyle1_Click);
			// 
			// Mein
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(352, 277);
			this.Controls.Add(this.buttonWithStyle1);
			this.Controls.Add(this.tabControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Mein";
			this.Text = "HWDServer Config";
			this.Load += new System.EventHandler(this.Mein_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new Mein());
		}

		private void cboServer_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SqlConnection conn;
			SqlCommand    comm;
			SqlDataReader reader;
			string strConn = "user id=" + this.txtUser.Text + ";password=" + this.txtPwd.Text + ";data source=" + this.cboServer.Text + ";persist security info=True;initial catalog=master;";
			conn = new SqlConnection(strConn);

			try
			{
				conn.Open();
				comm = new SqlCommand("select name from sysdatabases",conn);
				reader = comm.ExecuteReader(CommandBehavior.CloseConnection);
				cmbCatalog.Items.Clear();
				while(reader.Read())
					cmbCatalog.Items.Add(reader.GetString(0));
				reader.Close();
			}
			catch
			{
				MessageBox.Show("Can´t connect to Sql Server");
			}	
		}

		private void Mein_Load(object sender, System.EventArgs e)
		{
			this.cboServer.DomainName = Environment.UserDomainName;		   
			cboServer.ServerType =  NetworkManagement.ServerType.SQLServer;
			cboServer.Refresh();
			this.cboServer.AutoRefresh = true;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			string strConn = "user id=" + this.txtUser.Text + ";password=" + this.txtPwd.Text + ";data source=\"" + this.cboServer.Text + 
				"\";persist security info=True;initial catalog=" + this.cmbCatalog.Text;

			SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(strConn);
			try 
			{
				sqlConn.Open();
				this.CreateXML();
				Utilities.ChecaTablas(sqlConn);
				sqlConn.Close();
			}
			catch (Exception er)
			{
				MessageBox.Show(er.ToString());
			}
		}

		private void CreateXML()
		{
			XmlDocument xmldoc = new XmlDocument();
			StringBuilder xmlData = new StringBuilder();
			xmlData.Append("<Config><SQLServer>" + this.cboServer.Text + "</SQLServer>");
			xmlData.Append("<SQLUser>" + this.txtUser.Text + "</SQLUser>" );
			xmlData.Append("<SQLPwd>");
			xmlData.Append(Utilities.Encrypt(this.txtPwd.Text,Utilities.KeyType.MachineKey));
			xmlData.Append("</SQLPwd>");
			xmlData.Append("<SQLCatalog>" + this.cmbCatalog.Text + "</SQLCatalog>");
			xmlData.Append("</Config>");   			   
			xmldoc.LoadXml(xmlData.ToString());
			if (!System.IO.Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.System) + "\\HWD"))
				System.IO.Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.System) + "\\HWD");
			xmldoc.Save(System.Environment.GetFolderPath(System.Environment.SpecialFolder.System) + "\\HWD\\config.xml");
			MessageBox.Show("Sql Settings Saved");
		}

		private void buttonWithStyle1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
