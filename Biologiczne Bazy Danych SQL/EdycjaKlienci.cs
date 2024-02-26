using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Biologiczne_Bazy_Danych_SQL
{
    public partial class EdycjaKlienci : Form
    {
        private int idRekordu;
        private string connectionString = "Server=DESKTOP-5RKAGOG; Database=Motomaniak; Integrated Security=True;TrustServerCertificate=true";
        public EdycjaKlienci(int id)
        {
            InitializeComponent();
            idRekordu = id;
        }

        private void EdycjaKlienci_Load(object sender, EventArgs e)
        {
            string queryString = "SELECT Imie, Nazwisko, Adres, Telefon FROM Klienci WHERE ID = @ID";
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
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string updateString = "UPDATE Klienci SET Imie = @val1, Nazwisko = @val2, Adres = @val3, Telefon = @val4 WHERE ID = @ID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(updateString, connection))
            {
                if(!string.IsNullOrEmpty(textBox1.Text) || !string.IsNullOrEmpty(textBox2.Text) || !string.IsNullOrEmpty(textBox3.Text) || !string.IsNullOrEmpty(maskedTextBox1.Text))
                {
                    DialogResult resultdialog = MessageBox.Show("Czy chcesz kontynuować?", "Potwierdzenie", MessageBoxButtons.YesNo);
                    if (resultdialog == DialogResult.Yes)
                    {
                        try
                        {
                            command.Parameters.AddWithValue("@val1", textBox1.Text);
                            command.Parameters.AddWithValue("@val2", textBox2.Text);
                            command.Parameters.AddWithValue("@val3", textBox3.Text);
                            if (maskedTextBox1.Text.Length != 9)
                            {
                                MessageBox.Show("Niepoprawna długość numeru telefonu");
                                return;
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@val4", maskedTextBox1.Text);

                            }
                            command.Parameters.AddWithValue("@ID", idRekordu);

                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();

                            this.Close();

                        }
                        catch
                        {
                            MessageBox.Show("Niepoprawne dane");
                        }
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
