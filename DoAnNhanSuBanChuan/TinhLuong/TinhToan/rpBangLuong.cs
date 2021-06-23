using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace DoAnNhanSuBanChuan.TinhLuong.TinhToan
{
    public partial class rpBangLuong : DevExpress.XtraReports.UI.XtraReport
    {
        public rpBangLuong()
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
