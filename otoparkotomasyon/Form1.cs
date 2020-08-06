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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            giris gir = new giris();
            gir.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cikis cık = new cikis();
            cık.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            calisankayit calısan = new calisankayit();
            calısan.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            muhasebe muh = new muhasebe();
            muh.Show();
        }
        SqlConnection baglan = new SqlConnection(Program.sqlConnection);
        SqlCommand sorgu = new SqlCommand();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sorgu = baglan.CreateCommand();
                sorgu.CommandType = CommandType.StoredProcedure;
                sorgu.CommandText = "ara";
                sorgu.Parameters.Add("plak", SqlDbType.NChar, 11);
                sorgu.Parameters["plak"].Value = textBox1.Text;
                SqlDataAdapter adap = new SqlDataAdapter(sorgu);

                DataSet veri = new DataSet();

                adap.Fill(veri, "Table1");

                dataGridView1.DataSource = veri.Tables["Table1"];
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
    }
}
