using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusinessItemController : MonoBehaviour
{

    [Header("Business Item Material")]
    [SerializeField] private Material BusinessBody;
    [SerializeField] private Material BusinessHair;
    [SerializeField] private Material BusinessBlazer;
    [SerializeField] private Material BusinessPants;

    [Header("Business Color")]
    [SerializeField] private Color[] Colors;


    [Header("Business Button")]
    [SerializeField] private GameObject[] BodyButton;
    [SerializeField] private GameObject[] HairButton;
    [SerializeField] private GameObject[] BlazerButton;
    [SerializeField] private GameObject[] PantsButton;

    [Header("Business Ticket")]
    [SerializeField] private GameObject[] BodyTicket;
    [SerializeField] private GameObject[] HairTicket;
    [SerializeField] private GameObject[] BlazerTicket;
    [SerializeField] private GameObject[] PantsTicket;

    [Header("Business PlayerPrefs")]
    private string Business_Body1;
    private string Business_Body2;
    private string Business_Body3;
    private string Business_Hair1;
    private string Business_Hair2;
    private string Business_Hair3;
    private string Business_Blazer1;
    private string Business_Blazer2;
    private string Business_Blazer3;
    private string Business_Pants1;
    private string Business_Pants2;
    private string Business_Pants3;

    [Header("Data")]
    [SerializeField] private int ZirilionData;

    [Header("BUY-ERROR Panel")]
    [SerializeField] private GameObject BuyPanel;
    [SerializeField] private GameObject ErrorBuyPanel;

    void Start()
    {
        BuyPanel.SetActive(false);
        ErrorBuyPanel.SetActive(false);

        PlayerPrefs.GetString("Business_Body1", Business_Body1);
        PlayerPrefs.GetString("Business_Body2", Business_Body2);
        PlayerPrefs.GetString("Business_Body3", Business_Body3);
        PlayerPrefs.GetString("Business_Hair1", Business_Hair1);
        PlayerPrefs.GetString("Business_Hair2", Business_Hair2);
        PlayerPrefs.GetString("Business_Hair3", Business_Hair3);
        PlayerPrefs.GetString("Business_Blazer1", Business_Blazer1);
        PlayerPrefs.GetString("Business_Blazer2", Business_Blazer2);
        PlayerPrefs.GetString("Business_Blazer3", Business_Blazer3);
        PlayerPrefs.GetString("Business_Pants1", Business_Pants1);
        PlayerPrefs.GetString("Business_Pants2", Business_Pants2);
        PlayerPrefs.GetString("Business_Pants3", Business_Pants3);
    }


    void Update()
    {
        BusinessPlayerPrefs();
        ZirilionData = PlayerPrefs.GetInt("Zirilion");
    }

    void BusinessPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("Business_Body1"))
        {
            BodyButton[0].SetActive(false);
            BodyTicket[0].SetActive(false);
        }

        if (PlayerPrefs.HasKey("Business_Body2"))
        {
            BodyButton[1].SetActive(false);
            BodyTicket[1].SetActive(false);
        }

        if (PlayerPrefs.HasKey("Business_Body3"))
        {
            BodyButton[2].SetActive(false);
            BodyTicket[2].SetActive(false);
        }

        if (PlayerPrefs.HasKey("Business_Hair1"))
        {
            HairButton[0].SetActive(false);
            HairTicket[0].SetActive(false);
        }
        if (PlayerPrefs.HasKey("Business_Hair2"))
        {
            HairButton[1].SetActive(false);
            HairTicket[1].SetActive(false);
        }
        if (PlayerPrefs.HasKey("Business_Hair3"))
        {
            HairButton[2].SetActive(false);
            HairTicket[2].SetActive(false);
        }

        if (PlayerPrefs.HasKey("Business_Blazer1"))
        {
            BlazerButton[0].SetActive(false);
            BlazerTicket[0].SetActive(false);
        }

        if (PlayerPrefs.HasKey("Business_Blazer2"))
        {
            BlazerButton[1].SetActive(false);
            BlazerTicket[1].SetActive(false);
        }

        if (PlayerPrefs.HasKey("Business_Blazer3"))
        {
            BlazerButton[2].SetActive(false);
            BlazerTicket[2].SetActive(false);
        }

        if (PlayerPrefs.HasKey("Business_Pants1"))
        {
            PantsButton[0].SetActive(false);
            PantsTicket[0].SetActive(false);
        }
        if (PlayerPrefs.HasKey("Business_Pants2"))
        {
            PantsButton[1].SetActive(false);
            PantsTicket[1].SetActive(false);
        }
        if (PlayerPrefs.HasKey("Business_Pants3"))
        {
            PantsButton[2].SetActive(false);
            PantsTicket[2].SetActive(false);
        }
    }

    public void BusinessBodyDefault()
    {
        BusinessBody.color = Colors[0];
    }

    public void BusinessBody1()
    {
        BusinessBody.color = Colors[1];
    }
    public void BusinessBody1Buy()
    {
        if (ZirilionData >= 240)
        {
            BusinessBody.color = Colors[1];
            BodyButton[0].SetActive(false);
            BodyTicket[0].SetActive(false);
            PlayerPrefs.SetString("Business_Body1", Business_Body1);
            ZirilionData -= 240;
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

    public void BusinessBody2()
    {
        BusinessBody.color = Colors[2];
    }
    public void BusinessBody2Buy()
    {
        if (ZirilionData >= 460)
        {
            BusinessBody.color = Colors[2];
            BodyButton[1].SetActive(false);
            BodyTicket[1].SetActive(false);
            PlayerPrefs.SetString("Business_Body2", Business_Body2);
            ZirilionData -= 460;
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
    public void BusinessBody3()
    {
        BusinessBody.color = Colors[2];
    }
    public void BusinessBody3Buy()
    {
        if (ZirilionData >= 600)
        {
            BusinessBody.color = Colors[3];
            BodyButton[2].SetActive(false);
            BodyTicket[2].SetActive(false);
            PlayerPrefs.SetString("Business_Body3", Business_Body3);
            ZirilionData -= 600;
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

    /////////////////////////////////////////////////////////  HAIR
    ///

    public void BusinessHairDefault()
    {
        BusinessHair.color = Colors[4];
    }
    public void BusinessHair1()
    {
        BusinessHair.color = Colors[5];
    }
    public void BusinessHair1Buy()
    {
        if (ZirilionData >= 190)
        {
            BusinessHair.color = Colors[5];
            HairButton[0].SetActive(false);
            HairTicket[0].SetActive(false);
            PlayerPrefs.SetString("Business_Hair1", Business_Hair1);
            ZirilionData -= 190;
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
    public void BusinessHair2()
    {
        BusinessHair.color = Colors[6];
    }
    public void BusinessHair2Buy()
    {
        if (ZirilionData >= 369)
        {
            BusinessHair.color = Colors[6];
            HairButton[1].SetActive(false);
            HairTicket[1].SetActive(false);
            PlayerPrefs.SetString("Business_Hair2", Business_Hair2);
            ZirilionData -= 369;
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
    public void BusinessHair3()
    {
        BusinessHair.color = Colors[7];
    }
    public void BusinessHair3Buy()
    {
        if (ZirilionData >= 467)
        {
            BusinessHair.color = Colors[7];
            HairButton[2].SetActive(false);
            HairTicket[2].SetActive(false);
            PlayerPrefs.SetString("Business_Hair3", Business_Hair3);
            ZirilionData -= 467;
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
   
   //////////////////////////////////////////////////////  BLAZER
   ///

   public void BusinessBlazerDefault()
   {
        BusinessBlazer.color = Colors[8];
   }

    public void BusinessBlazer1()
    {
        BusinessBlazer.color = Colors[9];
    }
    public void BusinessBlazer1Buy()
    {
        if (ZirilionData >= 245)
        {
            BusinessBlazer.color = Colors[9];
            BlazerButton[0].SetActive(false);
            BlazerTicket[0].SetActive(false);
            PlayerPrefs.SetString("Business_Blazer1", Business_Blazer1);
            ZirilionData -= 245;
            PlayerPrefs.SetInt("Zirilion", ZirilionData);
            BuyPanel.SetActive(true);
            StartCoroutine(BuyController());
        }
        else
        {

            ErrorBuyPanel.SetActive(true);
            StartCoroutine(BuyController());
            BlazerButton[0].SetActive(true);
            BlazerTicket[0].SetActive(true);
        }
    }

    public void BusinessBlazer2()
    {
        BusinessBlazer.color = Colors[10];
    }
    public void BusinessBlazer2Buy()
    {
        if (ZirilionData >= 324)
        {
            BusinessBlazer.color = Colors[10];
            BlazerButton[1].SetActive(false);
            BlazerTicket[1].SetActive(false);
            PlayerPrefs.SetString("Business_Blazer2", Business_Blazer2);
            ZirilionData -= 324;
            PlayerPrefs.SetInt("Zirilion", ZirilionData);
            BuyPanel.SetActive(true);
            StartCoroutine(BuyController());
        }
        else
        {

            ErrorBuyPanel.SetActive(true);
            StartCoroutine(BuyController());
            BlazerButton[1].SetActive(true);
            BlazerTicket[1].SetActive(true);
        }
    }
    public void BusinessBlazer3()
    {
        BusinessBlazer.color = Colors[11];
    }
    public void BusinessBlazer3Buy()
    {
        if (ZirilionData >= 355)
        {
            BusinessBlazer.color = Colors[11];
            BlazerButton[2].SetActive(false);
            BlazerTicket[2].SetActive(false);
            PlayerPrefs.SetString("Business_Blazer3", Business_Blazer3);
            ZirilionData -= 355;
            PlayerPrefs.SetInt("Zirilion", ZirilionData);
            BuyPanel.SetActive(true);
            StartCoroutine(BuyController());
        }
        else
        {

            ErrorBuyPanel.SetActive(true);
            StartCoroutine(BuyController());
            BlazerButton[2].SetActive(true);
            BlazerTicket[2].SetActive(true);
        }
    }
    
    ///////////////////////////////////////////////////////////  PANTS
    ///

    public void BusinessPantsDefault()
    {
        BusinessPants.color = Colors[12];
    }

    public void BusinessPants1()
    {
        BusinessPants.color = Colors[13];
    }
    public void BusinessPants1Buy()
    {
        if (ZirilionData >= 285)
        {
            BusinessPants.color = Colors[13];
            PantsButton[0].SetActive(false);
            PantsTicket[0].SetActive(false);
            PlayerPrefs.SetString("Business_Pants1", Business_Pants1);
            ZirilionData -= 285;
            PlayerPrefs.SetInt("Zirilion", ZirilionData);
            BuyPanel.SetActive(true);
            StartCoroutine(BuyController());
        }
        else
        {

            ErrorBuyPanel.SetActive(true);
            StartCoroutine(BuyController());
            PantsButton[0].SetActive(true);
            PantsTicket[0].SetActive(true);
        }
    }

    public void BusinessPants2()
    {
        BusinessPants.color = Colors[14];
    }
    public void BusinessPants2Buy()
    {
        if (ZirilionData >= 344)
        {
            BusinessPants.color = Colors[14];
            PantsButton[1].SetActive(false);
            PantsTicket[1].SetActive(false);
            PlayerPrefs.SetString("Business_Pants2", Business_Pants2);
            ZirilionData -= 344;
            PlayerPrefs.SetInt("Zirilion", ZirilionData);
            BuyPanel.SetActive(true);
            StartCoroutine(BuyController());
        }
        else
        {

            ErrorBuyPanel.SetActive(true);
            StartCoroutine(BuyController());
            PantsButton[1].SetActive(true);
            PantsTicket[1].SetActive(true);
        }
    }
    public void BusinessPants3()
    {
        BusinessPants.color = Colors[15];
    }
    public void BusinessPants3Buy()
    {
        if (ZirilionData >= 456)
        {
            BusinessPants.color = Colors[15];
            PantsButton[2].SetActive(false);
            PantsTicket[2].SetActive(false);
            PlayerPrefs.SetString("Business_Pants3", Business_Pants3);
            ZirilionData -= 456;
            PlayerPrefs.SetInt("Zirilion", ZirilionData);
            BuyPanel.SetActive(true);
            StartCoroutine(BuyController());
        }
        else
        {

            ErrorBuyPanel.SetActive(true);
            StartCoroutine(BuyController());
            PantsButton[2].SetActive(true);
            PantsTicket[2].SetActive(true);
        }
    }

    IEnumerator BuyController()
    {
        yield return new WaitForSeconds(2);
        BuyPanel.SetActive(false);
        ErrorBuyPanel.SetActive(false);
    }

}
