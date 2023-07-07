using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Win32;

namespace DLPortLauncher
{
    public partial class MainForm : Form
    {
        AutoSizeFormClass ASFC = new AutoSizeFormClass();
        string GamePath;
        string StartArgument;
        public MainForm()
        {
            InitializeComponent();
            StartCheck();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ASFC.controllInitializeSize(this);
            GetNotice();
        }
        private void MainForm_ReSize(object sender, EventArgs e)
        {
            ASFC.controlAutoSize(this);
        }

        private void SetPath_Button_Click(object sender, EventArgs e)
        {
            AskForGamePath();
        }

        void AskForGamePath()
        {
            AskOpenDLPort.InitialDirectory = "C:\\";    //打开对话框后的初始目录
            AskOpenDLPort.Title = "首次启动，请选择游戏文件";
            AskOpenDLPort.Filter = "Dancing Line Port|Dancing Line.exe";
            AskOpenDLPort.RestoreDirectory = false;    //若为false，则打开对话框后为上次的目录。若为true，则为初始目录
            if (AskOpenDLPort.ShowDialog() == DialogResult.OK)
            {
                PathStatus_Label.Text = "已设置游戏路径";
                GamePath = '"' + AskOpenDLPort.FileName.ToString() + '"';
                //将路径存入注册表内
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\DLPL");
                key.SetValue("Path", AskOpenDLPort.FileName.ToString());
            }
        }

        private void Update_Tick(object sender, EventArgs e)
        {
            string Hour = DateTime.Now.Hour < 10 ? "0" + DateTime.Now.Hour.ToString() : DateTime.Now.Hour.ToString();
            string Minute = DateTime.Now.Minute < 10 ? "0" + DateTime.Now.Minute.ToString() : DateTime.Now.Minute.ToString();
            string Second = DateTime.Now.Second < 10 ? "0" + DateTime.Now.Second.ToString() : DateTime.Now.Second.ToString();
        }

        private void shadow_distance_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (shadow_distance_CheckBox.Checked == true) shadow_distance_TextBox.Visible = true;
            else shadow_distance_TextBox.Visible = false;
        }

        private void limit_fps_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (limit_fps_CheckBox.Checked == true) limit_fps_TextBox.Visible = true;
            else limit_fps_TextBox.Visible = false;
        }

        private void graphics_tier_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (graphics_tier_CheckBox.Checked == true) graphics_tier_TextBox.Visible = true;
            else graphics_tier_TextBox.Visible = false;
        }

        //启动自检查
        void StartCheck()
        {
            RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\DLPL");
            //1.读取注册表，查看是否有路径存入
            if (reg != null)
            {
                //ToString会Null，所以用Try捕获Null
                if (reg.GetValue("Path") != null)
                {
                    string path = reg.GetValue("Path").ToString();
                    if (path != "")
                    {
                        GamePath = '"' + path + '"';
                        PathStatus_Label.Text = "已设置游戏路径";
                    }
                }
                else
                {
                    AskForGamePath();
                }
            }
            else
            {
                AskForGamePath();
            }

            //2.读取各项启动参数的状态
            reg = Registry.CurrentUser.OpenSubKey(@"Software\DLPL");
            if (reg != null)
            {
                if (reg.GetValue("DiscordRPC") != null)
                    shadow_distance_CheckBox.Checked = reg.GetValue("DiscordRPC").ToString() == "1" ? true : false;
                if (reg.GetValue("AlwaysShowCursor") != null)
                    always_show_cursor_CheckBox.Checked = reg.GetValue("AlwaysShowCursor").ToString() == "1" ? true : false;
                if (reg.GetValue("UseSoftShadow") != null)
                    use_soft_shadow_CheckBox.Checked = reg.GetValue("UseSoftShadow").ToString() == "1" ? true : false;
                if (reg.GetValue("ForceWindow") != null)
                    force_window_CheckBox.Checked = reg.GetValue("ForceWindow").ToString() == "1" ? true : false;
                if (reg.GetValue("LowResolution") != null)
                    low_resolution_box.Checked = reg.GetValue("LowResolution").ToString() == "1" ? true : false;
                if (reg.GetValue("DisableShadow") != null)
                    disable_shadow_CheckBox.Checked = reg.GetValue("DisableShadow").ToString() == "1" ? true : false;
                if (reg.GetValue("DisableSound") != null)
                    disable_sound_CheckBox.Checked = reg.GetValue("DisableSound").ToString() == "1" ? true : false;

                if (reg.GetValue("ShadowDistance") != null)
                    if (reg.GetValue("ShadowDistance").ToString() != "0")
                    {
                        shadow_distance_CheckBox.Checked = true;
                        shadow_distance_TextBox.Text = reg.GetValue("ShadowDistance").ToString();
                    }
                    else
                    {
                        shadow_distance_CheckBox.Checked = false;
                    }

                if (reg.GetValue("LimitFPS") != null)
                    if (reg.GetValue("LimitFPS").ToString() != "-2")
                    {
                        limit_fps_CheckBox.Checked = true;
                        limit_fps_TextBox.Text = reg.GetValue("LimitFPS").ToString();
                    }
                    else
                    {
                        limit_fps_CheckBox.Checked = false;
                    }

                if (reg.GetValue("GraphicsTier") != null)
                    if (reg.GetValue("GraphicsTier").ToString() != "-1")
                    {
                        graphics_tier_CheckBox.Checked = true;
                        graphics_tier_TextBox.Text = reg.GetValue("GraphicsTier").ToString();
                    }
                    else
                    {
                        graphics_tier_CheckBox.Checked = false;
                    }

                //3.设置TextBox的可见性
                if (shadow_distance_CheckBox.Checked == true) shadow_distance_TextBox.Visible = true;
                else shadow_distance_TextBox.Visible = false;

                if (limit_fps_CheckBox.Checked == true) limit_fps_TextBox.Visible = true;
                else limit_fps_TextBox.Visible = false;

                if (graphics_tier_CheckBox.Checked == true) graphics_tier_TextBox.Visible = true;
                else graphics_tier_TextBox.Visible = false;

                reg.Close();

            }
        }

        //启动参数设置
        void StartArgumentSet()
        {
            StartArgument = "";
            if (disable_discord_rpc_CheckBox.Checked) StartArgument += "-disable_discord_rpc ";
            if (always_show_cursor_CheckBox.Checked) StartArgument += "-always_show_cursor ";
            if (use_soft_shadow_CheckBox.Checked) StartArgument += "-use_soft_shadows ";
            if (show_fps_CheckBox.Checked) StartArgument += "-show_fps ";
            if (force_window_CheckBox.Checked) StartArgument += "-force_windowed_mode ";
            if (low_resolution_box.Checked) StartArgument += "-low_resolution_mode ";
            if (disable_shadow_CheckBox.Checked) StartArgument += "-disable_shadow ";
            if (disable_sound_CheckBox.Checked) StartArgument += "-disable_sound ";

            if (shadow_distance_CheckBox.Checked) StartArgument += "-shadow_distance_" + shadow_distance_TextBox.Text + " ";
            if (limit_fps_CheckBox.Checked) StartArgument += "-frame_rate_" + limit_fps_TextBox.Text + " ";
            if (graphics_tier_CheckBox.Checked) StartArgument += "-graphics_tier_" + graphics_tier_TextBox.Text + " ";

            //将上面的数据存入注册表
            RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\DLPL");
            reg.SetValue("DiscordRPC", disable_discord_rpc_CheckBox.Checked ? "1" : "0");
            reg.SetValue("AlwaysShowCursor", always_show_cursor_CheckBox.Checked ? "1" : "0");
            reg.SetValue("UseSoftShadow", use_soft_shadow_CheckBox.Checked ? "1" : "0");
            reg.SetValue("ShowFPS", show_fps_CheckBox.Checked ? "1" : "0");
            reg.SetValue("ForceWindow", force_window_CheckBox.Checked ? "1" : "0");
            reg.SetValue("LowResolution", low_resolution_box.Checked ? "1" : "0");
            reg.SetValue("DisableShadow", disable_shadow_CheckBox.Checked ? "1" : "0");
            reg.SetValue("DisableSound", disable_sound_CheckBox.Checked ? "1" : "0");

            reg.SetValue("ShadowDistance", shadow_distance_CheckBox.Checked ? shadow_distance_TextBox.Text : "0");
            reg.SetValue("LimitFPS", limit_fps_CheckBox.Checked ? limit_fps_TextBox.Text : "-2");
            reg.SetValue("GraphicsTier", graphics_tier_CheckBox.Checked ? graphics_tier_TextBox.Text : "-1");

            reg.Close();
        }

        private void Start_Button_Click(object sender, EventArgs e)
        {
            if (GamePath != "")
            {
                StartArgumentSet();
                System.Diagnostics.Process.Start(GamePath, StartArgument);
            }
            else
            {
                MessageBox.Show("请先设置游戏路径");
            }
        }

        private void TimeShower_Label_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            // 创建the ToolTip 
            ToolTip toolTip1 = new ToolTip();

            // 设置显示样式
            toolTip1.AutoPopDelay = 5000;//提示信息的可见时间
            toolTip1.InitialDelay = 500;//事件触发多久后出现提示
            toolTip1.ReshowDelay = 500;//指针从一个控件移向另一个控件时，经过多久才会显示下一个提示框
            toolTip1.ShowAlways = true;//是否显示提示框

            //  设置伴随的对象.
            toolTip1.SetToolTip(this.pictureBox2, "该选项在游戏版本大于等于2.0.2时无效");//设置提示按钮和提示内容
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            // 创建the ToolTip 
            ToolTip toolTip1 = new ToolTip();

            // 设置显示样式
            toolTip1.AutoPopDelay = 5000;//提示信息的可见时间
            toolTip1.InitialDelay = 500;//事件触发多久后出现提示
            toolTip1.ReshowDelay = 500;//指针从一个控件移向另一个控件时，经过多久才会显示下一个提示框
            toolTip1.ShowAlways = true;//是否显示提示框

            //  设置伴随的对象.
            toolTip1.SetToolTip(this.pictureBox3, "该选项在游戏版本大于等于2.0.2时无效");//设置提示按钮和提示内容
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            // 创建the ToolTip 
            ToolTip toolTip1 = new ToolTip();

            // 设置显示样式
            toolTip1.AutoPopDelay = 5000;//提示信息的可见时间
            toolTip1.InitialDelay = 500;//事件触发多久后出现提示
            toolTip1.ReshowDelay = 500;//指针从一个控件移向另一个控件时，经过多久才会显示下一个提示框
            toolTip1.ShowAlways = true;//是否显示提示框

            //  设置伴随的对象.
            toolTip1.SetToolTip(this.pictureBox5, "该选项在游戏版本大于等于2.0.2时无效");//设置提示按钮和提示内容
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            // 创建the ToolTip 
            ToolTip toolTip1 = new ToolTip();

            // 设置显示样式
            toolTip1.AutoPopDelay = 5000;//提示信息的可见时间
            toolTip1.InitialDelay = 500;//事件触发多久后出现提示
            toolTip1.ReshowDelay = 500;//指针从一个控件移向另一个控件时，经过多久才会显示下一个提示框
            toolTip1.ShowAlways = true;//是否显示提示框

            //  设置伴随的对象.
            toolTip1.SetToolTip(this.pictureBox4, "该选项在游戏版本大于等于2.0.2时无效");//设置提示按钮和提示内容
        }

        private void EULAButton_Click(object sender, EventArgs e)
        {
            //打开网页
            System.Diagnostics.Process.Start("explorer.exe", "https://aaron8052.github.io/FengYan-Documentation/#/dlce/eula");
        }

        private void PPButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://aaron8052.github.io/FengYan-Documentation/#/dlce/privacy");
        }

        private void GroupButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://qm.qq.com/cgi-bin/qm/qr?k=jrj-sAZchUBh1WT5-jNAvlbo2XL3gx4t&jump_from=webapi&authKey=/QkYzDVm7/Ip4kAFOCEEnEjaDA7LcsjpUxT84a4+5TvUFvkYQnGfCbiN6wq498KZ");
        }

        private void DocButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://aaron8052.github.io/FengYan-Documentation/#/");

        }

        private void HistoryButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://aaron8052.github.io/FengYan-Documentation/#/dlce/versions");
        }

        private void GetGameButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://aaron8052.github.io/FengYan-Documentation/#/dlce-group/beta-test");
            System.Diagnostics.Process.Start("explorer.exe", "https://github.com/DL-Community/Dancing-Line-Community-Edition");
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            //检查启动器更新
            string updateFile = "https://raw.githubusercontent.com/AsabaSushi/DLPort-Launcher/master/version.txt";

            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string update = webClient.DownloadString(updateFile);

                //获取版本号
                string[] updateInfo = update.Split('\n');

                //获取当前软件的版本号
                string[] versionInfo = Application.ProductVersion.Split('.');
                int[] localVersion = new int[4];
                for (int i = 0; i < 4; i++)
                {
                    localVersion[i] = Convert.ToInt32(versionInfo[i]);
                }
                int[] remoteVersion = new int[4];
                for (int i = 0; i < 4; i++)
                {
                    remoteVersion[i] = Convert.ToInt32(updateInfo[i]);
                }

            }
        }

        void GetNotice()
        {
            NoticeLabel.Text = "正在获取公告...\n如获取公告失败，请检查网络连接是否通畅\n由于本公告内容来自Github，因此您极有可能获取失败";

            string noticeFile = "https://raw.githubusercontent.com/AsabaSushi/DLPort-Launcher/master/Notice.txt";

            //获取公告
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string notice = webClient.DownloadString(noticeFile);
                NoticeLabel.Text = notice;
            }
            catch (Exception)
            {
                NoticeLabel.Text = "获取公告失败";
            }
        }

        private void NoticeLabel_Click(object sender, EventArgs e)
        {
            GetNotice();
        }

        private void NoticeLabel_MouseHover(object sender, EventArgs e)
        {
            // 创建the ToolTip 
            ToolTip toolTip1 = new ToolTip();

            // 设置显示样式
            toolTip1.AutoPopDelay = 5000;//提示信息的可见时间
            toolTip1.InitialDelay = 500;//事件触发多久后出现提示
            toolTip1.ReshowDelay = 500;//指针从一个控件移向另一个控件时，经过多久才会显示下一个提示框
            toolTip1.ShowAlways = true;//是否显示提示框

            //  设置伴随的对象.
            toolTip1.SetToolTip(this.NoticeLabel, "点击文本可刷新公告");//设置提示按钮和提示内容
        }

        private void PathStatus_Label_MouseHover(object sender, EventArgs e)
        {
            // 创建the ToolTip 
            ToolTip toolTip1 = new ToolTip();

            // 设置显示样式
            toolTip1.AutoPopDelay = 5000;//提示信息的可见时间
            toolTip1.InitialDelay = 500;//事件触发多久后出现提示
            toolTip1.ReshowDelay = 500;//指针从一个控件移向另一个控件时，经过多久才会显示下一个提示框
            toolTip1.ShowAlways = true;//是否显示提示框

            //  设置伴随的对象.
            toolTip1.SetToolTip(this.PathStatus_Label, GamePath);//设置提示按钮和提示内容
        }

        private void SetPath_Button_MouseHover(object sender, EventArgs e)
        {
            // 创建the ToolTip 
            ToolTip toolTip1 = new ToolTip();

            // 设置显示样式
            toolTip1.AutoPopDelay = 5000;//提示信息的可见时间
            toolTip1.InitialDelay = 500;//事件触发多久后出现提示
            toolTip1.ReshowDelay = 500;//指针从一个控件移向另一个控件时，经过多久才会显示下一个提示框
            toolTip1.ShowAlways = true;//是否显示提示框

            //  设置伴随的对象.
            toolTip1.SetToolTip(this.SetPath_Button, "修改游戏路径");//设置提示按钮和提示内容
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveForm saveForm = new SaveForm();
            saveForm.Show();
        }
    }
}