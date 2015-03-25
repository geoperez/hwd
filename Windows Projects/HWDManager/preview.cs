using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ReportPrinting;

namespace HWD
{
	/// <summary>
	/// Summary description for preview.
	/// </summary>
	public class preview : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PrintPreviewControl printPreviewControl1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem mnuPrint;
		private System.Windows.Forms.MenuItem mnuSetup;
		private System.Windows.Forms.MenuItem mnClose;
		private ReportPrinting.ReportDocument reportDocument1;
		private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.PrintDialog printDialog1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public IReportMaker irp
		{
			set 
			{
				this.reportDocument1.ReportMaker = value;
			}
		}

		public preview()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(preview));
			this.printPreviewControl1 = new System.Windows.Forms.PrintPreviewControl();
			this.reportDocument1 = new ReportPrinting.ReportDocument();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.mnuPrint = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.mnuSetup = new System.Windows.Forms.MenuItem();
			this.mnClose = new System.Windows.Forms.MenuItem();
			this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
			this.printDialog1 = new System.Windows.Forms.PrintDialog();
			this.SuspendLayout();
			// 
			// printPreviewControl1
			// 
			this.printPreviewControl1.AutoZoom = false;
			this.printPreviewControl1.BackColor = System.Drawing.Color.White;
			this.printPreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.printPreviewControl1.Location = new System.Drawing.Point(0, 0);
			this.printPreviewControl1.Name = "printPreviewControl1";
			this.printPreviewControl1.Rows = 2;
			this.printPreviewControl1.Size = new System.Drawing.Size(736, 504);
			this.printPreviewControl1.TabIndex = 0;
			this.printPreviewControl1.UseAntiAlias = true;
			this.printPreviewControl1.Zoom = 0.5;
			// 
			// reportDocument1
			// 
			this.reportDocument1.Body = null;
			this.reportDocument1.DocumentUnit = System.Drawing.GraphicsUnit.Inch;
			this.reportDocument1.PageFooter = null;
			this.reportDocument1.PageFooterMaxHeight = 0F;
			this.reportDocument1.PageHeader = null;
			this.reportDocument1.PageHeaderMaxHeight = 0F;
			this.reportDocument1.ReportMaker = null;
			this.reportDocument1.ResetAfterPrint = true;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuPrint,
																					  this.menuItem1,
																					  this.mnuSetup,
																					  this.mnClose});
			// 
			// mnuPrint
			// 
			this.mnuPrint.Index = 0;
			this.mnuPrint.Text = "&Print";
			this.mnuPrint.Click += new System.EventHandler(this.mnuPrint_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 1;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2,
																					  this.menuItem3,
																					  this.menuItem4,
																					  this.menuItem5});
			this.menuItem1.Text = "&Zoom";
			// 
			// menuItem2
			// 
			this.menuItem2.Checked = true;
			this.menuItem2.DefaultItem = true;
			this.menuItem2.Index = 0;
			this.menuItem2.RadioCheck = true;
			this.menuItem2.Text = "50%";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.RadioCheck = true;
			this.menuItem3.Text = "100%";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.RadioCheck = true;
			this.menuItem4.Text = "150%";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 3;
			this.menuItem5.RadioCheck = true;
			this.menuItem5.Text = "200%";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// mnuSetup
			// 
			this.mnuSetup.Index = 2;
			this.mnuSetup.Text = "&Setup Page";
			this.mnuSetup.Click += new System.EventHandler(this.mnuSetup_Click);
			// 
			// mnClose
			// 
			this.mnClose.Index = 3;
			this.mnClose.Text = "&Close";
			this.mnClose.Click += new System.EventHandler(this.mnClose_Click);
			// 
			// pageSetupDialog1
			// 
			this.pageSetupDialog1.Document = this.reportDocument1;
			// 
			// printDialog1
			// 
			this.printDialog1.Document = this.reportDocument1;
			// 
			// preview
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(736, 504);
			this.Controls.Add(this.printPreviewControl1);
			this.ForeColor = System.Drawing.Color.White;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu1;
			this.Name = "preview";
			this.Text = "Report Preview";
			this.Load += new System.EventHandler(this.preview_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void mnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void mnuPrint_Click(object sender, System.EventArgs e)
		{
			DialogResult result = this.printDialog1.ShowDialog();

			if (result == DialogResult.OK)
			{
				this.reportDocument1.Print();
			}

		}

		private void mnuSetup_Click(object sender, System.EventArgs e)
		{
			this.printPreviewControl1.Document = null;
			this.pageSetupDialog1.ShowDialog();
			this.printPreviewControl1.Document = this.reportDocument1;
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			this.printPreviewControl1.Zoom = 0.5f;
			this.menuItem2.Checked = true;
			this.menuItem3.Checked = false;
			this.menuItem4.Checked = false;
			this.menuItem5.Checked = false;
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			this.printPreviewControl1.Zoom = 1f;
			this.menuItem3.Checked = true;
			this.menuItem2.Checked = false;
			this.menuItem4.Checked = false;
			this.menuItem5.Checked = false;
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			this.printPreviewControl1.Zoom = 1.5f;
			this.menuItem4.Checked = true;
			this.menuItem3.Checked = false;
			this.menuItem2.Checked = false;
			this.menuItem5.Checked = false;
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			this.printPreviewControl1.Zoom = 2f;
			this.menuItem3.Checked = false;
			this.menuItem4.Checked = false;
			this.menuItem2.Checked = false;
			this.menuItem5.Checked = true;
		}

		private void preview_Load(object sender, System.EventArgs e)
		{
			this.printPreviewControl1.Document = this.reportDocument1;
		}
	}
}
