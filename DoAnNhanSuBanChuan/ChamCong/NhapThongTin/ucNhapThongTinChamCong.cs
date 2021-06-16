using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnNhanSuBanChuan.DataAccess;
using DevExpress.XtraGrid.Views.Grid;

namespace DoAnNhanSuBanChuan.ChamCong.NhapThongTin
{
    public partial class ucNhapThongTinChamCong : UserControl
    {
        Data_Access chamcong = new Data_Access();
        public ucNhapThongTinChamCong()
        {
            InitializeComponent();
            hienthithongtinchamcong();
        }

        private void ucNhapThongTinChamCong_Load(object sender, EventArgs e)
        {
            dtpNgayHomNay.Value = DateTime.Today;
            btnDiLam.Click += BtnDiLam_Click;
            btnNghi.Click += BtnNghi_Click;
            btnSua.Click += BtnSua_Click;
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            ttchamcongcuthe_Load();
            DataTable aidachamcong = chamcong.CreateTable("UPDATE CHAMCONGHANGNGAY SET THONGTINDILAM = '" + ThongTinDiLam + "',SoGioLamThem = '" + SoGioLamThem + "' WHERE IdChamCong = '" + IdChamCong + "'");
            MessageBox.Show("Đã sửa thông tin chấm công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            hienthithongtinaidachamcong();
        }
        private void BtnNghi_Click(object sender, EventArgs e)
        {
            if (kiemtratrung() == true)
            {
                ttchamconghangngay_Load();
                DataTable chamcongdilam = chamcong.CreateTable("INSERT INTO CHAMCONGHANGNGAY(MaNV,NgayDiLam,ThongTinDiLam,SoGioLamThem) VALUES('" + MaNV + "','" + dtpNgayHomNay.Text + "','X','0')");
                hienthithongtinaidachamcong();
            }
            else
            {
                MessageBox.Show("Đã chấm công cho nhân viên này!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnDiLam_Click(object sender, EventArgs e)
        {
            if (kiemtratrung() == true)
            {
                ttchamconghangngay_Load();
                DataTable chamcongdilam = chamcong.CreateTable("INSERT INTO CHAMCONGHANGNGAY(MaNV,NgayDiLam,ThongTinDiLam,SoGioLamThem) VALUES('" + MaNV + "','" + dtpNgayHomNay.Text + "','V','0')");
                hienthithongtinaidachamcong();
            }
            else
            {
                MessageBox.Show("Đã chấm công cho nhân viên này!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void hienthithongtinchamcong()
        {
            DataTable hienthithongtinchamcong = chamcong.CreateTable("SELECT MaNV, HoTen FROM NHANVIEN ");
            gcChamCong.DataSource = hienthithongtinchamcong;
        }

        public void hienthithongtinaidachamcong()
        {
            DataTable hienthithongtindachamcong = chamcong.CreateTable("SELECT CHAMCONGHANGNGAY.IdChamCong, CHAMCONGHANGNGAY.ThongTinDiLam,CHAMCONGHANGNGAY.SoGioLamThem,CHAMCONGHANGNGAY.MaNV,NHANVIEN.HoTen FROM CHAMCONGHANGNGAY LEFT JOIN NHANVIEN ON CHAMCONGHANGNGAY.MaNV = NHANVIEN.MaNV WHERE NgayDiLam = '" + dtpNgayHomNay.Text + "'");
            gcDaChamCong.DataSource = hienthithongtindachamcong;
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            hienthithongtinchamcong();
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTim.PerformClick();
            }
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            DataTable timthongtin = chamcong.CreateTable("SELECT MaNV, HoTen FROM NHANVIEN WHERE MaNV LIKE '%" + txtTimKiem.Text + "%' OR HoTen LIKE N'%" + txtTimKiem.Text + "%'");
            if (timthongtin.Rows.Count == 0)
            {
                DialogResult ThongBao = MessageBox.Show("Không tìm thấy dữ liệu!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            else
            {
                gcChamCong.DataSource = timthongtin;
            }
        }

        string MaNV,ThongTinDiLam,SoGioLamThem, IdChamCong;

        private void btnLamThemGio_Click(object sender, EventArgs e)
        {
            fmDangKyLamThem dangkylamthem = new fmDangKyLamThem();
            dangkylamthem.ShowDialog();
            hienthithongtinaidachamcong();
        }

        public void ttchamconghangngay_Load()
        {
            MaNV = gvChamCong.GetRowCellValue(gvChamCong.FocusedRowHandle, "MaNV").ToString();
        }
        public void ttchamcongcuthe_Load()
        {
            ThongTinDiLam = gvDaChamCong.GetRowCellValue(gvDaChamCong.FocusedRowHandle, "ThongTinDiLam").ToString();
            SoGioLamThem = gvDaChamCong.GetRowCellValue(gvDaChamCong.FocusedRowHandle, "SoGioLamThem").ToString();
            IdChamCong = gvDaChamCong.GetRowCellValue(gvDaChamCong.FocusedRowHandle, "IdChamCong").ToString();
        }
        public bool kiemtratrung()
        {
            ttchamconghangngay_Load();
            DataTable kiemtratrunglap = chamcong.CreateTable("SELECT * FROM CHAMCONGHANGNGAY WHERE NgayDiLam = '" + dtpNgayHomNay.Text + "'");
            for (int i = 0; i < kiemtratrunglap.Rows.Count; i++)
                if (MaNV == kiemtratrunglap.Rows[i]["MaNV"].ToString())
                {
                    return false;
                }
            return true;
        }
    }
}
