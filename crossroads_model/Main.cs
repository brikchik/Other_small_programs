using System;
using System.Threading;
using System.Windows.Forms;
namespace Crossroads_model
{
    public partial class MainForm : Form
    {
        crossroads cr;
        public MainForm()
        {
            InitializeComponent();
            cr = new crossroads(screen);
            cr.project = false;
            Thread t = new Thread(imitation);
            t.Start();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //standard mode:
            int[] p1 = { 1, 2, 3, 2 };
            int[] p2 = { 3, 2, 1, 2 };
            int[] pedpr = { 1, 1, 2, 2 };
            int[] pedpr2 = { 2, 2, 1, 1};
            cr.mas[0].setProgram(p2);
            cr.mas[1].setProgram(p1);
            cr.mas[2].setProgram(p1);
            cr.mas[3].setProgram(p2);
            cr.mas[4].setProgram(pedpr2);
            cr.mas[5].setProgram(pedpr);
            cr.mas[6].setProgram(pedpr);
            cr.mas[7].setProgram(pedpr2);
            cr.mas[8].setProgram(pedpr2);
            cr.mas[9].setProgram(pedpr);
            cr.mas[10].setProgram(pedpr);
            cr.mas[11].setProgram(pedpr2);
            repaint();
        }
        private void repaint()
        {
            cr.refresh();
            pictureBox1.Image = cr.getLight(0).pic;
            pictureBox2.Image = cr.getLight(1).pic;
            pictureBox3.Image = cr.getLight(2).pic;
            pictureBox4.Image = cr.getLight(3).pic;
            pictureBox8.Image = cr.getLight(4).pic;
            pictureBox12.Image = cr.getLight(5).pic;
            pictureBox11.Image = cr.getLight(6).pic;
            pictureBox5.Image = cr.getLight(7).pic;
            pictureBox7.Image = cr.getLight(8).pic;
            pictureBox9.Image = cr.getLight(9).pic;
            pictureBox10.Image = cr.getLight(10).pic;
            pictureBox6.Image = cr.getLight(11).pic;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form roadlights = new Roadlights(cr.getLight(0), 1);
            roadlights.ShowDialog();
            roadlights.Dispose();
            repaint();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form roadlights = new Roadlights(cr.getLight(1), 2);
            roadlights.ShowDialog();
            roadlights.Dispose();
            repaint();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form roadlights = new Roadlights(cr.getLight(2),3);
            roadlights.ShowDialog();
            roadlights.Dispose();
            repaint();
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form roadlights = new Roadlights(cr.getLight(3),4);
            roadlights.ShowDialog();
            roadlights.Dispose();
            repaint();
        }
        private void pictureBox1_DoubleClick(object sender, EventArgs e){}
        //cycle
        private void imitation() {
            while (true)
            {
                if(cr.project)button2_Click(new object(), new EventArgs());
                cr.c1.next(cr);
                cr.c2.next(cr);
                cr.c3.next(cr);
                cr.c4.next(cr);
                Thread.Sleep(1000);
            }
        }
        //
        private void button1_Click(object sender, EventArgs e)
        {
            if (cr.project) cr.project = false; else cr.project = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            for(int i=0;i<12;i++) cr.getLight(i).nextState();
            cr.refresh();
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Form roadlights = new Roadlights(cr.getLight(4), 4);
            roadlights.ShowDialog();
            roadlights.Dispose();
            repaint();
        }
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Form roadlights = new Roadlights(cr.getLight(5), 5);
            roadlights.ShowDialog();
            roadlights.Dispose();
            repaint();
        }
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Form roadlights = new Roadlights(cr.getLight(6), 6);
            roadlights.ShowDialog();
            roadlights.Dispose();
            repaint();
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form roadlights = new Roadlights(cr.getLight(7), 7);
            roadlights.ShowDialog();
            roadlights.Dispose();
            repaint();
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form roadlights = new Roadlights(cr.getLight(8), 8);
            roadlights.ShowDialog();
            roadlights.Dispose();
            repaint();
        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Form roadlights = new Roadlights(cr.getLight(9), 9);
            roadlights.ShowDialog();
            roadlights.Dispose();
            repaint();
        }
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Form roadlights = new Roadlights(cr.getLight(10), 10);
            roadlights.ShowDialog();
            roadlights.Dispose();
            repaint();
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form roadlights = new Roadlights(cr.getLight(11), 11);
            roadlights.ShowDialog();
            roadlights.Dispose();
            repaint();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            roadlight rl = new arrowed_roadlight();
            pictureBox13.Image = rl.pic;
        }

        private void screen_Paint(object sender, PaintEventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            cr.carsN = (int)numericUpDown1.Value;
        }
    }
    
}