using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace HWD.HWDKernel.CabinetFile
{
	public class TCabinetFile : CollectionBase, IBindingList
	{
		/// <summary>
		/// The FileCallback callback function is used by a number of the setup functions. The PSP_FILE_CALLBACK type defines a pointer to this callback function. FileCallback is a placeholder for the application-defined function name.
		/// Platform SDK: Setup API
		/// </summary>
		private uint CallBack(uint context, uint notification, IntPtr param1, IntPtr param2)
		{
			uint rtnValue = SetupApiWrapper.NO_ERROR;
			switch (notification)
			{        
				case SetupApiWrapper.SPFILENOTIFY_FILEINCABINET:
					rtnValue = OnFileFound(context, notification, param1, param2);
					break;
				case SetupApiWrapper.SPFILENOTIFY_FILEEXTRACTED:
					rtnValue = OnFileExtractComplete(param1);
					break;
				case SetupApiWrapper.SPFILENOTIFY_NEEDNEWCABINET:
					rtnValue = SetupApiWrapper.NO_ERROR;
					break;
			}
			return rtnValue;
		}


		public TCabinetFile()
		{

		}

		public TCabinetFile(string sCabFileName)
		{
			this.Name = sCabFileName;
		}

		/// <summary>
		/// Cabinet file name
		/// </summary>
		private string m_Name = "";
		public string Name
		{
			set 
			{ 
				if (!System.IO.File.Exists(value))
					throw new System.Exception("This CabFile doesn't exist");

				PSP_FILE_CALLBACK callback = new PSP_FILE_CALLBACK(this.CallBack);				
				uint setupIterateCabinetAction = (uint)SetupIterateCabinetAction.Iterate;
				if (!SetupApiWrapper.SetupIterateCabinet(value, 0, callback, setupIterateCabinetAction))
				{
					string errMsg = new Win32Exception((int)KernelApiWrapper.GetLastError()).Message;
					System.Windows.Forms.MessageBox.Show(errMsg);
				}	
				m_Name = value;
			}
			get { return m_Name;}
		}
        
		/// <summary>
		/// output directory
		/// </summary>
		private string m_OutputDirectory = "";
		public string OutputDirectory
		{
			set 
			{
				if (!System.IO.Directory.Exists(value))
					throw new System.Exception("The Output directory doesn't exist.");

				m_OutputDirectory = value;
			}
			get 
			{
				if (m_OutputDirectory.Length <=0 )
					return System.IO.Directory.GetCurrentDirectory();
				return m_OutputDirectory;
			}
		}
        

		/// <summary>
		/// if true, extract file without path in cabinet
		/// </summary>
		private bool m_IgnoreInsidePath = false;
		public bool IgnoreInsidePath
		{
			set { m_IgnoreInsidePath = value;}
			get { return m_IgnoreInsidePath;}
		}

		
		#region Events
		private ListChangedEventHandler m_ListChanged;
		public event ListChangedEventHandler ListChanged
		{
			add
			{
				m_ListChanged += value;
			}
			remove
			{
				m_ListChanged -= value;
			}
		}

		private ListChangedEventArgs resetEvent = new ListChangedEventArgs(ListChangedType.Reset, -1);

		private EventHandler m_FileFound;
		public event EventHandler FileFound
		{
			add
			{
				m_FileFound += value;
			}
			remove
			{
				m_FileFound -= value;
			}
		}

		
		private EventHandler m_FileExtractBefore;
		public event EventHandler FileExtractBefore
		{
			add
			{
				m_FileExtractBefore += value;
			}
			remove
			{
				m_FileExtractBefore -= value;
			}
		}

		
		private EventHandler m_FileExtractComplete;
		public event EventHandler FileExtractComplete
		{
			add
			{
				m_FileExtractComplete += value;
			}
			remove
			{
				m_FileExtractComplete -= value;
			}
		}

		#endregion

		#region CollectionBase Method
		
		public int Add(TFile item)
		{
			throw new NotSupportedException();
			//	return (List.Add(item));			
		}

		public int IndexOf(TFile item)  
		{
			return( List.IndexOf( item ) );
		}

		public void Insert(int index, TFile item)  
		{
			throw new NotSupportedException();
			//			List.Insert(index, item);
		}

		public void Remove(TFile item)
		{
			throw new NotSupportedException();
			//			List.Remove(item);
		}

		
		public bool Contains(TFile item)  
		{
			return( List.Contains( item ) );
		}


		public TFile this[int index]
		{
			get	{	return (TFile)List[index] ;	}
			set	
			{	
				throw new NotSupportedException();
				//	List[index] = value;		
			}
		}

		public override string ToString()
		{
			return this.Name;
		}

		public override int GetHashCode()
		{
			return (this.Count);
		}

		public override bool Equals(object obj)
		{
			if (obj==null) return false;
			if (this.GetType() != obj.GetType()) return false;

			TCabinetFile other = (TCabinetFile)obj;
			return (string.Compare(this.Name, other.Name, true)==0);
		}

		public static bool operator ==(TCabinetFile a, TCabinetFile b)
		{
			if ((object)a == null) return false;
			return a.Equals(b);
		}

		public static bool operator !=(TCabinetFile a, TCabinetFile b)
		{
			return !(a==b);
		}
		
		#endregion

		protected virtual uint OnFileFound(uint context, uint notification, IntPtr param1, IntPtr param2)
		{
			uint fileOperation = SetupApiWrapper.NO_ERROR;
			FILE_IN_CABINET_INFO fileInCabinetInfo = (FILE_IN_CABINET_INFO)Marshal.PtrToStructure(param1, typeof(FILE_IN_CABINET_INFO));
			TFile file = new TFile(fileInCabinetInfo);
			switch(context)
			{
				case (uint)SetupIterateCabinetAction.Iterate:
					List.Add(file);
					if (m_FileFound != null)
						m_FileFound(file, System.EventArgs.Empty);
					fileOperation = (uint)FILEOP.FILEOP_SKIP;
					break;

				case (uint)SetupIterateCabinetAction.Extract:
					if (this.m_ExtractAll)
						this.m_ExtractFileIndex = this.IndexOf(file);

					fileOperation = OnFileExtractBefore(file);
					if (fileOperation == (uint)FILEOP.FILEOP_DOIT)
					{
						fileInCabinetInfo.FullTargetName = MakeExtractFileName(file);
						Marshal.StructureToPtr(fileInCabinetInfo, param1, true);
					}
					break;
			}
			return fileOperation;	
		}

		protected virtual uint OnFileExtractBefore(TFile file)
		{
			bool cancel = false;

			if (file != (TFile)this.List[m_ExtractFileIndex])
				return (uint)FILEOP.FILEOP_SKIP;

			if (m_FileExtractBefore != null)
			{
				System.ComponentModel.CancelEventArgs arg = new CancelEventArgs(false);
				m_FileExtractBefore(file, arg);
				cancel = arg.Cancel;
			}
			if (cancel)  
				return (uint)FILEOP.FILEOP_SKIP;

			return (uint)FILEOP.FILEOP_DOIT;
		}

		protected virtual uint OnFileExtractComplete(IntPtr param1)
		{
			FILEPATHS filePaths = 
				(FILEPATHS)Marshal.PtrToStructure(param1, typeof(FILEPATHS));

			if (m_FileExtractComplete != null && filePaths.Win32Error == SetupApiWrapper.NO_ERROR)
				m_FileExtractComplete(filePaths.Target, System.EventArgs.Empty);

			return filePaths.Win32Error;
		}
		


		#region Envent Handler for collection
		
		protected virtual void OnListChanged(ListChangedEventArgs ev)
		{
			if (m_ListChanged != null)
				m_ListChanged(this, ev);
		}

		protected override void OnClear()
		{
			throw new NotSupportedException();
			//			base.OnClear ();
		}

		protected override void OnClearComplete()
		{
			OnListChanged(resetEvent);
		}

		//		protected override void OnInsert(int index, object value)
		//		{
		//			throw new NotSupportedException();
		////			base.OnInsert (index, value);
		//		}

		protected override void OnInsertComplete(int index, object value)
		{
			OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index));
		}

		protected override void OnRemove(int index, object value)
		{
			throw new NotSupportedException();
			//			base.OnRemove (index, value);
		}

		protected override void OnRemoveComplete(int index, object value)
		{
			OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
		}

		protected override void OnSetComplete(int index, object oldValue, object newValue)
		{
			if(oldValue != newValue)
				OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index));
		}	
		#endregion

		#region IBindingList Implements
		
		bool IBindingList.AllowEdit
		{
			get {return false;}
		}

		bool IBindingList.AllowNew
		{
			get {return false;}
		}

		bool IBindingList.AllowRemove
		{
			get {return false;}
		}

		bool IBindingList.SupportsChangeNotification
		{
			get {return true;}
		}

		bool IBindingList.SupportsSearching
		{
			get {return false;}
		}

		bool IBindingList.SupportsSorting
		{
			get {return false;}
		}

		object IBindingList.AddNew()
		{
			throw new NotSupportedException();
			//			TFile file = new TFile();
			//			List.Add(file);
			//			return file;
		}


		bool IBindingList.IsSorted 
		{
			get { throw new NotSupportedException(); }
		}

		ListSortDirection IBindingList.SortDirection 
		{ 
			get { throw new NotSupportedException(); }
		}


		PropertyDescriptor IBindingList.SortProperty 
		{ 
			get { throw new NotSupportedException(); }
		}


		void IBindingList.AddIndex(PropertyDescriptor property)
		{
			throw new NotSupportedException();
		}

		void IBindingList.ApplySort(PropertyDescriptor property, ListSortDirection direction) 
		{
			throw new NotSupportedException(); 
		}

		int IBindingList.Find(PropertyDescriptor property, object key) 
		{
			throw new NotSupportedException(); 
		}

		void IBindingList.RemoveIndex(PropertyDescriptor property) 
		{
			throw new NotSupportedException(); 
		}

		void IBindingList.RemoveSort() 
		{
			throw new NotSupportedException(); 
		}

		#endregion


		private int m_ExtractFileIndex = -1;	// Target file index for extracting
		private bool m_ExtractAll  = false;		// if true, extract all

		public void ExtractAll()
		{
			m_ExtractAll = true;
			m_ExtractFileIndex = 0;
			
			PSP_FILE_CALLBACK callback = new PSP_FILE_CALLBACK(this.CallBack);
				
			uint setupIterateCabinetAction = (uint)SetupIterateCabinetAction.Extract;
			if (!SetupApiWrapper.SetupIterateCabinet(this.Name, 0, callback, setupIterateCabinetAction))
			{
				string errMsg = new Win32Exception((int)KernelApiWrapper.GetLastError()).Message;
				System.Windows.Forms.MessageBox.Show(errMsg);
			}	
		}

		public void Extract(string sFile)
		{
			int intI = 0;
			foreach(TFile file in this)
			{
				if (string.Compare(file.FullName, sFile, true)==0)
				{
					Extract(intI);
					return;
				}
				intI++;
			}
		}
	
		public void Extract(TFile file)
		{
			int intI = this.IndexOf(file);
			Extract(intI);
		}

		public void Extract(int index)
		{
			m_ExtractAll = false;
			m_ExtractFileIndex = index;
			
			PSP_FILE_CALLBACK callback = new PSP_FILE_CALLBACK(this.CallBack);
				
			uint setupIterateCabinetAction = (uint)SetupIterateCabinetAction.Extract;
			if (!SetupApiWrapper.SetupIterateCabinet(this.Name, 0, callback, setupIterateCabinetAction))
			{
				string errMsg = new Win32Exception((int)KernelApiWrapper.GetLastError()).Message;
				System.Windows.Forms.MessageBox.Show(errMsg);
			}	
		}

		private string MakeExtractFileName(TFile file)
		{
			string sFile = this.OutputDirectory;
			if (!this.IgnoreInsidePath && file.Path.Length >0)
			{
				sFile += System.IO.Path.DirectorySeparatorChar.ToString() + file.Path;
				if (!System.IO.Directory.Exists(sFile))
					System.IO.Directory.CreateDirectory(sFile);
			}
			sFile += System.IO.Path.DirectorySeparatorChar.ToString() + file.Name;
			sFile = sFile.Replace(@"\\", @"\");
			return sFile;
		}

	}
	
	/// <summary>
	/// The FILE_IN_CABINET_INFO class provides information about a file found in the cabinet.
	/// Platform SDK: Setup API 
	/// </summary>
	[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
	public class FILE_IN_CABINET_INFO
	{
		public String	NameInCabinet;
		public uint		FileSize;  
		public uint		Win32Error;  
		public ushort	DosDate;  
		public ushort	DosTime;  
		public ushort	DosAttribs;  
		
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst=260)]
		public System.String	FullTargetName;
	}
	
	/// <summary>
	/// The FILEPATHS structure stores source and target path information. 
	/// Platform SDK: Setup API 
	/// </summary>
	[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
	public class FILEPATHS
	{
		public String Target;  
		public String  Source;  
		public uint Win32Error;  
		public uint  Flags;
	} 

	/// <summary>
	/// The FILETIME structure is a 64-bit value representing the number of 100-nanosecond intervals since January 1, 1601 (UTC).
	/// Platform SDK: Windows System Information 
	/// </summary>
	[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
	public class FILETIME
	{
		public uint dwLowDateTime;  
		public uint dwHighDateTime;
	} 

	/// <summary>
	/// The SYSTEMTIME structure represents a date and time using individual members for the month, day, year, weekday, hour, minute, second, and millisecond.
	/// Platform SDK: Windows System Information
	/// </summary>
	[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
	public class SYSTEMTIME
	{
		public ushort wYear;  
		public ushort wMonth;  
		public ushort wDayOfWeek;
		public ushort wDay;  
		public ushort wHour;  
		public ushort wMinute;  
		public ushort wSecond;  
		public ushort wMilliseconds;  
	} 

	
	public enum FILEOP:uint
	{
		FILEOP_ABORT=0, // Abort cabinet processing.
		FILEOP_DOIT,	// Extract the current file.
		FILEOP_SKIP		// Skip the current file.
	}

	public enum SetupIterateCabinetAction:uint
	{
		Iterate=0, Extract 
	}
	
	/// <summary>
	/// The FileCallback callback function is used by a number of the setup functions. The PSP_FILE_CALLBACK type defines a pointer to this callback function. FileCallback is a placeholder for the application-defined function name.
	/// Platform SDK: Setup API
	/// </summary>
	public delegate uint PSP_FILE_CALLBACK(uint context, uint notification, IntPtr param1, IntPtr param2);
	
	/// <summary>
	/// SetupApi Wrapper class
	/// Platform SDK: Setup API
	/// </summary>
	public class SetupApiWrapper
	{
		public const uint SPFILENOTIFY_FILEINCABINET      = 0x00000011;	// The file has been extracted from the cabinet.
		public const uint SPFILENOTIFY_NEEDNEWCABINET     = 0x00000012;	// file is encountered in the cabinet.
		public const uint SPFILENOTIFY_FILEEXTRACTED      = 0x00000013;	// The current file is continued in the next cabinet.
		public const uint NO_ERROR     = 0;

		/// <summary>
		/// The SetupIterateCabinet function iterates through all the files in a cabinet and sends a notification to a callback function for each file found.
		/// Platform SDK: Setup API
		/// </summary>
		[DllImport("SetupApi.dll", CharSet=CharSet.Auto)]
		public static extern bool SetupIterateCabinet(string cabinetFile, uint reserved, PSP_FILE_CALLBACK callBack, uint context);			

	}

	public class KernelApiWrapper
	{
		[DllImport("Kernel32.dll", CharSet=CharSet.Auto)]
		public static extern uint GetLastError();
	}

	public class DateTimeConvert
	{
		[DllImport("Kernel32.dll", CharSet=CharSet.Auto)]
		public static extern uint GetLastError();

		[DllImport("Kernel32.dll", CharSet=CharSet.Auto)]
		public static extern bool DosDateTimeToFileTime (ushort wFatDate, ushort wFatTime, FILETIME lpFileTime );

		[DllImport("Kernel32.dll", CharSet=CharSet.Auto)]
		public static extern bool FileTimeToLocalFileTime (FILETIME lpFileTime, FILETIME lpLocalFileTime );

		[DllImport("Kernel32.dll", CharSet=CharSet.Auto)]
		public static extern bool FileTimeToSystemTime (FILETIME lpFileTime, SYSTEMTIME lpSystemTime );

	}
	
	public class TFile 
	{
		public TFile(FILE_IN_CABINET_INFO fileInCabinetInfo)
		{
			this.Name = System.IO.Path.GetFileName(fileInCabinetInfo.NameInCabinet);
			this.Path = System.IO.Path.GetDirectoryName(fileInCabinetInfo.NameInCabinet);
			this.Size = fileInCabinetInfo.FileSize;

			this.Date = GetDateTime(fileInCabinetInfo.DosDate, fileInCabinetInfo.DosTime);
		}

		public TFile()
		{
			throw new NotSupportedException();
		}

		/// <summary>
		/// file name
		/// </summary>
		private string m_Name = "";
		public string Name
		{
			get { return m_Name;}
			set { m_Name = value;}
		}
		/// <summary>
		/// last modifed time
		/// </summary>
		private System.DateTime m_Date;      
		public System.DateTime Date
		{
			get { return m_Date;}
			set { m_Date = value;}
		}
      
		/// <summary>
		/// size of file
		/// </summary>
		private uint m_Size = 0;
		public uint Size
		{
			get { return m_Size;}
			set { m_Size = value;}
		}
        
		/// <summary>
		/// file path in cabinet
		/// </summary>
		private string m_Path = "";
		public string Path
		{
			get { return m_Path;}
			set { m_Path = value;}
		}

		/// <summary>
		/// full path of file in cabinet
		/// </summary>
		public string FullName
		{
			get { return this.Path + System.IO.Path.DirectorySeparatorChar.ToString() + this.Name;}
		}


		public override string ToString()
		{
			return FullName;
		}

		public override int GetHashCode()
		{
			return (this.Size > int.MaxValue ? int.MaxValue : (int)this.Size );
		}

		public override bool Equals(object obj)
		{
			if (obj==null) return false;
			if (this.GetType() != obj.GetType()) return false;

			TFile other = (TFile)obj;
			return ( string.Compare(this.Path, other.Path, true) == 0 && string.Compare(this.Name, other.Name, true)==0);
		}

		public static bool operator ==(TFile a, TFile b)
		{
			if ((object)a == null) return false;
			return a.Equals(b);
		}

		public static bool operator !=(TFile a, TFile b)
		{
			return !(a==b);
		}

		private DateTime GetDateTime(ushort date, ushort time)
		{
			FILETIME lpFileTime = new FILETIME();
			SYSTEMTIME  lpSystemTime = new SYSTEMTIME();
			DateTimeConvert.DosDateTimeToFileTime(date, time, lpFileTime);
			DateTimeConvert.FileTimeToSystemTime(lpFileTime, lpSystemTime);

			DateTime dateTime = new DateTime(lpSystemTime.wYear, lpSystemTime.wMonth, lpSystemTime.wDay,
				lpSystemTime.wHour, lpSystemTime.wMinute, lpSystemTime.wSecond, lpSystemTime.wMilliseconds);

			return dateTime;
		}

	}
}
