using System;
using System.Diagnostics;
using System.Globalization;
using System.Xml;
using System.IO;

namespace LMI
{
	public class Kernel
	{
		[STAThread]
		static void Main(string[] args)
		{
			Kernel myLMI = new Kernel();
			Console.WriteLine(myLMI.GetProcesses());
			while (true)
			{
				string query = Console.ReadLine();
				foreach(string s in myLMI.GetCollectionHw(query))
					Console.WriteLine(s);
			}
		} 
		
		private XmlDocument xmldoc;

		public Kernel()
		{
			xmldoc = new XmlDocument();
			Console.Write("Load XML: ");
			xmldoc.Load(Console.ReadLine());
		}
		#region PUBLIC
		public string[] GetCollectionHw(string query)
		{
			string[] toret = null;
			string temp = GetValueHw(query);
			
			if (temp.IndexOf("|") > 0)
				toret = temp.Substring(0, temp.Length-1).Split('|');
			else
			{
				toret = new string[1];
				toret[0] = "-";
			}
			return toret;
		}

		public string GetValueHw(string query)
		{
			string temp = string.Empty;

			switch (query)
			{
				case "Processor":
					foreach (XmlNode xnodem in xmldoc.ChildNodes[2].ChildNodes)
							if(xnodem.Name == "node")
								foreach (XmlNode xnode in xnodem.ChildNodes)
									if(xnode.Name == "node" && xnode.HasChildNodes && xnode.Attributes["class"].InnerText == "processor")
									{
										string name = "";
										string speed = "0";
										foreach (XmlNode xnode2 in xnode.ChildNodes)
										{
											if (xnode2.Name == "product")
												name = xnode2.InnerText;
											if (xnode2.Name == "size")
												speed = xnode2.InnerText;
										}
											
										temp += name+" "+ formatSpeed(Convert.ToInt64(speed)/1000000) +"|"; 
									}
					break;
				case "Video":
					foreach (XmlNode xnodem in xmldoc.ChildNodes[2].ChildNodes)
							if(xnodem.Name == "node")
								foreach (XmlNode xnode in xnodem.ChildNodes)
									if(xnode.Name == "node" && xnode.HasChildNodes && xnode.Attributes["class"].InnerText == "bridge")
										foreach (XmlNode xnode2 in xnode.ChildNodes)
											if (xnode2.Name == "node" && xnode2.Attributes["class"].InnerText == "display")
											{
												temp += xnode2.ChildNodes[2].InnerText+" "+xnode2.ChildNodes[1].InnerText+"|";
											} 
											else if (xnode2.Name == "node" && xnode2.Attributes["class"].InnerText == "bridge")
											{  
												foreach (XmlNode xnode3 in xnode2.ChildNodes)
													if (xnode3.Name == "node" && xnode3.Attributes["class"].InnerText == "display")
														temp += xnode3.ChildNodes[2].InnerText+" "+xnode3.ChildNodes[1].InnerText+"|";
											}
					break;
				case "NIC":
					foreach (XmlNode xnodem in xmldoc.ChildNodes[2].ChildNodes)
							if(xnodem.Name == "node")
								foreach (XmlNode xnode in xnodem.ChildNodes)
									if(xnode.Name == "node" && xnode.HasChildNodes && xnode.Attributes["class"].InnerText == "bridge")
										foreach (XmlNode xnode2 in xnode.ChildNodes)
											if (xnode2.Name == "node" && xnode2.Attributes["class"].InnerText == "network")
											{// Fix to add mac address
												temp += xnode2.ChildNodes[2].InnerText+" "+xnode2.ChildNodes[1].InnerText+" ("+ xnode2.ChildNodes[3].InnerText +")|";
											} 
											else if (xnode2.Name == "node" && xnode2.Attributes["class"].InnerText == "bridge")
											{  
												foreach (XmlNode xnode3 in xnode2.ChildNodes)
													if (xnode3.Name == "node" && xnode3.Attributes["class"].InnerText == "network")
														temp += xnode3.ChildNodes[2].InnerText+" "+xnode3.ChildNodes[1].InnerText+" ("+ xnode3.ChildNodes[3].InnerText +")|";
											}
					break;
				case "CDROMDrive":
					foreach (XmlNode xnodem in xmldoc.ChildNodes[2].ChildNodes)
						if(xnodem.Name == "node")
							foreach (XmlNode xnode in xnodem.ChildNodes)
								if(xnode.Name == "node" && xnode.HasChildNodes && xnode.Attributes["class"].InnerText == "bridge")
									foreach (XmlNode xnode2 in xnode.ChildNodes)
										if (xnode2.Name == "node" && xnode2.Attributes["class"].InnerText == "storage")
											foreach (XmlNode xnode3 in xnode2.ChildNodes)
												if (xnode3.Name == "node" && xnode3.Attributes["class"].InnerText == "bus")
													foreach (XmlNode xnode4 in xnode3.ChildNodes)
														if (xnode4.Name == "node" && xnode4.Attributes["class"].InnerText == "disk" && xnode4.Attributes["id"].InnerText.Substring(0, 1) == "c")
															temp += xnode4.ChildNodes[1].InnerText+"|";
					break;
				case "HardDrive":
					foreach (XmlNode xnodem in xmldoc.ChildNodes[2].ChildNodes)
						if(xnodem.Name == "node")
							foreach (XmlNode xnode in xnodem.ChildNodes)
								if(xnode.Name == "node" && xnode.HasChildNodes && xnode.Attributes["class"].InnerText == "bridge")
									foreach (XmlNode xnode2 in xnode.ChildNodes)
										if (xnode2.Name == "node" && xnode2.Attributes["class"].InnerText == "storage")
											foreach (XmlNode xnode3 in xnode2.ChildNodes)
												if (xnode3.Name == "node" && xnode3.Attributes["class"].InnerText == "bus")
													foreach (XmlNode xnode4 in xnode3.ChildNodes)
														if (xnode4.Name == "node" && xnode4.Attributes["class"].InnerText == "disk" && xnode4.Attributes["id"].InnerText.Substring(0, 1) == "d")
															temp += xnode4.ChildNodes[1].InnerText+"|";
					break;
				case "System.Model":
					foreach (XmlNode xnode in xmldoc.ChildNodes[2].ChildNodes)
						if(xnode.Name == "product")
							temp = xnode.InnerText+"|";
					break;
				case "System.Manufacturer":
					foreach (XmlNode xnode in xmldoc.ChildNodes[2].ChildNodes)
						if(xnode.Name == "vendor")
							temp = xnode.InnerText+"|";
					break;
				case "System.SerialNumber":
					foreach (XmlNode xnode in xmldoc.ChildNodes[2].ChildNodes)
						if(xnode.Name == "serial")
							temp = xnode.InnerText+"|";
					break;
			}
			return temp;
		}
		public string GetProcesses()
		{
			// ProcessStartInfo psi = new ProcessStartInfo("c:\\do.bat"); // FOR WINDOWS
			// psi.WindowStyle = ProcessWindowStyle.Hidden; // FOR WINDOWS =S
			// ProcessStartInfo psi = new ProcessStartInfo("sh", "/usr/bin/CWD/pss.sh"); // FOR LINUX
			// psi.UseShellExecute = false; // FOR MONO =S
			// Process.Start(psi);
			FileStream fs = new FileStream("c:\\temp.lst",FileMode.Open); // FOR WINDOWS
			// FileStream fs = new FileStream("/tmp/temp.lst",FileMode.Open); // FOR LINUX
			byte[] buf = new byte[fs.Length];
			fs.Read(buf,0,buf.Length);
			string[] prs = System.Text.ASCIIEncoding.ASCII.GetString(buf).Split('\n');
			string toret = string.Empty;
			foreach (string tprs in prs)
			{
				string tp = tprs;
				tp = tp.TrimEnd(' ');
				if(tp.Length > 50)
				{
					//XML output
					toret += "<user>" + tp.Substring(0, 10).Trim() + "</user><pid>" + tp.Substring(11,4).Trim() + "</pid><name>" + tp.Substring(48, tp.Length-51).Trim() + "</name>\n";
					//toret += tp.Substring(0, 10).Trim() + "|" + tp.Substring(11,4).Trim() + "|" + tp.Substring(48, tp.Length-51).Trim() + "&";
				}
			}
			return toret;
		}

	/*	public string[] GetCollectionPr()
		{
			string[] stmp;
			string[] toret = null;
			string temp = GetProcesses();
			
			if (temp.IndexOf("&") > 0)
				stmp = temp.Substring(0, temp.Length-1).Split('|');
			//	toret = 
			else
			{
				toret[0] = "-";
			}
			return toret;
		}*/

		#endregion

		#region PRIVATE
		private string formatSize(Int64 lSize, bool booleanFormatOnly)
		{
			string stringSize = "";
			NumberFormatInfo myNfi = new NumberFormatInfo();
			Int64 lKBSize = 0;

			if (lSize < 1024 ) 
			{
				if (lSize == 0) 
					stringSize = "0";
				else
					stringSize = "1";
			}
			else 
			{
				if (booleanFormatOnly == false)
					lKBSize = lSize / 1024;
				else 
					lKBSize = lSize;

				stringSize = lKBSize.ToString("n",myNfi);
				stringSize = stringSize.Replace(".00", "");
			}

			return stringSize + " KB";
		}
		private string formatSpeed(Int64 lSpeed)
		{
			float floatSpeed = 0;
			string stringSpeed = "";
			NumberFormatInfo myNfi = new NumberFormatInfo();

			if (lSpeed < 1000 ) 
			{
				stringSpeed = lSpeed.ToString() + "MHz";
			}
			else 
			{
				floatSpeed = (float) lSpeed / 1000;
				stringSpeed = floatSpeed.ToString() + "GHz";
			}

			return stringSpeed;

		}
		#endregion
	}
}
