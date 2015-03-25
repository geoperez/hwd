using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using System.Diagnostics;
using Crownwood.DotNetMagic.Controls;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices;

namespace HWD
{
	public class Apps : System.Windows.Forms.Form
	{
		#region Objects
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ListBox lstBlock;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle buttonWithStyle6;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle buttonWithStyle4;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle buttonWithStyle3;
		private System.Windows.Forms.TextBox txtApp;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private NetworkManagement.ServerComboBox comboBox1;
		private System.Windows.Forms.ComboBox comboBox2;
		private SqlConnection sqlcon;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle buttonWithStyle1;
		private string owner;

		public SqlConnection sqlCon
		{
			set 
			{
				this.sqlcon = value;	
			}
		}
		#endregion

		#region Apps Class
		public Apps()
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
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Apps));
			this.titleBar1 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lstBlock = new System.Windows.Forms.ListBox();
			this.buttonWithStyle6 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.buttonWithStyle4 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.buttonWithStyle3 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.txtApp = new System.Windows.Forms.TextBox();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.comboBox1 = new NetworkManagement.ServerComboBox();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.buttonWithStyle1 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// titleBar1
			// 
			this.titleBar1.Dock = System.Windows.Forms.DockStyle.Top;
			this.titleBar1.GradientActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(136)), ((System.Byte)(144)), ((System.Byte)(156)));
			this.titleBar1.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
			this.titleBar1.GradientDirection = Crownwood.DotNetMagic.Controls.GradientDirection.TopToBottom;
			this.titleBar1.GradientInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(230)), ((System.Byte)(231)), ((System.Byte)(228)));
			this.titleBar1.Icon = ((System.Drawing.Icon)(resources.GetObject("titleBar1.Icon")));
			this.titleBar1.Location = new System.Drawing.Point(0, 0);
			this.titleBar1.MouseOverColor = System.Drawing.Color.Empty;
			this.titleBar1.Name = "titleBar1";
			this.titleBar1.Size = new System.Drawing.Size(336, 40);
			this.titleBar1.TabIndex = 0;
			this.titleBar1.Text = "Blocked Applications";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 120);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 16);
			this.label2.TabIndex = 17;
			this.label2.Text = "Internal Name of EXE:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lstBlock);
			this.groupBox1.Controls.Add(this.buttonWithStyle6);
			this.groupBox1.Location = new System.Drawing.Point(8, 168);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(320, 208);
			this.groupBox1.TabIndex = 16;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Blocked Apps";
			// 
			// lstBlock
			// 
			this.lstBlock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstBlock.Location = new System.Drawing.Point(8, 16);
			this.lstBlock.Name = "lstBlock";
			this.lstBlock.Size = new System.Drawing.Size(304, 158);
			this.lstBlock.TabIndex = 6;
			// 
			// buttonWithStyle6
			// 
			this.buttonWithStyle6.Location = new System.Drawing.Point(240, 184);
			this.buttonWithStyle6.Name = "buttonWithStyle6";
			this.buttonWithStyle6.Size = new System.Drawing.Size(72, 16);
			this.buttonWithStyle6.TabIndex = 13;
			this.buttonWithStyle6.Text = "Delete";
			this.buttonWithStyle6.Click += new System.EventHandler(this.buttonWithStyle6_Click_1);
			// 
			// buttonWithStyle4
			// 
			this.buttonWithStyle4.Location = new System.Drawing.Point(248, 136);
			this.buttonWithStyle4.Name = "buttonWithStyle4";
			this.buttonWithStyle4.Size = new System.Drawing.Size(72, 16);
			this.buttonWithStyle4.TabIndex = 15;
			this.buttonWithStyle4.Text = "Add";
			this.buttonWithStyle4.Click += new System.EventHandler(this.buttonWithStyle4_Click);
			// 
			// buttonWithStyle3
			// 
			this.buttonWithStyle3.Location = new System.Drawing.Point(160, 136);
			this.buttonWithStyle3.Name = "buttonWithStyle3";
			this.buttonWithStyle3.Size = new System.Drawing.Size(72, 16);
			this.buttonWithStyle3.TabIndex = 14;
			this.buttonWithStyle3.Text = "Browse";
			this.buttonWithStyle3.Click += new System.EventHandler(this.buttonWithStyle3_Click);
			// 
			// txtApp
			// 
			this.txtApp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtApp.Location = new System.Drawing.Point(8, 136);
			this.txtApp.Name = "txtApp";
			this.txtApp.Size = new System.Drawing.Size(144, 20);
			this.txtApp.TabIndex = 13;
			this.txtApp.Text = "";
			// 
			// radioButton1
			// 
			this.radioButton1.Checked = true;
			this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioButton1.Location = new System.Drawing.Point(8, 48);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(80, 16);
			this.radioButton1.TabIndex = 18;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "General";
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// radioButton2
			// 
			this.radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioButton2.Location = new System.Drawing.Point(8, 72);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(80, 16);
			this.radioButton2.TabIndex = 19;
			this.radioButton2.Text = "User";
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// radioButton3
			// 
			this.radioButton3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioButton3.Location = new System.Drawing.Point(8, 96);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(80, 16);
			this.radioButton3.TabIndex = 20;
			this.radioButton3.Text = "Machine";
			this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
			// 
			// comboBox1
			// 
			this.comboBox1.AutoRefresh = false;
			this.comboBox1.DomainName = null;
			this.comboBox1.Location = new System.Drawing.Point(96, 96);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.ServerType = NetworkManagement.ServerType.Workstation;
			this.comboBox1.Size = new System.Drawing.Size(144, 21);
			this.comboBox1.TabIndex = 21;
			// 
			// comboBox2
			// 
			this.comboBox2.Location = new System.Drawing.Point(96, 72);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(144, 21);
			this.comboBox2.TabIndex = 22;
			// 
			// buttonWithStyle1
			// 
			this.buttonWithStyle1.Location = new System.Drawing.Point(256, 384);
			this.buttonWithStyle1.Name = "buttonWithStyle1";
			this.buttonWithStyle1.Size = new System.Drawing.Size(72, 40);
			this.buttonWithStyle1.TabIndex = 23;
			this.buttonWithStyle1.Text = "Close";
			this.buttonWithStyle1.Click += new System.EventHandler(this.buttonWithStyle1_Click);
			// 
			// Apps
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(336, 428);
			this.Controls.Add(this.buttonWithStyle1);
			this.Controls.Add(this.comboBox2);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.radioButton3);
			this.Controls.Add(this.radioButton2);
			this.Controls.Add(this.radioButton1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.buttonWithStyle4);
			this.Controls.Add(this.buttonWithStyle3);
			this.Controls.Add(this.txtApp);
			this.Controls.Add(this.titleBar1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Apps";
			this.Text = "Bloked Applications";
			this.Load += new System.EventHandler(this.ConfigServer_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Apps General Methods

		private void GetItems()
		{
			this.lstBlock.Items.Clear();
			this.sqlcon.Open();
			SqlCommand sqlcommand = new SqlCommand("SELECT InternalName FROM BlockedApps WHERE Owner = '" + this.owner + "'", this.sqlcon);
			SqlDataReader sqlreader = sqlcommand.ExecuteReader(CommandBehavior.CloseConnection);
			while (sqlreader.Read())
				this.lstBlock.Items.Add(sqlreader.GetString(0).Trim());
			sqlreader.Close();
		}

		#endregion

		#region Apps Handlers
		private void ConfigServer_Load(object sender, System.EventArgs e)
		{
			this.comboBox1.DomainName = Environment.UserDomainName;
			this.comboBox1.Refresh();
			this.owner = "ALL";
			this.GetItems();
		}

		private void buttonWithStyle3_Click(object sender, System.EventArgs e)
		{
			this.openFileDialog1.Filter = "Applications (*.exe)|*.exe";

			if (this.openFileDialog1.ShowDialog(this) == DialogResult.OK)
				this.txtApp.Text = FileVersionInfo.GetVersionInfo(this.openFileDialog1.FileName).InternalName;
		}

		private void buttonWithStyle4_Click(object sender, System.EventArgs e)
		{
			if (this.txtApp.Text.Length > 1)
			{
				SqlCommand sqlcommand = new SqlCommand("INSERT INTO BlockedApps (InternalName, Owner) values ('" + this.txtApp.Text +"', '" + this.owner +"')", this.sqlcon); 	
				this.sqlcon.Open();
				sqlcommand.ExecuteNonQuery();
				this.sqlcon.Close();
				this.GetItems();
			}
		}

		private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
		{
			this.owner = "ALL";
			this.GetItems();
		}

		private void buttonWithStyle6_Click_1(object sender, System.EventArgs e)
		{
			if (this.lstBlock.SelectedIndex > -1)
			{
				SqlCommand sqlcommand = new SqlCommand("DELETE FROM BlockedApps WHERE Owner = '" + this.owner + "' AND InternalName = '" + this.lstBlock.Items[this.lstBlock.SelectedIndex].ToString() +"'", this.sqlcon); 	
				this.sqlcon.Open();
				sqlcommand.ExecuteNonQuery();
				this.sqlcon.Close();
				this.GetItems();
			}
		}

		private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
		{
			this.owner = this.comboBox2.Text;
			this.GetItems();
		}

		private void radioButton3_CheckedChanged(object sender, System.EventArgs e)
		{
			this.owner = this.comboBox1.Text;
			this.GetItems();
		}

		private void buttonWithStyle1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#endregion
	}
}
