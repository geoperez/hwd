using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CWD
{
	public class ticket : System.Windows.Forms.Form
	{
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar1;
		private System.Windows.Forms.ComboBox cboKind;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle buttonWithStyle4;
		private bool edit;
		private string[] mdata;
		private System.Windows.Forms.TextBox txtTitle;
		private System.Windows.Forms.TextBox txtStatus;
		private System.Windows.Forms.TextBox txtTrouble;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle buttonWithStyle1;
		
		public bool EditMode
		{
			set
			{
				edit = value;
			}
			get
			{
				return edit;
			}
		}
		public string[] Data
		{
			set 
			{
				mdata = value;
			}
			get 
			{
				return mdata;
			}
		}

		private System.ComponentModel.Container components = null;

		public ticket()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ticket));
			this.titleBar1 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.cboKind = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtTitle = new System.Windows.Forms.TextBox();
			this.txtStatus = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtTrouble = new System.Windows.Forms.TextBox();
			this.buttonWithStyle4 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.buttonWithStyle1 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.SuspendLayout();
			// 
			// titleBar1
			// 
			this.titleBar1.Dock = System.Windows.Forms.DockStyle.Top;
			this.titleBar1.GradientActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(53)), ((System.Byte)(115)), ((System.Byte)(214)));
			this.titleBar1.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
			this.titleBar1.GradientDirection = Crownwood.DotNetMagic.Controls.GradientDirection.TopToBottom;
			this.titleBar1.GradientInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(44)), ((System.Byte)(96)), ((System.Byte)(178)));
			this.titleBar1.Icon = ((System.Drawing.Icon)(resources.GetObject("titleBar1.Icon")));
			this.titleBar1.Location = new System.Drawing.Point(0, 0);
			this.titleBar1.MouseOverColor = System.Drawing.Color.Empty;
			this.titleBar1.Name = "titleBar1";
			this.titleBar1.Size = new System.Drawing.Size(208, 40);
			this.titleBar1.TabIndex = 1;
			this.titleBar1.Text = "Tickets";
			// 
			// cboKind
			// 
			this.cboKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboKind.Items.AddRange(new object[] {
														 "Software",
														 "Hardware",
														 "Virus",
														 "Security"});
			this.cboKind.Location = new System.Drawing.Point(48, 48);
			this.cboKind.Name = "cboKind";
			this.cboKind.Size = new System.Drawing.Size(152, 21);
			this.cboKind.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Kind";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 104);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Trouble";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 80);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "Title";
			// 
			// txtTitle
			// 
			this.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtTitle.Location = new System.Drawing.Point(48, 80);
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.Size = new System.Drawing.Size(152, 20);
			this.txtTitle.TabIndex = 2;
			this.txtTitle.Text = "";
			// 
			// txtStatus
			// 
			this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtStatus.Location = new System.Drawing.Point(48, 272);
			this.txtStatus.Name = "txtStatus";
			this.txtStatus.ReadOnly = true;
			this.txtStatus.Size = new System.Drawing.Size(152, 20);
			this.txtStatus.TabIndex = 8;
			this.txtStatus.TabStop = false;
			this.txtStatus.Text = "NEW";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 272);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 16);
			this.label4.TabIndex = 7;
			this.label4.Text = "Status";
			// 
			// txtTrouble
			// 
			this.txtTrouble.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtTrouble.Location = new System.Drawing.Point(8, 120);
			this.txtTrouble.Multiline = true;
			this.txtTrouble.Name = "txtTrouble";
			this.txtTrouble.Size = new System.Drawing.Size(192, 144);
			this.txtTrouble.TabIndex = 3;
			this.txtTrouble.Text = "";
			// 
			// buttonWithStyle4
			// 
			this.buttonWithStyle4.Location = new System.Drawing.Point(32, 304);
			this.buttonWithStyle4.Name = "buttonWithStyle4";
			this.buttonWithStyle4.Size = new System.Drawing.Size(80, 24);
			this.buttonWithStyle4.TabIndex = 4;
			this.buttonWithStyle4.Text = "Save";
			this.buttonWithStyle4.Click += new System.EventHandler(this.buttonWithStyle4_Click);
			// 
			// buttonWithStyle1
			// 
			this.buttonWithStyle1.Location = new System.Drawing.Point(120, 304);
			this.buttonWithStyle1.Name = "buttonWithStyle1";
			this.buttonWithStyle1.Size = new System.Drawing.Size(80, 24);
			this.buttonWithStyle1.TabIndex = 9;
			this.buttonWithStyle1.Text = "Cancel";
			this.buttonWithStyle1.Click += new System.EventHandler(this.buttonWithStyle1_Click);
			// 
			// ticket
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(208, 333);
			this.Controls.Add(this.buttonWithStyle1);
			this.Controls.Add(this.buttonWithStyle4);
			this.Controls.Add(this.txtTrouble);
			this.Controls.Add(this.txtStatus);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtTitle);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.titleBar1);
			this.Controls.Add(this.cboKind);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ticket";
			this.Text = "CWD - Ticket";
			this.Load += new System.EventHandler(this.ticket_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void buttonWithStyle4_Click(object sender, System.EventArgs e)
		{
			mdata = new string[6];
			mdata[0] = "0";
			mdata[1] = this.cboKind.SelectedItem.ToString();
			mdata[2] = this.txtTitle.Text;
			mdata[3] = this.txtTrouble.Text;
			mdata[4] = this.txtStatus.Text;
			mdata[5] = "1";
			this.DialogResult = DialogResult.OK;
		}

		private void ticket_Load(object sender, System.EventArgs e)
		{
			if(this.edit)
			{
				this.cboKind.Items[0] = mdata[1];
				this.cboKind.Enabled = false;
				this.txtTitle.ReadOnly = true;
				this.txtTitle.Text =  mdata[2];
				this.txtTrouble.Text =  mdata[3];
				this.txtStatus.Text =  mdata[4];
			}
			this.cboKind.SelectedIndex = 0;
		}

		private void buttonWithStyle1_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}
	}
}
