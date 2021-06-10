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

namespace DoAnNhanSuBanChuan.TongQuan.ThietLap
{
    public partial class ucThongKeNhanSu : DevExpress.XtraEditors.XtraUserControl
    {
        Data_Access thongke = new Data_Access();
        public ucThongKeNhanSu()
        {
            InitializeComponent();
            thongkenhansutheohocvan();
            thongkenhansutheoloaihopdong();
            thongkenhansutheogioitinh();

        }
        public void hienthitongsonhanvien()
        {
            DataTable tongnhanvien = thongke.CreateTable("SELECT COUNT(GioiTinh) AS TongSoGioiTinh FROM GioiTinh");
        }

        public void thongkenhansutheohocvan()
        {
            chartNhanSuHocVan.Titles.Add("SỐ LƯỢNG NHÂN VIÊN THEO TRÌNH ĐỘ HỌC VẤN");
            DataTable charhocvan = thongke.CreateTable("SELECT A.TrinhDo,B.TongSoLuong FROM HOCVAN A RIGHT JOIN (SELECT MaHV, count(*) AS TongSoLuong FROM HOCVANNHANVIEN GROUP by MaHV) B ON A.MaHV = B.MaHV");
            chartNhanSuHocVan.DataSource = charhocvan;
            chartNhanSuHocVan.Series["srNhanSuHocVan"].XValueMember = "TrinhDo";
            chartNhanSuHocVan.Series["srNhanSuHocVan"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            chartNhanSuHocVan.Series["srNhanSuHocVan"].YValueMembers = "TongSoLuong";
            chartNhanSuHocVan.Series["srNhanSuHocVan"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int64;
        }
        public void thongkenhansutheophongban()
        {
            chartNhanSu.Titles.Add("SỐ LƯỢNG NHÂN VIÊN THEO PHÒNG BAN");
            DataTable charphongban = thongke.CreateTable("SELECT A.TenPB,B.Tongsonguoi FROM PHONGBAN A RIGHT JOIN (SELECT MaPB, count(*) AS Tongsonguoi FROM PHONGBANCHUCVUNHANVIEN GROUP by MaPB) B ON A.MaPB = B.MaPB");
            chartNhanSu.DataSource = charphongban;
            chartNhanSu.Series["srPhongBan"].XValueMember = "TenPB";
            chartNhanSu.Series["srPhongBan"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            chartNhanSu.Series["srPhongBan"].YValueMembers = "Tongsonguoi";
            chartNhanSu.Series["srPhongBan"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int64;
        }
        public void thongkenhansutheotrangthai()
        {
            chartNhanSu.Titles.Add("SỐ LƯỢNG NHÂN VIÊN THEO TRẠNG THÁI LÀM VIỆC");
            DataTable chahrttrangthai = thongke.CreateTable("SELECT TrangThai, count(*) AS Tongsonguoi FROM NHANVIEN GROUP by TrangThai");
            chartNhanSu.DataSource = chahrttrangthai;
            chartNhanSu.Series["srTrangThai"].XValueMember = "TrangThai";
            chartNhanSu.Series["srTrangThai"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            chartNhanSu.Series["srTrangThai"].YValueMembers = "Tongsonguoi";
            chartNhanSu.Series["srTrangThai"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int64;
        }
        public void thongkenhansutheoloaihopdong()
        {
            chartNhanSuHDLD.Titles.Add("SỐ LƯỢNG NHÂN VIÊN THEO TRẠNG THÁI LÀM VIỆC");
            DataTable charthopdong = thongke.CreateTable("SELECT LoaiHD, count(*) AS Tonghd FROM HOPDONG GROUP by LoaiHD");
            chartNhanSuHDLD.DataSource = charthopdong;
            chartNhanSuHDLD.Series["srHopDongLaoDong"].XValueMember = "LoaiHD";
            chartNhanSuHDLD.Series["srHopDongLaoDong"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            chartNhanSuHDLD.Series["srHopDongLaoDong"].YValueMembers = "Tonghd";
            chartNhanSuHDLD.Series["srHopDongLaoDong"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int64;
        }
        public void thongkenhansutheogioitinh()
        {
            chartNamNu.Titles.Add("SỐ LƯỢNG NHÂN VIÊN THEO GIỚI TÍNH");
            DataTable chartgioitinh = thongke.CreateTable("SELECT GioiTinh, count(*) AS Tongns FROM NHANVIEN GROUP by GioiTinh");
            chartNamNu.DataSource = chartgioitinh;
            chartNamNu.Series["srNamNu"].XValueMember = "GioiTinh";
            chartNamNu.Series["srNamNu"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            chartNamNu.Series["srNamNu"].YValueMembers = "Tongns";
            chartNamNu.Series["srNamNu"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int64;
        }
        public void thongkenhansutheotuoi()
        {
            chartNhanSu.Titles.Add("SỐ LƯỢNG NHÂN VIÊN THEO ĐỘ TUỔI");
            DataTable chartdotuoi = thongke.CreateTable("SELECT YEAR(GETDATE()) - YEAR(NgaySinh) AS 'Tuoi' , COUNT(*) as tongsotuoi FROM NHANVIEN GROUP by NgaySinh");
            chartNhanSu.DataSource = chartdotuoi;
            chartNhanSu.Series["srTuoi"].XValueMember = "Tuoi";
            chartNhanSu.Series["srTuoi"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            chartNhanSu.Series["srTuoi"].YValueMembers = "tongsotuoi";
            chartNhanSu.Series["srTuoi"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int64;
        }
        private void btnPhongBan_Click(object sender, EventArgs e)
        {
            thongkenhansutheophongban();
        }

        private void btnTrangThai_Click(object sender, EventArgs e)
        {
            thongkenhansutheotrangthai();
        }

        private void btnTuoi_Click(object sender, EventArgs e)
        {
            thongkenhansutheotuoi();
        }
    }
}
