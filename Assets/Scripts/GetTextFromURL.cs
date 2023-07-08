using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class GetTextFromURL : MonoBehaviour
{
    public string url;
    public bool hasContent = true;
    public ContentSizeFitter content;

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

        yield return new WaitForEndOfFrame();

        if (hasContent)
        {
            content.enabled = false;
            content.enabled = true;
        }
    }
}
