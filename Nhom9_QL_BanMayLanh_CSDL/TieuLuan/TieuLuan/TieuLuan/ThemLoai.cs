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
    public partial class ThemLoai : Form
    {
        CSDL_ThemLoai csdl = new CSDL_ThemLoai();
        public ThemLoai()
        {
            InitializeComponent();
        }
        public void Enable_txt(bool value)
        {
            txt_themMaLoai.Enabled = value;
            txt_themTenLoai.Enabled = value;
        }
        public void Enable_btn(bool value)
        {
            btn_suaLoai.Enabled=btn_themLoai.Enabled=btn_xoa.Enabled=value;
        }
        public void loadCbo_NSX()
        {
            string maNSX = csdl.timMaNSX(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            for (int i = 0; i < cbo_nhaSanXuat.Items.Count; i++)
            {
                cbo_nhaSanXuat.SelectedIndex = i;
                string name = cbo_nhaSanXuat.SelectedValue.ToString();
                if (name.Equals(maNSX))
                {
                    return;
                }
            }
        }
        private void ThemLoai_Load(object sender, EventArgs e)
        {
            DataTable dt = csdl.loadView("");
            Enable_btn(false);
            Enable_txt(false);
            txt_themTenLoai.Enabled = true;
            btn_themLoai.Enabled = true;
            loadNhaSanXuat(csdl.loadNhaSanXuat());
            loadView(dt);
            bingDing(dt);
            loadCbo_NSX();
            txt_themTenLoai.SelectionStart = txt_themTenLoai.Text.Trim().Length;
            txt_themTenLoai.Focus();
            cbo_nhaSanXuat.SelectedIndex = 0;
            dataGridView1.AllowUserToAddRows = false;
        }
        public void loadNhaSanXuat(DataTable dt)
        {
            cbo_nhaSanXuat.DataSource = dt;
            cbo_nhaSanXuat.DisplayMember = "TENNSX";
            cbo_nhaSanXuat.ValueMember = "MANSX";
        }
        public void loadView(DataTable dt)
        {
            dataGridView1.DataSource = dt;
        }
        public void bingDing(DataTable dt)
        {
            txt_themMaLoai.DataBindings.Clear();
            txt_themTenLoai.DataBindings.Clear();
            txt_themMaLoai.DataBindings.Add("text", dt, "MALOAI");
            txt_themTenLoai.DataBindings.Add("text", dt, "TENLOAI");
        }
        private void btn_previous_Click(object sender, EventArgs e)
        {
            NhapSanPham frm = new NhapSanPham();
            frm.Show();
            this.Hide();
        }

        private void ThemLoai_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question); ;
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_themTenLoai.SelectionStart = txt_themTenLoai.Text.Trim().Length;
            txt_themTenLoai.Focus();
            if (dataGridView1.CurrentRow == null)
                return;
            btn_suaLoai.Enabled = true;
            btn_xoa.Enabled = true;
            string maNSX = csdl.timMaNSX(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            loadCbo_NSX();
        }

        private void cbo_nhaSanXuat_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbo_nhaSanXuat.SelectedItem == null)
                return;
            if (cbo_nhaSanXuat.SelectedValue.ToString().Equals("chon"))
                loadView(csdl.loadView(""));
            else
                loadView(csdl.loadView(cbo_nhaSanXuat.SelectedValue.ToString()));
        }

        private void btn_themLoai_Click(object sender, EventArgs e)
        {
            if (cbo_nhaSanXuat.SelectedIndex == 0||txt_themMaLoai.Text==string.Empty||txt_themTenLoai.Text==string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập tên sản phẩm hoặc tên nhà sản xuất", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string name = csdl.maxMaLoai();
            string maLoai;
            if (name == null)
                maLoai = "AirC-0";
            else
                maLoai = "AirC-" + (int.Parse(name.Substring(5)) + 1).ToString();
            if (csdl.them(maLoai, txt_themTenLoai.Text, cbo_nhaSanXuat.SelectedValue.ToString()))
                MessageBox.Show("Thêm thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                MessageBox.Show("Thêm thất bại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            loadView(csdl.loadView(""));
            txt_themTenLoai.SelectionStart = txt_themTenLoai.Text.Trim().Length;
        }

        private void btn_suaLoai_Click(object sender, EventArgs e)
        {
            if (cbo_nhaSanXuat.SelectedIndex == 0 || txt_themTenLoai.Text == string.Empty)
            {
                MessageBox.Show("Thông tin chưa đầy đủ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //if (!csdl.kiemTraKhoaTonTai(txt_themMaLoai.Text))
            //{
            //    MessageBox.Show("Không tìm thấy mã loại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            if (csdl.sua(txt_themMaLoai.Text, txt_themTenLoai.Text, cbo_nhaSanXuat.SelectedValue.ToString()))
                MessageBox.Show("Sửa thành công","",MessageBoxButtons.OK,MessageBoxIcon.Information);
            else
            {
                MessageBox.Show("Sửa thất bại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            loadView(csdl.loadView(""));
            txt_themTenLoai.SelectionStart = txt_themTenLoai.Text.Trim().Length;
            btn_xoa.Enabled = false;
            btn_suaLoai.Enabled = false;
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có chắc chắn muốn xóa!", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                return;
            if (dataGridView1.CurrentRow==null)
            {
                MessageBox.Show("Chưa chọn thông tin trên bảng để xóa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
          
            string kq = string.Empty;
            for (int i= dataGridView1.SelectedRows.Count-1;i>=0;i--)
            {
                string maLoai = dataGridView1.SelectedRows[i].Cells[0].Value.ToString();
                if (csdl.kiemTraMaLoaiBangSanPham(maLoai))
                {
                    if (kq != string.Empty)
                        kq += ", ";
                    kq += maLoai.Trim();
                }
                else
                    csdl.xoa(maLoai);
            }

          
            loadView(csdl.loadView(""));
            txt_themTenLoai.SelectionStart = txt_themTenLoai.Text.Trim().Length;
            btn_xoa.Enabled = false;
            btn_suaLoai.Enabled = false;

            if (kq!=string.Empty)
            {
                kq = "Loại sản phẩm (" + kq;
                MessageBox.Show(kq+= ") đang sử dụng không thể xóa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (kq==string.Empty)
                 MessageBox.Show("Xóa thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                 MessageBox.Show("Xóa thất bại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_xoa.PerformClick();
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_suaLoai.PerformClick();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txt_tim.Text == string.Empty)
                loadView(csdl.loadView(""));
            else
                loadView(csdl.loadView(txt_tim.Text));
        }
    }
}
