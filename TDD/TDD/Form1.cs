using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Threading;
namespace TDD
{
    public partial class Form1 : Form
    {
        private List<tdd> sensors = new List<tdd>();//массив датчиков
        private tdd press;//текущий датчик
        private float Mul = 1;//множитель для графика
        private float Mul2 = 1;//множитель для масштаба
        private bool sinus = true;//выбор типа сигнала на входе
        public Form1()
        {
            InitializeComponent();
            sensors.Add(new TDD.tdd());
            sensors.Add(new TDD.tdd());
            sensorList.Items.Add("Сенсор "+(sensorList.Items.Count+1));
            sensorList.Items.Add("Сенсор " + (sensorList.Items.Count+1));
            //2датчика для 1 задания
            sensorList.SelectedIndex = 0;
            press = sensors[0];
            sensorLabel.Text = "Работаем с датчиком " + sensorList.SelectedItem;
            do_paint();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        int y1(int k) { return 120 - k; }//переворачиваем
        int y2(int k) { return 250 - k; }//переворачиваем
        private void do_paint()
        {
            Bitmap btmBack = new Bitmap(348, 235);      //изображение
            Bitmap btmFront = new Bitmap(348, 235);     //фон
            Graphics grBack = Graphics.FromImage(btmBack);
            Graphics grFront = Graphics.FromImage(btmFront);  //лучше объявить заранее глобально.
            PictureBox1.Image = btmFront;
            PictureBox1.BackgroundImage = btmBack;
            grBack.DrawLine(Pens.Black, 5, 5, 5, 230);
            grBack.DrawLine(Pens.Black, 1, 10, 5, 5);
            grBack.DrawLine(Pens.Black, 10, 10, 5, 5);
            grBack.DrawLine(Pens.Black, 5, 150, 340, 150);
            grBack.DrawLine(Pens.Black, 335, 145, 340, 150);
            grBack.DrawLine(Pens.Black, 335, 155, 340, 150);
            grBack.DrawLine(Pens.Black, 5, 230, 340, 230);
            grBack.DrawLine(Pens.Black, 335, 225, 340, 230);
            grBack.DrawLine(Pens.Black, 335, 235, 340, 230);
            grBack.DrawLine(Pens.Black, 1, 160, 5, 150);
            grBack.DrawLine(Pens.Black, 10, 160, 5, 150);
            PictureBox1.Refresh();
            Point old_P = new Point(5, 200);
            Point old_I = new Point(5, 200);
            tdd temp = new tdd();
            temp.set_current(press.get_current());
            temp.set_units(press.units());
            for (int x = 5; x < 500; x++)
            {
                float current = (float)(Mul*Encode(x)+temp.get_current());
                temp.set_current(current);
                grBack.DrawLine(Pens.Chocolate, old_P, new Point(x, y1((int)(temp.get_pressure()*Mul2))));
                grBack.DrawLine(Pens.Red, old_I, new Point(x, y2((int)(temp.get_current()*Mul2))));
                old_P = new Point(x, y1((int)(temp.get_pressure()*Mul2)));
                old_I = new Point(x, y2((int)(temp.get_current()*Mul2)));
            }
            PictureBox1.Refresh();
        }
        private float Encode(int x)
        {
            Random r=new Random();
            if (sinus) return (float)Math.Sin(x);//0-1 число
            else
                return (float)r.NextDouble();//0-1, как и синус
        }
        private void currentButton_Click(object sender, EventArgs e)
        {
            if (!press.set_current(currentBox.Text)) Status_label.Text="Ошибка!";
            else Status_label.Text = "Ток успешно задан";
            trackBar.Value = (int)press.get_current();
            readValues();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            readValues();
        }
        public void readValues()
        {
            readList.Items[0] = "I = " + press.get_current() + " мА";
            readList.Items[1] = "P = " + press.get_full_pressure();
            readList.Items[2] = "Pmin =  " + press.get_full_min_pressure();
            readList.Items[3] = "Pmax =  " + press.get_full_max_pressure();
            
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            press.set_current(trackBar.Value);
            Status_label.Text = "Ток задан";
            readValues();
            do_paint();
        }

        private void unitsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            press.set_units((byte)unitsList.SelectedIndex);
            Status_label.Text = "Единицы измерения заданы";
            readValues();
            do_paint();
        }

        private void sensorList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(sensorList.SelectedIndex > sensorList.Items.Count - 1) && sensorList.SelectedIndex>=0)
            {
                press = sensors[sensorList.SelectedIndex];
                StatusLabel2.Text = "Работаем с датчиком " + sensorList.SelectedItem;
                trackBar.Value = (int)press.get_current();
                readValues();
                do_paint();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            sensors.Add(new TDD.tdd());
                sensorList.Items.Add("Сенсор " + (sensorList.Items.Count + 1));
            sensorList.SelectedIndex = sensorList.Items.Count-1;
            press = sensors[sensorList.SelectedIndex];
            StatusLabel2.Text = "Работаем с датчиком " + sensorList.SelectedItem;
            do_paint();
        }

        private void dropButton_Click(object sender, EventArgs e)
        {
            if (sensorList.Items.Count > 1)
            {
                int k = sensorList.SelectedIndex;
                sensors.RemoveAt(k);
                if (k != 0) press = sensors[k - 1]; else press = sensors[0];
                sensorList.Items.RemoveAt(k);
                sensorList.SelectedIndex = 0;
                do_paint();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (sensors[0] < sensors[1]) { label3.Text = "<"; press = sensors[1]; do_paint();}
            if (sensors[0] > sensors[1]) { label3.Text = ">"; press = sensors[0]; do_paint(); }
            if (sensors[0] == sensors[1]) label3.Text = "=";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0) sinus = true; else sinus = false;
            do_paint();
        }

        private void multButton_Click(object sender, EventArgs e)
        {
            try { Mul = float.Parse(mul.Text.Replace('.', ',')); } catch (Exception e1) { }
            do_paint();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try { Mul2 = float.Parse(mul.Text.Replace('.', ',')); } catch (Exception e1) { }
            do_paint();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            do_paint();
            PictureBox1.Invalidate();
        }
    }
}
