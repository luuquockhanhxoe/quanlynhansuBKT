using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DoAnNhanSuBanChuan.DataAccess;

namespace DoAnNhanSuBanChuan
{
    public partial class DangNhap : DevExpress.XtraEditors.XtraForm
    {
        Data_Access dangnhap = new Data_Access();
        public DangNhap()
        {
            InitializeComponent();
        }
        string hovaten,nhiemvu;
        public bool thongtindangnhap()
        {
            DataTable thongtindangnhap = dangnhap.CreateTable("SELECT NGUOIDUNGHETHONG.MaNV,NGUOIDUNGHETHONG.NhiemVu,NGUOIDUNGHETHONG.TenTaiKhoan, NGUOIDUNGHETHONG.MatKhau,NHANVIEN.HoTen FROM NGUOIDUNGHETHONG LEFT JOIN NHANVIEN ON NGUOIDUNGHETHONG.MaNV = NHANVIEN.MaNV WHERE TenTaiKhoan = '"+txtTenTaiKhoan.Text+"'");
            for (int i = 0; i < thongtindangnhap.Rows.Count; i++)
                if (txtMatKhau.Text == thongtindangnhap.Rows[i]["MatKhau"].ToString())
                {
                    hovaten = thongtindangnhap.Rows[i]["HoTen"].ToString();
                    nhiemvu = thongtindangnhap.Rows[i]["NhiemVu"].ToString();
                    return true;
                }
            return false;
        }
        public bool kiemtrathongtin()
        {
            if(txtTenTaiKhoan.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên tài khoản.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenTaiKhoan.Focus();
                return false;
            }
            if (txtMatKhau.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenTaiKhoan.Focus();
                return false;
            }
            return true;
        }

        private void spbtnChapNhanThongTinNhanSu_Click(object sender, EventArgs e)
        {
            if(kiemtrathongtin() == true)
            {
                if(thongtindangnhap() == true)
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TrangChu moformtrangchu = new TrangChu(nhiemvu);
                    this.Hide();
                    moformtrangchu.FormBorderStyle = FormBorderStyle.None;
                    moformtrangchu.WindowState = FormWindowState.Maximized;
                    moformtrangchu.Text = "Đăng nhập bởi " + hovaten + " quyền " + nhiemvu + " !";
                    moformtrangchu.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Bạn nhập sai tên tài khoản hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult ThongBao = MessageBox.Show("Bạn có muốn thoát không?",
              "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (ThongBao == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void cbHien_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHien.Checked == false)
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
        }
    }
}