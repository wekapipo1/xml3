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

namespace xml3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Заповніть всі поля.", "Помилка.");
            }
            else
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = textBox2.Text;
                dataGridView1.Rows[n].Cells[2].Value = numericUpDown1.Value;
                dataGridView1.Rows[n].Cells[3].Value = comboBox1.Text;
                dataGridView1.Rows[n].Cells[4].Value = textBox3.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int n = dataGridView1.SelectedRows[0].Index;
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = textBox2.Text;
                dataGridView1.Rows[n].Cells[2].Value = numericUpDown1.Value;
                dataGridView1.Rows[n].Cells[3].Value = comboBox1.Text;
                dataGridView1.Rows[n].Cells[4].Value = textBox3.Text;
            }
            else
            {
                MessageBox.Show("Виберіть рядок для редагування.", "Помилка.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Виберіть рядок для видалення.", "Помилка.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            int n = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value);
            numericUpDown1.Value = n;
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.TableName = "Employee";
                dt.Columns.Add("Surname");
                dt.Columns.Add("Name");
                dt.Columns.Add("Age");
                dt.Columns.Add("Family");
                dt.Columns.Add("Mail");
                ds.Tables.Add(dt);
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    DataRow row = ds.Tables["Employee"].NewRow();
                    row["Surname"] = r.Cells[0].Value;
                    row["Name"] = r.Cells[1].Value;
                    row["Age"] = r.Cells[2].Value;
                    row["Family"] = r.Cells[3].Value;
                    row["Mail"] = r.Cells[4].Value;
                    ds.Tables["Employee"].Rows.Add(row);
                }
                ds.WriteXml("C:\\Users\\Анастасія\\OneDrive\\Рабочий стол\\people.xml");
                MessageBox.Show("XML файл успішно збережений.", "Виконано.");

            }
            catch
            {
                MessageBox.Show("Неможливо зберегти XML файл.", "Помилка.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
            }
            else
            {
                MessageBox.Show("Таблиця пуста.", "Помилка.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count < 0)
            {
                MessageBox.Show("Очистіть поле перед завантаженням нового файлу.", "Помилка.");
            }
            else
            {
                if (File.Exists("C:\\Users\\Анастасія\\OneDrive\\Рабочий стол\\people.xml"))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml("C:\\Users\\Анастасія\\OneDrive\\Рабочий стол\\people.xml");

                    foreach (DataRow item in ds.Tables["Employee"].Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells[0].Value = item["Surname"];
                        dataGridView1.Rows[n].Cells[1].Value = item["Name"];
                        dataGridView1.Rows[n].Cells[2].Value = item["Age"];
                        dataGridView1.Rows[n].Cells[3].Value = item["Family"];
                        dataGridView1.Rows[n].Cells[4].Value = item["Mail"];
                    }
                }
                else
                {
                    MessageBox.Show("XML файл не знайдено.", "Помилка.");
                }
            }
        }
    }
}
