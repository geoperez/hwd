using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace HWD.DetailsControls
{
	public class HotFix : System.Windows.Forms.UserControl
	{
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button9;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Data.DataView dviHotfix;
		private System.Data.DataSet tempds;
		private System.Windows.Forms.ContextMenu cmnHotfix;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.ComponentModel.Container components = null;
		private string insys = HWD.Details.insys;
		private System.Resources.ResourceManager m_ResourceManager;
		private Point rightMouseDownPoint;
		public delegate void Status(string e);
		public event Status ChangeStatus;

		public System.Resources.ResourceManager rsxmgr
		{
			set
			{
				this.m_ResourceManager = value;
			}

		}

		public HotFix()
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button9 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.dataGrid2 = new System.Windows.Forms.DataGrid();
			this.cmnHotfix = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.dviHotfix = new System.Data.DataView();
			this.tempds = new System.Data.DataSet();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dviHotfix)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tempds)).BeginInit();
			this.SuspendLayout();
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(512, 4);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(96, 32);
			this.button9.TabIndex = 29;
			this.button9.Text = "Get Hotfixes";
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// dataGrid2
			// 
			this.dataGrid2.AlternatingBackColor = System.Drawing.Color.LightGray;
			this.dataGrid2.BackColor = System.Drawing.Color.Gainsboro;
			this.dataGrid2.BackgroundColor = System.Drawing.Color.Silver;
			this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid2.CaptionBackColor = System.Drawing.Color.LightSteelBlue;
			this.dataGrid2.CaptionForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid2.CaptionText = "Hotfixes to Install";
			this.dataGrid2.CaptionVisible = false;
			this.dataGrid2.ContextMenu = this.cmnHotfix;
			this.dataGrid2.DataMember = "";
			this.dataGrid2.DataSource = this.dviHotfix;
			this.dataGrid2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dataGrid2.FlatMode = true;
			this.dataGrid2.Font = new System.Drawing.Font("Tahoma", 8F);
			this.dataGrid2.ForeColor = System.Drawing.Color.Black;
			this.dataGrid2.GridLineColor = System.Drawing.Color.DimGray;
			this.dataGrid2.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
			this.dataGrid2.HeaderBackColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid2.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.dataGrid2.HeaderForeColor = System.Drawing.Color.White;
			this.dataGrid2.LinkColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid2.Location = new System.Drawing.Point(0, 49);
			this.dataGrid2.Name = "dataGrid2";
			this.dataGrid2.ParentRowsBackColor = System.Drawing.Color.DarkGray;
			this.dataGrid2.ParentRowsForeColor = System.Drawing.Color.Black;
			this.dataGrid2.PreferredColumnWidth = 85;
			this.dataGrid2.ReadOnly = true;
			this.dataGrid2.SelectionBackColor = System.Drawing.Color.CadetBlue;
			this.dataGrid2.SelectionForeColor = System.Drawing.Color.White;
			this.dataGrid2.Size = new System.Drawing.Size(614, 240);
			this.dataGrid2.TabIndex = 28;
			this.dataGrid2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGrid2_MouseDown);
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
			// tempds
			// 
			this.tempds.DataSetName = "NewDataSet";
			this.tempds.Locale = new System.Globalization.CultureInfo("es-MX");
			// 
			// HotFix
			// 
			this.Controls.Add(this.button9);
			this.Controls.Add(this.dataGrid2);
			this.Name = "HotFix";
			this.Size = new System.Drawing.Size(614, 289);
			this.Load += new System.EventHandler(this.HotFix_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dviHotfix)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tempds)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void changeStatus(string stringStatus)
		{
			if (ChangeStatus != null)
				ChangeStatus(stringStatus);
		}

		private void button9_Click(object sender, System.EventArgs e)
		{
			this.changeStatus("Getting hotfix table...");
			try 
			{
				string OS = string.Empty;
				this.Cursor = Cursors.WaitCursor;
				this.tempds.ReadXml("hwdhf.xml");
				this.tempds.Tables[0].Columns.Remove("ProductID");
				this.dviHotfix.Table = this.tempds.Tables[0];
				foreach(System.Management.ManagementObject mo in HWD.Details.Consulta("SELECT * FROM Win32_OperatingSystem"))
				{
					OS = mo["Caption"].ToString().Replace("Microsoft ", "");
				}
				this.dviHotfix.RowFilter = "Product like '%" + OS + "%'";
				foreach(System.Management.ManagementObject mo in HWD.Details.Consulta("SELECT * FROM Win32_QuickFixEngineering"))
				{
					string id = mo["HotFixID"].ToString();
					string desc = mo["Description"].ToString();
					if (id != "File 1")
					{
						int k = 0;
						foreach(DataRow dr in this.tempds.Tables[0].Rows)
						{
							string myid = dr["ID"].ToString();
							if (id.IndexOf(myid) > 0 || desc.IndexOf(myid) > 0 || dr["UrlPatch"].ToString().IndexOf(".exe") < 1) 
							{
								this.tempds.Tables[0].Rows[k].Delete();
								break;
							}
							k++;
						}
					}
				}
				this.dviHotfix.Table = this.tempds.Tables[0];
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.ToString());
			}
			this.button9.Enabled = false;
			this.Cursor = Cursors.Default;
			this.changeStatus("Online");
		}

		private void HotFix_Load(object sender, System.EventArgs e)
		{
			//this.button9.Text = m_ResourceManager.GetString("dbutton9");
			//this.dataGrid2.CaptionText = m_ResourceManager.GetString("ddataGrid2");
			//this.menuItem1.Text = m_ResourceManager.GetString("dmenuItem1");
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			Point pt = dataGrid2.PointToClient(rightMouseDownPoint); 

			try
			{
				HotFixInstaller hotInstall = new HotFixInstaller();
				hotInstall.computername = this.insys;
				hotInstall.url = dataGrid2[dataGrid2.HitTest(pt).Row, 4].ToString();
				if (HWD.Details.anotherLogin)
				{
					hotInstall.anotherLogin = true;
					hotInstall.username = HWD.Details.username;
					hotInstall.password = HWD.Details.password;
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
	}
}
