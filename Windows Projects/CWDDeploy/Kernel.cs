using System;
using System.IO;
using System.Management;

namespace CWDDeploy
{
	class Kernel
	{
		private string UNC;
		private string pathcwd;

		public Kernel(string system)
		{
			string[] arr = null;

			foreach (System.Management.ManagementObject mo in Consulta("SELECT * FROM Win32_OperatingSystem", system))
			{
				arr = mo["SystemDirectory"].ToString().Split('\\');
			}

			this.UNC = "\\\\" + system + "\\" + arr[0].Substring(0,1) + "$\\" + arr[1] + "\\" + arr[2];
			this.pathcwd = arr[0] + "\\" + arr[1] + "\\" + arr[2] + "\\temp.bat"; 
			Console.WriteLine("OPENING {0}", this.UNC);
			File.Copy("temp.bat", this.UNC + "\\temp.bat", true);
			Console.WriteLine("COPY READY!");
			this.Correr(this.pathcwd, system);
		}

		[STAThread]
		static void Main(string[] args)
		{
			Kernel kn = new Kernel(args[0]);
			Console.ReadLine();
		}

		private System.Management.ManagementObjectCollection Consulta(string strQuery, string strSystem)
		{
			ManagementObjectCollection queryCollection;
			try
			{
				System.Management.ManagementScope ms = new System.Management.ManagementScope("\\\\" + strSystem + "\\root\\cimv2", new ConnectionOptions());
				queryCollection = new ManagementObjectSearcher(ms, new System.Management.ObjectQuery(strQuery)).Get();
			}
			catch
			{
				queryCollection=null;
			}
			return queryCollection;
		}

		private void Correr(string path, string system)
		{
			try 
			{
				System.Management.ConnectionOptions co = new ConnectionOptions();
				ManagementScope ms = new ManagementScope("\\\\" + system + "\\root\\cimv2", co);
				ms.Connect();
				ManagementClass mc  = new ManagementClass("Win32_Process");
				mc.Scope = ms;
				System.Management.ManagementBaseObject parameters;
				parameters=mc.GetMethodParameters("Create");
				ManagementClass mc2 = new ManagementClass("Win32_ProcessStartup");
				mc2.Scope = ms;
				parameters["CommandLine"] = path;
				parameters["ProcessStartupInformation"]=mc2;
				mc.InvokeMethod("Create",parameters,null);
				Console.WriteLine("PROCESS LAUNCHED!");
			}
			catch 
			{
				Console.WriteLine("ERROR PROCESS");
			}
		}
	}
}
