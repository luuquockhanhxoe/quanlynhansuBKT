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
                ttbacluong_load();
                DataTable xoaluong = ttlq.CreateTable("DELETE FROM LUONG WHERE BacLuong = '" + BacLuong + "'");
                MessageBox.Show("Đã xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable hienthiluong = ttlq.CreateTable("SELECT * FROM LUONG ");
                gcLuong.DataSource = hienthiluong;
            }
        }
        private void BtnSuaLuong_Click(object sender, EventArgs e)
        {
            ttbacluong_load();
            DataTable sual = ttlq.CreateTable("UPDATE LUONG SET  BacLuong = '" + BacLuong + "',LuongCoBan = '" + LuongCoBan + "' WHERE IDL = '" + IDL+"' ");
            MessageBox.Show("Đã sửa thông tin lương !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable hienthiluong = ttlq.CreateTable("SELECT * FROM LUONG ");
            gcLuong.DataSource = hienthiluong;
        }

        private void BtnThemLuong_Click(object sender, EventArgs e)
        {
                ttbacluong_load();
                DataTable kiemtral = ttlq.CreateTable("SELECT * FROM LUONG ");
                if (kiemtral.Select("BacLuong ='" + BacLuong + "'").Length == 1 || kiemtral.Select("LuongCoBan = '" + LuongCoBan + "'").Length == 1)
                {
                    MessageBox.Show("Trùng thông tin lương!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DataTable themluong = ttlq.CreateTable("INSERT INTO LUONG VALUES('" + BacLuong + "','" + LuongCoBan + "')");
                    MessageBox.Show("Đã thêm thông tin lương !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataTable hienthiluong = ttlq.CreateTable("SELECT * FROM LUONG ");
                    gcLuong.DataSource = hienthiluong;
                }
        }

        private void BtnXoaBH_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                ttbaohiem_load();
                DataTable xoabh = ttlq.CreateTable("DELETE FROM BAOHIEM WHERE MaBH = '" + MaBH + "'");
                MessageBox.Show("Đã xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable hienthibaohiem = ttlq.CreateTable("SELECT * FROM BAOHIEM ");
                gcBaoHiem.DataSource = hienthibaohiem;
            }
        }

        private void BtnSuaBH_Click(object sender, EventArgs e)
        {
            ttbaohiem_load();
            DataTable suabh = ttlq.CreateTable("UPDATE BAOHIEM SET MaBH = '" + MaBH + "',TenBaoHiem = N'" + TenBaoHiem + "',SoTien = '" + SoTienBH + "' WHERE IDBH = '" + IDBH + "' ");
            MessageBox.Show("Đã sửa thông tin bảo hiểm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable hienthibaohiem = ttlq.CreateTable("SELECT * FROM BAOHIEM ");
            gcBaoHiem.DataSource = hienthibaohiem;
        }

        private void BtnThemBH_Click(object sender, EventArgs e)
        {
            ttbaohiem_load();
            DataTable kiemtrabh = ttlq.CreateTable("SELECT * FROM BAOHIEM ");
            if (kiemtrabh.Select("MaBH ='" + MaBH + "'").Length == 1 || kiemtrabh.Select("TenBaoHiem = '" + TenBaoHiem + "'").Length == 1 || kiemtrabh.Select("SoTien= = '" + SoTienBH + "'").Length == 1)
            {
                MessageBox.Show("Trùng thông tin bảo hiểm!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable thembaohiem = ttlq.CreateTable("INSERT INTO BAOHIEM VALUES('" + MaBH + "',N'" + TenBaoHiem + "','" + SoTienBH + "')");
                MessageBox.Show("Đã thêm thông tin bảo hiểm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable hienthibaohiem = ttlq.CreateTable("SELECT * FROM BAOHIEM ");
                gcBaoHiem.DataSource = hienthibaohiem;
            }
        }

        private void BtnXoaCV_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                ttchucvu_load();
                DataTable xoacv = ttlq.CreateTable("DELETE FROM CHUCVU WHERE MaCV = '" + MaCV + "'");
                MessageBox.Show("Đã xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable hienthichucvu = ttlq.CreateTable("SELECT * FROM CHUCVU ");
                gcChucVu.DataSource = hienthichucvu;
            }
        }

        private void BtnSuaCV_Click(object sender, EventArgs e)
        {
            ttchucvu_load();
            DataTable suacv = ttlq.CreateTable("UPDATE CHUCVU SET MaCV = '" + MaCV + "',TenCV = N'" + TenCV + "' WHERE IDCV = '" + IDCV + "' ");
            MessageBox.Show("Đã sửa thông tin chức vụ !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable hienthichucvu = ttlq.CreateTable("SELECT * FROM CHUCVU ");
            gcChucVu.DataSource = hienthichucvu;
        }

        private void BtnThemCV_Click(object sender, EventArgs e)
        {
            ttchucvu_load();
            DataTable kiemtracv = ttlq.CreateTable("SELECT * FROM CHUCVU ");
            if (kiemtracv.Select("MaCV ='" + MaCV + "'").Length == 1 || kiemtracv.Select("TenCV = '" + TenCV + "'").Length == 1)
            {
                MessageBox.Show("Trùng thông tin chức vụ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable themchucvu = ttlq.CreateTable("INSERT INTO CHUCVU VALUES('" + MaCV + "',N'" + TenCV + "')");
                MessageBox.Show("Đã thêm thông tin chức vụ !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable hienthichucvu = ttlq.CreateTable("SELECT * FROM CHUCVU ");
                gcChucVu.DataSource = hienthichucvu;
            }
        }

        private void BtnSuaPB_Click(object sender, EventArgs e)
        {
            ttphongban_load();
            DataTable suapb = ttlq.CreateTable("UPDATE PHONGBAN SET MaPB = '" + MaPB + "',TenPB = N'" + TenPB + "' WHERE IDPB = '" + IDPB + "' ");
            MessageBox.Show("Đã sửa thông tin phòng ban !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable hienthiphongban = ttlq.CreateTable("SELECT * FROM PHONGBAN ");
            gcPhongBan.DataSource = hienthiphongban;
        }

        private void BtnXoaPB_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                ttphongban_load();
                DataTable xoapb = ttlq.CreateTable("DELETE FROM PHONGBAN WHERE MaPB = '" + MaPB + "'");
                MessageBox.Show("Đã xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable hienthiphongban = ttlq.CreateTable("SELECT * FROM PHONGBAN ");
                gcPhongBan.DataSource = hienthiphongban;
            }
        }

        private void BtnThemPB_Click(object sender, EventArgs e)
        {
            ttphongban_load();
            DataTable kiemtrapb = ttlq.CreateTable("SELECT * FROM PHONGBAN ");
            if (kiemtrapb.Select("MaPB ='" + MaPB + "'").Length == 1 || kiemtrapb.Select("TenPB = '" + TenPB + "'").Length == 1 )
            {
                MessageBox.Show("Trùng thông tin phòng ban!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable themphongban = ttlq.CreateTable("INSERT INTO PHONGBAN VALUES('" + MaPB + "',N'" + TenPB + "')");
                MessageBox.Show("Đã thêm thông tin phòng ban !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable hienthiphongban = ttlq.CreateTable("SELECT * FROM PHONGBAN ");
                gcPhongBan.DataSource = hienthiphongban;
            }
        }

        private void BtnXoaKyLuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                ttkyluat_load();
                DataTable xoakl = ttlq.CreateTable("DELETE FROM KYLUAT WHERE MaKyLuat = '" + MaKyLuat + "'");
                MessageBox.Show("Đã xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable hienthikyluat = ttlq.CreateTable("SELECT * FROM KYLUAT ");
                gcKyLuat.DataSource = hienthikyluat;
            }
        }

        private void BtnSuaKyLuat_Click(object sender, EventArgs e)
        {
            ttkyluat_load();
            DataTable suakl = ttlq.CreateTable("UPDATE KYLUAT SET MaKyLuat = '" + MaKyLuat + "',TenKyLuat = N'" + TenKyLuat + "',SoTienKyLuat = '" + SoTienKyLuat + "' WHERE IDKL = '" + IDKL + "' ");
            MessageBox.Show("Đã sửa thông tin kỷ luật !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable hienthikyluat = ttlq.CreateTable("SELECT * FROM KYLUAT ");
            gcKyLuat.DataSource = hienthikyluat;
        }

        private void BtnThemKyLuat_Click(object sender, EventArgs e)
        {
            ttkyluat_load();
            DataTable kiemtrakl = ttlq.CreateTable("SELECT * FROM KYLUAT ");
            if (kiemtrakl.Select("MaKyLuat ='" + MaKyLuat + "'").Length == 1 || kiemtrakl.Select("TenKyLuat = '" + TenKyLuat + "'").Length == 1 || kiemtrakl.Select("SoTienKyLuat = '" + SoTienKyLuat + "'").Length == 1)
            {
                MessageBox.Show("Trùng thông tin kỷ luật!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable themkyluat = ttlq.CreateTable("INSERT INTO KYLUAT VALUES('" + MaKyLuat + "',N'" + TenKyLuat + "','" + SoTienKyLuat + "')");
                MessageBox.Show("Đã thêm thông tin kỷ luật !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable hienthikyluat = ttlq.CreateTable("SELECT * FROM KYLUAT ");
                gcKyLuat.DataSource = hienthikyluat;
            }
        }

        private void BtnXoaKhenThuong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                ttkhenthuong_load();
                DataTable xoakt = ttlq.CreateTable("DELETE FROM KHENTHUONG WHERE MaKhenThuong = '" + MaKhenThuong + "'");
                MessageBox.Show("Đã xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable hienthikhenthuong = ttlq.CreateTable("SELECT * FROM KHENTHUONG ");
                gcKhenThuong.DataSource = hienthikhenthuong;
            }
        }

        private void BtnSuaKhenThuong_Click(object sender, EventArgs e)
        {
            ttkhenthuong_load();
            DataTable suakt = ttlq.CreateTable("UPDATE KHENTHUONG SET MaKhenThuong = '" + MaKhenThuong + "',TenKhenThuong = N'" + TenKhenThuong + "',GiaTriKhenThuong = '" + GiaTriKhenThuong + "' WHERE IDKT = '" + IDKT + "' ");
            MessageBox.Show("Đã sửa thông tin khen thưởng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable hienthikhenthuong = ttlq.CreateTable("SELECT * FROM KHENTHUONG ");
            gcKhenThuong.DataSource = hienthikhenthuong;
        }

        private void BtnThemKhenThuong_Click(object sender, EventArgs e)
        {
            ttkhenthuong_load();
            DataTable kiemtrakt = ttlq.CreateTable("SELECT * FROM KHENTHUONG ");
            if (kiemtrakt.Select("MaKhenThuong ='" + MaKhenThuong + "'").Length == 1 || kiemtrakt.Select("TenKhenThuong = '" + TenKhenThuong + "'").Length == 1 || kiemtrakt.Select("GiaTriKhenThuong = '" + GiaTriKhenThuong + "'").Length == 1)
            {
                MessageBox.Show("Trùng thông tin khen thưởng!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable themkhenthuong = ttlq.CreateTable("INSERT INTO KHENTHUONG VALUES('" + MaKhenThuong + "',N'" + TenKhenThuong + "','" + GiaTriKhenThuong + "')");
                MessageBox.Show("Đã thêm thông tin khen thưởng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable hienthikhenthuong = ttlq.CreateTable("SELECT * FROM KHENTHUONG ");
                gcKhenThuong.DataSource = hienthikhenthuong;
            }
        }

        private void BtnXoaPC_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                ttphucap_load();
                DataTable xoapc = ttlq.CreateTable("DELETE FROM PHUCAP WHERE MaPC = '" + MaPC + "'");
                MessageBox.Show("Đã xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable hienthiphucap = ttlq.CreateTable("SELECT * FROM PHUCAP ");
                gcPhuCap.DataSource = hienthiphucap;
            }
        }

        private void BtnSuaPC_Click(object sender, EventArgs e)
        {
            ttphucap_load(); ;
            DataTable suapc = ttlq.CreateTable("UPDATE PHUCAP SET MaPC = '" + MaPC + "',TenPC = N'" + TenPC + "',SoTien = '" + SoTien + "' WHERE IDPC = '" + IDPC + "' ");
            MessageBox.Show("Đã sửa thông tin phụ cấp !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable hienthiphucap = ttlq.CreateTable("SELECT * FROM PHUCAP ");
            gcPhuCap.DataSource = hienthiphucap;
        }

        private void BtnThemPC_Click(object sender, EventArgs e)
        {
            ttphucap_load();
            DataTable kiemtrapc = ttlq.CreateTable("SELECT * FROM PHUCAP ");
            if (kiemtrapc.Select("TenPC ='" + TenPC + "'").Length == 1 || kiemtrapc.Select("MaPC = '" + MaPC + "'").Length == 1 || kiemtrapc.Select("SoTien = '" + SoTien + "'").Length == 1)
            {
                MessageBox.Show("Trùng thông tin phụ cấp!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable themphucap = ttlq.CreateTable("INSERT INTO PHUCAP VALUES('" + MaPC + "',N'" + TenPC + "','" + SoTien + "')");
                MessageBox.Show("Đã thêm thông tin phụ cấp !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable hienthiphucap = ttlq.CreateTable("SELECT * FROM PHUCAP ");
                gcPhuCap.DataSource = hienthiphucap;
            }
        }

        private void BtnXoaCC_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                ttchungchi_load();
                DataTable xoacc = ttlq.CreateTable("DELETE FROM CHUNGCHI WHERE MaCC = '" + MaCC + "'");
                MessageBox.Show("Đã xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable hienthichungchi = ttlq.CreateTable("SELECT * FROM CHUNGCHI ");
                gcChungChi.DataSource = hienthichungchi;
            }
        }

        private void BtnSuaCC_Click(object sender, EventArgs e)
        {
            ttchungchi_load();
            DataTable suacc = ttlq.CreateTable("UPDATE CHUNGCHI SET MaCC = '" + MaCC + "',TenChungChi = N'" + TenChungChi + "' WHERE IDCC = '" + IDCC + "' ");
            MessageBox.Show("Đã sửa thông tin chứng chỉ !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable hienthichungchi = ttlq.CreateTable("SELECT * FROM CHUNGCHI ");
            gcChungChi.DataSource = hienthichungchi;
        }

        private void BtnThemCC_Click(object sender, EventArgs e)
        {
            ttchungchi_load();
            DataTable kiemtracc = ttlq.CreateTable("SELECT * FROM CHUNGCHI ");
            if (kiemtracc.Select("MaCC ='" + MaCC + "'").Length == 1 || kiemtracc.Select("TenChungChi = '" + TenChungChi + "'").Length == 1)
            {
                MessageBox.Show("Trùng thông tin chứng chỉ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable themchungchi = ttlq.CreateTable("INSERT INTO CHUNGCHI VALUES('" + MaCC + "',N'" + TenChungChi + "')");
                MessageBox.Show("Đã thêm thông tin chứng chỉ !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable hienthichungchi = ttlq.CreateTable("SELECT * FROM CHUNGCHI ");
                gcChungChi.DataSource = hienthichungchi;
            }
        }

        private void BtnXoaHV_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                tthv_load();
                DataTable xoahv = ttlq.CreateTable("DELETE FROM HOCVAN WHERE MaHV = '" + MaHV + "'");
                MessageBox.Show("Đã xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable hienthihocvan = ttlq.CreateTable("SELECT * FROM HOCVAN ");
                gcHocVan.DataSource = hienthihocvan;
            }
        }

        private void BtnSuaHV_Click(object sender, EventArgs e)
        {
            tthv_load();
            DataTable suahv = ttlq.CreateTable("UPDATE HOCVAN SET MaHV = '" + MaHV + "',TrinhDo = N'" + TrinhDo + "' WHERE IDHV = '" + IDHV + "' ");
            MessageBox.Show("Đã sửa thông tin học vấn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable hienthihocvan = ttlq.CreateTable("SELECT * FROM HOCVAN ");
            gcHocVan.DataSource = hienthihocvan;
        }

        private void BtnThemHV_Click(object sender, EventArgs e)
        {
            tthv_load();
            DataTable kiemtrahv = ttlq.CreateTable("SELECT * FROM HOCVAN ");
            if (kiemtrahv.Select("TrinhDo ='" + TrinhDo + "'").Length == 1 || kiemtrahv.Select("MaHV = '" + MaHV + "'").Length == 1)
            {
                MessageBox.Show("Trùng thông tin học vấn!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }          
            else
            {
                DataTable themhocvan = ttlq.CreateTable("INSERT INTO HOCVAN VALUES('" + MaHV + "',N'" + TrinhDo + "')");
                MessageBox.Show("Đã thêm thông tin học vấn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable hienthihocvan = ttlq.CreateTable("SELECT * FROM HOCVAN ");
                gcHocVan.DataSource = hienthihocvan;
            }
        }

        string MaHV, IDHV, IDCC, TrinhDo, IDPC, IDL, IDBH, IDCV, IDPB, IDKT, IDKL, MaCC, MaCV, TenCV, TenChungChi, LuongCoBan, MaBH, TenBaoHiem, SoTienBH, BacLuong, MaPC, TenPC, SoTien, MaKhenThuong, TenKhenThuong, GiaTriKhenThuong, MaKyLuat, TenKyLuat, SoTienKyLuat, MaPB, TenPB;
        public void tthv_load()
        {
            MaHV = gvHocVan.GetRowCellValue(gvHocVan.FocusedRowHandle, "MaHV").ToString();
            TrinhDo = gvHocVan.GetRowCellValue(gvHocVan.FocusedRowHandle, "TrinhDo").ToString();
            IDHV = gvHocVan.GetRowCellValue(gvHocVan.FocusedRowHandle, "IDHV").ToString();

        }
        public void ttchungchi_load()
        {
            MaCC = gvChungChi.GetRowCellValue(gvChungChi.FocusedRowHandle, "MaCC").ToString();
            TenChungChi = gvChungChi.GetRowCellValue(gvChungChi.FocusedRowHandle, "TenChungChi").ToString();
            IDCC = gvChungChi.GetRowCellValue(gvChungChi.FocusedRowHandle, "IDCC").ToString();
        }
        public void ttphucap_load()
        {
            MaPC = gvPhuCap.GetRowCellValue(gvPhuCap.FocusedRowHandle, "MaPC").ToString();
            TenPC = gvPhuCap.GetRowCellValue(gvPhuCap.FocusedRowHandle, "TenPC").ToString();
            SoTien = gvPhuCap.GetRowCellValue(gvPhuCap.FocusedRowHandle, "SoTien").ToString();
            IDPC = gvPhuCap.GetRowCellValue(gvPhuCap.FocusedRowHandle, "IDPC").ToString();
        }
        public void ttkhenthuong_load()
        {
            MaKhenThuong = gvKhenThuong.GetRowCellValue(gvKhenThuong.FocusedRowHandle, "MaKhenThuong").ToString();
            TenKhenThuong = gvKhenThuong.GetRowCellValue(gvKhenThuong.FocusedRowHandle, "TenKhenThuong").ToString();
            GiaTriKhenThuong = gvKhenThuong.GetRowCellValue(gvKhenThuong.FocusedRowHandle, "GiaTriKhenThuong").ToString();
            IDKT = gvKhenThuong.GetRowCellValue(gvKhenThuong.FocusedRowHandle, "IDKT").ToString();
        }

        public void ttkyluat_load()
        {
            MaKyLuat = gvKyLuat.GetRowCellValue(gvKyLuat.FocusedRowHandle, "MaKyLuat").ToString();
            TenKyLuat = gvKyLuat.GetRowCellValue(gvKyLuat.FocusedRowHandle, "TenKyLuat").ToString();
            SoTienKyLuat = gvKyLuat.GetRowCellValue(gvKyLuat.FocusedRowHandle, "SoTienKyLuat").ToString();
            IDKL = gvKyLuat.GetRowCellValue(gvKyLuat.FocusedRowHandle, "IDKL").ToString();
        }
        public void ttphongban_load()
        {
            MaPB = gvPhongBan.GetRowCellValue(gvPhongBan.FocusedRowHandle, "MaPB").ToString();
            TenPB = gvPhongBan.GetRowCellValue(gvPhongBan.FocusedRowHandle, "TenPB").ToString();
            IDPB = gvPhongBan.GetRowCellValue(gvPhongBan.FocusedRowHandle, "IDPB").ToString();
        }
        public void ttchucvu_load()
        {
            MaCV = gvChucVu.GetRowCellValue(gvChucVu.FocusedRowHandle, "MaCV").ToString();
            TenCV = gvChucVu.GetRowCellValue(gvChucVu.FocusedRowHandle, "TenCV").ToString();
            IDCV = gvChucVu.GetRowCellValue(gvChucVu.FocusedRowHandle, "IDCV").ToString();
        }
        public void ttbacluong_load()
        {
            BacLuong = gvLuong.GetRowCellValue(gvLuong.FocusedRowHandle, "BacLuong").ToString();
            LuongCoBan = gvLuong.GetRowCellValue(gvLuong.FocusedRowHandle, "LuongCoBan").ToString();
            IDL = gvLuong.GetRowCellValue(gvLuong.FocusedRowHandle, "IDL").ToString();
        }
        public void ttbaohiem_load()
        {
            MaBH = gvBaoHiem.GetRowCellValue(gvBaoHiem.FocusedRowHandle, "MaBH").ToString();
            TenBaoHiem = gvBaoHiem.GetRowCellValue(gvBaoHiem.FocusedRowHandle, "TenBaoHiem").ToString();
            SoTienBH = gvBaoHiem.GetRowCellValue(gvBaoHiem.FocusedRowHandle, "SoTien").ToString();
            IDBH = gvBaoHiem.GetRowCellValue(gvBaoHiem.FocusedRowHandle, "IDBH").ToString();

        }      
    }   

}
