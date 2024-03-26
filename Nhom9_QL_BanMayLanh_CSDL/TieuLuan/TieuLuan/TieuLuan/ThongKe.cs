using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TieuLuan
{
    public partial class ThongKe : Form
    {
        CSDL_NhapSanPham csdl = new CSDL_NhapSanPham();

        public ThongKe()
        {
            InitializeComponent();
        }
        public void loadSoLuong()
        {
            chart_soLuongSP.Series["SoLuong"].Points.Clear();
            DataTable dt = csdl.loadSanPham();
            foreach (DataRow dr in dt.Rows)
            {
                string x = dr["TENSP"].ToString();
                string y = dr["SOLUONG"].ToString();
                DataPoint point = new DataPoint();
                point.SetValueXY(x, int.Parse(y));
                point.ToolTip = string.Format("{0}", x);
                chart_soLuongSP.Series["SoLuong"].Points.Add(point);
            }
        }
        public void loadThanhTien()
        {
            chart_thanhTien.Series["tien"].Points.Clear();
            DataTable dt = csdl.loadThanhTien(cbo_start.SelectedItem.ToString(),cbo_finish.SelectedItem.ToString());
            foreach (DataRow dr in dt.Rows)
            {
                string ten = dr["TENSP"].ToString();
                string thanhTien = dr["THANHTIEN"].ToString();
                DataPoint point = new DataPoint();
                point.SetValueXY(ten,double.Parse(thanhTien));
                point.ToolTip = string.Format("{0}", (ten));
                chart_thanhTien.Series["tien"].Points.Add(point);
            }
        }
        public void loadTime()
        {
            for (int i = 2010; i <= 2050; i++)
            {
                cbo_start.Items.Add(i.ToString());
                cbo_finish.Items.Add(i.ToString());
            }
        }
        private void ThongKe_Load(object sender, EventArgs e)
        {
            chart_soLuongSP.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart_soLuongSP.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
            chart_thanhTien.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart_thanhTien.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
            loadSoLuong();
            loadTime();
            cbo_start.SelectedIndex = 0;
            loadThanhTien();
        }

        private void btn_lamMoi_Click(object sender, EventArgs e)
        {
            loadSoLuong();
            loadThanhTien();
        }

        private void cbo_start_SelectedIndexChanged(object sender, EventArgs e)
        {
            int name = cbo_start.SelectedIndex;
            cbo_finish.SelectedIndex = name;
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

        private void roundButton1_Click(object sender, EventArgs e)
        {
            foreach (Form item in Application.OpenForms)
            {
                if (item.Text == "ThongKe_2")
                {
                    item.Show();
                    this.Hide();
                    return;
                }
            }
            ThongKe_2 frm = new ThongKe_2();
            frm.Show();
            this.Hide();
        }
    }
}
