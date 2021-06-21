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

namespace DoAnNhanSuBanChuan.TinhLuong.TinhToan
{
    public partial class ucTinhToanLuong : DevExpress.XtraEditors.XtraUserControl
    {
        Data_Access tinhluong = new Data_Access();
        public ucTinhToanLuong()
        {
            InitializeComponent();
        }
        public void hienthithongtin()
        {
            DataTable hienthithongtintinhluong = tinhluong.CreateTable("SELECT I.MaNV,I.HoTen,ISNULL(I.LuongCoBan,0) as LuongCoBan, ISNULL(I.HeSoLuong,0) as HeSoLuong ,ISNULL(I.TongBH, 0) as TongBH,ISNULL(I.TongKL, 0) as TongKL, ISNULL(I.TongKT,0) as TongKT, ISNULL(I.TongPC,0) as TongPC, ISNULL(H.SoGioLamThem,0)as SoGioLamThem, ISNULL(H.SoNgayLam,0) as SoNgayLam, (((ISNULL(LuongCoBan,0) * ISNULL(HeSoLuong,0))/25)*ISNULL(SoNgayLam,0) - ISNULL(TongBH,0) - ISNULL(TongKL,0) + ISNULL(TongKT,0) + ISNULL(TongPC,0) + ISNULL(SoGioLamThem,0)*"+txtTienCongThemGio.Text+" ) as SoTienNhan FROM (SELECT NHANVIEN.MaNV, SUM(CHAMCONGHANGNGAY.SoGioLamThem) as SoGioLamThem, COUNT(CHAMCONGHANGNGAY.ThongTinDiLam) as SoNgayLam FROM NHANVIEN LEFT JOIN CHAMCONGHANGNGAY ON NHANVIEN.MaNV = CHAMCONGHANGNGAY.MaNV WHERE CHAMCONGHANGNGAY.ThongTinDiLam = N'Đi làm' AND CHAMCONGHANGNGAY.NgayDiLam BETWEEN '"+dtpTuNgay.Text+"' AND '"+dtpDenNgay.Text+"' GROUP BY NHANVIEN.MaNV) H FULL JOIN (SELECT E.MaNV,E.HoTen,E.LuongCoBan,E.HeSoLuong,G.TongBH,G.TongKL,G.TongKT,G.TongPC FROM (SELECT NHANVIEN.MaNV, NHANVIEN.HoTen ,HOPDONG.HeSoLuong,LUONG.LuongCoBan FROM NHANVIEN LEFT JOIN HOPDONG ON NHANVIEN.MaNV = HOPDONG.MaNV LEFT JOIN LUONG ON HOPDONG.BacLuong = LUONG.BacLuong) E FULL JOIN (SELECT C.MaNV, C.TongKT,C.TongPC, D.TongBH,D.TongKL FROM (SELECT A.MaNV, A.TongPC, B.TongKT FROM (SELECT NHANVIEN.MaNV, SUM(PHUCAP.SoTien) as TongPC FROM NHANVIEN LEFT JOIN PHUCAPNHANVIEN ON NHANVIEN.MaNV = PHUCAPNHANVIEN.MaNV LEFT JOIN PHUCAP ON PHUCAPNHANVIEN.MaPC = PHUCAP.MaPC GROUP BY NHANVIEN.MaNV) A FULL JOIN (SELECT NHANVIEN.MaNV, SUM(KHENTHUONG.GiaTriKhenThuong) as TongKT FROM NHANVIEN LEFT JOIN KHENTHUONGNHANVIEN ON NHANVIEN.MaNV = KHENTHUONGNHANVIEN.MaNV LEFT JOIN KHENTHUONG ON KHENTHUONGNHANVIEN.MaKhenThuong = KHENTHUONG.MaKhenThuong GROUP BY NHANVIEN.MaNV) B ON A.MaNV = B.MaNV) C FULL JOIN (SELECT A.MaNV, A.TongBH, B.TongKL FROM (SELECT NHANVIEN.MaNV, SUM(BAOHIEM.SoTien) as TongBH FROM NHANVIEN LEFT JOIN BAOHIEMNHANVIEN ON NHANVIEN.MaNV = BAOHIEMNHANVIEN.MaNV LEFT JOIN BAOHIEM ON BAOHIEMNHANVIEN.MaBH = BAOHIEM.MaBH GROUP BY NHANVIEN.MaNV) A FULL JOIN (SELECT NHANVIEN.MaNV, SUM(KYLUAT.SoTienKyLuat) as TongKL FROM NHANVIEN LEFT JOIN KYLUATNHANVIEN ON NHANVIEN.MaNV = KYLUATNHANVIEN.MaNV LEFT JOIN KYLUAT ON KYLUATNHANVIEN.MaKyLuat = KYLUAT.MaKyLuat GROUP BY NHANVIEN.MaNV) B ON A.MaNV = B.MaNV) D ON C.MaNV = D.MaNV) G ON E.MaNV = G.MaNV ) I ON H.MaNV = I.MaNV");
            gcTinhLuong.DataSource = hienthithongtintinhluong;
        }

        private void ucTinhToanLuong_Load(object sender, EventArgs e)
        {
            
        }

        public bool kiemtrachon()
        {
            if (string.IsNullOrWhiteSpace(txtTienCongThemGio.Text))
            {
                MessageBox.Show("Bạn chưa nhập số tiền làm thêm 1 giờ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTienCongThemGio.Focus();
                return false;
            }
            else
            {
                foreach (Char c in txtTienCongThemGio.Text)
                {
                    if (!Char.IsDigit(c))
                    {
                        MessageBox.Show("Bạn phải nhập một con số!.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTienCongThemGio.Focus();
                        return false;
                    }
                }
            }
            if (txtTienCongThemGio.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập số tiền công làm thêm 1 giờ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTienCongThemGio.Focus();
                return false;
            }
            return true;
        }
        private void btnTinh_Click(object sender, EventArgs e)
        {
            if (kiemtrachon() == true)
            {
                hienthithongtin();
                ganketdulieu();
            }
        }
        string maNV;
        void hienthithongtindikem()
        {
            string tmp = maNV.Trim();
            DataTable hienthiphucap = tinhluong.CreateTable("SELECT TenPC, SoTien FROM PHUCAPNHANVIEN LEFT JOIN PHUCAP ON PHUCAPNHANVIEN.MaPC = PHUCAP.MaPC WHERE PHUCAPNHANVIEN.MaNV = '" + tmp+"'");
            gcPhuCap.DataSource = hienthiphucap;

            DataTable hienthikhenthuong = tinhluong.CreateTable("SELECT TenKhenThuong, GiaTriKhenThuong FROM KHENTHUONGNHANVIEN LEFT JOIN KHENTHUONG ON KHENTHUONGNHANVIEN.MaKhenThuong = KHENTHUONG.MaKhenThuong WHERE KHENTHUONGNHANVIEN.MaNV = '" + tmp + "'");
            gcKhenThuong.DataSource = hienthikhenthuong;

            DataTable hienthikyluat = tinhluong.CreateTable("SELECT TenKyLuat, SoTienKyLuat FROM KyLuatNhanVien LEFT JOIN KyLuat ON KyLuatNhanVien.MaKyLuat = KyLuat.MaKyLuat WHERE KyLuatNhanVien.MaNV = '" + tmp + "'");
            gcKyLuat.DataSource = hienthikyluat;

            DataTable hienthibaohiem = tinhluong.CreateTable("SELECT TenBaoHiem, SoTien FROM BAOHIEMNHANVIEN LEFT JOIN BAOHIEM ON BAOHIEMNHANVIEN.MaBH = BAOHIEM.MaBH WHERE BAOHIEMNHANVIEN.MaNV = '" + tmp + "'");
            gcBaoHiem.DataSource = hienthibaohiem;
        }

        private void gvTinhLuong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            maNV = gvTinhLuong.GetFocusedRowCellValue("MaNV").ToString();
            hienthithongtindikem();
        }
        public void ganketdulieu()
        {
            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("text", gcTinhLuong.DataSource, "MaNV");
            txtMaNV.ReadOnly = true;
            txtMaNV.BackColor = System.Drawing.SystemColors.Window;
            txtSoTienNhan.DataBindings.Clear();
            txtSoTienNhan.DataBindings.Add("text", gcTinhLuong.DataSource, "SoTienNhan");
            txtSoTienNhan.ReadOnly = true;
            txtSoTienNhan.BackColor = System.Drawing.SystemColors.Window;
        }
        public bool kiemtrathanhtoanchua()
        {           
            DataTable kiemtra = tinhluong.CreateTable("SELECT * FROM TINHLUONGNHANVIEN WHERE NgayNhan = '"+dtpNgayNhan.Text+"'");
            for (int i = 0; i < kiemtra.Rows.Count; i++)
                if (txtMaNV.Text == kiemtra.Rows[i]["MaNV"].ToString())
                {
                    return false;
                }
            return true;
        }
        public void thanhtoanluong()
        {
            DataTable hienthikyluat = tinhluong.CreateTable("INSERT INTO TINHLUONGNHANVIEN VALUES ('" + txtMaNV.Text + "','" + dtpNgayNhan.Text + "','" + txtSoTienNhan.Text + "',N'" + cbHinhThucNhan.Text + "', N'" + txtChuThich.Text + "' )");
            MessageBox.Show("Đã thanh toán lương cho nhân viên mã "+txtMaNV.Text+"", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnDongY_Click(object sender, EventArgs e)
        {
            if(cbHinhThucNhan.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn hình thức nhận tiền cho nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbHinhThucNhan.Focus();
            }
            else
            {
                if(kiemtrathanhtoanchua() == true)
                {
                    thanhtoanluong();
                }
                else
                {
                    MessageBox.Show("Đã thanh toán, vui lòng thanh toán cho người khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }        
        }

        public void timkiem()
        {
            DataTable hienthithongtintinhluong = tinhluong.CreateTable("SELECT I.MaNV,I.HoTen,ISNULL(I.LuongCoBan,0) as LuongCoBan, ISNULL(I.HeSoLuong,0) as HeSoLuong ,ISNULL(I.TongBH, 0) as TongBH,ISNULL(I.TongKL, 0) as TongKL, ISNULL(I.TongKT,0) as TongKT, ISNULL(I.TongPC,0) as TongPC, ISNULL(H.SoGioLamThem,0)as SoGioLamThem, ISNULL(H.SoNgayLam,0) as SoNgayLam, (((ISNULL(LuongCoBan,0) * ISNULL(HeSoLuong,0))/25)*ISNULL(SoNgayLam,0) - ISNULL(TongBH,0) - ISNULL(TongKL,0) + ISNULL(TongKT,0) + ISNULL(TongPC,0) + ISNULL(SoGioLamThem,0)*" + txtTienCongThemGio.Text + " ) as SoTienNhan FROM (SELECT NHANVIEN.MaNV, SUM(CHAMCONGHANGNGAY.SoGioLamThem) as SoGioLamThem, COUNT(CHAMCONGHANGNGAY.ThongTinDiLam) as SoNgayLam FROM NHANVIEN LEFT JOIN CHAMCONGHANGNGAY ON NHANVIEN.MaNV = CHAMCONGHANGNGAY.MaNV WHERE CHAMCONGHANGNGAY.ThongTinDiLam = 'V' AND CHAMCONGHANGNGAY.NgayDiLam BETWEEN '" + dtpTuNgay.Text + "' AND '" + dtpDenNgay.Text + "' GROUP BY NHANVIEN.MaNV) H FULL JOIN (SELECT E.MaNV,E.HoTen,E.LuongCoBan,E.HeSoLuong,G.TongBH,G.TongKL,G.TongKT,G.TongPC FROM (SELECT NHANVIEN.MaNV, NHANVIEN.HoTen ,HOPDONG.HeSoLuong,LUONG.LuongCoBan FROM NHANVIEN LEFT JOIN HOPDONG ON NHANVIEN.MaNV = HOPDONG.MaNV LEFT JOIN LUONG ON HOPDONG.BacLuong = LUONG.BacLuong) E FULL JOIN (SELECT C.MaNV, C.TongKT,C.TongPC, D.TongBH,D.TongKL FROM (SELECT A.MaNV, A.TongPC, B.TongKT FROM (SELECT NHANVIEN.MaNV, SUM(PHUCAP.SoTien) as TongPC FROM NHANVIEN LEFT JOIN PHUCAPNHANVIEN ON NHANVIEN.MaNV = PHUCAPNHANVIEN.MaNV LEFT JOIN PHUCAP ON PHUCAPNHANVIEN.MaPC = PHUCAP.MaPC GROUP BY NHANVIEN.MaNV) A FULL JOIN (SELECT NHANVIEN.MaNV, SUM(KHENTHUONG.GiaTriKhenThuong) as TongKT FROM NHANVIEN LEFT JOIN KHENTHUONGNHANVIEN ON NHANVIEN.MaNV = KHENTHUONGNHANVIEN.MaNV LEFT JOIN KHENTHUONG ON KHENTHUONGNHANVIEN.MaKhenThuong = KHENTHUONG.MaKhenThuong GROUP BY NHANVIEN.MaNV) B ON A.MaNV = B.MaNV) C FULL JOIN (SELECT A.MaNV, A.TongBH, B.TongKL FROM (SELECT NHANVIEN.MaNV, SUM(BAOHIEM.SoTien) as TongBH FROM NHANVIEN LEFT JOIN BAOHIEMNHANVIEN ON NHANVIEN.MaNV = BAOHIEMNHANVIEN.MaNV LEFT JOIN BAOHIEM ON BAOHIEMNHANVIEN.MaBH = BAOHIEM.MaBH GROUP BY NHANVIEN.MaNV) A FULL JOIN (SELECT NHANVIEN.MaNV, SUM(KYLUAT.SoTienKyLuat) as TongKL FROM NHANVIEN LEFT JOIN KYLUATNHANVIEN ON NHANVIEN.MaNV = KYLUATNHANVIEN.MaNV LEFT JOIN KYLUAT ON KYLUATNHANVIEN.MaKyLuat = KYLUAT.MaKyLuat GROUP BY NHANVIEN.MaNV) B ON A.MaNV = B.MaNV) D ON C.MaNV = D.MaNV) G ON E.MaNV = G.MaNV ) I ON H.MaNV = I.MaNV WHERE I.MaNV LIKE '%"+txtTimKiem.Text+ "%'  OR I.HoTen LIKE '%" + txtTimKiem.Text + "%'");
            if (hienthithongtintinhluong.Rows.Count == 0)
            {
                DialogResult ThongBao = MessageBox.Show("Không tìm thấy dữ liệu!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            else
            {
                gcTinhLuong.DataSource = hienthithongtintinhluong;
                ganketdulieu();
            }
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            timkiem();
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
            if (kiemtrachon() == true)
            {
                hienthithongtin();
                ganketdulieu();
            }
        }
    }
}
