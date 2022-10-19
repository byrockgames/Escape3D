using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BabyItemBuyController : MonoBehaviour
{
    [Header("Baby Item Material")]
    [SerializeField] private Material BabyBody;
    [SerializeField] private Material BabyHair_Eyebrow;

    [Header("Baby Color")]
    [SerializeField] private Color[] Colors;

    [Header("Baby Button")]
    [SerializeField] private GameObject[] BodyButton;
    [SerializeField] private GameObject[] HairButton;

    [Header("Baby Ticket")]
    [SerializeField] private GameObject[] BodyTicket;
    [SerializeField] private GameObject[] HairTicket;

    [Header("Baby PlayerPrefs")] 
    private string Body1;
    private string Body2;
    private string Body3;
    private string Hair1;
    private string Hair2;
    private string Hair3;

    [Header("Data")]
    [SerializeField] private int ZirilionData;

    [Header("BUY-ERROR Panel")]
    [SerializeField] private GameObject BuyPanel;
    [SerializeField] private GameObject ErrorBuyPanel;
    void Start()
    {       
        PlayerPrefs.GetString("Body1", Body1);
        PlayerPrefs.GetString("Body2", Body2);
        PlayerPrefs.GetString("Body3", Body3);
        PlayerPrefs.GetString("Hair1", Hair1);
        PlayerPrefs.GetString("Hair2", Hair2);
        PlayerPrefs.GetString("Hair3", Hair3);

        BuyPanel.SetActive(false);
        ErrorBuyPanel.SetActive(false);
    }

    void Update()
    {
        BabyPlayerPrefs();

        ZirilionData = PlayerPrefs.GetInt("Zirilion");
    }

    void BabyPlayerPrefs()
    {
      
      if(PlayerPrefs.HasKey("Body1"))
    {
        BodyButton[0].SetActive(false);
        BodyTicket[0].SetActive(false);    
    }

    if(PlayerPrefs.HasKey("Body2"))
    {
        BodyButton[1].SetActive(false);
        BodyTicket[1].SetActive(false);
    }

    if (PlayerPrefs.HasKey("Body3"))
    {
        BodyButton[2].SetActive(false);
        BodyTicket[2].SetActive(false);
    }

    /////////////////////////////////////////////////////// HAIR
    if (PlayerPrefs.HasKey("Hair1"))
    {
        HairButton[0].SetActive(false);
        HairTicket[0].SetActive(false);
    }

    if (PlayerPrefs.HasKey("Hair2"))
    {
        HairButton[1].SetActive(false);
        HairTicket[1].SetActive(false);
    }

    if (PlayerPrefs.HasKey("Hair3"))
    {
        HairButton[2].SetActive(false);
        HairTicket[2].SetActive(false);
    }


    }

    public void BabyBodyDefault()
    {        
        BabyBody.color = Colors[0];
    }

    public void BabyBody1()
    {
        BabyBody.color = Colors[1];
    }
    public void BabyBody1Buy()
    {
        if (ZirilionData >= 180)
        {
            BabyBody.color = Colors[1];
            BodyButton[0].SetActive(false);
            BodyTicket[0].SetActive(false);
            PlayerPrefs.SetString("Body1", Body1);
            ZirilionData -= 180;
            PlayerPrefs.SetInt("Zirilion", ZirilionData);
            BuyPanel.SetActive(true);
            StartCoroutine(BuyController());
        }
        else
        {
            ErrorBuyPanel.SetActive(true);
            StartCoroutine(BuyController());
            BodyButton[0].SetActive(true);
            BodyTicket[0].SetActive(true);
        }
    }

    public void BabyBody2()
    {
        BabyBody.color = Colors[2];
    }
    public void BabyBody2Buy()
    {
        if (ZirilionData >= 200)
        {
            BabyBody.color = Colors[2];
            BodyButton[1].SetActive(false);
            BodyTicket[1].SetActive(false);
            PlayerPrefs.SetString("Body2", Body2);
            ZirilionData -= 200;
            PlayerPrefs.SetInt("Zirilion", ZirilionData);
            BuyPanel.SetActive(true);
            StartCoroutine(BuyController());
        }
        else
        {
            ErrorBuyPanel.SetActive(true);
            StartCoroutine(BuyController());
            BodyButton[1].SetActive(true);
            BodyTicket[1].SetActive(true);
        }

    }

    public void BabyBody3()
    {
        BabyBody.color = Colors[3];
    }
    public void BabyBody3Buy()
    {
        if (ZirilionData >= 250)
        {
            BabyBody.color = Colors[3];
            BodyButton[2].SetActive(false);
            BodyTicket[2].SetActive(false);
            PlayerPrefs.SetString("Body3", Body3);
            ZirilionData -= 250;
            PlayerPrefs.SetInt("Zirilion", ZirilionData);
            BuyPanel.SetActive(true);
            StartCoroutine(BuyController());
        }
        else
        {
            ErrorBuyPanel.SetActive(true);
            StartCoroutine(BuyController());
            BodyButton[2].SetActive(true);
            BodyTicket[2].SetActive(true);
        }

    }
   
    ///////////////////////////////  HAIR
   public void BabyHairDefault()
   {
     BabyHair_Eyebrow.color = Colors[4];
   }

   public void BabyHair1()
   {
        BabyHair_Eyebrow.color = Colors[5];
   } 
   public void BabyHair1Buy()
   {

        if (ZirilionData >= 90)
        {
            BabyHair_Eyebrow.color = Colors[5];
            HairButton[0].SetActive(false);
            HairTicket[0].SetActive(false);
            PlayerPrefs.SetString("Hair1", Hair1);
            ZirilionData -= 90;
            PlayerPrefs.SetInt("Zirilion", ZirilionData);
            BuyPanel.SetActive(true);
            StartCoroutine(BuyController());
        }
        else
        {
            ErrorBuyPanel.SetActive(true);
            StartCoroutine(BuyController());
            HairButton[0].SetActive(true);
            HairTicket[0].SetActive(true);
        }
   }
    
    public void BabyHair2()
    {
        BabyHair_Eyebrow.color = Colors[6];
    }
     public void BabyHair2Buy()
    {

        if (ZirilionData >= 180)
        {
            BabyHair_Eyebrow.color = Colors[6];
            HairButton[1].SetActive(false);
            HairTicket[1].SetActive(false);
            PlayerPrefs.SetString("Hair2", Hair2);
            ZirilionData -= 180;
            PlayerPrefs.SetInt("Zirilion", ZirilionData);
            BuyPanel.SetActive(true);
            StartCoroutine(BuyController());
        }
        else
        {
            ErrorBuyPanel.SetActive(true);
            StartCoroutine(BuyController());
            HairButton[1].SetActive(true);
            HairTicket[1].SetActive(true);
        }
    }

    public void BabyHair3()
    {
        BabyHair_Eyebrow.color = Colors[7];
    }
    public void BabyHair3Buy()
    {

        if (ZirilionData >= 200)
        {
            BabyHair_Eyebrow.color = Colors[7];
            HairButton[2].SetActive(false);
            HairTicket[2].SetActive(false);
            PlayerPrefs.SetString("Hair3", Hair3);
            ZirilionData -= 200;
            PlayerPrefs.SetInt("Zirilion", ZirilionData);
            BuyPanel.SetActive(true);
            StartCoroutine(BuyController());
        }
        else
        {
            ErrorBuyPanel.SetActive(true);
            StartCoroutine(BuyController());
            HairButton[2].SetActive(true);
            HairTicket[2].SetActive(true);
        }
    }


    IEnumerator BuyController()
    {
        yield return new WaitForSeconds(2);
        BuyPanel.SetActive(false);
        ErrorBuyPanel.SetActive(false);
    }

}
