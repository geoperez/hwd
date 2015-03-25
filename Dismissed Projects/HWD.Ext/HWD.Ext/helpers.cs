using System;
using System.Runtime.InteropServices;
using System.Text;


namespace HWD.Ext
{
	public class Helpers
	{
		public const int SW_SHOW =5;
		#region Win32 Imports
		[DllImport("kernel32.dll")]
		internal static extern Boolean SetCurrentDirectory([MarshalAs(UnmanagedType.LPTStr)]string lpPathName);

		[DllImport("kernel32.dll")]
		internal static extern uint GetFileAttributes([MarshalAs(UnmanagedType.LPTStr)]string lpPathName);
		internal const uint FILE_ATTRIBUTE_DIRECTORY = 0x00000010;

		[DllImport("kernel32.dll")]
		internal static extern Boolean CreateProcess(
			string	lpApplicationName,
			string	lpCommandLine,
			uint	lpProcessAttributes,
			uint	lpThreadAttributes,
			Boolean bInheritHandles,
			uint	dwCreationFlags,
			uint	lpEnvironment,
			string	lpCurrentDirectory,
			StartupInfo lpStartupInfo,
			ProcessInformation lpProcessInformation);

		[DllImport("shell32")]
		internal static extern uint DragQueryFile(uint hDrop,uint iFile, StringBuilder buffer, int cch);

		[DllImport("user32")]
		internal static extern uint CreatePopupMenu();

		[DllImport("user32")]
		internal static extern int MessageBox(int hWnd, string text, string caption, int type);

		[DllImport("user32")]
		internal static extern int InsertMenuItem(uint hmenu, uint uposition, uint uflags, ref MENUITEMINFO mii);
		
		[DllImport("user32.dll", SetLastError=true)]
		internal static extern uint RegisterClipboardFormat(string lpszFormat);

		[DllImport("kernel32.dll")]
		internal static extern IntPtr GlobalLock(IntPtr hMem);

		[DllImport("kernel32.dll")]
		internal static extern bool GlobalUnlock(IntPtr hMem);

		[DllImport("user32.dll")]
		internal static extern bool InsertMenu(IntPtr hMenu, uint uPosition, uint uFlags,
		UIntPtr uIDNewItem, string lpNewItem);

		[DllImport("shell32.dll")]
		internal static extern IntPtr ShellExecute(IntPtr hwnd, string lpVerb, string lpFile,
		string lpParameters, string lpDirectory, int nShowCmd);

		#endregion
	}
}
