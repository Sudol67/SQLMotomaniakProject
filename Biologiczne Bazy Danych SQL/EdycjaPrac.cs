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
    public partial class EdycjaPrac : Form
    {
        private int idRekordu;
        private string connectionString = "Server=DESKTOP-5RKAGOG; Database=Motomaniak; Integrated Security=True;TrustServerCertificate=true";

        public EdycjaPrac(int id)
        {
            InitializeComponent();
            idRekordu = id;
        }

        private void EdycjaPrac_Load(object sender, EventArgs e)
        {
            string queryString = "SELECT Imie, Nazwisko, Adres, Telefon, Stanowisko, Haslo FROM Pracownicy WHERE ID = @ID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                command.Parameters.AddWithValue("@ID", idRekordu);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        textBox1.Text = reader["Imie"].ToString();
                        textBox2.Text = reader["Nazwisko"].ToString();
                        textBox3.Text = reader["Adres"].ToString();
                        maskedTextBox1.Text = reader["Telefon"].ToString();
                        textBox6.Text = reader["Stanowisko"].ToString();
                        textBox4.Text = reader["Haslo"].ToString();

                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string updateString = "UPDATE Pracownicy SET Imie = @val1, Nazwisko = @val2, Adres = @val3, Telefon = @val4, Stanowisko = @val5, Haslo = @val6 WHERE ID = @ID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(updateString, connection))
            {
                if(!string.IsNullOrEmpty(textBox1.Text) || !string.IsNullOrEmpty(textBox2.Text) || !string.IsNullOrEmpty(textBox3.Text) || !string.IsNullOrEmpty(maskedTextBox1.Text) || !string.IsNullOrEmpty(textBox4.Text) || !string.IsNullOrEmpty(textBox6.Text))
                {
                    DialogResult resultdialog = MessageBox.Show("Czy chcesz kontynuować?", "Potwierdzenie", MessageBoxButtons.YesNo);
                    if (resultdialog == DialogResult.Yes)
                    {
                        try
                        {
                            command.Parameters.AddWithValue("@val1", textBox1.Text);
                            command.Parameters.AddWithValue("@val2", textBox2.Text);
                            command.Parameters.AddWithValue("@val3", textBox3.Text);
                            
                            if(maskedTextBox1.Text.Length != 9)
                            {
                                MessageBox.Show("Niepoprawna długość numeru telefonu");
                                return;
                            }
                            command.Parameters.AddWithValue("@val4", maskedTextBox1.Text);
                            command.Parameters.AddWithValue("@val5", textBox6.Text);
                            if(textBox6.Text != "Menadzer" || textBox6.Text != "Zastępca Menadzera" || textBox6.Text != "Sprzedawca")
                            {
                                MessageBox.Show("Niepoprawne stanowisko");
                                return;
                            }
                            command.Parameters.AddWithValue("@val6", textBox4.Text);

                            command.Parameters.AddWithValue("@ID", idRekordu);

                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();

                            this.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Błędne dane");
                        }
                    }
                else
                {
                    MessageBox.Show("Proszę uzupełnić wszystkie pola");
                }
                }
            }
        }
    }
}
