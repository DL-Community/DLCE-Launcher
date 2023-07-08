using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundImage : MonoBehaviour
{
    public Vector2 mousePos;
    public float speed = 0.1f;

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //使得图片跟随鼠标反向移动
        transform.position = mousePos;
    }
}
