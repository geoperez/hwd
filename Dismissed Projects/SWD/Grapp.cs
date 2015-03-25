using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Collections;

namespace SWD
{
	public class Grapp
	{																		
		private Graphics objGraphics;
		private Bitmap objBitmap;

		public Grapp()
		{
			
		}

		public void InitializeGraph(int width, int height)
		{
			objBitmap = new Bitmap(width, height);
			objGraphics = Graphics.FromImage(objBitmap);
			objGraphics.FillRectangle(new SolidBrush(Color.White),0,0,width, height);
		}


		private void GraphPoint(float x1,float y1, string ip)
		{
			objGraphics.DrawString(".", new Font("Arial", 8), new SolidBrush(Color.Black), x1-2, y1-2);
			objGraphics.DrawString(ip, new Font("Arial", 6), new SolidBrush(Color.Black), x1, y1);
		}

		public Bitmap GetGraph(string ipaddr)
		{	
			this.GraphPoint(20, 20, ipaddr);
			return objBitmap;
		}
	}
}
