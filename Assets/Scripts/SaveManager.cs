using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

public class SaveManager : MonoBehaviour
{
    //链接指定系统函数       打开文件对话框
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class OpenFileName
    {
        public int structSize = 0;
        public IntPtr dlgOwner = IntPtr.Zero;
        public IntPtr instance = IntPtr.Zero;
        public String filter = null;
        public String customFilter = null;
        public int maxCustFilter = 0;
        public int filterIndex = 0;
        public String file = null;
        public int maxFile = 0;
        public String fileTitle = null;
        public int maxFileTitle = 0;
        public String initialDir = null;
        public String title = null;
        public int flags = 0;
        public short fileOffset = 0;
        public short fileExtension = 0;
        public String defExt = null;
        public IntPtr custData = IntPtr.Zero;
        public IntPtr hook = IntPtr.Zero;
        public String templateName = null;
        public IntPtr reservedPtr = IntPtr.Zero;
        public int reservedInt = 0;
        public int flagsEx = 0;
    }

    //链接指定系统函数        另存为对话框
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class SaveFileName
    {
        public int structSize = 0;
        public IntPtr dlgOwner = IntPtr.Zero;
        public IntPtr instance = IntPtr.Zero;
        public String filter = null;
        public String customFilter = null;
        public int maxCustFilter = 0;
        public int filterIndex = 0;
        public String file = null;
        public int maxFile = 0;
        public String fileTitle = null;
        public int maxFileTitle = 0;
        public String initialDir = null;
        public String title = null;
        public int flags = 0;
        public short fileOffset = 0;
        public short fileExtension = 0;
        public String defExt = null;
        public IntPtr custData = IntPtr.Zero;
        public IntPtr hook = IntPtr.Zero;
        public String templateName = null;
        public IntPtr reservedPtr = IntPtr.Zero;
        public int reservedInt = 0;
        public int flagsEx = 0;
    }

    public class LocalDialog
    {
        //链接指定系统函数       打开文件对话框
        [DllImport("Comdlg32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
        public static extern bool GetOpenFileName([In, Out] OpenFileName ofn);
        public static bool GetOFN([In, Out] OpenFileName ofn)
        {
            return GetOpenFileName(ofn);
        }
    
        //链接指定系统函数        另存为对话框
        [DllImport("Comdlg32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
        public static extern bool GetSaveFileName([In, Out] SaveFileName sfn);
        public static bool GetSFN([In, Out] SaveFileName sfn)
        {
            return GetSaveFileName(sfn);
        }
    }

    string loadFile()
    {
        OpenFileName openFileName = new OpenFileName();
        openFileName.structSize = Marshal.SizeOf(openFileName);
        openFileName.filter = "存档文件(*.reg)\0*.reg\0所有文件(*.*)\0*.*\0\0";
        openFileName.file = new string(new char[256]);
        openFileName.maxFile = openFileName.file.Length;
        openFileName.fileTitle = new string(new char[64]);
        openFileName.maxFileTitle = openFileName.fileTitle.Length;
        openFileName.initialDir = Application.streamingAssetsPath.Replace('/', '\\');//默认路径
        openFileName.title = "选择存档";
        openFileName.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000008;
 
        if (LocalDialog.GetOpenFileName(openFileName))
        {
            return openFileName.file;
 
        }
        else
        {
            return null;
        }
    }

    string saveFile()
    {
        SaveFileName saveFileName = new SaveFileName();
        saveFileName.structSize = Marshal.SizeOf(saveFileName);
        saveFileName.filter = "存档文件(*.reg)\0*.reg\0所有文件(*.*)\0*.*\0\0";
        saveFileName.file = new string(new char[256]);
        saveFileName.maxFile = saveFileName.file.Length;
        saveFileName.fileTitle = new string(new char[64]);
        saveFileName.maxFileTitle = saveFileName.fileTitle.Length;
        saveFileName.initialDir = Application.streamingAssetsPath.Replace('/', '\\');//默认路径
        saveFileName.title = "导出存档";
        saveFileName.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000008;
 
        if (LocalDialog.GetSaveFileName(saveFileName))
        {
            return saveFileName.file;
 
        }
        else
        {
            return null;
        }
    }
    public void ExportSave()
    {
        StartCoroutine(ExportSaveIEnumertor());
    }

    IEnumerator ExportSaveIEnumertor()
    {
        NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

        string regPath = "\"HKEY_CURRENT_USER\\Software\\YINSU Studio\\Dancing Line\""; //注册表路径
        //询问用户保存路径
        string savePath = saveFile();
        //导出注册表到指定路径
        System.Diagnostics.Process.Start("regedit", "/e " + savePath + " " + regPath);
        yield return new WaitForSeconds(1);
        //编辑注册表文件
        //在文件末尾添加MAC地址
        string macAddress = nics[0].GetPhysicalAddress().ToString();
        string[] lines = System.IO.File.ReadAllLines(savePath);
        List<string> newLines = new List<string>();
        foreach (string line in lines)
        {
            newLines.Add(line);
        }
        newLines.Add("MACAddress=\"" + macAddress + "\"");
        System.IO.File.WriteAllLines(savePath, newLines.ToArray());

        //对整个文件进行Base64编码
        string base64 = System.Convert.ToBase64String(System.IO.File.ReadAllBytes(savePath));
        //将Base64编码后的内容写入文件
        System.IO.File.WriteAllText(savePath, base64);

        //通知用户导出成功
        FindObjectOfType<PopOutWindow>().PopIn("存档管理","存档导出完毕！");
    }

    public void ImportSave()
    {
        StartCoroutine(ImportSaveIEnumertor());
    }

    IEnumerator ImportSaveIEnumertor()
    {
        //询问用户导入文件路径
        
        string importPath = loadFile();
        string oldFile = System.IO.File.ReadAllText(importPath);
        //对文件内容进行Base64解码
        string base64 = System.IO.File.ReadAllText(importPath);
        byte[] bytes = System.Convert.FromBase64String(base64);
        //将解码后的内容写入文件
        System.IO.File.WriteAllBytes(importPath, bytes);
        //校验MAC地址
        string[] lines = System.IO.File.ReadAllLines(importPath);
        string macAddress = NetworkInterface.GetAllNetworkInterfaces()[0].GetPhysicalAddress().ToString();
        if (lines[lines.Length - 1] != "MACAddress=\"" + macAddress + "\"")
        {
            //通知用户MAC地址不匹配
            FindObjectOfType<PopOutWindow>().PopIn("存档管理", "存档导入失败！\nMAC地址不匹配！");
            yield break;
        }
        //删除MAC地址
        List<string> newLines = new List<string>();
        foreach (string line in lines)
        {
            newLines.Add(line);
        }
        newLines.RemoveAt(newLines.Count - 1);
        System.IO.File.WriteAllLines(importPath, newLines.ToArray());
        //导入注册表
        System.Diagnostics.Process.Start("regedit", "/s " + importPath);
        yield return new WaitForSeconds(1);
        //重新将oldFile写入文件
        System.IO.File.WriteAllText(importPath, oldFile);
        //通知用户导入成功
        FindObjectOfType<PopOutWindow>().PopIn("存档管理", "存档导入完毕！");
    }
}
