using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace HWD.DetailsControls
{
	public class Process : System.Windows.Forms.UserControl
	{
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button12;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button13;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListView lstPro;
		private System.Windows.Forms.ColumnHeader columnHeader25;
		private System.Windows.Forms.ColumnHeader columnHeader22;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.ComponentModel.Container components = null;
		private ListViewItem ProcessItem;
		private string ProcessID;
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

		public Process()
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
			this.button12 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.button13 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.lstPro = new System.Windows.Forms.ListView();
			this.columnHeader25 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader22 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// button12
			// 
			this.button12.Location = new System.Drawing.Point(512, 4);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(96, 32);
			this.button12.TabIndex = 33;
			this.button12.Text = "Get Processes";
			this.button12.Click += new System.EventHandler(this.button12_Click);
			// 
			// button13
			// 
			this.button13.Location = new System.Drawing.Point(224, 4);
			this.button13.Name = "button13";
			this.button13.Size = new System.Drawing.Size(96, 32);
			this.button13.TabIndex = 32;
			this.button13.Text = "Create";
			this.button13.Click += new System.EventHandler(this.button13_Click);
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.Color.White;
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox1.Location = new System.Drawing.Point(88, 12);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(128, 20);
			this.textBox1.TabIndex = 31;
			this.textBox1.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 16);
			this.label2.TabIndex = 30;
			this.label2.Text = "New Process:";
			// 
			// lstPro
			// 
			this.lstPro.BackColor = System.Drawing.Color.White;
			this.lstPro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstPro.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					 this.columnHeader25,
																					 this.columnHeader22,
																					 this.columnHeader9});
			this.lstPro.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lstPro.FullRowSelect = true;
			this.lstPro.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lstPro.Location = new System.Drawing.Point(0, 49);
			this.lstPro.Name = "lstPro";
			this.lstPro.Size = new System.Drawing.Size(614, 240);
			this.lstPro.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lstPro.TabIndex = 29;
			this.lstPro.View = System.Windows.Forms.View.Details;
			this.lstPro.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstPro_MouseDown);
			// 
			// columnHeader25
			// 
			this.columnHeader25.Text = "ID";
			this.columnHeader25.Width = 74;
			// 
			// columnHeader22
			// 
			this.columnHeader22.Text = "Process";
			this.columnHeader22.Width = 189;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "User";
			this.columnHeader9.Width = 150;
			// 
			// Process
			// 
			this.Controls.Add(this.button12);
			this.Controls.Add(this.button13);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lstPro);
			this.Name = "Process";
			this.Size = new System.Drawing.Size(614, 289);
			this.ResumeLayout(false);

		}
		#endregion

		private void changeStatus(string stringStatus)
		{
			if (ChangeStatus != null)
				ChangeStatus(stringStatus);
		}

		private void button13_Click(object sender, System.EventArgs e)
		{
			System.Management.ManagementOperationObserver observer = new System.Management.ManagementOperationObserver(); 
			Handler completionHandlerObj = new Handler(); 
			observer.ObjectReady  += new System.Management.ObjectReadyEventHandler(completionHandlerObj.Done);
			System.Management.ConnectionOptions co = new System.Management.ConnectionOptions();
			if (HWD.Details.anotherLogin && HWD.Details.username.Length > 0)
			{
				co.Username = HWD.Details.username;
				co.Password = HWD.Details.password;
			}
			System.Management.ManagementScope ms = new System.Management.ManagementScope("\\\\" + this.insys + "\\root\\cimv2", co);

			System.Management.ManagementPath path = new System.Management.ManagementPath( "Win32_Process");
			System.Management.ManagementClass processClass = new System.Management.ManagementClass(ms,path,null);

			object[] methodArgs = {this.textBox1.Text, null, null, 0};

			processClass.InvokeMethod (observer, "Create", methodArgs);

			int intCount = 0;
			while (!completionHandlerObj.IsComplete) 
			{ 
				if (intCount > 10)
				{
					MessageBox.Show("Create process timed out.", "Terminate Process Status");
					break;
				}
				System.Threading.Thread.Sleep(500); 
				intCount++;
			} 

			if (intCount != 10)
			{
				if (completionHandlerObj.ReturnObject.Properties["returnValue"].Value.ToString() == "0")
				{
					this.Refresh();
				}
				else
				{
					MessageBox.Show("Error creating new process.", "Create New Process");
				}
			}
			this.Update();
		}
		private void button12_Click(object sender, System.EventArgs e)
		{
			this.changeStatus("Getting process table...");
			System.Management.ManagementOperationObserver observer = new System.Management.ManagementOperationObserver(); 
			Handler completionHandlerObj = new Handler(); 
			observer.ObjectReady += new System.Management.ObjectReadyEventHandler(completionHandlerObj.Done);

			this.Cursor = Cursors.WaitCursor;
			string [] sitems = new string[3];
			try 
			{
				foreach(System.Management.ManagementObject mo in HWD.Details.Consulta("SELECT * FROM Win32_Process"))
				{
					sitems[0] = mo["ProcessID"].ToString();
					sitems[1] = mo["Name"].ToString();
					mo.InvokeMethod(observer,"GetOwner", null);
			
					while (!completionHandlerObj.IsComplete) 
					{ 
						System.Threading.Thread.Sleep(500); 
					} 

					if (completionHandlerObj.ReturnObject["returnValue"].ToString() == "0")
					{
						sitems[2] = completionHandlerObj.ReturnObject.Properties["User"].Value.ToString();
					}
					else
					{ 
						sitems[2] = "-";
					}
					ListViewItem lvItem = new ListViewItem(sitems,0);
					this.lstPro.Items.Add(lvItem);
				}
			} 
			catch
			{
				this.Cursor = Cursors.Default;
			}
			this.button12.Enabled = false;
			this.changeStatus("Online");
			this.Cursor = Cursors.Default;
		}

		private void lstPro_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			System.Windows.Forms.ListView listViewObject = (System.Windows.Forms.ListView) sender;
			ContextMenu mnuContextMenu = new ContextMenu();
			MenuItem menuItem;

			if (e.Button == System.Windows.Forms.MouseButtons.Right) 
			{
				ProcessItem = listViewObject.GetItemAt(e.X,e.Y);
				this.lstPro.ContextMenu = mnuContextMenu;

				try
				{
					ProcessID = ProcessItem.SubItems[0].Text;

					menuItem = new MenuItem();
					menuItem.Text = "Terminate Process";
					mnuContextMenu.MenuItems.Add(menuItem);
					menuItem.Click  += new System.EventHandler(this.menuItemTerminate_Click);
				}
				catch
				{
					
				}
			}
		}

		private void menuItemTerminate_Click(object sender, System.EventArgs e)
		{   
			ListViewItem lvItem;

			System.Management.ManagementOperationObserver observer = new System.Management.ManagementOperationObserver(); 
			Handler completionHandlerObj = new Handler(); 
			observer.ObjectReady  += new System.Management.ObjectReadyEventHandler(completionHandlerObj.Done);
			
			foreach (System.Management.ManagementObject mo in HWD.Details.Consulta("Select * from Win32_Process Where ProcessID = '" + ProcessID + "'"))
			{
				mo.InvokeMethod(observer, "Terminate", null);
			}
			
			int intCount = 0;
			while (!completionHandlerObj.IsComplete) 
			{ 
				if (intCount == 10)
				{
					MessageBox.Show("Terminate process timed out.", "Terminate Process Status");
					break;
				}
				System.Threading.Thread.Sleep(500); 
				intCount++;
			} 

			if (intCount != 10)
			{
				if (completionHandlerObj.ReturnObject.Properties["returnValue"].Value.ToString() == "0")
				{ 
					lvItem = ProcessItem;
					lvItem.Remove();
				}
				else
				{
					MessageBox.Show("Error terminating process.", "Terminate Process");
				}
			}
			ProcessID = "";
			ProcessItem = null;
			this.Update();
		}
	}
}
