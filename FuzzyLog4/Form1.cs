using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FuzzyLog4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            trackBar1.Minimum = 1;
            trackBar1.Maximum = 10;
            trackBar2.Minimum = 1;
            trackBar2.Maximum = 10;
            trackBar3.Minimum = 1;
            trackBar3.Maximum = 10;
            trackBar4.Minimum = 1;
            trackBar4.Maximum = 10;
            trackBar6.Minimum = 1;
            trackBar6.Maximum = 10;
            trackBar7.Minimum = -10;
            trackBar7.Maximum = -1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            calc4(trackBar1.Value, trackBar2.Value);
            label_a1.Text = trackBar1.Value.ToString();
            label_a2.Text = trackBar2.Value.ToString();

            calc5(trackBar3.Value, trackBar4.Value, trackBar5.Value);
            label_a.Text = trackBar3.Value.ToString();
            label_b.Text = trackBar4.Value.ToString();
            label_c.Text = trackBar5.Value.ToString();
            

            calc7(trackBar6.Value, trackBar7.Value);
            label_a11.Text = trackBar6.Value.ToString();
            label_a21.Text = trackBar7.Value.ToString();
        }

        private void calc4(int a1, int a2)
        {
            double y;
            int c1 = -2, c2 = 6;

            if (c1 < c2)
            {
                for (double x = -30; x < 30; x += 0.2)
                {
                    if (x < c1)
                    {
                        y = Math.Exp(-((Math.Pow((x - c1), 2)) / (2 * Math.Pow(a1, 2))));
                    }
                    else if (c1 <= x && x <= c2)
                    {
                        y = 1;
                    }
                    else
                    {
                        y = Math.Exp(-((Math.Pow((x - c2), 2)) / (2 * Math.Pow(a2, 2))));
                    }
                    chart2.Series["line"].Points.AddXY(x, y);
                }
            }
            else if (c2 > c1)
            {
                for (double x = -15; x < 15; x += 0.2)
                {
                    if (x < c2)
                    {
                        y = Math.Exp(-((Math.Pow((x - c1), 2)) / (2 * Math.Pow(a1, 2))));
                    }
                    else if (c2 <= x && x <= c1)
                    {
                        y = (Math.Exp(-((Math.Pow((x - c1), 2)) / (2 * Math.Pow(a1, 2))))) * (Math.Exp(-((Math.Pow((x - c2), 2)) / (2 * Math.Pow(a2, 2)))));
                    }
                    else
                    {
                        y = Math.Exp(-((Math.Pow((x - c2), 2)) / (2 * Math.Pow(a2, 2))));
                    }

                    chart2.Series["line"].Points.AddXY(x, y);
                }
            }
        }

        private void calc5(int a,int b, int c)
        {
            double y;
            for (double x = -15; x < 25; x += 0.5)
            {
                double i = (x - c) / a;
                y = 1 / (1 + Math.Pow(Math.Abs(i), 2 * b));
                chart1.Series["line"].Points.AddXY(x, y);
            }
        }

        private void calc7(int a1, int a2)
        {
            double y;           
            int c1 = 0, c2 = 6;
            for (double x = -8; x < 15; x += 0.5)
            {
                y =(1/(1+Math.Exp(-a1*(x-c1))))*(1/(1+Math.Exp(-a2*(x-c2))));
                chart3.Series["line"].Points.AddXY(x, y);
            }
        }

      /*  private void calc1()
        {
            double y;
                int a = -10, b = 3, c = 15;
            for (double x = -15; x < 20; x += 0.5)
            {
                if (x < a)
                {
                    y = 0;
                }
                else if (a <= x && x < b)
                {
                    y = -((x - a) / (b - c));
                }
                else if (b <= x && x < c)
                {
                    y = (c - x) / (c - b);
                }
                else
                {
                    y = 0;
                }

                chart3.Series["line"].Points.AddXY(x, y);
            }
        }*/
      
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            chart2.Series["line"].Points.Clear();
            chart2.Refresh();
            calc4(trackBar1.Value, trackBar2.Value);

            label_a1.Text = trackBar1.Value.ToString();
        }
        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            chart2.Series["line"].Points.Clear();
            chart2.Refresh();
            calc4(trackBar1.Value, trackBar2.Value);

            label_a2.Text = trackBar2.Value.ToString();
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            chart1.Series["line"].Points.Clear();
            chart1.Refresh();
            calc5(trackBar3.Value, trackBar4.Value, trackBar5.Value);

            label_a.Text = trackBar3.Value.ToString();
        }

        private void trackBar4_ValueChanged(object sender, EventArgs e)
        {
            chart1.Series["line"].Points.Clear();
            chart1.Refresh();
            calc5(trackBar3.Value, trackBar4.Value, trackBar5.Value);

            label_b.Text = trackBar4.Value.ToString();
        }

        private void trackBar5_ValueChanged(object sender, EventArgs e)
        {
            chart1.Series["line"].Points.Clear();
            chart1.Refresh();
            calc5(trackBar3.Value, trackBar4.Value, trackBar5.Value);

            label_c.Text = trackBar5.Value.ToString();
        }

        private void trackBar6_ValueChanged(object sender, EventArgs e)
        {
            chart3.Series["line"].Points.Clear();
            chart3.Refresh();
            calc7(trackBar6.Value, trackBar7.Value);

            label_a11.Text = trackBar6.Value.ToString();
        }

        private void trackBar7_ValueChanged(object sender, EventArgs e)
        {
            chart3.Series["line"].Points.Clear();
            chart3.Refresh();
            calc7(trackBar6.Value, trackBar7.Value);

            label_a21.Text = trackBar7.Value.ToString();
        }
    }  
}