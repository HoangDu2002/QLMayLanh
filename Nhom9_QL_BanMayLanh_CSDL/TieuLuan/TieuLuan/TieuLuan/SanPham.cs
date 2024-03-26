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
    public partial class SanPham : Form
    {
        CSDL_SP dl = new CSDL_SP();
        public SanPham()
        {
            InitializeComponent();
        }

        public void loadSP(DataTable dt)
        {
            dataGridView1.DataSource = dt;
        }

        private void SanPham_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            loadSP(dl.loadSanPham(""));
            dl.loadChiTietHD();
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void txt_timKiem_TextChanged(object sender, EventArgs e)
        {
            if (txt_timKiem.Text == string.Empty)
                loadSP(dl.loadSanPham(""));
            else
                loadSP(dl.loadSanPham(txt_timKiem.Text.Trim()));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable t = dl.loadHinh();
            if (dataGridView1.CurrentRow == null)
                return;
            string s = string.Empty;
            for (int i = 0; i < t.Rows.Count; i++)
            {
                if (t.Rows[i][0].ToString() == dataGridView1.CurrentRow.Cells[0].Value.ToString())
                    s = t.Rows[i][1].ToString();
            }
            pictureBox1.Image = new Bitmap(Application.StartupPath + "\\images\\" + s);
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có chắc chắn muốn xóa!", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                return;
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Chưa chọn thông tin trên bảng để xóa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string kq = string.Empty;
            for (int i = dataGridView1.SelectedRows.Count - 1; i >= 0; i--)
            {
                string maSP = dataGridView1.SelectedRows[i].Cells[0].Value.ToString();
                if (dl.kiemTraMaSP_CTHoaDon(maSP))
                {
                    if (kq != string.Empty)
                        kq += ", ";
                    kq += maSP.Trim();
                   
                }
                else
                    dl.xoa(maSP);
            }
            if (kq!=string.Empty)
            {
                kq = "Sản phẩm (" + kq;
                MessageBox.Show(kq+= ") đang sử dụng không thể xóa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (kq==string.Empty)
                MessageBox.Show("Xóa thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Xóa thất bại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            loadSP(dl.loadSanPham(""));
            //string maSP = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //if (dl.kiemTraMaSP_CTHoaDon(maSP))
            //{
            //    MessageBox.Show("Dữ liệu đang sử dụng không thể xóa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //if (dl.xoa(maSP))
            //    MessageBox.Show("Xóa thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //else
            //{
            //    MessageBox.Show("Xóa thất bại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Chưa chọn thông tin trên bảng để sửa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = false;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                dataGridView1.Rows[i].ReadOnly = false;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (dl.luu())
            {
                MessageBox.Show("Lưu thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Lưu thất bại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button1_Click(object sender, EventArgs e)
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
    }
}
