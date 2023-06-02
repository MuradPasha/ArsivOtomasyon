using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;

namespace ArsivOtomasyonu
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        public Login()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (textEdit2.Text.Length < 1)
            {
                MessageBox.Show("Lütfen kullanıcı adı ve parola alanını boş bırakmayın.");
            }
            else if (textEdit2.Text.Length < 1)
            {
                MessageBox.Show("Lütfen parola alanını boş bırakmayın.");
            }
            else if (textEdit1.Text.Length < 1)
            {
                MessageBox.Show("Lütfen kullanıcı adı alanını boş bırakmayın.");
            }
            else
            {

                string query = "SELECT COUNT(*) FROM kullanici WHERE kullaniciadi = @Username AND sifre = @Password";
                using (MySqlConnection connection = new MySqlConnection(Func.connectionString))
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", textEdit1.Text);
                    command.Parameters.AddWithValue("@Password", textEdit2.Text);

                    connection.Open();

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count > 0)
                    {
                        this.Hide();
                        //MessageBox.Show("Giriş başarılı.");
                        Form1 fr1 = new Form1();
                        fr1.Show();
                    }
                    else
                    {
                        MessageBox.Show("Lütfen kullanıcı adı ve şifreyi kontrol edin.");
                    }
                }




            }

        }
    }
}