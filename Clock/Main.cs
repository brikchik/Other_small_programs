using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System;
namespace Clock
{
    public partial class Main : Form
    {
        Indicators mas, mas2,active;
        public static Panel p;
        public static Graphics g;
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
            active.mas[(int)numericUpDown2.Value] = new time1(active.p, active.g);
            button5_Click(new object(), new EventArgs());
            listBox1.SelectedIndex = (int)numericUpDown2.Value;
            button9_Click(new object(), new EventArgs());
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDown2.Value = listBox1.SelectedIndex;
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            active.mas[(int)numericUpDown2.Value] = new time1(active.p, active.g);
            button5_Click(new object(), new EventArgs());
            listBox1.SelectedIndex = (int)numericUpDown2.Value;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            active.mas[(int)numericUpDown2.Value] = new time3(active.p, active.g);
            button5_Click(new object(), new EventArgs());
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            active.mas[(int)numericUpDown2.Value] = new time2(active.p, active.g);
            button5_Click(new object(), new EventArgs());
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try { active.mas[(int)numericUpDown2.Value].name = textBox2.Text; } catch (NullReferenceException) { active.mas[(int)numericUpDown2.Value] = new time3(p, g); }
            active.mas[(int)numericUpDown2.Value].name = textBox2.Text;
            button5_Click(new object(), new EventArgs());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try{active.mas[(int)numericUpDown2.Value].setSize((float)numericUpDown4.Value); } catch (NullReferenceException) { active.mas[(int)numericUpDown2.Value] = new time3(p, g); }
            active.mas[(int)numericUpDown2.Value].setSize((float)numericUpDown4.Value);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            { active[(int)numericUpDown2.Value].paintAt((int)numericUpDown5.Value, (int)numericUpDown6.Value); }
            catch (Exception) { active.mas[(int)numericUpDown2.Value] = new time3(p, g); listBox1.Items.Add("type 3 indicator created automatically"); }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (active == mas2) mas.copy(mas2); else mas2.copy(mas);
            button5_Click(new object(), new EventArgs());
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            active = mas;
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            active = mas2;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
        }

        private void button11_Click_2(object sender, EventArgs e)
        {
            try
            {
                active.mas[(int)numericUpDown2.Value].setTime(dateTimePicker1.Value.Hour*3600+ dateTimePicker1.Value.Minute *60+ dateTimePicker1.Value.Second);
            }
            catch (NullReferenceException)
            {
                active.mas[(int)numericUpDown2.Value] = new time3(p, g);
            }
            button5_Click(new object(), new EventArgs());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            active.mas[(int)numericUpDown2.Value].setHour((int)numericUpDown3.Value);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            active.mas[(int)numericUpDown2.Value].setMin((int)numericUpDown7.Value);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            active.mas[(int)numericUpDown2.Value].setSec((int)numericUpDown8.Value);
        }

        private void button11_Click(object sender, EventArgs e)
        {
        }
        private void button5_Click(object sender, EventArgs e)
        {
            int k = listBox1.SelectedIndex;
            listBox1.Items.Clear();
            foreach (timeIndicator elem in active.mas)
            {
                try
                {
                    listBox1.Items.Add(Array.IndexOf(active.mas, elem) + ": " + elem.name + '_' + elem.getTime() + '_' + elem.getSize());
                }
                catch (NullReferenceException) { listBox1.Items.Add("Not initialised"); }
            }
            if(listBox1.Items.Count!=0)listBox1.SelectedIndex = k;
        }
    }
    public class Indicators
    {
        public Graphics g;
        public Panel p;
        private Exception WrongTypeException=new Exception("Indicator type doesn't exist");
        public timeIndicator[] mas=new timeIndicator[3];
        public Indicators(Graphics gr, Panel panel) { g = gr; p = panel; mas.Initialize(); }
        public timeIndicator this[int i]
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
    public abstract class timeIndicator
    {
        protected bool error = false;
        protected float size = 1;
        protected int x = 0, y = 0;//coords
        public string name = "DefaultName";
        protected Exception wrongValue = new Exception("Time does not exist");
        public abstract void setTime(int t);
        public void setTime(DateTime t){setHour(t.Hour);setMin(t.Minute);setSec(t.Second);}
        protected int time = 0;
        public int getHours() { return time / 3600; }
        public int getMins() { return (time % 3600) / 60; }
        public int getSecs() { return time % 60; }
        public virtual void setHour(int h) { if (h >= 0 && h < 24) { time = time % 3600 + 3600 * h; } else throw wrongValue; }
        public void setMin(int m) { if (m >= 0 && m < 60) { time = time / 3600 * 3600 + time % 60 + m * 60; } else throw wrongValue; }
        public void setSec(int s) { if (s >= 0 && s < 60) { time = time / 60 * 60 + s; } else throw wrongValue; }
        public String getTime() { return "" + getHours() + ':' + getMins() + ':' + getSecs(); }
        public long getFullTime() { return time; }
        public void setSize(float a) { size = a; }
        public float getSize() { return size; }
        public static Bitmap btmBack = new Bitmap(576, 208);
        public static Graphics g = Graphics.FromImage(btmBack);
        public abstract void doPaint();
        public String this[int k] { get { return getTime(); } set { } } //overload instead of []. get-> any number in []
        public bool hasError() { return error; }
        public abstract void paintAt(int x, int y);
        public static bool operator <(timeIndicator t1, timeIndicator t2) { return t1.getFullTime() < t2.getFullTime(); }
        public static bool operator >(timeIndicator t1, timeIndicator t2) { return t1.getFullTime() > t2.getFullTime(); }
        public static long operator -(timeIndicator t1, timeIndicator t2) { return Math.Abs(t1.getFullTime() - t2.getFullTime()); }
        //time difference
    }
    public class time1 : timeIndicator   //1 - circle
    {
        Panel panel;
        public time1(Panel p, Graphics c) { panel = p;}
        public override void setTime(int t)
        {
            if (t<0 || t>=3600*24) { error = true; throw wrongValue; } //12 hours
            else
            {
                if (t >= 3600 * 12) t -= 3600 * 12;
                time = t;
                error = false;
            }
        }
        public override void setHour(int h) { time = time % 3600 + 3600 * (h%12); }
        public override void paintAt(int x, int y)
        {
            this.x = x;this.y = y;
            doPaint();
        }
        public override void doPaint()
        {
            Graphics grBack = Graphics.FromImage(btmBack);
            panel.BackgroundImage = btmBack;
            Color c= Color.FromArgb(0, 0, 0);
            float center = 80*size;
            double angle = Math.PI;
            grBack.FillEllipse(Brushes.White, x, y, 78 * size * 2, 78 * size * 2);
            grBack.DrawEllipse(new Pen(c,3),x, y, center*2, center*2);
            for(int i=0;i<12;i++)
            {
                Point a = new Point((int)(x + center + (center - 20 * size) * Math.Sin(angle)), y + (int)(center + (center - 20 * size) * Math.Cos(angle)));
                Point b = new Point((int)(x + center + center * Math.Sin(angle)), (int)(y + center + center * Math.Cos(angle)));
                grBack.DrawLine(Pens.Black, a, b);
                a = new Point((int)(x + center + (center - 20 * size) * Math.Sin(angle)), y + (int)(center + (center - 20 * size) * Math.Cos(angle)));
                a.X -= 7*(int)size;
                a.Y -= 7*(int)size;
                if (i==0) grBack.DrawString("" + 12, new Font(FontFamily.GenericSansSerif, 12 * size), Brushes.Black, a);else
                grBack.DrawString("" + i, new Font(FontFamily.GenericSansSerif, 12*size),Brushes.Black, a);
                angle -= Math.PI / 6;
            }
            Point k = new Point((int)(x + center + (center - 25 * size) * Math.Sin(Math.PI * (1 - 4* (double)getSecs() / 60))), y + (int)(center + (center - 25 * size) * Math.Cos(Math.PI * (1 - 4 * (double)getSecs() / 60))));
            Point l = new Point((int)(x + center), (int)(y + center));
            grBack.DrawLine(Pens.Red, k, l);
            k = new Point((int)(x + center + (center - 45 * size) * Math.Sin(Math.PI * (1 -  4*(double)getHours() / 60))), y + (int)(center + (center - 45 * size) * Math.Cos(Math.PI * (1 - 4 * (double)getHours() / 60))));
            grBack.DrawLine(Pens.Black, k, l);
            k = new Point((int)(x + center + (center - 35 * size) * Math.Sin(Math.PI * (1 -  4*(double)getMins() / 60))), y + (int)(center + (center - 35 * size) * Math.Cos(Math.PI * (1 - 4 * (double)getMins() / 60))));
            grBack.DrawLine(Pens.Brown, k, l);
            panel.Refresh();
            Thread.Sleep(50);
        }
    }
    
    public class time2 : timeIndicator 
    {
        Graphics grBack;
        Panel panel;
        public time2(Panel p, Graphics c) { panel = p; grBack = c; }
        public override void setTime(int t)
        {
            if (t < 0 || t >= 3600 * 24) { error = true; throw wrongValue; } //24 hours
            else
            {
                time = t;
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
            Graphics grBack = Graphics.FromImage(btmBack);
            panel.BackgroundImage = btmBack;
            Color c = Color.FromArgb(0, 0, 0);
            float center = 80 * size;
            double angle = Math.PI;
            grBack.FillEllipse(Brushes.White, x, y, 78 * size * 2, 78 * size * 2);
            grBack.DrawEllipse(new Pen(c, 3), x, y, center * 2, center * 2);
            for (int i = 0; i < 24; i++)
            {
                Point a = new Point((int)(x + center + (center - 20 * size) * Math.Sin(angle)), y + (int)(center + (center - 20 * size) * Math.Cos(angle)));
                Point b = new Point((int)(x + center + center * Math.Sin(angle)), (int)(y + center + center * Math.Cos(angle)));
                grBack.DrawLine(Pens.Black, a, b);
                a = new Point((int)(x + center + (center - 20 * size) * Math.Sin(angle)), y + (int)(center + (center - 20 * size) * Math.Cos(angle)));
                a.X -= 5*(int)size;
                a.Y -= 5*(int)size;
                if (i%2==0)
                {
                    if (i == 0) grBack.DrawString("24", new Font(FontFamily.GenericSansSerif, 9 * size), Brushes.Black, a);
                    else
                        grBack.DrawString("" + i, new Font(FontFamily.GenericSansSerif, 9 * size), Brushes.Black, a);
                }
                angle -= Math.PI / 12;
            }
            Point k = new Point((int)(x + center + (center - 25 * size) * Math.Sin(Math.PI * (1 - 2 * (double)getSecs() / 60))), y + (int)(center + (center - 25 * size) * Math.Cos(Math.PI * (1 - 2 * (double)getSecs() / 60))));
            Point l = new Point((int)(x + center), (int)(y + center));
            grBack.DrawLine(Pens.Red, k, l);
            k = new Point((int)(x + center + (center - 45 * size) * Math.Sin(Math.PI * (1 - 2 * (double)getHours() / 60))), y + (int)(center + (center - 45 * size) * Math.Cos(Math.PI * (1 - 2 * (double)getHours() / 60))));
            grBack.DrawLine(Pens.Black, k, l);
            k = new Point((int)(x + center + (center - 35 * size) * Math.Sin(Math.PI * (1 - 2 * (double)getMins() / 60))), y + (int)(center + (center - 35 * size) * Math.Cos(Math.PI * (1 - 2 * (double)getMins() / 60))));
            grBack.DrawLine(Pens.Brown, k, l);
            panel.Refresh();
            Thread.Sleep(50);
        }
    }
    public class time3 : timeIndicator 
    {
        Panel panel;
        Graphics grBack;
        public time3(Panel p, Graphics c) { panel = p; grBack = c; }
        public override void setTime(int t)
        {
            if (t < 0 || t >= 3600 * 24) { error = true; throw wrongValue; } //24 hours
            else
            {
                time = t;
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

            Graphics grBack = Graphics.FromImage(btmBack);
            panel.BackgroundImage = btmBack;
            Color c = Color.Black;
            grBack.FillRectangle(Brushes.White, x, y, 70 * size, 25 * size);
            grBack.DrawRectangle(Pens.Brown, x, y, 70 * size, 25 * size);
            if (!error) grBack.DrawString(""+getTime(), new Font(FontFamily.GenericSansSerif, 12 * size), new SolidBrush(c), x + 2, y + 3);
            else
                grBack.DrawString("ERROR", new Font(FontFamily.GenericSansSerif, 12*size), new SolidBrush(c), x + 2, y + 3);
            panel.Refresh();
            Thread.Sleep(50);
        }
    }
}