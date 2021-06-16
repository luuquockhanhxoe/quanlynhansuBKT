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
        public ucTinhToanLuong()
        {
            InitializeComponent();
        }
        public void hienthithongtin()
        {
            DataTable hienthithongtintinhluong = tinhluong.CreateTable("SELECT N.MaNV,N.HoTen,N.LuongCoBan,N.HeSoLuong,N.TongBH,N.TongKL,N.TongKT,N.TongPC, N.SoGioLamThem,N.SoNgayLam, M.SoTienNhan FROM (SELECT I.MaNV,I.HoTen,I.LuongCoBan,I.HeSoLuong,I.TongBH,I.TongKL,I.TongKT,I.TongPC, H.SoGioLamThem,H.SoNgayLam FROM (SELECT NHANVIEN.MaNV, SUM(CHAMCONGHANGNGAY.SoGioLamThem) as SoGioLamThem, COUNT(CHAMCONGHANGNGAY.ThongTinDiLam) as SoNgayLam FROM NHANVIEN LEFT JOIN CHAMCONGHANGNGAY ON NHANVIEN.MaNV = CHAMCONGHANGNGAY.MaNV WHERE CHAMCONGHANGNGAY.ThongTinDiLam = 'V' AND CHAMCONGHANGNGAY.NgayDiLam BETWEEN '" + dtpTuNgay.Text+ "' AND '" + dtpDenNgay.Text + "' GROUP BY NHANVIEN.MaNV) H FULL JOIN (SELECT E.MaNV,E.HoTen,E.LuongCoBan,E.HeSoLuong,G.TongBH,G.TongKL,G.TongKT,G.TongPC FROM (SELECT NHANVIEN.MaNV, NHANVIEN.HoTen ,HOPDONG.HeSoLuong,LUONG.LuongCoBan FROM NHANVIEN LEFT JOIN HOPDONG ON NHANVIEN.MaNV = HOPDONG.MaNV LEFT JOIN LUONG ON HOPDONG.BacLuong = LUONG.BacLuong) E FULL JOIN (SELECT C.MaNV, C.TongKT,C.TongPC, D.TongBH,D.TongKL FROM (SELECT A.MaNV, A.TongPC, B.TongKT FROM (SELECT NHANVIEN.MaNV, SUM(PHUCAP.SoTien) as TongPC FROM NHANVIEN LEFT JOIN PHUCAPNHANVIEN ON NHANVIEN.MaNV = PHUCAPNHANVIEN.MaNV LEFT JOIN PHUCAP ON PHUCAPNHANVIEN.MaPC = PHUCAP.MaPC GROUP BY NHANVIEN.MaNV) A FULL JOIN (SELECT NHANVIEN.MaNV, SUM(KHENTHUONG.GiaTriKhenThuong) as TongKT FROM NHANVIEN LEFT JOIN KHENTHUONGNHANVIEN ON NHANVIEN.MaNV = KHENTHUONGNHANVIEN.MaNV LEFT JOIN KHENTHUONG ON KHENTHUONGNHANVIEN.MaKhenThuong = KHENTHUONG.MaKhenThuong GROUP BY NHANVIEN.MaNV) B ON A.MaNV = B.MaNV) C FULL JOIN (SELECT A.MaNV, A.TongBH, B.TongKL FROM (SELECT NHANVIEN.MaNV, SUM(BAOHIEM.SoTien) as TongBH FROM NHANVIEN LEFT JOIN BAOHIEMNHANVIEN ON NHANVIEN.MaNV = BAOHIEMNHANVIEN.MaNV LEFT JOIN BAOHIEM ON BAOHIEMNHANVIEN.MaBH = BAOHIEM.MaBH GROUP BY NHANVIEN.MaNV) A FULL JOIN (SELECT NHANVIEN.MaNV, SUM(KYLUAT.SoTienKyLuat) as TongKL FROM NHANVIEN LEFT JOIN KYLUATNHANVIEN ON NHANVIEN.MaNV = KYLUATNHANVIEN.MaNV LEFT JOIN KYLUAT ON KYLUATNHANVIEN.MaKyLuat = KYLUAT.MaKyLuat GROUP BY NHANVIEN.MaNV) B ON A.MaNV = B.MaNV) D ON C.MaNV = D.MaNV) G ON E.MaNV = G.MaNV ) I ON H.MaNV = I.MaNV) N FULL JOIN (SELECT NHANVIEN.MaNV, TINHLUONGNHANVIEN.SoTienNhan FROM NHANVIEN LEFT JOIN TINHLUONGNHANVIEN ON NHANVIEN.MaNV = TINHLUONGNHANVIEN.MaNV) M ON N.MaNV = M.MaNV");
            gcTinhLuong.DataSource = hienthithongtintinhluong;
        }

        private void ucTinhToanLuong_Load(object sender, EventArgs e)
        {
            
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            hienthithongtin();
        }
    }
}
