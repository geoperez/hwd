using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
namespace HWD.Ext
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	/// 
	[Guid("C6E8875C-5973-4197-9B35-9B8D38C2F9C4")]
	public class HWDContextMenuExt : IShellExtInit, IContextMenu
	{
		protected StringBuilder pcs = new StringBuilder();
		protected const string guid = "{C6E8875C-5973-4197-9B35-9B8D38C2F9C4}";
		public HWDContextMenuExt()
		{
		}

		int	IShellExtInit.Initialize (IntPtr pidlFolder, IntPtr lpdobj, uint hKeyProgID)
		{
			STGMEDIUM medium = new STGMEDIUM();
			IntPtr mem;
			mem = Marshal.AllocHGlobal (16000);
			try
			{
				HWD.Ext.NETRESOURCE  netResource;
				if (lpdobj != (IntPtr)0)
				{
					
					
					IDataObject dataObject = (IDataObject)Marshal.GetObjectForIUnknown(lpdobj);
					FORMATETC fmt = new FORMATETC();
					fmt.cfFormat =  HWD.Ext.Helpers.RegisterClipboardFormat("Net Resource");
					fmt.ptd		 = 0;
					fmt.dwAspect = DVASPECT.DVASPECT_CONTENT;
					fmt.lindex	 = -1;
					fmt.tymed	 = TYMED.TYMED_HGLOBAL;
				
					dataObject.GetData(ref fmt, ref medium);
					
					
					mem= HWD.Ext.Helpers.GlobalLock((IntPtr)medium.hGlobal);
					Type type = Type.GetType("HWD.Ext.NETRESOURCE");
					//unsafe
					{
					
//						NRESARRAY arr  = new NRESARRAY();
					//	arr.nr = new NETRESOURCE[1];

						Int32 ptr = mem.ToInt32();
						int numElementos = Marshal.ReadInt32(mem);
						ptr += Marshal.SizeOf(new uint());
						 //= new NETRESOURCE[1];
						
						//netResource[0]= new NETRESOURCE();
						Int32 inicio = ptr;
						pcs.Append("/scan ");
						for(int i=0;i<numElementos;i++)
						{
//							arr=(NRESARRAY)Marshal.PtrToStructure(mem,typeof(NRESARRAY));
//							//MessageBox.Show(arr.nr[i].lpRemoteName);
							if(i>0)
								pcs.Append(",");
								netResource = (NETRESOURCE)Marshal.PtrToStructure(new IntPtr(ptr),typeof(NETRESOURCE));
								pcs.Append(Marshal.PtrToStringUni(new IntPtr(netResource.remote.ToInt32() + inicio)));
								ptr += Marshal.SizeOf(netResource);
						}

					}
					
					
				}
			}
			catch(Exception e)
			{
				MessageBox.Show(e.Message);
			}
			finally
			{
				Marshal.FreeHGlobal( mem );
				Helpers.GlobalUnlock((IntPtr)medium.hGlobal);
			}
			return 0;
		}	
		

		int	IContextMenu.QueryContextMenu(uint hMenu, uint iMenu, int idCmdFirst, int idCmdLast, uint uFlags)
		{
			int id = 1;
			if ( (uFlags & 0xf) == 0 || (uFlags & (uint)CMF.CMF_EXPLORE) != 0)
			{
				
				Helpers.InsertMenu ( (IntPtr)hMenu, iMenu, 1024, (UIntPtr)idCmdFirst, "Scan with HWD" );
			}
			return id;
		}

		
		void IContextMenu.GetCommandString(int idCmd, uint uFlags, int pwReserved, StringBuilder commandString, int cchMax)
		{
			switch(uFlags)
			{				
				case (uint)GCS.HELPTEXT:
					commandString = new StringBuilder("Scan Selected Items With HWD");				
					break;
			}

		}

		
		void IContextMenu.InvokeCommand (IntPtr pici)
		{
			try
			{
				Type typINVOKECOMMANDINFO = Type.GetType("HWD.Ext.INVOKECOMMANDINFO");
				INVOKECOMMANDINFO ici = (INVOKECOMMANDINFO)Marshal.PtrToStructure(pici, typINVOKECOMMANDINFO);
				RegistryKey root = Registry.LocalMachine;
				RegistryKey key;
				key = root.OpenSubKey(@"Software\HWD");
				string path = (string)key.GetValue("Path");
				//MessageBox.Show(path);
				
				IntPtr res = Helpers.ShellExecute(IntPtr.Zero   ,"open",path,pcs.ToString(),"",Helpers.SW_SHOW);
			}
			catch(Exception e )
			{
				MessageBox.Show(e.Message);
			}
		}


		[System.Runtime.InteropServices.ComRegisterFunctionAttribute()]
		static void RegisterServer(String str1)
		{
			try
			{
				// For Winnt set me as an approved shellex
				RegistryKey root;
				RegistryKey rk;
				root = Registry.LocalMachine;
				rk = root.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Shell Extensions\\Approved", true);
				rk.SetValue(guid.ToString(), "BatchResults shell extension");
				rk.Close();

				
				root = Registry.ClassesRoot;
				rk = root.CreateSubKey("NetServer\\Shellex\\ContextMenuHandlers\\HWD");
				rk.SetValue("", guid.ToString());
				rk.Close();
			}
			catch(Exception e)
			{
				System.Console.WriteLine(e.ToString());
			}
		}

		[System.Runtime.InteropServices.ComUnregisterFunctionAttribute()]
		static void UnregisterServer(String str1)
		{
			try
			{
				RegistryKey root;
				RegistryKey rk;

				// Remove ShellExtenstions registration
				root = Registry.LocalMachine;
				rk = root.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Shell Extensions\\Approved", true);
				rk.DeleteValue(guid);
				rk.Close();

				// Delete  regkey
				root = Registry.ClassesRoot;
				root.DeleteSubKey("NetServer\\Shellex\\ContextMenuHandlers\\HWD");
			}
			catch(Exception e)
			{
				System.Console.WriteLine(e.ToString());
			}
		}

	}
}
