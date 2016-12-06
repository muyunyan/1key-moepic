namespace _1KeyMoePic
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_refresh = new System.Windows.Forms.Button();
            this.pbx_main = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_toWallpaper = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.label_progress = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_main)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(0, 337);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(521, 23);
            this.btn_refresh.TabIndex = 0;
            this.btn_refresh.Text = "再来一张";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // pbx_main
            // 
            this.pbx_main.Location = new System.Drawing.Point(0, 38);
            this.pbx_main.Name = "pbx_main";
            this.pbx_main.Size = new System.Drawing.Size(521, 293);
            this.pbx_main.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx_main.TabIndex = 1;
            this.pbx_main.TabStop = false;
            this.pbx_main.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.pbx_main_LoadCompleted);
            this.pbx_main.LoadProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.pbx_main_LoadProgressChanged);
            this.pbx_main.Click += new System.EventHandler(this.pbx_main_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(192, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "点击图片放大预览";
            // 
            // btn_toWallpaper
            // 
            this.btn_toWallpaper.Location = new System.Drawing.Point(0, 366);
            this.btn_toWallpaper.Name = "btn_toWallpaper";
            this.btn_toWallpaper.Size = new System.Drawing.Size(521, 43);
            this.btn_toWallpaper.TabIndex = 3;
            this.btn_toWallpaper.Text = "设为壁纸";
            this.btn_toWallpaper.UseVisualStyleBackColor = true;
            this.btn_toWallpaper.Click += new System.EventHandler(this.btn_toWallpaper_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(0, 415);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(521, 23);
            this.btn_save.TabIndex = 4;
            this.btn_save.Text = "存到本地";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label_progress
            // 
            this.label_progress.AutoSize = true;
            this.label_progress.Location = new System.Drawing.Point(243, 183);
            this.label_progress.Name = "label_progress";
            this.label_progress.Size = new System.Drawing.Size(0, 12);
            this.label_progress.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 445);
            this.Controls.Add(this.label_progress);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_toWallpaper);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbx_main);
            this.Controls.Add(this.btn_refresh);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 361);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "一键萌图";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_main)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.PictureBox pbx_main;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_toWallpaper;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label label_progress;
    }
}

