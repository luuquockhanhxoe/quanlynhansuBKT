using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail; //để gửi mail
using System.Net;//để gửi mail
using System.IO;//đọc file
using System.Threading; //text, xử lý đa luồng
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//https://www.google.com/settings/u/1/security/lesssecureapps
namespace DoAnNhanSuBanChuan.HoSo.ThongTin
{
    public partial class fmGuiGmail : Form
    {
        Attachment attach = null;
        public fmGuiGmail(string gmail) :this()
        {
            txtDen.Text = gmail;
        }

        public fmGuiGmail()
        {
            InitializeComponent();
        }

        void GuiMail(string tudau, string toidau, string chude, string thuviet, Attachment file = null)
        {
            MailMessage mess = new MailMessage(tudau, toidau, chude, thuviet); //cần gửi thông điệp gì.

            if(attach != null)
            {
                mess.Attachments.Add(attach);
            }
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //giúp phần mềm gửi mail.
            client.EnableSsl = true; 

            client.Credentials = new NetworkCredential(txtTenDangNhap.Text, txtMatKhau.Text);
            client.Send(mess); //gửi mail đi.

        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            ////de khong bi do
            Thread thread = new Thread(() =>
            {
                attach = null;
                try
                {
                    FileInfo file = new FileInfo(txtFileKem.Text);
                    attach = new Attachment(txtFileKem.Text);
                }
                catch { }
                GuiMail(txtTenDangNhap.Text, txtDen.Text, txtNoiDung.Text, txtMessage.Text, attach);
                MessageBox.Show("Đã gửi mail cho nhân viên!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                    );
            thread.Start();
        }



        private void btnKemFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if(dialog.ShowDialog()== DialogResult.OK)
            {
                txtFileKem.Text = dialog.FileName;
            }
        }

        private void cbHien_CheckedChanged(object sender, EventArgs e)
        {
            if(cbHien.Checked == true)
            {
                txtMatKhau.UseSystemPasswordChar = false;
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
    }
}
