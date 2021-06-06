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
        public fmThongTinHopDong(string mahopdong, string NgaykyHD, string loaihopdong, string thoihanhd, string solaodong, string bacluong, string hesoluong, string chedolamviec, string hinhthuctraluong, string manhanvien) : this()
        {
            txtMaHD.Text = mahopdong;
            txtMaHD.ReadOnly = true;
            cbMaNV.Text = manhanvien;
            cbMaNV.Enabled = false;
            dtpNgayKy.Text = NgaykyHD;
            cbLoaiHD.Text = loaihopdong;
            cbThoiHan.Text = thoihanhd;
            cbBacLuong.Text = bacluong;
            cbHeSoLuong.Text = hesoluong;
            cbCheDoLamViec.Text = chedolamviec;
            cbHinhThucTraLuong.Text = hinhthuctraluong;
            txtSoLaoDong.Text = solaodong;
        }

        public fmThongTinHopDong()
        {
            InitializeComponent();
            dulieuchon();
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
        }
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
        }
        private void smbtnHuyBoThongTinHopDong_Click(object sender, EventArgs e)
        {
            DialogResult ThongBaoHuy = MessageBox.Show("Bạn có muốn hủy bỏ không?", "Thông báo"
                , MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (ThongBaoHuy == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void fmThongTinHopDong_Load(object sender, EventArgs e)
        {

        }

        private void smbtnChapNhanThongTinNhanSu_Click(object sender, EventArgs e)
        {
          if (kiemtranhap() == true)
            {
                if (txtMaHD.ReadOnly == false)
                {
                    if (kiemtranhap2() == true)
                    {
                        themthongtinhopdong();
                    }
                    }
                else
                {
                    suathongtinhopdong();
                }
            }
        }

        private void spbtnLamMoi_Click(object sender, EventArgs e)
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
            txtSoLaoDong.Clear();
        }
        string MaHD, MaNV, NgayKyHD, LoaiHD, ThoiHan, BacLuong, HeSoLuong, CheDoLamViec, HinhThucTraLuong, SoLaoDong;

        private void cbLoaiHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLoaiHD.Text == "HĐLĐ Không xác định thời hạn")
            {
                cbThoiHan.Items.Add("Vô Thời Hạn");
                cbThoiHan.Text = "Vô Thời Hạn";
                cbThoiHan.Enabled = false;
                lbthang.Text = "";
            }
            else
            {
                cbThoiHan.Enabled = true;
                cbThoiHan.Items.Remove("Vô Thời Hạn");
                cbThoiHan.Text = "";
                lbthang.Text = "THÁNG";
            }
        }
        public void thongtinnhap()
        {
            MaHD = txtMaHD.Text.Trim();
            MaNV = cbMaNV.Text.Trim();
            NgayKyHD = dtpNgayKy.Text.Trim();
            LoaiHD = cbLoaiHD.Text.Trim();
            ThoiHan = cbThoiHan.Text.Trim();
            BacLuong = cbBacLuong.Text.Trim();
            HeSoLuong = cbHeSoLuong.Text.Trim();
            CheDoLamViec = cbCheDoLamViec.Text.Trim();
            HinhThucTraLuong = cbHinhThucTraLuong.Text.Trim();
            SoLaoDong = txtSoLaoDong.Text.Trim();
        }
        public void themthongtinhopdong()
        {
            thongtinnhap();
            DataTable dt = hd.CreateTable("INSERT INTO HOPDONG VALUES ('" + MaHD + "','" + NgayKyHD + "',N'" + LoaiHD + "',N'" + ThoiHan + "',N'" + SoLaoDong + "','" + BacLuong + "','" + HeSoLuong + "',N'" + CheDoLamViec + "',N'" + HinhThucTraLuong + "', '" + MaNV + "')");
            MessageBox.Show("Đã thêm hợp đồng "+ MaHD +" cho nhân viên có mã " + MaNV + " thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        public void suathongtinhopdong()
        {
            thongtinnhap();
            DataTable dt = hd.CreateTable("UPDATE HOPDONG SET MaHD = '" + MaHD + "',NgayKyHD='" + NgayKyHD + "',LoaiHD = N'" + LoaiHD + "',ThoiHanHD = N'" + ThoiHan + "',SoLaoDong =  '" + SoLaoDong + "',BacLuong = N'" + BacLuong + "', HeSoLuong = N'" + HeSoLuong + "',CheDoLamViec = N'" + CheDoLamViec + "',HinhThucTraLuong = N'" + HinhThucTraLuong + "',MaNV = '" + MaNV + "' WHERE MaHD = '" + MaHD + "' ");          
            MessageBox.Show("Đã sửa hợp đồng " + MaHD + " có mã " + MaNV + " thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
