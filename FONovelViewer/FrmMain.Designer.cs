
namespace FONovelViewer
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.lbchapters = new System.Windows.Forms.ListBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.tbContent = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbchapters
            // 
            this.lbchapters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(232)))), ((int)(((byte)(207)))));
            this.lbchapters.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbchapters.FormattingEnabled = true;
            this.lbchapters.ItemHeight = 18;
            this.lbchapters.Location = new System.Drawing.Point(0, 0);
            this.lbchapters.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbchapters.Name = "lbchapters";
            this.lbchapters.Size = new System.Drawing.Size(238, 1292);
            this.lbchapters.TabIndex = 3;
            this.lbchapters.SelectedIndexChanged += new System.EventHandler(this.lbchapters_SelectedIndexChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(238, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(15, 1292);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.btnPre);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(253, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(923, 75);
            this.panel1.TabIndex = 5;
            this.panel1.Click += new System.EventHandler(this.Panel1_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLoad.Location = new System.Drawing.Point(10, 18);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(123, 45);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "加载";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.TsmOpen_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNext.Location = new System.Drawing.Point(478, 18);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(123, 45);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "下一篇";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // btnPre
            // 
            this.btnPre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPre.Location = new System.Drawing.Point(322, 18);
            this.btnPre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(123, 45);
            this.btnPre.TabIndex = 0;
            this.btnPre.Text = "上一篇";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.BtnPre_Click);
            // 
            // tbContent
            // 
            this.tbContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(232)))), ((int)(((byte)(207)))));
            this.tbContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbContent.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbContent.Location = new System.Drawing.Point(253, 75);
            this.tbContent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbContent.Name = "tbContent";
            this.tbContent.ReadOnly = true;
            this.tbContent.Size = new System.Drawing.Size(923, 1217);
            this.tbContent.TabIndex = 6;
            this.tbContent.Text = "";
            this.tbContent.Click += new System.EventHandler(this.TbContent_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 1292);
            this.Controls.Add(this.tbContent);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.lbchapters);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmMain";
            this.Text = "阅读器";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox lbchapters;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.RichTextBox tbContent;
        private System.Windows.Forms.Button btnLoad;
    }
}

