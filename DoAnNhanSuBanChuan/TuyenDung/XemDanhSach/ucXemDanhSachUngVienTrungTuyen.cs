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
    public partial class ucXemDanhSachUngVienTrungTuyen : UserControl
    {
        public ucXemDanhSachUngVienTrungTuyen()
        {
            InitializeComponent();
        }

        private void spbtnThemThongTinUngVien_Click(object sender, EventArgs e)
        {
            TuyenDung.XemDanhSach.fmXemDanhSachUngVienTrungTuyen fmxemdanhsachuvtt = new TuyenDung.XemDanhSach.fmXemDanhSachUngVienTrungTuyen();
            fmxemdanhsachuvtt.Text = "Thêm Thông Tin";
            fmxemdanhsachuvtt.ShowDialog();
        }

        private void spbtnSuaThongTinUngVien_Click(object sender, EventArgs e)
        {
            TuyenDung.XemDanhSach.fmXemDanhSachUngVienTrungTuyen fmxemdanhsachuvtt = new TuyenDung.XemDanhSach.fmXemDanhSachUngVienTrungTuyen();
            fmxemdanhsachuvtt.Text = "Sửa Thông Tin";
            fmxemdanhsachuvtt.ShowDialog();
        }
    }
}
