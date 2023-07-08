using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeText : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(GetText());
    }

    IEnumerator GetText()
    {
        while(true)
        {
            int nowHour = System.DateTime.Now.Hour;
            string systemUsername = System.Environment.UserName;
            
            if (nowHour >= 0 && nowHour < 6)
            {
                GetComponent<UnityEngine.UI.Text>().text = "凌晨好，" + systemUsername + "。";
            }
            else if (nowHour >= 6 && nowHour < 12)
            {
                GetComponent<UnityEngine.UI.Text>().text = "早上好，" + systemUsername + "。";
            }
            else if (nowHour >= 12 && nowHour < 14)
            {
                GetComponent<UnityEngine.UI.Text>().text = "中午好，" + systemUsername + "。";
            }
            else if (nowHour >= 14 && nowHour < 18)
            {
                GetComponent<UnityEngine.UI.Text>().text = "下午好，" + systemUsername + "。";
            }
            else if (nowHour >= 18 && nowHour < 24)
            {
                GetComponent<UnityEngine.UI.Text>().text = "晚上好，" + systemUsername + "。";
            }

            yield return new WaitForSeconds(60);
        }
    }
}
