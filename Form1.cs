using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assign4
{
    public partial class Form1 : Form
    {
        //public variables that allow drawing on the picture box
        public Graphics g;
        public Image image;
        public Form1()
        {
            InitializeComponent();
            //initial drawing based on what is in the numeric updowns
            DrawAxies();
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
                decimal point = (-1*XMin.Value)/(XDif())*800;
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
            decimal Xpoint = 800 -((-1 * YMin.Value) / (YDif()) * 800);
            decimal Ypoint = (-1 * XMin.Value) / (XDif()) * 800;
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
                            g.DrawString("-" + XVal.ToString(), myfont, new SolidBrush(Color.Black), (float)Xmark - 5, (float)Xpoint-20);
                        }
                        else
                        {
                            g.DrawString(XVal.ToString(), myfont, new SolidBrush(Color.Black), (float)Xmark - 5, (float)Xpoint-20);
                        }
                    }
                    //increments that vars
                    g.DrawLine(new Pen(Color.Black), (float)Xmark, (float)Xpoint-5, (float)Xmark, (float)Xpoint+5);
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
                    g.DrawLine(new Pen(Color.Black), (float)Ypoint-5, (float)Ymark, (float)Ypoint+5, (float)Ymark);
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
            if(XMin.Value > XMax.Value)
            {
                XMax.Value = XMin.Value + 1;
            }
            DrawAxies();
        }

        private void XMax_ValueChanged(object sender, EventArgs e)
        {
            if (XMin.Value > XMax.Value)
            {
                XMin.Value = XMax.Value - 1;
            }
            DrawAxies();
        }

        private void YMin_ValueChanged(object sender, EventArgs e)
        {
            if (YMin.Value > YMax.Value)
            {
                YMax.Value = YMin.Value + 1;
            }
            DrawAxies();
        }

        private void YMax_ValueChanged(object sender, EventArgs e)
        {
            if (YMin.Value > YMax.Value)
            {
                YMin.Value = YMax.Value - 1;
            }
            DrawAxies();
        }

        private void XInterval_ValueChanged(object sender, EventArgs e)
        {
            DrawAxies();
        }

        private void YInterval_ValueChanged(object sender, EventArgs e)
        {
            DrawAxies();
        }
    }
}
