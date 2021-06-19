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
using System.IO;

namespace DoAnNhanSuBanChuan.TongQuan.ThietLap
{
    public partial class ucThongKeNguoiDungHeThong : DevExpress.XtraEditors.XtraUserControl
    {
        Data_Access thongtinnguoidung = new Data_Access();
        public ucThongKeNguoiDungHeThong() 
        {
            InitializeComponent();
            hienthithongtin();
        }

        public void  hienthithongtin()
        {
            DataTable hienthithongtinnguoidung = thongtinnguoidung.CreateTable("SELECT NGUOIDUNGHETHONG.MaNV,NGUOIDUNGHETHONG.NhiemVu,NGUOIDUNGHETHONG.TenTaiKhoan,NGUOIDUNGHETHONG.MatKhau,NHANVIEN.MaNV,NHANVIEN.HoTen, NHANVIEN.AnhChanDung FROM NGUOIDUNGHETHONG LEFT JOIN NHANVIEN ON NGUOIDUNGHETHONG.MaNV = NHANVIEN.MaNV");
            gcNguoiDungHeThong.DataSource = hienthithongtinnguoidung;
            ganketdulieu();
        }
        public void ganketdulieu()
        {
            lbMaNV.DataBindings.Clear();
            lbMaNV.DataBindings.Add("text", gcNguoiDungHeThong.DataSource, "MaNV");
            lbHoTen.DataBindings.Clear();
            lbHoTen.DataBindings.Add("text", gcNguoiDungHeThong.DataSource, "HoTen");
            lbNhiemVu.DataBindings.Clear();
            lbNhiemVu.DataBindings.Add("text", gcNguoiDungHeThong.DataSource, "NhiemVu");
            lbTenTaiKhoan.DataBindings.Clear();
            lbTenTaiKhoan.DataBindings.Add("text", gcNguoiDungHeThong.DataSource, "TenTaiKhoan");
            lbMatKhau.DataBindings.Clear();
            lbMatKhau.DataBindings.Add("text", gcNguoiDungHeThong.DataSource, "MatKhau");
        }

        string maNV;
        Image img;
        private void gvNguoiDungHeThong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            maNV = gvNguoiDungHeThong.GetFocusedRowCellValue("MaNV").ToString();

            byte[] getImg = (byte[])gvNguoiDungHeThong.GetRowCellValue(gvNguoiDungHeThong.FocusedRowHandle, "AnhChanDung");
            MemoryStream stream = new MemoryStream(getImg);
            img = Image.FromStream(stream);
            pbAnhChanDung.Image = img;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            DataTable timthongtin = thongtinnguoidung.CreateTable("SELECT NGUOIDUNGHETHONG.MaNV,NGUOIDUNGHETHONG.NhiemVu,NGUOIDUNGHETHONG.TenTaiKhoan,NGUOIDUNGHETHONG.MatKhau,NHANVIEN.HoTen, NHANVIEN.AnhChanDung FROM NGUOIDUNGHETHONG LEFT JOIN NHANVIEN ON NGUOIDUNGHETHONG.MaNV = NHANVIEN.MaNV WHERE NGUOIDUNGHETHONG.MaNV LIKE '%" + txtTimKiem.Text + "%' OR NGUOIDUNGHETHONG.NhiemVu LIKE N'%" + txtTimKiem.Text + "%' OR NGUOIDUNGHETHONG.TenTaiKhoan LIKE '%" + txtTimKiem.Text + "%' OR NHANVIEN.HoTen LIKE N'%" + txtTimKiem.Text + "%'");
            if (timthongtin.Rows.Count == 0)
            {
                DialogResult ThongBao = MessageBox.Show("Không tìm thấy dữ liệu!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            else
            {
                gcNguoiDungHeThong.DataSource = timthongtin;
                ganketdulieu();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            hienthithongtin();
            txtTimKiem.Clear();
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTim.PerformClick();
            }
        }

        private void spbtnThemNhanSu_Click(object sender, EventArgs e)
        {
            TaoNguoiDungHeThong taonguoidung = new TaoNguoiDungHeThong();
            taonguoidung.Text = "Thêm Thông Tin Người Dùng Hệ Thống";
            taonguoidung.ShowDialog();
            hienthithongtin();
        }

        private void spbtnXemVaSuaNhanSu_Click(object sender, EventArgs e)
        {
            string manhanvien = lbMaNV.Text;
            string hovaten = lbHoTen.Text;
            string nhiemvu = lbNhiemVu.Text;
            string tentaikhoan = lbTenTaiKhoan.Text;
            string matkhau = lbMatKhau.Text;
            TaoNguoiDungHeThong taonguoidung = new TaoNguoiDungHeThong(manhanvien,hovaten,nhiemvu,tentaikhoan,matkhau);
            taonguoidung.Text = "Sửa Thông Tin Người Dùng Hệ Thống";
            taonguoidung.ShowDialog();
            hienthithongtin();
        }
        public void xoanguoidung()
        {
            
            DialogResult ThongBao = MessageBox.Show("Bạn có chắc chắn xóa không?", "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (ThongBao == DialogResult.OK)
            {
                string tmp = maNV.Trim();
                DataTable dt = thongtinnguoidung.CreateTable("DELETE FROM NGUOIDUNGHETHONG WHERE MaNV ='" + tmp + "'");
                hienthithongtin();
            }
        }

        private void spbtnXoa_Click(object sender, EventArgs e)
        {
            xoanguoidung();
        }
    }
}
