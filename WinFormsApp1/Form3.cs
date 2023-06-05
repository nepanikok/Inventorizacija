using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Replace(" ", "");
            textBox2.Text = textBox2.Text.Replace(" ", "");
            using (StreamWriter stream = new FileInfo("Data/darbuotojai.txt").AppendText())
            {
                stream.WriteLine(textBox1.Text + "_" + textBox2.Text);
            }
            label3.Text = "*Ivedete darbuotoja: " + textBox1.Text + " " + textBox2.Text;
            textBox1.Clear();
            textBox2.Clear();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
