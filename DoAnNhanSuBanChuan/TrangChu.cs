using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DoAnNhanSuBanChuan
{
    public partial class TrangChu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        
       
        public TrangChu()
        {
            InitializeComponent();
            
        }

        private void btnNhanSu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnControl.Dock = DockStyle.Fill;
            grControl.Text = "Thống Kê Nhân Sự";
            pnControl.Controls.Clear();
            TongQuan.ThietLap.ucThongKeNhanSu ucThongKeNhanSu = new TongQuan.ThietLap.ucThongKeNhanSu();
            ucThongKeNhanSu.Dock = DockStyle.Fill;
            pnControl.Controls.Add(ucThongKeNhanSu);
        }

        private void btnThongTinNhanSu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnControl.Dock = DockStyle.Fill;
            grControl.Text = "Thông Tin Nhân Sự";
            pnControl.Controls.Clear();
            HoSo.ThongTin.ucThongTinNhanSu ucThongTinNhanSu = new HoSo.ThongTin.ucThongTinNhanSu();
            ucThongTinNhanSu.Dock = DockStyle.Fill;
            pnControl.Controls.Add(ucThongTinNhanSu);

        }

        private void btnHopDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnControl.Dock = DockStyle.Fill;
            grControl.Text = "Thông Tin Hợp Đồng";
            pnControl.Controls.Clear();
            HoSo.ThongTin.fmThongTinHopDong ucThongTinHopDong = new HoSo.ThongTin.fmThongTinHopDong();
            ucThongTinHopDong.Dock = DockStyle.Fill;
            pnControl.Controls.Add(ucThongTinHopDong);
        }

         
        private void btnChamCongHangNgay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnControl.Dock = DockStyle.Fill;
            grControl.Text = "Chấm Công Hàng Ngày";
            pnControl.Controls.Clear();
            ChamCong.NhapThongTin.ucNhapThongTinChamCong ucChamCongHangNgay = new ChamCong.NhapThongTin.ucNhapThongTinChamCong();
            ucChamCongHangNgay.Dock = DockStyle.Fill;
            pnControl.Controls.Add(ucChamCongHangNgay);

        }

        private void btnNguoiDungHeThong_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnControl.Dock = DockStyle.Fill;
            grControl.Text = "Thiết lập Về Người Dùng Hệ Thống";
            pnControl.Controls.Clear();
            TongQuan.ThietLap.ucThongKeNguoiDungHeThong ucthongkenguoidunghethong = new TongQuan.ThietLap.ucThongKeNguoiDungHeThong();
            ucthongkenguoidunghethong.Dock = DockStyle.Fill;
            pnControl.Controls.Add(ucthongkenguoidunghethong);
        }

        private void btnThongTinLienQuan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnControl.Dock = DockStyle.Fill;
            grControl.Text = "Thiết lập các Thông Tin Liên Quan";
            pnControl.Controls.Clear();
            TongQuan.ThietLap.ucThietLapThongTinLienQuan ucthongtinlienquan = new TongQuan.ThietLap.ucThietLapThongTinLienQuan();
            ucthongtinlienquan.Dock = DockStyle.Fill;
            pnControl.Controls.Add(ucthongtinlienquan);
        }

        private void btnBangChamCongTongHop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnControl.Dock = DockStyle.Fill;
            grControl.Text = "Chấm Công Tổng Hợp";
            pnControl.Controls.Clear();
            ChamCong.ChiXemChamCongTongHop.ucChamCongTongHop ucChamCongTongHop = new ChamCong.ChiXemChamCongTongHop.ucChamCongTongHop();
            ucChamCongTongHop.Dock = DockStyle.Fill;
            pnControl.Controls.Add(ucChamCongTongHop);
        }

        private void btnTinhToanLuong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnControl.Dock = DockStyle.Fill;
            grControl.Text = "Tính Lương";
            pnControl.Controls.Clear();
            TinhLuong.TinhToan.ucTinhToanLuong ucTinhToanLuong = new TinhLuong.TinhToan.ucTinhToanLuong();
            ucTinhToanLuong.Dock = DockStyle.Fill;
            pnControl.Controls.Add(ucTinhToanLuong);
        }
    }
}
   