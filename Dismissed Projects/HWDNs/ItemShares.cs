using System;
using System.Collections;
using WShell.Nspace;
using System.Windows.Forms;

namespace HWD
{
	public class ItemShare : DefaultFolderObject
	{
		private int n;
		private string name;

		public ItemShare(int n, string name)
		{
			this.n = n;
			this.name = name;
		}

		public override FolderAttributes Attributes
		{
			get
			{
				return FolderAttributes.CanRename | FolderAttributes.CanCopy;
			}
		}

		public override string GetDisplayName(NameOptions opts)
		{
			return name;
		}

		public override byte[] Persist()
		{
			return BitConverter.GetBytes(n);
		}

		public override IFolderObject Restore(byte[] data)
		{
			throw new NotImplementedException();
		}

		public override void SetName(IWin32Window owner, string name, NameOptions opts)
		{
			this.name = name;
		}
	}
}
