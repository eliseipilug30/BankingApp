using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankApp
{
    public partial class Form9 : Form
    {
        private SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0LALPAV\SQLEXPRESS;Initial Catalog=BankApp;persist security info=True;Integrated Security=SSPI;");
        private int clientID;
        private string numarContSelectat;
        private string valutaContExpeditor;
        private decimal sumaContExpeditor;
        private string numarContDestinatar;

        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbcontDest.SelectedIndex != -1)
            {
                numarContDestinatar = cmbcontDest.SelectedItem.ToString();
                string valutaContDestinatar = ""; 

                try
                {
                    conn.Open();

                    string query = "SELECT Moneda FROM Cont WHERE Numar = @numarContDestinatar";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@numarContDestinatar", numarContDestinatar);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        valutaContDestinatar = reader["Moneda"].ToString();
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving destination account currency: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }

                if (valutaContExpeditor != valutaContDestinatar)
                {
                    MessageBox.Show("Vă rugăm să selectați conturi cu aceeași valută!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TextboxSuma.Enabled = true;
                    TextboxSuma.Focus();
                }
            }
            else
            {
                MessageBox.Show("Vă rugăm să selectați un cont pentru destinatar!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            clientID = Form3.Salveaza.ClientId;
            LoadConturi();
        }

        private void LoadConturi()
        {
            try
            {
                conn.Open();

                string query = "SELECT Numar FROM Cont WHERE ClientID = @clientID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@clientID", clientID);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    comConturiExped.Items.Add(reader["Numar"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading accounts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void LoadConturiRamase()
        {
            try
            {
                conn.Open();

                string query = "SELECT Numar FROM Cont WHERE ClientID != @clientID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@clientID", Form3.Salveaza.ClientId);

                SqlDataReader reader = cmd.ExecuteReader();

                cmbcontDest.Items.Clear();

                while (reader.Read())
                {
                    cmbcontDest.Items.Add(reader["Numar"].ToString());
                }

                cmbcontDest.Visible = true;

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading remaining accounts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void comConturiExped_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnselcntexp_Click(object sender, EventArgs e)
        {
            if (comConturiExped.SelectedIndex != -1)
            {
                numarContSelectat = comConturiExped.SelectedItem.ToString();
                MessageBox.Show($"Ați selectat contul cu numărul: {numarContSelectat}", "Cont selectat", MessageBoxButtons.OK, MessageBoxIcon.Information);

                try
                {
                    conn.Open();
                    string query = "SELECT Moneda, Suma FROM Cont WHERE Numar = @numarContSelectat";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@numarContSelectat", numarContSelectat);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        valutaContExpeditor = reader["Moneda"].ToString();
                        sumaContExpeditor = (decimal)reader["Suma"];
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving account currency and balance: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Vă rugăm să selectați un cont", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIncarca_Click(object sender, EventArgs e)
        {
            LoadConturiRamase();
        }

        private void btnTrimite_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextboxSuma.Text) && decimal.TryParse(TextboxSuma.Text, out decimal sumaTrimisa))
            {
                if (string.IsNullOrEmpty(numarContDestinatar))
                {
                    MessageBox.Show("Vă rugăm să selectați un cont pentru destinatar!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (sumaTrimisa < 5)
                {
                    MessageBox.Show($"Introduceți o sumă de minim 5 {valutaContExpeditor}!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (sumaTrimisa <= sumaContExpeditor)
                {
                    try
                    {
                        conn.Open();
                        SqlTransaction transaction = conn.BeginTransaction();

                        string queryUpdateSume = @"
                        UPDATE Cont 
                        SET Suma = 
                            CASE 
                                WHEN Numar = @numarContExpeditor THEN Suma - @sumaTrimisa 
                                WHEN Numar = @numarContDestinatar THEN Suma + @sumaTrimisa 
                            END
                        WHERE Numar IN (@numarContExpeditor, @numarContDestinatar)";

                        SqlCommand cmdUpdateSume = new SqlCommand(queryUpdateSume, conn, transaction);
                        cmdUpdateSume.Parameters.AddWithValue("@sumaTrimisa", sumaTrimisa);
                        cmdUpdateSume.Parameters.AddWithValue("@numarContExpeditor", numarContSelectat);
                        cmdUpdateSume.Parameters.AddWithValue("@numarContDestinatar", numarContDestinatar);

                        int rowsAffected = cmdUpdateSume.ExecuteNonQuery();

                        if (rowsAffected == 2) 
                        {
                            transaction.Commit();
                            MessageBox.Show("Tranzacție inițiată cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); 
                        }
                        else
                        {
                            transaction.Rollback();
                            MessageBox.Show("Fonduri insuficiente!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Eroare la efectuarea tranzacției: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Fonduri insuficiente!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vă rugăm să introduceți o sumă validă!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cmbcontDest_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
