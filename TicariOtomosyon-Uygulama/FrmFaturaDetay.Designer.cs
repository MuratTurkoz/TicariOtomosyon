namespace TicariOtomosyon_Uygulama
{
    partial class FrmFaturaDetay
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
            this.groupControl6 = new DevExpress.XtraEditors.GroupControl();
            this.lblTutar = new System.Windows.Forms.Label();
            this.cmbUrunAd = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblDeneme = new System.Windows.Forms.Label();
            this.btnGuncelle1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnSil1 = new DevExpress.XtraEditors.SimpleButton();
            this.txtFiyat = new DevExpress.XtraEditors.TextEdit();
            this.txtMiktar = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gridControl12 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).BeginInit();
            this.groupControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUrunAd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFiyat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMiktar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl6
            // 
            this.groupControl6.Controls.Add(this.lblTutar);
            this.groupControl6.Controls.Add(this.cmbUrunAd);
            this.groupControl6.Controls.Add(this.lblDeneme);
            this.groupControl6.Controls.Add(this.btnGuncelle1);
            this.groupControl6.Controls.Add(this.btnKaydet1);
            this.groupControl6.Controls.Add(this.btnSil1);
            this.groupControl6.Controls.Add(this.txtFiyat);
            this.groupControl6.Controls.Add(this.txtMiktar);
            this.groupControl6.Controls.Add(this.label1);
            this.groupControl6.Controls.Add(this.label10);
            this.groupControl6.Controls.Add(this.label9);
            this.groupControl6.Controls.Add(this.label5);
            this.groupControl6.Location = new System.Drawing.Point(488, 12);
            this.groupControl6.Name = "groupControl6";
            this.groupControl6.ShowCaption = false;
            this.groupControl6.Size = new System.Drawing.Size(300, 413);
            this.groupControl6.TabIndex = 2;
            this.groupControl6.Text = "groupControl6";
            // 
            // lblTutar
            // 
            this.lblTutar.AutoSize = true;
            this.lblTutar.Location = new System.Drawing.Point(130, 200);
            this.lblTutar.Name = "lblTutar";
            this.lblTutar.Size = new System.Drawing.Size(29, 13);
            this.lblTutar.TabIndex = 38;
            this.lblTutar.Text = "0.00";
            // 
            // cmbUrunAd
            // 
            this.cmbUrunAd.Location = new System.Drawing.Point(120, 62);
            this.cmbUrunAd.Name = "cmbUrunAd";
            this.cmbUrunAd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbUrunAd.Size = new System.Drawing.Size(132, 20);
            this.cmbUrunAd.TabIndex = 37;
            // 
            // lblDeneme
            // 
            this.lblDeneme.AutoSize = true;
            this.lblDeneme.Location = new System.Drawing.Point(41, 81);
            this.lblDeneme.Name = "lblDeneme";
            this.lblDeneme.Size = new System.Drawing.Size(0, 13);
            this.lblDeneme.TabIndex = 36;
            // 
            // btnGuncelle1
            // 
            this.btnGuncelle1.ImageOptions.Image = global::TicariOtomosyon_Uygulama.Properties.Resources.refreshallpivottable_32x32;
            this.btnGuncelle1.Location = new System.Drawing.Point(207, 323);
            this.btnGuncelle1.Name = "btnGuncelle1";
            this.btnGuncelle1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnGuncelle1.Size = new System.Drawing.Size(81, 46);
            this.btnGuncelle1.TabIndex = 35;
            this.btnGuncelle1.Text = "Güncelle";
            this.btnGuncelle1.Click += new System.EventHandler(this.btnGuncelle1_Click);
            // 
            // btnKaydet1
            // 
            this.btnKaydet1.ImageOptions.Image = global::TicariOtomosyon_Uygulama.Properties.Resources.saveall_32x32;
            this.btnKaydet1.Location = new System.Drawing.Point(24, 323);
            this.btnKaydet1.Name = "btnKaydet1";
            this.btnKaydet1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnKaydet1.Size = new System.Drawing.Size(75, 46);
            this.btnKaydet1.TabIndex = 33;
            this.btnKaydet1.Text = "Kaydet";
            this.btnKaydet1.Click += new System.EventHandler(this.btnKaydet1_Click);
            // 
            // btnSil1
            // 
            this.btnSil1.ImageOptions.SvgImage = global::TicariOtomosyon_Uygulama.Properties.Resources.delete;
            this.btnSil1.Location = new System.Drawing.Point(120, 323);
            this.btnSil1.Name = "btnSil1";
            this.btnSil1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnSil1.Size = new System.Drawing.Size(69, 46);
            this.btnSil1.TabIndex = 34;
            this.btnSil1.Text = "Sil";
            this.btnSil1.Click += new System.EventHandler(this.btnSil1_Click);
            // 
            // txtFiyat
            // 
            this.txtFiyat.Location = new System.Drawing.Point(120, 152);
            this.txtFiyat.Name = "txtFiyat";
            this.txtFiyat.Size = new System.Drawing.Size(132, 20);
            this.txtFiyat.TabIndex = 30;
            // 
            // txtMiktar
            // 
            this.txtMiktar.Location = new System.Drawing.Point(120, 108);
            this.txtMiktar.Name = "txtMiktar";
            this.txtMiktar.Size = new System.Drawing.Size(132, 20);
            this.txtMiktar.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Miktar:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(41, 159);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Fiyat :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(41, 200);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Tutar :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Ürün Ad :";
            // 
            // gridControl12
            // 
            this.gridControl12.Location = new System.Drawing.Point(36, 25);
            this.gridControl12.MainView = this.gridView1;
            this.gridControl12.Name = "gridControl12";
            this.gridControl12.Size = new System.Drawing.Size(400, 400);
            this.gridControl12.TabIndex = 3;
            this.gridControl12.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl12;
            this.gridView1.Name = "gridView1";
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged_1);
            // 
            // FrmFaturaDetay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridControl12);
            this.Controls.Add(this.groupControl6);
            this.Name = "FrmFaturaDetay";
            this.Text = "FrmFaturaDetay";
            this.Load += new System.EventHandler(this.FrmFaturaDetay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).EndInit();
            this.groupControl6.ResumeLayout(false);
            this.groupControl6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUrunAd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFiyat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMiktar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl6;
        private DevExpress.XtraEditors.TextEdit txtFiyat;
        private DevExpress.XtraEditors.TextEdit txtMiktar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.SimpleButton btnGuncelle1;
        private DevExpress.XtraEditors.SimpleButton btnKaydet1;
        private DevExpress.XtraEditors.SimpleButton btnSil1;
        private System.Windows.Forms.Label lblDeneme;
        private DevExpress.XtraEditors.ComboBoxEdit cmbUrunAd;
        private System.Windows.Forms.Label lblTutar;
        private DevExpress.XtraGrid.GridControl gridControl12;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}