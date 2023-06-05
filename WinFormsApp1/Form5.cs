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
using static System.Windows.Forms.LinkLabel;
using static WinFormsApp1.Class1;

namespace WinFormsApp1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            
            string newline;
            System.IO.StreamReader file = new System.IO.StreamReader("Data/darbuotojai.txt");
            string[] columnnames = file.ReadLine().Split(' ');
            while ((newline = file.ReadLine()) != null)
            {
                string[] values = newline.Split(' ');
                checkedListBox1.Items.Add(values[0]);

            }
            file.Close();
            System.IO.StreamReader file1 = new System.IO.StreamReader("Data/lokacijos.txt");
            string[] columnnames1 = file1.ReadLine().Split(' ');
            while ((newline = file1.ReadLine()) != null)
            {
                string[] values1 = newline.Split(' ');
                checkedListBox2.Items.Add(values1[0]);
            }
            file1.Close();          
        }

       

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
         
            if (checkedListBox1.CheckedItems.Count > 0)
            {
                string fileName = "Data/darbuotojai.txt";
                List<string> list1 = new List<string>();
                for (int k = 0; k <= checkedListBox1.CheckedItems.Count - 1; k++)
                {
                 

                    list1.Add(checkedListBox1.CheckedItems[k].ToString());
                    }
     
                TextLineRemover.OnRemovedLine += (o, removedLineArgs) => Console.WriteLine(string.Format("Removed \"{0}\" at line {1}", removedLineArgs.RemovedLine, removedLineArgs.RemovedLineNumber));
                TextLineRemover.OnFinished += (o, finishedArgs) => Console.WriteLine(string.Format("{0} of {1} lines removed. Time used: {2}", finishedArgs.LinesRemoved, finishedArgs.TotalLines, finishedArgs.TotalTime.ToString()));
                TextLineRemover.RemoveTextLines(list1, fileName, fileName + ".tmp");
                MessageBox.Show("Darbuotojai sekmingai ištrynti", "Pranešimas");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fileName1 = "Data/lokacijos.txt";
            List<string> list2 = new List<string>();
            if (checkedListBox2.CheckedItems.Count > 0)
            {
                for (int k = 0; k <= checkedListBox2.CheckedItems.Count - 1; k++)
                {
              

                    list2.Add(checkedListBox2.CheckedItems[k].ToString());
                }
       
                TextLineRemover.OnRemovedLine += (o, removedLineArgs) => Console.WriteLine(string.Format("Removed \"{0}\" at line {1}", removedLineArgs.RemovedLine, removedLineArgs.RemovedLineNumber));
                TextLineRemover.OnFinished += (o, finishedArgs) => Console.WriteLine(string.Format("{0} of {1} lines removed. Time used: {2}", finishedArgs.LinesRemoved, finishedArgs.TotalLines, finishedArgs.TotalTime.ToString()));
                TextLineRemover.RemoveTextLines(list2, fileName1, fileName1 + ".tmp");
                MessageBox.Show("Lokacijos sekmingai ištryntos", "Pranešimas");
            }
      
        }
    }
}
