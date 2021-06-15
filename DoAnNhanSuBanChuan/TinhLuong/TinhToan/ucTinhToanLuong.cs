using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DoAnNhanSuBanChuan.DataAccess;

namespace DoAnNhanSuBanChuan.TinhLuong.TinhToan
{
    public partial class ucTinhToanLuong : DevExpress.XtraEditors.XtraUserControl
    {
        Data_Access tinhluong = new Data_Access();
        //SELECT NHANVIEN.MaNV,NHANVIEN.HoTen, HOPDONG.HeSoLuong, LUONG.LuongCoBan, SUM(PHUCAP.SoTien) as TongTienPC, SUM(KHENTHUONG.GiaTriKhenThuong) as TongTienKT,SUM(KYLUAT.SoTienKyLuat) as TongTienKL, SUM(BAOHIEM.SoTien) as TongTienBH  FROM ((((((((((NHANVIEN LEFT JOIN PHUCAPNHANVIEN ON NHANVIEN.MaNV = PHUCAPNHANVIEN.MaNV) LEFT JOIN PHUCAP ON PHUCAPNHANVIEN.MaPC = PHUCAP.MaPC) LEFT JOIN BAOHIEMNHANVIEN ON NHANVIEN.MaNV = BAOHIEMNHANVIEN.MaNV) LEFT JOIN BAOHIEM ON BAOHIEMNHANVIEN.MaBH = BAOHIEM.MaBH) LEFT JOIN HOPDONG ON NHANVIEN.MaNV = HOPDONG.MaNV) LEFT JOIN LUONG ON HOPDONG.BacLuong = LUONG.BacLuong) LEFT JOIN KHENTHUONGNHANVIEN ON NHANVIEN.MaNV = KHENTHUONGNHANVIEN.MaNV) LEFT JOIN KHENTHUONG ON KHENTHUONGNHANVIEN.MaKhenThuong = KHENTHUONG.MaKhenThuong) LEFT JOIN KYLUATNHANVIEN ON NHANVIEN.MaNV = KYLUATNHANVIEN.MaNV) LEFT JOIN KYLUAT ON KYLUATNHANVIEN.MaKyLuat = KYLUAT.MaKyLuat) GROUP BY NHANVIEN.MaNV,NHANVIEN.HoTen, HOPDONG.HeSoLuong, LUONG.LuongCoBan
        //SELECT NHANVIEN.MaNV, SUM(PHUCAP.SoTien) as TongTienPC FROM ((NHANVIEN LEFT JOIN PHUCAPNHANVIEN ON NHANVIEN.MaNV = PHUCAPNHANVIEN.MaNV) LEFT JOIN PHUCAP ON PHUCAPNHANVIEN.MaPC = PHUCAP.MaPC) GROUP BY NHANVIEN.MaNV
        public ucTinhToanLuong()
        {
            InitializeComponent();
        }
        public void hienthithongtin()
        {
            DataTable hienthithongtintinhluong = tinhluong.CreateTable("SELECT NHANVIEN.MaNV,NHANVIEN.HoTen, HOPDONG.HeSoLuong, LUONG.LuongCoBan, SUM(PHUCAP.SoTien) as TongTienPC, SUM(KHENTHUONG.GiaTriKhenThuong) as TongTienKT,SUM(KYLUAT.SoTienKyLuat) as TongTienKL, SUM(BAOHIEM.SoTien) as TongTienBH  FROM ((((((((((NHANVIEN LEFT JOIN PHUCAPNHANVIEN ON NHANVIEN.MaNV = PHUCAPNHANVIEN.MaNV) LEFT JOIN PHUCAP ON PHUCAPNHANVIEN.MaPC = PHUCAP.MaPC) LEFT JOIN BAOHIEMNHANVIEN ON NHANVIEN.MaNV = BAOHIEMNHANVIEN.MaNV) LEFT JOIN BAOHIEM ON BAOHIEMNHANVIEN.MaBH = BAOHIEM.MaBH) LEFT JOIN HOPDONG ON NHANVIEN.MaNV = HOPDONG.MaNV) LEFT JOIN LUONG ON HOPDONG.BacLuong = LUONG.BacLuong) LEFT JOIN KHENTHUONGNHANVIEN ON NHANVIEN.MaNV = KHENTHUONGNHANVIEN.MaNV) LEFT JOIN KHENTHUONG ON KHENTHUONGNHANVIEN.MaKhenThuong = KHENTHUONG.MaKhenThuong) LEFT JOIN KYLUATNHANVIEN ON NHANVIEN.MaNV = KYLUATNHANVIEN.MaNV) LEFT JOIN KYLUAT ON KYLUATNHANVIEN.MaKyLuat = KYLUAT.MaKyLuat) GROUP BY NHANVIEN.MaNV,NHANVIEN.HoTen, HOPDONG.HeSoLuong, LUONG.LuongCoBan");
            gcTinhLuong.DataSource = hienthithongtintinhluong;
        }

        private void ucTinhToanLuong_Load(object sender, EventArgs e)
        {
            hienthithongtin();
        }
    }
}
