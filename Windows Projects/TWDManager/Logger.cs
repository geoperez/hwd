using System;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace TWDManager
{
	public class Logger : System.Windows.Forms.Form
	{
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtTech;
		private System.Windows.Forms.TextBox txtDate;
		private System.Windows.Forms.TextBox txtEntry;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle buttonWithStyle1;
		private System.ComponentModel.Container components = null;
		private System.Data.SqlClient.SqlConnection sqlcon;
		public string Tech;
		private System.Windows.Forms.RichTextBox txtLog;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle buttonWithStyle2;
		public string Machinename;

		public System.Data.SqlClient.SqlConnection Sqlcon
		{
			set 
			{
				this.sqlcon = value;
			}
		}

		public Logger()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Logger));
			this.titleBar1 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.txtLog = new System.Windows.Forms.RichTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtTech = new System.Windows.Forms.TextBox();
			this.txtDate = new System.Windows.Forms.TextBox();
			this.txtEntry = new System.Windows.Forms.TextBox();
			this.buttonWithStyle1 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.buttonWithStyle2 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// titleBar1
			// 
			this.titleBar1.Dock = System.Windows.Forms.DockStyle.Top;
			this.titleBar1.GradientActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(200)), ((System.Byte)(200)));
			this.titleBar1.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
			this.titleBar1.GradientDirection = Crownwood.DotNetMagic.Controls.GradientDirection.TopToBottom;
			this.titleBar1.GradientInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(239)), ((System.Byte)(247)));
			this.titleBar1.Icon = ((System.Drawing.Icon)(resources.GetObject("titleBar1.Icon")));
			this.titleBar1.Location = new System.Drawing.Point(0, 0);
			this.titleBar1.MouseOverColor = System.Drawing.Color.Empty;
			this.titleBar1.Name = "titleBar1";
			this.titleBar1.Size = new System.Drawing.Size(504, 40);
			this.titleBar1.TabIndex = 0;
			this.titleBar1.Text = "Logger";
			// 
			// txtLog
			// 
			this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtLog.Location = new System.Drawing.Point(8, 48);
			this.txtLog.Name = "txtLog";
			this.txtLog.ReadOnly = true;
			this.txtLog.Size = new System.Drawing.Size(232, 280);
			this.txtLog.TabIndex = 1;
			this.txtLog.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 80);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Description:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Date/Time:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Technic:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.buttonWithStyle2);
			this.groupBox1.Controls.Add(this.buttonWithStyle1);
			this.groupBox1.Controls.Add(this.txtEntry);
			this.groupBox1.Controls.Add(this.txtDate);
			this.groupBox1.Controls.Add(this.txtTech);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(248, 48);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(248, 280);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Add Entry";
			// 
			// txtTech
			// 
			this.txtTech.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtTech.Location = new System.Drawing.Point(96, 24);
			this.txtTech.Name = "txtTech";
			this.txtTech.ReadOnly = true;
			this.txtTech.Size = new System.Drawing.Size(144, 20);
			this.txtTech.TabIndex = 5;
			this.txtTech.Text = "";
			// 
			// txtDate
			// 
			this.txtDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtDate.Location = new System.Drawing.Point(96, 48);
			this.txtDate.Name = "txtDate";
			this.txtDate.ReadOnly = true;
			this.txtDate.Size = new System.Drawing.Size(144, 20);
			this.txtDate.TabIndex = 6;
			this.txtDate.Text = "";
			// 
			// txtEntry
			// 
			this.txtEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtEntry.Location = new System.Drawing.Point(8, 104);
			this.txtEntry.Multiline = true;
			this.txtEntry.Name = "txtEntry";
			this.txtEntry.Size = new System.Drawing.Size(232, 128);
			this.txtEntry.TabIndex = 7;
			this.txtEntry.Text = "";
			// 
			// buttonWithStyle1
			// 
			this.buttonWithStyle1.Location = new System.Drawing.Point(96, 240);
			this.buttonWithStyle1.Name = "buttonWithStyle1";
			this.buttonWithStyle1.Size = new System.Drawing.Size(64, 32);
			this.buttonWithStyle1.TabIndex = 8;
			this.buttonWithStyle1.Text = "Save";
			this.buttonWithStyle1.Click += new System.EventHandler(this.buttonWithStyle1_Click);
			// 
			// buttonWithStyle2
			// 
			this.buttonWithStyle2.Location = new System.Drawing.Point(176, 240);
			this.buttonWithStyle2.Name = "buttonWithStyle2";
			this.buttonWithStyle2.Size = new System.Drawing.Size(64, 32);
			this.buttonWithStyle2.TabIndex = 9;
			this.buttonWithStyle2.Text = "Cancel";
			this.buttonWithStyle2.Click += new System.EventHandler(this.buttonWithStyle2_Click);
			// 
			// Logger
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(504, 334);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.txtLog);
			this.Controls.Add(this.titleBar1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Logger";
			this.Text = "Logger";
			this.Load += new System.EventHandler(this.Logger_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void Logger_Load(object sender, System.EventArgs e)
		{
			this.txtDate.Text = DateTime.Now.ToString();
			this.txtTech.Text = this.Tech;
			this.titleBar1.PostText = this.Machinename;
			if (this.sqlcon.State != ConnectionState.Open)
				this.sqlcon.Open();
			this.LoadLog();
		}

		private void LoadLog()
		{
			try 
			{
				this.txtLog.Text = "";
				SqlCommand sqlcommand = new SqlCommand("SELECT DateEntry, Tech, Description FROM HWD_LOG WHERE Computer = '" + this.Machinename + "' ORDER BY DateEntry", this.sqlcon);
				SqlDataReader sqlread = sqlcommand.ExecuteReader();
				this.txtLog.SelectionFont = new Font("Verdana", 10, FontStyle.Bold);
				this.txtLog.SelectionColor = Color.Red;
				this.txtLog.AppendText(this.Machinename+" Log\n");
				this.txtLog.SelectionColor = Color.Black;
				while (sqlread.Read())
				{
					this.txtLog.SelectionFont = new Font("Verdana", 8, FontStyle.Italic);
					this.txtLog.AppendText("Date/Time: " + sqlread.GetDateTime(0).ToString()+"\n");
					this.txtLog.AppendText("Tech: " + sqlread.GetString(1) + "\n");
					this.txtLog.SelectionFont = new Font("Verdana", 8, FontStyle.Regular);
					this.txtLog.AppendText(sqlread.GetString(2)+"\n\n");
				}
				sqlread.Close();
			} 
			catch (Exception er)
			{
				MessageBox.Show(er.ToString());
			}
		}

		private void buttonWithStyle1_Click(object sender, System.EventArgs e)
		{
			string query = "INSERT INTO HWD_LOG (Computer, Tech, DateEntry, Description) values ('" + this.Machinename + "','" + this.Tech + "','" + this.txtDate.Text + "','" + this.txtEntry.Text + "')";
			try 
			{
				SqlCommand sqlcommand = new SqlCommand(query, this.sqlcon);
				sqlcommand.ExecuteNonQuery();
			}
			catch(Exception exr)
			{
				MessageBox.Show(exr.ToString());
			}
			this.LoadLog();
		}

		private void buttonWithStyle2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}	
	}
}
