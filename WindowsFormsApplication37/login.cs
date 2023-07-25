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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-FUNPM7I;Initial Catalog=marketdepo;Integrated Security=True");
        SqlDataReader dr;
        SqlCommand com;
        
        public Form1()
        {
            InitializeComponent();
            Init_Data();
        }
       
        string hash = "";
        string Encrypt(string text)
        {
            byte[] data = Encoding.Default.GetBytes(text);
            using (MD5CryptoServiceProvider md5= new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(Encoding.Default.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider()
                {
                    Key = keys,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                })
                {
                    ICryptoTransform transform = tripleDES.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);


                }
            }
        }
       

        

         

        private void Form1_Load(object sender, EventArgs e)
        {
             
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";//şifre
            
        }
 

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";//email
             


        }




        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sifreunuttum sifreunut = new sifreunuttum();
            sifreunut.Show();
            this.Hide();
            
           

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
          // this.Hide();

            if (textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Şifre veya e mail boş geçilemez.", "UYARI");
            }

            string Email = textBox3.Text;
            string Şifre = textBox2.Text;

          //  textBox2.Text = Encrypt(//);
           

            con.Open();
            SqlCommand command = new SqlCommand("Select * from admin where Email='"+Email+"'", con);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (Email == reader["Email"].ToString().TrimEnd() && Şifre == reader["Şİfre"].ToString().TrimEnd())
                {
                    if (reader["Rol"].ToString()== 1.ToString())
                    {
                        admin frm = new admin();
                        frm.ShowDialog();
                    }
                    else if (reader["Rol"].ToString() == 2.ToString())
                    {
                        user frm = new user();
                        frm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Email veya şifre hatalı.","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                //com = new SqlCommand("INSERT INTO admin (Email,Şifre) values (@Email,@Şİfre)", con);
                //com.Parameters.AddWithValue("@Email", textBox3.Text);
                //com.Parameters.AddWithValue("@Şİfre", textBox2.Text);

            }
            con.Close();
           /*   if (isThere)
            {
                MessageBox.Show("Başarıyla Giriş Yaptınız!", "Program");


            }

            
            else
            {
                MessageBox.Show("Giriş Yapamadınız!", "Program");


            }
            */
        
            
        
             

             

                
        }
        private void Init_Data()
        {
            if(Properties.Settings.Default.Email!=string.Empty)
            {
                if(Properties.Settings.Default.BeniHatırla==true)
                {
                    textBox3.Text = Properties.Settings.Default.Email;
                    textBox2.Text = Properties.Settings.Default.Şifre;
                    checkBox1.Checked = true;


                }
                else
                {
                    textBox3.Text = Properties.Settings.Default.Email;
                }
            }
        }
        private void Save_Data()
        {
            if(checkBox1.Checked)
            {
                Properties.Settings.Default.Email = textBox3.Text;
                Properties.Settings.Default.Şifre = textBox2.Text;
                Properties.Settings.Default.BeniHatırla = true;
                Properties.Settings.Default.Save();
            }
            else
            {

                Properties.Settings.Default.Email = "";
                Properties.Settings.Default.Şifre = "";
                Properties.Settings.Default.BeniHatırla = false;
                Properties.Settings.Default.Save();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        // @ işareti
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '@')
            {
                e.Handled = false;

               

            }
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
            //MessageBox.Show("Lütfen Geçerli Email Adresi Girin!");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider(); // md5
            byte[] dizi = Encoding.UTF8.GetBytes(textBox2.Text);
            dizi = md5.ComputeHash(dizi);
            StringBuilder sb = new StringBuilder();

        }
    }
}
