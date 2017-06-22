using System.Drawing;
using System.Windows.Forms;
using System.Threading;
namespace Polymorph
{

    public abstract class temperatureIndicator
    {
        protected bool error = false;
        protected int color;
        protected float brightness;
        protected float size;
        public abstract void setTemp(float t);
        public abstract float getTemp();
        public abstract int getColor();
        public abstract void setColor(int col);
        public abstract float getBrightness();
        public abstract void setBrightness(float b);
        public abstract void setSize(float a, float b);
        public abstract float getSize();
        public abstract void doPaint();
    }
    public class temp1 : temperatureIndicator
    {
        Graphics grBack;
        Panel panel;
        float temp=0;
        
        public temp1(Panel p, Graphics c) { panel = p; grBack = c; }
        public override void setTemp(float t)
        {
            temp = t;
        }
        public override float getTemp() { return temp; }
        public override int getColor() { return 0; }
        public override void setColor(int col) { color = col; }
        public override float getBrightness() { return 0; }
        public override void setBrightness(float a) { }
        public override void setSize(float a, float b) { }
        public override float getSize() { return 0; }
        public bool this[int k]{ get { return true; } } //перегрузка индексатора вместо []
        public override void doPaint()
        {
            Bitmap btmBack = new Bitmap(348, 235);      //изображение
            grBack = Graphics.FromImage(btmBack);
            panel.BackgroundImage = btmBack;
            grBack.FillEllipse(Brushes.Bisque, new Rectangle(20, 20, 80, 80));
            grBack.DrawString(this.getTemp()+"°C", new Font(FontFamily.GenericMonospace, 15), Brushes.Blue, new Point(90, 10));
            panel.Refresh();
            Thread.Sleep(50);
        }
    }
    public class temp2 : temperatureIndicator
    {
        Panel panel;
        Graphics grBack;
        float temp=0;
        public temp2(Panel p , Graphics c) { panel = p; grBack = c; }
        public override void setTemp(float t)
        {
            temp = t;
        }
        public override float getTemp() { return temp; }
        public override int getColor() { return 0; }
        public override void setColor(int col) { color = col; }
        public override float getBrightness() { return 0; }
        public override void setBrightness(float a) { }
        public override void setSize(float a, float b) { }
        public override float getSize() { return 0; }
        public override void doPaint()
        {
            Bitmap btmBack = new Bitmap(348, 235);
            Graphics grBack = Graphics.FromImage(btmBack);
            panel.BackgroundImage = btmBack;
            grBack.DrawRectangle(Pens.Brown, new Rectangle(20, 20, 100, 25));
            grBack.DrawString("T1 = " + this.getTemp() + " °C", new Font(FontFamily.GenericSansSerif, 13), Brushes.Blue, new Point(22, 23));
            panel.Refresh();
            Thread.Sleep(50);
        }
    }
    public class temp3 : temperatureIndicator
    {
        Graphics grBack;
        float temp=0;
        Panel panel;
        public temp3(Panel p, Graphics c) { panel = p; grBack = c; }
        public override void setTemp(float t)
        {
            if (t > 40 || t < 0) error = true;
            else
            temp = t;
        }
        public override float getTemp() { return temp; }
        public override int getColor() { return 0; }
        public override void setColor(int col) { color = col; }
        public override float getBrightness() { return 0; }
        public override void setBrightness(float a) { }
        public override void setSize(float a, float b) { }
        public override float getSize() { return 0; }
        public override void doPaint()
        {
            Bitmap btmBack = new Bitmap(348, 235);      //изображение
            Graphics grBack = Graphics.FromImage(btmBack);
            panel.BackgroundImage = btmBack;
            grBack.DrawRectangle(Pens.Black, 20, 20, 50, 200);
            grBack.FillRectangle(Brushes.Blue, 60, 200 - this.getTemp() * 4, 5, this.getTemp() * 4);
            grBack.DrawString(this.getTemp() + "C", new Font(FontFamily.GenericSansSerif, 12), Brushes.Black, 80, 40);
            grBack.DrawLine(Pens.Black, 60, 30, 60, 200);
            grBack.DrawLine(Pens.Black, 50, 200, 70, 200);
            grBack.DrawString("0", new Font(FontFamily.GenericSansSerif, 11), Brushes.Black, 40, 200);
            grBack.DrawLine(Pens.Black, 50, 160, 70, 160);
            grBack.DrawString("10", new Font(FontFamily.GenericSansSerif, 11), Brushes.Black, 35, 160);
            grBack.DrawLine(Pens.Black, 50, 120, 70, 120);
            grBack.DrawString("20", new Font(FontFamily.GenericSansSerif, 11), Brushes.Black, 35, 120);
            grBack.DrawLine(Pens.Black, 50, 80, 70, 80);
            grBack.DrawString("30", new Font(FontFamily.GenericSansSerif, 11), Brushes.Black, 35, 80);
            grBack.DrawLine(Pens.Black, 50, 40, 70, 40);
            grBack.DrawString("40", new Font(FontFamily.GenericSansSerif, 11), Brushes.Black, 35, 40);
            panel.Refresh();
            Thread.Sleep(50);
        }
    }
    public partial class Form1 : Form
    {
        public temp1 t1;
        public temp2 t2;
        public temp3 t3;
        public Form1()
        {
            InitializeComponent();
            t1 = new temp1(panel1,panel1.CreateGraphics());
            t2 = new temp2(panel2,panel2.CreateGraphics());
            t3 = new temp3(panel3,panel3.CreateGraphics());
            //Thread x = new Thread(t1.doPaint);
            //x.Start();
            //Thread y = new Thread(t2.doPaint);
            //y.Start();
            //Thread z = new Thread(t3.doPaint);
            //z.Start();
        }

        private void panel1_Paint(object sender, PaintEventArgs e){}
        private void panel2_Paint(object sender, PaintEventArgs e){}
        private void button1_Click(object sender, System.EventArgs e)
        {
            t1.setTemp((float)numericUpDown1.Value);
            t1.doPaint();
        }
        private void button2_Click(object sender, System.EventArgs e)
        {
            t2.setTemp((float)numericUpDown2.Value);
            t2.doPaint();
        }
        private void button3_Click(object sender, System.EventArgs e)
        {
            t3.setTemp((float)numericUpDown3.Value);
            t3.doPaint();
        }
    }
}
