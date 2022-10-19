using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouthItemController : MonoBehaviour
{

    [Header("Youth Item Material")]
    [SerializeField] private Material YouthTshirt;
    [SerializeField] private Material YouthShort;

    [Header("Youth Color")]
    [SerializeField] private Color[] Colors;

    [Header("Youth Button")]
    [SerializeField] private GameObject[] TshirtButton;
    [SerializeField] private GameObject[] ShortButton;

    [Header("Youth Ticket")]
    [SerializeField] private GameObject[] TshirtTicket;
    [SerializeField] private GameObject[] ShortTicket;

    [Header("Youth PlayerPrefs")]
    private string Youth_Tshirt1;
    private string Youth_Tshirt2;
    private string Youth_Tshirt3;
    private string Youth_Short1;
    private string Youth_Short2;
    private string Youth_Short3;

    [Header("Data")]
    [SerializeField] private int ZirilionData;

    [Header("BUY-ERROR Panel")]
    [SerializeField] private GameObject BuyPanel;
    [SerializeField] private GameObject ErrorBuyPanel;

    void Start()
    {
        BuyPanel.SetActive(false);
        ErrorBuyPanel.SetActive(false);

        PlayerPrefs.GetString("Youth_Tshirt1", Youth_Tshirt1);
        PlayerPrefs.GetString("Youth_Tshirt2", Youth_Tshirt2);
        PlayerPrefs.GetString("Youth_Tshirt3", Youth_Tshirt3);
        PlayerPrefs.GetString("Youth_Short1", Youth_Short1);
        PlayerPrefs.GetString("Youth_Short2", Youth_Short2);
        PlayerPrefs.GetString("Youth_Short3", Youth_Short3);

    }

    void Update()
    {
        YouthPlayerPrefs();
        ZirilionData = PlayerPrefs.GetInt("Zirilion");
    }
    void YouthPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("Youth_Tshirt1"))
        {
            TshirtButton[0].SetActive(false);
            TshirtTicket[0].SetActive(false);
        }

        if (PlayerPrefs.HasKey("Youth_Tshirt2"))
        {
            TshirtButton[1].SetActive(false);
            TshirtTicket[1].SetActive(false);
        }

        if (PlayerPrefs.HasKey("Youth_Tshirt3"))
        {
            TshirtButton[2].SetActive(false);
            TshirtTicket[2].SetActive(false);
        }

        if (PlayerPrefs.HasKey("Youth_Short1"))
        {
            ShortButton[0].SetActive(false);
            ShortTicket[0].SetActive(false);
        }
        if (PlayerPrefs.HasKey("Youth_Short2"))
        {
            ShortButton[1].SetActive(false);
            ShortTicket[1].SetActive(false);
        }
        if (PlayerPrefs.HasKey("Youth_Short3"))
        {
            ShortButton[2].SetActive(false);
            ShortTicket[2].SetActive(false);
        }

    }

    public void YouthTshirtDefault()
    {
        YouthTshirt.color = Colors[0];
    }

    public void YouthTshirt1()
    {
        YouthTshirt.color = Colors[1];
    }

    public void YouthTshirt1Buy()
    {
        if (ZirilionData >= 176)
        {
            YouthTshirt.color = Colors[1];
            TshirtButton[0].SetActive(false);
            TshirtTicket[0].SetActive(false);
            PlayerPrefs.SetString("Youth_Tshirt1", Youth_Tshirt1);
            ZirilionData -= 176;
            PlayerPrefs.SetInt("Zirilion", ZirilionData);
            BuyPanel.SetActive(true);
            StartCoroutine(BuyController());
        }
        else
        {
            ErrorBuyPanel.SetActive(true);
            StartCoroutine(BuyController());
            TshirtButton[0].SetActive(true);
            TshirtTicket[0].SetActive(true);
        }

    }

    public void YouthTshirt2()
    {
        YouthTshirt.color = Colors[2];
    }

    public void YouthTshirt2Buy()
    {
        if (ZirilionData >= 268)
        {
            YouthTshirt.color = Colors[2];
            TshirtButton[1].SetActive(false);
            TshirtTicket[1].SetActive(false);
            PlayerPrefs.SetString("Youth_Tshirt2", Youth_Tshirt2);
            ZirilionData -= 268;
            PlayerPrefs.SetInt("Zirilion", ZirilionData);
            BuyPanel.SetActive(true);
            StartCoroutine(BuyController());
        }
        else
        {
            ErrorBuyPanel.SetActive(true);
            StartCoroutine(BuyController());
            TshirtButton[1].SetActive(true);
            TshirtTicket[1].SetActive(true);
        }

    }

    public void YouthTshirt3()
    {
        YouthTshirt.color = Colors[3];
    }

    public void YouthTshirt3Buy()
    {
        if (ZirilionData >= 344)
        {
            YouthTshirt.color = Colors[3];
            TshirtButton[2].SetActive(false);
            TshirtTicket[2].SetActive(false);
            PlayerPrefs.SetString("Youth_Tshirt3", Youth_Tshirt3);
            ZirilionData -= 344;
            PlayerPrefs.SetInt("Zirilion", ZirilionData);
            BuyPanel.SetActive(true);
            StartCoroutine(BuyController());
        }
        else
        {
            ErrorBuyPanel.SetActive(true);
            StartCoroutine(BuyController());
            TshirtButton[2].SetActive(true);
            TshirtTicket[2].SetActive(true);
        }

    }

    //////////////////////////////////////////////////////////////// SHORT
    
    public void YouthShortDefault()
    {
        YouthShort.color = Colors[4];
    }

    public void YouthShort1()
    {
        YouthShort.color = Colors[5];
    }

    public void YouthShort1Buy()
    {
        if (ZirilionData >= 179)
        {
            YouthShort.color = Colors[5];
            ShortButton[0].SetActive(false);
            ShortTicket[0].SetActive(false);
            PlayerPrefs.SetString("Youth_Short1", Youth_Short1);
            ZirilionData -= 179;
            PlayerPrefs.SetInt("Zirilion", ZirilionData);
            BuyPanel.SetActive(true);
            StartCoroutine(BuyController());
        }
        else
        {
            ErrorBuyPanel.SetActive(true);
            StartCoroutine(BuyController());
            ShortButton[0].SetActive(true);
            ShortTicket[0].SetActive(true);
        }

    }

    public void YouthShort2()
    {
        YouthShort.color = Colors[6];
    }

    public void YouthShort2Buy()
    {
        if (ZirilionData >= 238)
        {
            YouthShort.color = Colors[6];
            ShortButton[1].SetActive(false);
            ShortTicket[1].SetActive(false);
            PlayerPrefs.SetString("Youth_Short2", Youth_Short2);
            ZirilionData -= 238;
            PlayerPrefs.SetInt("Zirilion", ZirilionData);
            BuyPanel.SetActive(true);
            StartCoroutine(BuyController());
        }
        else
        {
            ErrorBuyPanel.SetActive(true);
            StartCoroutine(BuyController());
            ShortButton[1].SetActive(true);
            ShortTicket[1].SetActive(true);
        }

    }

    public void YouthShort3()
    {
        YouthShort.color = Colors[7];
    }

    public void YouthShort3Buy()
    {
        if (ZirilionData >= 459)
        {
            YouthShort.color = Colors[7];
            ShortButton[2].SetActive(false);
            ShortTicket[2].SetActive(false);
            PlayerPrefs.SetString("Youth_Short3", Youth_Short3);
            ZirilionData -= 459;
            PlayerPrefs.SetInt("Zirilion", ZirilionData);
            BuyPanel.SetActive(true);
            StartCoroutine(BuyController());
        }
        else
        {
            ErrorBuyPanel.SetActive(true);
            StartCoroutine(BuyController());
            ShortButton[2].SetActive(true);
            ShortTicket[2].SetActive(true);
        }

    }

    IEnumerator BuyController()
    {
        yield return new WaitForSeconds(2);
        BuyPanel.SetActive(false);
        ErrorBuyPanel.SetActive(false);
    }

}
