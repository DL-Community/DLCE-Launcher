using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class GetTextFromURL : MonoBehaviour
{
    public string url;

    private void Start()
    {
        OnClick();
    }

    public void OnClick()
    {
        StartCoroutine(GetText());
    }

    IEnumerator GetText()
    {
        GetComponent<Text>().text = "正在获取内容...";
        WWW www = new WWW(url);
        yield return www;
        GetComponent<Text>().text = www.text;
        
    }
}
