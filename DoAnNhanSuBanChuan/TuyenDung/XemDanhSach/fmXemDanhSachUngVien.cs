using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnNhanSuBanChuan.TuyenDung.XemDanhSach
{
    public partial class fmXemDanhSachUngVien : Form
    {
        public fmXemDanhSachUngVien()
        {
            InitializeComponent();
        }

        private void fmXemDanhSachUngVien_Load(object sender, EventArgs e)
        {

        }

        private void smbtnHuyBoThongTinUngVien_Click(object sender, EventArgs e)
        {
            DialogResult ThongBao4 = MessageBox.Show("Bạn có muốn hủy bỏ không?", 
                "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (ThongBao4 == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
