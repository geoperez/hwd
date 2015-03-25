using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Crownwood.DotNetMagic;

namespace HWD.DetailsControls
{

	public class SharedItems : System.Windows.Forms.UserControl
	{
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button8;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private ListViewItem tItem;
		private System.ComponentModel.IContainer components;
		private string insys = HWD.Details.insys;
		private System.Windows.Forms.ImageList imageList1;
		private System.Resources.ResourceManager m_ResourceManager;

		public System.Resources.ResourceManager rsxmgr
		{
			set
			{
				this.m_ResourceManager = value;
			}

		}

		public SharedItems()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SharedItems));
			this.button8 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.SuspendLayout();
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(512, 4);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(96, 32);
			this.button8.TabIndex = 29;
			this.button8.Text = "Get Items";
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// listView1
			// 
			this.listView1.BackColor = System.Drawing.Color.White;
			this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader5,
																						this.columnHeader7,
																						this.columnHeader6,
																						this.columnHeader8});
			this.listView1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.listView1.FullRowSelect = true;
			this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView1.Location = new System.Drawing.Point(0, 49);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(614, 240);
			this.listView1.SmallImageList = this.imageList1;
			this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.listView1.TabIndex = 28;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
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
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// SharedItems
			// 
			this.Controls.Add(this.button8);
			this.Controls.Add(this.listView1);
			this.Name = "SharedItems";
			this.Size = new System.Drawing.Size(614, 289);
			this.Load += new System.EventHandler(this.SharedItems_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void button8_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			string [] sitems = new string[4];

			foreach(System.Management.ManagementObject mo in HWD.Details.Consulta("SELECT * FROM Win32_Share"))
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

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			System.Diagnostics.Process process = new System.Diagnostics.Process();
			process.StartInfo.UseShellExecute = true;			
			process.StartInfo.FileName = "Explorer";
			process.StartInfo.Arguments = "\\\\" + this.insys + "\\" + tItem.SubItems[0].Text;			
			process.Start();
		}

		private void listView1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			System.Windows.Forms.ListView listViewObject = (System.Windows.Forms.ListView) sender;
			ContextMenu mnuContextMenu = new ContextMenu();
			MenuItem menuItem;

			if (e.Button == System.Windows.Forms.MouseButtons.Right) 
			{
				tItem = listViewObject.GetItemAt(e.X,e.Y);

				this.listView1.ContextMenu = mnuContextMenu;

				menuItem = new MenuItem();
				menuItem.Text = "Explore";
				menuItem.Click += new System.EventHandler(this.menuItem2_Click);
				mnuContextMenu.MenuItems.Add(menuItem);

			}
		}

		private void SharedItems_Load(object sender, System.EventArgs e)
		{
			this.button8.Text = m_ResourceManager.GetString("dbutton8");
			this.columnHeader5.Text = m_ResourceManager.GetString("dcolumnHeader5"); 
			this.columnHeader6.Text = m_ResourceManager.GetString("dcolumnHeader6"); 
			this.columnHeader7.Text = m_ResourceManager.GetString("dcolumnHeader7"); 
			this.columnHeader8.Text = m_ResourceManager.GetString("dcolumnHeader8");
		}
	}
}
