using UnityEngine;

public static class Vibrator
{

#if UNITY_ANDROID && !UNITY_EDITOR
    public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    public static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    public static AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "Vibrator");
#else
    public static AndroidJavaClass unityPlayer;
    public static AndroidJavaObject currentActivity;
    public static AndroidJavaObject vibrator;
#endif

    public static void Vibrate(long millisecond=250)
    {
       
       if(Isandroid())
       {
            vibrator.Call("vibrate", millisecond);

       }
       else
       {
            Handheld.Vibrate();
        }
      
    }

    public static void Cancel()
    {
        if(Isandroid())
        {
            vibrator.Call("cancel");

        }

    }
    
    public static bool Isandroid(){

#if UNITY_ANDROID && !UNITY_EDITOR
        return true;
#else
        return false;
#endif        
    }

}
