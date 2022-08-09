namespace bw323DataTools
{
    partial class InfoDataFix01
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
            this.dungeonLabel2 = new ReaLTaiizor.Controls.DungeonLabel();
            this.aloneComboBox_setotherver = new ReaLTaiizor.Controls.AloneComboBox();
            this.hopeButton1 = new ReaLTaiizor.Controls.HopeButton();
            this.SuspendLayout();
            // 
            // dungeonLabel2
            // 
            this.dungeonLabel2.AutoSize = true;
            this.dungeonLabel2.BackColor = System.Drawing.Color.Transparent;
            this.dungeonLabel2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dungeonLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.dungeonLabel2.Location = new System.Drawing.Point(109, 154);
            this.dungeonLabel2.Name = "dungeonLabel2";
            this.dungeonLabel2.Size = new System.Drawing.Size(153, 20);
            this.dungeonLabel2.TabIndex = 2;
            this.dungeonLabel2.Text = "其它厂家软件版本：";
            // 
            // aloneComboBox_setotherver
            // 
            this.aloneComboBox_setotherver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aloneComboBox_setotherver.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.aloneComboBox_setotherver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.aloneComboBox_setotherver.EnabledCalc = true;
            this.aloneComboBox_setotherver.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.aloneComboBox_setotherver.FormattingEnabled = true;
            this.aloneComboBox_setotherver.ItemHeight = 20;
            this.aloneComboBox_setotherver.Items.AddRange(new object[] {
            "思迅商云系列"});
            this.aloneComboBox_setotherver.Location = new System.Drawing.Point(268, 152);
            this.aloneComboBox_setotherver.Name = "aloneComboBox_setotherver";
            this.aloneComboBox_setotherver.Size = new System.Drawing.Size(278, 26);
            this.aloneComboBox_setotherver.TabIndex = 33;
            // 
            // hopeButton1
            // 
            this.hopeButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.hopeButton1.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.hopeButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hopeButton1.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.hopeButton1.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.hopeButton1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.hopeButton1.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.hopeButton1.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.hopeButton1.Location = new System.Drawing.Point(251, 268);
            this.hopeButton1.Name = "hopeButton1";
            this.hopeButton1.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.hopeButton1.Size = new System.Drawing.Size(120, 40);
            this.hopeButton1.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.hopeButton1.TabIndex = 34;
            this.hopeButton1.Text = "开始修复";
            this.hopeButton1.TextColor = System.Drawing.Color.White;
            this.hopeButton1.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.hopeButton1.Click += new System.EventHandler(this.hopeButton1_Click);
            // 
            // InfoDataFix01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 450);
            this.Controls.Add(this.hopeButton1);
            this.Controls.Add(this.aloneComboBox_setotherver);
            this.Controls.Add(this.dungeonLabel2);
            this.Name = "InfoDataFix01";
            this.Text = "数据修复";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InfoDataFix01_FormClosed);
            this.Load += new System.EventHandler(this.InfoDataFix01_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel2;
        private ReaLTaiizor.Controls.AloneComboBox aloneComboBox_setotherver;
        private ReaLTaiizor.Controls.HopeButton hopeButton1;
    }
}