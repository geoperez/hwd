using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Collections;

namespace HWD.Graph
{
	public class Line2D
	{
		private int m_Width;
		private int m_Height;						
		private ArrayList m_XAxis;						
		private ArrayList m_YAxis;					
		private Color m_graphColor = Color.Red;		
		private float m_XSlice = 1;						
		private float m_YSlice = 1;						
		private Graphics objGraphics;
		private Bitmap objBitmap;
		
		public int Width
		{
			get { return m_Width;}
			set { m_Width = value; }
		}

		public int Height
		{
			get { return m_Height; }
			set { m_Height = value;	}
		}

		//Sets or Gets the X-Axis pixels for the graph.
		public ArrayList XAxis
		{
			set	{ m_XAxis = value; }
			get { return m_XAxis;}
		}

		//Sets or Gets the Y-Axis pixels for the graph.
		public ArrayList YAxis
		{
			set { m_YAxis = value;}
			get { return m_YAxis;}
		}

		//Sets or Gets the Color of the line Graph.
		public Color GraphColor
		{
			set { m_graphColor = value;}
			get { return m_graphColor;}
		}


		//Sets or Gets the X Axis Slice.
		public float XSlice
		{
			set { m_XSlice = value;}
			get { return m_XSlice;}
		}

		//Sets or Gets the Y Axis Slice.
		public float YSlice
		{
			set { m_YSlice = value;}
			get { return m_YSlice;}
		}

		//Default constructor.
		public Line2D()
		{
			
		}

		public void InitializeGraph()
		{
			
			//Creating a bitmap image with given height and width.
			objBitmap = new Bitmap(Width,Height);

			//Getting the bitmap image into the graphics portion of the screen.
			objGraphics = Graphics.FromImage(objBitmap);

			//Filling the rectangle portion of the graphics with custom color.
			objGraphics.FillRectangle(new SolidBrush(Color.Black),0,0,Width,Height);
		}

		public void CreateGraph()
		{
			SetXAxis(ref objGraphics);
			SetPixels(ref objGraphics);
		}

		public Bitmap GetGraph()
		{			
			return objBitmap;
		}

		private void PlotGraph(ref Graphics objGraphics,float x1,float y1,float x2,float y2)
		{
			objGraphics.DrawLine(new Pen(new SolidBrush(Color.Lime),1),x1, y1 ,x2,y2);
		}

		private  void SetXAxis(ref Graphics objGraphics)
		{
			int k = this.Height / 10;
			for(int i = 0; i < 10; i++)
			{
				objGraphics.DrawLine(new Pen(new SolidBrush(Color.Silver)), 0 , i*k, this.Width, i*k);
			}

		}

		private void SetPixels(ref Graphics objGraphics)
		{
			float X1 = float.Parse(XAxis[0].ToString());
			float Y1 = float.Parse(YAxis[0].ToString());

			if(XAxis.Count == YAxis.Count)
			{
		
				for(int iXaxis = 0,iYaxis =0;(iXaxis < XAxis.Count - 1 && iYaxis < YAxis.Count - 1);iXaxis++,iYaxis++)
				{
					PlotGraph(ref objGraphics,X1,Y1,float.Parse(XAxis[iXaxis + 1].ToString()),float.Parse(YAxis[iYaxis + 1].ToString()));
					X1 = float.Parse(XAxis[iXaxis + 1].ToString());
					Y1 = float.Parse(YAxis[iYaxis + 1].ToString());
				}
			}
			else
			{
				//X and Y axis length should be same.
			}
		}
		
	}
}
