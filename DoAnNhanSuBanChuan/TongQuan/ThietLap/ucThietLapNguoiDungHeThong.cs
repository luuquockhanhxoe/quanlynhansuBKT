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

namespace DoAnNhanSuBanChuan.TongQuan.ThietLap
{
    public partial class ucThongKeNguoiDungHeThong : DevExpress.XtraEditors.XtraUserControl
    {
        public ucThongKeNguoiDungHeThong()
        {
            InitializeComponent();
            hienthibieutuong();
        }

        void hienthibieutuong()
        {
             
        }
        private void spbtnThemNguoiDung_Click(object sender, EventArgs e)
        {

            TaoNguoiDungHeThong taonguoidung = new TaoNguoiDungHeThong();
            taonguoidung.Text = "Thêm Thông Tin Người Dùng Hệ Thống";
            taonguoidung.ShowDialog();

        }

        private void spbtnSuaNguoiDung_Click(object sender, EventArgs e)
        {
            TaoNguoiDungHeThong taonguoidung = new TaoNguoiDungHeThong();
            taonguoidung.Text = "Sửa Thông Tin Người Dùng Hệ Thống";
            taonguoidung.ShowDialog();

        }

    }
}
