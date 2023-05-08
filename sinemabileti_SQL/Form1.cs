using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace sinemabileti_SQL;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }
    public static SQLiteConnection con = new SQLiteConnection("Data source=.\\sinema1.db;Versiyon=3");
    public static SQLiteDataAdapter adapter = new SQLiteDataAdapter("Select koltukno,adsoyad,filmler,fiyat from sinema1",con);
    public static SQLiteCommand cmd = new SQLiteCommand();
    public static DataTable dt;
    public void Listeleme()
    {
        con.Open();
        dt=new DataTable();
        adapter.Fill(dt);
        dataGridView1.DataSource = dt;
        con.Close();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        con.Open();
        cmd.Connection = con;
        cmd.CommandText = "Insert into sinema1(koltukno,adsoyad,filmler,fiyat)values( '" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text +"')";
        cmd.ExecuteNonQuery();
        con.Close();
        Listeleme();

    }

    private void button2_Click(object sender, EventArgs e)
    {
        DialogResult sonuc = MessageBox.Show("Tablodan seçilen verinin silinmesini istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (sonuc == DialogResult.Yes)
        {
            con.Open();
            cmd.Connection = con;
            int koltuk_no = Convert.ToInt32(dataGridView1.CurrentRow.Cells["koltukno"].Value);
            cmd.CommandText = "Delete from koltukno where ='" + koltuk_no + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            Listeleme();
        }
    }
    private void button4_Click(object sender, EventArgs e)
    {
        Listeleme();
    }

    
}
