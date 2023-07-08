using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : MonoBehaviour
{
    public string url;

    public void OnClick()
    {
        Application.OpenURL(url);
    }
}
