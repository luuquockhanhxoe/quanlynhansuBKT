using DoAnNhanSuBanChuan.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnNhanSuBanChuan.TongQuan.ThietLap
{
    public partial class TaoNguoiDungHeThong : Form
    {
        Data_Access taonguoidung = new Data_Access();

        public TaoNguoiDungHeThong(string manhanvien, string hovaten, string nhiemvu, string tentaikhoan, string matkhau) : this()
        {
            cbMaNV.Text = manhanvien;
            cbMaNV.Enabled = false;
            txtHoTen.Text = hovaten;
            cbNhiemVu.Text = nhiemvu;
            txtTenTaiKhoan.Text = tentaikhoan;
            txtMatKhau.Text = matkhau;
            txtXacNhanMatKhau.Text = matkhau;
        }

        public TaoNguoiDungHeThong()
        {
            InitializeComponent();
            dulieuchon();
        }

        private void spbtnHuyBoThongTinNguoiDung_Click(object sender, EventArgs e)
        {        
            this.Close();
        }
        private void TaoNguoiDungHeThong_Load(object sender, EventArgs e)
        {
            
        }

        public bool kiemtratrung()
        {
            thongtinnhap();
            DataTable kiemtra = taonguoidung.CreateTable("select * from NGUOIDUNGHETHONG;");
            for (int i = 0; i < kiemtra.Rows.Count; i++)
                if (MaNV == kiemtra.Rows[i]["MaNV"].ToString())
                {
                    MessageBox.Show("Mã nhân viên này đã được tạo, mời chọn mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            return true;
        }
        public bool kiemtranhap()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Bạn chưa chọn mã nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbMaNV.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cbNhiemVu.Text))
            {
                MessageBox.Show("Bạn chưa chọn nhiệm vụ cho nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoTen.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenTaiKhoan.Text))
            {
                MessageBox.Show("Bạn chưa tạo tên tài khoản cho nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenTaiKhoan.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Bạn chưa tạo mật khẩu cho tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtXacNhanMatKhau.Text))
            {
                MessageBox.Show("Bạn chưa nhập xác nhận mật khẩu cho tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtXacNhanMatKhau.Focus();
                return false;
            }
            else
            {             
                    if (txtXacNhanMatKhau.Text != txtMatKhau.Text)
                    {
                        MessageBox.Show("Không trùng mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtXacNhanMatKhau.Focus();
                        return false;
                    }

            }
            return true;
        }

        string MaNV, NhiemVu, TenTaiKhoan, MatKhau;
        public void thongtinnhap()
        {
            MaNV = cbMaNV.Text.Trim();
            NhiemVu = cbNhiemVu.Text.Trim();
            TenTaiKhoan = txtTenTaiKhoan.Text.Trim();
            MatKhau = txtMatKhau.Text.Trim();
        }
        public void themthongtintaikhoan()
        {
            thongtinnhap();
            DataTable dt = taonguoidung.CreateTable("INSERT INTO NGUOIDUNGHETHONG VALUES('" + MaNV+ "',N'" + NhiemVu + "',N'" + TenTaiKhoan + "',N'" + MatKhau + "')");
            MessageBox.Show("Đã thêm tài khoản cho nhân viên có mã "+ MaNV +" thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void cbHien_CheckedChanged(object sender, EventArgs e)
        {
            if(cbHien.Checked == false)
            {
                txtMatKhau.UseSystemPasswordChar = true;
                txtXacNhanMatKhau.UseSystemPasswordChar = true;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = false;
                txtXacNhanMatKhau.UseSystemPasswordChar = false;
            }
        }

        public void suathongtintaikhoan()
        {
            DataTable dt = taonguoidung.CreateTable("UPDATE NGUOIDUNGHETHONG SET NhiemVu = N'" + cbNhiemVu.Text + "',TenTaiKhoan ='" + txtTenTaiKhoan.Text + "',MatKhau = '" + txtMatKhau.Text + "' WHERE MaNV = '" + cbMaNV.Text + "' ");
            MessageBox.Show("Đã sửa tài khoản cho nhân viên có mã " + MaNV + " thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void TaoNguoiDungHeThong_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult ThongBao = MessageBox.Show("Bạn có muốn thoát không?",
              "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (ThongBao == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void spbtnChapNhanThongTinNguoiDung_Click(object sender, EventArgs e)
        {
            kiemtranhap();
            if (cbMaNV.Enabled == true)
              {
                if(kiemtratrung() == true)
                {
                    themthongtintaikhoan();
                }
              }
            else
              {
                suathongtintaikhoan();
              }
        }

        public void dulieuchon()
        {
            DataTable dulieuvaocommbobox = taonguoidung.CreateTable("SELECT MaNV, HoTen FROM NHANVIEN");
            cbMaNV.DataSource = dulieuvaocommbobox;
            cbMaNV.DisplayMember = "MaNV";
            cbMaNV.ValueMember = "HoTen";
        }
        private void cbMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtHoTen.Text = cbMaNV.SelectedValue.ToString();            
        }
    }
}
