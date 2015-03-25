using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Crownwood.DotNetMagic;

namespace HWD.DetailsControls
{
	public class Performance : System.Windows.Forms.UserControl
	{
		private Crownwood.DotNetMagic.Controls.ButtonWithStyle button6;
		private System.Windows.Forms.PictureBox graph2;
		private System.Windows.Forms.PictureBox graph1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label8;
		private System.Diagnostics.PerformanceCounter performanceCounter1;
		private System.Diagnostics.PerformanceCounter performanceCounter2;
		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.IContainer components;
		private HWD.Graph.Line2D gr1 = new HWD.Graph.Line2D();
		private HWD.Graph.Line2D gr2 = new HWD.Graph.Line2D();
		private ArrayList arrX1 = new ArrayList();
		private ArrayList arrY1 = new ArrayList();
		private ArrayList arrX2 = new ArrayList();
		private ArrayList arrY2 = new ArrayList();
		private int i = 0;
		private string insys = HWD.Details.insys;
		private System.Resources.ResourceManager m_ResourceManager;

		public System.Resources.ResourceManager rsxmgr
		{
			set
			{
				this.m_ResourceManager = value;
			}

		}

		public Performance()
		{
			InitializeComponent();
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.button6 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
			this.graph2 = new System.Windows.Forms.PictureBox();
			this.graph1 = new System.Windows.Forms.PictureBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.performanceCounter1 = new System.Diagnostics.PerformanceCounter();
			this.performanceCounter2 = new System.Diagnostics.PerformanceCounter();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.performanceCounter2)).BeginInit();
			this.SuspendLayout();
			// 
			// button6
			// 
			this.button6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.button6.Location = new System.Drawing.Point(11, 12);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(96, 32);
			this.button6.TabIndex = 29;
			this.button6.Text = "Activate";
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// graph2
			// 
			this.graph2.BackColor = System.Drawing.Color.Black;
			this.graph2.Location = new System.Drawing.Point(19, 196);
			this.graph2.Name = "graph2";
			this.graph2.Size = new System.Drawing.Size(584, 80);
			this.graph2.TabIndex = 28;
			this.graph2.TabStop = false;
			// 
			// graph1
			// 
			this.graph1.BackColor = System.Drawing.Color.Black;
			this.graph1.Location = new System.Drawing.Point(19, 76);
			this.graph1.Name = "graph1";
			this.graph1.Size = new System.Drawing.Size(584, 80);
			this.graph1.TabIndex = 27;
			this.graph1.TabStop = false;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(11, 172);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(136, 16);
			this.label10.TabIndex = 26;
			this.label10.Text = "CPU Usage";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(11, 52);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(128, 16);
			this.label8.TabIndex = 25;
			this.label8.Text = "Memory Usage";
			// 
			// performanceCounter1
			// 
			this.performanceCounter1.CategoryName = "Paging File";
			this.performanceCounter1.CounterName = "% Usage";
			this.performanceCounter1.InstanceName = "_Total";
			// 
			// performanceCounter2
			// 
			this.performanceCounter2.CategoryName = "Processor";
			this.performanceCounter2.CounterName = "% Processor Time";
			this.performanceCounter2.InstanceName = "_Total";
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Performance
			// 
			this.Controls.Add(this.button6);
			this.Controls.Add(this.graph2);
			this.Controls.Add(this.graph1);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label8);
			this.Name = "Performance";
			this.Size = new System.Drawing.Size(614, 289);
			this.Load += new System.EventHandler(this.Performance_Load);
			((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.performanceCounter2)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void InitGraph()
		{
			this.gr1.Width = this.graph1.Width;
			this.gr1.Height = this.graph1.Height;
			this.gr2.Width = this.graph2.Width;
			this.gr2.Height = this.graph2.Height;

			this.gr1.InitializeGraph();
			this.gr2.InitializeGraph();
			this.graph1.Image = this.gr1.GetGraph();
			this.graph2.Image = this.gr2.GetGraph();
		}

		private void button6_Click(object sender, System.EventArgs e)
		{
			if (this.button6.Text == "Desactive") 
			{
				this.timer1.Enabled = false;
				this.button6.Text = "Active";
			} 
			else 
			{
				this.performanceCounter1.MachineName = this.insys;
				this.performanceCounter2.MachineName = this.insys;
				this.timer1.Enabled = true;
				this.button6.Text = "Desactive";
			}
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			this.arrX1.Add(i);
			this.arrY1.Add(this.performanceCounter1.NextValue());
			this.gr1.XAxis = this.arrX1;
			this.gr1.YAxis = this.arrY1;
			this.gr1.CreateGraph();
			this.graph1.Image = this.gr1.GetGraph();

			this.arrX2.Add(i);
			this.arrY2.Add(this.performanceCounter2.NextValue());
			this.gr2.XAxis = this.arrX2;
			this.gr2.YAxis = this.arrY2;
			this.gr2.CreateGraph();
			this.graph2.Image = this.gr2.GetGraph();
			
			if(this.i > 300) 
			{
				this.i = 0;
				this.arrX1.Clear();
				this.arrY1.Clear();
				this.arrX2.Clear();
				this.arrY2.Clear();
			}
			this.i++;
		}

		private void Performance_Load(object sender, System.EventArgs e)
		{
			this.button6.Text = m_ResourceManager.GetString("dbutton6");
			this.label8.Text = m_ResourceManager.GetString("dlabel8");
			this.label10.Text = m_ResourceManager.GetString("dlabel10");
			this.InitGraph();
		}
	}
}
