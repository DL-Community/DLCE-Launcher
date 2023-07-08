using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class PopOutWindow : MonoBehaviour
{
    public Text title;
    public Text content;
    bool isPopOut = false;

    void Start()
    {
        transform.position = new Vector3(transform.position.x + 1000, transform.position.y, 0);
    }
    public void PopIn(string title, string content)
    {
        if(!isPopOut)
        {
            isPopOut = true;
            this.title.text = title;
            this.content.text = content;
            transform.DOMoveX(transform.position.x - 1000, 0.5f);
            Invoke("PopOut", 3);
        }
    }

    public void PopOut()
    {
        transform.DOMoveX(transform.position.x + 1000, 0.5f);
        isPopOut = false;
    }
}
