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
        public void thongkenhansutheohocvan()
        {
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

            DataTable chartdotuoi = thongke.CreateTable("SELECT A.Tuoi as Tuoi, COUNT(*) as tongsotuoi FROM (SELECT (YEAR(GETDATE()) - YEAR(NgaySinh)) AS Tuoi FROM NHANVIEN) A GROUP BY A.Tuoi");
            chartTuoi.DataSource = chartdotuoi;
            chartTuoi.SeriesDataMember = "Tuoi";
            chartTuoi.SeriesTemplate.ArgumentDataMember = "Tuoi";
            chartTuoi.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "tongsotuoi" });
        }
        public void thongkenhansutheobiendong()
        {
            chartBienDongNhanSu.Titles.Add("BIẾN ĐỘNG NHÂN SỰ QUA TỪNG NĂM");
            DataTable charbiendong = thongke.CreateTable("SELECT A.NamVao as NamVao, COUNT(*) as TongSoNguoiVaoTrongNam  FROM (SELECT (YEAR(NgayKyHD)) AS 'NamVao' FROM HOPDONG) A GROUP BY A.NamVao");
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
