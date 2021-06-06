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
    public partial class ucXemDanhSachUngVien : UserControl
    {
        public ucXemDanhSachUngVien()
        {
            InitializeComponent();
        }

        private void spbtnThemThongTinUngVien_Click(object sender, EventArgs e)
        {
            fmXemDanhSachUngVien fmXemDanhSachUngVien = new fmXemDanhSachUngVien();
            fmXemDanhSachUngVien.Text = "Thêm Thông Tin Ứng Viên";
            fmXemDanhSachUngVien.ShowDialog();
        }

        private void spbtnSuaThongTinUngVien_Click(object sender, EventArgs e)
        {
            fmXemDanhSachUngVien fmXemDanhSachUngVien = new fmXemDanhSachUngVien();
            fmXemDanhSachUngVien.Text = "Sửa Thông Tin Ứng Viên";
            fmXemDanhSachUngVien.ShowDialog();
        }
    }
}
