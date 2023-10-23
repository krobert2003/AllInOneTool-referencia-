using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AllInOneTool_referencia_
{
    public partial class ToDoList : Form
    {
        private string filePath = "todolist.csv";

        public ToDoList()
        {
            InitializeComponent();
        }
        DataTable todolist = new DataTable();
        bool edited = false;

        private void SaveData()
        {
            StringBuilder sb = new StringBuilder();

            IEnumerable<string> columnNames = todolist.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in todolist.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                sb.AppendLine(string.Join(",", fields));
            }

            File.WriteAllText(filePath, sb.ToString());
        }
        private void LoadData()
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length > 0)
                {
                    string[] header = lines[0].Split(',');
                    todolist = new DataTable();

                    foreach (string columnName in header)
                    {
                        todolist.Columns.Add(columnName);
                    }

                    for (int i = 1; i < lines.Length; i++)
                    {
                        string[] fields = lines[i].Split(',');
                        todolist.Rows.Add(fields);
                    }

                    DataList.DataSource = todolist;
                }
            }
        }
        private void ToDoList_Load(object sender, EventArgs e)
        {
            todolist.Columns.Add("Cím");
            todolist.Columns.Add("Tárgy");
            DataList.DataSource = todolist;
            LoadData();
        }
      
        
        private void DataList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            if (todolist != null && DataList != null && DataList.CurrentCell != null && todolist.Rows.Count > 0 && DataList.CurrentCell.RowIndex < todolist.Rows.Count)
            {
                edited = true;
                todolist.Rows[DataList.CurrentCell.RowIndex]["Cím"] = title.Text;
                todolist.Rows[DataList.CurrentCell.RowIndex]["Tárgy"] = description.Text;
            }
            else
            {
                MessageBox.Show("Nem található a szerkeszthető sor.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SaveData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (todolist != null && DataList != null && DataList.CurrentCell != null && todolist.Rows.Count > 0 && DataList.CurrentCell.RowIndex < todolist.Rows.Count)
                {
                    todolist.Rows[DataList.CurrentCell.RowIndex].Delete();
                }
                else
                {
                   MessageBox.Show("Nem lehetséges a törlés", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Nem lehetséges a törlés: " + ex);
                
            }
            SaveData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(title.Text) || String.IsNullOrEmpty(description.Text))
            {
                MessageBox.Show("A cím vagy a leírás mező üres ", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

           
            if (edited && DataList.CurrentCell != null && DataList.CurrentCell.RowIndex < todolist.Rows.Count)
            {
                todolist.Rows[DataList.CurrentCell.RowIndex]["Cím"] = title.Text;
                todolist.Rows[DataList.CurrentCell.RowIndex]["Tárgy"] = description.Text;
                edited = false;
            }
            else
            {
                todolist.Rows.Add(title.Text, description.Text);
            }
            title.Text = "";
            description.Text = "";
            }
            SaveData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        AllInOneTool form1 = new AllInOneTool();
            form1.ShowDialog();
            this.Close();
        }
    }
}
