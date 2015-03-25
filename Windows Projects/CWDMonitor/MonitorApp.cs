using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;

namespace CWDMonitor
{
	public class Monitor : System.ServiceProcess.ServiceBase
	{
		private System.ComponentModel.Container components = null;
		static bool status = false;
		static ArrayList bads = null;
		static ArrayList gods = new ArrayList();

		public Monitor()
		{
			InitializeComponent();
		}

		static void Main()
		{
			System.ServiceProcess.ServiceBase[] ServicesToRun;
			ServicesToRun = new System.ServiceProcess.ServiceBase[] { new Monitor() };

			System.ServiceProcess.ServiceBase.Run(ServicesToRun);
		}

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.ServiceName = "CWDMonitor";
			this.CanStop = true;
			this.CanPauseAndContinue = false;
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		protected override void OnStart(string[] args)
		{
			status = true;
			ParseItems();
			TimerWMI mytimer = new TimerWMI();
			System.Threading.TimerCallback timerDelegate = new System.Threading.TimerCallback(CheckStatus);
			System.Threading.Timer timer = new System.Threading.Timer(timerDelegate, mytimer, 400, 500);
			mytimer.tmr = timer;
			System.Diagnostics.EventLog.WriteEntry("CWDMonitor","CWDMonitor Loaded");
		}
 
		protected override void OnStop()
		{
			status = false;
		}

		private void ParseItems()
		{
			System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
			xmldoc.Load(System.Environment.GetFolderPath(System.Environment.SpecialFolder.System) + "\\CWD\\bads.xml");
			bads = new ArrayList();
			for(int i = 0; i < xmldoc.FirstChild.ChildNodes.Count; i++)
			{
				bads.Add(xmldoc.FirstChild.ChildNodes[i].InnerText);
			}
			bads.TrimToSize();
			xmldoc = null;
			GC.Collect();
		}

		static void CheckStatus(Object state)
		{
			if (status)
			{
				try 
				{
					foreach (System.Management.ManagementObject mo in Consulta("SELECT ProcessId, ExecutablePath FROM Win32_Process"))
					{
						if (!gods.Contains(mo["ProcessId"].ToString()))
						{
							if (mo["ExecutablePath"] != null) 
							{
								if (bads.Contains(GetInternalName(mo["ExecutablePath"].ToString().Replace(@"\",@"\\"))))
									KillProcess(Convert.ToInt32(mo["ProcessId"].ToString()));
								else
									gods.Add(mo["ProcessId"].ToString());
							}
						}
					}
					gods.TrimToSize();
				} 
				catch (Exception e) 
				{
					System.Diagnostics.EventLog.WriteEntry("CWDMonitor",e.ToString());
				}
			} 
			else 
			{
				TimerWMI tw =(TimerWMI)state;
				tw.tmr.Dispose();
				tw.tmr = null;
			}
			GC.Collect();
		}

		static System.Management.ManagementObjectCollection Consulta(string strQuery)
		{
			System.Management.ManagementScope ms = new System.Management.ManagementScope("\\\\" + Environment.MachineName + "\\root\\cimv2", new System.Management.ConnectionOptions());
			System.Management.ManagementObjectCollection queryCollection = new System.Management.ManagementObjectSearcher(ms, new System.Management.ObjectQuery(strQuery)).Get();
			return queryCollection;
		}

		static void KillProcess(int ID)
		{
			foreach (System.Management.ManagementObject mo in Consulta("Select * from Win32_Process Where ProcessID = '" + ID + "'"))
				mo.InvokeMethod("Terminate", null);
		}

		static string GetInternalName(string file)
		{
			return FileVersionInfo.GetVersionInfo(file).InternalName;
		}
	}

	public class TimerWMI 
	{
		public System.Threading.Timer tmr;
	}
}
