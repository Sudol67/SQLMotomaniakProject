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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Biologiczne_Bazy_Danych_SQL
{
    public partial class EdytSerwis : Form
    {
        private int idRekordu;
        private string connectionString = "Server=DESKTOP-5RKAGOG; Database=Motomaniak; Integrated Security=True;TrustServerCertificate=true";
        public EdytSerwis(int id)
        {
            InitializeComponent();
            idRekordu = id;
        }

        private void EdytSerwis_Load(object sender, EventArgs e)
        {
            string queryString = "SELECT ID_Pojazdu, Opis, Koszt, Data_rozpoczecia, Data_zakonczenia FROM Serwis WHERE ID_Zgloszenia = @ID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                command.Parameters.AddWithValue("@ID", idRekordu);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        textBox1.Text = reader["ID_Pojazdu"].ToString();
                        richTextBox1.Text = reader["Opis"].ToString();
                        textBox3.Text = reader["Koszt"].ToString();
                        string data1 = reader["Data_rozpoczecia"].ToString();
                        DateTime dateValue1;
                        if (DateTime.TryParse(data1, out dateValue1))
                        {
                            dateTimePicker1.Value = dateValue1;
                        }
                        string data2 = reader["Data_zakonczenia"].ToString();
                        DateTime dateValue2;
                        if (DateTime.TryParse(data2, out dateValue2))
                        {
                            dateTimePicker2.Value = dateValue2;
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string updateString = "UPDATE Serwis SET ID_Pojazdu = @val1, Opis = @val2, Koszt = @val3, Data_rozpoczecia = @val4, Data_zakonczenia = @val5 WHERE ID_Zgloszenia = @ID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(updateString, connection))
            {
                if (!string.IsNullOrEmpty(textBox1.Text) || !string.IsNullOrEmpty(textBox3.Text) || !string.IsNullOrEmpty(richTextBox1.Text))
                {
                    DialogResult resultdialog = MessageBox.Show("Czy chcesz kontynuować?", "Potwierdzenie", MessageBoxButtons.YesNo);
                    if (resultdialog == DialogResult.Yes)
                    {
                        try
                        {
                            command.Parameters.AddWithValue("@val1", textBox1.Text);
                            command.Parameters.AddWithValue("@val2", richTextBox1.Text);
                            string wartoscZFormularza = textBox3.Text;
                            if (wartoscZFormularza.Contains("."))
                            {
                                wartoscZFormularza = wartoscZFormularza.Replace(".", ",");
                            }
                            decimal liczba = decimal.Parse(wartoscZFormularza, NumberStyles.Any, new CultureInfo("pl-PL"));
                            command.Parameters.AddWithValue("@val3", liczba);
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
                }
                else
                {
                    MessageBox.Show("Proszę uzupełnić wszystkie pola");
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
