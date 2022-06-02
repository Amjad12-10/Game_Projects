using UnityEngine.Advertisements;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AdsManager : MonoBehaviour
{

#if UNITY_IOS
   Public String IosID = "123456";
#elif UNITY_ANDROID
    public string AppID = "123456";
#endif


}