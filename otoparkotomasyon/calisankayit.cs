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
    public partial class calisankayit : Form
    {
        public calisankayit()
        {
            InitializeComponent();
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
                sorgu.CommandText = "calekle";
                sorgu.Parameters.Add("tc", SqlDbType.NChar, 11);
                sorgu.Parameters.Add("ad", SqlDbType.NChar, 20);
                sorgu.Parameters.Add("soyad", SqlDbType.NChar, 20);
                sorgu.Parameters.Add("gorev", SqlDbType.NChar, 20);
                sorgu.Parameters["tc"].Value = maskedTextBox1.Text;
                sorgu.Parameters["ad"].Value = textBox1.Text;
                sorgu.Parameters["soyad"].Value = textBox2.Text;
                sorgu.Parameters["gorev"].Value = comboBox1.SelectedItem;
                if (sorgu.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("ÇALIŞAN KAYDI YAPILDI");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            finally
          {
             baglan.Close();
          }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
              baglan.Open();
                sorgu = baglan.CreateCommand();
                sorgu.CommandType = CommandType.StoredProcedure;
                sorgu.CommandText = "iscikar";
                sorgu.Parameters.Add("tc", SqlDbType.NChar, 11);
                sorgu.Parameters["tc"].Value = maskedTextBox2.Text;

                if (sorgu.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("İŞTE ÇIKARILDI..");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            finally
          {
               baglan.Close();
           }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                sorgu = baglan.CreateCommand();
                sorgu.CommandType = CommandType.StoredProcedure;
                sorgu.CommandText = "calara";
                sorgu.Parameters.Add("tc", SqlDbType.NChar, 11);
                sorgu.Parameters["tc"].Value = maskedTextBox3.Text;
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
             baglan.Open();
                sorgu = baglan.CreateCommand();
                sorgu.CommandType = CommandType.StoredProcedure;
                sorgu.CommandText = "guncelle";
                sorgu.Parameters.Add("tc", SqlDbType.NChar, 11);
                sorgu.Parameters.Add("ad", SqlDbType.NChar, 20);
                sorgu.Parameters.Add("soyad", SqlDbType.NChar, 20);
                sorgu.Parameters.Add("gorev", SqlDbType.NChar, 20);
                sorgu.Parameters["tc"].Value = maskedTextBox1.Text;
                sorgu.Parameters["ad"].Value = textBox1.Text;
                sorgu.Parameters["soyad"].Value = textBox2.Text;
                sorgu.Parameters["gorev"].Value = comboBox1.SelectedItem;
                if (sorgu.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("GÜNCELLEME YAPILDI");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
           finally
           {
               baglan.Close();
            }
        }
        
    }
}
