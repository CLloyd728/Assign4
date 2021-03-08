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
        public Graphics g;
        public Image image;
        public Form1()
        {
            InitializeComponent();
            DrawAxies();
        }
        public void refresh()
        {
            image = new Bitmap(Graph.Width, Graph.Height);
            g = Graphics.FromImage(image);
        }
        public void DrawAxies()
        {
            refresh();
            if (XMax.Value > 0 && XMin.Value < 0)
            { 
                decimal point = (-1*XMax.Value)/(XMin.Value - XMax.Value)*800;
                g.DrawLine(new Pen(Color.Black), (float)point, 0, (float)point, 800);
                Graph.Image = image;
            }
            if (YMin.Value < 0 && YMax.Value > 0)
            {
                decimal point = (-1 * YMin.Value) / (YMax.Value - YMin.Value) * 800;
                g.DrawLine(new Pen(Color.Black), 0, (float)point, 800, (float)point);
                Graph.Image = image;
            }
            DrawTicks();
        }
        public void DrawTicks()
        {
            decimal Xmark = XMin.Value + XInterval.Value;
            while (Xmark < 800)
            {
                g.DrawLine(new Pen(Color.Black), (float)Xmark, 800, (float)Xmark, 795);
                Xmark += XInterval.Value;
                Graph.Image = image;
            }
            decimal Ymark = YMin.Value + YInterval.Value;
            while (Ymark < 800)
            {
                g.DrawLine(new Pen(Color.Black), 0, (float)Ymark, 5, (float)Ymark);
                Ymark += YInterval.Value;
                Graph.Image = image;
            }
        }
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
