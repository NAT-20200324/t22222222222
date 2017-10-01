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
using System.Configuration;

namespace GiaoDienChinh
{
    public partial class GDDangKy : Form
    {
        private string luachon;
        private SqlConnection cn = null;
        public GDDangKy(string str)
        {
            InitializeComponent();
            luachon = str;
        }
        private void GDDangKy_Load(object sender, EventArgs e)
        {
            string cnStr = "Server = .; Database = UDToanLop3; Integrated security = true";
            cn = new SqlConnection(cnStr);
            try
            {
                if (cn != null && cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Cannot open a connection without specifying a data source or server" + ex.Message);
                //Không thể mở một kết nối mà không nêu rõ nguồn dữ liệu hoặc máy chủ
            }
            catch (SqlException ex)
            {
                MessageBox.Show("A connection-level error occurred while opening the connection" + ex.Message);
                //Đã xảy ra lỗi kết nối cấp độ khi mở kết nối
            }
            catch (ConfigurationException ex)
            {
                MessageBox.Show("There are two entries with the same name in the <localdb instances> section" + ex.Message);
                //Có hai mục có cùng tên trong phần <localdb instances>
            }
        }
        private void btDangKy_Click(object sender, EventArgs e)
        {
            if (txtDKMK.Text != txtNLMK.Text) {
                MessageBox.Show("Nhập lại mật khẩu.");
            }
            else if (txtDKTK.Text == ""|| txtDKMK.Text == "" || txtDKHo.Text == "" || txtDKTen.Text == "") {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
            }
            else
            {
                string cmdStr = "Insert into [UDToanLop3].[dbo].[" + luachon + "] values('" + txtDKTK.Text + "','" + txtDKMK.Text + "','" + txtDKHo.Text + "','" + txtDKTen.Text + "','" + txtDKTenDem.Text + "')";
                SqlCommand cmd = new SqlCommand(cmdStr, cn);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đăng ký thành công");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

    }
}
