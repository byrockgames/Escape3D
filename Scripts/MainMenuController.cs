using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    [Header("UI")]
    public GameObject MainPanel;
    public GameObject LoadingPanel;

    [Header("URL")]
    [SerializeField] string ContactURL;
    [SerializeField] string PrivacyURL;

    [SerializeField] string InstagramURL;
    [SerializeField] string TwitterURL;
    [SerializeField] string LinkedInURL;
    [SerializeField] string TikTokURL;

    [Header("Buy")]
    [SerializeField] GameObject ChildBuy;
    [SerializeField] GameObject YouthBuy;
    [SerializeField] GameObject BusinessBuy;

    [SerializeField] GameObject BuyPanel;
    [SerializeField] GameObject ErrorBuyPanel;

    [Header("Data")]
    [SerializeField] private int ZirilionData;
    [SerializeField] private TMP_Text ZirilionText;
    private string PurchaseChild;
    private string PurchaseYouth;
    private string PurchaseBusiness;

    [Header("AudioSource")]

    [SerializeField] private AudioSource aSourceButtonClick;
    void Start()
    {
       
        // UI PANLES
        MainPanel.SetActive(true);
        LoadingPanel.SetActive(false);
        
        // Buy Panel 
        BuyPanel.SetActive(false);
        ErrorBuyPanel.SetActive(false);


    }

    
    void Update()
    {
        ZirilionText.text = "" + ZirilionData.ToString();
        PurchaseController();

        //  Data
        ZirilionData = PlayerPrefs.GetInt("Zirilion");
        PlayerPrefs.GetString("PurchaseChild", PurchaseChild);
        PlayerPrefs.GetString("PurchaseYouth", PurchaseYouth);
        PlayerPrefs.GetString("PurchaseBusiness", PurchaseBusiness);

    }

    void PurchaseController()
    {

     if(PlayerPrefs.HasKey("PurchaseChild"))
     {
         ChildBuy.SetActive(false);
     }
      else
     {
        ChildBuy.SetActive(true);
     }
     
     //////////////////////////////////  Youth
     if (PlayerPrefs.HasKey("PurchaseYouth"))
     {
        YouthBuy.SetActive(false);
     }
     else
     {
        YouthBuy.SetActive(true);
     }

        //////////////////////////////////  Business    
     if (PlayerPrefs.HasKey("PurchaseBusiness"))
     {
        BusinessBuy.SetActive(false);
     }
     else
     {
        BusinessBuy.SetActive(true);
     }

    }

    public void ChildBuyController()
    {
       aSourceButtonClick.Play();
       if(ZirilionData >= 800)
       {       
            BuyPanel.SetActive(true);
            ChildBuy.SetActive(false);
            PlayerPrefs.SetString("PurchaseChild", PurchaseChild);
            ZirilionData -= 800;
            StartCoroutine(BuyController());
            PlayerPrefs.SetInt("Zirilion", ZirilionData);
        }
       else
       {
            ErrorBuyPanel.SetActive(true);
            StartCoroutine(BuyController());
       }

    }

    public void YouthBuyController()
    {
        aSourceButtonClick.Play();
        if (ZirilionData >= 1600)
        {
            BuyPanel.SetActive(true);
            YouthBuy.SetActive(false);
            PlayerPrefs.SetString("PurchaseYouth", PurchaseYouth);
            ZirilionData -= 1600;
            StartCoroutine(BuyController());
            PlayerPrefs.SetInt("Zirilion", ZirilionData);
        }
        else
        {
            ErrorBuyPanel.SetActive(true);
            StartCoroutine(BuyController());
        }

    }

    public void BusinessBuyController()
    {
        aSourceButtonClick.Play();
        if (ZirilionData >= 3000)
        {
            BuyPanel.SetActive(true);
            YouthBuy.SetActive(false);
            PlayerPrefs.SetString("PurchaseBusiness", PurchaseBusiness);
            ZirilionData -= 3000;
            StartCoroutine(BuyController());
            PlayerPrefs.SetInt("Zirilion", ZirilionData);
        }
        else
        {
            ErrorBuyPanel.SetActive(true);
            StartCoroutine(BuyController());
        }

    }

    IEnumerator BuyController()
    {
        yield return new WaitForSeconds(2);
        BuyPanel.SetActive(false);
        ErrorBuyPanel.SetActive(false);
    }

    public void InstagramUrl()
    {
        aSourceButtonClick.Play();
        Application.OpenURL(InstagramURL);
    }
    public void TwitterUrl()
    {
        aSourceButtonClick.Play();
        Application.OpenURL(TwitterURL);
    }
    public void LinkedInUrl()
    {
        aSourceButtonClick.Play();
        Application.OpenURL(LinkedInURL);
    }
    public void TikTokUrl()
    {
        aSourceButtonClick.Play();
        Application.OpenURL(TikTokURL);
    }
    public void ContactUsURL()
    {
        aSourceButtonClick.Play();
         Application.OpenURL(ContactURL);
    }
    public void PrivacyPoliceURL()
    {
        aSourceButtonClick.Play();
        Application.OpenURL(PrivacyURL);
    }

    // Baby Hospital Random sahne secme 
    public void BabyButtonRandomScene()
    {
        aSourceButtonClick.Play();
        LoadingPanel.SetActive(true);
        StartCoroutine(BabyButtonScene());
    }
    IEnumerator BabyButtonScene()
    {
        yield return new WaitForSeconds(4);

        LoadingPanel.SetActive(false);
        int index = Random.Range(2,4+1); 
        SceneManager.LoadScene(index);
   
    }

    // Child School Random sahne secme 
    public void ChildButtonRandomScene()
    {
        aSourceButtonClick.Play();
        LoadingPanel.SetActive(true);
        StartCoroutine(ChildButtonScene());
    }
    IEnumerator ChildButtonScene()
    {
        yield return new WaitForSeconds(4);

        LoadingPanel.SetActive(false);
        int index = Random.Range(5, 7+1);
        SceneManager.LoadScene(index);
    }

    // Youth Street Random sahne secme 
    public void YouthButtonRandomScene()
    {
        aSourceButtonClick.Play();
        LoadingPanel.SetActive(true);
        StartCoroutine(YouthButtonScene());
    }
    IEnumerator YouthButtonScene()
    {
        yield return new WaitForSeconds(4);

        LoadingPanel.SetActive(false);
        int index = Random.Range(8, 9 +1);
        SceneManager.LoadScene(index);
    }


    // Business Office Random sahne secme 
    public void BusinessButtonRandomScene()
    {
        aSourceButtonClick.Play();
        LoadingPanel.SetActive(true);
        StartCoroutine(BusinessButtonScene());
    }
    IEnumerator BusinessButtonScene()
    {
        yield return new WaitForSeconds(4);

        LoadingPanel.SetActive(false);
        int index = Random.Range(10, 11 + 1);
        SceneManager.LoadScene(index);
    }

    public void DataReset()
    {
        aSourceButtonClick.Play();
        PlayerPrefs.DeleteAll();
    }
}
