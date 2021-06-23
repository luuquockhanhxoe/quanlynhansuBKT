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

namespace DoAnNhanSuBanChuan.TongQuan.DongThoiGian
{
    public partial class ucSinhNhatNhanVien : UserControl
    {
        Data_Access sinhnhat = new Data_Access();
        public ucSinhNhatNhanVien()
        {
            InitializeComponent();
            hienthisinhnhat();
        }
        public void hienthisinhnhat()
        {
            DataTable hienthisinhnhatnhanvien = sinhnhat.CreateTable("SELECT * FROM NHANVIEN WHERE (MONTH(GETDATE()) - MONTH(NgaySinh)) = 0");
            gcSinhNhatNhanVien.DataSource = hienthisinhnhatnhanvien;
        }
    }
}
