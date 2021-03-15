using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Assign4
{
    public partial class Form1 : Form
    {
        //public variables that allow drawing on the picture box
        public Graphics g;
        public Image image;
        public Color LinearCol = Color.Black;
        public Color QuadCol = Color.Black;
        public Color CircleCol = Color.Black;
        public Color CubicCol = Color.Black;
        public int drawCount = 0;   // counter to keep track of number of graphs drawn
        public Form1()
        {
            InitializeComponent();
            //initial drawing based on what is in the numeric updowns
            DrawAxies();
            LinearMTip.SetToolTip(LinearM, "This is the M value in the equation above or the slope");
            LinearBTip.SetToolTip(LinearB, "This is the b value in the equation above or the y-intercept");
            LinearGraphTip.SetToolTip(LinearEqButton, "Click this button to graph the linear equation on the graph");
            XMinTip.SetToolTip(XMin, "This numeric updown controls the minimum X-Value that will be on the graph");
            YMinTip.SetToolTip(YMin, "This numeric updown controls the minimum Y-Value that will be on the graph");
            XMaxTip.SetToolTip(XMax, "This numeric updown controls the maximum X-Value that will be on the graph");
            YMaxTip.SetToolTip(YMax, "This numeric updown controls the maximum Y-Value that will be on the graph");
            XIntervalTip.SetToolTip(XInterval, "This controls the intervals of the tick marks for X-Values on the graph");
            YIntervalTip.SetToolTip(YInterval, "This controls the intervals of the tick marks for Y-Values on the graph");
        }
        //just resets the graph so that it can be redrawn on
        public void refresh()
        {
            image = new Bitmap(800, 800);
            g = Graphics.FromImage(image);
        }
        //draws the axies 
        public void DrawAxies()
        {
            refresh();
            //if the axis should exist on screen it draws it
            if (XMax.Value > 0 && XMin.Value < 0)
            {
                //finds where the 0 should be
                decimal point = (-1 * XMin.Value) / (XDif()) * 800;
                //draws it and then prints it onto the picture box
                g.DrawLine(new Pen(Color.Black), (float)point, 0, (float)point, 800);
                Graph.Image = image;
            }
            //if the other axis should exist it draws that as well
            if (YMin.Value < 0 && YMax.Value > 0)
            {
                decimal point = 800 - (-1 * YMin.Value) / (YDif()) * 800;
                g.DrawLine(new Pen(Color.Black), 0, (float)point, 800, (float)point);
                Graph.Image = image;
            }
            DrawTicks();
        }
        //draws the tick marks and labels them
        public void DrawTicks()
        {
            //variables that need to be used in different areas
            decimal Xmark = 0;
            int XCount = 0;
            Font myfont = new Font("Arial", 8);
            decimal XVal = XMin.Value;
            decimal YVal = YMax.Value;
            int YCount = 0;
            decimal Ypoint = 0;
            decimal Xpoint = 0;
            if (YDif() != 0)
                Xpoint = 800 - ((-1 * YMin.Value) / (YDif()) * 800);

            // was getting a divide by zero error sometimes so added conditional
            if (XDif() == 0)
                return;
            Ypoint = (-1 * XMin.Value) / (XDif()) * 800;
            //As it works it's way across the X axis
            while (Xmark < 800)
            {
                //if the x axis is on the screen it puts the ticks and numbers on it
                if ((YMin.Value < 0 && YMax.Value > 0))
                {
                    //just removes the outer ticks as well as the one at the origin so that they don't get all smooshed
                    if (XCount % 2 == 0 && XCount != 0 && XVal != 0)
                    {
                        //labels the ticks and has two cases for in case it needs a negative sign
                        if (XVal < 0)
                        {
                            g.DrawString("-" + XVal.ToString(), myfont, new SolidBrush(Color.Black), (float)Xmark - 5, (float)Xpoint - 20);
                        }
                        else
                        {
                            g.DrawString(XVal.ToString(), myfont, new SolidBrush(Color.Black), (float)Xmark - 5, (float)Xpoint - 20);
                        }
                    }
                    //increments that vars
                    g.DrawLine(new Pen(Color.Black), (float)Xmark, (float)Xpoint - 5, (float)Xmark, (float)Xpoint + 5);
                    if (XDif() == 0)
                        return;
                    Xmark += (XInterval.Value / XDif() * 800);
                    XCount++;
                    XVal += XInterval.Value;

                }
                else
                {
                    //the  same as above but if there is no axis
                    if (XCount % 2 == 0 && XCount != 0 && XVal != 0)
                    {
                        if (XVal < 0)
                        {
                            g.DrawString("-" + XVal.ToString(), myfont, new SolidBrush(Color.Black), (float)Xmark - 5, 780);
                        }
                        else
                        {
                            g.DrawString(XVal.ToString(), myfont, new SolidBrush(Color.Black), (float)Xmark - 5, 780);
                        }
                    }
                    g.DrawLine(new Pen(Color.Black), (float)Xmark, 800, (float)Xmark, 795);
                    Xmark += (XInterval.Value / XDif() * 800);
                    XCount++;
                    XVal += XInterval.Value;
                }
            }
            //same as above but for Y's
            decimal Ymark = 0;
            while (Ymark < 800)
            {
                if ((XMin.Value < 0 && XMax.Value > 0))
                {
                    if (YCount % 2 == 0 && YCount != 0 && YVal != 0)
                    {
                        if (YVal < 0)
                        {
                            g.DrawString("-" + YVal.ToString(), myfont, new SolidBrush(Color.Black), (float)Ypoint - 20, (float)Ymark - 5);
                        }
                        else
                        {
                            g.DrawString(YVal.ToString(), myfont, new SolidBrush(Color.Black), (float)Ypoint - 20, (float)Ymark - 5);
                        }
                    }
                    g.DrawLine(new Pen(Color.Black), (float)Ypoint - 5, (float)Ymark, (float)Ypoint + 5, (float)Ymark);
                    Ymark += YInterval.Value * (800 / YDif());
                    YCount++;
                    YVal -= YInterval.Value;
                }
                else
                {
                    if (YCount % 2 == 0 && YCount != 0 && YVal != 0)
                    {
                        if (YVal < 0)
                        {
                            g.DrawString("-" + YVal.ToString(), myfont, new SolidBrush(Color.Black), 20, (float)Ymark - 5);
                        }
                        else
                        {
                            g.DrawString(YVal.ToString(), myfont, new SolidBrush(Color.Black), 20, (float)Ymark - 5);
                        }
                    }
                    g.DrawLine(new Pen(Color.Black), 0, (float)Ymark, 5, (float)Ymark);
                    Ymark += YInterval.Value * (800 / YDif());
                    YCount++;
                    YVal -= YInterval.Value;
                }
            }
            //adds it all to the picture box
            Graph.Image = image;
        }
        //just finds the difference in min and max for X and then the same for Y just because of How many times I needed it
        public decimal XDif()
        {
            return XMax.Value - XMin.Value;
        }
        public decimal YDif()
        {

            return YMax.Value - YMin.Value;
        }
        //Several functions That make sure that the Mins and maxes are correct 
        private void XMin_ValueChanged(object sender, EventArgs e)
        {
            if (XMin.Value >= XMax.Value)
            {
                XMax.Value = XMin.Value + 1;
            }
            DrawAxies();
            LinearGraph();
            CircleGraph();
            QuadraticGraph();
            CubicGraph();
        }

        private void XMax_ValueChanged(object sender, EventArgs e)
        {
            if (XMin.Value >= XMax.Value)
            {
                XMin.Value = XMax.Value - 1;
            }

            DrawAxies();
            LinearGraph();
            CircleGraph();
            QuadraticGraph();
            CubicGraph();
        }

        private void YMin_ValueChanged(object sender, EventArgs e)
        {
            if (YMin.Value >= YMax.Value)
            {
                YMax.Value = YMin.Value + 1;
            }
            DrawAxies();
            LinearGraph();
            CircleGraph();
            QuadraticGraph();
            CubicGraph();
        }

        private void YMax_ValueChanged(object sender, EventArgs e)
        {
            if (YMin.Value >= YMax.Value)
            {
                YMin.Value = YMax.Value - 1;
            }
            DrawAxies();
            LinearGraph();
            CircleGraph();
            QuadraticGraph();
            CubicGraph();
        }

        private void XInterval_ValueChanged(object sender, EventArgs e)
        {
            DrawAxies();
            LinearGraph();
            CircleGraph();
            QuadraticGraph();
            CubicGraph();
        }

        private void YInterval_ValueChanged(object sender, EventArgs e)
        {
            DrawAxies();
            LinearGraph();
            CircleGraph();
            QuadraticGraph();
            CubicGraph();
        }

        private void LinearGraphButton_Click(object sender, EventArgs e)
        {
            if (LinearM.Text.Length == 0 || LinearB.Text.Length == 0 || LinearM.Text.Equals("-") || LinearB.Text.Equals("-"))
            {
                MessageBox.Show("Please fill in all of the fields before trying to graph the Linear equation.");
                return;
            }
            ColorDialog LinearColor = new ColorDialog();
            if (LinearColor.ShowDialog() == DialogResult.OK)
            {
                LinearCol = LinearColor.Color;
            }
            LinearGraph();
        }
        public void LinearGraph()
        {
            if (LinearM.Text.Length == 0 || LinearB.Text.Length == 0)
                return;
            
            decimal? ymaxpoint = null;
            decimal? yminpoint = null;
            decimal? xmaxpoint = null;
            decimal? xminpoint = null;
            decimal xmin;
            decimal xmax;
            decimal ymin;
            decimal ymax;
            if(XMin.Value == 0)
            {
                xmin = (decimal)0.01;
            }
            else
            {
                xmin = XMin.Value;
            }
            if (XMax.Value == 0)
            {
                xmax = (decimal)0.01;
            }
            else
            {
                xmax = XMax.Value;
            }
            if (YMin.Value == 0)
            {
                ymin = (decimal)0.01;
            }
            else
            {
                ymin = YMin.Value;
            }
            if (YMax.Value == 0)
            {
                ymax = (decimal)0.01;
            }
            else
            {
                ymax = YMax.Value;
            }
            for (decimal i = xmin; xmin <= i && i <= xmax; i = i + (decimal)0.1)
            {
                decimal point = Linear(Convert.ToDecimal(LinearM.Text), i, Convert.ToDecimal(LinearB.Text));
                if (point <= ymax && point >= ymin)
                {
                    if (yminpoint == null || xminpoint == null)
                    {
                        yminpoint = point;
                        xminpoint = i;
                    }
                    else
                    {
                        ymaxpoint = point;
                        xmaxpoint = i;
                    }
                }
            }
            if (yminpoint == null || ymaxpoint == null)
            {
                MessageBox.Show("line is not of the graph");
                return;
            }

            // clear graph if count = 4
            if (drawCount % 4 == 0)
                DrawAxies();
            drawCount += 1;
            float x1 = (float)((xmin - xminpoint) * (800/XDif()));
            float x2 = (float)((xmaxpoint- xmin) * (800/XDif()));
            float y1 = (float)((ymin - yminpoint) * (800/YDif()));
            float y2 = (float)((ymaxpoint - ymin) * (800/YDif()));
            if(x1 < 0)
            {
                x1 *= -1;
            }
            if(x2 < 0)
            {
                x2 *= -1;
            }
            if(y1 < 0)
            {
                y1 *= -1;
            }
            if(y2 < 0)
            {
                y2 *= -1;
            }
            y1 = 800 - y1;
            y2 = 800 - y2;
            g.DrawLine(new Pen(LinearCol), x1, y1, x2, y2);
            //g.DrawLine(new Pen(LinearCol), (float)(400 - (xminpoint / XMin.Value) * 400), (float)(800 - (400 - (yminpoint / YMin.Value) * 400)), (float)(400 + (xmaxpoint / XMax.Value) * 400), (float)(800 - (400 + (ymaxpoint / YMax.Value) * 400)));   
            Graph.Image = image;
        }
        public decimal Linear(decimal m, decimal x, decimal b)
        {
            return (m * x) + b;
        }
        //makes sure only things I want can be input
        private void LinearM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue > 47 && e.KeyValue < 58)
            {
                LinearM.Text = LinearM.Text + (char)e.KeyValue;
            }
            else if (e.KeyValue == 189)
            {
                if (LinearM.Text.Length == 0)
                    LinearM.Text = "-";
            }
            else if (e.KeyValue == 190)
            {
                if (LinearM.Text.Length == 0)
                    LinearM.Text = "0.";
                else if (LinearM.Text.Contains("."))
                    return;
                LinearM.Text = LinearM.Text + ".";
            }
            if (e.KeyCode == Keys.Back)
            {
                if (LinearM.Text.Length == 0)
                    return;
                else
                {
                    LinearM.Text = LinearM.Text.Substring(0, LinearM.Text.Length - 1);
                }
            }
        }
        //makes sure only things I want can be input
        private void LinearB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue > 47 && e.KeyValue < 58)
            {
                LinearB.Text = LinearB.Text + (char)e.KeyValue;
            }
            else if (e.KeyValue == 189)
            {
                if (LinearB.Text.Length == 0)
                    LinearB.Text = "-";
            }
            else if (e.KeyValue == 190)
            {
                if (LinearB.Text.Length == 0)
                {
                    LinearB.Text = "0.";
                    return;
                }
                else if (LinearB.Text.Contains("."))
                    return;
                LinearB.Text = LinearB.Text + ".";
            }
            if (e.KeyCode == Keys.Back)
            {
                if (LinearB.Text.Length == 0)
                    return;
                else
                {
                    LinearB.Text = LinearB.Text.Substring(0, LinearB.Text.Length - 1);
                }
            }
        }

        private void QuadButton_Click(object sender, EventArgs e)
        {
            // if no input, do nothing
            if (QuadA.Text.Length == 0 && QuadB.Text.Length == 0 && QuadC.Text.Length == 0)
            {
                MessageBox.Show("Please fill in all of the fields before trying to graph the Quadratic equation.", "Error");
                return;
            }

            // get color for current graph
            ColorDialog QuadColor = new ColorDialog();
            if (QuadColor.ShowDialog() == DialogResult.OK)
            {
                QuadCol = QuadColor.Color;
            }
            QuadraticGraph();
        }

        public void QuadraticGraph()
        {
            // if no input, do nothing
            if (QuadA.Text.Length == 0 || QuadB.Text.Length == 0 || QuadC.Text.Length == 0)   
                return;

            // relative position of x based on min and max value
            decimal sizeX = 800 / ((Math.Abs(XMin.Value) + Math.Abs(XMax.Value)));

            // list of points to create curve
            List<PointF> points = new List<PointF>();
            bool onGraph = false;

            // a, b, and c values scaled based on size of graph
            decimal a = Convert.ToDecimal(QuadA.Text) * sizeX;
            decimal b = Convert.ToDecimal(QuadB.Text) * sizeX;
            decimal c = Convert.ToDecimal(QuadC.Text) * sizeX;

            // get a list of all points in the range of the x axis
            for (decimal x = XMin.Value; x < XMax.Value; x+= (decimal)0.1)
            {
                // get y value based on x value and and to list of points
                decimal y =  a * (x * x) + (b * x) + c;
                PointF curPoint = new PointF((float)((sizeX * Math.Abs(XMin.Value)) + x * sizeX), (float)((sizeX * Math.Abs(XMax.Value)) - y));
                points.Add(curPoint);

                // set flag to true if there is a point within bounds
                if ((curPoint.X <= 800 && curPoint.X >= 0) && (curPoint.Y <= 800 && curPoint.Y >= 0))
                    onGraph = true;
            }

            // don't draw graph if no visible points exist
            if (!onGraph)
            {
                MessageBox.Show("Line is not of the graph", "Out of bounds error");
                return;
            }

            // clear graph if count = 4
            if (drawCount % 4 == 0)
                DrawAxies();
            drawCount += 1;

            // draw quadratic graph
            g.DrawCurve(new Pen(QuadCol), points.ToArray());
            Graph.Image = image;
            return;
        }

        private void CircleButton_Click(object sender, EventArgs e)
        {
            // if no input, do nothing
            if (CircleH.Text.Length == 0 || CircleK.Text.Length == 0 || CircleR.Text.Length == 0)
            {
                MessageBox.Show("Please fill in all of the fields before trying to graph the Circle equation.", "Error");
                return;
            }

            // get color for current graph
            ColorDialog CircleColor = new ColorDialog();
            if (CircleColor.ShowDialog() == DialogResult.OK)
            {
                CircleCol = CircleColor.Color;
            }
            CircleGraph();
        }

        public void CircleGraph()
        {
            // if no input, do nothing
            if (CircleH.Text.Length == 0 && CircleK.Text.Length == 0 && CircleR.Text.Length == 0)
                return;

            // relative postions of x and y based on min and max values 
            decimal sizeX = 800 / (Math.Abs(XMin.Value) + Math.Abs(XMax.Value));
            decimal sizeY = 800 / (Math.Abs(YMin.Value) + Math.Abs(YMax.Value));
            decimal sizeX1 = (Math.Abs(XMin.Value) + Math.Abs(XMax.Value)) / 2;
            decimal sizeY1 = (Math.Abs(YMin.Value) + Math.Abs(YMax.Value)) / 2;

            // h, k, and r values scaled based on size of graph
            decimal h = Convert.ToDecimal(CircleH.Text) * sizeX;
            decimal k = Convert.ToDecimal(CircleK.Text) * sizeY;
            decimal r = (decimal)Math.Sqrt(Convert.ToDouble(CircleR.Text)) * sizeX;

            // verify line is on the graph
            if (((h + (sizeX * sizeX1)) <= 0 || (h + (sizeX * sizeX1)) >= 800) || (((sizeY * sizeY1) - k) <= 0 || ((sizeY * sizeY1) - k) >= 800))
            {
                MessageBox.Show("Line is not of the graph", "Out of bounds error");
                return;
            }

            // clear graph if count = 4
            if (drawCount % 4 == 0)
                DrawAxies();
                drawCount += 1;

            // draw the circle graph
            g.DrawCircle(new Pen(CircleCol), (float)(h + (sizeX * sizeX1)), (float)((sizeY * sizeY1) - k), (float)r);
            Graph.Image = image;
            return;
        }

        private void CubeButton_Click(object sender, EventArgs e)
        {
            // if no input, do nothing
            if (CubeA.Text.Length == 0 || CubeB.Text.Length == 0 || CubeC.Text.Length == 0 || CubeD.Text.Length == 0)
            {
                MessageBox.Show("Please fill in all of the fields before trying to graph the Cubic equation.", "No input error");
                return;
            }

            // get color for current graph
            ColorDialog CubicColor = new ColorDialog();
            if (CubicColor.ShowDialog() == DialogResult.OK)
            {
                CubicCol = CubicColor.Color;
            }
            CubicGraph();
        }

        public void CubicGraph()
        {
            // if no input, do nothing
            if (CubeA.Text.Length == 0 || CubeB.Text.Length == 0 || CubeC.Text.Length == 0 || CubeD.Text.Length == 0)
                return;

            // list to hold all the points
            List<PointF> points = new List<PointF>();
            bool onGraph = false;

            //relative position of x and y based on min and max values
            decimal sizeX = 800 / (Math.Abs(XMin.Value) + Math.Abs(XMax.Value));
            decimal sizeX1 = (Math.Abs(XMin.Value) + Math.Abs(XMax.Value)) / 2;

            // a, b, c, and d values scaled based on graph size
            decimal a = Convert.ToDecimal(CubeA.Text) * sizeX;
            decimal b = Convert.ToDecimal(CubeB.Text) * sizeX;
            decimal c = Convert.ToDecimal(CubeC.Text) * sizeX;
            decimal d = Convert.ToDecimal(CubeD.Text) * sizeX;

            // get a list of all points in the range of the x axis
            for (decimal x = XMin.Value; x < XMax.Value; x+= (decimal)0.1)
            {
                // get y value based on x value and and to list of points
                decimal y = (a * (x * x * x)) + (b * (x * x)) + (c * x) + d;
                PointF curPoint = new PointF((float)((sizeX * sizeX1) + x * sizeX), (float)((sizeX * sizeX1) - y));
                points.Add(curPoint);
                if ((curPoint.X <= 800 && curPoint.X >= 0) || (curPoint.Y <= 800 || curPoint.Y >= 0))
                    onGraph = true;
            }

            if (!onGraph)
            {
                MessageBox.Show("Line is not of the graph", "Out of bounds error");
                return;
            }

            // clear graph if count = 4
            if (drawCount % 4 == 0)
                DrawAxies();
            drawCount += 1;

            // draw the cube graph
            g.DrawCurve(new Pen(CubicCol), points.ToArray());
            Graph.Image = image;
            return;
        }
    }

    public static class Extensions
    {
        // helper function to draw circles
        public static void DrawCircle(this Graphics g, Pen pen,
              float centerX, float centerY, float radius)
        {
            g.DrawEllipse(pen, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }
    }
}
