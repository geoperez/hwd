using System;
using System.Data;
using System.Drawing;
using ReportPrinting;

namespace HWD
{
	public class ReportMWD : IReportMaker
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
			TextStyle.Normal.Size = 9f;
			TextStyle.TableRow.Size = 9f;

			ReportBuilder builder = new ReportBuilder(reportDocument);
			builder.StartContainer(new LinearSections());
			
			builder.AddPageHeader ("Hardware Report", HorizontalAlignment.Right);
			builder.AddPageFooter ("Page %p", String.Empty, DateTime.Now.ToShortDateString());
			builder.AddPageHeaderLine ();
			builder.AddPageFooterLine ();
			builder.DefaultTablePen = reportDocument.ThinPen;

			this.dv.Sort = "UserName";
			ReportSectionData data;
			data = builder.AddDataSection (this.dv, true);
			builder.CurrentSection.HorizontalAlignment = HorizontalAlignment.Center;
			builder.CurrentSection.UseFullWidth = true;
			builder.AddColumn("ComputerName", "Computer Name", 1.8f, false, true);
			builder.AddColumn("UserName", "Username", 2f, false, true);
			builder.AddColumn("ItemCaption", "Caption", 4f, false, true);
			data.InnerPenHeaderBottom = null;
			data.OuterPens = reportDocument.NormalPen;
		}



	}
}
