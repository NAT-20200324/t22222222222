using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaoDienChinh
{
    public partial class Form1 : Form
    {
        private string luachon;
        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txtTK.Text = "sadsa";
        }
        private void btDangKy_Click(object sender, EventArgs e)
        {
            if (rdHS.Checked == true || rdGV.Checked == true)
            {
                if (rdHS.Checked == true) {
                    luachon = "TableHocSinh";
                }
                else if (rdGV.Checked == true) {
                    luachon = "TableGiaoVien";
                }
                GDDangKy gddk = new GDDangKy(luachon);
                gddk.Show();
            }
            else
            {
                MessageBox.Show("Bạn là học sinh hay giáo viên?");
            }
        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
        }
    }
}
