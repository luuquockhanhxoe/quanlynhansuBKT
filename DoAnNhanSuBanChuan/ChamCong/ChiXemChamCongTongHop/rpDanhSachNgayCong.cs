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
