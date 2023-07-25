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
    public partial class admin : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-FUNPM7I;Initial Catalog=marketdepo;Integrated Security=True");
        SqlDataAdapter da;
        SqlCommand komut;
        public admin()
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

        private void Form5_Load(object sender, EventArgs e)
        {
            textBox2.Enabled = false;

            textBox1.Enabled = false;
            verilerigörüntüle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            verilerigörüntüle();
        }
        void temizle()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = "";
            dateTimePicker1.Value = DateTime.Now;
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

        private void button3_Click(object sender, EventArgs e)
        {
            //güncelle
            baglan.Open();
            string sorgu = "UPDATE depo SET UrunTuru=@UrunTuru,DepoGirisTarihi=@DepoGirisTarihi,RafSuresi=@RafSuresi,StokHareketDurumu=@StokHareketDurumu,BelirlenenMinMiktar=@BelirlenenMinMiktar,UrunAdi=@UrunAdi WHERE id=@id";
            komut = new SqlCommand(sorgu, baglan);
            komut.Parameters.AddWithValue("@id", textBox2.Text);
            komut.Parameters.AddWithValue("@UrunTuru", textBox3.Text);
            komut.Parameters.AddWithValue("@DepoGirisTarihi", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@RafSuresi", textBox5.Text);
            komut.Parameters.AddWithValue("@StokHareketDurumu", textBox6.Text);
            komut.Parameters.AddWithValue("@BelirlenenMinMiktar", textBox7.Text);
            komut.Parameters.AddWithValue("@UrunAdi", textBox8.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigörüntüle();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //sil
            baglan.Open();
            string sorgu = "DELETE from depo WHERE id=@id";
            komut = new SqlCommand(sorgu, baglan);
            komut.Parameters.AddWithValue("@id", textBox2.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigörüntüle();

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
