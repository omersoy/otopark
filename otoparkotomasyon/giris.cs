using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace otoparkotomasyon
{
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = DateTime.Now.ToLongTimeString();
        }
        SqlConnection baglan = new SqlConnection(Program.sqlConnection);
        SqlCommand sorgu = new SqlCommand();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                sorgu = baglan.CreateCommand();
                sorgu.CommandType = CommandType.StoredProcedure;
                sorgu.CommandText = "giris";
                sorgu.Parameters.Add("aractur", SqlDbType.NChar, 20);
                sorgu.Parameters.Add("plak", SqlDbType.NChar, 20);
                sorgu.Parameters.Add("girsaat", SqlDbType.DateTime);
                sorgu.Parameters["aractur"].Value = comboBox1.SelectedItem;
                sorgu.Parameters["plak"].Value = textBox1.Text;
                sorgu.Parameters["girsaat"].Value = textBox2.Text;
                if (sorgu.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("ARAÇ GİRİŞİ YAPILDI");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
