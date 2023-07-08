using UnityEngine.UI;
using System;
using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Ads : MonoBehaviour
{
    [Serializable]
    public class LevelBlock
    {
        public string titleString;
        public string contentString;
        public string imageURL;
        public string textURL;
        public Text titleText;
        public Text contentText;
        public Image image;
    }

    public float switchTime;

    public LevelBlock[] levelBlocks;

    private void Start()
    {
        OnClick();
        StartCoroutine(AutoSwitch());
    }

    public void OnClick()
    {
        StartCoroutine(GetLevelAd());
    }

    IEnumerator GetLevelAd()
    {
        levelBlocks[0].titleText.text = "正在获取内容...";
        levelBlocks[0].contentText.text = "请坐和放宽...";

        //存储URL
        for(int i = 1 ; i <= levelBlocks.Length ; i++)
        {
            levelBlocks[i - 1].imageURL = $"https://raw.githubusercontent.com/AsabaSushi/DLCE-Launcher/public-text-assets/AdImages/{i}.png";
            levelBlocks[i - 1].textURL = $"https://raw.githubusercontent.com/AsabaSushi/DLCE-Launcher/public-text-assets/Ads/{i}.txt";
        }

        //获取文本内容
        for (int i = 0; i < levelBlocks.Length; i++)
        {
            WWW www = new WWW(levelBlocks[i].textURL);
            yield return www;
            levelBlocks[i].titleString = www.text.Split('\n')[0];
            levelBlocks[i].contentString = www.text.Split('\n')[1];

            levelBlocks[i].titleText.text = levelBlocks[i].titleString;
            levelBlocks[i].contentText.text = levelBlocks[i].contentString;
        }

        //获取图片
        for (int i = 0; i < levelBlocks.Length; i++)
        {
            StartCoroutine(GetImage(levelBlocks[i].imageURL, levelBlocks[i].image));
        }
    }

    IEnumerator GetImage(string url, Image image)
    {
        WWW www = new WWW(url);
        yield return www;
        image.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), Vector2.zero);
    }
    
    IEnumerator AutoSwitch()
    {
        int i = 0;

        while (true)
        {
            yield return new WaitForSeconds(switchTime);

            if(i == levelBlocks.Length - 1)
            {
                i = 0;
            }
            else
            {
                i++;
            }

            this.transform.DOLocalMoveX(-i * 450, 1f).SetEase(Ease.OutCubic);
        }
    }
}
