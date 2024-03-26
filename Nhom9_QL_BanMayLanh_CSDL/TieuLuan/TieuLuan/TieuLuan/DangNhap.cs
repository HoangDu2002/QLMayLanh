using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TieuLuan
{
    public partial class DangNhap : Form
    {
        CSDL_user dt = new CSDL_user();
        public DangNhap()
        {
            InitializeComponent();
        }
        public static string ID_USER = "";
        public static string QUYENHAN = "";
        private void button1_Click(object sender, EventArgs e)
        {
            ID_USER = dt.getID(txtTenTK.Text, txtMK.Text);
            if (ID_USER != "")
            {

                QUYENHAN = dt.getQH(ID_USER);
                if (QUYENHAN == "QT")
                {
                    TrangChu fmain = new TrangChu(QUYENHAN);
                    fmain.Show();
                    this.Hide();
                }
                else if (QUYENHAN == "NV")
                {
                    TrangChu fmain = new TrangChu(QUYENHAN);
                    fmain.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Tài khoản và mật khẩu không đúng !");
            }
        }

        private void txtMK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
