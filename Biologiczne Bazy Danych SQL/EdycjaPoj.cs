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
    public partial class EdycjaPoj : Form
    {
        private int idRekordu;
        private string connectionString = "Server=DESKTOP-5RKAGOG; Database=Motomaniak; Integrated Security=True;TrustServerCertificate=true";

        public EdycjaPoj(int id)
        {
            InitializeComponent();
            idRekordu = id;
        }

        private void EdycjaPoj_Load(object sender, EventArgs e)
        {
            string queryString = "SELECT Model, Marka, Kolor, Silnik, Data_dostarczenia, Cena_kupna FROM Pojazdy WHERE ID = @ID";
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
                        textBox3.Text = reader["Kolor"].ToString();
                        textBox4.Text = reader["Silnik"].ToString();
                        string data1 = reader["Data_dostarczenia"].ToString();
                        DateTime dateValue1;
                        if (DateTime.TryParse(data1, out dateValue1))
                        {
                            dateTimePicker1.Value = dateValue1;
                        }
                        textBox6.Text = reader["Cena_kupna"].ToString();

                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string updateString = "UPDATE Pojazdy SET Marka = @val1, Model = @val2, Kolor = @val3, Silnik = @val4, Data_dostarczenia = @val5, Cena_kupna = @val6 WHERE ID = @ID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(updateString, connection))
            {
                DialogResult resultdialog = MessageBox.Show("Czy na pewno chcesz edytować dane?", "Potwierdzenie", MessageBoxButtons.YesNo);
                if (resultdialog == DialogResult.Yes)
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

                        command.Parameters.AddWithValue("@ID", idRekordu);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Nieprawidłowe dane");
                    }
                    this.Close();
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
    }
}
