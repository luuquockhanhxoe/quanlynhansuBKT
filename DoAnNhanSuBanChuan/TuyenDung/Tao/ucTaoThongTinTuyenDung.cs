using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnNhanSuBanChuan.TuyenDung.Tao
{
    public partial class ucTaoThongTinTuyenDung : UserControl
    {
        public ucTaoThongTinTuyenDung()
        {
            InitializeComponent();
        }

        private void spbtnThemThongTinTuyenDung_Click(object sender, EventArgs e)
        {
            fmTaoThongTinTuyenDung fmTaoThongTinTuyenDung = new fmTaoThongTinTuyenDung();
            fmTaoThongTinTuyenDung.Text = "Thêm Thông Tin Tuyển Dụng";
            fmTaoThongTinTuyenDung.ShowDialog();
        }

        private void spbtnSuaThongTinTuyenDung_Click(object sender, EventArgs e)
        {
            fmTaoThongTinTuyenDung fmTaoThongTinTuyenDung = new fmTaoThongTinTuyenDung();
            fmTaoThongTinTuyenDung.Text = "Sửa Thông Tin Tuyển Dụng";
            fmTaoThongTinTuyenDung.ShowDialog();
        }
    }
}
