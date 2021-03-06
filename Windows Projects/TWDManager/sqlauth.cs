using System;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text;
using System.Security.Principal;
using System.Threading;
using NetworkManagement;
using System.IO;

namespace TWDManager
{
	public class SessionForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox txtUser;
		public System.Windows.Forms.TextBox txtPwd;
		public System.Data.SqlClient.SqlConnection sqlConn;
		public NetworkManagement.ServerComboBox cboServer;
		private System.Windows.Forms.CheckBox checkBox1;
		public string type = "sql";
		public string auth = "sql";
		private System.ComponentModel.Container components = null;
		public System.Windows.Forms.CheckBox savePass;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioSQL;
		private System.Windows.Forms.RadioButton radioWin;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button3;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button1;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button2;
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar1;
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar2;
		public System.Windows.Forms.ComboBox cmbCatalog;

		public SessionForm()
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtUser = new System.Windows.Forms.TextBox();
			this.txtPwd = new System.Windows.Forms.TextBox();
			this.cboServer = new NetworkManagement.ServerComboBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.savePass = new System.Windows.Forms.CheckBox();
			this.cmbCatalog = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button3 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.radioWin = new System.Windows.Forms.RadioButton();
			this.radioSQL = new System.Windows.Forms.RadioButton();
			this.button1 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.button2 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.titleBar1 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.titleBar2 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "User:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Password:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 112);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Server:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(24, 136);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "Catalog:";
			// 
			// txtUser
			// 
			this.txtUser.BackColor = System.Drawing.Color.White;
			this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtUser.Location = new System.Drawing.Point(136, 64);
			this.txtUser.Name = "txtUser";
			this.txtUser.Size = new System.Drawing.Size(128, 20);
			this.txtUser.TabIndex = 1;
			this.txtUser.Text = "";
			// 
			// txtPwd
			// 
			this.txtPwd.BackColor = System.Drawing.Color.White;
			this.txtPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPwd.Location = new System.Drawing.Point(136, 88);
			this.txtPwd.MaxLength = 32;
			this.txtPwd.Name = "txtPwd";
			this.txtPwd.PasswordChar = '*';
			this.txtPwd.Size = new System.Drawing.Size(128, 20);
			this.txtPwd.TabIndex = 2;
			this.txtPwd.Text = "";
			// 
			// cboServer
			// 
			this.cboServer.AutoRefresh = false;
			this.cboServer.BackColor = System.Drawing.Color.White;
			this.cboServer.DomainName = null;
			this.cboServer.Location = new System.Drawing.Point(136, 112);
			this.cboServer.Name = "cboServer";
			this.cboServer.ServerType = NetworkManagement.ServerType.None;
			this.cboServer.Size = new System.Drawing.Size(128, 21);
			this.cboServer.TabIndex = 0;
			this.cboServer.SelectedIndexChanged += new System.EventHandler(this.cboServer_SelectedIndexChanged);
			// 
			// checkBox1
			// 
			this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBox1.Location = new System.Drawing.Point(16, 248);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(72, 16);
			this.checkBox1.TabIndex = 7;
			this.checkBox1.Text = "Offline";
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// savePass
			// 
			this.savePass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.savePass.Location = new System.Drawing.Point(8, 160);
			this.savePass.Name = "savePass";
			this.savePass.Size = new System.Drawing.Size(136, 16);
			this.savePass.TabIndex = 8;
			this.savePass.Text = "Remember Password";
			// 
			// cmbCatalog
			// 
			this.cmbCatalog.BackColor = System.Drawing.Color.White;
			this.cmbCatalog.Location = new System.Drawing.Point(136, 136);
			this.cmbCatalog.Name = "cmbCatalog";
			this.cmbCatalog.Size = new System.Drawing.Size(128, 21);
			this.cmbCatalog.TabIndex = 9;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button3);
			this.groupBox1.Controls.Add(this.radioWin);
			this.groupBox1.Controls.Add(this.radioSQL);
			this.groupBox1.Controls.Add(this.cmbCatalog);
			this.groupBox1.Controls.Add(this.savePass);
			this.groupBox1.Controls.Add(this.cboServer);
			this.groupBox1.Controls.Add(this.txtPwd);
			this.groupBox1.Controls.Add(this.txtUser);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(8, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(320, 184);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(272, 136);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(40, 24);
			this.button3.TabIndex = 13;
			this.button3.Text = "Get";
			this.button3.Click += new System.EventHandler(this.cboServer_SelectedIndexChanged);
			// 
			// radioWin
			// 
			this.radioWin.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioWin.Location = new System.Drawing.Point(8, 16);
			this.radioWin.Name = "radioWin";
			this.radioWin.Size = new System.Drawing.Size(152, 24);
			this.radioWin.TabIndex = 12;
			this.radioWin.Text = "Windows Authentication";
			this.radioWin.CheckedChanged += new System.EventHandler(this.radioWin_CheckedChanged);
			// 
			// radioSQL
			// 
			this.radioSQL.Checked = true;
			this.radioSQL.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioSQL.Location = new System.Drawing.Point(8, 40);
			this.radioSQL.Name = "radioSQL";
			this.radioSQL.Size = new System.Drawing.Size(136, 24);
			this.radioSQL.TabIndex = 11;
			this.radioSQL.TabStop = true;
			this.radioSQL.Text = "SQL Authentication";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(120, 304);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 36);
			this.button1.TabIndex = 14;
			this.button1.Text = "Log in";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(224, 304);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(96, 36);
			this.button2.TabIndex = 15;
			this.button2.Text = "Cancel";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// titleBar1
			// 
			this.titleBar1.Dock = System.Windows.Forms.DockStyle.Top;
			this.titleBar1.GradientActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(53)), ((System.Byte)(115)), ((System.Byte)(214)));
			this.titleBar1.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
			this.titleBar1.GradientDirection = Crownwood.DotNetMagic.Controls.GradientDirection.TopToBottom;
			this.titleBar1.GradientInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(96)), ((System.Byte)(178)));
			this.titleBar1.Location = new System.Drawing.Point(0, 0);
			this.titleBar1.MouseOverColor = System.Drawing.Color.Empty;
			this.titleBar1.Name = "titleBar1";
			this.titleBar1.Size = new System.Drawing.Size(330, 24);
			this.titleBar1.TabIndex = 16;
			this.titleBar1.TabStop = false;
			this.titleBar1.Text = "SQL Login";
			// 
			// titleBar2
			// 
			this.titleBar2.GradientActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(53)), ((System.Byte)(115)), ((System.Byte)(214)));
			this.titleBar2.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
			this.titleBar2.GradientDirection = Crownwood.DotNetMagic.Controls.GradientDirection.TopToBottom;
			this.titleBar2.GradientInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(96)), ((System.Byte)(178)));
			this.titleBar2.Location = new System.Drawing.Point(0, 216);
			this.titleBar2.MouseOverColor = System.Drawing.Color.Empty;
			this.titleBar2.Name = "titleBar2";
			this.titleBar2.Size = new System.Drawing.Size(328, 24);
			this.titleBar2.TabIndex = 17;
			this.titleBar2.TabStop = false;
			this.titleBar2.Text = "Session Options";
			// 
			// SessionForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(330, 349);
			this.ControlBox = false;
			this.Controls.Add(this.titleBar2);
			this.Controls.Add(this.titleBar1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.checkBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "SessionForm";
			this.Text = "Session Login";
			this.Load += new System.EventHandler(this.SessionForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		
		private void button1_Click(object sender, System.EventArgs e)
		{
			if (this.checkBox1.Checked) 
			{
				this.type = "xml";
				this.DialogResult = DialogResult.OK;
			} 
			else 
			{
				string strConn = ";data source=\"" + this.cboServer.Text + 
					"\";persist security info=True;initial catalog=" + this.cmbCatalog.Text;

				if (!this.radioWin.Checked)
				{
					strConn = "user id=" + this.txtUser.Text + ";password=" + this.txtPwd.Text + strConn;
					this.auth = "sql";
				} 
				else 
				{
					strConn = "Integrated Security=SSPI" + strConn;
					this.auth = "win";
				}

				this.sqlConn = new System.Data.SqlClient.SqlConnection(strConn);
				StringBuilder sb = new StringBuilder();
				try 
				{
					sqlConn.Open();
					sqlConn.Close();
					this.DialogResult = DialogResult.OK;
				}
				catch (Exception er)
				{
					MessageBox.Show(er.ToString());
				}
			}
		}

		private void SessionForm_Load(object sender, System.EventArgs e)
		{
			this.cboServer.DomainName = Environment.UserDomainName;		   
			cboServer.ServerType =  NetworkManagement.ServerType.SQLServer;
			cboServer.Refresh();
			this.cboServer.AutoRefresh = true;
		}

		private void cboServer_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SqlConnection conn;
			SqlCommand    comm;
			SqlDataReader reader;
			string strConn = ";data source=" + this.cboServer.Text + ";persist security info=True;initial catalog=master;";
			if (!this.radioWin.Checked)
				strConn = "user id=" + this.txtUser.Text + ";password=" + this.txtPwd.Text + strConn;
			else 
				strConn = "Integrated Security=SSPI" + strConn;

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
				MessageBox.Show("Can�t connect to Sql Server");
			}	
		}

		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.checkBox1.Checked) 
			{
				this.txtUser.Enabled = false;
				this.txtPwd.Enabled = false;
				this.cboServer.Enabled = false;
				this.cmbCatalog.Enabled = false;
			} 
			else 
			{
				this.txtUser.Enabled = true;
				this.txtPwd.Enabled = true;
				this.cboServer.Enabled = true;
				this.cmbCatalog.Enabled = true;
			}
		}

		private void radioWin_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.radioWin.Checked) 
			{
				this.txtUser.Enabled = false;
				this.txtPwd.Enabled = false;
			} 
			else 
			{
				this.txtUser.Enabled = true;
				this.txtPwd.Enabled = true;
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

	}

	public class Auth
	{
		private XmlDocument xmldoc;
		private bool status;
		private string type;
		private System.Data.SqlClient.SqlConnection sqlConn;
		string SQLServer;
		string SQLUser;
		string SQLCatalog ;
		string auth;

		public Auth()
		{
			this.status = false;
			this.type = "sql";
			this.xmldoc = new XmlDocument();
			try 
			{
				this.xmldoc.Load(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\TWD\\config.xml");
				if (this.CheckConnection())
					this.status = true; 
				else 
					this.status = this.SessionDialog();			
			}
			catch
			{
				this.status = this.SessionDialog();
			}
		}

		private bool SessionDialog()
		{      
			SessionForm mySform = new SessionForm();
			mySform.cmbCatalog.Text = this.SQLCatalog;
			mySform.txtUser.Text = this.SQLUser;
			mySform.cboServer.DomainName = this.SQLServer;
			mySform.ShowDialog();
			if (mySform.DialogResult == DialogResult.OK)
			{
				StringBuilder xmlData = new StringBuilder();
				xmlData.Append("<Config><SQLServer>" + mySform.cboServer.Text + "</SQLServer>");
				xmlData.Append("<Auth>" + mySform.auth + "</Auth>" );
				if (mySform.auth == "sql") 
				{
					xmlData.Append("<SQLUser>" + mySform.txtUser.Text + "</SQLUser>" );
					xmlData.Append("<SQLPwd>");
					if ( mySform.savePass.Checked == true)
						xmlData.Append(Utilities.Encrypt(mySform.txtPwd.Text,Utilities.KeyType.UserKey));
					xmlData.Append("</SQLPwd>");
				} 
				else 
				{
					xmlData.Append("<SQLUser></SQLUser>");
					xmlData.Append("<SQLPwd></SQLPwd>");
				}
				xmlData.Append("<SQLCatalog>" + mySform.cmbCatalog.Text + "</SQLCatalog>");
				xmlData.Append("<SavePass>"); 			
				if ( mySform.savePass.Checked == true)
					xmlData.Append("1");
				else
					xmlData.Append("0");
				xmlData.Append("</SavePass>");
				xmlData.Append("</Config>");   			   
				this.xmldoc.LoadXml(xmlData.ToString());
				Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\TWD");
				this.xmldoc.Save(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\TWD\\config.xml");
				this.type = mySform.type;
				if (this.type == "sql")
					this.sqlConn = mySform.sqlConn;
				return true;
			} 
			else 
				return false;
		}
		
		private bool CheckConnection()
		{
			auth = this.xmldoc.FirstChild["Auth"].InnerText;
			SQLServer = this.xmldoc.FirstChild["SQLServer"].InnerText;
			SQLUser = this.xmldoc.FirstChild["SQLUser"].InnerText;
			string SQLPwd = Utilities.Decrypt(this.xmldoc.FirstChild["SQLPwd"].InnerText);
			SQLCatalog = this.xmldoc.FirstChild["SQLCatalog"].InnerText;

			string strConn = ";data source=\"" + SQLServer +
				"\";persist security info=True;initial catalog=" + SQLCatalog;

			if (auth == "sql")
				strConn = "user id=" + SQLUser + ";password=" + SQLPwd + strConn;
			else 
				strConn = "Integrated Security=SSPI" + strConn;

			Int16 autoConnect = Convert.ToInt16(this.xmldoc.FirstChild["SavePass"].InnerText);
			if (autoConnect==0)
				return false; 
			this.sqlConn = new SqlConnection(strConn);
			try 
			{
				sqlConn.Open();
				sqlConn.Close();
				return true;
			}
			catch 
			{
				return false;
			}
		}

		[STAThread]
		static void Main(string[] args)
		{
			bool init = true;
			bool mux;
			
			AppDomain myDomain = Thread.GetDomain();

			myDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
			WindowsPrincipal winuser = (WindowsPrincipal)Thread.CurrentPrincipal;

			if (winuser.IsInRole(WindowsBuiltInRole.Administrator)) 
			{
				Mutex m = new Mutex(init, "TWDMein", out mux);
				
				if (!(init && mux))
					MessageBox.Show("Already Running");
				else 
				{
					Application.EnableVisualStyles();
					Application.DoEvents();
					Auth myAuth = new Auth();
					if (myAuth.status)
						Application.Run(new Mein(myAuth.sqlConn, myAuth.type));
				}
			} 
			else 
				MessageBox.Show("Sorry. You need to be Administrator to use TWDManager");
			Application.Exit();
		} 
	}
}
