using System;
using System.Runtime.InteropServices;
using WindowsShell.Nspace;

namespace HWD
{
	[Guid("6a125063-a28d-4666-a433-7a88ebe1bda8"),
	NsExtension(NsTarget.Desktop, "HWD Manager", FolderAttributes.Folder, InfoTip="Browse systems in HWD.", IconString=@"Software\HWD")]
	public class MainClass : NsExtension
	{
		public MainClass() : base(new Root())
		{
		}
	}
}
