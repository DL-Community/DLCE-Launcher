using System;
using System.Management;
using System.Text;

namespace DLPortLauncher
{
    public partial class SaveForm : Form
    {
        public SaveForm()
        {
            InitializeComponent();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            //注册表目录："HKEY_CURRENT_USER\Software\YINSU Studio\Dancing Line"
            //导出整个注册表
            //询问用户导出路径
            //要求管理员权限（UAC）

            string regPath = "\"HKEY_CURRENT_USER\\Software\\YINSU Studio\\Dancing Line\""; //需要包含双引号
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "注册表文件|*.reg";
            saveFileDialog.FileName = "DancingLine_Save.reg";
            saveFileDialog.Title = "导出注册表";
            saveFileDialog.ShowDialog();
            //导出注册表
            System.Diagnostics.Process.Start("regedit.exe", string.Format("/e {0} {1}", saveFileDialog.FileName, regPath));

            //对导出的注册表文件末尾添加该设备网卡MAC地址用于验证
            string macAddress = GetMacByWMI()[0];
            //添加MAC地址
            string[] lines = File.ReadAllLines(saveFileDialog.FileName);
            lines[lines.Length - 1] += "\r\n\"" + macAddress;
            File.WriteAllLines(saveFileDialog.FileName, lines);

            //对整个文件里的内容进行Base64加密
            string[] cry = File.ReadAllLines(saveFileDialog.FileName);
            string base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Join("\r\n", lines)));

            //写入文件
            File.WriteAllText(saveFileDialog.FileName, base64);

            //提示导出成功
            MessageBox.Show("导出成功！", "导出注册表", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        public List<string> GetMacByWMI()
        {
            List<string> macs = new List<string>();
            try
            {
                string mac = "";
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"])
                    {
                        mac = mo["MacAddress"].ToString();
                        macs.Add(mac);
                    }
                }
                moc = null;
                mc = null;
            }
            catch
            {
            }

            return macs;
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            //要求用户选择注册表文件
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "注册表文件|*.reg";
            openFileDialog.Title = "导入注册表";
            openFileDialog.ShowDialog();

            //将文件存储到临时文件
            File.WriteAllText(openFileDialog.FileName + ".tmp", File.ReadAllText(openFileDialog.FileName));

            //对文件内容进行Base64解密
            string base64 = File.ReadAllText(openFileDialog.FileName + ".tmp");
            string[] lines = Encoding.UTF8.GetString(Convert.FromBase64String(base64)).Split(new string[] { "\r\n" }, StringSplitOptions.None);

            //校验MAC地址
            string macAddress = GetMacByWMI()[0];
            if (lines[lines.Length - 1] != "\"" + macAddress)
            {
                MessageBox.Show("导入失败！\r\n\r\n错误原因：\r\n这个存档文件不是来自同一台设备！", "导入注册表", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //删除MAC地址
            lines[lines.Length - 1] = "";

            //写入文件
            File.WriteAllLines(openFileDialog.FileName + ".tmp.reg", lines);

            //导入注册表
            System.Diagnostics.Process.Start("regedit.exe", string.Format("/s {0}", openFileDialog.FileName + ".tmp.reg"));

            //删除临时文件
            File.Delete(openFileDialog.FileName + ".tmp");
            File.Delete(openFileDialog.FileName + ".tmp.reg");

            //提示导入成功
            MessageBox.Show("导入成功！", "导入注册表", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
