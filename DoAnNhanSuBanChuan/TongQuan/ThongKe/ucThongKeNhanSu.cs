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
using DevExpress.XtraCharts;

namespace DoAnNhanSuBanChuan.TongQuan.ThietLap
{
    public partial class ucThongKeNhanSu : DevExpress.XtraEditors.XtraUserControl
    {
        Data_Access thongke = new Data_Access();
        public ucThongKeNhanSu()
        {
            InitializeComponent();
            thongkenhansutheohocvan();
            thongkenhansutheogioitinh();
            thongkenhansutheobiendong();
            thongkenhansutheotrangthai();
            thongkenhansutheotuoi();
        }
        public void hienthitongsonhanvien()
        {
            DataTable tongnhanvien = thongke.CreateTable("SELECT COUNT(GioiTinh) AS TongSoGioiTinh FROM GioiTinh");
        }

        public void thongkenhansutheohocvan()
        {
            //chartNhanSuHocVan.Titles.Add("SỐ LƯỢNG NHÂN VIÊN THEO TRÌNH ĐỘ HỌC VẤN");
            //DataTable charhocvan = thongke.CreateTable("SELECT A.TrinhDo,B.TongSoLuong FROM HOCVAN A RIGHT JOIN (SELECT MaHV, count(*) AS TongSoLuong FROM HOCVANNHANVIEN GROUP by MaHV) B ON A.MaHV = B.MaHV");
            //chartNhanSuHocVan.DataSource = charhocvan;
            //chartNhanSuHocVan.Series["srNhanSuHocVan"].XValueMember = "TrinhDo";
            //chartNhanSuHocVan.Series["srNhanSuHocVan"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            //chartNhanSuHocVan.Series["srNhanSuHocVan"].YValueMembers = "TongSoLuong";
            //chartNhanSuHocVan.Series["srNhanSuHocVan"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int64;
            Series srHocVan = new Series("test", ViewType.Pie);
            DataTable charhocvan1 = thongke.CreateTable("SELECT A.TrinhDo,B.TongSoLuong FROM HOCVAN A RIGHT JOIN (SELECT MaHV, count(*) AS TongSoLuong FROM HOCVANNHANVIEN GROUP by MaHV) B ON A.MaHV = B.MaHV");
            srHocVan.DataSource = charhocvan1;
            srHocVan.ArgumentDataMember = "TrinhDo";
            srHocVan.ValueDataMembers.AddRange(new string[] { "TongSoLuong" });
            chartHocVan.Series.Add(srHocVan);
            srHocVan.LegendTextPattern = "{A}";
        }
        public void thongkenhansutheotrangthai()
        {
            //chartTrangThai.Titles.Add("SỐ LƯỢNG NHÂN VIÊN THEO TRẠNG THÁI LÀM VIỆC");
            //DataTable chahrttrangthai = thongke.CreateTable("SELECT TrangThai, count(*) AS Tongsonguoi FROM NHANVIEN GROUP by TrangThai");
            //chartTrangThai.DataSource = chahrttrangthai;
            //chartTrangThai.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            //chartTrangThai.Series["srTrangThai"].XValueMember = "TrangThai";
            //chartTrangThai.Series["srTrangThai"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            //chartTrangThai.Series["srTrangThai"].YValueMembers = "Tongsonguoi";
            //chartTrangThai.Series["srTrangThai"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int64;
            DataTable chahrttrangthai = thongke.CreateTable("SELECT TrangThai, count(*) AS Tongsonguoi FROM NHANVIEN GROUP by TrangThai");
            chartTrangThai.DataSource = chahrttrangthai;
            chartTrangThai.SeriesDataMember = "TrangThai";
            chartTrangThai.SeriesTemplate.ArgumentDataMember = "TrangThai";
            chartTrangThai.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Tongsonguoi" });

        }    
        public void thongkenhansutheogioitinh()
        {
            ChartGioiTinh.Titles.Add("SỐ LƯỢNG NHÂN VIÊN THEO GIỚI TÍNH");
            DataTable chartgioitinh = thongke.CreateTable("SELECT GioiTinh, count(*) AS Tongns FROM NHANVIEN GROUP by GioiTinh");
            ChartGioiTinh.DataSource = chartgioitinh;
            ChartGioiTinh.Series["srNamNu"].XValueMember = "GioiTinh";
            ChartGioiTinh.Series["srNamNu"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            ChartGioiTinh.Series["srNamNu"].YValueMembers = "Tongns";
            ChartGioiTinh.Series["srNamNu"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int64;
        }
        public void thongkenhansutheotuoi()
        {

            //charTuoi.Titles.Add("SỐ LƯỢNG NHÂN VIÊN THEO ĐỘ TUỔI");
            //DataTable chartdotuoi = thongke.CreateTable("SELECT (YEAR(GETDATE()) - YEAR(NgaySinh)) AS 'Tuoi' , COUNT(*) as tongsotuoi FROM NHANVIEN GROUP by NgaySinh");
            //charTuoi.DataSource = chartdotuoi;
            //charTuoi.Series["srTuoi"].XValueMember = "Tuoi";
            //charTuoi.Series["srTuoi"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            //charTuoi.Series["srTuoi"].YValueMembers = "tongsotuoi";
            //charTuoi.Series["srTuoi"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int64;
            DataTable chartdotuoi = thongke.CreateTable("SELECT (YEAR(GETDATE()) - YEAR(NgaySinh)) AS Tuoi , COUNT(*) as tongsotuoi FROM NHANVIEN GROUP by NgaySinh");
            chartTuoi.DataSource = chartdotuoi;
            chartTuoi.SeriesDataMember = "Tuoi";
            chartTuoi.SeriesTemplate.ArgumentDataMember = "Tuoi";
            chartTuoi.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "tongsotuoi" });
        }
        public void thongkenhansutheobiendong()
        {
            chartBienDongNhanSu.Titles.Add("BIẾN ĐỘNG NHÂN SỰ QUA TỪNG NĂM");
            DataTable charbiendong = thongke.CreateTable("SELECT (YEAR(NgayKyHD)) AS 'NamVao',COUNT(*) as TongSoNguoiVaoTrongNam FROM HOPDONG GROUP BY NgayKyHD");
            chartBienDongNhanSu.DataSource = charbiendong;
            chartBienDongNhanSu.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chartBienDongNhanSu.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            chartBienDongNhanSu.Series["srBienDongNhanSu"].XValueMember = "NamVao";
            chartBienDongNhanSu.Series["srBienDongNhanSu"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            chartBienDongNhanSu.Series["srBienDongNhanSu"].YValueMembers = "TongSoNguoiVaoTrongNam";
            chartBienDongNhanSu.Series["srBienDongNhanSu"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int64;
        }
    }
}
