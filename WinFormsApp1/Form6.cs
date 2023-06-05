using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WinFormsApp1.Class1;

namespace WinFormsApp1
{
    
    public partial class Form6 : Form
    {
        private string p;
        private string id;
        private string pav;
        private string darb;       
        private string lok;
        private string kain;
        private string dat5;
        public Form6(string qs)
        {
            InitializeComponent();
          
            p = qs;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            
            string newline1;
            System.IO.StreamReader file1 = new System.IO.StreamReader("Data/darbuotojai.txt");
            string[] columnnames1 = file1.ReadLine().Split(' ');
            while ((newline1 = file1.ReadLine()) != null)
            {
                string[] values = newline1.Split(' ');
                comboBox1.Items.Add(values[0]);

            }
            file1.Close();
            System.IO.StreamReader file2 = new System.IO.StreamReader("Data/lokacijos.txt");
            string[] columnnames2 = file2.ReadLine().Split(' ');
            while ((newline1 = file2.ReadLine()) != null)
            {
                string[] values1 = newline1.Split(' ');
                comboBox2.Items.Add(values1[0]);

            }
            file2.Close();
            dataGridView1.Rows.Clear();
            System.IO.StreamReader file = new System.IO.StreamReader("Data/daiktai.txt");
            string[] columnnames = file.ReadLine().Split(' ');
            string newline;
            int l = 0;
            string lik = "null";

            while ((newline = file.ReadLine()) != null)
            {
                string[] values = newline.Split(' ');
               
                  
                        if (p == values[1])
                        {
                            lik = values[0];
                            dataGridView1.Rows.Add(values[0], values[1], values[2], values[3], values[4], values[5]);
                        }
                    
                
            }

            file.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
       
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) 
            {
                int row = e.RowIndex;
                id = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
                pav = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                darb = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
                lok = dataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
                kain = dataGridView1.SelectedRows[0].Cells[4].Value + string.Empty;
                dat5 = dataGridView1.SelectedRows[0].Cells[5].Value + string.Empty;

                label7.Text = id;
                textBox1.Text = pav;
                label9.Text = dat5;
                comboBox1.Text = darb; 
                comboBox2.Text = lok;
                label8.Text = kain;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((Convert.ToInt32(label7.Text) > 0))
            {
                string fileName = "Data/daiktai.txt";
                List<string> list1 = new List<string>();
                
           

                    list1.Add(label7.Text + " " + textBox1.Text + " " + comboBox1.Text + " " + comboBox2.Text + " " + label8.Text + " " + label9.Text);
                
                TextLineRemover.OnRemovedLine += (o, removedLineArgs) => Console.WriteLine(string.Format("Removed \"{0}\" at line {1}", removedLineArgs.RemovedLine, removedLineArgs.RemovedLineNumber));
                TextLineRemover.OnFinished += (o, finishedArgs) => Console.WriteLine(string.Format("{0} of {1} lines removed. Time used: {2}", finishedArgs.LinesRemoved, finishedArgs.TotalLines, finishedArgs.TotalTime.ToString()));
                TextLineRemover.RemoveTextLines(list1, fileName, fileName + ".tmp");
                MessageBox.Show("Daiktas sekmingai ištryntas", "Pranešimas");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string text = File.ReadAllText("Data/daiktai.txt");
            text = text.Replace(id + " " + pav +" " + darb + " " + lok + " " + kain + " " + dat5, label7.Text + " " + textBox1.Text + " " + comboBox1.Text + " " + comboBox2.Text + " " + label8.Text + " " + label9.Text);
            File.WriteAllText("Data/daiktai.txt", text);
            MessageBox.Show("Daiktas sekmingai atnaujintas", "Pranešimas");
        }
    }
}
