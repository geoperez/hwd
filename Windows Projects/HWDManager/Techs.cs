using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace HWD
{
	public class Techs : System.Windows.Forms.Form
	{
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar1;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle buttonWithStyle1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle buttonWithStyle2;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle buttonWithStyle4;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ListView lstTechs;
		private System.Windows.Forms.TextBox txtUser;
		private System.Windows.Forms.TextBox txtName;
		private SqlConnection sqlcon = null;

		public SqlConnection sqlCon
		{
			set 
			{
				this.sqlcon = value;	
			}
		}

		public Techs()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Techs));
			this.titleBar1 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.buttonWithStyle1 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.lstTechs = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.label2 = new System.Windows.Forms.Label();
			this.txtUser = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.buttonWithStyle2 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.label1 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.buttonWithStyle4 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
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
			this.titleBar1.Size = new System.Drawing.Size(328, 40);
			this.titleBar1.TabIndex = 1;
			this.titleBar1.Text = "Technics Manager";
			// 
			// buttonWithStyle1
			// 
			this.buttonWithStyle1.Location = new System.Drawing.Point(248, 288);
			this.buttonWithStyle1.Name = "buttonWithStyle1";
			this.buttonWithStyle1.Size = new System.Drawing.Size(72, 40);
			this.buttonWithStyle1.TabIndex = 24;
			this.buttonWithStyle1.Text = "Close";
			this.buttonWithStyle1.Click += new System.EventHandler(this.buttonWithStyle1_Click);
			// 
			// lstTechs
			// 
			this.lstTechs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					   this.columnHeader1,
																					   this.columnHeader2,
																					   this.columnHeader3});
			this.lstTechs.FullRowSelect = true;
			this.lstTechs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lstTechs.Location = new System.Drawing.Point(8, 48);
			this.lstTechs.Name = "lstTechs";
			this.lstTechs.Size = new System.Drawing.Size(312, 176);
			this.lstTechs.TabIndex = 25;
			this.lstTechs.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "ID";
			this.columnHeader1.Width = 31;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Username";
			this.columnHeader2.Width = 108;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Name";
			this.columnHeader3.Width = 161;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 16);
			this.label2.TabIndex = 27;
			this.label2.Text = "Username:";
			// 
			// txtUser
			// 
			this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtUser.Location = new System.Drawing.Point(8, 32);
			this.txtUser.Name = "txtUser";
			this.txtUser.Size = new System.Drawing.Size(144, 20);
			this.txtUser.TabIndex = 26;
			this.txtUser.Text = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.buttonWithStyle2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtName);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtUser);
			this.groupBox1.Location = new System.Drawing.Point(8, 232);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(232, 104);
			this.groupBox1.TabIndex = 28;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "New Technic";
			// 
			// buttonWithStyle2
			// 
			this.buttonWithStyle2.Location = new System.Drawing.Point(160, 32);
			this.buttonWithStyle2.Name = "buttonWithStyle2";
			this.buttonWithStyle2.Size = new System.Drawing.Size(64, 40);
			this.buttonWithStyle2.TabIndex = 30;
			this.buttonWithStyle2.Text = "Save";
			this.buttonWithStyle2.Click += new System.EventHandler(this.buttonWithStyle2_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 16);
			this.label1.TabIndex = 29;
			this.label1.Text = "Real Name:";
			// 
			// txtName
			// 
			this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtName.Location = new System.Drawing.Point(8, 72);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(144, 20);
			this.txtName.TabIndex = 28;
			this.txtName.Text = "";
			// 
			// buttonWithStyle4
			// 
			this.buttonWithStyle4.Location = new System.Drawing.Point(248, 232);
			this.buttonWithStyle4.Name = "buttonWithStyle4";
			this.buttonWithStyle4.Size = new System.Drawing.Size(72, 40);
			this.buttonWithStyle4.TabIndex = 29;
			this.buttonWithStyle4.Text = "Delete";
			this.buttonWithStyle4.Click += new System.EventHandler(this.buttonWithStyle4_Click);
			// 
			// Techs
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(328, 338);
			this.Controls.Add(this.buttonWithStyle4);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.lstTechs);
			this.Controls.Add(this.buttonWithStyle1);
			this.Controls.Add(this.titleBar1);
			this.Name = "Techs";
			this.Text = "Technics Manager";
			this.Load += new System.EventHandler(this.Techs_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void buttonWithStyle4_Click(object sender, System.EventArgs e)
		{
			if (this.lstTechs.SelectedIndices.Count > 0)
			{
				SqlCommand sqlcommand = new SqlCommand("DELETE FROM HWD_TECHS WHERE ID = " + this.lstTechs.SelectedItems[0].SubItems[0].Text, this.sqlcon); 	
				this.sqlcon.Open();
				sqlcommand.ExecuteNonQuery();
				this.sqlcon.Close();
				this.PopulatedItems();
			}
		}

		private void PopulatedItems()
		{
			this.lstTechs.Items.Clear();
			this.sqlcon.Open();
			SqlCommand sqlcommand = new SqlCommand("SELECT * FROM HWD_TECHS", this.sqlcon);
			SqlDataReader sqlreader = sqlcommand.ExecuteReader(CommandBehavior.CloseConnection);
			while (sqlreader.Read())
			{
				string[] str = new string[3];
				str[0] = sqlreader.GetInt32(0).ToString();
				str[1] = sqlreader.GetString(1).Trim();
				str[2] = sqlreader.GetString(2).Trim();
				ListViewItem lvi = new ListViewItem(str);
				this.lstTechs.Items.Add(lvi);
			}
			sqlreader.Close();
		}

		private void Techs_Load(object sender, System.EventArgs e)
		{
			this.PopulatedItems();
		}

		private void buttonWithStyle2_Click(object sender, System.EventArgs e)
		{
			if (this.txtUser.Text.Length > 1 && this.txtName.Text.Length > 1)
			{
				SqlCommand sqlcommand = new SqlCommand("INSERT INTO HWD_TECHS (Username, Name) values ('" + this.txtUser.Text +"', '" + this.txtName.Text +"')", this.sqlcon); 	
				this.sqlcon.Open();
				sqlcommand.ExecuteNonQuery();
				this.sqlcon.Close();
				this.PopulatedItems();
			}
		}

		private void buttonWithStyle1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
