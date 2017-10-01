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

namespace WindowsFormsApplication2
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
            string cnStr = "Server = .; Database = LTCSDL_1; Integrated security=true";
            cn = new SqlConnection(cnStr);
            cn.Open();
            if (cn.State == ConnectionState.Open)
            {
                MessageBox.Show("kết nối thành công");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cmdStr = "INSERT INTO [LTCSDL_1].[dbo].[bang-1]([name],[fullname]) VALUES('" + textBox1.Text.ToString() + "','zzzz')";
            SqlCommand cmd = new SqlCommand(cmdStr, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            cn.Close();
            if (cn.State == ConnectionState.Closed)
            {
                MessageBox.Show("đã ngắt kết nối");
            }
           
        }
        private List<object> GetData() { 
            List<object> list = new List<object>();
            string cmdStr = "SELECT * FROM Customers";
            SqlCommand cmd = new SqlCommand(cmdStr,cn);
            SqlDataReader dr = cmd.ExecuteReader();
            string id, name, ContactName;
            while(dr.Read()){
                id = dr.GetString(0);
                name = dr.GetString(1);
                ContactName = dr.GetString(2);
                var Cust = new{
                    CID = id,
                    ComN=name,
                    ConN=ContactName
                };
                list.Add(Cust);
            }
            dr.Close();
            return list;
        }
    }
}
