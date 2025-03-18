using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BankApp
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy hh:mm tt"; // Ensure AM/PM is displayed
            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0LALPAV\SQLEXPRESS;Initial Catalog=BankApp;persist security info=True;Integrated Security=SSPI;");
            try
            {
                conn.Open();

                int clientId = Form3.Salveaza.ClientId;

                string query = "SELECT Nume, Prenume FROM Client WHERE ClientID = @clientId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@clientId", clientId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBox1.Text = $"{reader["Nume"]} {reader["Prenume"]}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDateTime = dateTimePicker1.Value;

            int hour = selectedDateTime.Hour;
            int minute = selectedDateTime.Minute;

            if (minute < 30)
            {
                minute = 0;
            }
            else if (minute > 30)
            {
                minute = 0;
                hour += 1;
            }
            else
            {
                minute = 30;
            }

            if (hour < 8)
            {
                hour = 8;
                minute = 0;
            }
            else if (hour >= 16)
            {
                hour = 15;
                minute = 30;
            }

            dateTimePicker1.Value = new DateTime(selectedDateTime.Year, selectedDateTime.Month, selectedDateTime.Day, hour, minute, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0LALPAV\SQLEXPRESS;Initial Catalog=BankApp;persist security info=True;Integrated Security=SSPI;");
            try
            {
                conn.Open();

                int clientId = Form3.Salveaza.ClientId;

                DateTime dataInregistrare = DateTime.Now;

                DateTime data = dateTimePicker1.Value;

                if (data < DateTime.Now)
                {
                    MessageBox.Show("Vă rugăm să alegeți o dată validă", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Random random = new Random();
                int numar = random.Next();

                string check = "SELECT COUNT(*) FROM Programare WHERE Data = @data";

                using (SqlCommand checkCmd = new SqlCommand(check, conn))
                {
                    checkCmd.Parameters.AddWithValue("@data", data);

                    int programariCount = (int)checkCmd.ExecuteScalar();

                    if (programariCount > 0)
                    {
                        MessageBox.Show("Această dată este ocupată. Vă rugăm să alegeți una disponibilă", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                string insertQuery = @"
                INSERT INTO Programare (ClientID, Numar, DataInregistrare, Data) 
                OUTPUT inserted.Numar
                VALUES (@clientId, @Numar, @dataInregistrare, @data)
                ";

                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@clientId", clientId);
                    cmd.Parameters.AddWithValue("@Numar", numar);
                    cmd.Parameters.AddWithValue("@dataInregistrare", dataInregistrare);
                    cmd.Parameters.AddWithValue("@data", data);

                    string generatedNumar = cmd.ExecuteScalar().ToString();

                    MessageBox.Show($"Rezervarea a fost salvată cu succes. Numar: {generatedNumar}", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving reservation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
