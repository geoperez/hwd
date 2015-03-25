using System;
using System.IO;
using System.Data;
using System.Xml;
using System.Net;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CabinetFile;
using System.Resources;

namespace HWD
{
	public delegate void AvanceDownload(long receivedBytes, long totalBytes);

	public enum WindowsVersions
	{
		Windows2000AdvancedServer   = 143,
		Windows2000DatacenterServer= 144,	
		Windows2000Professional=145,
		Windows2000Server=146,
		//		Windows95=147,
		//		Windows98=148,
		//		Windows98SE=151,
		//		WindowsMe=152,
		//		WindowsNTServer40=170,
		//		WindowsNTServer40EnterpriseEdition=171,
		//		WindowsNTServer40TerminalServerEdition=172,
		//		WindowsNTWorkstation40=173,
		WindowsServer2003forSmallBusinessServer=176,
		WindowsServer2003DatacenterEdition=177,
		WindowsServer2003EnterpriseEdition=178,
		WindowsServer2003StandardEdition=179,
		WindowsServer2003WebEdition=180,
		WindowsXPHomeEdition=181,
		WindowsXPProfessional=183
	}
	public class HotFixUpdaterForm : System.Windows.Forms.Form
	{
		private CabinetFile.TCabinetFile m_CabinetFile = new TCabinetFile();
		private Crownwood.DotNetMagic.Controls.TitleBar titleBar1;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button2;
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button1;
		
		private System.Windows.Forms.ProgressBar progressBar1;

		public HotFixUpdaterForm()
		{
			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(HotFixUpdaterForm));
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.titleBar1 = new Crownwood.DotNetMagic.Controls.TitleBar();
			this.button2 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.button1 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.SuspendLayout();
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(8, 48);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(352, 32);
			this.progressBar1.Step = 1;
			this.progressBar1.TabIndex = 0;
			// 
			// titleBar1
			// 
			this.titleBar1.Dock = System.Windows.Forms.DockStyle.Top;
			this.titleBar1.GradientActiveColor = System.Drawing.Color.FromArgb(((System.Byte)(136)), ((System.Byte)(144)), ((System.Byte)(156)));
			this.titleBar1.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
			this.titleBar1.GradientDirection = Crownwood.DotNetMagic.Controls.GradientDirection.TopToBottom;
			this.titleBar1.GradientInactiveColor = System.Drawing.Color.FromArgb(((System.Byte)(230)), ((System.Byte)(231)), ((System.Byte)(228)));
			this.titleBar1.Location = new System.Drawing.Point(0, 0);
			this.titleBar1.MouseOverColor = System.Drawing.Color.Empty;
			this.titleBar1.Name = "titleBar1";
			this.titleBar1.PostText = "Click Download to Begin";
			this.titleBar1.Size = new System.Drawing.Size(368, 40);
			this.titleBar1.TabIndex = 21;
			this.titleBar1.Text = "HotFix Updater";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(264, 88);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(96, 36);
			this.button2.TabIndex = 22;
			this.button2.Text = "Cancel";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(160, 88);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 36);
			this.button1.TabIndex = 23;
			this.button1.Text = "Download";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// HotFixUpdaterForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(368, 135);
			this.ControlBox = false;
			this.Controls.Add(this.button1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.titleBar1);
			this.Controls.Add(this.progressBar1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximumSize = new System.Drawing.Size(374, 160);
			this.MinimumSize = new System.Drawing.Size(374, 160);
			this.Name = "HotFixUpdaterForm";
			this.Text = "Downloading Definition File";
			this.ResumeLayout(false);

		}

		private void CabinetFile_FileExtractBefore(object sender, System.EventArgs e)
		{
			TFile file = (TFile)sender;

			System.ComponentModel.CancelEventArgs cancel = (System.ComponentModel.CancelEventArgs)e;
		}

		private void UpdateProgress(long receivedBytes, long totalBytes)
		{
			this.progressBar1.Value = Convert.ToInt32(Math.Floor((receivedBytes * 100) / totalBytes));
		}

		private void Clean()
		{
			if(File.Exists("mssecure.cab"))
			{
				File.Delete("mssecure.cab");
			}
			if(File.Exists("mssecure.xml"))
			{
				File.Delete("mssecure.xml");
			}
			if(File.Exists("hwdhf.xml"))
			{
				File.Delete("hwdhf.xml");
			}
		}
		private void DownloadFile(string remoteFilename, string localFilename)
		{
			int bytesProcessed = 0;

			Stream remoteStream  = null;
			Stream localStream   = null;
			WebResponse response = null;

			try
			{
				WebRequest request = WebRequest.Create(remoteFilename);
				if (request != null)
				{
					response = request.GetResponse();
					if (response != null)
					{

						remoteStream = response.GetResponseStream();


						localStream = File.Create(localFilename);

						byte[] buffer = new byte[4096];
						int bytesRead;
						do
						{
							bytesRead = remoteStream.Read (buffer, 0, buffer.Length);
							localStream.Write (buffer, 0, bytesRead);
							bytesProcessed += bytesRead;
							this.Invoke(new AvanceDownload(UpdateProgress), new object[] {bytesProcessed,response.ContentLength});
						} while (bytesRead > 0);
					}
				}
			}
			catch(Exception e)
			{
				MessageBox.Show(e.ToString());
			}
			finally
			{
				if (response     != null) response.Close();
				if (remoteStream != null) remoteStream.Close();
				if (localStream  != null) localStream.Close();
			}
			return;
		}

		private void UpdateDef()
		{
			DownloadFile("http://go.microsoft.com/fwlink/?LinkId=18922", "mssecure.cab");
			if (File.Exists("mssecure.cab"))
			{
				this.m_CabinetFile.IgnoreInsidePath = true;
				this.m_CabinetFile.Name = "mssecure.cab";
				this.m_CabinetFile.ExtractAll();
				XmlDocument doc = new XmlDocument();
				doc.Load("mssecure.xml");
				XmlNode nodeList = doc.ChildNodes[1];
				nodeList.RemoveChild(nodeList.ChildNodes[3]);
				doc.Save("mssecure.xml"); 		
			
				
				XmlTextWriter writer = new XmlTextWriter("hwdhf.xml",null);
				writer.Formatting = Formatting.Indented;
				writer.Indentation = 3;				
				DataSet ds = new DataSet("BulletinDatastore");
				ds.ReadXml("mssecure.xml");

				writer.WriteStartDocument(true);
				DataColumn [] x = new DataColumn[1];
				x[0] =ds.Tables["Location"].Columns["LocationID"];
				ds.Tables["Location"].PrimaryKey = x;
				DataRow t2;
				writer.WriteStartElement("HotFixes");
				for(int i=0;i<ds.Tables["Bulletin"].Rows.Count-1;i++)
				{
				{
					DataRow [] dr,dr2;
					dr = ds.Tables["Bulletin"].Rows[i].GetChildRows("Bulletin_Patches");
					dr2 = dr[0].GetChildRows("Patches_Patch");
					
					foreach(DataRow dr4 in dr2)
					{
						DataRow [] dr5 = dr4.GetChildRows("Patch_AffectedProduct");
						foreach(DataRow dr6 in dr5)
						{
							Int32 productId = Convert.ToInt32(dr6["ProductID"].ToString());
							DataRow t = ds.Tables["Product"].Rows.Find(productId-1);							
							
							t2 = ds.Tables["Location"].Rows.Find(dr4["PatchLocationID"]);
						
							try
							{
								
								if (Enum.IsDefined(typeof(WindowsVersions), productId))
								{

									writer.WriteStartElement("HotFix");
									writer.WriteStartElement("BulletinID");
									writer.WriteString(ds.Tables["Bulletin"].Rows[i]["BulletinID"].ToString());
									writer.WriteEndElement();
										
									writer.WriteStartElement("Summary");			
									writer.WriteString(ds.Tables["Bulletin"].Rows[i]["Summary"].ToString());
									writer.WriteEndElement();

									DataRow [] QNumbers = ds.Tables["Bulletin"].Rows[i].GetChildRows("Bulletin_QNumbers");
									DataRow [] QNumber = QNumbers[0].GetChildRows("QNumbers_QNumber");
									writer.WriteStartElement("ID");			
									writer.WriteString(QNumber[0]["QNumber"].ToString());
									writer.WriteEndElement();

									writer.WriteStartElement("Product");
									writer.WriteString(t["Name"].ToString());
									writer.WriteEndElement();
									
									writer.WriteStartElement("ProductID");
									writer.WriteString(productId.ToString());
									writer.WriteEndElement();
										
									writer.WriteStartElement("UrlPatch");
									writer.WriteString(t2["Path"].ToString().Replace("&", "&amp;"));
									writer.WriteEndElement();
									
									
									writer.WriteEndElement();
								}
							}
							catch
							{
								MessageBox.Show("Can't create definition file");
							}
						}
					}
				}
				}
				
				writer.WriteEndElement();

				writer.Close();
				this.DialogResult = DialogResult.OK;
				this.Close();
			} 
			else 
			{
				MessageBox.Show("Error downloading file");
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.button1.Enabled = false;
			this.Clean();
			this.UpdateDef();
		}
	}
}