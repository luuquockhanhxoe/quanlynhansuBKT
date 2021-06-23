using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace DoAnNhanSuBanChuan.HoSo.ThongTin
{
    public partial class rpThongTinNhanVien : DevExpress.XtraReports.UI.XtraReport
    {
        public rpThongTinNhanVien()
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
