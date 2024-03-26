using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace TieuLuan
{
    public partial class NhapSanPham : Form
    {
        CSDL_NhapSanPham csdl = new CSDL_NhapSanPham();
        public NhapSanPham()
        {
            InitializeComponent();
        }
        public void loadLoai()
        {
            DataTable dt = csdl.loadLoai();
            cbo_loai.DataSource = dt;
            cbo_loai.DisplayMember = "TENLOAI";
            cbo_loai.ValueMember = "MALOAI";
        }
        public void loadNhaSanXuat()
        {
            string[] name = { "Việt Nam", "Trung Quốc", "Thái Lan", "Mỹ", "Malaysia", "Pháp", "Đức", "Đài Loan", "Nhật Bản", "Singapore" };
            cbo_noiSanXuat.Items.AddRange(name);
        }
        public void loadAnh()
        {
            string[] name = { "1", "2", "3", "4", "5" };
            foreach(string x in name)
            {
                cbo_anh.Items.Add("Hinh" + x );
            }
        }
        public void focus_tenSP()
        {
            txt_tenSanPham.SelectionStart = txt_tenSanPham.Text.Trim().Length;
            txt_tenSanPham.Focus();
        }
        private void NhapSanPham_Load(object sender, EventArgs e)
        {
            loadLoai();
            txt_tenSanPham.Focus();
            loadNhaSanXuat();
            cbo_noiSanXuat.SelectedIndex = 0;
            focus_tenSP();
            loadAnh();
            cbo_anh.SelectedIndex = 0;
        }

        private void btn_themLoai_Click(object sender, EventArgs e)
        {
            ThemLoai frm = new ThemLoai();
            frm.Show();
            this.Hide();
        }
        public void lamMoi()
        {
            txt_tenSanPham.Text = txt_tienVon.Text = txt_soLuong.Text = txt_soChieu.Text = txt_moTa.Text  = txt_giaSanPham.Text = txt_congSuat.Text = string.Empty;
            cbo_noiSanXuat.SelectedIndex = 0;
            cbo_loai.SelectedIndex = 0;
        }
        private void btn_lamMoi_Click(object sender, EventArgs e)
        {
            lamMoi();
            focus_tenSP();
        }
        public bool kiemTraTrong()
        {
            if (txt_congSuat.Text == string.Empty || txt_giaSanPham.Text == string.Empty || txt_moTa.Text == string.Empty || txt_soChieu.Text == string.Empty || txt_soLuong.Text == string.Empty || txt_tenSanPham.Text == string.Empty || txt_tienVon.Text == string.Empty || dateTimePicker.Text == string.Empty)
                return true;
            return false;
        }
        private void btn_luu_Click(object sender, EventArgs e)
        {
            if(kiemTraTrong())
            {
                MessageBox.Show("Thông tin chưa đầy đủ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string name = csdl.maxMaSP();
            string maSP;
            if (name == null)
                maSP = "SP-0";
            else
                maSP = "SP-" + (int.Parse(name.Substring(3)) + 1).ToString();
            //if (csdl.kiemTraKhoaTonTai(txt_maSanPham.Text))
            //{
            //    MessageBox.Show("Mã sản phẩm đã tồn tại trong danh sách!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            string date = dateTimePicker.Value.Day.ToString() + "/" + dateTimePicker.Value.Month.ToString()+"/" + dateTimePicker.Value.Year.ToString();
            if (csdl.them(maSP, txt_tenSanPham.Text, txt_giaSanPham.Text, txt_tienVon.Text, txt_congSuat.Text, txt_soChieu.Text, cbo_loai.SelectedValue.ToString(), cbo_noiSanXuat.SelectedItem.ToString(), txt_moTa.Text, cbo_anh.SelectedItem.ToString() + ".png", txt_soLuong.Text,date))
            {
                MessageBox.Show("Thêm thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lamMoi();
                focus_tenSP();
            }
            else
                MessageBox.Show("Thêm thất bại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void NhapSanPham_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question); ;
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void cbo_anh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_anh.SelectedItem == null)
                return;
            pictureBox1.Image=new Bitmap(Application.StartupPath + "\\images\\"+cbo_anh.SelectedItem.ToString()+".png");
        }

        private void btn_previous_Click(object sender, EventArgs e)
        {
            foreach (Form item in Application.OpenForms)
            {
                if (item.Text == "TrangChu")
                {
                    item.Show();
                    this.Hide();
                    break;
                }
            }
        }

        private void txt_giaSanPham_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
