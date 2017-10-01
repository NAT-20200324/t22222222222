using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //khai báo
using System.Configuration;//khai báo để bắt ngoại lệ

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        private SqlConnection cn = null;  //khai báo đối tượng kết nối.
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string cnStr = "Server = .; Database = Northwind; Integrated security = true"; // kết nối đến đâu.
            cn = new SqlConnection(cnStr); //tạo đối tượng kết nối đến cnStr
            try
            {
                if (cn == null && cn.State == ConnectionState.Open)
                    cn.Open(); // kết nối
            }
            catch (InvalidOperationException ex) //ngoại lệ
            {
                //quên rồi
            }
            catch (SqlException ex) //ngoại lệ (lỗi)
            {
                //hỏi anh mày đi
            }
            catch (ConfigurationException ex)//ngoại lệ
            {
                //cần khai báo để bắt được ngoại lệ.
            }
            MessageBox.Show("ket noi thanh cong.");
            string dsStr = "SELECT * FROM Customers";
            DataSet ds = getData(dsStr);
            dataGridView1.DataSource = ds.Tables[0]; //hiển thị dataset ra dataGridView.
        }
        private DataSet getData(string dsStr)
        {
            //dsStr: muốn lấy dữ liệu từ bảng nào.
            //cn: Database nào.
            SqlDataAdapter da = new SqlDataAdapter(dsStr, cn);
            DataSet ds = new DataSet(); //tạo dataset, dùng cách này thay cho list
            da.Fill(ds); //lưu vào vùng nhớ tạm
            return ds;  
        }
    }
}
