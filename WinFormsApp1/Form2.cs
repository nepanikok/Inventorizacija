using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id=0;
            int n=0, c = 0;
            string ids1, ns1;
            string newline;
            string check;
            ArrayList id1 = new ArrayList();
 
            System.IO.StreamReader file = new System.IO.StreamReader("Data/daiktai.txt");
            string[] columnnames = file.ReadLine().Split(' ');
            while ((newline = file.ReadLine()) != null)
            {
                string[] values = newline.Split(' ');        
                id1.Add(values[0]);
            }
            file.Close();
            if (id1.Count > 0) { id = Convert.ToInt32(id1[id1.Count - 1]) + 1; }
            else { id = 1; }
            n = Convert.ToInt32(numericUpDown1.Text);
            textBox1.Text = textBox1.Text.Replace(" ", "_");
            c = id;
            for (int k = 0; k < n; k++)
            {
                using (StreamWriter stream = new FileInfo("Data/daiktai.txt").AppendText())
                {
                    
                    ids1 = Convert.ToString(c);
                    ns1 = Convert.ToString(n);
                    stream.WriteLine(ids1 + " " + textBox1.Text + " " +
                        comboBox1.Text + " " + comboBox2.Text + " " +
                        numericUpDown2.Text + " " + dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                         c++;
                }
            }
            c = id;
  
            label7.Text = "*Ivedete Daikta pavdinimu: " + textBox1.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string newline;
            System.IO.StreamReader file = new System.IO.StreamReader("Data/darbuotojai.txt");
            string[] columnnames = file.ReadLine().Split(' ');
            while ((newline = file.ReadLine()) != null)
            {
                string[] values = newline.Split(' ');
                comboBox1.Items.Add(values[0]);

            }
            file.Close();
            System.IO.StreamReader file1 = new System.IO.StreamReader("Data/lokacijos.txt");
            string[] columnnames1 = file1.ReadLine().Split(' ');
            while ((newline = file1.ReadLine()) != null)
            {
                string[] values1 = newline.Split(' ');
                comboBox2.Items.Add(values1[0]);

            }
            file1.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
