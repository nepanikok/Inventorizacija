using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private int numberOfItemsPerPage = 0;
        private int numberOfItemsPrintedSoFar = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {


            dataGridView8.Rows.Clear();
             System.IO.StreamReader file = new System.IO.StreamReader("Data/daiktai.txt");
             string[] columnnames = file.ReadLine().Split(' ');
             string newline;
            int l = 0;
             string lik = "null";

                 while ((newline = file.ReadLine()) != null)
             {
                 string[] values = newline.Split(' ');  
                     if (checkedListBox1.CheckedItems.Count > 0)
                     {
                     for (int k = 0; k <= checkedListBox1.CheckedItems.Count - 1; k++)
                         {           
                             if (checkedListBox1.CheckedItems[k].ToString() == values[2])
                             {
                             lik = values[0];
                             dataGridView8.Rows.Add(values[1], "1", values[2], values[3], values[4], values[5]);
                         }
                         }
                 }

                 if (checkedListBox2.CheckedItems.Count > 0)
                 {
                     for (int m = 0; m <= checkedListBox2.CheckedItems.Count - 1; m++)
                     {
                         if (checkedListBox2.CheckedItems[m].ToString() == values[3] && lik != values[0])
                         {
                            l++;
                             dataGridView8.Rows.Add(values[1], l, values[2], values[3], values[4], values[5]);
                         }
                     }
                 }
             }

             file.Close();



            //*********************GRazinti************************
                  var q = dataGridView8.Rows.OfType<DataGridViewRow>()
               .GroupBy(x => x.Cells[0].Value.ToString() + "/" + x.Cells[2].Value.ToString() + "/" + x.Cells[3].Value.ToString())
               .Select(g => new { Value = g.Key, Count = g.Count(), Rows = g.ToList()})
               .OrderByDescending(x => x.Count);




               foreach (var item in q)
               {
                   List<string> list = new List<string>();
                   string words = string.Format(item.Value);
                   string[] words1 = words.Split('/');
                   int i = 0;
                   foreach (var word in words1)
                   {
                       list.Add(word);
                   }
                   int rowIndex = -1;
                   foreach (DataGridViewRow row in dataGridView8.Rows)
                   {
                       if (row.Cells[0].Value.ToString().Equals(list[0]) && row.Cells[2].Value.ToString().Equals(list[1]) && row.Cells[3].Value.ToString().Equals(list[2]))
                       {
                           rowIndex = row.Index;
                           dataGridView8.Rows[rowIndex].Cells[1].Value = item.Count;
                           break;
                       }
                   }
               }

   


           if (dataGridView8.Rows.Count > 0)
            {
                for (int i = dataGridView8.Rows.Count - 1; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        break;
                    }
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (dataGridView8.Rows[i].Cells[0].Value.ToString() == dataGridView8.Rows[j].Cells[0].Value.ToString() && dataGridView8.Rows[i].Cells[2].Value.ToString() == dataGridView8.Rows[j].Cells[2].Value.ToString() && dataGridView8.Rows[i].Cells[3].Value.ToString() == dataGridView8.Rows[j].Cells[3].Value.ToString())
                        {
                            dataGridView8.Rows.Remove(dataGridView8.Rows[i]);
                            break;
                        }
                    }
                }              
            }
       
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
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
            string[] columnnameso = file1.ReadLine().Split(' ');
            while ((newline = file1.ReadLine()) != null)
            {
                string[] values1 = newline.Split(' ');
                checkedListBox2.Items.Add(values1[0]);

            }
            file1.Close();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            checkedListBox2.Items.Clear();
            dataGridView8.Rows.Clear();
            Form1_Load(sender, e);
        }

       
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int g = 0;
            e.HasMorePages = false;
        string curdhead = "Inventorizacijos lapas";
            e.Graphics.DrawString(curdhead, new System.Drawing.Font("Times New Roman", 13, FontStyle.Bold), Brushes.Black, 350, 50);

            string l1 = "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            e.Graphics.DrawString(l1, new System.Drawing.Font("Times New Roman", 13, FontStyle.Bold), Brushes.Black, 0, 100);

            string g1 = "Daikto pavadinimas ";
            e.Graphics.DrawString(g1, new System.Drawing.Font("Times New Roman", 13, FontStyle.Bold), Brushes.Black, 80, 140);

            string g2 = "Kiekis";
            e.Graphics.DrawString(g2, new System.Drawing.Font("Times New Roman", 13, FontStyle.Bold), Brushes.Black, 350, 140);

            string g3 = "Darbuotojas";
            e.Graphics.DrawString(g3, new System.Drawing.Font("Times New Roman", 13, FontStyle.Bold), Brushes.Black, 500, 140);          
           
            string l2 = "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            e.Graphics.DrawString(l2, new System.Drawing.Font("Times New Roman", 13, FontStyle.Bold), Brushes.Black, 0, 160);

            int height = 165;           
            for (int l = numberOfItemsPrintedSoFar; l < dataGridView8.Rows.Count; l++)
            {
                numberOfItemsPrintedSoFar++;
          
                if (numberOfItemsPerPage <= 30)
                {
                    numberOfItemsPerPage++;
                
                    if (numberOfItemsPrintedSoFar <= dataGridView8.Rows.Count)
                    {

                        height += dataGridView8.Rows[0].Height;
                        string z1 = dataGridView8.Rows[l].Cells[0].FormattedValue.ToString();
                        e.Graphics.DrawString(z1, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 80, height);
                        string z2 = dataGridView8.Rows[l].Cells[1].FormattedValue.ToString();
                        e.Graphics.DrawString(z2, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 350, height);
                        string z3 = dataGridView8.Rows[l].Cells[2].FormattedValue.ToString();
                        e.Graphics.DrawString(z3, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 500, height);                      
                    }
                    else
                    {
                        numberOfItemsPerPage = 0;
                        e.HasMorePages = false;
                    }
                }

                else if(numberOfItemsPerPage >= 30)
                {
                    numberOfItemsPerPage = 0;
                    e.HasMorePages = true;
                    //string l1 = "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
                    e.Graphics.DrawString(l1, new System.Drawing.Font("Times New Roman", 13, FontStyle.Bold), Brushes.Black, 0, 100);
       
                    return;
                  
                }
              

            }
            numberOfItemsPerPage = 0;
            numberOfItemsPrintedSoFar = 0;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.PrintDialog PrintDialog1 = new PrintDialog();
            PrintDialog1.AllowSomePages = true;
            PrintDialog1.ShowHelp = true;
            PrintDialog1.Document = printDocument1;
            DialogResult result = PrintDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
           printPreviewDialog1.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
           System.Windows.Forms.Application.ExitThread();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
         
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
 
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

  

        }
        private void dataGridView8_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView8.SelectedRows.Count > 0) 
            {
                int row = e.RowIndex;
                string pav = dataGridView8.SelectedRows[0].Cells[0].Value + string.Empty;
             
                Form6 f6 = new Form6(pav);
                f6.Show();
            }

        }
    }
}