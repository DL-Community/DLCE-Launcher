namespace DLCELauncher
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            pictureBox1 = new PictureBox();
            Name_Label = new Label();
            Start_Button = new Button();
            AskOpenDLPort = new OpenFileDialog();
            Title_Label = new Label();
            Port_Label = new Label();
            PathStatus_Label = new Label();
            SetPath_Button = new Button();
            Update = new System.Windows.Forms.Timer(components);
            StartOption_Group = new GroupBox();
            pictureBox5 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            graphics_tier_TextBox = new TextBox();
            limit_fps_TextBox = new TextBox();
            shadow_distance_TextBox = new TextBox();
            graphics_tier_CheckBox = new CheckBox();
            limit_fps_CheckBox = new CheckBox();
            shadow_distance_CheckBox = new CheckBox();
            disable_sound_CheckBox = new CheckBox();
            disable_shadow_CheckBox = new CheckBox();
            low_resolution_box = new CheckBox();
            force_window_CheckBox = new CheckBox();
            show_fps_CheckBox = new CheckBox();
            use_soft_shadow_CheckBox = new CheckBox();
            always_show_cursor_CheckBox = new CheckBox();
            disable_discord_rpc_CheckBox = new CheckBox();
            groupBox1 = new GroupBox();
            panel1 = new Panel();
            NoticeLabel = new Label();
            groupBox2 = new GroupBox();
            DocButton = new Button();
            GroupButton = new Button();
            HistoryButton = new Button();
            PPButton = new Button();
            EULAButton = new Button();
            GetGameButton = new Button();
            UpdateButton = new Button();
            SaveButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            StartOption_Group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.PortLogo;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(24, 24);
            pictureBox1.MaximumSize = new Size(100, 100);
            pictureBox1.MinimumSize = new Size(100, 100);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // Name_Label
            // 
            Name_Label.AutoSize = true;
            Name_Label.BackColor = Color.Transparent;
            Name_Label.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Name_Label.ForeColor = Color.White;
            Name_Label.Location = new Point(12, 563);
            Name_Label.Name = "Name_Label";
            Name_Label.Size = new Size(367, 21);
            Name_Label.TabIndex = 1;
            Name_Label.Text = "Dancing Line Community Edtion Launcher v1.1";
            // 
            // Start_Button
            // 
            Start_Button.BackColor = SystemColors.Window;
            Start_Button.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            Start_Button.ForeColor = Color.Black;
            Start_Button.Location = new Point(858, 529);
            Start_Button.Name = "Start_Button";
            Start_Button.Size = new Size(180, 55);
            Start_Button.TabIndex = 2;
            Start_Button.Text = "启动游戏";
            Start_Button.UseVisualStyleBackColor = false;
            Start_Button.Click += Start_Button_Click;
            // 
            // AskOpenDLPort
            // 
            AskOpenDLPort.FileName = "DLport";
            // 
            // Title_Label
            // 
            Title_Label.AutoSize = true;
            Title_Label.BackColor = Color.Transparent;
            Title_Label.Font = new Font("Microsoft YaHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            Title_Label.ForeColor = SystemColors.ControlLightLight;
            Title_Label.Location = new Point(130, 48);
            Title_Label.Name = "Title_Label";
            Title_Label.Size = new Size(189, 31);
            Title_Label.TabIndex = 3;
            Title_Label.Text = "DANCING LINE";
            // 
            // Port_Label
            // 
            Port_Label.AutoSize = true;
            Port_Label.BackColor = Color.Transparent;
            Port_Label.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Port_Label.ForeColor = SystemColors.ControlLightLight;
            Port_Label.Location = new Point(133, 79);
            Port_Label.Name = "Port_Label";
            Port_Label.Size = new Size(153, 21);
            Port_Label.TabIndex = 4;
            Port_Label.Text = "Community Edtion";
            // 
            // PathStatus_Label
            // 
            PathStatus_Label.BackColor = Color.Transparent;
            PathStatus_Label.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            PathStatus_Label.ForeColor = SystemColors.ControlLightLight;
            PathStatus_Label.Location = new Point(849, 500);
            PathStatus_Label.Name = "PathStatus_Label";
            PathStatus_Label.Size = new Size(158, 23);
            PathStatus_Label.TabIndex = 5;
            PathStatus_Label.Text = "尚未设置游戏路径";
            PathStatus_Label.TextAlign = ContentAlignment.MiddleRight;
            PathStatus_Label.MouseHover += PathStatus_Label_MouseHover;
            // 
            // SetPath_Button
            // 
            SetPath_Button.BackColor = Color.Transparent;
            SetPath_Button.BackgroundImageLayout = ImageLayout.Zoom;
            SetPath_Button.ForeColor = SystemColors.ControlLightLight;
            SetPath_Button.ImageAlign = ContentAlignment.MiddleLeft;
            SetPath_Button.Location = new Point(1013, 498);
            SetPath_Button.Name = "SetPath_Button";
            SetPath_Button.Size = new Size(25, 25);
            SetPath_Button.TabIndex = 6;
            SetPath_Button.UseVisualStyleBackColor = false;
            SetPath_Button.Click += SetPath_Button_Click;
            SetPath_Button.MouseHover += SetPath_Button_MouseHover;
            // 
            // Update
            // 
            Update.Enabled = true;
            Update.Tick += Update_Tick;
            // 
            // StartOption_Group
            // 
            StartOption_Group.BackColor = Color.Transparent;
            StartOption_Group.Controls.Add(pictureBox5);
            StartOption_Group.Controls.Add(pictureBox4);
            StartOption_Group.Controls.Add(pictureBox3);
            StartOption_Group.Controls.Add(pictureBox2);
            StartOption_Group.Controls.Add(graphics_tier_TextBox);
            StartOption_Group.Controls.Add(limit_fps_TextBox);
            StartOption_Group.Controls.Add(shadow_distance_TextBox);
            StartOption_Group.Controls.Add(graphics_tier_CheckBox);
            StartOption_Group.Controls.Add(limit_fps_CheckBox);
            StartOption_Group.Controls.Add(shadow_distance_CheckBox);
            StartOption_Group.Controls.Add(disable_sound_CheckBox);
            StartOption_Group.Controls.Add(disable_shadow_CheckBox);
            StartOption_Group.Controls.Add(low_resolution_box);
            StartOption_Group.Controls.Add(force_window_CheckBox);
            StartOption_Group.Controls.Add(show_fps_CheckBox);
            StartOption_Group.Controls.Add(use_soft_shadow_CheckBox);
            StartOption_Group.Controls.Add(always_show_cursor_CheckBox);
            StartOption_Group.Controls.Add(disable_discord_rpc_CheckBox);
            StartOption_Group.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            StartOption_Group.ForeColor = SystemColors.ControlLightLight;
            StartOption_Group.Location = new Point(24, 130);
            StartOption_Group.Name = "StartOption_Group";
            StartOption_Group.Size = new Size(424, 418);
            StartOption_Group.TabIndex = 7;
            StartOption_Group.TabStop = false;
            StartOption_Group.Text = "启动参数";
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(173, 109);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(30, 30);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 17;
            pictureBox5.TabStop = false;
            pictureBox5.MouseHover += pictureBox5_MouseHover;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(307, 205);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(30, 30);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 16;
            pictureBox4.TabStop = false;
            pictureBox4.MouseHover += pictureBox4_MouseHover;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(217, 173);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 30);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 15;
            pictureBox3.TabStop = false;
            pictureBox3.MouseHover += pictureBox3_MouseHover;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(106, 237);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 30);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 14;
            pictureBox2.TabStop = false;
            pictureBox2.MouseHover += pictureBox2_MouseHover;
            // 
            // graphics_tier_TextBox
            // 
            graphics_tier_TextBox.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            graphics_tier_TextBox.Location = new Point(147, 371);
            graphics_tier_TextBox.Name = "graphics_tier_TextBox";
            graphics_tier_TextBox.Size = new Size(100, 23);
            graphics_tier_TextBox.TabIndex = 13;
            // 
            // limit_fps_TextBox
            // 
            limit_fps_TextBox.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            limit_fps_TextBox.Location = new Point(147, 339);
            limit_fps_TextBox.Name = "limit_fps_TextBox";
            limit_fps_TextBox.Size = new Size(100, 23);
            limit_fps_TextBox.TabIndex = 12;
            // 
            // shadow_distance_TextBox
            // 
            shadow_distance_TextBox.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            shadow_distance_TextBox.Location = new Point(147, 307);
            shadow_distance_TextBox.Name = "shadow_distance_TextBox";
            shadow_distance_TextBox.Size = new Size(100, 23);
            shadow_distance_TextBox.TabIndex = 11;
            // 
            // graphics_tier_CheckBox
            // 
            graphics_tier_CheckBox.AutoSize = true;
            graphics_tier_CheckBox.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            graphics_tier_CheckBox.Location = new Point(23, 369);
            graphics_tier_CheckBox.Name = "graphics_tier_CheckBox";
            graphics_tier_CheckBox.Size = new Size(125, 26);
            graphics_tier_CheckBox.TabIndex = 10;
            graphics_tier_CheckBox.Text = "更改图像层为";
            graphics_tier_CheckBox.UseVisualStyleBackColor = true;
            graphics_tier_CheckBox.CheckedChanged += graphics_tier_CheckBox_CheckedChanged;
            // 
            // limit_fps_CheckBox
            // 
            limit_fps_CheckBox.AutoSize = true;
            limit_fps_CheckBox.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            limit_fps_CheckBox.Location = new Point(23, 337);
            limit_fps_CheckBox.Name = "limit_fps_CheckBox";
            limit_fps_CheckBox.Size = new Size(125, 26);
            limit_fps_CheckBox.TabIndex = 9;
            limit_fps_CheckBox.Text = "设置帧率上限";
            limit_fps_CheckBox.UseVisualStyleBackColor = true;
            limit_fps_CheckBox.CheckedChanged += limit_fps_CheckBox_CheckedChanged;
            // 
            // shadow_distance_CheckBox
            // 
            shadow_distance_CheckBox.AutoSize = true;
            shadow_distance_CheckBox.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            shadow_distance_CheckBox.Location = new Point(23, 305);
            shadow_distance_CheckBox.Name = "shadow_distance_CheckBox";
            shadow_distance_CheckBox.Size = new Size(125, 26);
            shadow_distance_CheckBox.TabIndex = 8;
            shadow_distance_CheckBox.Text = "锁定阴影距离";
            shadow_distance_CheckBox.UseVisualStyleBackColor = true;
            shadow_distance_CheckBox.CheckedChanged += shadow_distance_CheckBox_CheckedChanged;
            // 
            // disable_sound_CheckBox
            // 
            disable_sound_CheckBox.AutoSize = true;
            disable_sound_CheckBox.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            disable_sound_CheckBox.Location = new Point(23, 273);
            disable_sound_CheckBox.Name = "disable_sound_CheckBox";
            disable_sound_CheckBox.Size = new Size(301, 26);
            disable_sound_CheckBox.TabIndex = 7;
            disable_sound_CheckBox.Text = "关闭游戏声音（即使设置中已经打开）";
            disable_sound_CheckBox.UseVisualStyleBackColor = true;
            // 
            // disable_shadow_CheckBox
            // 
            disable_shadow_CheckBox.AutoSize = true;
            disable_shadow_CheckBox.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            disable_shadow_CheckBox.Location = new Point(23, 241);
            disable_shadow_CheckBox.Name = "disable_shadow_CheckBox";
            disable_shadow_CheckBox.Size = new Size(93, 26);
            disable_shadow_CheckBox.TabIndex = 6;
            disable_shadow_CheckBox.Text = "禁用阴影";
            disable_shadow_CheckBox.UseVisualStyleBackColor = true;
            // 
            // low_resolution_box
            // 
            low_resolution_box.AutoSize = true;
            low_resolution_box.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            low_resolution_box.Location = new Point(23, 209);
            low_resolution_box.Name = "low_resolution_box";
            low_resolution_box.Size = new Size(290, 26);
            low_resolution_box.TabIndex = 5;
            low_resolution_box.Text = "强制游戏以800x600分辨率模式运行";
            low_resolution_box.UseVisualStyleBackColor = true;
            // 
            // force_window_CheckBox
            // 
            force_window_CheckBox.AutoSize = true;
            force_window_CheckBox.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            force_window_CheckBox.Location = new Point(23, 177);
            force_window_CheckBox.Name = "force_window_CheckBox";
            force_window_CheckBox.Size = new Size(205, 26);
            force_window_CheckBox.TabIndex = 4;
            force_window_CheckBox.Text = "强制游戏以窗口模式运行";
            force_window_CheckBox.UseVisualStyleBackColor = true;
            // 
            // show_fps_CheckBox
            // 
            show_fps_CheckBox.AutoSize = true;
            show_fps_CheckBox.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            show_fps_CheckBox.Location = new Point(23, 145);
            show_fps_CheckBox.Name = "show_fps_CheckBox";
            show_fps_CheckBox.Size = new Size(91, 26);
            show_fps_CheckBox.TabIndex = 3;
            show_fps_CheckBox.Text = "显示FPS";
            show_fps_CheckBox.UseVisualStyleBackColor = true;
            // 
            // use_soft_shadow_CheckBox
            // 
            use_soft_shadow_CheckBox.AutoSize = true;
            use_soft_shadow_CheckBox.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            use_soft_shadow_CheckBox.Location = new Point(23, 113);
            use_soft_shadow_CheckBox.Name = "use_soft_shadow_CheckBox";
            use_soft_shadow_CheckBox.Size = new Size(157, 26);
            use_soft_shadow_CheckBox.TabIndex = 2;
            use_soft_shadow_CheckBox.Text = "使用柔和阴影模式";
            use_soft_shadow_CheckBox.UseVisualStyleBackColor = true;
            // 
            // always_show_cursor_CheckBox
            // 
            always_show_cursor_CheckBox.AutoSize = true;
            always_show_cursor_CheckBox.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            always_show_cursor_CheckBox.Location = new Point(23, 81);
            always_show_cursor_CheckBox.Name = "always_show_cursor_CheckBox";
            always_show_cursor_CheckBox.Size = new Size(301, 26);
            always_show_cursor_CheckBox.TabIndex = 1;
            always_show_cursor_CheckBox.Text = "关卡游玩过程中不再自动隐藏鼠标光标";
            always_show_cursor_CheckBox.UseVisualStyleBackColor = true;
            // 
            // disable_discord_rpc_CheckBox
            // 
            disable_discord_rpc_CheckBox.AutoSize = true;
            disable_discord_rpc_CheckBox.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            disable_discord_rpc_CheckBox.Location = new Point(23, 49);
            disable_discord_rpc_CheckBox.Name = "disable_discord_rpc_CheckBox";
            disable_discord_rpc_CheckBox.Size = new Size(162, 26);
            disable_discord_rpc_CheckBox.TabIndex = 0;
            disable_discord_rpc_CheckBox.Text = "禁用Discord RPC";
            disable_discord_rpc_CheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(panel1);
            groupBox1.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.ForeColor = SystemColors.ControlLightLight;
            groupBox1.Location = new Point(475, 18);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(563, 379);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "游戏公告";
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(NoticeLabel);
            panel1.Location = new Point(16, 30);
            panel1.Name = "panel1";
            panel1.Size = new Size(534, 332);
            panel1.TabIndex = 1;
            // 
            // NoticeLabel
            // 
            NoticeLabel.AutoSize = true;
            NoticeLabel.Location = new Point(0, 0);
            NoticeLabel.MaximumSize = new Size(520, 0);
            NoticeLabel.Name = "NoticeLabel";
            NoticeLabel.Size = new Size(0, 27);
            NoticeLabel.TabIndex = 0;
            NoticeLabel.Click += NoticeLabel_Click;
            NoticeLabel.MouseHover += NoticeLabel_MouseHover;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(DocButton);
            groupBox2.Controls.Add(GroupButton);
            groupBox2.Controls.Add(HistoryButton);
            groupBox2.Controls.Add(PPButton);
            groupBox2.Controls.Add(EULAButton);
            groupBox2.Controls.Add(GetGameButton);
            groupBox2.Controls.Add(UpdateButton);
            groupBox2.Controls.Add(SaveButton);
            groupBox2.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(475, 403);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(368, 181);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "游戏选项";
            // 
            // DocButton
            // 
            DocButton.ForeColor = Color.Black;
            DocButton.Location = new Point(244, 129);
            DocButton.Name = "DocButton";
            DocButton.Size = new Size(108, 37);
            DocButton.TabIndex = 16;
            DocButton.Text = "文档站";
            DocButton.UseVisualStyleBackColor = true;
            DocButton.Click += DocButton_Click;
            // 
            // GroupButton
            // 
            GroupButton.ForeColor = Color.Black;
            GroupButton.Location = new Point(130, 129);
            GroupButton.Name = "GroupButton";
            GroupButton.Size = new Size(108, 37);
            GroupButton.TabIndex = 15;
            GroupButton.Text = "交流群";
            GroupButton.UseVisualStyleBackColor = true;
            GroupButton.Click += GroupButton_Click;
            // 
            // HistoryButton
            // 
            HistoryButton.ForeColor = Color.Black;
            HistoryButton.Location = new Point(244, 84);
            HistoryButton.Name = "HistoryButton";
            HistoryButton.Size = new Size(108, 37);
            HistoryButton.TabIndex = 14;
            HistoryButton.Text = "版本历史";
            HistoryButton.UseVisualStyleBackColor = true;
            HistoryButton.Click += HistoryButton_Click;
            // 
            // PPButton
            // 
            PPButton.ForeColor = Color.Black;
            PPButton.Location = new Point(130, 84);
            PPButton.Name = "PPButton";
            PPButton.Size = new Size(108, 37);
            PPButton.TabIndex = 13;
            PPButton.Text = "隐私政策";
            PPButton.UseVisualStyleBackColor = true;
            PPButton.Click += PPButton_Click;
            // 
            // EULAButton
            // 
            EULAButton.ForeColor = Color.Black;
            EULAButton.Location = new Point(130, 41);
            EULAButton.Name = "EULAButton";
            EULAButton.Size = new Size(222, 37);
            EULAButton.TabIndex = 12;
            EULAButton.Text = "最终用户许可条款";
            EULAButton.UseVisualStyleBackColor = true;
            EULAButton.Click += EULAButton_Click;
            // 
            // GetGameButton
            // 
            GetGameButton.ForeColor = Color.Black;
            GetGameButton.Location = new Point(16, 129);
            GetGameButton.Name = "GetGameButton";
            GetGameButton.Size = new Size(108, 37);
            GetGameButton.TabIndex = 11;
            GetGameButton.Text = "获取游戏";
            GetGameButton.UseVisualStyleBackColor = true;
            GetGameButton.Click += GetGameButton_Click;
            // 
            // UpdateButton
            // 
            UpdateButton.ForeColor = Color.Black;
            UpdateButton.Location = new Point(16, 84);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(108, 37);
            UpdateButton.TabIndex = 10;
            UpdateButton.Text = "检查更新";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.ForeColor = Color.Black;
            SaveButton.Location = new Point(16, 41);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(108, 37);
            SaveButton.TabIndex = 9;
            SaveButton.Text = "存档管理";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = Properties.Resources.PortBG;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1063, 597);
            Controls.Add(PathStatus_Label);
            Controls.Add(SetPath_Button);
            Controls.Add(Start_Button);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(StartOption_Group);
            Controls.Add(Port_Label);
            Controls.Add(Title_Label);
            Controls.Add(Name_Label);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(1079, 636);
            MinimumSize = new Size(1079, 636);
            Name = "MainForm";
            Text = "跳舞的线社区版 启动器";
            Load += MainForm_Load;
            Resize += MainForm_ReSize;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            StartOption_Group.ResumeLayout(false);
            StartOption_Group.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            groupBox1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
        private GroupBox groupBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private GroupBox groupBox2;
        private Button EULAButton;
        private Button GetGameButton;
        private Button UpdateButton;
        private Button SaveButton;
        private Button DocButton;
        private Button GroupButton;
        private Button HistoryButton;
        private Button PPButton;
        private Label NoticeLabel;
        private Panel panel1;
    }
}