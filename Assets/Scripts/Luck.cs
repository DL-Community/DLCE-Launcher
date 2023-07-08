using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Luck : MonoBehaviour
{
    public Text luckValue;
    public Text luckText;

    private void Start()
    {
        int luck = Random.Range(0, 100);
        luckValue.text = luck.ToString();

        if (luck >= 0 && luck < 10)
        {
            luckText.text = "大凶...你还是...别尝试了...吧...";
        }
        else if (luck >= 10 && luck < 30)
        {
            luckText.text = "凶...希望你不会死的太惨...";
        }
        else if (luck >= 30 && luck < 50)
        {
            luckText.text = "末吉..感觉在线的话，你还是可以尝试一下的...";
        }
        else if (luck >= 50 && luck < 70)
        {
            luckText.text = "吉，中规中矩，祝你好运吧！";
        }
        else if (luck >= 70 && luck < 90)
        {
            luckText.text = "小吉，你可以过关的！";
        }
        else if (luck >= 90 && luck <= 100)
        {
            luckText.text = "大吉！你一定可以一命AP一个关卡！";
        }

    }
}
