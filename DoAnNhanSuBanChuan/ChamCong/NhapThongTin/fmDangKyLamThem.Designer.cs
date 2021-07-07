namespace DoAnNhanSuBanChuan.ChamCong.NhapThongTin
{
    partial class fmDangKyLamThem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmDangKyLamThem));
            this.smbtnHuyBoThongTinNhanSu = new DevExpress.XtraEditors.SimpleButton();
            this.spbtnChapNhanThongTinNhanSu = new DevExpress.XtraEditors.SimpleButton();
            this.cbSoGioDangKy = new System.Windows.Forms.ComboBox();
            this.dtpThoiGian = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMaNV = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // smbtnHuyBoThongTinNhanSu
            // 
            this.smbtnHuyBoThongTinNhanSu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("smbtnHuyBoThongTinNhanSu.ImageOptions.Image")));
            this.smbtnHuyBoThongTinNhanSu.Location = new System.Drawing.Point(193, 141);
            this.smbtnHuyBoThongTinNhanSu.Name = "smbtnHuyBoThongTinNhanSu";
            this.smbtnHuyBoThongTinNhanSu.Size = new System.Drawing.Size(79, 38);
            this.smbtnHuyBoThongTinNhanSu.TabIndex = 139;
            this.smbtnHuyBoThongTinNhanSu.Text = "Thoát";
            this.smbtnHuyBoThongTinNhanSu.Click += new System.EventHandler(this.smbtnHuyBoThongTinNhanSu_Click);
            // 
            // spbtnChapNhanThongTinNhanSu
            // 
            this.spbtnChapNhanThongTinNhanSu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("spbtnChapNhanThongTinNhanSu.ImageOptions.Image")));
            this.spbtnChapNhanThongTinNhanSu.Location = new System.Drawing.Point(108, 141);
            this.spbtnChapNhanThongTinNhanSu.Name = "spbtnChapNhanThongTinNhanSu";
            this.spbtnChapNhanThongTinNhanSu.Size = new System.Drawing.Size(79, 38);
            this.spbtnChapNhanThongTinNhanSu.TabIndex = 138;
            this.spbtnChapNhanThongTinNhanSu.Text = "Đồng ý";
            this.spbtnChapNhanThongTinNhanSu.Click += new System.EventHandler(this.spbtnChapNhanThongTinNhanSu_Click);
            // 
            // cbSoGioDangKy
            // 
            this.cbSoGioDangKy.FormattingEnabled = true;
            this.cbSoGioDangKy.Items.AddRange(new object[] {
            "0.5",
            "1",
            "1.5",
            "2",
            "2.5",
            "3"});
            this.cbSoGioDangKy.Location = new System.Drawing.Point(105, 103);
            this.cbSoGioDangKy.Name = "cbSoGioDangKy";
            this.cbSoGioDangKy.Size = new System.Drawing.Size(100, 21);
            this.cbSoGioDangKy.TabIndex = 137;
            // 
            // dtpThoiGian
            // 
            this.dtpThoiGian.CustomFormat = "dd/MM/yyyy";
            this.dtpThoiGian.Enabled = false;
            this.dtpThoiGian.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpThoiGian.Location = new System.Drawing.Point(105, 77);
            this.dtpThoiGian.Name = "dtpThoiGian";
            this.dtpThoiGian.Size = new System.Drawing.Size(100, 20);
            this.dtpThoiGian.TabIndex = 136;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(9, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 135;
            this.label4.Text = "Ngày đăng ký:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(9, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 134;
            this.label3.Text = "Số giờ đăng ký:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(105, 47);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(167, 20);
            this.txtHoTen.TabIndex = 133;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(9, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 132;
            this.label2.Text = "Họ và tên:";
            // 
            // cbMaNV
            // 
            this.cbMaNV.FormattingEnabled = true;
            this.cbMaNV.Location = new System.Drawing.Point(105, 16);
            this.cbMaNV.Name = "cbMaNV";
            this.cbMaNV.Size = new System.Drawing.Size(100, 21);
            this.cbMaNV.TabIndex = 131;
            this.cbMaNV.SelectedIndexChanged += new System.EventHandler(this.cbMaNV_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(9, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 130;
            this.label1.Text = "Mã nhân viên:";
            // 
            // fmDangKyLamThem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(285, 185);
            this.Controls.Add(this.smbtnHuyBoThongTinNhanSu);
            this.Controls.Add(this.spbtnChapNhanThongTinNhanSu);
            this.Controls.Add(this.cbSoGioDangKy);
            this.Controls.Add(this.dtpThoiGian);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbMaNV);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmDangKyLamThem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký làm thêm giờ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fmDangKyLamThem_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton smbtnHuyBoThongTinNhanSu;
        private DevExpress.XtraEditors.SimpleButton spbtnChapNhanThongTinNhanSu;
        private System.Windows.Forms.ComboBox cbSoGioDangKy;
        private System.Windows.Forms.DateTimePicker dtpThoiGian;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMaNV;
        private System.Windows.Forms.Label label1;
    }
}