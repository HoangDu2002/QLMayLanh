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
    public partial class ChiTietHD : Form
    {
        CSDL dl = new CSDL();
        public ChiTietHD()
        {
            InitializeComponent();
        }
        public void loadData()
        {
            dataGridView1.DataSource = dl.loadCtHdKh();
        }

        public void loadCbo()
        {
            cboMaHD.DataSource = dl.loadMaHD();
            cboMaHD.ValueMember = cboMaHD.DisplayMember = "MAHD";
            cboTenKH.DataSource = dl.loadTenKH();
            cboTenKH.ValueMember = cboTenKH.DisplayMember = "TENKH";
        }

        public void bingding(DataTable pData)
        {
            cboMaHD.DataBindings.Clear();
            cboTenKH.DataBindings.Clear();

            cboMaHD.DataBindings.Add("text", pData, "MAHD");
            cboTenKH.DataBindings.Add("text",pData, "TENKH");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadData();
            loadCbo();
            bingding(dl.loadCtHdKh());
        }

        private void cboMaHD_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dl.loadTheoMaHD(cboMaHD.SelectedValue.ToString());
        }

        private void cboTenKH_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dl.loadTheoTenKH(cboTenKH.SelectedValue.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Form item in Application.OpenForms)
            {
                if (item.Text == "TaoDonHang")
                {
                    item.Show();
                    this.Hide();
                    break;
                }
            }
        }
    }
}
