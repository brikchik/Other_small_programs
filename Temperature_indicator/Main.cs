using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System;

namespace Temperature_indicator
{
    public partial class Main : Form
    {
        Indicators mas, mas2,active;
        Panel p;Graphics g;
        public Main()
        {
            InitializeComponent();
            p = panel1;
            g = panel1.CreateGraphics();
            mas = new Indicators(g,p);
            mas.mas.Initialize();
            mas2 = new Indicators(g,p);
            mas2.mas.Initialize();
            active = mas;
        }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void button1_Click(object sender, System.EventArgs e)
        {
            active.resize((int)numericUpDown1.Value);
        }
        private void button2_Click(object sender, System.EventArgs e)
        {
            
        }
        private void button3_Click(object sender, System.EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            active = mas2;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            active = mas;
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            active.mas[(int)numericUpDown2.Value] = new temp1(active.p, active.g);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            active.mas[(int)numericUpDown2.Value] = new temp2(active.p, active.g);
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            active.mas[(int)numericUpDown2.Value] = new temp3(active.p, active.g);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try { active.mas[(int)numericUpDown2.Value].setTemp((float)numericUpDown3.Value); } catch (NullReferenceException) { active.mas[(int)numericUpDown2.Value] = new temp1(p, g); }
            active.mas[(int)numericUpDown2.Value].setTemp((float)numericUpDown3.Value);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try { active.mas[(int)numericUpDown2.Value].name = textBox2.Text; } catch (NullReferenceException) { active.mas[(int)numericUpDown2.Value] = new temp1(p, g); }
            active.mas[(int)numericUpDown2.Value].name = textBox2.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try{active.mas[(int)numericUpDown2.Value].setSize((float)numericUpDown4.Value); } catch (NullReferenceException) { active.mas[(int)numericUpDown2.Value] = new temp1(p, g); }
            active.mas[(int)numericUpDown2.Value].setSize((float)numericUpDown4.Value);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            { active[(int)numericUpDown2.Value].paintAt((int)numericUpDown5.Value, (int)numericUpDown6.Value); }
            catch (Exception) { active.mas[(int)numericUpDown2.Value] = new temp1(p, g); listBox1.Items.Add("Type 1 indicator created automatically"); }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            mas.copy(mas2);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (temperatureIndicator elem in active.mas)
            {
                try
                {
                    listBox1.Items.Add(Array.IndexOf(active.mas, elem) + ": " + elem.name + '_' + elem.getTemp() + '_' + elem.getSize());
                }
                catch (NullReferenceException) { listBox1.Items.Add("Not initialised"); }
            }
        }
    }
    public class Indicators
    {
        public Graphics g;
        public Panel p;
        private Exception WrongTypeException=new Exception("Indicator type doesn't exist");
        public temperatureIndicator[] mas=new temperatureIndicator[3];
        public Indicators(Graphics gr, Panel panel) { g = gr; p = panel; mas.Initialize(); }
        public temperatureIndicator this[int i]
        {
            get
            {
                try
                {
                    return mas[i];
                }
                catch (Exception e) { return null; }
            }
            set { }
        }
        public void resize(int i) { Array.Resize(ref mas, i); }
        public void copy(Indicators x) { Array.Copy(mas, x.mas, mas.Length); }
        public int size { get { return mas.Length; } }
    }
    public abstract class temperatureIndicator
    {
        protected bool error = false;
        protected float size=1;
        protected float temp=0;
        protected int x=0, y=0;//coords
        public string name = "DefaultName";
        protected Exception wrongValue=new Exception("Temperature out of range");
        public abstract void setTemp(float t);  //temperature in float just in case. setTemp might be different
        public float getTemp() { return temp; }
        public void setSize(float a) { this.size = a; }
        public float getSize() { return size; }
        public abstract void doPaint();
        public float this[float k] { get { return temp; } set { setTemp(k); } } //overload instead of []. get-> any number in [], set->temp=[number]
        public bool hasError() { return error; }
        public abstract void paintAt(int x, int y);
        public static bool operator <(temperatureIndicator t1, temperatureIndicator t2) { return t1.getTemp() < t2.getTemp(); }
        public static bool operator >(temperatureIndicator t1, temperatureIndicator t2) { return t1.getTemp() > t2.getTemp(); }
    }
    public class temp1 : temperatureIndicator   //1 - circle
    {

        Panel panel;
        public temp1(Panel p, Graphics c) { panel = p;}
        public override void setTemp(float t)
        {
            if (t > 50 || t < -50) { error = true; throw wrongValue; }
            else
            {
                temp = t;
                error = false;
            }
        }
        public override void paintAt(int x, int y)
        {
            this.x = x;this.y = y;
            doPaint();
        }
        public override void doPaint()
        {
            Bitmap btmBack = new Bitmap(348, 235);
            Graphics grBack = Graphics.FromImage(btmBack);
            panel.BackgroundImage = btmBack;
            Color c;
            if (temp > 0)
            {
                if (error) c = Color.FromArgb(0, 0, 0);
                else
                    c = Color.FromArgb(5 * (int)temp, 0, 0);
            }
            else
            {
                if (error) c = Color.FromArgb(0, 0, 0);
                else
                    c = Color.FromArgb(0, 0, 5 * (int)-temp);
            }
            grBack.FillEllipse(new SolidBrush(c),x, y, 80*size, 80*size);
            if(!error)grBack.DrawString(this.getTemp() + "°C", new Font(FontFamily.GenericMonospace, 15*size), Brushes.Blue, x + 90*size, y+10*size);
            else
                grBack.DrawString("ERROR", new Font(FontFamily.GenericMonospace, 15 * size), Brushes.Blue, x + 90*size, y+10*size);
            panel.Refresh();
            Thread.Sleep(50);
        }
    }
    public class temp2 : temperatureIndicator   //3 - text
    {
        Panel panel;
        Graphics grBack;
        public temp2(Panel p, Graphics c) { panel = p; grBack = c; }
        public override void setTemp(float t)
        {
            if (t > 50 || t < -50)
            { error = true; throw wrongValue; }
            else
            {
                temp = t;
                error = false;
            }
        }

        public override void paintAt(int x, int y)
        {
            this.x = x; this.y = y;
            doPaint();
        }
        public override void doPaint()
        {
            Bitmap btmBack = new Bitmap(348, 235);
            Graphics grBack = Graphics.FromImage(btmBack);
            panel.BackgroundImage = btmBack;
            Color c;
            if (temp > 0)
            {
                if (error) c = Color.FromArgb(0, 0, 0);
                else
                    c = Color.FromArgb(5 * (int)temp, 0, 0);
            }
            else
            {
                if (error) c = Color.FromArgb(0, 0, 255);
                else
                    c = Color.FromArgb(0, 0, 5 * (int)-temp);
            }
            grBack.DrawRectangle(Pens.Brown, x, y, 100 * size, 25 * size);
            if(!error)grBack.DrawString("T1 = " + this.getTemp() + " °C", new Font(FontFamily.GenericSansSerif, 13 * size), new SolidBrush(c), x + 2, y + 3);
            else
                grBack.DrawString("ERROR", new Font(FontFamily.GenericSansSerif, 13), new SolidBrush(c), x+2, y+3);
            panel.Refresh();
            Thread.Sleep(50);
        }
    }
    public class temp3 : temperatureIndicator   //2type
    {
        Graphics grBack;
        bool overload = false;//not more than 45
        Panel panel;
        public temp3(Panel p, Graphics c) { panel = p; grBack = c; }
        public override void setTemp(float t)
        {
            if (t > 45 || t < 0) { error = true; if (t > 45) overload = true; throw wrongValue; }
            else
            {
                temp = t;
                error = false;
                overload = false;
            }
        }
        public override void paintAt(int x, int y)
        {
            this.x = x; this.y = y;
            doPaint();
        }
        public override void doPaint()
        {
            Bitmap btmBack = new Bitmap(348, 235);
            Graphics grBack = Graphics.FromImage(btmBack);
            Color c = Color.Black;
            if (overload) c = Color.FromArgb(255, 0, 0);
            else if(error) c = Color.Black;
            else
                c = Color.FromArgb(5 * (int)temp, 0, 0);
            panel.BackgroundImage = btmBack;
            grBack.DrawRectangle(Pens.Black, x, y, 50 * size, 200 * size);
            if(overload) grBack.FillRectangle(new SolidBrush(c), x + 40, y + 180 - 45 * 4, 5 * size, 45 * 4 * size);
            else
                grBack.FillRectangle(new SolidBrush(c), x+40, y+180 - getTemp() * 4, 5 * size, getTemp() * 4 * size);
            if(!error)grBack.DrawString(this.getTemp() + "C", new Font(FontFamily.GenericSansSerif, 12), Brushes.Black, x+60, y+20);
            else
                grBack.DrawString("ERROR", new Font(FontFamily.GenericSansSerif, 12), Brushes.Black, x + 60, y + 20);
            grBack.DrawLine(Pens.Black, x+40, y+10, (x+40) * size, (y+180) * size);
            grBack.DrawLine(Pens.Black, x+30, y+180, (x+50) * size, (y+180) * size);
            grBack.DrawString("0", new Font(FontFamily.GenericSansSerif, 11), Brushes.Black, x+20, y+180);
            grBack.DrawLine(Pens.Black, x+30, y+140, (x+50) * size, (y+140) * size);
            grBack.DrawString("10", new Font(FontFamily.GenericSansSerif, 11), Brushes.Black, x+15, y+140);
            grBack.DrawLine(Pens.Black, x+30, y+100, (x+50) * size, (y+100) * size);
            grBack.DrawString("20", new Font(FontFamily.GenericSansSerif, 11), Brushes.Black, x+15, y+100);
            grBack.DrawLine(Pens.Black, x+30, y+60, (x+50) * size, (y+60) * size);
            grBack.DrawString("30", new Font(FontFamily.GenericSansSerif, 11), Brushes.Black, x+15, y+60);
            grBack.DrawLine(Pens.Black, x+30, y+20, (x+50) * size, (y+20) * size);
            grBack.DrawString("40", new Font(FontFamily.GenericSansSerif, 11), Brushes.Black, x+15, y+20);
            panel.Refresh();
            Thread.Sleep(50);
        }
    }
}