using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using System.Globalization;
using System.Drawing;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;


namespace Biologiczne_Bazy_Danych_SQL
{
    public partial class Form1 : Form
    {
        private string connectionString = "Server=DESKTOP-5RKAGOG; Database=Motomaniak; Integrated Security=True;TrustServerCertificate=true";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queryPoj = "SELECT * FROM Pojazdy";
            SqlDataAdapter adapter1 = new SqlDataAdapter(queryPoj, connection);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            dataGridView1.DataSource = table1;

            string querySerw = "SELECT * FROM Serwis";
            SqlDataAdapter adapter2 = new SqlDataAdapter(querySerw, connection);
            DataTable table2 = new DataTable();
            adapter2.Fill(table2);
            dataGridView2.DataSource = table2;

            string querySprz = "SELECT * FROM Sprzedane";
            SqlDataAdapter adapter3 = new SqlDataAdapter(querySprz, connection);
            DataTable table3 = new DataTable();
            adapter3.Fill(table3);
            dataGridView3.DataSource = table3;

            string queryKli = "SELECT * FROM Klienci";
            SqlDataAdapter adapter4 = new SqlDataAdapter(queryKli, connection);
            DataTable table4 = new DataTable();
            adapter4.Fill(table4);
            dataGridView4.DataSource = table4;

            string queryPrac = "SELECT ID, IMIE, NAZWISKO, ADRES, TELEFON, STANOWISKO FROM Pracownicy";
            SqlDataAdapter adapter5 = new SqlDataAdapter(queryPrac, connection);
            DataTable table5 = new DataTable();
            adapter5.Fill(table5);
            dataGridView5.DataSource = table5;

            List<int> listaNumerowLabeli = new List<int> { 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 73, 74, 75, 76, 78, 80, 82 };
            foreach (int numer in listaNumerowLabeli)
            {
                Label label = this.Controls.Find("label" + numer.ToString(), true).FirstOrDefault() as Label;
                if (label != null)
                {
                    label.Text = "";
                }
            }
            label91.Visible = false;
            label92.Visible = false;
            button36.Enabled = false;

            foreach (TabPage tab in tabControl1.TabPages)
            {
                tab.Text = "";
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "czy_sprzedane")
            {
                if (e.Value != null)
                {
                    e.Value = (e.Value.ToString() == "1") ? "tak" : "nie";
                    e.FormattingApplied = true;
                }
            }
        }

        //-----------------------------------------Tabela Magazyn/Pojazdy ----------------------------------------------------------------------------

        private void button1_Click(object sender, EventArgs e)
        {
            //Dodaj nowy pojazd
            Form2 formDodajRekord = new Form2();
            formDodajRekord.ShowDialog();

            SqlConnection connection = new SqlConnection(connectionString);
            string queryPoj = "SELECT * FROM Pojazdy";
            SqlDataAdapter adapter1 = new SqlDataAdapter(queryPoj, connection);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            dataGridView1.DataSource = table1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //usuwanie rekordu pojazdu
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                int idDoUsuniecia = Convert.ToInt32(dataGridView1[0, selectedIndex].Value);

                DialogResult resultdialog = MessageBox.Show("Czy chcesz kontynuowaæ?", "Potwierdzenie", MessageBoxButtons.YesNo);
                if (resultdialog == DialogResult.Yes)
                {
                    string queryString = "DELETE FROM Pojazdy WHERE ID = @id";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(queryString, connection);
                        command.Parameters.AddWithValue("@id", idDoUsuniecia);

                        try
                        {
                            connection.Open();
                            int result = command.ExecuteNonQuery();

                            if (result > 0)
                            {
                                MessageBox.Show("Rekord zosta³ usuniêty.");
                            }
                            else
                            {
                                MessageBox.Show("Rekord nie zosta³ znaleziony.");
                            }
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Wyst¹pi³ b³¹d podczas usuwania rekordu: " + ex.Message);
                        }
                        string queryPoj = "SELECT * FROM Pojazdy";
                        SqlDataAdapter adapter1 = new SqlDataAdapter(queryPoj, connection);
                        DataTable table1 = new DataTable();
                        adapter1.Fill(table1);
                        dataGridView1.DataSource = table1;
                    }

                }
            }
            else
            {
                MessageBox.Show("Proszê zaznaczyæ rz¹d do usuniêcia.");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //Edytowanie pojazdów
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                int id = Convert.ToInt32(selectedRow.Cells[0].Value);

                EdycjaPoj formDodajRekord = new EdycjaPoj(id);
                formDodajRekord.ShowDialog();

                SqlConnection connection = new SqlConnection(connectionString);
                string queryPoj = "SELECT * FROM Pojazdy";
                SqlDataAdapter adapter1 = new SqlDataAdapter(queryPoj, connection);
                DataTable table1 = new DataTable();
                adapter1.Fill(table1);
                dataGridView1.DataSource = table1;
            }
            else
            {
                MessageBox.Show("Proszê zaznaczyæ rz¹d do edycji.");
            }

        }
        private void button14_Click(object sender, EventArgs e)
        {
            //Wyszukiwanie w tabeli
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Proszê wybraæ przeszukiwan¹ kolumnê");
            }
            else if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Proszê wpisaæ wyszukiwan¹ frazê");
            }
            else
            {
                string selectedColumn = comboBox1.SelectedItem.ToString();
                string filterExpression = "";

                try
                {
                    if (!string.IsNullOrEmpty(textBox1.Text))
                    {
                        if (selectedColumn == "ID")
                        {
                            int liczba = int.Parse(textBox1.Text);
                            filterExpression = string.Format("{0} = {1}", selectedColumn, liczba);
                        }
                        else
                        {
                            filterExpression = string.Format("{0} LIKE '%{1}%'", selectedColumn, textBox1.Text);
                        }
                    }
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Nieprawid³owe dane wyszukiwania");
                }

                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = filterExpression;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //wyczyœæ
            textBox1.Text = "";
            comboBox1.SelectedIndex = -1;

            SqlConnection connection = new SqlConnection(connectionString);
            string queryPoj = "SELECT * FROM Pojazdy";
            SqlDataAdapter adapter1 = new SqlDataAdapter(queryPoj, connection);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            dataGridView1.DataSource = table1;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //menu g³ówne przycisk
            tabControl1.SelectedIndex = 0;
            textBox1.Text = "";
            comboBox1.SelectedIndex = -1;

            SqlConnection connection = new SqlConnection(connectionString);
            string queryPoj = "SELECT * FROM Pojazdy";
            SqlDataAdapter adapter1 = new SqlDataAdapter(queryPoj, connection);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            dataGridView1.DataSource = table1;
        }

        //----------------------------------------Menu g³ówne----------------------------------------------------------------
        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 5;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 6;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 7;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        //--------------------------Sprzeda¿--------------------------------------------------------------

        private void button16_Click(object sender, EventArgs e)
        {
            //Szukanie danych
            bool pojazd = false;
            bool pracownik = false;
            //Klient
            /*string klientId = textBox2.Text;

            if (!string.IsNullOrEmpty(klientId) & string.IsNullOrEmpty(textBox3.Text) & string.IsNullOrEmpty(textBox4.Text) & string.IsNullOrEmpty(textBox5.Text) & string.IsNullOrEmpty(textBox6.Text))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT Imie, Nazwisko, Adres, Telefon FROM Klienci WHERE ID = @IdKlienta";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@IdKlienta", klientId);
                        connection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBox3.Text = reader["Imie"].ToString();
                                textBox4.Text = reader["Nazwisko"].ToString();
                                textBox5.Text = reader["Adres"].ToString();
                                textBox6.Text = reader["Telefon"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Klient nie zosta³ znaleziony.");
                            }
                        }
                    }
                }
            }
            else if (string.IsNullOrEmpty(textBox2.Text) & !string.IsNullOrEmpty(textBox3.Text) & !string.IsNullOrEmpty(textBox4.Text) & !string.IsNullOrEmpty(textBox5.Text) & !string.IsNullOrEmpty(textBox6.Text))
            {
                //Tworzenie nowego klienta
                DialogResult resultdialog = MessageBox.Show("Czy chcesz stworzyæ nowego klienta?", "Potwierdzenie", MessageBoxButtons.YesNo);
                if (resultdialog == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "INSERT INTO Klienci (Imie, Nazwisko, Adres, Telefon) VALUES (@Imie, @Nazwisko, @Adres, @Telefon)";

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@Imie", textBox3.Text);
                            cmd.Parameters.AddWithValue("@Nazwisko", textBox4.Text);
                            cmd.Parameters.AddWithValue("@Adres", textBox5.Text);
                            cmd.Parameters.AddWithValue("@Adres", textBox6.Text);

                            connection.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Klient zosta³ dodany.");
                }
            }*/
            //Pracownik
            string pracownikId = textBox17.Text;
            if (!string.IsNullOrEmpty(pracownikId))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT Imie, Nazwisko, Adres, Telefon, Stanowisko FROM Pracownicy WHERE ID = @IdPracownika";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@IdPracownika", pracownikId);
                        connection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            try
                            {
                                if (reader.Read())
                                {
                                    pracownik = true;
                                    textBox16.Text = reader["Imie"].ToString();
                                    textBox15.Text = reader["Nazwisko"].ToString();
                                    textBox14.Text = reader["Adres"].ToString();
                                    textBox13.Text = reader["Telefon"].ToString();
                                    textBox18.Text = reader["Stanowisko"].ToString();
                                }
                                else
                                {
                                    MessageBox.Show("Pracownik nie zosta³ znaleziony.");
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Niepoprawne ID pracownika");
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Proszê uzupe³niæ ID pracownika");
            }
            //Samochód
            string samochodId = textBox11.Text;
            if (!string.IsNullOrEmpty(samochodId))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT Marka, Model, Kolor, Silnik, czy_sprzedany FROM Pojazdy WHERE ID = @Idsamochodu";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Idsamochodu", samochodId);
                        connection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            try
                            {
                                if (reader.Read())
                                {
                                    if (reader["czy_sprzedany"].ToString() == "1")
                                    {
                                        MessageBox.Show("Ten pojazd zosta³ ju¿ sprzedany. Proszê wybraæ inny.");
                                    }
                                    else
                                    {
                                        pojazd = true;
                                        textBox10.Text = reader["Marka"].ToString();
                                        textBox9.Text = reader["Model"].ToString();
                                        textBox8.Text = reader["Kolor"].ToString();
                                        textBox7.Text = reader["Silnik"].ToString();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Pojazd nie zosta³ znaleziony.");
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Niepoprawne ID Pojazdu");
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Proszê uzupe³niæ ID pojazdu");
            }
            if (pojazd == true & pracownik == true & !string.IsNullOrEmpty(textBox3.Text) & !string.IsNullOrEmpty(textBox4.Text) & !string.IsNullOrEmpty(textBox5.Text) & !string.IsNullOrEmpty(maskedTextBox1.Text) & !string.IsNullOrEmpty(textBox11.Text) & !string.IsNullOrEmpty(textBox17.Text))
            {
                button16.Enabled = false;
                button17.Enabled = true;
                textBox11.ReadOnly = true;
                textBox17.ReadOnly = true;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //Sprzeda¿
            //Tablica Pojazdy
            string idPojazdu = textBox11.Text;
            if (!string.IsNullOrEmpty(idPojazdu))
            {
                string updateString = "UPDATE Pojazdy SET Cena_sprzedazy = @val1, Czy_sprzedany = @val2 WHERE ID = @ID";
                using (SqlConnection connection1 = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(updateString, connection1))
                {
                    if (!string.IsNullOrEmpty(textBox12.Text))
                    {
                        string wartoscZFormularza = textBox12.Text;
                        if (wartoscZFormularza.Contains("."))
                        {
                            wartoscZFormularza = wartoscZFormularza.Replace(".", ",");
                        }
                        decimal liczba = decimal.Parse(wartoscZFormularza, NumberStyles.Any, new CultureInfo("pl-PL"));
                        command.Parameters.AddWithValue("@val1", liczba);
                    }
                    else
                    {
                        MessageBox.Show("Proszê uzupe³niæ cenê sprzeda¿y");
                    }
                    command.Parameters.AddWithValue("@val2", "1");

                    command.Parameters.AddWithValue("@ID", idPojazdu);

                    connection1.Open();
                    command.ExecuteNonQuery();
                    connection1.Close();
                }
            }
            //tablica Klienta
            //Tworzenie nowego klienta
            using (SqlConnection connection2 = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Klienci (Imie, Nazwisko, Adres, Telefon, ID_Pojazdu) VALUES (@Imie, @Nazwisko, @Adres, @Telefon, @IDPojazdu)";

                using (SqlCommand cmd = new SqlCommand(query, connection2))
                {
                    if (string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox5.Text) ||
                            string.IsNullOrWhiteSpace(maskedTextBox1.Text) || string.IsNullOrWhiteSpace(textBox11.Text))
                    {
                        MessageBox.Show("Brakuje wartoœci w jednym lub wiêcej polach tekstowych.");
                        return;
                    }
                    else if (maskedTextBox1.Text.Length != 9)
                    {
                        MessageBox.Show("Niepoprawna d³ugoœæ numeru telefonu");
                        return;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Imie", textBox3.Text);
                        cmd.Parameters.AddWithValue("@Nazwisko", textBox4.Text);
                        cmd.Parameters.AddWithValue("@Adres", textBox5.Text);
                        cmd.Parameters.AddWithValue("@Telefon", maskedTextBox1.Text);
                        cmd.Parameters.AddWithValue("@IDPojazdu", textBox11.Text);
                    }
                    connection2.Open();
                    cmd.ExecuteNonQuery();
                    connection2.Close();
                }
            }
            MessageBox.Show("Klient zosta³ dodany.");

            //tablica Sprzedane
            if (string.IsNullOrEmpty(maskedTextBox1.Text))
            {
                MessageBox.Show("Niepoprawny telefon");
                return;
            }
            string Ntelefon = maskedTextBox1.Text.ToString();
            string queryPobierzIDKlienta = "SELECT ID FROM Klienci WHERE Telefon = @nTelefonu";
            int idKlienta = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(queryPobierzIDKlienta, conn))
                {
                    cmd.Parameters.AddWithValue("@nTelefonu", Ntelefon);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            idKlienta = Convert.ToInt32(reader["ID"]);
                        }
                        else
                        {
                            MessageBox.Show("Nie znaleziono klienta dla podanego ID pojazdu.");
                            return;
                        }
                    }
                }
            }
            string IDPoj = textBox11.Text;
            string queryPobierzCeneKupna = "SELECT Cena_kupna FROM Pojazdy WHERE ID = @IDpoj";
            decimal Cena = 0;


            using (SqlConnection connection3 = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd1 = new SqlCommand(queryPobierzCeneKupna, connection3))
                {
                    cmd1.Parameters.AddWithValue("@IDpoj", IDPoj);

                    connection3.Open();
                    using (SqlDataReader reader = cmd1.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Cena = (decimal)reader["Cena_kupna"];
                        }
                        else
                        {
                            MessageBox.Show("Nie znaleziono pojazdu dla podanego ID.");
                            return;
                        }
                    }
                }
            }

            string queryDodajDoSprzedanych = "INSERT INTO Sprzedane (Marka, Model, ID_Pojazdu, ID_Klienta, ID_Sprzedawcy, Cena_kupna, Cena_sprzedazy, Przychod, DataSprzedazy) VALUES (@Marka, @Model, @ID_Pojazdu, @ID_Klienta, @ID_Sprzedawcy, @Cena_kupna, @Cena_sprzedazy, @Przychod, @DataSprzedazy)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(queryDodajDoSprzedanych, conn))
                {
                    cmd.Parameters.AddWithValue("@Marka", textBox10.Text);
                    cmd.Parameters.AddWithValue("@Model", textBox9.Text);
                    cmd.Parameters.AddWithValue("@ID_Pojazdu", textBox11.Text);
                    cmd.Parameters.AddWithValue("@ID_Klienta", idKlienta);
                    cmd.Parameters.AddWithValue("@ID_Sprzedawcy", textBox17.Text);
                    cmd.Parameters.AddWithValue("@Cena_kupna", Cena);
                    string wartoscZFormularza = textBox12.Text;
                    if (wartoscZFormularza.Contains("."))
                    {
                        wartoscZFormularza = wartoscZFormularza.Replace(".", ",");
                    }
                    decimal liczbaCena = decimal.Parse(wartoscZFormularza, NumberStyles.Any, new CultureInfo("pl-PL"));
                    cmd.Parameters.AddWithValue("@Cena_sprzedazy", liczbaCena);
                    cmd.Parameters.AddWithValue("@Przychod", 0);
                    cmd.Parameters.AddWithValue("@DataSprzedazy", DateTime.Now);

                    conn.Open();
                    int wynik = cmd.ExecuteNonQuery();

                    if (wynik > 0)
                        MessageBox.Show("Pojazd zosta³ dodany do sprzedanych.");
                    else
                        MessageBox.Show("B³¹d podczas dodawania do sprzedanych.");
                }
            }
            SqlConnection connection = new SqlConnection(connectionString);

            string queryPoj = "SELECT * FROM Pojazdy";
            SqlDataAdapter adapter1 = new SqlDataAdapter(queryPoj, connection);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            dataGridView1.DataSource = table1;

            string querySprz = "SELECT * FROM Sprzedane";
            SqlDataAdapter adapter3 = new SqlDataAdapter(querySprz, connection);
            DataTable table3 = new DataTable();
            adapter3.Fill(table3);
            dataGridView3.DataSource = table3;

            string queryKli = "SELECT * FROM Klienci";
            SqlDataAdapter adapter4 = new SqlDataAdapter(queryKli, connection);
            DataTable table4 = new DataTable();
            adapter4.Fill(table4);
            dataGridView4.DataSource = table4;

            button16.Enabled = true;
            button17.Enabled = false;
            textBox11.ReadOnly = false;
            textBox17.ReadOnly = false;
            List<int> listaNumerowTextboxow = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 };
            foreach (int numer in listaNumerowTextboxow)
            {
                TextBox textbox = this.Controls.Find("textBox" + numer.ToString(), true).FirstOrDefault() as TextBox;
                if (textbox != null)
                {
                    textbox.Text = "";
                }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            //powrót do menu g³ównego i czyszczenie formularza
            textBox11.ReadOnly = false;
            textBox17.ReadOnly = false;
            tabControl1.SelectedIndex = 0;
            button16.Enabled = true;
            button17.Enabled = false;
            maskedTextBox1.Text = "";
            List<int> listaNumerowTextboxow = new List<int> { 2, 3, 4, 5, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 };
            foreach (int numer in listaNumerowTextboxow)
            {
                TextBox textbox = this.Controls.Find("textBox" + numer.ToString(), true).FirstOrDefault() as TextBox;
                if (textbox != null)
                {
                    textbox.Text = "";
                }
            }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
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

        //-------------------------Pracownicy--------------------------------------------------------------------
        private void button19_Click(object sender, EventArgs e)
        {
            //Powrót do Menu
            tabControl1.SelectedIndex = 0;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            //Usuwanie
            if (dataGridView5.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView5.SelectedRows[0].Index;
                int idDoUsuniecia = Convert.ToInt32(dataGridView5[0, selectedIndex].Value);

                DialogResult resultdialog = MessageBox.Show("Czy chcesz kontynuowaæ?", "Potwierdzenie", MessageBoxButtons.YesNo);
                if (resultdialog == DialogResult.Yes)
                {
                    string queryString = "DELETE FROM Pracownicy WHERE ID = @id";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(queryString, connection);
                        command.Parameters.AddWithValue("@id", idDoUsuniecia);

                        try
                        {
                            connection.Open();
                            int result = command.ExecuteNonQuery();

                            if (result > 0)
                            {
                                MessageBox.Show("Rekord zosta³ usuniêty.");
                            }
                            else
                            {
                                MessageBox.Show("Rekord nie zosta³ znaleziony.");
                            }
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Wyst¹pi³ b³¹d podczas usuwania rekordu: " + ex.Message);
                        }
                        string queryPrac = "SELECT ID, IMIE, NAZWISKO, ADRES, TELEFON, STANOWISKO FROM Pracownicy";
                        SqlDataAdapter adapter5 = new SqlDataAdapter(queryPrac, connection);
                        DataTable table5 = new DataTable();
                        adapter5.Fill(table5);
                        dataGridView5.DataSource = table5;
                    }
                }
            }
            else
            {
                MessageBox.Show("Proszê zaznaczyæ rz¹d do usuniêcia.");
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            //Edytowanie
            if (dataGridView5.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView5.SelectedRows[0];

                int id = Convert.ToInt32(selectedRow.Cells[0].Value);

                EdycjaPrac formEdytujRekord = new EdycjaPrac(id);
                formEdytujRekord.ShowDialog();

                SqlConnection connection = new SqlConnection(connectionString);
                string queryPrac = "SELECT ID, IMIE, NAZWISKO, ADRES, TELEFON, STANOWISKO FROM Pracownicy";
                SqlDataAdapter adapter5 = new SqlDataAdapter(queryPrac, connection);
                DataTable table5 = new DataTable();
                adapter5.Fill(table5);
                dataGridView5.DataSource = table5;
            }
            else
            {
                MessageBox.Show("Proszê zaznaczyæ rz¹d do edycji.");
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            //Dodawanie
            DodPrac formDodajRekord = new DodPrac();
            formDodajRekord.ShowDialog();
            SqlConnection connection = new SqlConnection(connectionString);
            string queryPrac = "SELECT ID, IMIE, NAZWISKO, ADRES, TELEFON, STANOWISKO FROM Pracownicy";
            SqlDataAdapter adapter5 = new SqlDataAdapter(queryPrac, connection);
            DataTable table5 = new DataTable();
            adapter5.Fill(table5);
            dataGridView5.DataSource = table5;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            //Wyszukiwanie
            string selectedColumn = comboBox2.SelectedItem.ToString();
            string filterExpression = "";

            if (!string.IsNullOrEmpty(textBox19.Text))
            {
                if (selectedColumn == "Telefon")
                {
                    int liczba = int.Parse(textBox19.Text);
                    filterExpression = string.Format("{0} = {1}", selectedColumn, liczba);
                }
                else
                {
                    filterExpression = string.Format("{0} LIKE '%{1}%'", selectedColumn, textBox19.Text);
                }
            }

            (dataGridView5.DataSource as DataTable).DefaultView.RowFilter = filterExpression;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            //wyczyœæ
            textBox1.Text = "";
            comboBox1.SelectedIndex = -1;
            SqlConnection connection = new SqlConnection(connectionString);
            string queryPrac = "SELECT ID, IMIE, NAZWISKO, ADRES, TELEFON, STANOWISKO FROM Pracownicy";
            SqlDataAdapter adapter5 = new SqlDataAdapter(queryPrac, connection);
            DataTable table5 = new DataTable();
            adapter5.Fill(table5);
            dataGridView5.DataSource = table5;
        }

        //-----------------------------Raport--------------------------------------------------------------------------------
        private void button25_Click(object sender, EventArgs e)
        {
            //Szukaj
            if (!string.IsNullOrEmpty(textBox20.Text) & int.TryParse(textBox20.Text, out _))
            {
                string IDSprzedazy = textBox20.Text;
                string IDPojazdu = "", IDKlienta = "", IDSprzedawcy = "", CenaKupna = "", CenaSprzedazy = "", Przychod = "", DataSprzedazy = "", Marka = "", Model = "", Kolor = "", Silnik = "", DataDostarczenia = "", ImieKlient = "", NazwiskoKlient = "", AdresKlient = "";
                string TelefonKlient = "", ImieSprzedawca = "", NazwiskoSprzedawca = "", TelefonSprzedawca = "", StanowiskoSprzedawca = "";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("PobierzDaneSprzedazy", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", IDSprzedazy);

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Przypisanie wartoœci do labeli
                                IDPojazdu = reader["ID_Pojazdu"].ToString();
                                IDKlienta = reader["ID_Klienta"].ToString();
                                IDSprzedawcy = reader["ID_Sprzedawcy"].ToString();
                                CenaKupna = reader["Cena_kupna"].ToString();
                                CenaSprzedazy = reader["Cena_sprzedazy"].ToString();
                                Przychod = reader["Przychod"].ToString();
                                DataSprzedazy = reader["DataSprzedazy"].ToString();
                                Marka = reader["Marka"].ToString();
                                Model = reader["Model"].ToString();
                                Kolor = reader["Kolor"].ToString();
                                Silnik = reader["Silnik"].ToString();
                                DataDostarczenia = reader["Data_dostarczenia"].ToString();
                                ImieKlient = reader["ImieKlienta"].ToString();
                                NazwiskoKlient = reader["NazwiskoKlienta"].ToString();
                                AdresKlient = reader["Adres"].ToString();
                                TelefonKlient = reader["TelefonKlienta"].ToString();
                                ImieSprzedawca = reader["ImieSprzedawcy"].ToString();
                                NazwiskoSprzedawca = reader["NazwiskoSprzedawcy"].ToString();
                                TelefonSprzedawca = reader["TelefonSprzedawcy"].ToString();
                                StanowiskoSprzedawca = reader["Stanowisko"].ToString();

                                if (radioButton4.Checked & !radioButton3.Checked)
                                {
                                    //Klient
                                    label53.Visible = false;
                                    label54.Visible = false;
                                    label55.Visible = false;
                                    label82.Text = IDPojazdu;
                                    label62.Text = Marka;
                                    label61.Text = Model;
                                    label60.Text = Kolor;
                                    label59.Text = Silnik;
                                    label58.Text = DataSprzedazy;
                                    label57.Text = CenaSprzedazy + " z³";
                                    label78.Text = IDSprzedawcy;
                                    label65.Text = ImieSprzedawca;
                                    label66.Text = NazwiskoSprzedawca;
                                    label67.Text = TelefonSprzedawca;
                                    label68.Text = StanowiskoSprzedawca;
                                    label80.Text = IDKlienta;
                                    label76.Text = ImieKlient;
                                    label75.Text = NazwiskoKlient;
                                    label74.Text = AdresKlient;
                                    label73.Text = TelefonKlient;

                                }
                                else if (radioButton3.Checked & !radioButton4.Checked)
                                {
                                    //Salon
                                    label82.Text = IDPojazdu;
                                    label62.Text = Marka;
                                    label61.Text = Model;
                                    label60.Text = Kolor;
                                    label59.Text = Silnik;
                                    label58.Text = DataSprzedazy;
                                    label57.Text = CenaSprzedazy + " z³";
                                    label56.Text = DataDostarczenia;
                                    label63.Text = CenaKupna + " z³";
                                    label64.Text = Przychod + " z³";
                                    label78.Text = IDSprzedawcy;
                                    label65.Text = ImieSprzedawca;
                                    label66.Text = NazwiskoSprzedawca;
                                    label67.Text = TelefonSprzedawca;
                                    label68.Text = StanowiskoSprzedawca;
                                    label80.Text = IDKlienta;
                                    label76.Text = ImieKlient;
                                    label75.Text = NazwiskoKlient;
                                    label74.Text = AdresKlient;
                                    label73.Text = TelefonKlient;
                                }
                                else
                                {
                                    MessageBox.Show("Proszê zaznaczyæ rodzaj raportu");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Nie znaleziono danych dla podanego ID.");
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Proszê wpisaæ prawid³owy numer ID");
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            //Wyczyœæ
            textBox20.Text = "";
            radioButton4.Checked = false;
            radioButton3.Checked = false;
            label53.Visible = true;
            label54.Visible = true;
            label55.Visible = true;
            label82.Text = "";
            label62.Text = "";
            label61.Text = "";
            label60.Text = "";
            label59.Text = "";
            label58.Text = "";
            label57.Text = "";
            label56.Text = "";
            label63.Text = "";
            label64.Text = "";
            label78.Text = "";
            label65.Text = "";
            label66.Text = "";
            label67.Text = "";
            label68.Text = "";
            label80.Text = "";
            label76.Text = "";
            label75.Text = "";
            label74.Text = "";
            label73.Text = "";
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            //Raport dla klienta
            radioButton4.Checked = true;
            radioButton3.Checked = false;
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            //Raport dla salonu
            radioButton3.Checked = true;
            radioButton4.Checked = false;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            //Menu g³ówne
            tabControl1.SelectedIndex = 0;
            textBox20.Text = "";
            radioButton4.Checked = false;
            radioButton3.Checked = false;
            label53.Visible = true;
            label54.Visible = true;
            label55.Visible = true;
            label82.Text = "";
            label62.Text = "";
            label61.Text = "";
            label60.Text = "";
            label59.Text = "";
            label58.Text = "";
            label57.Text = "";
            label56.Text = "";
            label63.Text = "";
            label64.Text = "";
            label78.Text = "";
            label65.Text = "";
            label66.Text = "";
            label67.Text = "";
            label68.Text = "";
            label80.Text = "";
            label76.Text = "";
            label75.Text = "";
            label74.Text = "";
            label73.Text = "";
        }

        private void button31_Click(object sender, EventArgs e)
        {
            //Raport do pliku
            MessageBox.Show("Opcja w fazie rozwoju");
        }

        //-------------------------------------------Serwis---------------------------------------------------------------------------
        private void button30_Click(object sender, EventArgs e)
        {
            //Powrót do menu g³ównego
            tabControl1.SelectedIndex = 0;
        }

        private void button46_Click(object sender, EventArgs e)
        {
            //Dodaj nowy wpis do serwisu
            DodSerwis formDodajRekord = new DodSerwis();
            formDodajRekord.ShowDialog();
            SqlConnection connection = new SqlConnection(connectionString);
            string querySerw = "SELECT * FROM Serwis";
            SqlDataAdapter adapter2 = new SqlDataAdapter(querySerw, connection);
            DataTable table2 = new DataTable();
            adapter2.Fill(table2);
            dataGridView2.DataSource = table2;
        }

        private void button44_Click(object sender, EventArgs e)
        {
            //Edytuj rekord
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];

                int id = Convert.ToInt32(selectedRow.Cells[0].Value);

                EdytSerwis formEdytujRekord = new EdytSerwis(id);
                formEdytujRekord.ShowDialog();

                SqlConnection connection = new SqlConnection(connectionString);
                string querySerw = "SELECT * FROM Serwis";
                SqlDataAdapter adapter2 = new SqlDataAdapter(querySerw, connection);
                DataTable table2 = new DataTable();
                adapter2.Fill(table2);
                dataGridView2.DataSource = table2;
            }
            else
            {
                MessageBox.Show("Proszê zaznaczyæ rz¹d do edycji.");
            }
        }

        private void button45_Click(object sender, EventArgs e)
        {
            //Usuñ rekord
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView2.SelectedRows[0].Index;
                int idDoUsuniecia = Convert.ToInt32(dataGridView2[0, selectedIndex].Value);

                DialogResult resultdialog = MessageBox.Show("Czy chcesz kontynuowaæ?", "Potwierdzenie", MessageBoxButtons.YesNo);
                if (resultdialog == DialogResult.Yes)
                {
                    string queryString = "DELETE FROM Serwis WHERE ID_Zgloszenia = @id";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(queryString, connection);
                        command.Parameters.AddWithValue("@id", idDoUsuniecia);

                        try
                        {
                            connection.Open();
                            int result = command.ExecuteNonQuery();

                            if (result > 0)
                            {
                                MessageBox.Show("Rekord zosta³ usuniêty.");
                            }
                            else
                            {
                                MessageBox.Show("Rekord nie zosta³ znaleziony.");
                            }
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Wyst¹pi³ b³¹d podczas usuwania rekordu: " + ex.Message);
                        }
                        string querySerw = "SELECT * FROM Serwis";
                        SqlDataAdapter adapter2 = new SqlDataAdapter(querySerw, connection);
                        DataTable table2 = new DataTable();
                        adapter2.Fill(table2);
                        dataGridView2.DataSource = table2;
                    }
                }
            }
            else
            {
                MessageBox.Show("Proszê zaznaczyæ rz¹d do usuniêcia.");
            }
        }

        private void button43_Click(object sender, EventArgs e)
        {
            //Szukaj
            string selectedColumn = comboBox5.SelectedItem.ToString();
            string filterExpression = "";

            if (!string.IsNullOrEmpty(textBox23.Text))
            {
                if (selectedColumn == "Data_rozpoczecia" || selectedColumn == "Data_zakonczenia")
                {
                    string dataWFormacieDDMMYYYY = textBox23.Text;
                    DateTime data;
                    if (DateTime.TryParseExact(dataWFormacieDDMMYYYY, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out data))
                    {
                        string dataWFormacieYYYYMMDD = data.ToString("yyyy-MM-dd");
                        filterExpression = string.Format("{0} = '{1}'", selectedColumn, dataWFormacieYYYYMMDD);
                    }
                }
                else if (selectedColumn == "ID_Zgloszenia" || selectedColumn == "ID_Pojazdu")
                {
                    if (int.TryParse(textBox23.Text, out int liczba))
                    {
                        filterExpression = string.Format("{0} = {1}", selectedColumn, liczba);
                    }
                    else
                    {
                        MessageBox.Show("Wpisz poprawne ID.");
                        return;
                    }
                }
                else
                {
                    filterExpression = string.Format("{0} LIKE '%{1}%'", selectedColumn, textBox23.Text);
                }
            }

            (dataGridView2.DataSource as DataTable).DefaultView.RowFilter = filterExpression;

        }

        private void button42_Click(object sender, EventArgs e)
        {
            //Wyczyœæ
            textBox23.Text = "";
            comboBox5.SelectedIndex = -1;
            SqlConnection connection = new SqlConnection(connectionString);
            string querySerw = "SELECT * FROM Serwis";
            SqlDataAdapter adapter2 = new SqlDataAdapter(querySerw, connection);
            DataTable table2 = new DataTable();
            adapter2.Fill(table2);
            dataGridView2.DataSource = table2;
        }

        //----------------------------------------------------Sprzedane----------------------------------------------------------------------
        private void button29_Click(object sender, EventArgs e)
        {
            //Powrót do menu g³ównego
            tabControl1.SelectedIndex = 0;
        }

        private void button39_Click(object sender, EventArgs e)
        {
            //Edytuj
            if (dataGridView3.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView3.SelectedRows[0];

                int id = Convert.ToInt32(selectedRow.Cells[0].Value);

                EdycjaSprzedane formEdytujRekord = new EdycjaSprzedane(id);
                formEdytujRekord.ShowDialog();

                SqlConnection connection = new SqlConnection(connectionString);
                string querySprz = "SELECT * FROM Sprzedane";
                SqlDataAdapter adapter3 = new SqlDataAdapter(querySprz, connection);
                DataTable table3 = new DataTable();
                adapter3.Fill(table3);
                dataGridView3.DataSource = table3;
            }
            else
            {
                MessageBox.Show("Proszê zaznaczyæ rz¹d do edycji.");
            }
        }

        private void button40_Click(object sender, EventArgs e)
        {
            //Usuñ
            if (dataGridView3.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView3.SelectedRows[0].Index;
                int idDoUsuniecia = Convert.ToInt32(dataGridView3[0, selectedIndex].Value);

                DialogResult resultdialog = MessageBox.Show("Czy chcesz kontynuowaæ?", "Potwierdzenie", MessageBoxButtons.YesNo);
                if (resultdialog == DialogResult.Yes)
                {
                    string getIdKlientaPojazduQuery = "SELECT ID_Klienta, ID_Pojazdu FROM Sprzedane WHERE ID = @id";
                    string updateKlientQuery = "UPDATE Klienci SET ID_Pojazdu = 0 WHERE ID = @idKlienta";
                    string updatePojazdyQuery = "UPDATE Pojazdy SET Cena_sprzedazy = NULL, [Czy_sprzedany] = 0 WHERE ID = @idPojazdu";
                    string deleteQuery = "DELETE FROM Sprzedane WHERE ID = @id";
                    int idKlienta = 0;
                    int idPojazdu = 0;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Pobierz ID klienta i ID pojazdu
                        using (SqlCommand commandGetId = new SqlCommand(getIdKlientaPojazduQuery, connection))
                        {
                            commandGetId.Parameters.AddWithValue("@id", idDoUsuniecia);
                            using (SqlDataReader reader = commandGetId.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    idKlienta = reader["ID_Klienta"] != DBNull.Value ? Convert.ToInt32(reader["ID_Klienta"]) : 0;
                                    idPojazdu = reader["ID_Pojazdu"] != DBNull.Value ? Convert.ToInt32(reader["ID_Pojazdu"]) : 0;
                                }
                            }
                        }

                        // Usuñ rekord
                        using (SqlCommand commandDelete = new SqlCommand(deleteQuery, connection))
                        {
                            commandDelete.Parameters.AddWithValue("@id", idDoUsuniecia);
                            int result = commandDelete.ExecuteNonQuery();

                            if (result > 0)
                            {
                                MessageBox.Show("Rekord zosta³ usuniêty.");
                            }
                            else
                            {
                                MessageBox.Show("Rekord nie zosta³ znaleziony.");
                            }
                        }

                        // Aktualizuj tabelê Klienci
                        /*if (idKlienta != 0)
                        {
                            using (SqlCommand commandUpdateKlient = new SqlCommand(updateKlientQuery, connection))
                            {
                                commandUpdateKlient.Parameters.AddWithValue("@idKlienta", idKlienta);
                                commandUpdateKlient.ExecuteNonQuery();
                            }
                        }*/

                        // Aktualizuj tabelê Pojazdy
                        if (idPojazdu != 0)
                        {
                            using (SqlCommand commandUpdatePojazdy = new SqlCommand(updatePojazdyQuery, connection))
                            {
                                commandUpdatePojazdy.Parameters.AddWithValue("@idPojazdu", idPojazdu);
                                commandUpdatePojazdy.ExecuteNonQuery();
                            }
                        }

                        // Odœwie¿ widok danych
                        string querySprz = "SELECT * FROM Sprzedane";
                        SqlDataAdapter adapter3 = new SqlDataAdapter(querySprz, connection);
                        DataTable table3 = new DataTable();
                        adapter3.Fill(table3);
                        dataGridView3.DataSource = table3;

                        string queryPoj = "SELECT * FROM Pojazdy";
                        SqlDataAdapter adapter1 = new SqlDataAdapter(queryPoj, connection);
                        DataTable table1 = new DataTable();
                        adapter1.Fill(table1);
                        dataGridView1.DataSource = table1;
                    }
                }
            }
            else
            {
                MessageBox.Show("Proszê zaznaczyæ rz¹d do usuniêcia.");
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            //Szukaj
            string selectedColumn = comboBox4.SelectedItem.ToString();
            string filterExpression = "";

            if (!string.IsNullOrEmpty(textBox22.Text))
            {
                if (selectedColumn == "DataSprzedazy")
                {
                    string dataWFormacieDDMMYYYY = textBox22.Text;
                    DateTime data;
                    if (DateTime.TryParseExact(dataWFormacieDDMMYYYY, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out data))
                    {
                        string dataWFormacieYYYYMMDD = data.ToString("yyyy-MM-dd");
                        filterExpression = string.Format("{0} = '{1}'", selectedColumn, dataWFormacieYYYYMMDD);
                    }
                }
                else if (selectedColumn == "ID" || selectedColumn == "ID_Pojazdu" || selectedColumn == "ID_Klienta" || selectedColumn == "ID_Sprzedawcy")
                {
                    if (int.TryParse(textBox22.Text, out int liczba))
                    {
                        filterExpression = string.Format("{0} = {1}", selectedColumn, liczba);
                    }
                    else
                    {
                        MessageBox.Show("Wpisz poprawne ID.");
                        return;
                    }
                }
                else
                {
                    filterExpression = string.Format("{0} LIKE '%{1}%'", selectedColumn, textBox22.Text);
                }
            }

            (dataGridView3.DataSource as DataTable).DefaultView.RowFilter = filterExpression;
        }

        private void button37_Click(object sender, EventArgs e)
        {
            //Wyczyœæ
            textBox22.Text = "";
            comboBox4.SelectedIndex = -1;
            SqlConnection connection = new SqlConnection(connectionString);
            string querySprz = "SELECT * FROM Sprzedane";
            SqlDataAdapter adapter3 = new SqlDataAdapter(querySprz, connection);
            DataTable table3 = new DataTable();
            adapter3.Fill(table3);
            dataGridView3.DataSource = table3;
        }

        //----------------------------------------------------Klienci--------------------------------------------------------------------------
        private void button28_Click(object sender, EventArgs e)
        {
            //Powrót do menu g³ównego
            tabControl1.SelectedIndex = 0;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            //Edytuj
            if (dataGridView4.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView4.SelectedRows[0];

                int id = Convert.ToInt32(selectedRow.Cells[0].Value);

                EdycjaKlienci formEdytujRekord = new EdycjaKlienci(id);
                formEdytujRekord.ShowDialog();

                SqlConnection connection = new SqlConnection(connectionString);
                string queryKli = "SELECT * FROM Klienci";
                SqlDataAdapter adapter4 = new SqlDataAdapter(queryKli, connection);
                DataTable table4 = new DataTable();
                adapter4.Fill(table4);
                dataGridView4.DataSource = table4;
            }
            else
            {
                MessageBox.Show("Proszê zaznaczyæ rz¹d do edycji.");
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            //Usuñ
            if (dataGridView4.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView4.SelectedRows[0].Index;
                int idDoUsuniecia = Convert.ToInt32(dataGridView4[0, selectedIndex].Value);

                DialogResult resultdialog = MessageBox.Show("Czy chcesz kontynuowaæ?", "Potwierdzenie", MessageBoxButtons.YesNo);
                if (resultdialog == DialogResult.Yes)
                {
                    string queryString = "DELETE FROM Klienci WHERE ID = @id";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(queryString, connection);
                        command.Parameters.AddWithValue("@id", idDoUsuniecia);

                        try
                        {
                            connection.Open();
                            int result = command.ExecuteNonQuery();

                            if (result > 0)
                            {
                                MessageBox.Show("Rekord zosta³ usuniêty.");
                            }
                            else
                            {
                                MessageBox.Show("Rekord nie zosta³ znaleziony.");
                            }
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Wyst¹pi³ b³¹d podczas usuwania rekordu: " + ex.Message);
                        }
                        string queryKli = "SELECT * FROM Klienci";
                        SqlDataAdapter adapter4 = new SqlDataAdapter(queryKli, connection);
                        DataTable table4 = new DataTable();
                        adapter4.Fill(table4);
                        dataGridView4.DataSource = table4;
                    }
                }
            }
            else
            {
                MessageBox.Show("Proszê zaznaczyæ rz¹d do usuniêcia.");
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            //Szukaj
            string selectedColumn = comboBox3.SelectedItem.ToString();
            string filterExpression = "";

            if (!string.IsNullOrEmpty(textBox21.Text))
            {
                if (selectedColumn == "Telefon" || selectedColumn == "ID")
                {
                    int liczba = int.Parse(textBox21.Text);
                    filterExpression = string.Format("{0} = {1}", selectedColumn, liczba);
                }
                else
                {
                    filterExpression = string.Format("{0} LIKE '%{1}%'", selectedColumn, textBox21.Text);
                }
            }

            (dataGridView4.DataSource as DataTable).DefaultView.RowFilter = filterExpression;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            //Wyczyœæ
            textBox21.Text = "";
            comboBox3.SelectedIndex = -1;
            SqlConnection connection = new SqlConnection(connectionString);
            string queryKli = "SELECT * FROM Klienci";
            SqlDataAdapter adapter4 = new SqlDataAdapter(queryKli, connection);
            DataTable table4 = new DataTable();
            adapter4.Fill(table4);
            dataGridView4.DataSource = table4;
        }

        //----------------Logowanie---------------------------------------------
        private void button2_Click(object sender, EventArgs e)
        {
            string userId = textBox6.Text;
            string password = textBox24.Text;
            string imie, nazwisko;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT Imie, Nazwisko, Haslo, Stanowisko FROM Pracownicy WHERE ID = @userId";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@userId", userId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            label89.Visible = true;
                        }
                        else
                        {
                            label89.Visible = false;
                            string dbPassword = reader["Haslo"].ToString();
                            string stanowisko = reader["Stanowisko"].ToString();

                            if (dbPassword != password)
                            {
                                label90.Visible = true;
                            }
                            else
                            {
                                button36.Enabled = true;
                                imie = reader["Imie"].ToString();
                                nazwisko = reader["Nazwisko"].ToString();
                                label92.Text = imie + " " + nazwisko;
                                label90.Visible = false;
                                label91.Visible = true;
                                label92.Visible = true;
                                panel1.Visible = false;
                                switch (stanowisko)
                                {
                                    case "Menadzer":
                                        button8.Enabled = true;
                                        button9.Enabled = true;
                                        button10.Enabled = true;
                                        button11.Enabled = true;
                                        break;
                                    case "Zastêpca Menadzera":
                                        button8.Enabled = true;
                                        button9.Enabled = true;
                                        button11.Enabled = true;
                                        break;
                                    case "Sprzedawca":
                                        button8.Enabled = true;
                                        button9.Enabled = true;
                                        break;
                                    default:
                                        MessageBox.Show("Nierozpoznane stanowisko zalogowanej osoby. Ograniczona funkcjonalnoœæ.");
                                        break;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wyst¹pi³ b³¹d: " + ex.Message);
                }
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
            textBox24.Text = "";
            label89.Visible = false;
            label90.Visible = false;
            label91.Visible = false;
            label92.Visible = false;
            panel1.Visible = true;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
            button36.Enabled = false;
        }
    }
}