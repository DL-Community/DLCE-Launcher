using UnityEngine.UI;
using UnityEngine;

public class SetArgue : MonoBehaviour
{
    public Toggle disableRPC,hideMouse,softShadow,showFPS,windowed,lowRes,disShadow,mute,lockShadowDis,limFPS,changeLayer;
    public InputField lockShadowDisInput,limFPSInput,changeLayerInput;
    public string generetedArgue;

    private bool canGenerate = false;

    private void Start()
    {
        generetedArgue = "";
        ReadPlayerPrefs();
        GenerateArgue();
    }

    public void ReadPlayerPrefs()
    {
        disableRPC.isOn = PlayerPrefs.GetInt("disableRPC", 0) == 1 ? true : false;
        hideMouse.isOn = PlayerPrefs.GetInt("hideMouse", 0) == 1 ? true : false;
        softShadow.isOn = PlayerPrefs.GetInt("softShadow", 0) == 1 ? true : false;
        showFPS.isOn = PlayerPrefs.GetInt("showFPS", 0) == 1 ? true : false;
        windowed.isOn = PlayerPrefs.GetInt("windowed", 0) == 1 ? true : false;
        lowRes.isOn = PlayerPrefs.GetInt("lowRes", 0) == 1 ? true : false;
        disShadow.isOn = PlayerPrefs.GetInt("disShadow", 0) == 1 ? true : false;
        mute.isOn = PlayerPrefs.GetInt("mute", 0) == 1 ? true : false;
        lockShadowDis.isOn = PlayerPrefs.GetInt("lockShadowDis", 0) == 1 ? true : false;
        limFPS.isOn = PlayerPrefs.GetInt("limFPS", 0) == 1 ? true : false;
        changeLayer.isOn = PlayerPrefs.GetInt("changeLayer", 0) == 1 ? true : false;
        lockShadowDisInput.text = PlayerPrefs.GetString("lockShadowDisInput", "1");
        limFPSInput.text = PlayerPrefs.GetString("limFPSInput", "-1");
        changeLayerInput.text = PlayerPrefs.GetString("changeLayerInput", "0");

        canGenerate = true;
    }

    public void GenerateArgue()
    {
        if (!canGenerate)
        {
            return;
        }

        generetedArgue = "";
        if (disableRPC.isOn)
        {
            PlayerPrefs.SetInt("disableRPC", 1);
            generetedArgue += " -disable_discord_rpc";
        }
        else
        {
            PlayerPrefs.SetInt("disableRPC", 0);
        }

        if (hideMouse.isOn)
        {
            PlayerPrefs.SetInt("hideMouse", 1);
            generetedArgue += " -always_show_cursor";
        }
        else
        {
            PlayerPrefs.SetInt("hideMouse", 0);
        }
        
        if (softShadow.isOn)
        {
            PlayerPrefs.SetInt("softShadow", 1);
            generetedArgue += " -use_soft_shadows";
        }
        else
        {
            PlayerPrefs.SetInt("softShadow", 0);
        }

        if (showFPS.isOn)
        {
            PlayerPrefs.SetInt("showFPS", 1);
            generetedArgue += " -show_fps";
        }
        else
        {
            PlayerPrefs.SetInt("showFPS", 0);
        }
        
        if (windowed.isOn)
        {
            PlayerPrefs.SetInt("windowed", 1);
            generetedArgue += " -force_windowed_mode";
        }
        else
        {
            PlayerPrefs.SetInt("windowed", 0);
        }

        if (lowRes.isOn)
        {
            PlayerPrefs.SetInt("lowRes", 1);
            generetedArgue += " -low_resolution_mode";
        }
        else
        {
            PlayerPrefs.SetInt("lowRes", 0);
        }

        if (disShadow.isOn)
        {
            PlayerPrefs.SetInt("disShadow", 1);
            generetedArgue += " -disable_shadow";
        }
        else
        {
            PlayerPrefs.SetInt("disShadow", 0);
        }

        if (mute.isOn)
        {
            PlayerPrefs.SetInt("mute", 1);
            generetedArgue += " -disable_sound";
        }
        else
        {
            PlayerPrefs.SetInt("mute", 0);
        }

        if (lockShadowDis.isOn)
        {
            PlayerPrefs.SetInt("lockShadowDis", 1);
            PlayerPrefs.SetString("lockShadowDisInput", lockShadowDisInput.text);
            
            if(lockShadowDisInput.text == "")
            {
                lockShadowDisInput.text = "1";
            }
            generetedArgue += " -shadow_distance_" + lockShadowDisInput.text;
        }
        else
        {
            PlayerPrefs.SetInt("lockShadowDis", 0);
        }

        if (limFPS.isOn)
        {
            PlayerPrefs.SetInt("limFPS", 1);
            PlayerPrefs.SetString("limFPSInput", limFPSInput.text);

            if (limFPSInput.text == "")
            {
                limFPSInput.text = "-1";
            }
            generetedArgue += " -frame_rate_" + limFPSInput.text;
        }
        else
        {
            PlayerPrefs.SetInt("limFPS", 0);
        }

        if (changeLayer.isOn)
        {
            PlayerPrefs.SetInt("changeLayer", 1);
            PlayerPrefs.SetString("changeLayerInput", changeLayerInput.text);

            if (changeLayerInput.text == "")
            {
                changeLayerInput.text = "0";
            }
            generetedArgue += " -graphics_tier_" + changeLayerInput.text;
        }
        else
        {
            PlayerPrefs.SetInt("changeLayer", 0);
        }

        PlayerPrefs.SetString("generetedArgue", generetedArgue);
    }
}
