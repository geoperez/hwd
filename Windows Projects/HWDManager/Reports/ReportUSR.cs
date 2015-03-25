using System;
using System.Data;
using System.Drawing;
using ReportPrinting;

namespace HWD
{
	public class ReportUSR : IReportMaker
	{
		public System.Data.DataView dv;

		public System.Data.DataView dataview
		{
			set 
			{
				this.dv = value;
			}

			get
			{
				return this.dv;
			}
		}

		public void MakeDocument(ReportDocument reportDocument)
		{
			TextStyle.ResetStyles();

			TextStyle.Heading1.Bold = true;
			TextStyle.TableHeader.BackgroundBrush = Brushes.Silver;
			TextStyle.TableHeader.Brush = Brushes.Black;
			TextStyle.TableHeader.MarginNear = 0.1f;
			TextStyle.TableHeader.MarginFar = 0.1f;
			TextStyle.TableRow.MarginNear = 0.1f;
			TextStyle.TableRow.MarginFar = 0.1f;

			ReportBuilder builder = new ReportBuilder(reportDocument);
			builder.StartLinearLayout(Direction.Vertical);
			
			builder.AddPageHeader ("Hardware Report", HorizontalAlignment.Right);
			builder.AddPageFooter ("Page %p", String.Empty, DateTime.Now.ToShortDateString());
			builder.AddPageHeaderLine ();
			builder.AddPageFooterLine ();
			builder.DefaultTablePen = reportDocument.ThinPen;

			builder.AddTextSection("User System - " + this.dv[0]["Username"].ToString(), TextStyle.Heading1);
			builder.AddTextSection("\n");
			builder.AddHorizontalLine();
			builder.AddTextSection("Computer Name:" + this.dv[0]["ComputerName"].ToString());
			builder.AddTextSection("Model: " + this.dv[0]["Manufacturer"].ToString() + " " + this.dv[0]["Model"].ToString());
			builder.AddTextSection("Serial Number: " + this.dv[0]["SerialNumber"].ToString());
			builder.AddTextSection("OS:\t\t" + this.dv[0]["OS"].ToString());
			builder.AddTextSection("\n");
			builder.AddHorizontalLine();
			builder.AddTextSection("Processor(s):\n\t\t" + this.dv[0]["Processors"].ToString());
			builder.AddTextSection("Hard Disk(s):\n\t\t" + this.dv[0]["HDs"].ToString());
			builder.AddTextSection("NIC(s):\n\t\t" + this.dv[0]["NICs"].ToString());
			builder.AddTextSection("CD-ROM(s):\n\t\t" + this.dv[0]["CDs"].ToString());
			builder.AddTextSection("Printer(s):\n\t\t" + this.dv[0]["Printers"].ToString());
			builder.AddHorizontalLine();
			builder.FinishLinearLayout();
		}



	}
}
