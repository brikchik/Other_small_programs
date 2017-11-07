using System;
using System.Windows.Forms;

namespace Stack_based_class
{
    public partial class Main : Form
    {
        MessageStack a = new MessageStack(1);
        MessageStack b = new MessageStack(1);
        MessageStack current;
        Message currM;
        public Main()
        {
            InitializeComponent();
            listBox1.Items.Add("Stack 1");
            listBox1.Items.Add("Stack 2");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            current = a;
            currM = current.peek();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = ""+currM.getNumber();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "" + currM.getDate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "" + currM.getMessage();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "" + currM.getFullMessage();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currM.setDate(dateTimePicker1.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value < 0) richTextBox1.Text = "Number has to be natural!";else
            currM.setNumber((uint)numericUpDown1.Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currM.setMessage(textBox1.Text);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0) current = a; else current = b;
            if(!current.isEmpty())currM = current.peek();else richTextBox1.Text = "Can not be opened";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if(!(a & b))richTextBox1.Text="error while copying 2 -> 1";
            current = a;
            currM = current.peek();
            listBox1.SelectedIndex = 0;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Message x = new Stack_based_class.Message();
            current.push(x);
            currM = current.peek();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!(current.getSize()==1)) { current.pop(); currM = current.peek(); }
            else { richTextBox1.Text = "Empty!"; };
        }
    }
}
