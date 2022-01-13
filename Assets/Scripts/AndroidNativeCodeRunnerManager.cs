using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AndroidNativeCodeRunnerManager : MonoBehaviour
{
    [SerializeField] private Text _batteryPercentageText;
    [SerializeField] private Text _sumNumberText;

    AndroidJavaClass _unityClass;
    AndroidJavaObject _unityActivitys;
    AndroidJavaObject _unityPluginInstance;
    
    private void Awake()
    {
        InitializePlugin();
    }

    void InitializePlugin()
    {
        _unityPluginInstance = new AndroidJavaObject("com.rehtsestudio.unityplugin.PluginInstance");
        _unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        _unityActivitys = _unityClass.GetStatic<AndroidJavaObject>("currentActivity");
        
        _unityPluginInstance.CallStatic("ReceiveUnityActivity", _unityActivitys);
    }

    public void Add()
    {
        if(_unityPluginInstance != null)
        {
            var result = _unityPluginInstance.Call<int>("Add", 5, 6);
            _sumNumberText.text = result.ToString();
        }
    }

    public void GetBatteryPercentage()
    {
        if(_unityPluginInstance != null)
        {
            var result = _unityPluginInstance.Call<int>("GetBatteryPercentage", _unityActivitys);
            _batteryPercentageText.text = result.ToString();
        }
    }    
}
