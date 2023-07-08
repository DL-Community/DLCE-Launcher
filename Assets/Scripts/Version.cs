using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Version : MonoBehaviour
{
    public Text versionText;

    private void Start()
    {
        versionText.text = "当前启动器版本：" + Application.version + "，点击检查更新。";
    }

    public void CheckUpdate()
    {
        StartCoroutine(GetVersion());
    }

    IEnumerator GetVersion()
    {
        string url = "https://raw.githubusercontent.com/AsabaSushi/DLCE-Launcher/public-text-assets/version.txt";
        WWW www = new WWW(url);
        yield return www;
        string version = www.text;

        System.Version currentVersion = new System.Version(Application.version);
        System.Version latestVersion = new System.Version(version);

        if (currentVersion < latestVersion)
        {
            FindObjectOfType<PopOutWindow>().PopIn("版本更新检查","检测到新版本：" + version + "，请前往仓库下载。");
        }
        else
        {
            FindObjectOfType<PopOutWindow>().PopIn("版本更新检查","当前已是最新版本。");
        }
    }
}
