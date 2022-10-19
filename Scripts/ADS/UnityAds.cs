using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAds : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsShowListener , IUnityAdsLoadListener
{

    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    [SerializeField] bool _testMode;
    private string _gameId;

    // Prize
    public int ZirilionData;

    void Start()
    {
        
    }

    void Update() 
    {
        Time.timeScale = 1f;
        ZirilionData = PlayerPrefs.GetInt("Zirilion");
    }

    void Awake()
    {
        InitializeAds();
        LoadRewardedAd();
       
    }

    public void InitializeAds()
    {
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSGameId
            : _androidGameId;
        Advertisement.Initialize(_gameId, _testMode, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        //LoadBannerAd();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }


    // BANNER

    //public void LoadBannerAd()
   // {
        // Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
       // Advertisement.Banner.Load("Banner_Android",
           // new BannerLoadOptions
           // {
               // loadCallback = OnBannerLoaded,
               // errorCallback =  OnBannerError
           // });

   // }

    //void OnBannerLoaded()
    //{
       // Advertisement.Banner.Show("Banner_Android");
    //}

   //  void OnBannerError(string message)
    //{
     //   Debug.Log($"Banner Error: {message}");
    //}




    // Rewarded (odul)
    public void LoadRewardedAd()
    {
        Advertisement.Load("Rewarded_Android", this);
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("OnUnityAdsShowFailure");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("OnUnityAdsShowStart");
        Time.timeScale = 0;
        Advertisement.Banner.Hide();
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("OnUnityAdsShowClick");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("OnUnityAdsShowComplete " + showCompletionState);
        if (placementId.Equals("Rewarded_Android") && UnityAdsShowCompletionState.COMPLETED.Equals(showCompletionState))
        {
            Debug.Log("rewared Player");
            ZirilionData += 10;
            PlayerPrefs.SetInt("Zirilion", ZirilionData);
        }
        Time.timeScale = 1f;
        Advertisement.Banner.Show("Banner_Android");
    }



    // Interstitial  (Gecis)


    public void LoadInerstitialAd()
    {
        Advertisement.Load("Interstitial_Android", this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("OnUnityAdsAdLoaded");
        Advertisement.Show(placementId, this);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {placementId}: {error.ToString()} - {message}");
    }

}
