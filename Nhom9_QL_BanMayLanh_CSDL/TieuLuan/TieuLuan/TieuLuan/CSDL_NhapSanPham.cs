using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace TieuLuan
{
    public class CSDL_NhapSanPham
    {
        SqlConnection con = new SqlConnection("Data Source=MSI\\MAYAO;Initial Catalog=QL_MAYLANH;Integrated Security=True");
        DataSet ds_QL_MAYLANH = new DataSet();
        SqlDataAdapter da_Loai;
        SqlDataAdapter da_Sanpham;
        SqlDataAdapter da_chiTietHD;
        SqlDataAdapter da_donViVanChuyen;
        SqlDataAdapter da_thanhTien;
        SqlDataAdapter da_soLuongBanDuoc;
        SqlDataAdapter da_tienBanDcTungLoai;
        public DataTable loadTienBanDuocTungLoai(string start, string end)
        {
            string lenh = "	SELECT * FROM DBO.F_TK_TienTungLoai("+start+","+end+")";
            da_tienBanDcTungLoai = new SqlDataAdapter(lenh, con);
            if (ds_QL_MAYLANH.Tables.Contains("TienBanDuocTungLoai"))
                ds_QL_MAYLANH.Tables["TienBanDuocTungLoai"].Rows.Clear();
            da_tienBanDcTungLoai.Fill(ds_QL_MAYLANH, "TienBanDuocTungLoai");
            return ds_QL_MAYLANH.Tables["TienBanDuocTungLoai"];
        }
        public DataTable loadSLBanDuoc(string start, string end)
        {
            string lenh = "SELECT * FROM  dbo.F_TK_SLTungSanPham("+start+","+end+")";
            da_soLuongBanDuoc = new SqlDataAdapter(lenh, con);
            if (ds_QL_MAYLANH.Tables.Contains("SLBanDuoc"))
                ds_QL_MAYLANH.Tables["SLBanDuoc"].Rows.Clear();
            da_soLuongBanDuoc.Fill(ds_QL_MAYLANH, "SLBanDuoc");
            return ds_QL_MAYLANH.Tables["SLBanDuoc"];
        }
        public DataTable loadLoai()
        {
            string lenh = "select * from LOAISP";
            da_Loai = new SqlDataAdapter(lenh, con);
            if (ds_QL_MAYLANH.Tables.Contains("LOAISP"))
                ds_QL_MAYLANH.Tables["LOAISP"].Rows.Clear();
            da_Loai.Fill(ds_QL_MAYLANH, "LOAISP");
            return ds_QL_MAYLANH.Tables["LOAISP"];
        }
        public DataTable loadDonViVanChuyen()
        {
            string lenh = "select * from DONVIVANCHUYEN";
            da_donViVanChuyen = new SqlDataAdapter(lenh, con);
            if (ds_QL_MAYLANH.Tables.Contains("DONVIVANCHUYEN"))
                ds_QL_MAYLANH.Tables["DONVIVANCHUYEN"].Rows.Clear();
            da_donViVanChuyen.Fill(ds_QL_MAYLANH, "DONVIVANCHUYEN");
            return ds_QL_MAYLANH.Tables["DONVIVANCHUYEN"];
        }
        public DataTable loadChiTietHD()
        {
            string lenh = "select * from CHITIETHOADONKH";
            da_chiTietHD = new SqlDataAdapter(lenh, con);
            if (ds_QL_MAYLANH.Tables.Contains("CHITIETHOADON"))
                ds_QL_MAYLANH.Tables["CHITIETHOADON"].Rows.Clear();
            da_chiTietHD.Fill(ds_QL_MAYLANH, "CHITIETHOADON");
            return ds_QL_MAYLANH.Tables["CHITIETHOADON"];
        }
        public string maxMaSP()
        {
            DataRow row = loadSanPham().Rows[0];
            if (row == null)
                return null;
            foreach (DataRow dr in ds_QL_MAYLANH.Tables["SANPHAM"].Rows)
                if (int.Parse(row[0].ToString().Substring(3)) < int.Parse(dr[0].ToString().Substring(3)))
                    row = dr;
            return row[0].ToString();
        }
        public DataTable loadSanPham()
        {
            string lenh = "select * from SANPHAM";
            da_Sanpham = new SqlDataAdapter(lenh, con);
            if (ds_QL_MAYLANH.Tables.Contains("SANPHAM"))
                ds_QL_MAYLANH.Tables["SANPHAM"].Rows.Clear();
            da_Sanpham.Fill(ds_QL_MAYLANH, "SANPHAM");
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds_QL_MAYLANH.Tables["SANPHAM"].Columns[0];
            ds_QL_MAYLANH.Tables["SANPHAM"].PrimaryKey = keys;
            return ds_QL_MAYLANH.Tables["SANPHAM"];
        }
        public DataTable loadThanhTien(string start,string end)
        {
            string lenh = "select * from dbo.F_TK_TienTungSanPham('"+start+"','"+end+"')";
            da_thanhTien = new SqlDataAdapter(lenh, con);
            if (ds_QL_MAYLANH.Tables.Contains("THANHTIEN"))
                ds_QL_MAYLANH.Tables["THANHTIEN"].Rows.Clear();
                da_thanhTien.Fill(ds_QL_MAYLANH, "THANHTIEN");
            return ds_QL_MAYLANH.Tables["THANHTIEN"];
        }
        public bool kiemTraKhoaTonTai(string maLoai)
        {
            DataTable dt = loadSanPham();
            foreach(DataRow dr in dt.Rows)
            {
                if (dr["MASP"].ToString().Trim().Equals(maLoai.Trim()))
                    return true;
            }
            return false;
        }
        public bool kiemTraMaSP_CTHoaDon(string maSP)
        {
            DataTable dt = loadChiTietHD();
            foreach(DataRow dr in dt.Rows)
            {
                if (dr["MASP"].ToString().Trim().Equals(maSP.Trim()))
                    return true;
            }
            return false;
        }
        public bool kiemTraMaSP_DonViVanChuyen(string maSP)
        {
            DataTable dt = loadChiTietHD();
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["MASP"].ToString().Trim().Equals(maSP.Trim()))
                    return true;
            }
            return false;
        }
        public bool them(string maSP,string tenSP,string giaNhap,string giaGoc,string congSuat,string soChieu,string maLoai,string noiSX,string moTa,string anhBia,string soLuong,string date)
        {
            try
            {
                loadSanPham();
                DataRow row = ds_QL_MAYLANH.Tables["SANPHAM"].NewRow();
                row[0] = maSP;
                row[1] = tenSP;
                row[2] = giaNhap;
                row[3] = giaGoc;
                row[4] = congSuat;
                row[5] = soChieu;
                row[6] = maLoai;
                row[7] = noiSX;
                row[8] = moTa;
                row[9] = anhBia;
                row[10] = soLuong;
                row[11] = date;
                ds_QL_MAYLANH.Tables["SANPHAM"].Rows.Add(row);
                SqlCommandBuilder cm = new SqlCommandBuilder(da_Sanpham);
                da_Sanpham.Update(ds_QL_MAYLANH, "SANPHAM");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool sua(string maSP, string tenSP, string giaNhap, string giaGoc, string congSuat, string soChieu, string maLoai, string noiSX, string moTa, string anhBia, string soLuong,string date)
        {
            try
            {
                loadSanPham();
                DataRow row = ds_QL_MAYLANH.Tables["SANPHAM"].Rows.Find(maSP);
                if(row!=null)
                {
                    row[1] = tenSP;
                    row[2] = giaNhap;
                    row[3] = giaGoc;
                    row[4] = congSuat;
                    row[5] = soChieu;
                    row[6] = maLoai;
                    row[7] = noiSX;
                    row[8] = moTa;
                    row[9] = anhBia;
                    row[10] = soLuong;
                    row[11] = date;
                }
                SqlCommandBuilder cm = new SqlCommandBuilder(da_Sanpham);
                da_Sanpham.Update(ds_QL_MAYLANH, "SANPHAM");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool xoa(string maSP)
        {
            try
            {
                loadSanPham();
                DataRow row = ds_QL_MAYLANH.Tables["SANPHAM"].Rows.Find(maSP);
                if (row != null)
                {
                    row.Delete();
                }
                SqlCommandBuilder cm = new SqlCommandBuilder(da_Sanpham);
                da_Sanpham.Update(ds_QL_MAYLANH, "SANPHAM");
                return true;
            }
            catch
            {
                return false;
            }
        }
       
    }
}
