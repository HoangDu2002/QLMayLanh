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
    public partial class TrangChu : Form
    {
        string quyenHan;
        public TrangChu(string quyenHan)
        {
            InitializeComponent();
            this.quyenHan = quyenHan;
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            foreach (Form item in Application.OpenForms)
            {
                if (item.Text == "ThongKe")
                {
                    item.Show();
                    this.Hide();
                    return;
                }
            }
            ThongKe frm = new ThongKe();
            frm.Show();
            this.Hide();
        }

        private void btn_ThemSanPhamMoi_Click(object sender, EventArgs e)
        {
            foreach (Form item in Application.OpenForms)
            {
                if (item.Text == "NhapSanPham")
                {
                    item.Show();
                    this.Hide();
                    return;
                }
            }
            NhapSanPham frm = new NhapSanPham();
            frm.Show();
            this.Hide();            
        }

        private void btn_TaoDonHangMoi_Click(object sender, EventArgs e)
        {
            foreach (Form item in Application.OpenForms)
            {
                if (item.Text == "TaoDonHang")
                {
                    item.Show();
                    this.Hide();
                    return;
                }
            }
            TaoDonHang frm = new TaoDonHang();
            frm.Show();
            this.Hide();
        }

        private void btn_DanhSach_Click(object sender, EventArgs e)
        {
            foreach (Form item in Application.OpenForms)
            {
                if (item.Text == "SanPham")
                {
                    item.Show();
                    this.Hide();
                    return;
                }
            }
            SanPham frm = new SanPham();
            frm.Show();
            this.Hide();
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            if (quyenHan == "NV")
            {
                btn_ThemSanPhamMoi.Enabled = btnDsUser.Enabled = label4.Enabled = false;
            }
        }

        private void btnDsUser_Click(object sender, EventArgs e)
        {
            foreach (Form item in Application.OpenForms)
            {
                if (item.Text == "DsUser")
                {
                    item.Show();
                    this.Hide();
                    return;
                }
            }
            DsUser frm = new DsUser();
            frm.Show();
            this.Hide();
        }
    }
}
