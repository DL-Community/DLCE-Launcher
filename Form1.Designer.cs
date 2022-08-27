namespace DLPortLauncher
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Name_Label = new System.Windows.Forms.Label();
            this.Start_Button = new System.Windows.Forms.Button();
            this.AskOpenDLPort = new System.Windows.Forms.OpenFileDialog();
            this.Title_Label = new System.Windows.Forms.Label();
            this.Port_Label = new System.Windows.Forms.Label();
            this.PathStatus_Label = new System.Windows.Forms.Label();
            this.SetPath_Button = new System.Windows.Forms.Button();
            this.Update = new System.Windows.Forms.Timer(this.components);
            this.StartOption_Group = new System.Windows.Forms.GroupBox();
            this.graphics_tier_TextBox = new System.Windows.Forms.TextBox();
            this.limit_fps_TextBox = new System.Windows.Forms.TextBox();
            this.shadow_distance_TextBox = new System.Windows.Forms.TextBox();
            this.graphics_tier_CheckBox = new System.Windows.Forms.CheckBox();
            this.limit_fps_CheckBox = new System.Windows.Forms.CheckBox();
            this.shadow_distance_CheckBox = new System.Windows.Forms.CheckBox();
            this.disable_sound_CheckBox = new System.Windows.Forms.CheckBox();
            this.disable_shadow_CheckBox = new System.Windows.Forms.CheckBox();
            this.low_resolution_box = new System.Windows.Forms.CheckBox();
            this.force_window_CheckBox = new System.Windows.Forms.CheckBox();
            this.show_fps_CheckBox = new System.Windows.Forms.CheckBox();
            this.use_soft_shadow_CheckBox = new System.Windows.Forms.CheckBox();
            this.always_show_cursor_CheckBox = new System.Windows.Forms.CheckBox();
            this.disable_discord_rpc_CheckBox = new System.Windows.Forms.CheckBox();
            this.TimeShower_Label = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.StartOption_Group.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DLPortLauncher.Properties.Resources.PortLogo;
            this.pictureBox1.Location = new System.Drawing.Point(24, 24);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(100, 100);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(100, 100);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Name_Label
            // 
            this.Name_Label.AutoSize = true;
            this.Name_Label.BackColor = System.Drawing.Color.Transparent;
            this.Name_Label.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name_Label.ForeColor = System.Drawing.Color.White;
            this.Name_Label.Location = new System.Drawing.Point(12, 563);
            this.Name_Label.Name = "Name_Label";
            this.Name_Label.Size = new System.Drawing.Size(259, 21);
            this.Name_Label.TabIndex = 1;
            this.Name_Label.Text = "Dancing Line Port Launcher V1.0";
            // 
            // Start_Button
            // 
            this.Start_Button.BackColor = System.Drawing.SystemColors.Window;
            this.Start_Button.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Start_Button.ForeColor = System.Drawing.Color.Black;
            this.Start_Button.Location = new System.Drawing.Point(858, 529);
            this.Start_Button.Name = "Start_Button";
            this.Start_Button.Size = new System.Drawing.Size(180, 55);
            this.Start_Button.TabIndex = 2;
            this.Start_Button.Text = "启动游戏";
            this.Start_Button.UseVisualStyleBackColor = false;
            this.Start_Button.Click += new System.EventHandler(this.Start_Button_Click);
            // 
            // AskOpenDLPort
            // 
            this.AskOpenDLPort.FileName = "DLport";
            // 
            // Title_Label
            // 
            this.Title_Label.AutoSize = true;
            this.Title_Label.BackColor = System.Drawing.Color.Transparent;
            this.Title_Label.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Title_Label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Title_Label.Location = new System.Drawing.Point(130, 48);
            this.Title_Label.Name = "Title_Label";
            this.Title_Label.Size = new System.Drawing.Size(189, 31);
            this.Title_Label.TabIndex = 3;
            this.Title_Label.Text = "DANCING LINE";
            // 
            // Port_Label
            // 
            this.Port_Label.AutoSize = true;
            this.Port_Label.BackColor = System.Drawing.Color.Transparent;
            this.Port_Label.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Port_Label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Port_Label.Location = new System.Drawing.Point(130, 79);
            this.Port_Label.Name = "Port_Label";
            this.Port_Label.Size = new System.Drawing.Size(104, 21);
            this.Port_Label.TabIndex = 4;
            this.Port_Label.Text = "Port Version";
            // 
            // PathStatus_Label
            // 
            this.PathStatus_Label.BackColor = System.Drawing.Color.Transparent;
            this.PathStatus_Label.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PathStatus_Label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.PathStatus_Label.Location = new System.Drawing.Point(787, 498);
            this.PathStatus_Label.Name = "PathStatus_Label";
            this.PathStatus_Label.Size = new System.Drawing.Size(229, 23);
            this.PathStatus_Label.TabIndex = 5;
            this.PathStatus_Label.Text = "尚未设置游戏路径";
            this.PathStatus_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SetPath_Button
            // 
            this.SetPath_Button.BackColor = System.Drawing.Color.Transparent;
            this.SetPath_Button.BackgroundImage = global::DLPortLauncher.Properties.Resources.编辑__1_;
            this.SetPath_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SetPath_Button.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SetPath_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SetPath_Button.Location = new System.Drawing.Point(1013, 498);
            this.SetPath_Button.Name = "SetPath_Button";
            this.SetPath_Button.Size = new System.Drawing.Size(25, 25);
            this.SetPath_Button.TabIndex = 6;
            this.SetPath_Button.UseVisualStyleBackColor = false;
            this.SetPath_Button.Click += new System.EventHandler(this.SetPath_Button_Click);
            // 
            // Update
            // 
            this.Update.Enabled = true;
            this.Update.Tick += new System.EventHandler(this.Update_Tick);
            // 
            // StartOption_Group
            // 
            this.StartOption_Group.BackColor = System.Drawing.Color.Transparent;
            this.StartOption_Group.Controls.Add(this.graphics_tier_TextBox);
            this.StartOption_Group.Controls.Add(this.limit_fps_TextBox);
            this.StartOption_Group.Controls.Add(this.shadow_distance_TextBox);
            this.StartOption_Group.Controls.Add(this.graphics_tier_CheckBox);
            this.StartOption_Group.Controls.Add(this.limit_fps_CheckBox);
            this.StartOption_Group.Controls.Add(this.shadow_distance_CheckBox);
            this.StartOption_Group.Controls.Add(this.disable_sound_CheckBox);
            this.StartOption_Group.Controls.Add(this.disable_shadow_CheckBox);
            this.StartOption_Group.Controls.Add(this.low_resolution_box);
            this.StartOption_Group.Controls.Add(this.force_window_CheckBox);
            this.StartOption_Group.Controls.Add(this.show_fps_CheckBox);
            this.StartOption_Group.Controls.Add(this.use_soft_shadow_CheckBox);
            this.StartOption_Group.Controls.Add(this.always_show_cursor_CheckBox);
            this.StartOption_Group.Controls.Add(this.disable_discord_rpc_CheckBox);
            this.StartOption_Group.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StartOption_Group.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.StartOption_Group.Location = new System.Drawing.Point(24, 130);
            this.StartOption_Group.Name = "StartOption_Group";
            this.StartOption_Group.Size = new System.Drawing.Size(424, 418);
            this.StartOption_Group.TabIndex = 7;
            this.StartOption_Group.TabStop = false;
            this.StartOption_Group.Text = "启动参数";
            // 
            // graphics_tier_TextBox
            // 
            this.graphics_tier_TextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.graphics_tier_TextBox.Location = new System.Drawing.Point(147, 371);
            this.graphics_tier_TextBox.Name = "graphics_tier_TextBox";
            this.graphics_tier_TextBox.Size = new System.Drawing.Size(100, 23);
            this.graphics_tier_TextBox.TabIndex = 13;
            // 
            // limit_fps_TextBox
            // 
            this.limit_fps_TextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.limit_fps_TextBox.Location = new System.Drawing.Point(147, 339);
            this.limit_fps_TextBox.Name = "limit_fps_TextBox";
            this.limit_fps_TextBox.Size = new System.Drawing.Size(100, 23);
            this.limit_fps_TextBox.TabIndex = 12;
            // 
            // shadow_distance_TextBox
            // 
            this.shadow_distance_TextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.shadow_distance_TextBox.Location = new System.Drawing.Point(147, 307);
            this.shadow_distance_TextBox.Name = "shadow_distance_TextBox";
            this.shadow_distance_TextBox.Size = new System.Drawing.Size(100, 23);
            this.shadow_distance_TextBox.TabIndex = 11;
            // 
            // graphics_tier_CheckBox
            // 
            this.graphics_tier_CheckBox.AutoSize = true;
            this.graphics_tier_CheckBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.graphics_tier_CheckBox.Location = new System.Drawing.Point(23, 369);
            this.graphics_tier_CheckBox.Name = "graphics_tier_CheckBox";
            this.graphics_tier_CheckBox.Size = new System.Drawing.Size(125, 26);
            this.graphics_tier_CheckBox.TabIndex = 10;
            this.graphics_tier_CheckBox.Text = "更改图像层为";
            this.graphics_tier_CheckBox.UseVisualStyleBackColor = true;
            this.graphics_tier_CheckBox.CheckedChanged += new System.EventHandler(this.graphics_tier_CheckBox_CheckedChanged);
            // 
            // limit_fps_CheckBox
            // 
            this.limit_fps_CheckBox.AutoSize = true;
            this.limit_fps_CheckBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.limit_fps_CheckBox.Location = new System.Drawing.Point(23, 337);
            this.limit_fps_CheckBox.Name = "limit_fps_CheckBox";
            this.limit_fps_CheckBox.Size = new System.Drawing.Size(125, 26);
            this.limit_fps_CheckBox.TabIndex = 9;
            this.limit_fps_CheckBox.Text = "设置帧率上限";
            this.limit_fps_CheckBox.UseVisualStyleBackColor = true;
            this.limit_fps_CheckBox.CheckedChanged += new System.EventHandler(this.limit_fps_CheckBox_CheckedChanged);
            // 
            // shadow_distance_CheckBox
            // 
            this.shadow_distance_CheckBox.AutoSize = true;
            this.shadow_distance_CheckBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.shadow_distance_CheckBox.Location = new System.Drawing.Point(23, 305);
            this.shadow_distance_CheckBox.Name = "shadow_distance_CheckBox";
            this.shadow_distance_CheckBox.Size = new System.Drawing.Size(125, 26);
            this.shadow_distance_CheckBox.TabIndex = 8;
            this.shadow_distance_CheckBox.Text = "锁定阴影距离";
            this.shadow_distance_CheckBox.UseVisualStyleBackColor = true;
            this.shadow_distance_CheckBox.CheckedChanged += new System.EventHandler(this.shadow_distance_CheckBox_CheckedChanged);
            // 
            // disable_sound_CheckBox
            // 
            this.disable_sound_CheckBox.AutoSize = true;
            this.disable_sound_CheckBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.disable_sound_CheckBox.Location = new System.Drawing.Point(23, 273);
            this.disable_sound_CheckBox.Name = "disable_sound_CheckBox";
            this.disable_sound_CheckBox.Size = new System.Drawing.Size(301, 26);
            this.disable_sound_CheckBox.TabIndex = 7;
            this.disable_sound_CheckBox.Text = "关闭游戏声音（即使设置中已经打开）";
            this.disable_sound_CheckBox.UseVisualStyleBackColor = true;
            // 
            // disable_shadow_CheckBox
            // 
            this.disable_shadow_CheckBox.AutoSize = true;
            this.disable_shadow_CheckBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.disable_shadow_CheckBox.Location = new System.Drawing.Point(23, 241);
            this.disable_shadow_CheckBox.Name = "disable_shadow_CheckBox";
            this.disable_shadow_CheckBox.Size = new System.Drawing.Size(93, 26);
            this.disable_shadow_CheckBox.TabIndex = 6;
            this.disable_shadow_CheckBox.Text = "禁用阴影";
            this.disable_shadow_CheckBox.UseVisualStyleBackColor = true;
            // 
            // low_resolution_box
            // 
            this.low_resolution_box.AutoSize = true;
            this.low_resolution_box.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.low_resolution_box.Location = new System.Drawing.Point(23, 209);
            this.low_resolution_box.Name = "low_resolution_box";
            this.low_resolution_box.Size = new System.Drawing.Size(290, 26);
            this.low_resolution_box.TabIndex = 5;
            this.low_resolution_box.Text = "强制游戏以800x600分辨率模式运行";
            this.low_resolution_box.UseVisualStyleBackColor = true;
            // 
            // force_window_CheckBox
            // 
            this.force_window_CheckBox.AutoSize = true;
            this.force_window_CheckBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.force_window_CheckBox.Location = new System.Drawing.Point(23, 177);
            this.force_window_CheckBox.Name = "force_window_CheckBox";
            this.force_window_CheckBox.Size = new System.Drawing.Size(205, 26);
            this.force_window_CheckBox.TabIndex = 4;
            this.force_window_CheckBox.Text = "强制游戏以窗口模式运行";
            this.force_window_CheckBox.UseVisualStyleBackColor = true;
            // 
            // show_fps_CheckBox
            // 
            this.show_fps_CheckBox.AutoSize = true;
            this.show_fps_CheckBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.show_fps_CheckBox.Location = new System.Drawing.Point(23, 145);
            this.show_fps_CheckBox.Name = "show_fps_CheckBox";
            this.show_fps_CheckBox.Size = new System.Drawing.Size(91, 26);
            this.show_fps_CheckBox.TabIndex = 3;
            this.show_fps_CheckBox.Text = "显示FPS";
            this.show_fps_CheckBox.UseVisualStyleBackColor = true;
            // 
            // use_soft_shadow_CheckBox
            // 
            this.use_soft_shadow_CheckBox.AutoSize = true;
            this.use_soft_shadow_CheckBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.use_soft_shadow_CheckBox.Location = new System.Drawing.Point(23, 113);
            this.use_soft_shadow_CheckBox.Name = "use_soft_shadow_CheckBox";
            this.use_soft_shadow_CheckBox.Size = new System.Drawing.Size(317, 26);
            this.use_soft_shadow_CheckBox.TabIndex = 2;
            this.use_soft_shadow_CheckBox.Text = "使用柔和阴影模式（物体阴影边缘虚化）";
            this.use_soft_shadow_CheckBox.UseVisualStyleBackColor = true;
            // 
            // always_show_cursor_CheckBox
            // 
            this.always_show_cursor_CheckBox.AutoSize = true;
            this.always_show_cursor_CheckBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.always_show_cursor_CheckBox.Location = new System.Drawing.Point(23, 81);
            this.always_show_cursor_CheckBox.Name = "always_show_cursor_CheckBox";
            this.always_show_cursor_CheckBox.Size = new System.Drawing.Size(301, 26);
            this.always_show_cursor_CheckBox.TabIndex = 1;
            this.always_show_cursor_CheckBox.Text = "关卡游玩过程中不再自动隐藏鼠标光标";
            this.always_show_cursor_CheckBox.UseVisualStyleBackColor = true;
            // 
            // disable_discord_rpc_CheckBox
            // 
            this.disable_discord_rpc_CheckBox.AutoSize = true;
            this.disable_discord_rpc_CheckBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.disable_discord_rpc_CheckBox.Location = new System.Drawing.Point(23, 49);
            this.disable_discord_rpc_CheckBox.Name = "disable_discord_rpc_CheckBox";
            this.disable_discord_rpc_CheckBox.Size = new System.Drawing.Size(162, 26);
            this.disable_discord_rpc_CheckBox.TabIndex = 0;
            this.disable_discord_rpc_CheckBox.Text = "禁用Discord RPC";
            this.disable_discord_rpc_CheckBox.UseVisualStyleBackColor = true;
            // 
            // TimeShower_Label
            // 
            this.TimeShower_Label.BackColor = System.Drawing.Color.Transparent;
            this.TimeShower_Label.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TimeShower_Label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TimeShower_Label.Location = new System.Drawing.Point(452, 563);
            this.TimeShower_Label.Name = "TimeShower_Label";
            this.TimeShower_Label.Size = new System.Drawing.Size(195, 25);
            this.TimeShower_Label.TabIndex = 8;
            this.TimeShower_Label.Text = "label1";
            this.TimeShower_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(475, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(563, 464);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "广告位招租（bushi";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::DLPortLauncher.Properties.Resources.PortBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1063, 597);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TimeShower_Label);
            this.Controls.Add(this.StartOption_Group);
            this.Controls.Add(this.SetPath_Button);
            this.Controls.Add(this.PathStatus_Label);
            this.Controls.Add(this.Port_Label);
            this.Controls.Add(this.Title_Label);
            this.Controls.Add(this.Start_Button);
            this.Controls.Add(this.Name_Label);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1079, 636);
            this.MinimumSize = new System.Drawing.Size(1079, 636);
            this.Name = "MainForm";
            this.Text = "跳舞的线移植版 启动器";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_ReSize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.StartOption_Group.ResumeLayout(false);
            this.StartOption_Group.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Label Name_Label;
        private Button Start_Button;
        private OpenFileDialog AskOpenDLPort;
        private Label Title_Label;
        private Label Port_Label;
        private Label PathStatus_Label;
        private Button SetPath_Button;
        private System.Windows.Forms.Timer Update;
        private GroupBox StartOption_Group;
        private TextBox graphics_tier_TextBox;
        private TextBox limit_fps_TextBox;
        private TextBox shadow_distance_TextBox;
        private CheckBox graphics_tier_CheckBox;
        private CheckBox limit_fps_CheckBox;
        private CheckBox shadow_distance_CheckBox;
        private CheckBox disable_sound_CheckBox;
        private CheckBox disable_shadow_CheckBox;
        private CheckBox low_resolution_box;
        private CheckBox force_window_CheckBox;
        private CheckBox show_fps_CheckBox;
        private CheckBox use_soft_shadow_CheckBox;
        private CheckBox always_show_cursor_CheckBox;
        private CheckBox disable_discord_rpc_CheckBox;
        private Label TimeShower_Label;
        private GroupBox groupBox1;
    }
}