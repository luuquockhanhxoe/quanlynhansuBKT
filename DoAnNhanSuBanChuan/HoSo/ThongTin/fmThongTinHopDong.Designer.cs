namespace DoAnNhanSuBanChuan.HoSo.ThongTin
{
    partial class fmThongTinHopDong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmThongTinHopDong));
            this.dtpNgayKy = new System.Windows.Forms.DateTimePicker();
            this.txtSoLaoDong = new System.Windows.Forms.TextBox();
            this.cbLoaiHD = new System.Windows.Forms.ComboBox();
            this.cbBacLuong = new System.Windows.Forms.ComboBox();
            this.cbHeSoLuong = new System.Windows.Forms.ComboBox();
            this.smbtnHuyBoThongTinHopDong = new DevExpress.XtraEditors.SimpleButton();
            this.smbtnChapNhanThongTinNhanSu = new DevExpress.XtraEditors.SimpleButton();
            this.lbthang = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbThoiHan = new System.Windows.Forms.ComboBox();
            this.cbMaNV = new System.Windows.Forms.ComboBox();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.cbHinhThucTraLuong = new System.Windows.Forms.ComboBox();
            this.cbCheDoLamViec = new System.Windows.Forms.ComboBox();
            this.spbtnLamMoi = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpNgayKy
            // 
            this.dtpNgayKy.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayKy.Location = new System.Drawing.Point(108, 89);
            this.dtpNgayKy.Name = "dtpNgayKy";
            this.dtpNgayKy.Size = new System.Drawing.Size(163, 20);
            this.dtpNgayKy.TabIndex = 182;
            this.dtpNgayKy.Value = new System.DateTime(2021, 5, 4, 17, 23, 19, 0);
            // 
            // txtSoLaoDong
            // 
            this.txtSoLaoDong.Location = new System.Drawing.Point(408, 142);
            this.txtSoLaoDong.Multiline = true;
            this.txtSoLaoDong.Name = "txtSoLaoDong";
            this.txtSoLaoDong.Size = new System.Drawing.Size(163, 21);
            this.txtSoLaoDong.TabIndex = 143;
            this.txtSoLaoDong.Text = "Không Có";
            // 
            // cbLoaiHD
            // 
            this.cbLoaiHD.FormattingEnabled = true;
            this.cbLoaiHD.Items.AddRange(new object[] {
            "HĐLĐ Không xác định thời hạn",
            "HĐLĐ Xác định thời hạn"});
            this.cbLoaiHD.Location = new System.Drawing.Point(108, 115);
            this.cbLoaiHD.Name = "cbLoaiHD";
            this.cbLoaiHD.Size = new System.Drawing.Size(163, 21);
            this.cbLoaiHD.TabIndex = 190;
            this.cbLoaiHD.SelectedIndexChanged += new System.EventHandler(this.cbLoaiHD_SelectedIndexChanged);
            // 
            // cbBacLuong
            // 
            this.cbBacLuong.FormattingEnabled = true;
            this.cbBacLuong.Location = new System.Drawing.Point(408, 30);
            this.cbBacLuong.Name = "cbBacLuong";
            this.cbBacLuong.Size = new System.Drawing.Size(163, 21);
            this.cbBacLuong.TabIndex = 195;
            // 
            // cbHeSoLuong
            // 
            this.cbHeSoLuong.FormattingEnabled = true;
            this.cbHeSoLuong.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cbHeSoLuong.Location = new System.Drawing.Point(408, 57);
            this.cbHeSoLuong.Name = "cbHeSoLuong";
            this.cbHeSoLuong.Size = new System.Drawing.Size(163, 21);
            this.cbHeSoLuong.TabIndex = 197;
            // 
            // smbtnHuyBoThongTinHopDong
            // 
            this.smbtnHuyBoThongTinHopDong.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("smbtnHuyBoThongTinHopDong.ImageOptions.Image")));
            this.smbtnHuyBoThongTinHopDong.Location = new System.Drawing.Point(422, 204);
            this.smbtnHuyBoThongTinHopDong.Name = "smbtnHuyBoThongTinHopDong";
            this.smbtnHuyBoThongTinHopDong.Size = new System.Drawing.Size(80, 38);
            this.smbtnHuyBoThongTinHopDong.TabIndex = 227;
            this.smbtnHuyBoThongTinHopDong.Text = "Hủy bỏ";
            this.smbtnHuyBoThongTinHopDong.Click += new System.EventHandler(this.smbtnHuyBoThongTinHopDong_Click);
            // 
            // smbtnChapNhanThongTinNhanSu
            // 
            this.smbtnChapNhanThongTinNhanSu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("smbtnChapNhanThongTinNhanSu.ImageOptions.Image")));
            this.smbtnChapNhanThongTinNhanSu.Location = new System.Drawing.Point(336, 204);
            this.smbtnChapNhanThongTinNhanSu.Name = "smbtnChapNhanThongTinNhanSu";
            this.smbtnChapNhanThongTinNhanSu.Size = new System.Drawing.Size(80, 38);
            this.smbtnChapNhanThongTinNhanSu.TabIndex = 226;
            this.smbtnChapNhanThongTinNhanSu.Text = "Đồng ý";
            this.smbtnChapNhanThongTinNhanSu.Click += new System.EventHandler(this.smbtnChapNhanThongTinNhanSu_Click);
            // 
            // lbthang
            // 
            this.lbthang.AutoSize = true;
            this.lbthang.Location = new System.Drawing.Point(214, 150);
            this.lbthang.Name = "lbthang";
            this.lbthang.Size = new System.Drawing.Size(45, 13);
            this.lbthang.TabIndex = 229;
            this.lbthang.Text = "THÁNG";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(304, 123);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(97, 13);
            this.label18.TabIndex = 240;
            this.label18.Text = "Hình thức trả lương";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(304, 95);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(84, 13);
            this.label17.TabIndex = 239;
            this.label17.Text = "Chế độ làm việc";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(304, 65);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 13);
            this.label14.TabIndex = 238;
            this.label14.Text = "Hệ số lương";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(304, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 237;
            this.label6.Text = "Bậc lương";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(304, 150);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 236;
            this.label10.Text = "Sổ lao động";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 150);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 235;
            this.label11.Text = "Thời hạn";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 234;
            this.label4.Text = "Loại hợp đồng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 233;
            this.label3.Text = "Ngày ký";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 232;
            this.label2.Text = "Mã hợp đồng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 231;
            this.label1.Text = "Mã nhân viên";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbThoiHan);
            this.groupBox2.Controls.Add(this.cbMaNV);
            this.groupBox2.Controls.Add(this.txtMaHD);
            this.groupBox2.Controls.Add(this.cbHinhThucTraLuong);
            this.groupBox2.Controls.Add(this.cbCheDoLamViec);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.lbthang);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbHeSoLuong);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.cbBacLuong);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtSoLaoDong);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cbLoaiHD);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.dtpNgayKy);
            this.groupBox2.Location = new System.Drawing.Point(15, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(586, 186);
            this.groupBox2.TabIndex = 241;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "THÔNG TIN HỢP ĐỒNG";
            // 
            // cbThoiHan
            // 
            this.cbThoiHan.FormattingEnabled = true;
            this.cbThoiHan.Items.AddRange(new object[] {
            "3",
            "6",
            "9",
            "12",
            "15",
            "18",
            "21",
            "24",
            "27",
            "30",
            "33",
            "36"});
            this.cbThoiHan.Location = new System.Drawing.Point(108, 142);
            this.cbThoiHan.Name = "cbThoiHan";
            this.cbThoiHan.Size = new System.Drawing.Size(100, 21);
            this.cbThoiHan.TabIndex = 245;
            this.cbThoiHan.SelectedIndexChanged += new System.EventHandler(this.cbLoaiHD_SelectedIndexChanged);
            // 
            // cbMaNV
            // 
            this.cbMaNV.FormattingEnabled = true;
            this.cbMaNV.Location = new System.Drawing.Point(108, 57);
            this.cbMaNV.Name = "cbMaNV";
            this.cbMaNV.Size = new System.Drawing.Size(163, 21);
            this.cbMaNV.TabIndex = 244;
            // 
            // txtMaHD
            // 
            this.txtMaHD.Location = new System.Drawing.Point(108, 30);
            this.txtMaHD.Multiline = true;
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.Size = new System.Drawing.Size(163, 21);
            this.txtMaHD.TabIndex = 243;
            // 
            // cbHinhThucTraLuong
            // 
            this.cbHinhThucTraLuong.FormattingEnabled = true;
            this.cbHinhThucTraLuong.Items.AddRange(new object[] {
            "Chuyển Khoản",
            "Tiền Mặt"});
            this.cbHinhThucTraLuong.Location = new System.Drawing.Point(408, 115);
            this.cbHinhThucTraLuong.Name = "cbHinhThucTraLuong";
            this.cbHinhThucTraLuong.Size = new System.Drawing.Size(163, 21);
            this.cbHinhThucTraLuong.TabIndex = 242;
            // 
            // cbCheDoLamViec
            // 
            this.cbCheDoLamViec.FormattingEnabled = true;
            this.cbCheDoLamViec.Items.AddRange(new object[] {
            "Hành Chính",
            "Làm Ca",
            "Làm Kíp",
            "Làm Partime"});
            this.cbCheDoLamViec.Location = new System.Drawing.Point(408, 87);
            this.cbCheDoLamViec.Name = "cbCheDoLamViec";
            this.cbCheDoLamViec.Size = new System.Drawing.Size(163, 21);
            this.cbCheDoLamViec.TabIndex = 241;
            // 
            // spbtnLamMoi
            // 
            this.spbtnLamMoi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("spbtnLamMoi.ImageOptions.Image")));
            this.spbtnLamMoi.Location = new System.Drawing.Point(508, 204);
            this.spbtnLamMoi.Name = "spbtnLamMoi";
            this.spbtnLamMoi.Size = new System.Drawing.Size(93, 38);
            this.spbtnLamMoi.TabIndex = 242;
            this.spbtnLamMoi.Text = "Làm mới";
            this.spbtnLamMoi.Click += new System.EventHandler(this.spbtnLamMoi_Click);
            // 
            // fmThongTinHopDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 248);
            this.Controls.Add(this.spbtnLamMoi);
            this.Controls.Add(this.smbtnHuyBoThongTinHopDong);
            this.Controls.Add(this.smbtnChapNhanThongTinNhanSu);
            this.Controls.Add(this.groupBox2);
            this.Name = "fmThongTinHopDong";
            this.Load += new System.EventHandler(this.fmThongTinHopDong_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpNgayKy;
        private System.Windows.Forms.TextBox txtSoLaoDong;
        private System.Windows.Forms.ComboBox cbLoaiHD;
        private System.Windows.Forms.ComboBox cbBacLuong;
        private System.Windows.Forms.ComboBox cbHeSoLuong;
        private DevExpress.XtraEditors.SimpleButton smbtnHuyBoThongTinHopDong;
        private DevExpress.XtraEditors.SimpleButton smbtnChapNhanThongTinNhanSu;
        private System.Windows.Forms.Label lbthang;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbHinhThucTraLuong;
        private System.Windows.Forms.ComboBox cbCheDoLamViec;
        private System.Windows.Forms.ComboBox cbMaNV;
        private System.Windows.Forms.TextBox txtMaHD;
        private DevExpress.XtraEditors.SimpleButton spbtnLamMoi;
        private System.Windows.Forms.ComboBox cbThoiHan;
    }
}