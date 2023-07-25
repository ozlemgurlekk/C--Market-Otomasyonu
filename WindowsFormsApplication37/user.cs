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
using System.Security.Cryptography;

namespace WindowsFormsApplication37
{
    public partial class user : Form
    {

        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-FUNPM7I;Initial Catalog=marketdepo;Integrated Security=True");
        SqlDataAdapter da;
        SqlCommand komut;
        public user()
        {
            InitializeComponent();
        }
        void verilerigörüntüle()
        {



            baglan.Open();
            da = new SqlDataAdapter("SELECT * FROM depo", baglan);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();

        }
        private string Md5(string text)
        {

            MD5 MD5Encrypting = new MD5CryptoServiceProvider();
            byte[] bytes = MD5Encrypting.ComputeHash(Encoding.UTF8.GetBytes(text.ToCharArray()));

            StringBuilder builder = new StringBuilder();
            foreach (var item in bytes)
            {
                builder.Append(item.ToString("x2"));
            }
            return builder.ToString();
        }
        private void listView1_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //ekle
            string sorgu = "INSERT INTO depo (UrunTuru,DepoGirisTarihi,RafSuresi,StokHareketDurumu,BelirlenenMinMiktar,UrunAdi) VALUES (@UrunTuru,@DepoGirisTarihi,@RafSuresi,@StokHareketDurumu,@BelirlenenMinMiktar,@UrunAdi)";
            baglan.Open();
            komut = new SqlCommand(sorgu, baglan);
            komut.Parameters.AddWithValue("@UrunTuru", textBox3.Text);
            komut.Parameters.AddWithValue("@DepoGirisTarihi", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@RafSuresi", textBox5.Text);
            komut.Parameters.AddWithValue("@StokHareketDurumu", textBox6.Text);
            komut.Parameters.AddWithValue("@BelirlenenMinMiktar", textBox7.Text);
            komut.Parameters.AddWithValue("@UrunAdi", textBox8.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigörüntüle();
            temizle();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            verilerigörüntüle();
        }
        void temizle()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox3.Text = textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

            textBox1.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
             
           

        }
    }
}
