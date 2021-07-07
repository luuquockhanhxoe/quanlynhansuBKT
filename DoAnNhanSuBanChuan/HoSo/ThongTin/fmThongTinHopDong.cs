using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnNhanSuBanChuan.DataAccess;

namespace DoAnNhanSuBanChuan.HoSo.ThongTin
{
    public partial class fmThongTinHopDong : Form
    {
        Data_Access hd = new Data_Access();
        public fmThongTinHopDong()
        {
            InitializeComponent();
            hienthithongtin();
        }
        public void hienthithongtin()
        {
            dulieuchon();
            DataTable thongtinhopdong = hd.CreateTable("SELECT * FROM HOPDONG");
            gcHopDong.DataSource = thongtinhopdong;
            xoatextbox();
        }
        public void dulieuchon()
        {
            DataTable dulieuvaocommbobox = hd.CreateTable("SELECT MaNV FROM NHANVIEN");
            cbMaNV.DataSource = dulieuvaocommbobox;
            cbMaNV.DisplayMember = "MaNV";
            DataTable dulieuvaocommbobox1 = hd.CreateTable("SELECT BacLuong FROM LUONG");
            cbBacLuong.DataSource = dulieuvaocommbobox1;
            cbBacLuong.DisplayMember = "BacLuong";
        }
        public void thongtinnhap()
        {
            MaHD = txtMaHD.Text.Trim();
            MaNV = cbMaNV.Text.Trim();
            NgayKyHD = dtpNgayKy.Value.ToString();
            LoaiHD = cbLoaiHD.Text.Trim();
            ThoiHan = cbThoiHan.Text.Trim();
            BacLuong = cbBacLuong.Text.Trim();
            HeSoLuong = cbHeSoLuong.Text.Trim();
            CheDoLamViec = cbCheDoLamViec.Text.Trim();
            HinhThucTraLuong = cbHinhThucTraLuong.Text.Trim();
            SoLaoDong = txtSoLaoDong.Text.Trim();
        }
        public bool kiemtranhap()
        {
            if (string.IsNullOrWhiteSpace(txtMaHD.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã hợp đồng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaHD.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cbMaNV.Text))
            {
                MessageBox.Show("Bạn chưa chọn mã nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbMaNV.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cbLoaiHD.Text))
            {
                MessageBox.Show("Bạn chưa chọn loại hợp đồng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLoaiHD.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cbThoiHan.Text))
            {
                MessageBox.Show("Bạn chưa chọn thời hạn hợp đồng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbThoiHan.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cbBacLuong.Text))
            {
                MessageBox.Show("Bạn chưa chọn bậc lương cho hợp đồng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbBacLuong.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cbHeSoLuong.Text))
            {
                MessageBox.Show("Bạn chưa chọn hệ số lương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbHeSoLuong.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cbCheDoLamViec.Text))
            {
                MessageBox.Show("Bạn chưa chọn chế độ làm việc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbCheDoLamViec.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cbHinhThucTraLuong.Text))
            {
                MessageBox.Show("Bạn chưa chọn hình thức trả lương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbHinhThucTraLuong.Focus();
                return false;
            }
            return true;
        } // kiểm tra textbox
        public bool kiemtranhap2()
        {
            thongtinnhap();
            DataTable kiemtra1 = hd.CreateTable("select * from HOPDONG;");
            for (int i = 0; i < kiemtra1.Rows.Count; i++)
                if (MaHD == kiemtra1.Rows[i]["MaHD"].ToString())
                {
                    MessageBox.Show("Mã hợp đồng này đã được dùng, mời nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            for (int i = 0; i < kiemtra1.Rows.Count; i++)
                if (MaNV == kiemtra1.Rows[i]["MaNV"].ToString())
                {
                    MessageBox.Show("Mã nhân viên này đã được làm hợp đồng, mời chọn mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            return true;
        } // kiểm tra trùng mã hợp đồng và mã nhân viên đã tạo chưa?
        private void smbtnHuyBoThongTinHopDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
  

        string MaHD, MaNV, NgayKyHD, LoaiHD, ThoiHan, BacLuong, HeSoLuong, CheDoLamViec, HinhThucTraLuong, SoLaoDong;

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            var r = new rpBaoCaoHopDong();
            DataTable inthongtin = hd.CreateTable("SELECT NHANVIEN.HoTen, HOPDONG.MaHD, HOPDONG.MaNV, CONVERT(varchar,HOPDONG.NgayKyHD,103) as NgayKyHD, HOPDONG.LoaiHD, HOPDONG.ThoiHanHD, HOPDONG.SoLaoDong, HOPDONG.BacLuong, HOPDONG.HeSoLuong, HOPDONG.CheDoLamViec, HOPDONG.HinhThucTraLuong FROM HOPDONG LEFT JOIN NHANVIEN ON HOPDONG.MaNV = NHANVIEN.MaNV");
            r.DataSource = inthongtin;
            r.hienthipreview();
        }

        private void fmThongTinHopDong_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult ThongBao = MessageBox.Show("Bạn có muốn thoát không?",
               "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (ThongBao == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void cbHienThi_CheckedChanged(object sender, EventArgs e)
        {
            if(cbHienThi.Checked == false)
            {
                hienthithongtin();
                txtMaHD.ReadOnly = false;
            }
            else
            {
                txtMaHD.ReadOnly = true;
                ganketdulieu();
            }
        }
        public void xoatextbox()
        {
            txtMaHD.Clear();
            cbMaNV.Text = "";
            dtpNgayKy.Text = "";
            cbLoaiHD.Text = "";
            cbThoiHan.Text = "";
            cbBacLuong.Text = "";
            cbHeSoLuong.Text = "";
            cbCheDoLamViec.Text = "";
            cbHinhThucTraLuong.Text = "";
            txtTimKiem.Clear();
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            hienthithongtin();
            xoatextbox();
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
            DataTable thongtinhd = hd.CreateTable("SELECT * FROM HOPDONG WHERE MaNV LIKE '%" + txtTimKiem.Text + "%' OR MaHD LIKE N'%" + txtTimKiem.Text + "%' OR NgayKyHD LIKE N'%" + txtTimKiem.Text + "%' OR LoaiHD LIKE N'%" + txtTimKiem.Text + "%' OR ThoiHanHD LIKE N'%" + txtTimKiem.Text + "%' OR SoLaoDong LIKE N'%" + txtTimKiem.Text + "%' OR BacLuong LIKE '%" + txtTimKiem.Text + "%' OR HeSoLuong LIKE N'%" + txtTimKiem.Text + "%' OR CheDoLamViec LIKE N'%" + txtTimKiem.Text + "%' OR HinhThucTraLuong LIKE N'%" + txtTimKiem.Text + "%'");
            if (thongtinhd.Rows.Count == 0)
            {
                DialogResult ThongBao = MessageBox.Show("Không tìm thấy dữ liệu!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            else
            {
                gcHopDong.DataSource = thongtinhd;
            }
        }

        private void cbLoaiHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbLoaiHD.Text == "HĐLĐ Không xác định thời hạn")
            {
                cbThoiHan.Text = "Vô Thời Hạn";
            }
            else
            {
                cbThoiHan.DataBindings.Clear();
                cbThoiHan.DataBindings.Add("text", gcHopDong.DataSource, "ThoiHanHD");
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (kiemtranhap() == true)
            {
                if(txtMaHD.ReadOnly == true)
                {
                    thongtinnhap();
                    DataTable dt = hd.CreateTable("UPDATE HOPDONG SET MaHD = '" + MaHD + "',NgayKyHD='" + NgayKyHD + "',LoaiHD = N'" + LoaiHD + "',ThoiHanHD = N'" + ThoiHan + "',SoLaoDong =  '" + SoLaoDong + "',BacLuong = N'" + BacLuong + "', HeSoLuong = N'" + HeSoLuong + "',CheDoLamViec = N'" + CheDoLamViec + "',HinhThucTraLuong = N'" + HinhThucTraLuong + "',MaNV = '" + MaNV + "' WHERE MaHD = '" + MaHD + "' ");
                    MessageBox.Show("Đã sửa hợp đồng " + MaHD + " có mã " + MaNV + " thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienthithongtin();
                }
                else
                if (kiemtranhap2() == true)
                {
                    thongtinnhap();
                    DataTable them = hd.CreateTable("INSERT INTO HOPDONG VALUES ('" + MaHD + "','" + NgayKyHD + "',N'" + LoaiHD + "',N'" + ThoiHan + "',N'" + SoLaoDong + "','" + BacLuong + "','" + HeSoLuong + "',N'" + CheDoLamViec + "',N'" + HinhThucTraLuong + "', '" + MaNV + "')");
                    MessageBox.Show("Đã thêm hợp đồng " + MaHD + " cho nhân viên có mã " + MaNV + " thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienthithongtin();
                }
            }
        }
        public void ganketdulieu()
        {
            txtMaHD.DataBindings.Clear();
            txtMaHD.DataBindings.Add("text", gcHopDong.DataSource, "MaHD");
            cbMaNV.DataBindings.Clear();
            cbMaNV.DataBindings.Add("text", gcHopDong.DataSource, "MaNV");
            dtpNgayKy.DataBindings.Clear();
            dtpNgayKy.DataBindings.Add("text", gcHopDong.DataSource, "NgayKyHD");
            cbHeSoLuong.DataBindings.Clear();
            cbHeSoLuong.DataBindings.Add("text", gcHopDong.DataSource, "HeSoLuong");
            cbBacLuong.DataBindings.Clear();
            cbBacLuong.DataBindings.Add("text", gcHopDong.DataSource, "BacLuong");
            txtSoLaoDong.DataBindings.Clear();
            txtSoLaoDong.DataBindings.Add("text", gcHopDong.DataSource, "SoLaoDong");
            cbLoaiHD.DataBindings.Clear();
            cbLoaiHD.DataBindings.Add("text", gcHopDong.DataSource, "LoaiHD");
            cbCheDoLamViec.DataBindings.Clear();
            cbCheDoLamViec.DataBindings.Add("text", gcHopDong.DataSource, "CheDoLamViec");
            cbHinhThucTraLuong.DataBindings.Clear();
            cbHinhThucTraLuong.DataBindings.Add("text", gcHopDong.DataSource, "HinhThucTraLuong");
            cbThoiHan.DataBindings.Clear();
            cbThoiHan.DataBindings.Add("text", gcHopDong.DataSource, "ThoiHanHD");
        }
    }
}
