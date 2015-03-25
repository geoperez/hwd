using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace HWD.DetailsControls
{
	public class Services : System.Windows.Forms.UserControl
	{
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button7;
		private System.Windows.Forms.ListView listViewServiceslistView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private string ServiceName;
		private string ServiceAction;
		private ListViewItem ServiceItem;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ImageList imageList1;
		public delegate void Status(string e);
		public event Status ChangeStatus;
		private System.Resources.ResourceManager m_ResourceManager;

		public System.Resources.ResourceManager rsxmgr
		{
			set
			{
				this.m_ResourceManager = value;
			}

		}

		public Services()
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Services));
			this.button7 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.listViewServiceslistView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.SuspendLayout();
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(512, 4);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(96, 32);
			this.button7.TabIndex = 29;
			this.button7.Text = "Get Services";
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// listViewServiceslistView1
			// 
			this.listViewServiceslistView1.BackColor = System.Drawing.Color.White;
			this.listViewServiceslistView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listViewServiceslistView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																										this.columnHeader1,
																										this.columnHeader2,
																										this.columnHeader3,
																										this.columnHeader4});
			this.listViewServiceslistView1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.listViewServiceslistView1.FullRowSelect = true;
			this.listViewServiceslistView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewServiceslistView1.Location = new System.Drawing.Point(0, 49);
			this.listViewServiceslistView1.Name = "listViewServiceslistView1";
			this.listViewServiceslistView1.Size = new System.Drawing.Size(614, 240);
			this.listViewServiceslistView1.SmallImageList = this.imageList1;
			this.listViewServiceslistView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.listViewServiceslistView1.TabIndex = 28;
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
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// Services
			// 
			this.Controls.Add(this.button7);
			this.Controls.Add(this.listViewServiceslistView1);
			this.Name = "Services";
			this.Size = new System.Drawing.Size(614, 289);
			this.Load += new System.EventHandler(this.Services_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void changeStatus(string stringStatus)
		{
			if (ChangeStatus != null)
				ChangeStatus(stringStatus);
		}

		private void button7_Click(object sender, System.EventArgs e)
		{
			this.changeStatus("Getting Services...");
			this.Cursor = Cursors.WaitCursor;
			string[] lvData =  new string[4];

			try 
			{
				foreach (System.Management.ManagementObject mo in HWD.Details.Consulta("SELECT * FROM Win32_Service"))
				{
					int icon = 1;
					lvData[0] = mo["Name"].ToString();
					lvData[1] = mo["StartMode"].ToString();
					if (mo["Started"].Equals(true))
					{
						lvData[2] = "Started";
					}
					else
					{
						lvData[2] = "Stop";
						icon = 0;
					}
					lvData[3] = mo["StartName"].ToString();
					
					ListViewItem lvItem = new ListViewItem(lvData,icon);
					this.listViewServiceslistView1.Items.Add(lvItem);
				}
			}

			catch
			{
				MessageBox.Show(this, "Error getting services.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			this.button7.Enabled = false;
			this.changeStatus("Online");
			this.Cursor = Cursors.Default;
		}

		private void listViewServiceslistView1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			System.Windows.Forms.ListView listViewObject = (System.Windows.Forms.ListView) sender;
			ContextMenu mnuContextMenu = new ContextMenu();
			MenuItem menuItem = new MenuItem();

			if (e.Button == System.Windows.Forms.MouseButtons.Right) 
			{
				ServiceName = listViewObject.GetItemAt(e.X, e.Y).Text;
				ServiceItem = listViewObject.GetItemAt(e.X,e.Y);

				listViewObject.ContextMenu = mnuContextMenu;
				try
				{
					foreach (System.Management.ManagementObject mo in HWD.Details.Consulta("SELECT * FROM Win32_Service Where Name = '" + ServiceName + "'"))
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
						menuItem.Click  += new System.EventHandler(this.menuItem3_Click);
					}
				}
				catch
				{
					MessageBox.Show("Can't get service status");
				}
			}
		}
		private void menuItem3_Click(object sender, System.EventArgs e)
		{   
			ListViewItem lvItem;

			System.Management.ManagementOperationObserver observer = new System.Management.ManagementOperationObserver(); 
			Handler completionHandlerObj = new Handler(); 
			observer.ObjectReady += new System.Management.ObjectReadyEventHandler(completionHandlerObj.Done);

			foreach (System.Management.ManagementObject mo in HWD.Details.Consulta("Select * from Win32_Service Where Name = '" + ServiceName + "'"))
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
				{
					lvItem.SubItems[2].Text = "Started";
					lvItem.ImageIndex = 1;
				}
				else
				{
					lvItem.SubItems[2].Text = "Stop";
					lvItem.ImageIndex = 0;
				}
			}
			else
			{
				MessageBox.Show("Failed to change state of service " + ServiceName + ".", "Start/Stop Service Failure");
			}

			ServiceName = "";
			ServiceAction = "";
			ServiceItem = null;
		}

		private void Services_Load(object sender, System.EventArgs e)
		{
			//this.button7.Text = m_ResourceManager.GetString("dbutton7");
			//this.columnHeader1.Text = m_ResourceManager.GetString("dcolumnHeader1"); 
			//this.columnHeader2.Text = m_ResourceManager.GetString("dcolumnHeader2"); 
			//this.columnHeader4.Text = m_ResourceManager.GetString("dcolumnHeader4"); 
		}
	}
}
