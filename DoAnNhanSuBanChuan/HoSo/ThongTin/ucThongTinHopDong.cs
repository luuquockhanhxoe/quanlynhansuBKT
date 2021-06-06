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

namespace DoAnNhanSuBanChuan.HoSo.ThongTin
{
    public partial class ucThongTinHopDong : UserControl
    {
        Data_Access hd = new Data_Access();
        void hienthithongtinhopdong()
        {
            DataTable thongtincoban = hd.CreateTable("SELECT HOPDONG.MaHD, HOPDONG.MaNV, FORMAT (getdate(), 'dd/MM/yyyy ') AS NgayKyHD, HOPDONG.LoaiHD, HOPDONG.ThoiHanHD,HOPDONG.BacLuong, HOPDONG.HeSoLuong,HOPDONG.CheDoLamViec, HOPDONG.HinhThucTraLuong, HOPDONG.SoLaoDong, NHANVIEN.HoTen FROM HOPDONG LEFT JOIN NHANVIEN ON HOPDONG.MaNV = NHANVIEN.MaNV");
            gcHopDong.DataSource = thongtincoban;
            ganketdulieu();
        }
       
        public void ganketdulieu()
        {
            lbMaNV.DataBindings.Clear();
            lbMaNV.DataBindings.Add("text", gcHopDong.DataSource, "MaNV");
            lbMaHD.DataBindings.Clear();
            lbMaHD.DataBindings.Add("text", gcHopDong.DataSource, "MaHD");
            lbNgayKyHD.DataBindings.Clear();
            lbNgayKyHD.DataBindings.Add("text", gcHopDong.DataSource, "NgayKyHD");
            lbLoaiHD.DataBindings.Clear();
            lbLoaiHD.DataBindings.Add("text", gcHopDong.DataSource, "LoaiHD");
            lbThoiHan.DataBindings.Clear();
            lbThoiHan.DataBindings.Add("text", gcHopDong.DataSource, "ThoiHanHD");
            lbBacLuong.DataBindings.Clear();
            lbBacLuong.DataBindings.Add("text", gcHopDong.DataSource, "BacLuong");
            lbHeSoLuong.DataBindings.Clear();
            lbHeSoLuong.DataBindings.Add("text", gcHopDong.DataSource, "HeSoLuong");
            lbCheDoLamViec.DataBindings.Clear();
            lbCheDoLamViec.DataBindings.Add("text", gcHopDong.DataSource, "CheDoLamViec");
            lbHinhThucTraLuong.DataBindings.Clear();
            lbHinhThucTraLuong.DataBindings.Add("text", gcHopDong.DataSource, "HinhThucTraLuong");
            lbSoLaoDong.DataBindings.Clear();
            lbSoLaoDong.DataBindings.Add("text", gcHopDong.DataSource, "SoLaoDong");         
        }
        public ucThongTinHopDong()
        {
            InitializeComponent();
            hienthithongtinhopdong();
        }
        private void spbtnXemVaSuaNhanSu_Click(object sender, EventArgs e)
        {
            string mahopdong = lbMaHD.Text;
            string NgaykyHD = lbNgayKyHD.Text;
            string loaihopdong = lbLoaiHD.Text;
            string thoihanhd = lbThoiHan.Text;
            string solaodong = lbSoLaoDong.Text;
            string bacluong = lbBacLuong.Text;
            string hesoluong = lbHeSoLuong.Text;
            string chedolamviec = lbCheDoLamViec.Text;
            string hinhthuctraluong = lbHinhThucTraLuong.Text;
            string manhanvien = lbMaNV.Text;           
            fmThongTinHopDong themhopdong = new fmThongTinHopDong(mahopdong,NgaykyHD,loaihopdong,thoihanhd,solaodong,bacluong,hesoluong,chedolamviec,hinhthuctraluong,manhanvien);
            themhopdong.Text = "Sửa Thông Tin Hợp Đồng";
            themhopdong.ShowDialog();
            hienthithongtinhopdong();
        }

        private void spbtnThemNhanSu_Click_1(object sender, EventArgs e)
        {
            fmThongTinHopDong themhopdong = new fmThongTinHopDong();
            themhopdong.Text = "Thêm Thông Tin Hợp Đồng";
            themhopdong.ShowDialog();
            hienthithongtinhopdong();
        }
        string maHD;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            maHD = gridView1.GetFocusedRowCellValue("MaHD").ToString();
        }

        private void spbtnXoaHD_Click(object sender, EventArgs e)
        {
            DialogResult ThongBao = MessageBox.Show("Bạn có chắc chắn xóa không?", "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (ThongBao == DialogResult.OK)
            {
                string tmp = maHD.Trim();
                DataTable dt = hd.CreateTable("DELETE FROM HOPDONG WHERE MaHD ='"+maHD+"'");
                hienthithongtinhopdong();
            }
        }
    }
}
