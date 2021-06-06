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
    public partial class fmXemDanhSachLichPhongVan : Form
    {
        public fmXemDanhSachLichPhongVan()
        {
            InitializeComponent();
        }

        private void smbtnHuyBo_Click(object sender, EventArgs e)
        {
            DialogResult ThongBao3 = MessageBox.Show("Bạn có muốn hủy bỏ không?", "Thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(ThongBao3 == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
