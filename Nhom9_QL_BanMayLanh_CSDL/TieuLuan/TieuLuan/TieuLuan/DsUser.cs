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
    public partial class DsUser : Form
    {
        CSDL_user dt = new CSDL_user();
        public DsUser()
        {
            InitializeComponent();
        }
        public void load_user()
        {
            dataGridView1.DataSource = dt.load_user();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            load_user();

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            lưuToolStripMenuItem.Enabled = false;

        }

        private void sửaThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lưuToolStripMenuItem.Enabled = true;
            dataGridView1.ReadOnly = false;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.Rows[i].ReadOnly = false;
            }
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void lưuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dt.Luu();
            MessageBox.Show("Thành công!");
            lưuToolStripMenuItem.Enabled = false;
        }

        private void tạoUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lưuToolStripMenuItem.Enabled = true;

            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.ReadOnly = false;

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.Rows[i].ReadOnly = true;
            }
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            dt.Xoa(s);
            MessageBox.Show("Thanh cong!");
        }

        private void quayLaiToolStripMenuItem_Click(object sender, EventArgs e)
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
