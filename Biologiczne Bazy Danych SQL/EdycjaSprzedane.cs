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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Biologiczne_Bazy_Danych_SQL
{
    public partial class EdycjaSprzedane : Form
    {
        private int idRekordu;
        private string connectionString = "Server=DESKTOP-5RKAGOG; Database=Motomaniak; Integrated Security=True;TrustServerCertificate=true";
        public EdycjaSprzedane(int id)
        {
            InitializeComponent();
            idRekordu = id;
        }

        private void EdycjaSprzedane_Load(object sender, EventArgs e)
        {
            string queryString = "SELECT Marka, Model, ID_Pojazdu, ID_Klienta, ID_Sprzedawcy, Cena_kupna, Cena_sprzedazy, DataSprzedazy FROM Sprzedane WHERE ID = @ID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                command.Parameters.AddWithValue("@ID", idRekordu);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        textBox1.Text = reader["Marka"].ToString();
                        textBox2.Text = reader["Model"].ToString();
                        textBox3.Text = reader["ID_Pojazdu"].ToString();
                        textBox4.Text = reader["ID_Klienta"].ToString();
                        textBox5.Text = reader["ID_Sprzedawcy"].ToString();
                        textBox6.Text = reader["Cena_kupna"].ToString();
                        textBox7.Text = reader["Cena_sprzedazy"].ToString();
                        string data1 = reader["DataSprzedazy"].ToString();
                        DateTime dateValue1;
                        if (DateTime.TryParse(data1, out dateValue1))
                        {
                            dateTimePicker1.Value = dateValue1;
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string updateString = "UPDATE Serwis SET Marka = @val1, Model = @val2, ID_Pojazdu = @val3, ID_Klienta = @val4, ID_Sprzedawcy = @val5,  Cena_kupna = @val6, Cena_sprzedazy = @val7, DataSprzedazy = @val8 WHERE ID = @ID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(updateString, connection))
            {
                if (!string.IsNullOrEmpty(textBox1.Text) || !string.IsNullOrEmpty(textBox2.Text) || !string.IsNullOrEmpty(textBox3.Text) || !string.IsNullOrEmpty(textBox4.Text) || !string.IsNullOrEmpty(textBox5.Text) || !string.IsNullOrEmpty(textBox6.Text))
                {
                    DialogResult resultdialog = MessageBox.Show("Czy chcesz kontynuować?", "Potwierdzenie", MessageBoxButtons.YesNo);
                    if (resultdialog == DialogResult.Yes)
                    {
                        try
                        {
                            command.Parameters.AddWithValue("@val1", textBox1.Text);
                            command.Parameters.AddWithValue("@val2", textBox2.Text);
                            command.Parameters.AddWithValue("@val3", textBox3.Text);
                            command.Parameters.AddWithValue("@val4", textBox4.Text);
                            command.Parameters.AddWithValue("@val5", textBox5.Text);
                            //-----------------------------------
                            string wartosckupna = textBox6.Text;
                            if (wartosckupna.Contains("."))
                            {
                                wartosckupna = wartosckupna.Replace(".", ",");
                            }
                            decimal liczbaKupna = decimal.Parse(wartosckupna, NumberStyles.Any, new CultureInfo("pl-PL"));
                            command.Parameters.AddWithValue("@val6", liczbaKupna);
                            //---------------------------------
                            string wartoscsprzedazy = textBox7.Text;
                            if (wartoscsprzedazy.Contains("."))
                            {
                                wartoscsprzedazy = wartoscsprzedazy.Replace(".", ",");
                            }
                            decimal liczbaSprzedazy = decimal.Parse(wartoscsprzedazy, NumberStyles.Any, new CultureInfo("pl-PL"));
                            command.Parameters.AddWithValue("@val7", liczbaSprzedazy);
                            //-----------------------------------
                            DateTime wybranadata1 = dateTimePicker1.Value;
                            string sformatowana1 = wybranadata1.ToString("yyyy-MM-dd");
                            command.Parameters.AddWithValue("@val8", sformatowana1);

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

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
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
