using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace WindowsFormsApplication37
{
    public partial class sifreunuttum : Form
    {
        public sifreunuttum()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlbaglantisi bgln = new sqlbaglantisi();
            SqlCommand komut = new SqlCommand("Select * from admin Where Email='"+textBox2.Text.ToString()+"'",bgln.baglanti());

            SqlDataReader oku = komut.ExecuteReader();
            while(oku.Read())
            {
                try
                {
                    SmtpClient smtpserver = new SmtpClient();
                    MailMessage mail = new MailMessage();
                    string tarih = DateTime.Now.ToLongDateString();
                    string mailadresin = ("ozlemgurlekk@outlook.com");
                    string sifre = ("192837Og");
                    // string smtpsrvr = "smtp.outlook.com";
                    string smtpsrvr = "smtp-mail.outlook.com";
                    string kime = (oku["Email"].ToString());
                    string konu = ("Şifre Hatırlatma Maili"); //smtp-mail.outlook.com
                    string yaz = ("Sayın,"+oku["Email"].ToString() +"\n"+"Bizden"+ tarih + " Tarihinde Şifre Hatırlatma Talebinde "+
                    "Bulundunuz"+"\n" + "Parolanız:"+ oku["Şİfre"].ToString()+"\nİyi Günler");
                    smtpserver.Credentials = new NetworkCredential(mailadresin, sifre);
                    smtpserver.Port = 587;
                    smtpserver.Host = smtpsrvr;
                    smtpserver.EnableSsl = true;
                    mail.From = new MailAddress(mailadresin);
                    mail.To.Add(kime);
                    mail.Subject = konu;
                    mail.Body= yaz;
                    smtpserver.Send(mail);
                    DialogResult bilgi = new DialogResult();
                    bilgi = MessageBox.Show("Girmiş Olduğunuz Bilgiler Uyuşuyor.Şifreniz Mail Adresinize Gönderilmiştir.");
                }
                catch(Exception Hata)
                {
                    MessageBox.Show("Mail Gönderme Hatası! "+ Hata);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
