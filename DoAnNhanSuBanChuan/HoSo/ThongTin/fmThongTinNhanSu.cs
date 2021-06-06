using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DoAnNhanSuBanChuan.DataAccess;
using System.IO;
using DevExpress.XtraEditors.Filtering.Templates;
using System.Data.Common;
using DevExpress.XtraGrid.Views.Grid;

namespace DoAnNhanSuBanChuan.HoSo.ThongTin
{

    public partial class fmThongTinNhanSu : Form
    {
        Data_Access tsx = new Data_Access();
        public fmThongTinNhanSu(string manhanvien, string tennhanvien, string gioitinh, string ngaysinh, string socccd, string ngaycap, string noicap, string trangthai, string sodienthoai, string gmail, string quequan, string Noio, string nguoilienhe, string sodienthoainlh, string nganhang, string sotaikhoan, Image img) :this()
        {

            txtMaNhanVien.Text = manhanvien;
            txtMaNhanVien.ReadOnly = true;
            //txtMaNhanVien.BackColor = System.Drawing.SystemColors.Window;
            txtHoTen.Text = tennhanvien;
            if (gioitinh == "Nam")
            {
                cbNam.Checked = true;
            }
            else
            {
                cbNu.Checked = true;
            }
            dtpNgaySinh.Text = ngaysinh;
            txtSoCCCD.Text = socccd;
            dtpNgayCap.Text = ngaycap;
            txtNoiCap.Text = noicap;
            cbTrangThai.Text = trangthai;
            txtSoDienThoai.Text = sodienthoai;
            txtGmail.Text = gmail;
            txtQueQuan.Text = quequan;
            txtNoiO.Text = Noio;
            txtNguoiLienHe.Text = nguoilienhe;
            txtSoDienThoaiNLH.Text = sodienthoainlh;
            txtNganHang.Text = nganhang;
            txtSoTaiKhoan.Text = sotaikhoan;
            
            pbAnhChanDung.Image = img;

            DataTable hienthihocvan = tsx.CreateTable("SELECT * FROM HOCVANNHANVIEN WHERE MaNV = '" + txtMaNhanVien.Text + "'");
            gcTrinhDoHocVan.DataSource = hienthihocvan;

            DataTable thongtinquatrinhcongtac = tsx.CreateTable("SELECT * FROM QUATRINHCONGTAC WHERE MaNV = '" + txtMaNhanVien.Text + "'");
            gcQuaTrinhCongTac.DataSource = thongtinquatrinhcongtac;

            DataTable thongtinchungchi = tsx.CreateTable("SELECT * FROM CHUNGCHINHANVIEN WHERE MaNV = '" + txtMaNhanVien.Text + "'");
            gcChungChiNhanVien.DataSource = thongtinchungchi;

            DataTable thongtinvitri = tsx.CreateTable("SELECT * FROM PHONGBANCHUCVUNHANVIEN WHERE MaNV = '" + txtMaNhanVien.Text + "'");
            gcChucVuNhanVien.DataSource = thongtinvitri;

            DataTable thongtinphucap = tsx.CreateTable("SELECT * FROM PHUCAPNHANVIEN WHERE MaNV = '" + txtMaNhanVien.Text + "'");
            gcPhuCapNhanVien.DataSource = thongtinphucap;

            DataTable thongtinbaohiem = tsx.CreateTable("SELECT * FROM BAOHIEMNHANVIEN WHERE MaNV = '" + txtMaNhanVien.Text + "'");
            gcBaoHiemNhanVien.DataSource = thongtinbaohiem;

        }

        public fmThongTinNhanSu()
        {
            InitializeComponent();
        }

        private void smbtnHuyBoThongTinNhanSu_Click(object sender, EventArgs e)
        {
            DialogResult ThongBao = MessageBox.Show("Bạn có muốn hủy bỏ không?",
                "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (ThongBao == DialogResult.OK)
            {
                this.Close();
            }

        }

        public bool kiemtranhap()
        {
            if (string.IsNullOrWhiteSpace(txtMaNhanVien.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNhanVien.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Bạn chưa nhập họ và tên nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoTen.Focus();
                return false;
            }
            if (cbNam.Checked == false && cbNu.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSoCCCD.Text))
            {
                MessageBox.Show("Bạn chưa nhập số Căn Cước Công Dân.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoCCCD.Focus();
                return false;
            }
            else
            {
                foreach (Char c in txtSoCCCD.Text)
                {
                    if (!Char.IsDigit(c))
                    {
                        MessageBox.Show("Số Căn Cước Công Dân không có chữ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSoCCCD.Focus();
                        return false;
                    }
                }
            }
            if (string.IsNullOrWhiteSpace(txtNoiCap.Text))
            {
                MessageBox.Show("Bạn chưa nhập nơi cấp CCCD.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNoiCap.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cbTrangThai.Text))
            {
                MessageBox.Show("Bạn chưa chọn trạng thái làm việc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbTrangThai.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoDienThoai.Focus();
                return false;
            }
            else
            {
                foreach (Char c in txtSoDienThoai.Text)
                {
                    if (!Char.IsDigit(c))
                    {
                        MessageBox.Show("Số điện thoại không có chữ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSoDienThoai.Focus();
                        return false;
                    }
                }
            }
            if (string.IsNullOrWhiteSpace(txtGmail.Text))
            {
                MessageBox.Show("Bạn chưa nhập gmail.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGmail.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtQueQuan.Text))
            {
                MessageBox.Show("Bạn chưa nhập quê quán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQueQuan.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNoiO.Text))
            {
                MessageBox.Show("Bạn chưa nhập nơi ở.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNoiO.Focus();
                return false;
            }
            if (pbAnhChanDung.Image==null)
            {
                MessageBox.Show("Bạn chưa chọn ảnh cho nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNguoiLienHe.Text))
            {
                MessageBox.Show("Bạn chưa nhập thông tin người liên hệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNguoiLienHe.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSoDienThoaiNLH.Text))
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại người liên hệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoDienThoaiNLH.Focus();
                return false;
            }
            else
            {
                foreach (Char c in txtSoDienThoaiNLH.Text)
                {
                    if (!Char.IsDigit(c))
                    {
                        MessageBox.Show("Số điện thoại không có chữ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSoDienThoaiNLH.Focus();
                        return false;
                    }
                }
            }
            if (string.IsNullOrWhiteSpace(txtNganHang.Text))
            {
                MessageBox.Show("Bạn chưa nhập thông tin ngân hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNganHang.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSoTaiKhoan.Text))
            {
                MessageBox.Show("Bạn chưa nhập số tài khoản.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoTaiKhoan.Focus();
                return false;
            }
            else
            {
                foreach (Char c in txtSoTaiKhoan.Text)
                {
                    if(!Char.IsDigit(c))
                    {
                        MessageBox.Show("Số tài khoản không có chữ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSoTaiKhoan.Focus();
                        return false;
                    }
                }
            }
            return true;
        }

        private void fmThongTinNhanSu_Load(object sender, EventArgs e)
        {
            btnXoaHocVan.Click += BtnXoaHocVan_Click;
            btnXoaCV.Click += BtnXoaCV_Click;
            btnXoaCC.Click += BtnXoaCC_Click;
            btnXoaPC.Click += BtnXoaPC_Click;
            btnXoaBH.Click += BtnXoaBH_Click;
            btnXoaQTCT.Click += BtnXoaQTCT_Click;
            btnDongYHV.Click += BtnDongYHV_Click;
            btnSuaHV.Click += BtnSuaHV_Click;
            btnThemCC.Click += BtnThemCC_Click;
            btnSuaCC.Click += BtnSuaCC_Click;
            btnThemPC.Click += BtnThemPC_Click;
            btnSuaPC.Click += BtnSuaPC_Click;
            btnThemBH.Click += BtnThemBH_Click;
            btnSuaBH.Click += BtnSuaBH_Click;
            btnThemQTCT.Click += BtnThemQTCT_Click;
            btnSuaQTCT.Click += BtnSuaQTCT_Click;
            btnThemCV.Click += BtnThemCV_Click;
            btnSuaCV.Click += BtnSuaCV_Click;
        }

        //CHỨC VỤ
        private void BtnSuaCV_Click(object sender, EventArgs e)
        {
            thongtinnhap();
            DataTable suacv = tsx.CreateTable("UPDATE PHONGBANCHUCVUNHANVIEN SET GhiChu =N'" + GhiChu + "',NgayNhamChuc = '" + NgayNhamChuc + "' WHERE MaNV = '" + MaNV + "' AND MaPB = '" + MaPB + "'AND MaCV = '" + MaCV + "'");
            MessageBox.Show("Đã sửa thông tin chức vụ !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable thongtinvitri = tsx.CreateTable("SELECT * FROM PHONGBANCHUCVUNHANVIEN WHERE MaNV = '" + txtMaNhanVien.Text + "'");
            gcChucVuNhanVien.DataSource = thongtinvitri;
        }
        private void BtnThemCV_Click(object sender, EventArgs e)
        {
            thongtinnhap();
            DataTable themcv = tsx.CreateTable("INSERT INTO PHONGBANCHUCVUNHANVIEN(MaPB,MaCV,GhiChu,NgayNhamChuc,MaNV) VALUES('" + MaPB + "','" + MaCV + "',N'" + GhiChu + "','" + NgayNhamChuc + "','" + MaNV + "')");
            MessageBox.Show("Đã thêm thông tin chức vụ !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable thongtinvitri = tsx.CreateTable("SELECT * FROM PHONGBANCHUCVUNHANVIEN WHERE MaNV = '" + txtMaNhanVien.Text + "'");
            gcChucVuNhanVien.DataSource = thongtinvitri;
        }
        private void BtnXoaCV_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                thongtinnhap();
                DataTable xoacv = tsx.CreateTable("DELETE FROM PHONGBANCHUCVUNHANVIEN WHERE MaNV = '" + MaNV + "' AND MaPB = '" + MaPB + "' AND MaCV = '" + MaCV + "'");
                MessageBox.Show("Đã xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable thongtinvitri = tsx.CreateTable("SELECT * PHONGBANCHUCVUNHANVIEN WHERE MaNV = '" + txtMaNhanVien.Text + "'");
                gcChucVuNhanVien.DataSource = thongtinvitri;
            }
        }

        //QUÁ TRÌNH CÔNG TÁC
        private void BtnSuaQTCT_Click(object sender, EventArgs e)
        {
            thongtinnhap();
            DataTable suact = tsx.CreateTable("UPDATE QUATRINHCONGTAC SET TuNgay ='" + TuNgay + "',DenNgay ='" + DenNgay + "',TenCongTy ='" + TenCongTy + "'  WHERE MaNV = '" + MaNV + "' AND  MaCT ='" + MaCT + "'");
            MessageBox.Show("Đã sửa thông tin công tác !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable thongtinquatrinhcongtac = tsx.CreateTable("SELECT * FROM QUATRINHCONGTAC WHERE MaNV = '" + txtMaNhanVien.Text + "'");
            gcQuaTrinhCongTac.DataSource = thongtinquatrinhcongtac;
        }
        private void BtnThemQTCT_Click(object sender, EventArgs e)
        {
            thongtinnhap();
            DataTable themct = tsx.CreateTable("INSERT INTO QUATRINHCONGTAC VALUES ('"+MaNV+"','"+TuNgay+"','"+DenNgay+"','"+MaCT+"',N'"+TenCongTy+"')");
            MessageBox.Show("Đã thêm thông tin công tác!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable thongtinquatrinhcongtac = tsx.CreateTable("SELECT * FROM QUATRINHCONGTAC WHERE MaNV = '" + txtMaNhanVien.Text + "'");
            gcQuaTrinhCongTac.DataSource = thongtinquatrinhcongtac;
        }
        private void BtnXoaQTCT_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                thongtinnhap();
                DataTable xoact = tsx.CreateTable("DELETE FROM QUATRINHCONGTAC WHERE MaNV = '" + MaNV + "' AND  MaCT ='" + MaCT + "'");
                MessageBox.Show("Đã xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable thongtinquatrinhcongtac = tsx.CreateTable("SELECT * FROM QUATRINHCONGTAC WHERE MaNV = '" + txtMaNhanVien.Text + "'");
                gcQuaTrinhCongTac.DataSource = thongtinquatrinhcongtac;
            }
        }

        //BẢO HIỂM
        private void BtnSuaBH_Click(object sender, EventArgs e)
        {
            thongtinnhap();
            DataTable suabh = tsx.CreateTable("UPDATE BAOHIEMNHANVIEN SET NgayBatDauBH ='" + NgayBatDauBH + "' WHERE MaNV = '" + MaNV + "' AND  MaBH ='" + MaBH + "'");
            MessageBox.Show("Đã sửa thông tin bảo hiểm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable thongtinbaohiem = tsx.CreateTable("SELECT * FROM BAOHIEMNHANVIEN WHERE MaNV = '" + txtMaNhanVien.Text + "'");
            gcBaoHiemNhanVien.DataSource = thongtinbaohiem;
        }
        private void BtnThemBH_Click(object sender, EventArgs e)
        {
            thongtinnhap();
            DataTable thembh = tsx.CreateTable("INSERT INTO BAOHIEMNHANVIEN(MaNV,MaBH,NgayBatDauBH) VALUES ('" + MaNV + "','" + MaBH + "','" + NgayBatDauBH + "')");
            MessageBox.Show("Đã thêm thông tin bảo hiểm!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable thongtinbaohiem = tsx.CreateTable("SELECT * FROM BAOHIEMNHANVIEN WHERE MaNV = '" + txtMaNhanVien.Text + "'");
            gcBaoHiemNhanVien.DataSource = thongtinbaohiem;
        }
        private void BtnXoaBH_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                thongtinnhap();
                DataTable xoabh = tsx.CreateTable("DELETE FROM BAOHIEMNHANVIEN WHERE MaNV = '" + MaNV + "' AND  MaBH ='" + MaBH + "'");
                MessageBox.Show("Đã xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable thongtinbaohiem = tsx.CreateTable("SELECT * FROM BAOHIEMNHANVIEN WHERE MaNV = '" + txtMaNhanVien.Text + "'");
                gcBaoHiemNhanVien.DataSource = thongtinbaohiem;
            }
        }

        //PHỤ CẤP
        private void BtnSuaPC_Click(object sender, EventArgs e)
        {
            thongtinnhap();
            DataTable suapc = tsx.CreateTable("UPDATE PHUCAPNHANVIEN SET NgayBatDau ='" + NgayBatDau + "' WHERE MaNV = '" + MaNV + "' AND  MaPC ='" + MaPC + "'");
            MessageBox.Show("Đã sửa thông tin phụ cấp !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable thongtinphucap = tsx.CreateTable("SELECT * FROM PHUCAPNHANVIEN WHERE MaNV = '" + txtMaNhanVien.Text + "'");
            gcPhuCapNhanVien.DataSource = thongtinphucap;
        }
        private void BtnThemPC_Click(object sender, EventArgs e)
        {
            thongtinnhap();
            DataTable thempc = tsx.CreateTable("INSERT INTO PHUCAPNHANVIEN(MaNV,MaPC,NgayBatDau) VALUES ('" + MaNV + "','" + MaPC + "','" + NgayBatDau + "')");
            MessageBox.Show("Đã thêm thông tin phụ cấp!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable thongtinphucap = tsx.CreateTable("SELECT * FROM PHUCAPNHANVIEN WHERE MaNV = '" + txtMaNhanVien.Text + "'");
            gcPhuCapNhanVien.DataSource = thongtinphucap;
        }
        private void BtnXoaPC_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                thongtinnhap();
                DataTable xoapc = tsx.CreateTable("DELETE FROM PHUCAPNHANVIEN WHERE MaNV = '" + MaNV + "' AND  MaPC ='" + MaPC + "'");
                MessageBox.Show("Đã xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable thongtinphucap = tsx.CreateTable("SELECT * FROM PHUCAPNHANVIEN WHERE MaNV = '" + txtMaNhanVien.Text + "'");
                gcPhuCapNhanVien.DataSource = thongtinphucap;
            }
        }

        // CHỨNG CHỈ
        private void BtnSuaCC_Click(object sender, EventArgs e)
        {
            thongtinnhap();
            DataTable suacc = tsx.CreateTable("UPDATE CHUNGCHINHANVIEN SET NgayCap ='" + NgayCapCC + "', DonViCap = N'" + DonViCap + "',Loai = N'" + Loai + "' WHERE MaNV = '" + MaNV + "' AND  MaCC ='" + MaCC + "'");
            MessageBox.Show("Đã sửa thông tin chứng chỉ !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable thongtinchungchi = tsx.CreateTable("SELECT * FROM CHUNGCHINHANVIEN WHERE MaNV = '" + txtMaNhanVien.Text + "'");
            gcChungChiNhanVien.DataSource = thongtinchungchi;

        }
        private void BtnThemCC_Click(object sender, EventArgs e)
        {
            thongtinnhap();
            DataTable themcc = tsx.CreateTable("INSERT INTO CHUNGCHINHANVIEN(MaNV,MaCC,DonViCap,NgayCap,Loai) VALUES ('" + MaNV + "','" + MaCC + "',N'" + DonViCap + "', '" + NgayCapCC + "',N'" + Loai + "')");
            MessageBox.Show("Đã thêm thông tin chứng chỉ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable thongtinchungchi = tsx.CreateTable("SELECT * FROM CHUNGCHINHANVIEN WHERE MaNV = '" + txtMaNhanVien.Text + "'");
            gcChungChiNhanVien.DataSource = thongtinchungchi;

        }
        private void BtnXoaCC_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                thongtinnhap();
                DataTable xoacc = tsx.CreateTable("DELETE FROM CHUNGCHINHANVIEN WHERE MaNV = '" + MaNV + "' AND  MaCC ='" + MaCC + "'");
                MessageBox.Show("Đã xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable thongtinchungchi = tsx.CreateTable("SELECT * FROM CHUNGCHINHANVIEN WHERE MaNV = '" + txtMaNhanVien.Text + "'");
                gcChungChiNhanVien.DataSource = thongtinchungchi;
            }
        }

        //HỌC VẤN
        private void BtnSuaHV_Click(object sender, EventArgs e)
        {
            thongtinnhap();
            DataTable sua = tsx.CreateTable("UPDATE HOCVANNHANVIEN SET ChuyenNganh =N'" + ChuyenNganh + "', NamTotNghiep ='" + NamTotNghiep + "', XepLoai =N'" + XepLoai + "' WHERE MaNV = '" + MaNV + "' AND MaHV = '" + MaHV + "' AND NoiDaoTao = '" + MaNoiDaoTao + "'");
            MessageBox.Show("Đã sửa thông tin học vấn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable hienthihocvan = tsx.CreateTable("SELECT * FROM HOCVANNHANVIEN WHERE MaNV = '" + txtMaNhanVien.Text + "'");
            gcTrinhDoHocVan.DataSource = hienthihocvan;
        }
        private void BtnDongYHV_Click(object sender, EventArgs e)
        {
            thongtinnhap();
            DataTable them = tsx.CreateTable("INSERT INTO HOCVANNHANVIEN(MaHV,MaNoiDaoTao,ChuyenNganh,NamTotNghiep,XepLoai,MaNV) VALUES ('" + MaHV + "','" + MaNoiDaoTao + "',N'" + ChuyenNganh + "', '" + NamTotNghiep + "',N'" + XepLoai + "','" + txtMaNhanVien.Text + "')");
            MessageBox.Show("Đã thêm thông tin học vấn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable hienthihocvan = tsx.CreateTable("SELECT * FROM HOCVANNHANVIEN WHERE MaNV = '" + txtMaNhanVien.Text + "'");
            gcTrinhDoHocVan.DataSource = hienthihocvan;
        }
        private void BtnXoaHocVan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                thongtinnhap();
                DataTable xoa = tsx.CreateTable("DELETE FROM HOCVANNHANVIEN WHERE MaNV = '" + MaNV + "' AND MaHV = '" + MaHV + "' AND MaNoiDaoTao = '" + MaNoiDaoTao + "' ");
                MessageBox.Show("Đã xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable hienthihocvan = tsx.CreateTable("SELECT * HOCVANNHANVIEN WHERE MaNV = '" + txtMaNhanVien.Text + "'");
                gcTrinhDoHocVan.DataSource = hienthihocvan;
            }
        }




        string MaNV, HoTen, GioiTinh, NgaySinh, SoCCCD, NgayCap, NoiCap, TrangThai, SoDienThoai, Gmail, QueQuan, NoiO, NguoiLienHe, SoDienThoaiNLH, NganHang, SoTaiKhoan;

        private void spbtnLamMoi_Click_1(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            cbNam.Checked = false;
            cbNu.Checked = false;
            txtSoCCCD.Clear();
            txtNoiCap.Clear();
            cbTrangThai.Text = "";
            txtSoDienThoai.Clear();
            txtGmail.Clear();
            txtQueQuan.Clear();
            txtNoiO.Clear();
            txtNguoiLienHe.Clear();
            txtSoDienThoaiNLH.Clear();
            txtNganHang.Clear();
            txtSoTaiKhoan.Clear();
        }

        string MaHV, MaNoiDaoTao, ChuyenNganh, NamTotNghiep, XepLoai,MaPB,MaCV,GhiChu,NgayNhamChuc,MaCC,DonViCap,NgayCapCC,MaPC,NgayBatDau,MaBH,Loai, NgayBatDauBH,TuNgay,DenNgay, MaCT, TenCongTy;
        public void thongtinnhap()
        {
            MaNV = txtMaNhanVien.Text.Trim();

            HoTen = txtHoTen.Text.Trim();

            if (cbNam.Checked == true)
            {
                GioiTinh = "Nam";
            }
            else if (cbNu.Checked == true)
            {
                GioiTinh = "Nữ";
            }
            NgaySinh = dtpNgaySinh.Value.ToString();

            SoCCCD = txtSoCCCD.Text.Trim();
          
            NgayCap = dtpNgayCap.Value.ToString();

            NoiCap = txtNoiCap.Text.Trim();

            TrangThai = cbTrangThai.Text;

            SoDienThoai = txtSoDienThoai.Text.Trim();

            Gmail = txtGmail.Text.Trim();

            QueQuan = txtQueQuan.Text.Trim();

            NoiO = txtNoiO.Text.Trim();

            NguoiLienHe = txtNguoiLienHe.Text.Trim();

            SoDienThoaiNLH = txtSoDienThoaiNLH.Text.Trim();

            NganHang = txtNganHang.Text.Trim();

            SoTaiKhoan = txtSoTaiKhoan.Text.Trim();

            MaHV = gvHocVanNhanVien.GetRowCellValue(gvHocVanNhanVien.FocusedRowHandle, "MaHV").ToString();
            MaNoiDaoTao = gvHocVanNhanVien.GetRowCellValue(gvHocVanNhanVien.FocusedRowHandle, "MaNoiDaoTao").ToString();
            ChuyenNganh = gvHocVanNhanVien.GetRowCellValue(gvHocVanNhanVien.FocusedRowHandle, "ChuyenNganh").ToString();
            NamTotNghiep = gvHocVanNhanVien.GetRowCellValue(gvHocVanNhanVien.FocusedRowHandle, "NamTotNghiep").ToString();
            XepLoai = gvHocVanNhanVien.GetRowCellValue(gvHocVanNhanVien.FocusedRowHandle, "XepLoai").ToString();

            MaCC = gvChungChiNhanVien.GetRowCellValue(gvChungChiNhanVien.FocusedRowHandle, "MaCC").ToString();
            DonViCap = gvChungChiNhanVien.GetRowCellValue(gvChungChiNhanVien.FocusedRowHandle, "DonViCap").ToString();
            NgayCapCC = gvChungChiNhanVien.GetRowCellValue(gvChungChiNhanVien.FocusedRowHandle, "NgayCap").ToString();
            Loai = gvChungChiNhanVien.GetRowCellValue(gvChungChiNhanVien.FocusedRowHandle, "Loai").ToString();

            MaPB = gvChucVuNhanVien.GetRowCellValue(gvChucVuNhanVien.FocusedRowHandle, "MaPB").ToString();
            MaCV = gvChucVuNhanVien.GetRowCellValue(gvChucVuNhanVien.FocusedRowHandle, "MaCV").ToString();
            GhiChu = gvChucVuNhanVien.GetRowCellValue(gvChucVuNhanVien.FocusedRowHandle, "GhiChu").ToString();
            NgayNhamChuc = gvChucVuNhanVien.GetRowCellValue(gvChucVuNhanVien.FocusedRowHandle, "NgayNhamChuc").ToString();

            MaPC = bgvPhuCapNhanVien.GetRowCellValue(bgvPhuCapNhanVien.FocusedRowHandle, "MaPC").ToString();
            NgayBatDau = bgvPhuCapNhanVien.GetRowCellValue(bgvPhuCapNhanVien.FocusedRowHandle, "NgayBatDau").ToString();

            MaBH = bgvBaoHiemNhanVien.GetRowCellValue(bgvBaoHiemNhanVien.FocusedRowHandle, "MaBH").ToString();
            NgayBatDauBH = bgvBaoHiemNhanVien.GetRowCellValue(bgvBaoHiemNhanVien.FocusedRowHandle, "NgayBatDauBH").ToString();

            TuNgay = gvQuaTrinhCongTac.GetRowCellValue(gvQuaTrinhCongTac.FocusedRowHandle, "TuNgay").ToString();
            DenNgay = gvQuaTrinhCongTac.GetRowCellValue(gvQuaTrinhCongTac.FocusedRowHandle, "DenNgay").ToString();
            MaCT = gvQuaTrinhCongTac.GetRowCellValue(gvQuaTrinhCongTac.FocusedRowHandle, "MaCT").ToString();
            TenCongTy = gvQuaTrinhCongTac.GetRowCellValue(gvQuaTrinhCongTac.FocusedRowHandle, "TenCongTy").ToString();
        }

        public bool kiemtranhap2()
        {
            thongtinnhap();
            DataTable kiemtra1 = tsx.CreateTable("select * from NHANVIEN;");
            for (int i = 0; i < kiemtra1.Rows.Count; i++)
                if (MaNV == kiemtra1.Rows[i]["MaNV"].ToString())
                {
                    MessageBox.Show("Mã nhân viên này đã được dùng, mời chọn mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            return true;
        }
        public void themthongtinnhanvien()
        {
            thongtinnhap();            
            byte[] anhluu = chuyendoianhsangdangbyte(pbAnhChanDung.Image);
            DataTable dt = tsx.CreateTable("INSERT INTO NHANVIEN VALUES ('" + MaNV + "',N'" + HoTen + "',N'" + GioiTinh + "','" + NgaySinh + "', '" + SoCCCD + "', N'" + NgayCap + "', N'" + NoiCap + "',N'" + TrangThai + "', '" + SoDienThoai + "', '" + Gmail + "', N'" + QueQuan + "', N'" + NoiO + "',N'" + NguoiLienHe + "','" + SoDienThoaiNLH + "',N'" + NganHang + "', '" + SoTaiKhoan + "',@anhluu)",anhluu);           
            MessageBox.Show("Đã thêm nhân viên có mã " + MaNV + " thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

    }   
        public void suathongtinnhanvien()
        {
            thongtinnhap();
            byte[] anhluu = chuyendoianhsangdangbyte(pbAnhChanDung.Image);
            DataTable dt = tsx.CreateTable("UPDATE NHANVIEN SET MaNV = '" + MaNV + "',HoTen= N'" + HoTen + "',GioiTinh = N'" + GioiTinh + "',NgaySinh = '" + NgaySinh + "',SoCCCD =  '" + SoCCCD + "',NgayCap = N'" + NgayCap + "', NoiCap = N'" + NoiCap + "',TrangThai = N'" + TrangThai + "',SoDienThoai = '" + SoDienThoai + "',Gmail = '" + Gmail + "',QueQuan = N'" + QueQuan + "',NoiO = N'" + NoiO + "',AnhChanDung =@anhluu,NguoiLienHe = N'" + NguoiLienHe + "',SoDienThoaiNLH = '" + SoDienThoaiNLH + "',NganHang = N'" + NganHang + "',SoTaiKhoan = '" + SoTaiKhoan + "' WHERE MaNV = '" + MaNV + "' ",anhluu);
            MessageBox.Show("Đã sửa nhân viên có mã " + MaNV + " thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            
        }

        public byte[] chuyendoianhsangdangbyte(System.Drawing.Image anh)
        {
            MemoryStream ms = new MemoryStream();
            anh.Save(ms, anh.RawFormat);
            return ms.ToArray();
        }
        private void spbtnChapNhanThongTinNhanSu_Click(object sender, EventArgs e)
        {
            if (kiemtranhap() == true)
            {
                if (txtMaNhanVien.ReadOnly == false)
                {
                    if (kiemtranhap2() == true)
                    {
                        themthongtinnhanvien();
                    }
                }
                else
                {                   
                    suathongtinnhanvien();
                }
            }
        }
        
        private void spbtnTaiAnhLen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                pbAnhChanDung.ImageLocation = openFile.FileName;
                txtDuongDan.Text = openFile.FileName;
            }

        }
        private void bidingNamNu(object sender, EventArgs e)
        {
            if (cbNam.Checked == true)
            {
                cbNu.Enabled = false;
            }
            else
            {
                cbNu.Enabled = true;
            }

            if (cbNu.Checked == true)
            {
                cbNam.Enabled = false;
            }
            else
            {
                cbNam.Enabled = true;
            }
        }       
    }
    
}
