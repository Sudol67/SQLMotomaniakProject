using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Biologiczne_Bazy_Danych_SQL
{
    public partial class DodSerwis : Form
    {
        public DodSerwis()
        {
            InitializeComponent();
        }

        private void DodSerwis_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-5RKAGOG; Database=Motomaniak; Integrated Security=True;TrustServerCertificate=true";
            string query = "INSERT INTO Serwis (ID_Pojazdu, Opis, Koszt, Data_rozpoczecia, Data_zakonczenia) VALUES (@val1, @val2, @val3, @val4, @val5)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if(!string.IsNullOrEmpty(textBox1.Text) || !string.IsNullOrEmpty(richTextBox1.Text) || !string.IsNullOrEmpty(textBox3.Text))
                    {
                        try
                        {
                            command.Parameters.AddWithValue("@val1", textBox1.Text);
                            command.Parameters.AddWithValue("@val2", richTextBox1.Text);
                            if (!string.IsNullOrEmpty(textBox3.Text))
                            {
                                string wartoscZFormularza = textBox3.Text;
                                if (wartoscZFormularza.Contains("."))
                                {
                                    wartoscZFormularza = wartoscZFormularza.Replace(".", ",");
                                }
                                decimal kwota = decimal.Parse(wartoscZFormularza, NumberStyles.Any, new CultureInfo("pl-PL"));
                                command.Parameters.AddWithValue("@val3", kwota);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@val3", DBNull.Value);

                            }
                            DateTime wybranadata1 = dateTimePicker1.Value;
                            string sformatowana1 = wybranadata1.ToString("yyyy-MM-dd");
                            command.Parameters.AddWithValue("@val4", sformatowana1);
                            if (checkBox1.Checked)
                            {
                                command.Parameters.AddWithValue("@val5", DBNull.Value);
                            }
                            else
                            {
                                DateTime wybranadata2 = dateTimePicker2.Value;
                                string sformatowana2 = wybranadata2.ToString("yyyy-MM-dd");
                                command.Parameters.AddWithValue("@val5", sformatowana2);
                            }

                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();

                            this.Close();
                        }
                        catch 
                        {
                            MessageBox.Show("Pola zawierają błędne dane");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Proszę uzupełnić wszystkie pola");
                    }
                }
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

    }
}
