using DG.Tweening;
using UnityEngine;

public class Pages : MonoBehaviour
{
    public CanvasGroup[] pages;
    public GameObject[] buttons;
    public GameObject highLight;

    public void ChangePage(string name)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            if (pages[i].name == name)
            {
                pages[i].DOFade(1, 0.5f);
                highLight.transform.DOLocalMoveY(buttons[i].transform.localPosition.y, 0.5f).SetEase(Ease.InOutCirc);
                pages[i].blocksRaycasts = true;
            }
            else
            {
                pages[i].DOFade(0, 0.5f);
                pages[i].blocksRaycasts = false;
            }
        }
    }
}
