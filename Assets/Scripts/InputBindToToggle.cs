using UnityEngine.UI;
using UnityEngine;

public class InputBindToToggle : MonoBehaviour
{
    public Toggle toggle;
    public InputField input;

    private void Start()
    {
        input.interactable = toggle.isOn;
    }

    public void OnToggle()
    {
        input.interactable = toggle.isOn;
    }
}
