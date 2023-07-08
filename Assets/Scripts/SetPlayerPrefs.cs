using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerPrefs : MonoBehaviour
{
    public PrefsType prefsType;
    public string key;
    public string value;

    public void OnClick()
    {
        switch (prefsType)
        {
            case PrefsType.String:
                PlayerPrefs.SetString(key, value);
                break;
            case PrefsType.Int:
                PlayerPrefs.SetInt(key, int.Parse(value));
                break;
            case PrefsType.Float:
                PlayerPrefs.SetFloat(key, float.Parse(value));
                break;
            case PrefsType.Bool:
                PlayerPrefs.SetInt(key, bool.Parse(value) ? 1 : 0);
                break;
        }
    }

    public enum PrefsType
    {
        String,
        Int,
        Float,
        Bool
    }
}
