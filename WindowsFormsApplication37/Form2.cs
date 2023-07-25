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

namespace WindowsFormsApplication37
{
    public partial class Form2 : Form
    {
         

        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-FUNPM7I;Initial Catalog=marketdepo;Integrated Security=True");
        SqlDataAdapter da;
        SqlCommand komut;
        public Form2()
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
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            verilerigörüntüle();


        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ekle
            string sorgu = "INSERT INTO depo (UrunTuru,DepoGirisTarihi,RafSuresi,StokHareketDurumu,BelirlenenMinMiktar,UrunAdi) VALUES (@UrunTuru,@DepoGirisTarihi,@RafSuresi,@StokHareketDurumu,@BelirlenenMinMiktar,@UrunAdi)";
            baglan.Open();
            komut = new SqlCommand(sorgu, baglan);
            komut.Parameters.AddWithValue("@UrunID", textBox2.Text);
            komut.Parameters.AddWithValue("@UrunTuru", textBox3.Text);
            komut.Parameters.AddWithValue("@DepoGirisTarihi", textBox4.Text);
            komut.Parameters.AddWithValue("@RafSuresi", textBox5.Text);
            komut.Parameters.AddWithValue("@StokHareketDurumu", textBox6.Text);
            komut.Parameters.AddWithValue("@BelirlenenMinMiktar", textBox7.Text);
            komut.Parameters.AddWithValue("@UrunAdi", textBox8.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigörüntüle();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //güncelle
            baglan.Open();
            string sorgu = "UPDATE depo SET UrunTuru=@UrunTuru,DepoGirisTarihi=@DepoGirisTarihi,RafSuresi=@RafSuresi,StokHareketDurumu=@StokHareketDurumu,BelirlenenMinMiktar=@BelirlenenMinMiktar,UrunAdi=@UrunAdi WHERE UrunID=@UrunID";
            komut = new SqlCommand(sorgu, baglan);
            komut.Parameters.AddWithValue("@UrunID", textBox2.Text);
            komut.Parameters.AddWithValue("@UrunTuru", textBox3.Text);
            komut.Parameters.AddWithValue("@DepoGirisTarihi", textBox4.Text);
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
            string sorgu = "DELETE from depo WHERE UrunID=@UrunID";
            komut = new SqlCommand(sorgu, baglan);
            komut.Parameters.AddWithValue("@UrunID", textBox2.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigörüntüle();


        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            

            textBox2.Enabled = false;


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
   }
}
