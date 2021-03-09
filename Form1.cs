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
            LinearGraph();
        }

        private void XMax_ValueChanged(object sender, EventArgs e)
        {
            if (XMin.Value > XMax.Value)
            {
                XMin.Value = XMax.Value - 1;
            }
            DrawAxies();
            LinearGraph();
        }

        private void YMin_ValueChanged(object sender, EventArgs e)
        {
            if (YMin.Value > YMax.Value)
            {
                YMax.Value = YMin.Value + 1;
            }
            DrawAxies();
            LinearGraph();
        }

        private void YMax_ValueChanged(object sender, EventArgs e)
        {
            if (YMin.Value > YMax.Value)
            {
                YMin.Value = YMax.Value - 1;
            }
            DrawAxies();
            LinearGraph();
        }

        private void XInterval_ValueChanged(object sender, EventArgs e)
        {
            DrawAxies();
            LinearGraph();
        }

        private void YInterval_ValueChanged(object sender, EventArgs e)
        {
            DrawAxies();
            LinearGraph();
        }

        private void LinearGraphButton_Click(object sender, EventArgs e)
        {
            if (LinearM.Text.Length == 0 || LinearB.Text.Length == 0)
            {
                MessageBox.Show("Please fill in all of the fields before trying to graph the Linear equation.");
                return;
            }
            LinearGraph();
        }
        public void LinearGraph()
        {
            if (LinearM.Text.Length == 0 || LinearB.Text.Length == 0)
                return;
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            decimal? ymaxpoint = null;
            decimal? yminpoint = null;
            decimal? xmaxpoint = null;
            decimal? xminpoint = null;
            for (decimal i = XMin.Value; XMin.Value <= i && i <= XMax.Value; i = i + (decimal)0.1)
            {
                decimal point = Linear(Convert.ToDecimal(LinearM.Text), i, Convert.ToDecimal(LinearB.Text));
                if (point <= YMax.Value && point >= YMin.Value)
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
            }
            g.DrawLine(new Pen(Color.Black), (float)(400 - (xminpoint / XMin.Value) * 400), (float)(800 - (400 - (yminpoint / YMin.Value) * 400)), (float)(400 + (xmaxpoint / XMax.Value) * 400), (float)(800 - (400 + (ymaxpoint / YMax.Value) * 400)));
            Graph.Image = image;
        }
        public decimal Linear(decimal m, decimal x, decimal b)
        {
            return (m * x) + b;
        }
        //makes sure only things I want can be input
        private void LinearM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue > 47 && e.KeyValue < 56)
            {
                LinearM.Text = LinearM.Text + (char)e.KeyValue;
            }
            else if(e.KeyValue == 189)
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
            if (e.KeyValue > 47 && e.KeyValue < 56)
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
    }
}
