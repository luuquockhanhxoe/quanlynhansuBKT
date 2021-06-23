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
using System.Data.SqlClient;
using DoAnNhanSuBanChuan.DataAccess;
using System.IO;

namespace DoAnNhanSuBanChuan.HoSo.ThongTin
{
    public partial class ucThongTinNhanSu : DevExpress.XtraEditors.XtraUserControl
    {
        Data_Access da = new Data_Access();
        void hienthithongtincoban()
        {
            DataTable thongtincoban = da.CreateTable("SELECT MaNV,HoTen,GioiTinh,NgaySinh,SoCCCD,NgayCap,NoiCap,TrangThai,SoDienThoai,Gmail,QueQuan,NoiO,NguoiLienHe,SoDienThoaiNLH, NganHang, SoTaiKhoan, AnhChanDung FROM NHANVIEN");
            gcHienThiThongTin.DataSource = thongtincoban;
            ganketdulieu();
        }
        void hienthithongtinhocvan()
        {
            string tmp = maNV.Trim();
            DataTable thongtinhocvan = da.CreateTable("SELECT HOCVAN.TrinhDo, HOCVANNHANVIEN.MaNoiDaoTao, HOCVANNHANVIEN.ChuyenNganh, HOCVANNHANVIEN.NamTotNghiep, HOCVANNHANVIEN.XepLoai FROM(( NHANVIEN LEFT JOIN HOCVANNHANVIEN ON NHANVIEN.MaNV = HOCVANNHANVIEN.MaNV) LEFT JOIN HOCVAN ON HOCVANNHANVIEN.MaHV = HOCVAN.MaHV) WHERE NHANVIEN.MaNV = '" +tmp+ "'");
            gcHocVanNhanVien.DataSource = thongtinhocvan;
        }
        void hienthiquatrinhcongtac()
        {
            string tmp = maNV.Trim();
            DataTable thongtinquatrinhcongtac = da.CreateTable("SELECT * FROM QUATRINHCONGTAC WHERE MaNV = '" +tmp+ "'");
            gcQuaTrinhCongTac.DataSource = thongtinquatrinhcongtac;
        }
        void hienthithongtinphongbanchucvu()
        {
            string tmp = maNV.Trim();
            DataTable thongtinchucvu = da.CreateTable("SELECT PHONGBAN.TenPB, CHUCVU.TenCV, PHONGBANCHUCVUNHANVIEN.GhiChu,PHONGBANCHUCVUNHANVIEN.NgayNhamChuc FROM ((PHONGBANCHUCVUNHANVIEN LEFT JOIN CHUCVU ON PHONGBANCHUCVUNHANVIEN.MaCV = CHUCVU.MaCV) LEFT JOIN PHONGBAN ON PHONGBANCHUCVUNHANVIEN.MaPB = PHONGBAN.MaPB) WHERE PHONGBANCHUCVUNHANVIEN.MaNV = '" + tmp + "'");
            gcChucVuNhanVien.DataSource = thongtinchucvu;
        }     
        void hienthithongtinchungchi()
        {
            string tmp = maNV.Trim();
            DataTable thongtinchungchi = da.CreateTable("SELECT CHUNGCHI.TenChungChi, CHUNGCHINHANVIEN.DonViCap,CHUNGCHINHANVIEN.NgayCap,CHUNGCHINHANVIEN.Loai FROM ((CHUNGCHINHANVIEN LEFT JOIN CHUNGCHI ON CHUNGCHINHANVIEN.MaCC = CHUNGCHI.MaCC) LEFT JOIN NHANVIEN ON CHUNGCHINHANVIEN.MaNV = NHANVIEN.MaNV) WHERE NHANVIEN.MaNV = '" + tmp + "'");
            gcChungChiNhanVien.DataSource = thongtinchungchi;
        }
        void hienthithongtinkyluat()
        {
            string tmp = maNV.Trim();
            DataTable thongtinkyluat = da.CreateTable("SELECT KYLUATNHANVIEN.NgayKyLuat, KYLUATNHANVIEN.LyDo, KYLUAT.TenKyLuat FROM KYLUATNHANVIEN LEFT JOIN KYLUAT ON KYLUATNHANVIEN.MaKyLuat = KYLUAT.MaKyLuat  WHERE KYLUATNHANVIEN.MaNV = '" + tmp + "'");
            gcKyLuatNhanVien.DataSource = thongtinkyluat;
        }
        void hienthithongkhenthuong()
        {
            string tmp = maNV.Trim();
            DataTable thongtinkhenthuong = da.CreateTable("SELECT KHENTHUONGNHANVIEN.NgayKhenThuong, KHENTHUONGNHANVIEN.LyDo, KHENTHUONG.TenKhenThuong FROM KHENTHUONGNHANVIEN LEFT JOIN KHENTHUONG ON KHENTHUONGNHANVIEN.MaKhenThuong = KHENTHUONG.MaKhenThuong  WHERE KHENTHUONGNHANVIEN.MaNV = '" + tmp + "'");
            gcKhenThuongNhanVien.DataSource = thongtinkhenthuong;
        }
        void hienthithongtinthunhap()
        {
            string tmp = maNV.Trim();
            DataTable thongtinthunhap = da.CreateTable("SELECT * FROM TINHLUONGNHANVIEN WHERE MaNV = '" + tmp + "'");
            gcThuNhap.DataSource = thongtinthunhap;
        }
        void hienthithongtinphucapbaohiem()
        {
            string tmp = maNV.Trim();
            DataTable thongtinphucap = da.CreateTable("SELECT PHUCAP.TenPC, PHUCAPNHANVIEN.NgayBatDau FROM ((PHUCAPNHANVIEN LEFT JOIN PHUCAP ON PHUCAPNHANVIEN.MaPC = PHUCAP.MaPC) LEFT JOIN NHANVIEN ON PHUCAPNHANVIEN.MaNV = NHANVIEN.MaNV) WHERE NHANVIEN.MaNV = '" + tmp + "'");
            gcPhuCapNhanVien.DataSource = thongtinphucap;
            DataTable thongtinbaohiem = da.CreateTable("SELECT BAOHIEM.TenBaoHiem, BAOHIEMNHANVIEN.NgayBatDauBH FROM ((BAOHIEMNHANVIEN LEFT JOIN BAOHIEM ON BAOHIEMNHANVIEN.MaBH = BAOHIEM.MaBH) LEFT JOIN NHANVIEN ON BAOHIEMNHANVIEN.MaNV = NHANVIEN.MaNV) WHERE NHANVIEN.MaNV = '" + tmp + "'");
            gcBaoHiemNhanVien.DataSource = thongtinbaohiem;
        }

        public ucThongTinNhanSu()
        {
            InitializeComponent();
            hienthithongtincoban();
        }
        public void ganketdulieu()
        {
            lbMaNV.DataBindings.Clear();
            lbMaNV.DataBindings.Add("text", gcHienThiThongTin.DataSource, "MaNV"); 
            lbHoTen.DataBindings.Clear();
            lbHoTen.DataBindings.Add("text", gcHienThiThongTin.DataSource, "HoTen");
            lbGioiTinh.DataBindings.Clear();
            lbGioiTinh.DataBindings.Add("text", gcHienThiThongTin.DataSource, "GioiTinh");
            lbNgaySinh.DataBindings.Clear();
            lbNgaySinh.DataBindings.Add("text", gcHienThiThongTin.DataSource, "NgaySinh");
            lbSoCCCD.DataBindings.Clear();
            lbSoCCCD.DataBindings.Add("text", gcHienThiThongTin.DataSource, "SoCCCD");
            lbNgayCap.DataBindings.Clear();
            lbNgayCap.DataBindings.Add("text", gcHienThiThongTin.DataSource, "NgayCap");
            lbNoiCap.DataBindings.Clear();
            lbNoiCap.DataBindings.Add("text", gcHienThiThongTin.DataSource, "NoiCap");
            lbTrangThai.DataBindings.Clear();
            lbTrangThai.DataBindings.Add("text", gcHienThiThongTin.DataSource, "TrangThai");
            lbSoDienThoai.DataBindings.Clear();
            lbSoDienThoai.DataBindings.Add("text", gcHienThiThongTin.DataSource, "SoDienThoai");
            lbGmail.DataBindings.Clear();
            lbGmail.DataBindings.Add("text", gcHienThiThongTin.DataSource, "Gmail");
            lbQueQuan.DataBindings.Clear();
            lbQueQuan.DataBindings.Add("text", gcHienThiThongTin.DataSource, "QueQuan");
            lbNoiO.DataBindings.Clear();
            lbNoiO.DataBindings.Add("text", gcHienThiThongTin.DataSource, "NoiO");
            lbNguoiLienHe.DataBindings.Clear();
            lbNguoiLienHe.DataBindings.Add("text", gcHienThiThongTin.DataSource, "NguoiLienHe");
            lbSoDienThoaiNLH.DataBindings.Clear();
            lbSoDienThoaiNLH.DataBindings.Add("text", gcHienThiThongTin.DataSource, "SoDienThoaiNLH");
            lbNganHang.DataBindings.Clear();
            lbNganHang.DataBindings.Add("text", gcHienThiThongTin.DataSource, "NganHang");
            lbSoTaiKhoan.DataBindings.Clear();
            lbSoTaiKhoan.DataBindings.Add("text", gcHienThiThongTin.DataSource, "SoTaiKhoan");
        }
        string maNV;
        Image img;
        private void grdView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
             maNV = grdView.GetFocusedRowCellValue("MaNV").ToString();                         
             hienthithongtinhocvan();
             hienthiquatrinhcongtac();
             hienthithongtinchungchi();
             hienthithongtinphongbanchucvu();
             hienthithongtinphucapbaohiem();
             hienthithongtinkyluat();
             hienthithongkhenthuong();
             hienthithongtinthunhap();


            byte[] getImg = (byte[])grdView.GetRowCellValue(grdView.FocusedRowHandle, "AnhChanDung");
            MemoryStream stream = new MemoryStream(getImg);
            img = Image.FromStream(stream);
            pbAnhChanDung.Image = img;

        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            DataTable thongtincoban = da.CreateTable("SELECT * FROM NHANVIEN WHERE MaNV LIKE '%"+txtTimKiem.Text+ "%' OR HoTen LIKE N'%" + txtTimKiem.Text + "%' OR GioiTinh LIKE N'%" + txtTimKiem.Text + "%' OR NgaySinh LIKE '%" + txtTimKiem.Text + "%' OR TrangThai LIKE N'%" + txtTimKiem.Text + "%' OR SoDienThoai LIKE '%" + txtTimKiem.Text + "%' OR Gmail LIKE '%" + txtTimKiem.Text + "%'");
            if(thongtincoban.Rows.Count == 0)
            {
                DialogResult ThongBao = MessageBox.Show("Không tìm thấy dữ liệu!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            else
            {
                gcHienThiThongTin.DataSource = thongtincoban;
                ganketdulieu();
            }
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTim.PerformClick();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            hienthithongtincoban();
            txtTimKiem.Clear();
        }

        private void spbtnThemNhanSu_Click(object sender, EventArgs e)
        {
            fmThongTinNhanSu themnhansu = new fmThongTinNhanSu();
            themnhansu.Text = "Thêm Thông Tin Nhân Sự";
            themnhansu.ShowDialog();
            hienthithongtincoban();
        }

        private void spbtnXemVaSuaNhanSu_Click(object sender, EventArgs e)
        {
            string manhanvien = lbMaNV.Text;
            string tennhanvien = lbHoTen.Text;
            string gioitinh = lbGioiTinh.Text;
            string ngaysinh = lbNgaySinh.Text;
            string socccd = lbSoCCCD.Text;
            string ngaycap = lbNgayCap.Text;
            string noicap = lbNoiCap.Text;
            string trangthai = lbTrangThai.Text;
            string sodienthoai = lbSoDienThoai.Text;
            string gmail = lbGmail.Text;
            string quequan = lbQueQuan.Text;
            string Noio = lbNoiO.Text;
            string nguoilienhe = lbNguoiLienHe.Text;
            string sodienthoainlh = lbSoDienThoaiNLH.Text;
            string nganhang = lbNganHang.Text;
            string sotaikhoan = lbSoTaiKhoan.Text;
            fmThongTinNhanSu themnhansu = new fmThongTinNhanSu(manhanvien, tennhanvien, gioitinh, ngaysinh, socccd, ngaycap, noicap, trangthai, sodienthoai, gmail, quequan, Noio, nguoilienhe, sodienthoainlh, nganhang, sotaikhoan, img);
            themnhansu.Text = "Xem và Sửa Thông Tin Nhân Sự";
            themnhansu.ShowDialog();
            hienthithongtincoban();
        }

        private void spbtnXoa_Click_1(object sender, EventArgs e)
        {
            DialogResult ThongBao = MessageBox.Show("Bạn có chắc chắn xóa không?", "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (ThongBao == DialogResult.OK)
            {
                string tmp = maNV.Trim();
                DataTable dt = da.CreateTable("DELETE FROM NHANVIEN WHERE MaNV ='" + tmp + "'");
                hienthithongtincoban();
            }
        }

        private void btnGmail_Click_1(object sender, EventArgs e)
        {
            string gmail = lbGmail.Text;
            fmGuiGmail guimail = new fmGuiGmail(gmail);
            guimail.Text = "Gửi Gmail";
            guimail.ShowDialog();
            hienthithongtincoban();
        }

        private void btnHopDong_Click(object sender, EventArgs e)
        {
            fmThongTinHopDong hopdong = new fmThongTinHopDong();
            hopdong.Text = "Thông Tin Hợp Đồng";
            hopdong.ShowDialog();
            hienthithongtincoban();
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            var r = new rpThongTinNhanVien();
            DataTable inthongtin = da.CreateTable("SELECT * FROM NHANVIEN");
            r.DataSource = inthongtin;
            r.hienthipreview();
        }
    }
}
