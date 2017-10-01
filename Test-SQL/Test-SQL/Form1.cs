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

namespace Test_SQL
{
    public partial class Form1 : Form
    {
        private SqlConnection cn = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string cnStr = "Server = .; Database = Northwind; Integrated security = true";
            cn = new SqlConnection(cnStr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            dataGridView1.DataSource = GetData();
        }
        private DataTable GetData()
        {
            string sql = "SELECT * FROM Customers";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
