using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Speed_indicator_graph
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private int num = 0; //current graph
        private void Form1_Load(object sender, EventArgs e)
        {
            sensors.Add(new F_sensor()); sensors[0].Frequency = 50;
            sensors.Add(new F_sensor()); sensors[1].Frequency = 180;
            sensors.Add(new F_sensor()); sensors[2].Frequency = 70;
            listBox2.Items.Add("sensor "+0);
            listBox2.Items.Add("sensor " + 1);
            listBox2.Items.Add("sensor " + 2);
            listBox2.SelectedIndex = 0;
            num = listBox2.SelectedIndex;
            paint();
        }
        private int func_type=0;
        private List<F_sensor> sensors=new List<F_sensor>();
        private void paint()
        {
            int num = 0;
            double max = 0;
            for (int i = 0; i < sensors.Count; i++)
            {
                if (sensors[i] > max)
                {
                    max = sensors[i].Frequency;
                    num = i;
                }
            }
            double maxSpeed = sensors[num].Speed * 1.5;
            max *= 1.5;
            Bitmap bm = new Bitmap(450, 400);
            Graphics g = Graphics.FromImage(bm);
            panel1.BackgroundImage = bm;
            g.DrawLine(Pens.Black, 5, 5, 5, 400);
            g.DrawLine(Pens.Black, 5, 5, 445, 5);
            g.DrawString("" + 0+sensors[num].Units, SystemFonts.CaptionFont, Brushes.Black, 5, 5);
            g.DrawString(""+(int)maxSpeed+sensors[num].Units, SystemFonts.CaptionFont, Brushes.Black, 5, 185);
            g.DrawString("Starting speed = "+(int)sensors[num].Speed+ sensors[num].Units,
                SystemFonts.CaptionFont,Brushes.Green,300,185);
            g.DrawLine(Pens.Black, 5, 200, 445, 200);
            g.DrawString("" + 0+"Hz", SystemFonts.CaptionFont, Brushes.Black, 5, 205);
            g.DrawString("" + (int)max+"Hz", SystemFonts.CaptionFont, Brushes.Black, 5, 385);
            g.DrawString("Frequency = "+(int)sensors[num].Frequency+"Hz", SystemFonts.CaptionFont, Brushes.Green, 320, 385);
            double startFreq = sensors[num].Frequency;
            for (int i = 0; i < 430; i += 2)
            {
                Point a = new Point(i+5, 5 + (int)(sensors[num].Speed/maxSpeed*200));
                Point b = new Point(i+5, 205 + (int)(sensors[num].Frequency/max*200));
                switch(func_type)
                {
                    case 0: break;
                    case 1: sensors[num].Frequency = sensors[num].Frequency + Math.Sin(i) * 35; break;
                    case 2: sensors[num].Frequency = sensors[num].Frequency + Math.Cos(i) * 35; break;
                    case 3: sensors[num].Frequency += 4; if (sensors[num].Frequency > max) max *= 1.5; break;
                    default: break;
                }
                if (sensors[num].Speed >= maxSpeed-50) maxSpeed *= 1.5;
                g.DrawLine(Pens.Blue, a, new Point(i + 6, 5 + (int)(sensors[num].Speed / maxSpeed * 200)));
                g.DrawLine(Pens.Red, b, new Point(i + 6, 205 + (int)(sensors[num].Frequency / max * 200)));
            }
            panel1.Refresh();
            sensors[num].Frequency = startFreq;
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            func_type = listBox1.SelectedIndex;
            paint();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) sensors[listBox2.SelectedIndex].Units = "km/h"; else sensors[listBox2.SelectedIndex].Units = "m/s";
            paint();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            sensors[listBox2.SelectedIndex].Frequency = (double)numericUpDown1.Value;
            paint();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add("sensor " + listBox2.Items.Count);
            sensors.Add(new F_sensor());
            paint();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (sensors.Count == 1) throw new Exception("You shouldn't remove last graph");
            sensors.RemoveAt(listBox2.SelectedIndex);
            listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            paint();
        }
    }
}
