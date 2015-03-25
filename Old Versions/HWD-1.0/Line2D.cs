using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Collections;

namespace LineChart
{
	/// <summary>
	/// Summary description for Line2D.
	/// </summary>
	public class Line2D
	{
		private int m_Width;							//Width of the rectangle container for graph.
		private int m_Height;							//Height of the rectangle container for graph.
		private ArrayList m_XAxis;						//X-axis for the graph.
		private ArrayList m_YAxis;						//Y-Axis for the graph.
		private Color m_graphColor = Color.Red;			//Color of the line graph.
		private float m_XSlice = 1;						//Slice for X Axis.
		private float m_YSlice = 1;						//Slice for Y Axis.
		private Graphics objGraphics;
		private Bitmap objBitmap;
		private string m_XAxisText = "X";
		private string m_YAxisText = "Y";
		private string m_Title;
		private Color m_TitleBackColor = Color.Cyan;
		private Color m_TitleForeColor = Color.Green;
		


		//Sets or Gets the Width for the rectangle container of graph.
		public int Width
		{
			get { return m_Width;}
			set { m_Width = value; }
		}

		//Sets or Gets the Height for the rectangle container of graph.
		public int Height
		{
			get { return m_Height;}
			set { m_Height = value;	}
		}

		//Sets or Gets the X-Axis pixels for the graph.
		public ArrayList XAxis
		{
			set 
			{ 
				m_XAxis = value;
			}
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

		//Sets or Gets the X-Axis Test.
		public string XAxisText
		{
			get { return m_XAxisText;}
			set { m_XAxisText = value;}
		}

		//Sets or Gets the Y-Axis Test.
		public string YAxisText
		{
			get { return m_YAxisText;}
			set { m_YAxisText = value;}
		}

		//Sets or Gets the title for the Graph.
		public string Title
		{
			get { return m_Title;}
			set { m_Title = value;}
		}

		//Sets or Gets the title Backcolor.
		public Color TitleBackColor
		{
			get { return m_TitleBackColor;}
			set { m_TitleBackColor = value;}
		}

		//Sets or Gets the Title ForeColor.
		public Color TitleForeColor
		{
			get { return m_TitleForeColor;}
			set { m_TitleForeColor = value;}
		}

		//Default constructor.
		public Line2D()
		{
			
		}


		/******************************************************************************************
		 * Method	:	Public InitializeGraph
		 * Purpose	:	Initialises the Graph.Draws rectangle region and fills the region.
		 *				Draws X-Axis line and Y-Axis line.
		 *				Draws Origin (0,0) point.Sets Axis Text and creates Title.
		 * *****************************************************************************************/
		public void InitializeGraph()
		{
			
			//Creating a bitmap image with given height and width.
			objBitmap = new Bitmap(Width,Height);

			//Getting the bitmap image into the graphics portion of the screen.
			objGraphics = Graphics.FromImage(objBitmap);

			//Filling the rectangle portion of the graphics with custom color.
			objGraphics.FillRectangle(new SolidBrush(Color.Black),0,0,Width,Height);
			
			//Drawing X-Axis line.
			//objGraphics.DrawLine(new Pen(new SolidBrush(Color.YellowGreen),2),0,Height - 10,Width - 10,Height - 100);

			//Drawing Y-Axis line.
			//objGraphics.DrawLine(new Pen(new SolidBrush(Color.YellowGreen),2),100,Height - 100,100,10);

			//Plotting Origin(0,0).
			//objGraphics.DrawString("0",new Font("Arial",8),new SolidBrush(Color.Black),100,Height - 90);

			//Sets Axis text.
			//SetAxisText(ref objGraphics);

			//Sets the title for the Graph.
			//CreateTitle(ref objGraphics);
		}

		
		/******************************************************************************************
		 * Method	:	Public CreateGraph
		 * Purpose	:	Calls SetPixel function to draw line in the rectangle region.	
		 * Input	:	Color of the line Graph.
		 * *****************************************************************************************/
		public void CreateGraph(Color _GraphColor)
		{
			GraphColor = _GraphColor;
			//Plotting the pixels.
			SetPixels(ref objGraphics);
		}

		/******************************************************************************************
		 * Method	:	Public Draw2D.
		 * Purpose	:	Creates 2D graph for the given X and Y Axis.
		 * Returns	:	(Bitmap) reference of the graphics portions.
		 * *****************************************************************************************/
		public Bitmap GetGraph()
		{
							
			//Creating X-Axis slices.
			SetXAxis(ref objGraphics,XSlice);
			
			//Creating Y-Axis slices.
			SetYAxis(ref objGraphics,YSlice);
			
			return objBitmap;
		}

		/******************************************************************************************
		 * Method	:	Public PlotGraph.
		 * Purpose	:	Draws Axis Line.
		 * Input	:	Graphics object,X Axis, Y Axis for both points.
		 ******************************************************************************************/
		private void PlotGraph(ref Graphics objGraphics,float x1,float y1,float x2,float y2)
		{
			objGraphics.DrawLine(new Pen(new SolidBrush(Color.Lime),1),x1, y1 ,x2,y2);
		}


		/******************************************************************************************
		 * Method	:	Public SetXAxis.
		 * Purpose	:	Draws X-Axis Slices.
		 * Input	:	Graphics object, Slices for the XAxis.
		 ******************************************************************************************/
		private  void SetXAxis(ref Graphics objGraphics,float iSlices)
		{
			float x1 = 0,y1 = Height - 110,x2 = 0,y2 = Height - 90;

			for(int iIndex = 0;iIndex<Height - 200;iIndex+=10)
			{
				objGraphics.DrawLine(new Pen(new SolidBrush(Color.YellowGreen)),x1+iIndex,y1+5,x2+iIndex,y2-5);
			}

		}


		/******************************************************************************************
		 * Method	:	Public SetYAxis.
		 * Purpose	:	Draws Y-Axis Slices.
		 * Input	:	Graphics object, Slices for the axis.
		 ******************************************************************************************/
		private void SetYAxis(ref Graphics objGraphics,float iSlices)
		{
			int x1 = 95; 
			int y1 = Height - 110;
			int x2 = 105;
			int y2 = Height - 110;

			for(int iIndex = 0;iIndex<Height - 200;iIndex+=10)
			{
				objGraphics.DrawLine(new Pen(new SolidBrush(Color.YellowGreen)), x1, (y1 - iIndex),x2,(y2 - iIndex));
			}

		}



		/******************************************************************************************
		 * Method	:	Public SetPixels.
		 * Purpose	:	Plots pixels.
		 * Input	:	Graphics object.
		 ******************************************************************************************/
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
//				objGraphics.DrawRectangle(new Pen(Color.Black), 0, 108, Width, 20);
//				objGraphics.DrawString(Y1.ToString()+"%", new Font("Courier New", 10), new SolidBrush(Color.GreenYellow), 10, 108);
			}
			else
			{
				//X and Y axis length should be same.
			}
		}


		/******************************************************************************************
		 * Method	:	Private SetAxisText.
		 * Purpose	:	Sets the Axis text.
		 * Input	:	Graphics object.
		 ******************************************************************************************/
		private void SetAxisText(ref Graphics objGraphics)
		{
			objGraphics.DrawString(XAxisText,new Font("Arial",9),new SolidBrush(Color.SaddleBrown),
				Width / 2 - 50,Height - 50);

			int X = 30;
			int Y = (Height / 2 ) - 50;
			for(int iIndex = 0;iIndex < YAxisText.Length;iIndex++)
			{
				objGraphics.DrawString(YAxisText[iIndex].ToString(),new Font("Arial",9),new SolidBrush(Color.SaddleBrown),
					X,Y);
				Y += 10;
			}

		}


		/******************************************************************************************
		 * Method	:	Public CreateTitle.
		 * Purpose	:	Creates title for the graph.
		 * Input	:	Graphics object.
		 ******************************************************************************************/
		private void CreateTitle(ref Graphics objGraphics)
		{
			objGraphics.FillRectangle(new SolidBrush(Color.Green),Height - 100,20,Height - 200,20);
			Rectangle rect = new Rectangle(Height - 100,20,Height - 200,20);
			objGraphics.DrawString(Title,new Font("Verdana",10),new SolidBrush(TitleForeColor),rect);
			
		}

		
	}
}
