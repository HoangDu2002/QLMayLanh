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
    public partial class ThongKe_2 : Form
    {
        CSDL_NhapSanPham csdl = new CSDL_NhapSanPham();
        public ThongKe_2()
        {
            InitializeComponent();
            this.Load += ThongKe_2_Load;
        }

        private void ThongKe_2_Load(object sender, EventArgs e)
        {
            loadTime();
            cbo_start.SelectedIndex= 0;
            loadPhanTram();
            loadTienTungLoai();
            chart_phanTramSL.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart_phanTramSL.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
            chart_thanhTien.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart_thanhTien.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
        }

        public void loadPhanTram()
        {
            chart_phanTramSL.Series["SOLUONG"].Points.Clear();
            DataTable dt = csdl.loadSLBanDuoc(cbo_start.SelectedItem.ToString(), cbo_finish.SelectedItem.ToString());
            foreach(DataRow dr in dt.Rows)
            {
                string x = dr["TENSP"].ToString();
                string Y = dr["SOLUONG"].ToString();
                DataPoint a = new DataPoint();
                a.SetValueXY(x, int.Parse(Y));
                a.ToolTip = string.Format("{0}", x);
                chart_phanTramSL.Series["SOLUONG"].Points.Add(a);
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

        private void cbo_start_SelectedIndexChanged(object sender, EventArgs e)
        {
            int name = cbo_start.SelectedIndex;
            cbo_finish.SelectedIndex = name;
        }

        public void loadTienTungLoai()
        {
            chart_thanhTien.Series["tien"].Points.Clear();
            DataTable dt = csdl.loadTienBanDuocTungLoai(cbo_start.SelectedItem.ToString(), cbo_finish.SelectedItem.ToString());
            foreach (DataRow dr in dt.Rows)
            {
                string x = dr["TENLOAI"].ToString();
                string Y = dr["THANHTIEN"].ToString();
                DataPoint a = new DataPoint();
                a.SetValueXY(x, double.Parse(Y));
                a.ToolTip = string.Format("{0}", x);
                chart_thanhTien.Series["tien"].Points.Add(a);
            }
        }
        private void btn_back_Click(object sender, EventArgs e)
        {
            foreach (Form i in Application.OpenForms)
            {
                if (i.Text == "ThongKe")
                {
                    i.Show();
                    this.Hide();
                }
            }
        }

        private void btn_lamMoi_Click(object sender, EventArgs e)
        {
            loadPhanTram();
            loadTienTungLoai();
        }

        private void ThongKe_2_Load_1(object sender, EventArgs e)
        {

        }
    }
}
