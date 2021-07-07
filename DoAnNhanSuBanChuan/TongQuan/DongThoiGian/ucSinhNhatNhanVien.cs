using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnNhanSuBanChuan.DataAccess;

namespace DoAnNhanSuBanChuan.TongQuan.DongThoiGian
{
    public partial class ucSinhNhatNhanVien : UserControl
    {
        Data_Access sinhnhat = new Data_Access();
        public ucSinhNhatNhanVien()
        {
            InitializeComponent();
            hienthisinhnhat();
        }
        public void hienthisinhnhat()
        {
            DataTable hienthisinhnhatnhanvien = sinhnhat.CreateTable("SELECT NHANVIEN.MaNV, NHANVIEN.HoTen, NHANVIEN.GioiTinh, CONVERT(varchar, NHANVIEN.NgaySinh, 103) as NgaySinh , PHONGBAN.TenPB, NHANVIEN.SoDienThoai FROM NHANVIEN LEFT JOIN PHONGBANCHUCVUNHANVIEN ON NHANVIEN.MaNV = PHONGBANCHUCVUNHANVIEN.MaNV LEFT JOIN PHONGBAN ON PHONGBANCHUCVUNHANVIEN.MaPB = PHONGBAN.MaPB WHERE (MONTH(GETDATE()) - MONTH(NgaySinh)) = 0");
            gcSinhNhatNhanVien.DataSource = hienthisinhnhatnhanvien;
        }
    }
}
