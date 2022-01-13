using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetBatteryPercentage : MonoBehaviour
{
    [SerializeField] private Text _batteryPercentageText;
    [SerializeField] private Text _batteryChargingText;

    public void GetBatteryPercentageInfo()
    {
        _batteryPercentageText.text = "Battery: " + GetBatteryLevel().ToString();
    }

    public void IsBatteryChargingInfo()
    {
        _batteryChargingText.text = "Is Battery Charging: " + IsBatteryCharging().ToString();
    }

    private float GetBatteryLevel()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            using (var androidPlugin = new AndroidJavaObject("com.rehtsestudio.unityplugin.GetBatteryInfo"))
            {
                using (var javaUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
                {
                    using (var currentActivity = javaUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
                    {
                        return androidPlugin.CallStatic<float>("GetBatteryPercentage", currentActivity);
                    }
                }
            }
        }

        return 1f;
    }

    private bool IsBatteryCharging()
    {
        using (var androidPlugin = new AndroidJavaObject("com.rehtsestudio.unityplugin.GetBatteryInfo"))
        {
            using (var javaUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                using (var currentActivity = javaUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
                {
                    return androidPlugin.CallStatic<bool>("IsBatteryCharging", currentActivity);
                }
            }
        }
    }
}
