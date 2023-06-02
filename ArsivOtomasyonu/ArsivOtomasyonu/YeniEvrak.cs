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
    public partial class YeniEvrak : DevExpress.XtraEditors.XtraForm
    {
        public YeniEvrak()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

        }

        private void YeniEvrak_Load(object sender, EventArgs e)
        {
            pdfViewer1.DocumentFilePath = @"a.pdf";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fr1 = new Form1();
            fr1.Show();
        }

        private void YeniEvrak_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        string selectedFilePath = "";
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Bir dosya seçin";
            openFileDialog.Filter = "Pdf Dosyası|*.pdf;*.pdf;";
            //openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = openFileDialog.FileName;
                pdfViewer1.DocumentFilePath = selectedFilePath;
            }
            
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Onizleme onizle = new Onizleme();

            if (selectedFilePath == "")
                onizle.pdfViewer1.DocumentFilePath = "a.pdf";
            else
            onizle.pdfViewer1.DocumentFilePath = selectedFilePath;
            onizle.Show();
        }
        

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            
            string query = "INSERT INTO evrak (evrakAd, emanetVerildi, Aciklama, tarih, tur, dosyaYolu) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5, @Value6)";

            using (MySqlConnection connection = new MySqlConnection(Func.connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Value1", textEdit1.Text);
                command.Parameters.AddWithValue("@Value2", "Verilmedi");
                command.Parameters.AddWithValue("@Value3", memoExEdit1.Text);
                command.Parameters.AddWithValue("@Value4", dateEdit1.Text);
                command.Parameters.AddWithValue("@Value5", comboBoxEdit1.Text);
                command.Parameters.AddWithValue("@Value6", selectedFilePath);


                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if(rowsAffected >= 1)
                    MessageBox.Show("Kayıt başarılı.");
                else
                    MessageBox.Show("Kayıt sırasında bir sorun oluştu.");
            }
        }

    }
}