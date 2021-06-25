using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace DoAnNhanSuBanChuan.ChamCong.ChiXemChamCongTongHop
{
    public partial class rpDanhSachNgayCong : DevExpress.XtraReports.UI.XtraReport
    {
        public rpDanhSachNgayCong()
        {
            InitializeComponent();
            lbNgayThangNam.Text = string.Format("Hà Nội, ngày {0} tháng {1} năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
        }
        public void hienthipreview()
        {
            this.ShowPreviewDialog();
        }
        public void hienthidesigner()
        {
            this.ShowDesignerDialog();
        }
    }
}
