using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using WindowsShell.Nspace;

namespace HWD
{
	public class Root : DefaultFolderObject
	{        
		public Root()
		{
			
		}

		public override FolderAttributes Attributes
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override ColumnCollection Columns
		{
			get
			{
				return MyItem.columns;
			}
		}

		public override string GetDisplayName(NameOptions opts)
		{
			throw new NotImplementedException();
		}

		public override IEnumerable GetItems(IWin32Window owner)
		{
			if (SQLEngine.items == null)
				SQLEngine.GetDB();
			return SQLEngine.items;
		}

		public override byte[] Persist()
		{
			throw new NotImplementedException();
		}

		public override IFolderObject Restore(byte[] data)
		{
			return new MyItem(Encoding.Default.GetString(data));
		}
	}
}
