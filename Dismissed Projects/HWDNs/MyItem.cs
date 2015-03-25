using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Wsi = WindowsShell.Interop;
using WindowsShell.Nspace;
using Microsoft.Win32;

namespace HWD
{
	public class MyItem : DefaultFolderObject
	{
		private readonly string n;
		internal static readonly Column ColName = new Column("Name", ColumnFormat.Left, 25);
		internal static readonly Column ColModel = new Column("Model", ColumnFormat.Left, 15);
		internal static readonly Column ColManufacturer = new Column("Manufacturer", ColumnFormat.Left, 15);
		internal static readonly Column ColSerialNumber = new Column("SerialNumber", ColumnFormat.Left, 15);
		internal static readonly Column ColOS = new Column("OS", ColumnFormat.Left, 15);
		internal static readonly ColumnCollection columns;
		private ShellMenuItem[] menuItems;
		private ShellMenuItem mnuDetails;
		private ShellMenuItem mnuRemoteDesktop;
		private ShellMenuItem mnuComputer;
		private string HWDPath = Registry.LocalMachine.OpenSubKey(@"Software\HWD\").GetValue("Path").ToString();

		static MyItem()
		{
			columns = new ColumnCollection();
			columns.Add(ColName);
			columns.Add(ColModel);
			columns.Add(ColManufacturer);
			columns.Add(ColSerialNumber);
			columns.Add(ColOS);
			columns.DefaultDisplayColumn = ColName;
			columns.DefaultSortColumn = ColName;
		}


		public MyItem(string n)
		{
			this.n = n;
		}

		public override ColumnCollection Columns
		{
			get
			{
				return columns;
			}
		}
		
		public override object GetColumnValue(Column column)
		{
			if (column == ColName)
			{
				return this.n;
			}
			else if (column == ColModel)
			{
				return SQLEngine.GetValue("Model", this.n);
			}
			else if (column == ColManufacturer)
			{
				return SQLEngine.GetValue("Manufacturer", this.n);
			}
			else if (column == ColSerialNumber)
			{
				return SQLEngine.GetValue("SerialNumber", this.n);
			}
			else if (column == ColOS)
			{
				return SQLEngine.GetValue("OS", this.n);
			}
			else
			{
				return null;
			}
		}

		public override ShellMenuItem[] MenuItems
		{
			get
			{
				if (menuItems == null)
				{
					mnuDetails = new ShellMenuItem("Details", "details", new EventHandler(Details));
					mnuRemoteDesktop = new ShellMenuItem("Remote Desktop", "remotedesktop", new EventHandler(RemoteDesktop));
					mnuComputer = new ShellMenuItem("Manage Computer", "managecomputer", new EventHandler(ManageComputer));
					menuItems = new ShellMenuItem[] { mnuDetails, mnuRemoteDesktop, mnuComputer };
				}

				return menuItems;
			}
		}

		public void Details(object sender, EventArgs args)
		{
			string arg = "/details " + this.n;
			ProcessStartInfo pr = new System.Diagnostics.ProcessStartInfo(HWDPath, arg);
			pr.WindowStyle = ProcessWindowStyle.Normal;
			Process.Start(pr);
		}

		public void RemoteDesktop(object sender, EventArgs args)
		{
			string arg = "/v: " + this.n;
			ProcessStartInfo pr = new System.Diagnostics.ProcessStartInfo("mstsc", arg);
			pr.WindowStyle = ProcessWindowStyle.Maximized;
			Process.Start(pr);
		}

		public void ManageComputer(object sender, EventArgs args)
		{
			string arg = @"%windir%\system32\compmgmt.msc /computer=" + this.n;
			ProcessStartInfo pr = new System.Diagnostics.ProcessStartInfo("mmc.exe", arg);
			pr.WindowStyle = ProcessWindowStyle.Maximized;
			Process.Start(pr);
		}
	
		public override string GetDisplayName(NameOptions opts)
		{
			return n;
		}

		public override ShellIcon GetIcon(bool open)
		{
			
			return ShellIcon.CreateFromFile(HWDPath,0,true,false);
		}

		public override byte[] Persist()
		{
			return Encoding.Default.GetBytes(n);
		}

		public override IFolderObject Restore(byte[] data)
		{
			throw new NotImplementedException();
		}
	}
}
