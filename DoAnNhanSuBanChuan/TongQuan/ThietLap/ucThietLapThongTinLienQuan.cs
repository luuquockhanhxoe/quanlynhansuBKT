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

namespace DoAnNhanSuBanChuan.TongQuan.ThietLap
{
    public partial class ucThietLapThongTinLienQuan : UserControl
    {
        Data_Access ttlq = new Data_Access();
        public ucThietLapThongTinLienQuan()
        {
            InitializeComponent();

            DataTable hienthihocvan = ttlq.CreateTable("SELECT * FROM HOCVAN ");
            gcHocVan.DataSource = hienthihocvan;

            DataTable hienthichungchi = ttlq.CreateTable("SELECT * FROM CHUNGCHI ");
            gcChungChi.DataSource = hienthichungchi;

            DataTable hienthiphucap = ttlq.CreateTable("SELECT * FROM PHUCAP ");
            gcPhuCap.DataSource = hienthiphucap;

            DataTable hienthikhenthuong = ttlq.CreateTable("SELECT * FROM KHENTHUONG ");
            gcKhenThuong.DataSource = hienthikhenthuong;

            DataTable hienthikyluat = ttlq.CreateTable("SELECT * FROM KYLUAT ");
            gcKyLuat.DataSource = hienthikyluat;

            DataTable hienthiphongban = ttlq.CreateTable("SELECT * FROM PHONGBAN ");
            gcPhongBan.DataSource = hienthiphongban;

            DataTable hienthichucvu = ttlq.CreateTable("SELECT * FROM CHUCVU ");
            gcChucVu.DataSource = hienthichucvu;

            DataTable hienthiluong = ttlq.CreateTable("SELECT * FROM LUONG ");
            gcLuong.DataSource = hienthiluong;

            DataTable hienthibaohiem = ttlq.CreateTable("SELECT * FROM BAOHIEM ");
            gcBaoHiem.DataSource = hienthibaohiem;
        }

        private void ucThietLapThongTinLienQuan_Load(object sender, EventArgs e)
        {
            btnThemHV.Click += BtnThemHV_Click;
            btnSuaHV.Click += BtnSuaHV_Click;
            btnXoaHV.Click += BtnXoaHV_Click;

            btnThemCC.Click += BtnThemCC_Click;
            btnSuaCC.Click += BtnSuaCC_Click;
            btnXoaCC.Click += BtnXoaCC_Click;

            btnThemPC.Click += BtnThemPC_Click;
            btnSuaPC.Click += BtnSuaPC_Click;
            btnXoaPC.Click += BtnXoaPC_Click;

            btnThemKhenThuong.Click += BtnThemKhenThuong_Click;
            btnSuaKhenThuong.Click += BtnSuaKhenThuong_Click;
            btnXoaKhenThuong.Click += BtnXoaKhenThuong_Click;

            btnThemKyLuat.Click += BtnThemKyLuat_Click;
            btnSuaKyLuat.Click += BtnSuaKyLuat_Click;
            btnXoaKyLuat.Click += BtnXoaKyLuat_Click;

            btnThemPB.Click += BtnThemPB_Click;
            btnXoaPB.Click += BtnXoaPB_Click;
            btnSuaPB.Click += BtnSuaPB_Click;

            btnThemCV.Click += BtnThemCV_Click;
            btnSuaCV.Click += BtnSuaCV_Click;
            btnXoaCV.Click += BtnXoaCV_Click;

            btnThemBH.Click += BtnThemBH_Click;
            btnSuaBH.Click += BtnSuaBH_Click;
            btnXoaBH.Click += BtnXoaBH_Click;

            btnThemLuong.Click += BtnThemLuong_Click;
            btnSuaLuong.Click += BtnSuaLuong_Click;
            btnXoaLuong.Click += BtnXoaLuong_Click;

        }

        private void BtnXoaLuong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                thongtinnhapgridcontrol();
                DataTable xoaluong = ttlq.CreateTable("DELETE FROM LUONG WHERE BacLuong = '" + BacLuong + "'");
                MessageBox.Show("Đã xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable hienthiluong = ttlq.CreateTable("SELECT * FROM LUONG ");
                gcLuong.DataSource = hienthiluong;
            }
        }
        private void BtnSuaLuong_Click(object sender, EventArgs e)
        {
            thongtinnhapgridcontrol();
            DataTable sual = ttlq.CreateTable("UPDATE LUONG SET  BacLuong = '" + BacLuong + "',LuongCoBan = '" + LuongCoBan + "' WHERE IDL = '" + IDL+"' ");
            MessageBox.Show("Đã sửa thông tin lương !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable hienthiluong = ttlq.CreateTable("SELECT * FROM LUONG ");
            gcLuong.DataSource = hienthiluong;
        }

        private void BtnThemLuong_Click(object sender, EventArgs e)
        {
            thongtinnhapgridcontrol();
            DataTable themluong = ttlq.CreateTable("INSERT INTO LUONG VALUES('" + BacLuong + "','" + LuongCoBan + "')");
            MessageBox.Show("Đã thêm thông tin lương !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable hienthiluong = ttlq.CreateTable("SELECT * FROM LUONG ");
            gcLuong.DataSource = hienthiluong;
        }

        private void BtnXoaBH_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                thongtinnhapgridcontrol();
                DataTable xoabh = ttlq.CreateTable("DELETE FROM BAOHIEM WHERE MaBH = '" + MaBH + "'");
                MessageBox.Show("Đã xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable hienthibaohiem = ttlq.CreateTable("SELECT * FROM BAOHIEM ");
                gcBaoHiem.DataSource = hienthibaohiem;
            }
        }

        private void BtnSuaBH_Click(object sender, EventArgs e)
        {
            thongtinnhapgridcontrol();
            DataTable suabh = ttlq.CreateTable("UPDATE BAOHIEM SET MaBH = '" + MaBH + "',TenBaoHiem = N'" + TenBaoHiem + "',SoTien = '" + SoTien + "' WHERE IDBH = '" + IDBH + "' ");
            MessageBox.Show("Đã sửa thông tin bảo hiểm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable hienthibaohiem = ttlq.CreateTable("SELECT * FROM BAOHIEM ");
            gcBaoHiem.DataSource = hienthibaohiem;
        }

        private void BtnThemBH_Click(object sender, EventArgs e)
        {
            thongtinnhapgridcontrol();
            DataTable thembaohiem = ttlq.CreateTable("INSERT INTO BAOHIEM VALUES('" + MaBH + "',N'" + TenBaoHiem + "','" + SoTienBH + "')");
            MessageBox.Show("Đã thêm thông tin bảo hiểm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable hienthibaohiem = ttlq.CreateTable("SELECT * FROM BAOHIEM ");
            gcBaoHiem.DataSource = hienthibaohiem;
        }

        private void BtnXoaCV_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                thongtinnhapgridcontrol();
                DataTable xoacv = ttlq.CreateTable("DELETE FROM CHUCVU WHERE MaCV = '" + MaCV + "'");
                MessageBox.Show("Đã xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable hienthichucvu = ttlq.CreateTable("SELECT * FROM CHUCVU ");
                gcChucVu.DataSource = hienthichucvu;
            }
        }

        private void BtnSuaCV_Click(object sender, EventArgs e)
        {
            thongtinnhapgridcontrol();
            DataTable suacv = ttlq.CreateTable("UPDATE CHUCVU SET MaCV = '" + MaCV + "',TenCV = N'" + TenCV + "' WHERE IDCV = '" + IDCV + "' ");
            MessageBox.Show("Đã sửa thông tin chức vụ !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable hienthichucvu = ttlq.CreateTable("SELECT * FROM CHUCVU ");
            gcChucVu.DataSource = hienthichucvu;
        }

        private void BtnThemCV_Click(object sender, EventArgs e)
        {
            thongtinnhapgridcontrol();
            DataTable themchucvu = ttlq.CreateTable("INSERT INTO CHUCVU VALUES('" + MaCV + "',N'" + TenCV + "')");
            MessageBox.Show("Đã thêm thông tin chức vụ !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable hienthichucvu = ttlq.CreateTable("SELECT * FROM CHUCVU ");
            gcChucVu.DataSource = hienthichucvu;
        }

        private void BtnSuaPB_Click(object sender, EventArgs e)
        {
            thongtinnhapgridcontrol();
            DataTable suapb = ttlq.CreateTable("UPDATE PHONGBAN SET MaPB = '" + MaPB + "',TenPB = '" + TenPB + "' WHERE IDPB = '" + IDPB + "' ");
            MessageBox.Show("Đã sửa thông tin phòng ban !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable hienthiphongban = ttlq.CreateTable("SELECT * FROM PHONGBAN ");
            gcPhongBan.DataSource = hienthiphongban;
        }

        private void BtnXoaPB_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                thongtinnhapgridcontrol();
                DataTable xoapb = ttlq.CreateTable("DELETE FROM PHONGBAN WHERE MaPB = '" + MaPB + "'");
                MessageBox.Show("Đã xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable hienthiphongban = ttlq.CreateTable("SELECT * FROM PHONGBAN ");
                gcPhongBan.DataSource = hienthiphongban;
            }
        }

        private void BtnThemPB_Click(object sender, EventArgs e)
        {
            thongtinnhapgridcontrol();
            DataTable themphongban = ttlq.CreateTable("INSERT INTO PHONGBAN VALUES('" + MaPB + "',N'" + TenPB + "')");
            MessageBox.Show("Đã thêm thông tin phòng ban !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable hienthiphongban = ttlq.CreateTable("SELECT * FROM PHONGBAN ");
            gcPhongBan.DataSource = hienthiphongban;
        }

        private void BtnXoaKyLuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                thongtinnhapgridcontrol();
                DataTable xoakl = ttlq.CreateTable("DELETE FROM KYLUAT WHERE MaKyLuat = '" + MaKyLuat + "'");
                MessageBox.Show("Đã xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable hienthikyluat = ttlq.CreateTable("SELECT * FROM KYLUAT ");
                gcKyLuat.DataSource = hienthikyluat;
            }
        }

        private void BtnSuaKyLuat_Click(object sender, EventArgs e)
        {
            thongtinnhapgridcontrol();
            DataTable suakl = ttlq.CreateTable("UPDATE KYLUAT SET MaKyLuat = '" + MaKyLuat + "',TenKyLuat = '" + TenKyLuat + "',SoTienKyLuat = '" + SoTienKyLuat + "' WHERE IDKL = '" + IDKL + "' ");
            MessageBox.Show("Đã sửa thông tin kỷ luật !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable hienthikyluat = ttlq.CreateTable("SELECT * FROM KYLUAT ");
            gcKyLuat.DataSource = hienthikyluat;
        }

        private void BtnThemKyLuat_Click(object sender, EventArgs e)
        {
            thongtinnhapgridcontrol();
            DataTable themkyluat = ttlq.CreateTable("INSERT INTO KYLUAT VALUES('" + MaKyLuat + "',N'" + TenKyLuat + "','" + SoTienKyLuat + "')");
            MessageBox.Show("Đã thêm thông tin kỷ luật !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable hienthikyluat = ttlq.CreateTable("SELECT * FROM KYLUAT ");
            gcKyLuat.DataSource = hienthikyluat;
        }

        private void BtnXoaKhenThuong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                thongtinnhapgridcontrol();
                DataTable xoakt = ttlq.CreateTable("DELETE FROM KHENTHUONG WHERE MaKhenThuong = '" + MaKhenThuong + "'");
                MessageBox.Show("Đã xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable hienthikhenthuong = ttlq.CreateTable("SELECT * FROM KHENTHUONG ");
                gcKhenThuong.DataSource = hienthikhenthuong;
            }
        }

        private void BtnSuaKhenThuong_Click(object sender, EventArgs e)
        {
            thongtinnhapgridcontrol();
            DataTable suakt = ttlq.CreateTable("UPDATE KHENTHUONG SET MaKhenThuong = '" + MaKhenThuong + "',TenKhenThuong = '" + TenKhenThuong + "',GiaTriKhenThuong = '" + GiaTriKhenThuong + "' WHERE IDKT = '" + IDKT + "' ");
            MessageBox.Show("Đã sửa thông tin khen thưởng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable hienthikhenthuong = ttlq.CreateTable("SELECT * FROM KHENTHUONG ");
            gcKhenThuong.DataSource = hienthikhenthuong;
        }

        private void BtnThemKhenThuong_Click(object sender, EventArgs e)
        {
            thongtinnhapgridcontrol();
            DataTable themkhenthuong = ttlq.CreateTable("INSERT INTO KHENTHUONG VALUES('" + MaKhenThuong + "',N'" + TenKhenThuong + "','" + GiaTriKhenThuong + "')");
            MessageBox.Show("Đã thêm thông tin khen thưởng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable hienthikhenthuong = ttlq.CreateTable("SELECT * FROM KHENTHUONG ");
            gcKhenThuong.DataSource = hienthikhenthuong;
        }

        private void BtnXoaPC_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                thongtinnhapgridcontrol();
                DataTable xoapc = ttlq.CreateTable("DELETE FROM PHUCAP WHERE MaPC = '" + MaPC + "'");
                MessageBox.Show("Đã xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable hienthiphucap = ttlq.CreateTable("SELECT * FROM PHUCAP ");
                gcPhuCap.DataSource = hienthiphucap;
            }
        }

        private void BtnSuaPC_Click(object sender, EventArgs e)
        {
            thongtinnhapgridcontrol();
            DataTable suapc = ttlq.CreateTable("UPDATE PHUCAP SET MaPC = '" + MaPC + "',TenPC = N'" + TenPC + "',SoTien = '" + SoTien + "' WHERE IDPC = '" + IDPC + "' ");
            MessageBox.Show("Đã sửa thông tin phụ cấp !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable hienthiphucap = ttlq.CreateTable("SELECT * FROM PHUCAP ");
            gcPhuCap.DataSource = hienthiphucap;
        }

        private void BtnThemPC_Click(object sender, EventArgs e)
        {
            thongtinnhapgridcontrol();
            DataTable themphucap = ttlq.CreateTable("INSERT INTO PHUCAP VALUES('" + MaPC + "',N'" + TenPC + "','" + SoTien + "')");
            MessageBox.Show("Đã thêm thông tin phụ cấp !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable hienthiphucap = ttlq.CreateTable("SELECT * FROM PHUCAP ");
            gcPhuCap.DataSource = hienthiphucap;
        }

        private void BtnXoaCC_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                thongtinnhapgridcontrol();
                DataTable xoacc = ttlq.CreateTable("DELETE FROM CHUNGCHI WHERE MaCC = '" + MaCC + "'");
                MessageBox.Show("Đã xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable hienthichungchi = ttlq.CreateTable("SELECT * FROM CHUNGCHI ");
                gcChungChi.DataSource = hienthichungchi;
            }
        }

        private void BtnSuaCC_Click(object sender, EventArgs e)
        {
            thongtinnhapgridcontrol();
            DataTable suacc = ttlq.CreateTable("UPDATE CHUNGCHI SET MaCC = '" + MaCC + "',TenChungChi = '" + TenChungChi + "' WHERE IDCC = '" + IDCC + "' ");
            MessageBox.Show("Đã sửa thông tin chứng chỉ !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable hienthichungchi = ttlq.CreateTable("SELECT * FROM CHUNGCHI ");
            gcChungChi.DataSource = hienthichungchi;
        }

        private void BtnThemCC_Click(object sender, EventArgs e)
        {
            thongtinnhapgridcontrol();
            DataTable themchungchi = ttlq.CreateTable("INSERT INTO CHUNGCHI VALUES('" + MaCC + "',N'" + TenChungChi + "')");
            MessageBox.Show("Đã thêm thông tin chứng chỉ !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable hienthichungchi = ttlq.CreateTable("SELECT * FROM CHUNGCHI ");
            gcChungChi.DataSource = hienthichungchi;
        }

        private void BtnXoaHV_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                thongtinnhapgridcontrol();
                DataTable xoahv = ttlq.CreateTable("DELETE FROM HOCVAN WHERE MaHV = '" + MaHV + "'");
                MessageBox.Show("Đã xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable hienthihocvan = ttlq.CreateTable("SELECT * FROM HOCVAN ");
                gcHocVan.DataSource = hienthihocvan;
            }
        }

        private void BtnSuaHV_Click(object sender, EventArgs e)
        {
            thongtinnhapgridcontrol();
            DataTable suahv = ttlq.CreateTable("UPDATE HOCVAN SET MaHV = '" + MaHV + "',TrinhDo = '" + TrinhDo + "' WHERE IDHV = '" + IDHV + "' ");
            MessageBox.Show("Đã sửa thông tin học vấn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable hienthihocvan = ttlq.CreateTable("SELECT * FROM HOCVAN ");
            gcHocVan.DataSource = hienthihocvan;

        }

        private void BtnThemHV_Click(object sender, EventArgs e)
        {
            thongtinnhapgridcontrol();
            DataTable themhocvan = ttlq.CreateTable("INSERT INTO HOCVAN VALUES('" + MaHV + "',N'" + TrinhDo + "')");
            MessageBox.Show("Đã thêm thông tin học vấn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable hienthihocvan = ttlq.CreateTable("SELECT * FROM HOCVAN ");
            gcHocVan.DataSource = hienthihocvan;
        }

        string MaHV, IDHV, IDCC, TrinhDo, IDPC, IDL, IDBH, IDCV, IDPB, IDKT, IDKL, MaCC, MaCV, TenCV, TenChungChi, LuongCoBan, MaBH, TenBaoHiem, SoTienBH, BacLuong, MaPC, TenPC, SoTien, MaKhenThuong, TenKhenThuong, GiaTriKhenThuong, MaKyLuat, TenKyLuat, SoTienKyLuat, MaPB, TenPB;
        public void thongtinnhapgridcontrol()
        {
             MaHV = gvHocVan.GetRowCellValue(gvHocVan.FocusedRowHandle, "MaHV").ToString();
             TrinhDo = gvHocVan.GetRowCellValue(gvHocVan.FocusedRowHandle, "TrinhDo").ToString();
             IDHV = gvHocVan.GetRowCellValue(gvHocVan.FocusedRowHandle, "IDHV").ToString();

             MaCC = gvChungChi.GetRowCellValue(gvChungChi.FocusedRowHandle, "MaCC").ToString();
             TenChungChi = gvChungChi.GetRowCellValue(gvChungChi.FocusedRowHandle, "TenChungChi").ToString();
             IDCC = gvChungChi.GetRowCellValue(gvChungChi.FocusedRowHandle, "IDCC").ToString();

             MaPC = gvPhuCap.GetRowCellValue(gvPhuCap.FocusedRowHandle, "MaPC").ToString();
             TenPC = gvPhuCap.GetRowCellValue(gvPhuCap.FocusedRowHandle, "TenPC").ToString();
             SoTien = gvPhuCap.GetRowCellValue(gvPhuCap.FocusedRowHandle, "SoTien").ToString();
             IDPC = gvPhuCap.GetRowCellValue(gvPhuCap.FocusedRowHandle, "IDPC").ToString();


             MaKhenThuong = gvKhenThuong.GetRowCellValue(gvKhenThuong.FocusedRowHandle, "MaKhenThuong").ToString();
             TenKhenThuong = gvKhenThuong.GetRowCellValue(gvKhenThuong.FocusedRowHandle, "TenKhenThuong").ToString();
             GiaTriKhenThuong = gvKhenThuong.GetRowCellValue(gvKhenThuong.FocusedRowHandle, "GiaTriKhenThuong").ToString();
            IDKT = gvKhenThuong.GetRowCellValue(gvKhenThuong.FocusedRowHandle, "IDKT").ToString();

            MaKyLuat = gvKyLuat.GetRowCellValue(gvKyLuat.FocusedRowHandle, "MaKyLuat").ToString();
             TenKyLuat = gvKyLuat.GetRowCellValue(gvKyLuat.FocusedRowHandle, "TenKyLuat").ToString();
             SoTienKyLuat = gvKyLuat.GetRowCellValue(gvKyLuat.FocusedRowHandle, "SoTienKyLuat").ToString();
            IDKL = gvKyLuat.GetRowCellValue(gvKyLuat.FocusedRowHandle, "IDKL").ToString();

            MaPB = gvPhongBan.GetRowCellValue(gvPhongBan.FocusedRowHandle, "MaPB").ToString();
             TenPB = gvPhongBan.GetRowCellValue(gvPhongBan.FocusedRowHandle, "TenPB").ToString();
            IDPB = gvPhongBan.GetRowCellValue(gvPhongBan.FocusedRowHandle, "IDPB").ToString();

            MaCV = gvChucVu.GetRowCellValue(gvChucVu.FocusedRowHandle, "MaCV").ToString();
             TenCV = gvChucVu.GetRowCellValue(gvChucVu.FocusedRowHandle, "TenCV").ToString();
            IDCV = gvChucVu.GetRowCellValue(gvChucVu.FocusedRowHandle, "IDCV").ToString();

            BacLuong = gvLuong.GetRowCellValue(gvLuong.FocusedRowHandle, "BacLuong").ToString();
             LuongCoBan = gvLuong.GetRowCellValue(gvLuong.FocusedRowHandle, "LuongCoBan").ToString();
            IDL = gvLuong.GetRowCellValue(gvLuong.FocusedRowHandle, "IDL").ToString();

            MaBH = gvBaoHiem.GetRowCellValue(gvBaoHiem.FocusedRowHandle, "MaBH").ToString();
             TenBaoHiem = gvBaoHiem.GetRowCellValue(gvBaoHiem.FocusedRowHandle, "TenBaoHiem").ToString();
             SoTienBH = gvBaoHiem.GetRowCellValue(gvBaoHiem.FocusedRowHandle, "SoTien").ToString();
            IDBH = gvBaoHiem.GetRowCellValue(gvBaoHiem.FocusedRowHandle, "IDBH").ToString();

        }

    }   
}
