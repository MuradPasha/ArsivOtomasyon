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
    public partial class Arsiv : DevExpress.XtraEditors.XtraForm
    {
        public Arsiv()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fr1 = new Form1();
            fr1.Show();
        }
        void GridDoldur()
        {          
            string query = "SELECT * FROM evrak";
            //string query = "SELECT * FROM Table1 INNER JOIN Table2 ON Table1.Id = Table2.Table1Id";
            using (MySqlConnection connection = new MySqlConnection(Func.connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);
                gridControl1.DataSource = dataTable;
                
            }
        }
        void TureGoreGrid()
        {
            string query = "SELECT * FROM evrak WHERE tur='"+comboBoxEdit1.Text+"'";
            //string query = "SELECT * FROM Table1 INNER JOIN Table2 ON Table1.Id = Table2.Table1Id";
            using (MySqlConnection connection = new MySqlConnection(Func.connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);
                gridControl1.DataSource = dataTable;

            }
        }
        void TariheGoreGrid()
        {
            string query = "SELECT * FROM evrak WHERE tarih='" + dateEdit1.Text + "'";
            //string query = "SELECT * FROM evrak INNER JOIN emanet ON evrak.evrakID = emanet.evrakID";
            using (MySqlConnection connection = new MySqlConnection(Func.connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);
                gridControl1.DataSource = dataTable;

            }
        }
        private void Arsiv_Load(object sender, EventArgs e)
        {
            GridDoldur();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            TureGoreGrid();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridControl1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void gridControl1_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void gridControl1_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {
            
        }

        private void gridControl1_Enter(object sender, EventArgs e)
        {
            
        }

        private void gridControl1_MouseCaptureChanged(object sender, EventArgs e)
        {
            object CellValue = gridView1.GetFocusedRowCellValue("dosyaYolu");
            string yol = CellValue.ToString();
            pdfViewer1.DocumentFilePath = yol;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            TariheGoreGrid();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            GridDoldur();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            Onizleme onizle = new Onizleme();
            onizle.pdfViewer1.DocumentFilePath = pdfViewer1.DocumentFilePath;
            onizle.Show();
        }
    }
}