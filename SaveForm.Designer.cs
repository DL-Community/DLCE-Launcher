namespace DLCELauncher
{
    partial class SaveForm
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
            ExportButton = new Button();
            ImportButton = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // ExportButton
            // 
            ExportButton.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            ExportButton.Location = new Point(16, 90);
            ExportButton.Name = "ExportButton";
            ExportButton.Size = new Size(180, 72);
            ExportButton.TabIndex = 0;
            ExportButton.Text = "导出存档";
            ExportButton.UseVisualStyleBackColor = true;
            ExportButton.Click += ExportButton_Click;
            // 
            // ImportButton
            // 
            ImportButton.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            ImportButton.Location = new Point(16, 12);
            ImportButton.Name = "ImportButton";
            ImportButton.Size = new Size(180, 72);
            ImportButton.TabIndex = 1;
            ImportButton.Text = "导入存档";
            ImportButton.UseVisualStyleBackColor = true;
            ImportButton.Click += ImportButton_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(16, 165);
            label1.Name = "label1";
            label1.Size = new Size(180, 127);
            label1.TabIndex = 2;
            label1.Text = "本存档管理功能所建立的存档仅限于当前设备使用";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SaveForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(208, 295);
            Controls.Add(label1);
            Controls.Add(ImportButton);
            Controls.Add(ExportButton);
            MaximumSize = new Size(224, 334);
            MinimumSize = new Size(224, 334);
            Name = "SaveForm";
            Text = "存档管理";
            ResumeLayout(false);
        }

        #endregion

        private Button ExportButton;
        private Button ImportButton;
        private Label label1;
    }
}