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
    public partial class cikis : Form
    {
        public cikis()
        {
            InitializeComponent();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = DateTime.Now.ToShortDateString();
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
           
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void maskedTextBox1_Click(object sender, EventArgs e)
        {
            int x = 3;
            maskedTextBox1.Text = x.ToString();
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5.Text = DateTime.Now.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
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
                sorgu.CommandText = "cikis";
                sorgu.Parameters.Add("tar", SqlDbType.Date);
                sorgu.Parameters.Add("plak", SqlDbType.NChar, 20);
                sorgu.Parameters.Add("ciksaat", SqlDbType.DateTime);
                sorgu.Parameters.Add("ucrt", SqlDbType.Int);
                sorgu.Parameters["tar"].Value = textBox2.Text;
                sorgu.Parameters["plak"].Value = textBox1.Text;
                sorgu.Parameters["ciksaat"].Value = textBox5.Text;
                sorgu.Parameters["ucrt"].Value = maskedTextBox1.Text;
                if (sorgu.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("ARAÇ ÇIKIŞI YAPILDI");
                }
            }
            catch (Exception HATA)
            {
                MessageBox.Show(HATA.Message);
            }
        }
    }
}
