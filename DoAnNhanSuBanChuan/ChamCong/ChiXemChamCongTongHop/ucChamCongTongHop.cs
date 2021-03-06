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

namespace DoAnNhanSuBanChuan.ChamCong.ChiXemChamCongTongHop
{
    public partial class ucChamCongTongHop : DevExpress.XtraEditors.XtraUserControl
    {
        Data_Access chamcongtonghop = new Data_Access();
        public ucChamCongTongHop()
        {
            InitializeComponent();
            dulieuchon();
        }
        public void dulieuchon()
        {
            DataTable dulieuvaocommbobox = chamcongtonghop.CreateTable("SELECT MaNV FROM NHANVIEN");
            cbMaNV.DataSource = dulieuvaocommbobox;
            cbMaNV.DisplayMember = "MaNV";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DataTable thongtinchamcongtonghop = chamcongtonghop.CreateTable("SELECT CONVERT(nvarchar, NgayDiLam,103) as NgayDiLam, ThongTinDiLam, SoGioLamThem FROM CHAMCONGHANGNGAY WHERE  NgayDiLam BETWEEN '" + dtpTuNgay.Value + "' AND '"+ dtpDenNgay.Value + "'  AND MaNV = '"+cbMaNV.Text+"'");
            gcChamCongTongHop.DataSource = thongtinchamcongtonghop;
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            var r = new rpDanhSachNgayCong();
            DataTable inthongtin = chamcongtonghop.CreateTable("SELECT CONVERT(varchar,NgayDiLam,103) as NgayDiLam, ThongTinDiLam, SoGioLamThem FROM CHAMCONGHANGNGAY WHERE  NgayDiLam BETWEEN '" + dtpTuNgay.Value + "' AND '" + dtpDenNgay.Value + "'  AND MaNV = '" + cbMaNV.Text + "'");
            r.DataSource = inthongtin;
            r.hienthipreview();
        }
    }
}
