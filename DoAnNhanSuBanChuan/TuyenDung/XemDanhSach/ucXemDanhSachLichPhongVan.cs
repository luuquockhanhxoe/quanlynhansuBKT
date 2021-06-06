using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnNhanSuBanChuan.TuyenDung.XemDanhSach
{
    public partial class ucXemDanhSachLichPhongVan : UserControl
    {
        public ucXemDanhSachLichPhongVan()
        {
            InitializeComponent();
        }

        private void spbtnThemThongTinLichPhongVan_Click(object sender, EventArgs e)
        {
            fmXemDanhSachLichPhongVan XemDanhSachLichPhongVan = new fmXemDanhSachLichPhongVan();
            XemDanhSachLichPhongVan.Text = "Thêm Danh Sách Lịch Phỏng Vấn";
            XemDanhSachLichPhongVan.ShowDialog();
        }

        private void spbtnSuaThongTinLichPhongVan_Click(object sender, EventArgs e)
        {
            fmXemDanhSachLichPhongVan XemDanhSachLichPhongVan = new fmXemDanhSachLichPhongVan();
            XemDanhSachLichPhongVan.Text = "Sửa Danh Sách Lịch Phỏng Vấn";
            XemDanhSachLichPhongVan.ShowDialog();
        }
    }
}
