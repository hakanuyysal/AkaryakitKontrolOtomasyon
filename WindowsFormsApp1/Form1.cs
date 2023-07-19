using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Data Source=myPc\SQLEXPRESS01;Initial Catalog=Akaryakit_control;Integrated Security=True

        SqlConnection baglanti = new SqlConnection(@"Data Source=myPc\SQLEXPRESS01;Initial Catalog=Akaryakit_control;Integrated Security=True");
        

        
         void liste()
        {
            //kursunsuz95
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select*from YAKIT where YAKITTUR='Kursunsuz95' ", baglanti);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                kursunsuz95.Text = dr[3].ToString();
                progressBar1.Value = int.Parse(dr[4].ToString());
                kursunsuz.Text = dr[4].ToString();
            }
            baglanti.Close();

            //ProDiesel
            baglanti.Open();
            SqlCommand cmd2 = new SqlCommand("select*from YAKIT where YAKITTUR='ProDiesel' ", baglanti);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                prodiesel.Text = dr2[3].ToString();
                progressBar2.Value = int.Parse(dr2[4].ToString());
                prodizel.Text = dr2[4].ToString();
            }
            baglanti.Close();

            //vmaxdiesel
            baglanti.Open();
            SqlCommand cmd3 = new SqlCommand("select*from YAKIT where YAKITTUR='VMaxDiesel' ", baglanti);
            SqlDataReader dr3 = cmd2.ExecuteReader();
            while (dr3.Read())
            {
                vmaxdiesel.Text = dr3[3].ToString();
                progressBar3.Value = int.Parse(dr3[4].ToString());
                vmaxdizel.Text = dr3[4].ToString();
            }
            baglanti.Close();

            //gaz
            baglanti.Open();
            SqlCommand cmd4 = new SqlCommand("select*from YAKIT where YAKITTUR='Gaz' ", baglanti);
            SqlDataReader dr4 = cmd2.ExecuteReader();
            while (dr4.Read())
            {
                gaz.Text = dr4[3].ToString();
                progressBar4.Value = int.Parse(dr4[4].ToString());
                gazz.Text = dr4[4].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand sql5 = new SqlCommand();
            SqlDataReader dr6= sql5.ExecuteReader();
            while (dr6.Read()) {
                label18.Text = dr6[0].ToString();
                baglanti.Close();

            }


        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            liste();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double kursunsu95, litre, tutar;
            kursunsu95=Convert.ToDouble(numericUpDown1.Text);
            litre = Convert.ToDouble(numericUpDown1.Value);
            tutar = kursunsu95 * litre;
            fiyat1.Text=tutar.ToString();


        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            double prodizel, litre, tutar;
            prodizel = Convert.ToDouble(numericUpDown2.Text);
            litre= Convert.ToDouble(numericUpDown2.Value);
            tutar= prodizel * litre;
            fiyat2.Text=tutar.ToString();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            double vmaxdizel, litre, tutar;
            vmaxdizel = Convert.ToDouble(numericUpDown3.Text);
            litre = Convert.ToDouble(numericUpDown3.Value);
            tutar = vmaxdizel * litre;
            textBox7.Text = tutar.ToString();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            double gaz, litre, tutar;
            gaz = Convert.ToDouble(numericUpDown4.Text);
            litre = Convert.ToDouble(numericUpDown4.Value);
            tutar = gaz * litre;
            textBox5.Text = tutar.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value !=0) 
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into HAREKET (PLAKA,YAKITTUR,LITRE,FIYAT) values(@1,@2,@3,@4)",baglanti);
                komut.Parameters.AddWithValue("@1", txtPlaka.Text);
                komut.Parameters.AddWithValue("@2", "kursunsuz 95");
                komut.Parameters.AddWithValue("@3", numericUpDown1.Value);
                komut.Parameters.AddWithValue("@4", textBox5.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                

                baglanti.Open();
                SqlCommand komut2 = new SqlCommand("update KASA set MİKTAR=+@p1", baglanti);
                komut2.Parameters.AddWithValue("@p1", fiyat1.Text);
                komut2.ExecuteNonQuery();
                baglanti.Close();
  

                baglanti.Open();
                SqlCommand komut3 = new SqlCommand("update YAKIT set STOK =-@p1 where YAKITTUR='kursunsuz95'",baglanti);
                komut3.Parameters.AddWithValue("@p1",numericUpDown1.Value);
                komut3.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Satış Yapıldı");
                liste();


            }
        }

        private void fiyat1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
