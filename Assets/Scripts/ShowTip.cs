using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public CanvasGroup tip;

    private void Start()
    {
        tip.alpha = 0;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tip.DOFade(1, 0.5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tip.DOFade(0, 0.5f);
    }
}
