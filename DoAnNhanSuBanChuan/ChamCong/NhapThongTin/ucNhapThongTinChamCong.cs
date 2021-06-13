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
        }

        private void ucNhapThongTinChamCong_Load(object sender, EventArgs e)
        {
            dtpNgayHomNay.Value = DateTime.Today;
            hienthithongtinchamcong();
        }

        public void hienthithongtinchamcong()
        {
            DataTable hienthithongtinchamcong = chamcong.CreateTable("SELECT NHANVIEN.MaNV, NHANVIEN.HoTen, CHAMCONGHANGNGAY.NgayDiLam, CHAMCONGHANGNGAY.IdChamCong, CHAMCONGHANGNGAY.SoGioLamThem,CHAMCONGHANGNGAY.ThongTinDiLam FROM NHANVIEN FULL JOIN CHAMCONGHANGNGAY ON NHANVIEN.MaNV = CHAMCONGHANGNGAY.MaNV");
            gcThongTinChamCong.DataSource = hienthithongtinchamcong;
        }
        string MaNV, IdChamCong, ThongTinDiLam, SoGioLamThem;

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
            DataTable timthongtin = chamcong.CreateTable("SELECT NHANVIEN.MaNV, NHANVIEN.HoTen, CHAMCONGHANGNGAY.IdChamCong, CHAMCONGHANGNGAY.SoGioLamThem,CHAMCONGHANGNGAY.ThongTinDiLam FROM NHANVIEN FULL JOIN CHAMCONGHANGNGAY ON NHANVIEN.MaNV = CHAMCONGHANGNGAY.MaNV WHERE NHANVIEN.MaNV LIKE '%" + txtTimKiem.Text + "%' OR NHANVIEN.HoTen LIKE N'%" + txtTimKiem.Text + "%' OR CHAMCONGHANGNGAY.ThongTinDiLam LIKE '%" + txtTimKiem.Text + "%' OR CHAMCONGHANGNGAY.SoGioLamThem LIKE N'%" + txtTimKiem.Text + "%' ");
            if (timthongtin.Rows.Count == 0)
            {
                DialogResult ThongBao = MessageBox.Show("Không tìm thấy dữ liệu!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            else
            {
                gcThongTinChamCong.DataSource = timthongtin;
            }
        }

        private void gvChamCong_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (gvChamCong.RowCount.ToString() == null )
            {
                chapnhanchamcongchonhanvien();
            }
            {
                suachamcongchonhanvien();
            }
        }

        public void chapnhanchamcongchonhanvien()
        {
                ttchamconghangngay_Load();
                DataTable chamcongnv = chamcong.CreateTable("INSERT INTO CHAMCONGHANGNGAY(MaNV,ThongTinDiLam,SoGioLamThem,NgayDiLam) VALUES ('" + MaNV + "',N'" + ThongTinDiLam + "', '" + SoGioLamThem + "',N'" + dtpNgayHomNay.Text + "')");
                MessageBox.Show("Đã chấm công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hienthithongtinchamcong();
        }
        public void suachamcongchonhanvien()
        {
            ttchamconghangngay_Load();
            DataTable chamcongnv = chamcong.CreateTable("UPDATE CHAMCONGHANGNGAY SET ThongTinDiLam = N'" + ThongTinDiLam + "', SoGioLamThem = '" + SoGioLamThem + "' WHERE IdChamCong = '"+ IdChamCong + "'");
            MessageBox.Show("Đã sửa chấm công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            hienthithongtinchamcong();
        }
        public void ttchamconghangngay_Load()
        {
            MaNV = gvChamCong.GetRowCellValue(gvChamCong.FocusedRowHandle, "MaNV").ToString();
            IdChamCong = gvChamCong.GetRowCellValue(gvChamCong.FocusedRowHandle, "IdChamCong").ToString();
            ThongTinDiLam = gvChamCong.GetRowCellValue(gvChamCong.FocusedRowHandle, "ThongTinDiLam").ToString();
            SoGioLamThem = gvChamCong.GetRowCellValue(gvChamCong.FocusedRowHandle, "SoGioLamThem").ToString();
        }
    }
}
