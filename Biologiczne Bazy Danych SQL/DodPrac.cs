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
    public partial class DodPrac : Form
    {
        public DodPrac()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DodPrac_Load(object sender, EventArgs e)
        {
            textBox4.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-5RKAGOG; Database=Motomaniak; Integrated Security=True;TrustServerCertificate=true";
            string query = "INSERT INTO Pracownicy (Imie, Nazwisko, Adres, Telefon, Stanowisko, Haslo) VALUES (@val1, @val2, @val3, @val4, @val5, @val6)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text) ||
                                string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox6.Text))
                        {
                            MessageBox.Show("Brakuje wartości w jednym lub więcej polach tekstowych.");
                            return;
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@val1", textBox1.Text);
                            command.Parameters.AddWithValue("@val2", textBox2.Text);
                            command.Parameters.AddWithValue("@val3", textBox3.Text);
                            if(maskedTextBox1.Text.Length == 9)
                            {
                                command.Parameters.AddWithValue("@val4", maskedTextBox1.Text);
                            }
                            else
                            {
                                MessageBox.Show("Nieprawidłowa długość numeru telefonu");
                                return;
                            }
                            if (textBox6.Text != "Menadzer" || textBox6.Text != "Zastępca Menadzera" || textBox6.Text != "Sprzedawca")
                            {
                                MessageBox.Show("Niepoprawne stanowisko");
                                return;
                            }
                            command.Parameters.AddWithValue("@val5", textBox6.Text);
                            command.Parameters.AddWithValue("@val6", textBox4.Text);

                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                }
                this.Close();
            }
            catch
            {
                MessageBox.Show("Nieprawidłowy format danych");
            }
        }
    }
}
