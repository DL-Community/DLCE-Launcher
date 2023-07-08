using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;

public class LaunchGame : MonoBehaviour
{
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

        public class LocalDialog
        {
            //链接指定系统函数       打开文件对话框
            [DllImport("Comdlg32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
            public static extern bool GetOpenFileName([In, Out] OpenFileName ofn);
            public static bool GetOFN([In, Out] OpenFileName ofn)
            {
                return GetOpenFileName(ofn);
            }
        }

            string loadFile()
            {
                OpenFileName openFileName = new OpenFileName();
                openFileName.structSize = Marshal.SizeOf(openFileName);
                openFileName.filter = "游戏文件(*.exe)\0*.exe\0所有文件(*.*)\0*.*\0\0";
                openFileName.file = new string(new char[256]);
                openFileName.maxFile = openFileName.file.Length;
                openFileName.fileTitle = new string(new char[64]);
                openFileName.maxFileTitle = openFileName.fileTitle.Length;
                openFileName.initialDir = Application.streamingAssetsPath.Replace('/', '\\');//默认路径
                openFileName.title = "选择游戏可执行文件";
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

    public void OnClick()
    {
        string GamePath = PlayerPrefs.GetString("GamePath","NOPATH");

        if (GamePath == "NOPATH")
        {
            //询问用户游戏路径
            GamePath = loadFile();
            PlayerPrefs.SetString("GamePath", GamePath);
            System.Diagnostics.Process.Start(GamePath,PlayerPrefs.GetString("generetedArgue",""));
        }
        else
        {
            System.Diagnostics.Process.Start(GamePath, PlayerPrefs.GetString("generetedArgue", ""));
        }
    }
}
