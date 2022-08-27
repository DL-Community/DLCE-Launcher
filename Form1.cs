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

            TimeShower_Label.Text = $"��ǰʱ�䣺{Hour}:{Minute}:{Second}";
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
            if(reg != null)
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
    }
}