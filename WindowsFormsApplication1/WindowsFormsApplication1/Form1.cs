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

namespace WindowsFormsApplication1
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
            string cnStr = "Server = .; Database = Northwind; Integrated security= true";
            cn = new SqlConnection(cnStr);
            cn.Open();
            string sqlStr = "SELECT * FROM Customers";
            //dataGridView1.DataSource = GetData(sqlStr);
            dataGridView1.DataSource = GetDataList(sqlStr);
        }

        private DataTable GetData(string sqlStr)
        {
            SqlDataAdapter da = new SqlDataAdapter(sqlStr, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private List<object> GetDataList(string sqlStr)
        {
            List<object> list = new List<object>();
            try
            {
                SqlCommand cmd = new SqlCommand(sqlStr, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                string name, CompanyName, ContactName;
                while (dr.Read())
                {
                    name = dr.GetString(0);
                    CompanyName = dr.GetString(1);
                    ContactName = dr.GetString(2);
                    var cust = new
                    {
                        CusID = name,
                        ComName = CompanyName,
                        ConName = ContactName
                    };
                    list.Add(cust);
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return list;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}