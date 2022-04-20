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

namespace KasirBaru_Pertemuan7
{
    public partial class Form1 : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;

        Koneksi Konn = new Koneksi();

        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void Bersihkan()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TampilBarang();
            Bersihkan();
        }

        /* Membuat tombol simpan */
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox6.Text.Trim() == "")
            {
                MessageBox.Show("Mohon isikan terlebih dahulu kolom-kolom yang tersedia!");

            }
            else
            {
                SqlConnection conn = Konn.GetConn();
                try
                {
                    cmd = new SqlCommand("INSERT INTO Table_Barang VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Insert Data Berhasil!");
                    TampilBarang();
                    Bersihkan();
                }

                catch (Exception X)
                {
                    MessageBox.Show("Tidak Dapat Menyimpan Data!");
                }
            }
        }
        void TampilBarang()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("Select * from Table_Barang", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Table_Barang");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Table_Barang";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception G)
            {
                MessageBox.Show(G.ToString());
            }
            finally
            {
                conn.Close();
            }
        }



        /*
                private void Form1_Load(object sender, EventArgs e)
                {
                    SqlConnection conn = Konn.GetConn();
                    try
                    {
                        conn.Open();
                        cmd = new SqlCommand("Select * from TBL_BARANG", conn);
                        ds = new DataSet();
                        da = new SqlDataAdapter(cmd);
                        da.Fill(ds, "TBL_BARANG");
                        dataGridView1.DataSource = ds;
                        dataGridView1.DataMember = "TBL_BARANG";
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                    catch (Exception G)
                    {
                        MessageBox.Show(G.ToString());
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
        */

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

    }
}
