using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Crownwood.DotNetMagic;

namespace HWD.DetailsControls
{
	public class EventLog : System.Windows.Forms.UserControl
	{
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button11;
		private System.Windows.Forms.ListView listView3;
		private System.Windows.Forms.ColumnHeader columnHeader24;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.ColumnHeader columnHeader20;
		private System.Windows.Forms.ImageList imageList1;
		private System.ComponentModel.IContainer components;
		private string insys = HWD.Details.insys;
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

		public EventLog()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(EventLog));
			this.button11 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.listView3 = new System.Windows.Forms.ListView();
			this.columnHeader24 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader20 = new System.Windows.Forms.ColumnHeader();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.SuspendLayout();
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(512, 4);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(96, 32);
			this.button11.TabIndex = 29;
			this.button11.Text = "Get Log";
			this.button11.Click += new System.EventHandler(this.button11_Click_1);
			// 
			// listView3
			// 
			this.listView3.BackColor = System.Drawing.Color.White;
			this.listView3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader24,
																						this.columnHeader10,
																						this.columnHeader12,
																						this.columnHeader20});
			this.listView3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.listView3.FullRowSelect = true;
			this.listView3.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView3.Location = new System.Drawing.Point(0, 49);
			this.listView3.Name = "listView3";
			this.listView3.Size = new System.Drawing.Size(614, 240);
			this.listView3.SmallImageList = this.imageList1;
			this.listView3.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.listView3.TabIndex = 28;
			this.listView3.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader24
			// 
			this.columnHeader24.Text = "Type";
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "Event Code";
			this.columnHeader10.Width = 101;
			// 
			// columnHeader12
			// 
			this.columnHeader12.Text = "Source";
			this.columnHeader12.Width = 70;
			// 
			// columnHeader20
			// 
			this.columnHeader20.Text = "Message";
			this.columnHeader20.Width = 298;
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// EventLog
			// 
			this.Controls.Add(this.button11);
			this.Controls.Add(this.listView3);
			this.Name = "EventLog";
			this.Size = new System.Drawing.Size(614, 289);
			this.Load += new System.EventHandler(this.EventLog_Load);
			this.ResumeLayout(false);

		}
		#endregion
		
		private void changeStatus(string stringStatus)
		{
			if (ChangeStatus != null)
				ChangeStatus(stringStatus);
		}

		private void button11_Click_1(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			this.changeStatus("Getting event log...");
			string [] sitems = new string[4];
			try 
			{
				foreach(System.Management.ManagementObject mo in HWD.Details.Consulta("SELECT * FROM Win32_NTLogEvent"))
				{
					sitems[0] = mo["Type"].ToString();
					sitems[1] = mo["EventCode"].ToString();
					sitems[2] = mo["SourceName"].ToString();
					sitems[3] = mo["Message"].ToString();
					sitems[3].Replace("\n\r", " ");
					ListViewItem lvItem = new ListViewItem(sitems,0);
					this.listView3.Items.Add(lvItem);
				}
			} 
			catch
			{
				this.Cursor = Cursors.Default;
			}
			this.changeStatus("Online");
			this.Cursor = Cursors.Default;
		}

		private void EventLog_Load(object sender, System.EventArgs e)
		{
			this.columnHeader10.Text = m_ResourceManager.GetString("dcolumnHeader10"); 
			this.columnHeader12.Text = m_ResourceManager.GetString("dcolumnHeader12");
			this.columnHeader20.Text = m_ResourceManager.GetString("dcolumnHeader20");  
			this.columnHeader24.Text = m_ResourceManager.GetString("dcolumnHeader7");
		}
	}
}
