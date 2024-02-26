using Microsoft.Data.SqlClient;
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

namespace Biologiczne_Bazy_Danych_SQL
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-5RKAGOG; Database=Motomaniak; Integrated Security=True;TrustServerCertificate=true";
            string query = "INSERT INTO Pojazdy (Marka, Model, Kolor, Silnik, Data_dostarczenia, Cena_kupna, Cena_sprzedazy, Czy_sprzedany) VALUES (@val1, @val2, @val3, @val4, @val5, @val6, @val7, @val8)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || 
                            string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox6.Text))
                        {
                            MessageBox.Show("Brakuje wartości w jednym lub więcej polach tekstowych.");
                            return;
                        }
                        command.Parameters.AddWithValue("@val1", textBox1.Text);
                        command.Parameters.AddWithValue("@val2", textBox2.Text);
                        command.Parameters.AddWithValue("@val3", textBox3.Text);
                        command.Parameters.AddWithValue("@val4", textBox4.Text);
                        DateTime wybranadata1 = dateTimePicker1.Value;
                        string sformatowana1 = wybranadata1.ToString("yyyy-MM-dd");
                        command.Parameters.AddWithValue("@val5", sformatowana1);
                        string wartoscZFormularza = textBox6.Text;
                        if (wartoscZFormularza.Contains("."))
                        {
                            wartoscZFormularza = wartoscZFormularza.Replace(".", ",");
                        }
                        decimal liczba = decimal.Parse(wartoscZFormularza, NumberStyles.Any, new CultureInfo("pl-PL"));
                        command.Parameters.AddWithValue("@val6", liczba);
                        command.Parameters.AddWithValue("@val7", DBNull.Value);
                        command.Parameters.AddWithValue("@val8", "0");

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Nieprawidłowe dane");
                    }
                }
            }

            this.Close();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
