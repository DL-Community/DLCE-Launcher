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
            AskOpenDLPort.InitialDirectory = "C:\\";    //�򿪶Ի����ĳ�ʼĿ¼
            AskOpenDLPort.Title = "�״���������ѡ����Ϸ�ļ�";
            AskOpenDLPort.Filter = "Dancing Line Port|Dancing Line.exe";
            AskOpenDLPort.RestoreDirectory = false;    //��Ϊfalse����򿪶Ի����Ϊ�ϴε�Ŀ¼����Ϊtrue����Ϊ��ʼĿ¼
            if (AskOpenDLPort.ShowDialog() == DialogResult.OK)
            {
                PathStatus_Label.Text = "��������Ϸ·��";
                GamePath = '"' + AskOpenDLPort.FileName.ToString() + '"';
                //��·������ע�����
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

        //�����Լ��
        void StartCheck()
        {
            RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\DLPL");
            //1.��ȡע����鿴�Ƿ���·������
            if (reg != null)
            {
                //ToString��Null��������Try����Null
                if (reg.GetValue("Path") != null)
                {
                    string path = reg.GetValue("Path").ToString();
                    if (path != "")
                    {
                        GamePath = '"' + path + '"';
                        PathStatus_Label.Text = "��������Ϸ·��";
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

            //2.��ȡ��������������״̬
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

                //3.����TextBox�Ŀɼ���
                if (shadow_distance_CheckBox.Checked == true) shadow_distance_TextBox.Visible = true;
                else shadow_distance_TextBox.Visible = false;

                if (limit_fps_CheckBox.Checked == true) limit_fps_TextBox.Visible = true;
                else limit_fps_TextBox.Visible = false;

                if (graphics_tier_CheckBox.Checked == true) graphics_tier_TextBox.Visible = true;
                else graphics_tier_TextBox.Visible = false;

                reg.Close();

            }
        }

        //������������
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

            //����������ݴ���ע���
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
                MessageBox.Show("����������Ϸ·��");
            }
        }

        private void TimeShower_Label_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            // ����the ToolTip 
            ToolTip toolTip1 = new ToolTip();

            // ������ʾ��ʽ
            toolTip1.AutoPopDelay = 5000;//��ʾ��Ϣ�Ŀɼ�ʱ��
            toolTip1.InitialDelay = 500;//�¼�������ú������ʾ
            toolTip1.ReshowDelay = 500;//ָ���һ���ؼ�������һ���ؼ�ʱ��������òŻ���ʾ��һ����ʾ��
            toolTip1.ShowAlways = true;//�Ƿ���ʾ��ʾ��

            //  ���ð���Ķ���.
            toolTip1.SetToolTip(this.pictureBox2, "��ѡ������Ϸ�汾���ڵ���2.0.2ʱ��Ч");//������ʾ��ť����ʾ����
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            // ����the ToolTip 
            ToolTip toolTip1 = new ToolTip();

            // ������ʾ��ʽ
            toolTip1.AutoPopDelay = 5000;//��ʾ��Ϣ�Ŀɼ�ʱ��
            toolTip1.InitialDelay = 500;//�¼�������ú������ʾ
            toolTip1.ReshowDelay = 500;//ָ���һ���ؼ�������һ���ؼ�ʱ��������òŻ���ʾ��һ����ʾ��
            toolTip1.ShowAlways = true;//�Ƿ���ʾ��ʾ��

            //  ���ð���Ķ���.
            toolTip1.SetToolTip(this.pictureBox3, "��ѡ������Ϸ�汾���ڵ���2.0.2ʱ��Ч");//������ʾ��ť����ʾ����
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            // ����the ToolTip 
            ToolTip toolTip1 = new ToolTip();

            // ������ʾ��ʽ
            toolTip1.AutoPopDelay = 5000;//��ʾ��Ϣ�Ŀɼ�ʱ��
            toolTip1.InitialDelay = 500;//�¼�������ú������ʾ
            toolTip1.ReshowDelay = 500;//ָ���һ���ؼ�������һ���ؼ�ʱ��������òŻ���ʾ��һ����ʾ��
            toolTip1.ShowAlways = true;//�Ƿ���ʾ��ʾ��

            //  ���ð���Ķ���.
            toolTip1.SetToolTip(this.pictureBox5, "��ѡ������Ϸ�汾���ڵ���2.0.2ʱ��Ч");//������ʾ��ť����ʾ����
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            // ����the ToolTip 
            ToolTip toolTip1 = new ToolTip();

            // ������ʾ��ʽ
            toolTip1.AutoPopDelay = 5000;//��ʾ��Ϣ�Ŀɼ�ʱ��
            toolTip1.InitialDelay = 500;//�¼�������ú������ʾ
            toolTip1.ReshowDelay = 500;//ָ���һ���ؼ�������һ���ؼ�ʱ��������òŻ���ʾ��һ����ʾ��
            toolTip1.ShowAlways = true;//�Ƿ���ʾ��ʾ��

            //  ���ð���Ķ���.
            toolTip1.SetToolTip(this.pictureBox4, "��ѡ������Ϸ�汾���ڵ���2.0.2ʱ��Ч");//������ʾ��ť����ʾ����
        }

        private void EULAButton_Click(object sender, EventArgs e)
        {
            //����ҳ
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
            //�������������
            string updateFile = "https://raw.githubusercontent.com/AsabaSushi/DLPort-Launcher/master/version.txt";

            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string update = webClient.DownloadString(updateFile);

                //��ȡ�汾��
                string[] updateInfo = update.Split('\n');

                //��ȡ��ǰ����İ汾��
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
            NoticeLabel.Text = "���ڻ�ȡ����...\n���ȡ����ʧ�ܣ��������������Ƿ�ͨ��\n���ڱ�������������Github����������п��ܻ�ȡʧ��";

            string noticeFile = "https://raw.githubusercontent.com/AsabaSushi/DLPort-Launcher/master/Notice.txt";

            //��ȡ����
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string notice = webClient.DownloadString(noticeFile);
                NoticeLabel.Text = notice;
            }
            catch (Exception)
            {
                NoticeLabel.Text = "��ȡ����ʧ��";
            }
        }

        private void NoticeLabel_Click(object sender, EventArgs e)
        {
            GetNotice();
        }

        private void NoticeLabel_MouseHover(object sender, EventArgs e)
        {
            // ����the ToolTip 
            ToolTip toolTip1 = new ToolTip();

            // ������ʾ��ʽ
            toolTip1.AutoPopDelay = 5000;//��ʾ��Ϣ�Ŀɼ�ʱ��
            toolTip1.InitialDelay = 500;//�¼�������ú������ʾ
            toolTip1.ReshowDelay = 500;//ָ���һ���ؼ�������һ���ؼ�ʱ��������òŻ���ʾ��һ����ʾ��
            toolTip1.ShowAlways = true;//�Ƿ���ʾ��ʾ��

            //  ���ð���Ķ���.
            toolTip1.SetToolTip(this.NoticeLabel, "����ı���ˢ�¹���");//������ʾ��ť����ʾ����
        }

        private void PathStatus_Label_MouseHover(object sender, EventArgs e)
        {
            // ����the ToolTip 
            ToolTip toolTip1 = new ToolTip();

            // ������ʾ��ʽ
            toolTip1.AutoPopDelay = 5000;//��ʾ��Ϣ�Ŀɼ�ʱ��
            toolTip1.InitialDelay = 500;//�¼�������ú������ʾ
            toolTip1.ReshowDelay = 500;//ָ���һ���ؼ�������һ���ؼ�ʱ��������òŻ���ʾ��һ����ʾ��
            toolTip1.ShowAlways = true;//�Ƿ���ʾ��ʾ��

            //  ���ð���Ķ���.
            toolTip1.SetToolTip(this.PathStatus_Label, GamePath);//������ʾ��ť����ʾ����
        }

        private void SetPath_Button_MouseHover(object sender, EventArgs e)
        {
            // ����the ToolTip 
            ToolTip toolTip1 = new ToolTip();

            // ������ʾ��ʽ
            toolTip1.AutoPopDelay = 5000;//��ʾ��Ϣ�Ŀɼ�ʱ��
            toolTip1.InitialDelay = 500;//�¼�������ú������ʾ
            toolTip1.ReshowDelay = 500;//ָ���һ���ؼ�������һ���ؼ�ʱ��������òŻ���ʾ��һ����ʾ��
            toolTip1.ShowAlways = true;//�Ƿ���ʾ��ʾ��

            //  ���ð���Ķ���.
            toolTip1.SetToolTip(this.SetPath_Button, "�޸���Ϸ·��");//������ʾ��ť����ʾ����
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveForm saveForm = new SaveForm();
            saveForm.Show();
        }
    }
}