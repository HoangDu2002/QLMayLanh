using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TieuLuan
{
    public class CSDL
    {
        SqlConnection _cnn = new SqlConnection("Data Source=MSI\\MAYAO;Initial Catalog=QL_MAYLANH;Integrated Security=True");
        DataSet QLMayLanh = new DataSet();
        SqlDataAdapter dsChiTiet;
        public DataTable loadChiTiet(string s)
        {
            string cauLenh = s;
            dsChiTiet = new SqlDataAdapter(cauLenh, _cnn);
            if (QLMayLanh.Tables.Contains("CHITIETHOADONKH"))
                QLMayLanh.Tables["CHITIETHOADONKH"].Rows.Clear();
            dsChiTiet.Fill(QLMayLanh, "CHITIETHOADONKH");
            DataColumn[] cot = new DataColumn[1];
            cot[0] = QLMayLanh.Tables["CHITIETHOADONKH"].Columns[0];
            QLMayLanh.Tables["CHITIETHOADONKH"].PrimaryKey = cot;
            return QLMayLanh.Tables["CHITIETHOADONKH"];
        }
        public DataTable loadCtHdKh()
        {
            return loadChiTiet("select ct.MAHD, TENKH, TENSP, DONGIA, ct.SOLUONG from CHITIETHOADONKH ct, HOADONKH hd, SANPHAM sp, KHACHHANG kh where ct.MAHD=hd.MAHD and hd.MAKH=kh.MAKH and ct.MASP=sp.MASP");
        }
        public DataTable loadTheoMaHD(string pMaHD)
        {
            return loadChiTiet("select ct.MAHD, TENKH, TENSP, DONGIA, ct.SOLUONG from CHITIETHOADONKH ct, HOADONKH hd, SANPHAM sp, KHACHHANG kh where ct.MAHD=hd.MAHD and hd.MAKH=kh.MAKH and ct.MASP=sp.MASP and ct.MAHD='" + pMaHD + "'");
        }
        public DataTable loadTheoTenKH(string pTenKH)
        {
            return loadChiTiet("select ct.MAHD, TENKH, TENSP, DONGIA, ct.SOLUONG from CHITIETHOADONKH ct, HOADONKH hd, SANPHAM sp, KHACHHANG kh where ct.MAHD=hd.MAHD and hd.MAKH=kh.MAKH and ct.MASP=sp.MASP and TENKH=N'" + pTenKH + "'");
        }
        public DataTable loadMaHD()
        {
            string cauLenh = "select MAHD from HOADONKH";
            SqlDataAdapter dsHoaDon = new SqlDataAdapter(cauLenh, _cnn);
            dsHoaDon.Fill(QLMayLanh, "HOADONKH");
            return QLMayLanh.Tables["HOADONKH"];
        }
        public DataTable loadTenKH()
        {
            string cauLenh = "select TENKH from KHACHHANG";
            SqlDataAdapter dsKhachHang = new SqlDataAdapter(cauLenh, _cnn);
            dsKhachHang.Fill(QLMayLanh, "KHACHHANG");
            return QLMayLanh.Tables["KHACHHANG"];
        }
        public DataTable loadTaiKhoan()
        {
            string cauLenh = "select * from TAIKHOAN";
            if (QLMayLanh.Tables.Contains("TAIKHOAN"))
                QLMayLanh.Tables["TAIKHOAN"].Rows.Clear();
            SqlDataAdapter dsTK = new SqlDataAdapter(cauLenh, _cnn);
            dsTK.Fill(QLMayLanh, "TAIKHOAN");
            return QLMayLanh.Tables["TAIKHOAN"];
        }
    }
}
