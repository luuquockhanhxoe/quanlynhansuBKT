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

namespace DoAnNhanSuBanChuan.ChamCong.NhapThongTin
{
    public partial class fmDangKyLamThem : Form
    {
        Data_Access dangkylamthem = new Data_Access();
        public fmDangKyLamThem()
        {
            InitializeComponent();
            hienthicombobox();
        }
        public void hienthicombobox()
        {
            DataTable hienthi = dangkylamthem.CreateTable("Select DISTINCT CHAMCONGHANGNGAY.MaNV, NHANVIEN.HoTen FROM CHAMCONGHANGNGAY LEFT JOIN NHANVIEN ON CHAMCONGHANGNGAY.MaNV = NHANVIEN.MaNV WHERE NHANVIEN.TrangThai = N'Đang làm việc'");
            cbMaNV.DataSource = hienthi;
            cbMaNV.DisplayMember = "MaNV";
            cbMaNV.ValueMember = "HoTen";
            txtHoTen.Text = cbMaNV.SelectedValue.ToString();
        }

        public bool kiemtranhap()
        {
            if(cbSoGioDangKy.Text.Length == 0 )
            {
                MessageBox.Show("Bạn chưa chọn số giờ đăng ký cho nhân viên!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtHoTen.Text == "System.Data.DataRowView")
            {
                MessageBox.Show("Bạn chưa chọn nhân viên!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public void dangkychonhanvien()
        {
            if (kiemtranhap() == true)
            {
                DataTable dangky = dangkylamthem.CreateTable("UPDATE CHAMCONGHANGNGAY SET SoGioLamThem = '" + cbSoGioDangKy.Text + "' WHERE MaNV = '"+cbMaNV.Text+"' AND NgayDiLam = '"+dtpThoiGian.Value+"' ");
                MessageBox.Show("Đã đăng ký làm thêm giờ cho nhân viên mã " + cbMaNV.Text + "!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void cbMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtHoTen.Text = cbMaNV.SelectedValue.ToString();
        }
        private void spbtnChapNhanThongTinNhanSu_Click(object sender, EventArgs e)
        {
            dangkychonhanvien();
        }

        private void fmDangKyLamThem_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult ThongBao = MessageBox.Show("Bạn có muốn thoát không?",
               "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (ThongBao == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void smbtnHuyBoThongTinNhanSu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
