using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TieuLuan
{
    public class CSDL_SP
    {
        SqlConnection con = new SqlConnection("Data Source=MSI\\MAYAO;Initial Catalog=QL_MAYLANH;Integrated Security=True");
        DataSet ds_QL_MAYLANH = new DataSet();
        SqlDataAdapter da_Sanpham;
        SqlDataAdapter da_chiTietHD;
        public DataTable loadSanPham(string key)
        {
            string lenh;
            if (key == "")
                lenh = "select * from SANPHAM";
            else
                lenh = "select * from SANPHAM where MASP LIKE '%"+key+"%' OR TENSP LIKE '%"+key+"%' OR DONGIA LIKE '%"+ key + "%' OR GIAGOC LIKE '%" + key + "%' OR CONGSUAT LIKE '%" + key + "%' OR SOCHIEU LIKE '%" + key + "%' OR MALOAI LIKE '%" + key + "%' OR NOISANXUAT LIKE '%" + key + "%' OR MOTA LIKE '%" + key + "%' OR SOLUONG LIKE '%" + key + "%' OR NGAYNHAP LIKE '%" + key + "%'";
            da_Sanpham = new SqlDataAdapter(lenh, con);
            if (ds_QL_MAYLANH.Tables.Contains("SANPHAM"))
                ds_QL_MAYLANH.Tables["SANPHAM"].Rows.Clear();
            da_Sanpham.Fill(ds_QL_MAYLANH, "SANPHAM");
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds_QL_MAYLANH.Tables["SANPHAM"].Columns[0];
            ds_QL_MAYLANH.Tables["SANPHAM"].PrimaryKey = keys;
            return ds_QL_MAYLANH.Tables["SANPHAM"];
        }
        public DataTable loadHinh()
        {
            string lenh = "select MASP, ANHBIA from SANPHAM";
            da_Sanpham = new SqlDataAdapter(lenh, con);
            if (ds_QL_MAYLANH.Tables.Contains("Hinh"))
                ds_QL_MAYLANH.Tables["Hinh"].Rows.Clear();
            da_Sanpham.Fill(ds_QL_MAYLANH, "Hinh");
            return ds_QL_MAYLANH.Tables["Hinh"];
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
        public bool kiemTraMaSP_CTHoaDon(string maSP)
        {
            DataTable dt = ds_QL_MAYLANH.Tables["CHITIETHOADON"];
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["MASP"].ToString().Trim().Equals(maSP.Trim()))
                    return true;
            }
            return false;
        }
        public bool xoa(string maSP)
        {
            try
            {
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
        public bool luu()
        {
            try
            {
                da_Sanpham = new SqlDataAdapter("select * from SANPHAM", con);
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
