using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HWDServerConfig
{
	class Utilities
	{
		[DllImport( "crypt32.dll",
			 SetLastError=true,
			 CharSet=System.Runtime.InteropServices.CharSet.Auto)]
		private static extern
			bool CryptProtectData(  ref DATA_BLOB     pPlainText,
			string        szDescription,
			ref DATA_BLOB     pEntropy,
			IntPtr        pReserved,
			ref CRYPTPROTECT_PROMPTSTRUCT pPrompt,
			int           dwFlags,
			ref DATA_BLOB     pCipherText);		
		[DllImport( "crypt32.dll",
			 SetLastError=true,
			 CharSet=System.Runtime.InteropServices.CharSet.Auto)]
		private static extern
			bool CryptUnprotectData(ref DATA_BLOB       pCipherText,
			ref string          pszDescription,
			ref DATA_BLOB       pEntropy,
			IntPtr          pReserved,
			ref CRYPTPROTECT_PROMPTSTRUCT pPrompt,
			int             dwFlags,
			ref DATA_BLOB       pPlainText);
		[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
			internal struct DATA_BLOB
		{
			public int     cbData;
			public IntPtr  pbData;
		}
		[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
			internal struct CRYPTPROTECT_PROMPTSTRUCT
		{
			public int      cbSize;
			public int      dwPromptFlags;
			public IntPtr   hwndApp;
			public string   szPrompt;
		}
		public enum KeyType {UserKey = 1, MachineKey};		
		private const int CRYPTPROTECT_UI_FORBIDDEN  = 0x1;
		private const int CRYPTPROTECT_LOCAL_MACHINE = 0x4;
		
		private static byte [] Encrypt (byte [] text, KeyType keyType)
		{
			
			if(text==null) text = new byte[0];
			DATA_BLOB blobText  = new DATA_BLOB();
			DATA_BLOB fill = new DATA_BLOB();
			DATA_BLOB textEncryptedBlob = new DATA_BLOB();
			byte[] cipherTextBytes;
			try
			{	
				blobText.pbData = Marshal.AllocHGlobal(text.Length);			
				blobText.cbData = text.Length;
				Marshal.Copy(text, 0, blobText.pbData, text.Length);

				byte[] strFill={0};
				fill.pbData = Marshal.AllocHGlobal(strFill.Length);			
				fill.cbData = strFill.Length;
				Marshal.Copy(strFill, 0, fill.pbData, strFill.Length);



				int flags = CRYPTPROTECT_UI_FORBIDDEN;
				if (keyType == KeyType.MachineKey)
					flags |= CRYPTPROTECT_LOCAL_MACHINE;
				string desc="Password Sql Server";

				CRYPTPROTECT_PROMPTSTRUCT ps =
					new CRYPTPROTECT_PROMPTSTRUCT();
				ps.cbSize       = Marshal.SizeOf(
					typeof(CRYPTPROTECT_PROMPTSTRUCT));
				ps.dwPromptFlags= 0;
				ps.hwndApp      = IntPtr.Zero ;
				ps.szPrompt     = null;
				bool success = CryptProtectData(ref blobText,
					desc,
					ref fill,
					IntPtr.Zero,
					ref ps,
					flags,
					ref textEncryptedBlob);

				cipherTextBytes = new byte[textEncryptedBlob.cbData];

			
				Marshal.Copy(textEncryptedBlob.pbData,
					cipherTextBytes,
					0,
					textEncryptedBlob.cbData);

			}
			catch
			{
				throw new Exception("Can not Decryp Message");
			}
			finally
			{
				if(textEncryptedBlob.pbData!=IntPtr.Zero)
					Marshal.FreeHGlobal (textEncryptedBlob.pbData);
				if(blobText.pbData!=IntPtr.Zero)
					Marshal.FreeHGlobal (blobText.pbData);
				if(fill.pbData!=IntPtr.Zero)
					Marshal.FreeHGlobal (fill.pbData);
			}
			return cipherTextBytes;

		}
		public static string Encrypt(string text, KeyType keyType)
		{
			return Convert.ToBase64String(
				Encrypt(Encoding.UTF8.GetBytes(text), keyType)
				);
		}
		public static string   Decrypt(string encryptedText)
		{
			return Encoding.UTF8.GetString(
				Decrypt(    Convert.FromBase64String(encryptedText)	));
			
		}
		public static byte[] Decrypt(    byte[] encryptedText	)
		{
			if(encryptedText==null) encryptedText = new byte[0];

			DATA_BLOB plainTextBlob  = new DATA_BLOB();
			DATA_BLOB cipherTextBlob = new DATA_BLOB();
			DATA_BLOB fill    = new DATA_BLOB();
			byte[] plainTextBytes;


			try
			{
				cipherTextBlob.pbData = Marshal.AllocHGlobal(encryptedText.Length);			
				cipherTextBlob.cbData = encryptedText.Length;
				Marshal.Copy(encryptedText, 0, cipherTextBlob.pbData, encryptedText.Length);

				byte[] strFill={0};
				fill.pbData = Marshal.AllocHGlobal(strFill.Length);			
				fill.cbData = strFill.Length;
				Marshal.Copy(strFill, 0, fill.pbData, strFill.Length);

		
				CRYPTPROTECT_PROMPTSTRUCT ps =
					new CRYPTPROTECT_PROMPTSTRUCT();
				ps.cbSize       = Marshal.SizeOf(
					typeof(CRYPTPROTECT_PROMPTSTRUCT));
				ps.dwPromptFlags= 0;
				ps.hwndApp      = IntPtr.Zero ;
				ps.szPrompt     = null;
			
				string description = String.Empty;

				int flags = CRYPTPROTECT_UI_FORBIDDEN;

				bool success = CryptUnprotectData(ref cipherTextBlob,
					ref description,
					ref fill,
					IntPtr.Zero,
					ref ps,
					flags,
					ref plainTextBlob);	

				plainTextBytes = new byte[plainTextBlob.cbData];

				Marshal.Copy(plainTextBlob.pbData,
					plainTextBytes,
					0,
					plainTextBlob.cbData);			
			}
			catch
			{
				throw new Exception("Can not decrypy message");
			}
			finally
			{
				if (plainTextBlob.pbData !=IntPtr.Zero)
					Marshal.FreeHGlobal(plainTextBlob.pbData);
				if (cipherTextBlob.pbData !=IntPtr.Zero)
					Marshal.FreeHGlobal(cipherTextBlob.pbData);
				if (fill.pbData !=IntPtr.Zero)
					Marshal.FreeHGlobal(fill.pbData);
			}
			return plainTextBytes;
		}
		public static void ChecaTablas(SqlConnection conn)
		{
			StringBuilder sb = new StringBuilder();
			SqlCommand comm;
			comm = new SqlCommand();
			comm.Connection = conn;
			try
			{
				comm.CommandText ="Select 1 from HWD_TECHS";
				comm.ExecuteNonQuery();
			}
			catch
			{
				sb.Append("CREATE TABLE [HWD_TECHS] (\r\n");
				sb.Append("	[ID] [int] IDENTITY (1, 1) NOT NULL ,\r\n");
				sb.Append("	[Username] [char] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,\r\n");
				sb.Append("	[Name] [char] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,\r\n");
				sb.Append("	CONSTRAINT [PK_TechPersonal] PRIMARY KEY  CLUSTERED \r\n");
				sb.Append("	(\r\n");
				sb.Append("		[ID]\r\n");
				sb.Append("	)  ON [PRIMARY] \r\n");
				sb.Append(") ON [PRIMARY]\r\n");
		

				comm.CommandText = sb.ToString();
				comm.ExecuteNonQuery();
			}

			sb=new StringBuilder("");
			try
			{
				comm.CommandText ="Select 1 from HWD_BLOCKEDS";
				comm.ExecuteNonQuery();
			}
			catch
			{
				sb.Append("CREATE TABLE [HWD_BLOCKEDS] (\r\n");
				sb.Append("	[ID] [int] IDENTITY (1, 1) NOT NULL ,\r\n");
				sb.Append("	[InternalName] [char] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,\r\n");
				sb.Append("	[Owner] [char] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL \r\n");
				sb.Append(") ON [PRIMARY]\r\n");				

				comm.CommandText = sb.ToString();
				comm.ExecuteNonQuery();
				
			}

			sb=new StringBuilder("");
			try
			{
				comm.CommandText ="Select 1 from HWD_TICKETS";
				comm.ExecuteNonQuery();
			}
			catch
			{
				sb.Append("CREATE TABLE [HWD_TICKETS] (\r\n");
				sb.Append("	[ID] [int] IDENTITY (1, 1) NOT NULL ,\r\n");
				sb.Append("	[Machine] [char] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,\r\n");
				sb.Append("	[Username] [char] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL , \r\n");
				sb.Append(" [Kind] [char] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL , \r\n");
				sb.Append(" [Title] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL , \r\n");
				sb.Append(" [Description] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL , \r\n");
				sb.Append(" [Status] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL , \r\n");
				sb.Append(" [Showit] [bit] NULL CONSTRAINT [DF_Tickets_Showit] DEFAULT (1), \r\n");
				sb.Append(" [Tech] [int] NULL CONSTRAINT [DF_Tickets_Tech] DEFAULT (0), \r\n");
				sb.Append(" [CreateDate] [datetime] NULL , \r\n");
				sb.Append(" [CompleteDate] [datetime] NULL , \r\n");
				sb.Append(" CONSTRAINT [PK_Tickets] PRIMARY KEY  CLUSTERED \r\n");
				sb.Append("	(\r\n");
				sb.Append("		[ID]\r\n");
				sb.Append("	)  ON [PRIMARY] \r\n");
				sb.Append(") ON [PRIMARY]\r\n");			

				comm.CommandText = sb.ToString();
				comm.ExecuteNonQuery();
				
			}
		}
	}
}
