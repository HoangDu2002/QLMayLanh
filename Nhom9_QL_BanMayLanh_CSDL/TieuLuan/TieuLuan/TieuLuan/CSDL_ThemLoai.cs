using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace TieuLuan
{
    public class CSDL_ThemLoai
    {
        SqlConnection con = new SqlConnection("Data Source=MSI\\MAYAO;Initial Catalog=QL_MAYLANH;Integrated Security=True");
        DataSet ds_QL_MAYLANH = new DataSet();
        SqlDataAdapter da_Nhasanxuat;
        SqlDataAdapter da_View;
        SqlDataAdapter da_Sanpham;
        SqlDataAdapter da_Loai;
        public DataTable loadNhaSanXuat()
        {
            string lenh = "select * from NHASANXUAT";
            da_Nhasanxuat = new SqlDataAdapter(lenh, con);
            if (ds_QL_MAYLANH.Tables.Contains("NHASANXUAT"))
                ds_QL_MAYLANH.Tables["NHASANXUAT"].Rows.Clear();
            da_Nhasanxuat.Fill(ds_QL_MAYLANH, "NHASANXUAT");
            DataRow row = ds_QL_MAYLANH.Tables["NHASANXUAT"].NewRow();
            row[0] = "chon";
            row[1] = "Tất cả nhà sản xuất";
            ds_QL_MAYLANH.Tables["NHASANXUAT"].Rows.Add(row);
            for(int i=0;i<ds_QL_MAYLANH.Tables["NHASANXUAT"].Rows.Count-1;i++)
            {
                DataRow lastRow = ds_QL_MAYLANH.Tables["NHASANXUAT"].NewRow();
                DataRow firstRow = ds_QL_MAYLANH.Tables["NHASANXUAT"].Rows[0];
                lastRow[0] = firstRow[0];
                lastRow[1] = firstRow[1];
                ds_QL_MAYLANH.Tables["NHASANXUAT"].Rows.RemoveAt(0);
                ds_QL_MAYLANH.Tables["NHASANXUAT"].Rows.Add(lastRow);
            }
            return ds_QL_MAYLANH.Tables["NHASANXUAT"];
        }
        public DataTable loadView(string tenLoai)
        {
            string lenh;
            tenLoai = tenLoai.Trim();
            if (tenLoai == "")
                lenh = "select l.MALOAI,TENLOAI,TENNSX from LOAISP l,NHASANXUAT n where n.MANSX=l.MANSX";
            else
                lenh = "select l.MALOAI,TENLOAI,TENNSX from LOAISP l,NHASANXUAT n where n.MANSX=l.MANSX and TENLOAI like N'%"+tenLoai+"%'  ";
            da_View = new SqlDataAdapter(lenh, con);
            if (ds_QL_MAYLANH.Tables.Contains("View"))
                ds_QL_MAYLANH.Tables["View"].Rows.Clear();
            da_View.Fill(ds_QL_MAYLANH, "View");
            return ds_QL_MAYLANH.Tables["View"];
        }
        public string timMaNSX(string tenNSX)
        {
            DataTable dt = loadNhaSanXuat();
            foreach (DataRow dr in dt.Rows)
                if (dr["TENNSX"].ToString().Equals(tenNSX))
                    return dr["MANSX"].ToString();
            return null;
        }
        public string maxMaLoai()
        {
            DataRow row = loadLoai().Rows[0];
            if (row == null)
                return null;
            foreach (DataRow dr in ds_QL_MAYLANH.Tables["LOAISP"].Rows)
                if (int.Parse(row[0].ToString().Substring(5)) < int.Parse(dr[0].ToString().Substring(5)))
                    row = dr;
            return row[0].ToString();
        }
        public DataTable loadLoai()
        {
            string lenh = "select * from LOAISP";
            da_Loai = new SqlDataAdapter(lenh, con);
            if (ds_QL_MAYLANH.Tables.Contains("LOAISP"))
               ds_QL_MAYLANH.Tables["LOAISP"].Rows.Clear();
            da_Loai.Fill(ds_QL_MAYLANH, "LOAISP");
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds_QL_MAYLANH.Tables["LOAISP"].Columns[0];
            ds_QL_MAYLANH.Tables["LOAISP"].PrimaryKey = keys;
            return ds_QL_MAYLANH.Tables["LOAISP"];
        }
        public bool kiemTraKhoaTonTai(string maLoai)
        {
            DataTable dt = ds_QL_MAYLANH.Tables["LOAISP"];
            foreach(DataRow dr in dt.Rows)
            {
                if (dr["MALOAI"].ToString().Equals(maLoai))
                    return true;
            }
            return false;
        }
        public DataTable loadSanPham()
        {
            string lenh = "select * from SANPHAM";
            da_Sanpham = new SqlDataAdapter(lenh, con);
            if (ds_QL_MAYLANH.Tables.Contains("SANPHAM"))
                ds_QL_MAYLANH.Tables["SANPHAM"].Rows.Clear();
            da_Sanpham.Fill(ds_QL_MAYLANH, "SANPHAM");
            return ds_QL_MAYLANH.Tables["SANPHAM"];
        }
        public bool kiemTraMaLoaiBangSanPham(string maLoai)
        {
            DataTable dt = loadSanPham();
            foreach(DataRow row in dt.Rows)
            {
                if (row["MALOAI"].ToString().Trim().Equals(maLoai.Trim()))
                    return true;
            }
            return false;
        }
        public DataTable loadChucNang()
        {
            return ds_QL_MAYLANH.Tables["LOAISP"];
        }
        public bool them(string MALOAI,string TENLOAI,string MANSX)
        {
            try
            {
                loadLoai();
                DataRow row = ds_QL_MAYLANH.Tables["LOAISP"].NewRow();
                row[0] = MALOAI.Trim();
                row[1] = TENLOAI.Trim();
                row[2] = MANSX.Trim();
                ds_QL_MAYLANH.Tables["LOAISP"].Rows.Add(row);
                SqlCommandBuilder cm = new SqlCommandBuilder(da_Loai);
                da_Loai.Update(ds_QL_MAYLANH, "LOAISP");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool sua(string MALOAI, string TENLOAI, string MANSX)
        {
            try
            {
                loadLoai();
                DataRow row = ds_QL_MAYLANH.Tables["LOAISP"].Rows.Find(MALOAI);
                if(row!=null)
                {
                    row[1] = TENLOAI;
                    row[2] = MANSX;
                }
                SqlCommandBuilder cm = new SqlCommandBuilder(da_Loai);
                da_Loai.Update(ds_QL_MAYLANH, "LOAISP");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool xoa(string MALOAI)
        {
            try
            {
                loadLoai();
                DataRow row = ds_QL_MAYLANH.Tables["LOAISP"].Rows.Find(MALOAI);
                if (row != null)
                    row.Delete();
                SqlCommandBuilder cm = new SqlCommandBuilder(da_Loai);
                da_Loai.Update(ds_QL_MAYLANH, "LOAISP");
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
                SqlCommandBuilder cm = new SqlCommandBuilder(da_Loai);
                da_Loai.Update(ds_QL_MAYLANH, "LOAISP");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool xacNhan()
        {
            try
            {
                SqlCommandBuilder cm = new SqlCommandBuilder(da_Loai);
                da_Loai.Update(ds_QL_MAYLANH, "LOAISP");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
