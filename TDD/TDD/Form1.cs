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
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void currentButton_Click(object sender, EventArgs e)
        {
            if (!press.set_current(currentBox.Text))successLabel.Text="Ошибка!";
            else successLabel.Text = "Ток успешно задан";
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
            successLabel.Text = "Ток задан";
            readValues();
        }

        private void unitsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            press.set_units((byte)unitsList.SelectedIndex);
            successLabel.Text = "Единицы измерения заданы";
            readValues();
        }

        private void sensorList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(sensorList.SelectedIndex > sensorList.Items.Count - 1) && sensorList.SelectedIndex>=0)
            {
                press = sensors[sensors.Count-1];
                sensorLabel.Text = "Работаем с датчиком " + sensorList.SelectedItem;
                readValues();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            sensors.Add(new TDD.tdd());
            int i = 1;
            while(sensorList.Items.Contains("Сенсор " + (sensorList.Items.Count - 1 + i)))
            {
                sensorList.Items.Add("Сенсор " + (sensorList.Items.Count + i));
                i++;
            }
            sensorList.SelectedIndex = sensorList.Items.Count-1;
            press = sensors[sensorList.SelectedIndex];
            sensorLabel.Text = "Работаем с датчиком " + sensorList.SelectedItem;
        }

        private void dropButton_Click(object sender, EventArgs e)
        {
            if (sensorList.Items.Count > 1)
            {
                int k = sensorList.SelectedIndex;
                sensors.RemoveAt(k);
                press = sensors[k-1];
                sensorList.Items.RemoveAt(k);
                sensorList.SelectedIndex = 0;
            }
        }
    }
}
