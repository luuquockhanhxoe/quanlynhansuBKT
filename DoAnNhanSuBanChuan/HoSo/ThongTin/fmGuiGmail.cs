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
using DoAnNhanSuBanChuan.DataAccess;
//https://www.google.com/settings/u/1/security/lesssecureapps
namespace DoAnNhanSuBanChuan.HoSo.ThongTin
{
    public partial class fmGuiGmail : Form
    {
        Data_Access guimailnv = new Data_Access();
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
            if (txtTenDangNhap.Text.Length == 0 || txtMatKhau.Text.Length == 0)
            {
                MessageBox.Show("Yêu cầu đăng nhập!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(txtDen.Text.Length == 0)
            {
                MessageBox.Show("Yêu cầu điền gmail người nhận!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtNoiDung.Text.Length == 0)
            {
                MessageBox.Show("Yêu cầu thêm chủ đề vào Gmail!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtMessage.Text.Length == 0)
            {
                MessageBox.Show("Thư trống, vui lòng thêm thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {////de khong bi do
                Thread thread = new Thread(() =>
                {
                    attach = null;
                    try
                    {
                        FileInfo file = new FileInfo(txtFileKem.Text);
                        attach = new Attachment(txtFileKem.Text);
                    }
                    catch { }
                    for (int i = 0; i< (txtDen.Lines.Length)-1; i++)                  
                    {
                        GuiMail(txtTenDangNhap.Text, txtDen.Lines[i], txtNoiDung.Text, txtMessage.Text, attach);
                    }
                    MessageBox.Show("Đã gửi mail cho nhân viên!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                           );
                thread.Start();
            }
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
            if (cbHien.Checked == true)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
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

        private void cbGuiToanBo_CheckedChanged(object sender, EventArgs e)
        {
            if(cbGuiToanBo.Checked == true)
            {
                txtDen.Clear();
                DataTable danhsachgmail = guimailnv.CreateTable("SELECT Gmail FROM NHANVIEN");
                for (int i = 0; i < danhsachgmail.Rows.Count; i++)
                {
                    txtDen.Text += danhsachgmail.Rows[i]["Gmail"].ToString() + "\n";                    
                }
            }
            else
            {
                txtDen.Clear();
            }
        }
    }
}
