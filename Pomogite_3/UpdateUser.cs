using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pomogite_3
{
    public partial class UpdateUser : Form
    {

        DBconnect connection = new DBconnect();

        public UpdateUser()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.None;

            connection.ConOpen();

            SqlCommand command_1 = new SqlCommand("select * from contact;", connection.GetConnection());

            using (var reader = command_1.ExecuteReader())
            {

                while (reader.Read())
                {

                    comboBox1.Items.Add(reader["surname"].ToString());

                }

            }

            SqlCommand command_data = new SqlCommand("select * from contact", connection.GetConnection());

            dataGridView1.Columns.Add("S1", "Фамилия");
            dataGridView1.Columns.Add("S2", "Имя");
            dataGridView1.Columns.Add("S3", "Отчество");
            dataGridView1.Columns.Add("S4", "Номер телеофна");

            using (var reader = command_data.ExecuteReader())
            {

                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["surname"].ToString(), reader["name"].ToString(), reader["patronymic"].ToString(), reader["PhoneNumber"].ToString());
                }

            }

            textBox1.Enabled = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command_2 = new SqlCommand($"UPDATE contact SET {comboBox2.Text} = '{textBox1.Text}' WHERE surname = '{comboBox1.Text}';", connection.GetConnection());
                command_2.ExecuteNonQuery();
                MessageBox.Show("Вы успешно изменили данные");
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
            catch (Exception)
            {

                MessageBox.Show("У вас не выбрано поле с именем или редактируемой колонкой");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
        }

        private void UpdateUser_Load(object sender, EventArgs e)
        {

        }
    }
}
