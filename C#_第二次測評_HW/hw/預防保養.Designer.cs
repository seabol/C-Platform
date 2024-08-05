namespace N96121171_蔡尚哲_C__第二次測評
{
    partial class 預防保養
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(預防保養));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.產能效率 = new System.Windows.Forms.ToolStripButton();
            this.機台監測 = new System.Windows.Forms.ToolStripButton();
            this.電力監測 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.生產總表 = new System.Windows.Forms.ToolStripButton();
            this.使用者 = new System.Windows.Forms.ToolStripButton();
            this.設定 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.離開 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.DimGray;
            this.toolStrip1.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.產能效率,
            this.機台監測,
            this.電力監測,
            this.toolStripButton2,
            this.生產總表,
            this.使用者,
            this.設定,
            this.離開});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1052, 70);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(72, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "機台編號";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "A01",
            "A02",
            "A03",
            "B01",
            "B02",
            "C01",
            "C02",
            ""});
            this.comboBox1.Location = new System.Drawing.Point(167, 146);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView1.Location = new System.Drawing.Point(75, 195);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(723, 167);
            this.dataGridView1.TabIndex = 6;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(252, 67);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // 產能效率
            // 
            this.產能效率.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.產能效率.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.產能效率.ForeColor = System.Drawing.Color.Gold;
            this.產能效率.Image = ((System.Drawing.Image)(resources.GetObject("產能效率.Image")));
            this.產能效率.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.產能效率.Name = "產能效率";
            this.產能效率.Size = new System.Drawing.Size(78, 67);
            this.產能效率.Text = "產能效率";
            this.產能效率.Click += new System.EventHandler(this.產能效率_Click);
            // 
            // 機台監測
            // 
            this.機台監測.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.機台監測.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.機台監測.ForeColor = System.Drawing.Color.Gold;
            this.機台監測.Image = ((System.Drawing.Image)(resources.GetObject("機台監測.Image")));
            this.機台監測.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.機台監測.Name = "機台監測";
            this.機台監測.Size = new System.Drawing.Size(78, 67);
            this.機台監測.Text = "機台監測";
            this.機台監測.Click += new System.EventHandler(this.機台監測_Click);
            // 
            // 電力監測
            // 
            this.電力監測.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.電力監測.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.電力監測.ForeColor = System.Drawing.Color.Gold;
            this.電力監測.Image = ((System.Drawing.Image)(resources.GetObject("電力監測.Image")));
            this.電力監測.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.電力監測.Name = "電力監測";
            this.電力監測.Size = new System.Drawing.Size(78, 67);
            this.電力監測.Text = "電力監測";
            this.電力監測.Click += new System.EventHandler(this.電力監測_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton2.ForeColor = System.Drawing.Color.Gold;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(78, 67);
            this.toolStripButton2.Text = "預防保養";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // 生產總表
            // 
            this.生產總表.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.生產總表.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.生產總表.ForeColor = System.Drawing.Color.Gold;
            this.生產總表.Image = ((System.Drawing.Image)(resources.GetObject("生產總表.Image")));
            this.生產總表.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.生產總表.Name = "生產總表";
            this.生產總表.Size = new System.Drawing.Size(78, 67);
            this.生產總表.Text = "生產總表";
            // 
            // 使用者
            // 
            this.使用者.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.使用者.Image = ((System.Drawing.Image)(resources.GetObject("使用者.Image")));
            this.使用者.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.使用者.Name = "使用者";
            this.使用者.Size = new System.Drawing.Size(24, 67);
            this.使用者.Text = "toolStripButton2";
            // 
            // 設定
            // 
            this.設定.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.設定.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.設定.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.設定.ForeColor = System.Drawing.Color.DimGray;
            this.設定.Image = ((System.Drawing.Image)(resources.GetObject("設定.Image")));
            this.設定.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.設定.Name = "設定";
            this.設定.Size = new System.Drawing.Size(36, 67);
            this.設定.Text = "toolStripSplitButton1";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.BackColor = System.Drawing.Color.DimGray;
            this.toolStripMenuItem3.ForeColor = System.Drawing.Color.Gold;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(162, 22);
            this.toolStripMenuItem3.Text = "新增機台";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.DimGray;
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.Gold;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
            this.toolStripMenuItem1.Text = "機台保養狀況填寫";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.BackColor = System.Drawing.Color.DimGray;
            this.toolStripMenuItem2.ForeColor = System.Drawing.Color.Gold;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(162, 22);
            this.toolStripMenuItem2.Text = "產線生產細項填寫";
            // 
            // 離開
            // 
            this.離開.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.離開.Image = ((System.Drawing.Image)(resources.GetObject("離開.Image")));
            this.離開.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.離開.Name = "離開";
            this.離開.Size = new System.Drawing.Size(24, 67);
            this.離開.Text = "toolStripButton4";
            this.離開.Click += new System.EventHandler(this.離開_Click);
            // 
            // 預防保養
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1052, 521);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "預防保養";
            this.Text = "預防保養";
            this.Load += new System.EventHandler(this.預防保養_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton 產能效率;
        private System.Windows.Forms.ToolStripButton 機台監測;
        private System.Windows.Forms.ToolStripButton 電力監測;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton 生產總表;
        private System.Windows.Forms.ToolStripButton 使用者;
        public System.Windows.Forms.ToolStripSplitButton 設定;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripButton 離開;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}