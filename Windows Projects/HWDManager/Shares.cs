using System;
using System.IO;
using System.Collections;
using System.Runtime.InteropServices;

namespace HWD
{
           	[Flags]
        	public enum ShareType
            {
                   Disk		    = 0,
                   Printer		= 1,
                   Device		= 2,
                   IPC			= 3,
                   Special		= -2147483648,
          	}
            public class Share
            {
                  private string netName, path, comments;
                  private ShareType type;
                  public Share(string _name, string _path, ShareType _type, string _comments)
                  {
                   netName = _name;
                   path = _path;
                   type = _type;
                   comments = _comments;
                  }


                   public string NetName
		           {
                      get { return netName; }
                   }
                   public string Path
                   {
                     get {return path;}
                   }
                   public string Comments
                   {
                     get {return comments;}
                   }
                   public ShareType Type
                   {
                     get {return type;}
                   }
            }
            public class Shares : ReadOnlyCollectionBase
            {

	    #region Estructuras
   		[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
		protected struct UNIVERSAL_NAME_INFO
		{
			[MarshalAs(UnmanagedType.LPTStr)]
			public string lpUniversalName;
		}
   		[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
		protected struct SHARE_INFO_2
		{
			[MarshalAs(UnmanagedType.LPWStr)]
			public string NetName;
			public ShareType ShareType;
			[MarshalAs(UnmanagedType.LPWStr)]
			public string Remark;
			public int Permissions;
			public int MaxUsers;
			public int CurrentUsers;
			[MarshalAs(UnmanagedType.LPWStr)]
			public string Path;
			[MarshalAs(UnmanagedType.LPWStr)]
			public string Password;
		}
	 	[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
		protected struct SHARE_INFO_1
		{
			[MarshalAs(UnmanagedType.LPWStr)]
			public string NetName;
			public ShareType ShareType;
			[MarshalAs(UnmanagedType.LPWStr)]
			public string Remark;
		}
  #endregion

	    #region Funciones

		/// <summary>Get a UNC name</summary>
		[DllImport("mpr", CharSet=CharSet.Auto)]
		protected static extern int WNetGetUniversalName (string lpLocalPath,
			int dwInfoLevel, ref UNIVERSAL_NAME_INFO lpBuffer, ref int lpBufferSize);

		/// <summary>Get a UNC name</summary>
		[DllImport("mpr", CharSet=CharSet.Auto)]
		protected static extern int WNetGetUniversalName (string lpLocalPath,
			int dwInfoLevel, IntPtr lpBuffer, ref int lpBufferSize);

		/// <summary>Enumerate shares (NT)</summary>
		[DllImport("netapi32", CharSet=CharSet.Unicode)]
		protected static extern int NetShareEnum (string lpServerName, int dwLevel,
			out IntPtr lpBuffer, int dwPrefMaxLen, out int entriesRead,
			out int totalEntries, ref int hResume);

		/// <summary>Enumerate shares (9x)</summary>
		[DllImport("svrapi", CharSet=CharSet.Ansi)]
		protected static extern int NetShareEnum(
			[MarshalAs(UnmanagedType.LPTStr)] string lpServerName, int dwLevel,
			IntPtr lpBuffer, ushort cbBuffer, out ushort entriesRead,
			out ushort totalEntries);

		/// <summary>Free the buffer (NT)</summary>
		[DllImport("netapi32")]
		protected static extern int NetApiBufferFree(IntPtr lpBuffer);
		
		#endregion
        #region Constantes
       		protected const int MAX_PATH = 260;
           	protected const int NO_ERROR = 0;
  		    protected const int ERROR_ACCESS_DENIED = 5;
            protected const int ERROR_WRONG_LEVEL = 124;
            protected const int ERROR_MORE_DATA = 234;
            protected const int ERROR_NOT_CONNECTED = 2250;
            protected const int UNIVERSAL_NAME_INFO_LEVEL = 1;
            protected const int MAX_SI50_ENTRIES = 20;
            #endregion

              public  Shares(string server)
              {
                EnumerateShares(server);
              }
              public void Add(string name, string path, ShareType type, string comments )
              {
                InnerList.Add(new Share(name, path, type, comments));
              }
              public void CopyTo(Share[] array, int index)
              {
			   InnerList.CopyTo(array, index);
              }
               public  void EnumerateShares(string server)
		       {
                InnerList.Clear();
			    int level = 2;
			    int entriesRead, totalEntries, nRet, hResume = 0;
                IntPtr pBuffer = IntPtr.Zero;
                try
			    {
				 nRet = NetShareEnum(server, level, out pBuffer, -1,
					out entriesRead, out totalEntries, ref hResume);
                 if (ERROR_ACCESS_DENIED == nRet)
				 {
                 	level = 1;
					nRet = NetShareEnum(server, level, out pBuffer, -1,
						out entriesRead, out totalEntries, ref hResume);
				 }

				 if (NO_ERROR == nRet && entriesRead > 0)
				 {
					Type t = (2 == level) ? typeof(SHARE_INFO_2) : typeof(SHARE_INFO_1);
					int offset = Marshal.SizeOf(t);

					for (int i=0, lpItem=pBuffer.ToInt32(); i<entriesRead; i++, lpItem+=offset)
					{
						IntPtr pItem = new IntPtr(lpItem);
						if (1 == level)
						{
							SHARE_INFO_1 si = (SHARE_INFO_1)Marshal.PtrToStructure(pItem, t);
                            Add(si.NetName, string.Empty, si.ShareType, si.Remark);
						}
						else
						{
							SHARE_INFO_2 si = (SHARE_INFO_2)Marshal.PtrToStructure(pItem, t);
							Add(si.NetName, si.Path, si.ShareType, si.Remark);
						}
					}
				   }

			}
			finally
			{

				if (IntPtr.Zero != pBuffer)
					NetApiBufferFree(pBuffer);
			}
		}
  }

  /*
  class Class
	{


		[STAThread]
		static void Main(string[] args)
		{
          Shares shars = new Shares("200.78.88.22");
          foreach ( Share s in shars)
          {
           Console.WriteLine(s.NetName);
           Console.WriteLine(s.Type.ToString());
           Console.WriteLine(s.Path);
           Console.WriteLine(s.Comments);
          }
          Console.ReadLine();
        }
    }
    */
}

