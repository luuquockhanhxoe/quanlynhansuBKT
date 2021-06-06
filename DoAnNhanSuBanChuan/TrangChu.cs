//using DoAnNhanSuBanChuan.TongQuan.ThongKe;
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
            HoSo.ThongTin.ucThongTinHopDong ucThongTinHopDong = new HoSo.ThongTin.ucThongTinHopDong();
            ucThongTinHopDong.Dock = DockStyle.Fill;
            pnControl.Controls.Add(ucThongTinHopDong);
        }

        private void btnThongTinTuyenDung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnControl.Dock = DockStyle.Fill;
            grControl.Text = "Tạo Thông Tin Tuyển Dụng";
            pnControl.Controls.Clear();
            TuyenDung.Tao.ucTaoThongTinTuyenDung ucTaoThongTinTuyenDung = new TuyenDung.Tao.ucTaoThongTinTuyenDung();
            ucTaoThongTinTuyenDung.Dock = DockStyle.Fill;
            pnControl.Controls.Add(ucTaoThongTinTuyenDung);
        }

        private void btnUngVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnControl.Dock = DockStyle.Fill;
            grControl.Text = "Xem Danh Sách Ứng Viên";
            pnControl.Controls.Clear();
            TuyenDung.XemDanhSach.ucXemDanhSachUngVien ucXemDanhSachUngVien = new TuyenDung.XemDanhSach.ucXemDanhSachUngVien();
            ucXemDanhSachUngVien.Dock = DockStyle.Fill;
            pnControl.Controls.Add(ucXemDanhSachUngVien);

        }

        private void btnLichPhongVan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnControl.Dock = DockStyle.Fill;
            grControl.Text = "Xem Danh Sách Lịch Phỏng Vấn";
            pnControl.Controls.Clear();
            TuyenDung.XemDanhSach.ucXemDanhSachLichPhongVan ucXemDanhSachLichPhongVan = new TuyenDung.XemDanhSach.ucXemDanhSachLichPhongVan();
            ucXemDanhSachLichPhongVan.Dock = DockStyle.Fill;
            pnControl.Controls.Add(ucXemDanhSachLichPhongVan);
        }

        private void btnUngVienTrungTuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnControl.Dock = DockStyle.Fill;
            grControl.Text = "Xem Dach Sách Ứng Viên Trúng Tuyển";
            pnControl.Controls.Clear();
            TuyenDung.XemDanhSach.ucXemDanhSachUngVienTrungTuyen ucXemDanhSachUngVienTrungTuyen = new TuyenDung.XemDanhSach.ucXemDanhSachUngVienTrungTuyen();
            ucXemDanhSachUngVienTrungTuyen.Dock = DockStyle.Fill;
            pnControl.Controls.Add(ucXemDanhSachUngVienTrungTuyen);
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
    }
}
   