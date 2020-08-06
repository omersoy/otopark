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
    public partial class muhasebe : Form
    {
        public muhasebe()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(Program.sqlConnection);
        SqlCommand sorgu = new SqlCommand();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sorgu = baglan.CreateCommand();

                sorgu.CommandType = CommandType.StoredProcedure;

                sorgu.CommandText = "güntop";
                sorgu.Parameters.Add("tar", SqlDbType.Date);
                sorgu.Parameters["tar"].Value = maskedTextBox1.Text;
     
        
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                sorgu = baglan.CreateCommand();
                sorgu.CommandType = CommandType.StoredProcedure;
                sorgu.CommandText = "toplam";
           

        
                SqlDataAdapter adap = new SqlDataAdapter(sorgu);

                DataSet veri = new DataSet();

                adap.Fill(veri, "Table1");

                dataGridView2.DataSource = veri.Tables["Table1"];


            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
        private void göster()
        {
            try
            {
                sorgu = baglan.CreateCommand();
          
                sorgu.CommandType = CommandType.StoredProcedure;
           
                sorgu.CommandText = "göster";
           
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
