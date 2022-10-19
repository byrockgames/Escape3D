using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildItemController : MonoBehaviour
{

    [Header("Child Item Material")]
    [SerializeField] private Material ChildBody;
    [SerializeField] private Material ChildClothes;

    [Header("Child Color")]
    [SerializeField] private Color[] Colors;

    [Header("Child Button")]
    [SerializeField] private GameObject[] BodyButton;
    [SerializeField] private GameObject[] ClothesButton;

    [Header("Child Ticket")]
    [SerializeField] private GameObject[] BodyTicket;
    [SerializeField] private GameObject[] ClothesTicket;

    [Header("Child PlayerPrefs")]
    private string Child_Body1;
    private string Child_Body2;
    private string Child_Body3;
    private string Child_Clothes1;
    private string Child_Clothes2;
    private string Child_Clothes3;

    [Header("Data")]
    [SerializeField] private int ZirilionData;

    [Header("BUY-ERROR Panel")]
    [SerializeField] private GameObject BuyPanel;
    [SerializeField] private GameObject ErrorBuyPanel;
   
    void Start()
    {
        BuyPanel.SetActive(false);
        ErrorBuyPanel.SetActive(false);

        PlayerPrefs.GetString("Child_Body1", Child_Body1);
        PlayerPrefs.GetString("Child_Body2", Child_Body2);
        PlayerPrefs.GetString("Child_Body3", Child_Body3);
        PlayerPrefs.GetString("Child_Clothes1", Child_Clothes1);
        PlayerPrefs.GetString("Child_Clothes2", Child_Clothes2);
        PlayerPrefs.GetString("Child_Clothes3", Child_Clothes3);
    }

  
    void Update()
    {
        ChildPlayerPrefs();
        ZirilionData = PlayerPrefs.GetInt("Zirilion");
    }
    
    void ChildPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("Child_Body1"))
        {
            BodyButton[0].SetActive(false);
            BodyTicket[0].SetActive(false);
        }

        if (PlayerPrefs.HasKey("Child_Body2"))
        {
            BodyButton[1].SetActive(false);
            BodyTicket[1].SetActive(false);
        }

        if (PlayerPrefs.HasKey("Child_Body3"))
        {
            BodyButton[2].SetActive(false);
            BodyTicket[2].SetActive(false);
        }

        if (PlayerPrefs.HasKey("Child_Clothes1"))
        {
            ClothesButton[0].SetActive(false);
            ClothesTicket[0].SetActive(false);
        }
        if (PlayerPrefs.HasKey("Child_Clothes2"))
        {
            ClothesButton[1].SetActive(false);
            ClothesTicket[1].SetActive(false);
        }
        if (PlayerPrefs.HasKey("Child_Clothes3"))
        {
            ClothesButton[2].SetActive(false);
            ClothesTicket[2].SetActive(false);
        }

    }


    public void ChildBodyDefault()
    {
        ChildBody.color = Colors[0];
    }

    public void ChildBody1()
    {
        ChildBody.color = Colors[1];
    }
    public void ChildBody1Buy()
    {
        if (ZirilionData >= 200)
        {
            ChildBody.color = Colors[1];
            BodyButton[0].SetActive(false);
            BodyTicket[0].SetActive(false);
            PlayerPrefs.SetString("Child_Body1", Child_Body1);
            ZirilionData -= 200;
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

    public void ChildBody2()
    {
        ChildBody.color = Colors[2];
    }
    public void ChildBody2Buy()
    {
        if (ZirilionData >= 220)
        {
            ChildBody.color = Colors[2];
            BodyButton[1].SetActive(false);
            BodyTicket[1].SetActive(false);
            PlayerPrefs.SetString("Child_Body2", Child_Body2);
            ZirilionData -= 220;
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

    public void ChildBody3()
    {
        ChildBody.color = Colors[3];
    }
    public void ChildBody3Buy()
    {
        if (ZirilionData >= 250)
        {
            ChildBody.color = Colors[3];
            BodyButton[2].SetActive(false);
            BodyTicket[2].SetActive(false);
            PlayerPrefs.SetString("Child_Body3", Child_Body3);
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
     
     //////////////////////////////////////////////  CLOTHES
     
    public void ChildClothesDefault()
    {
        ChildClothes.color = Colors[4];
    }

    public void ChildClothes1()
    {
        ChildClothes.color = Colors[5];
    }
    public void ChildClothes1Buy()
    {
        if (ZirilionData >= 240)
        {
            ChildClothes.color = Colors[5];
            ClothesButton[0].SetActive(false);
            ClothesTicket[0].SetActive(false);
            PlayerPrefs.SetString("Child_Clothes1", Child_Clothes1);
            ZirilionData -= 240;
            PlayerPrefs.SetInt("Zirilion", ZirilionData);
            BuyPanel.SetActive(true);
            StartCoroutine(BuyController());
        }
        else
        {
            ErrorBuyPanel.SetActive(true);
            StartCoroutine(BuyController());
            ClothesButton[0].SetActive(true);
            ClothesTicket[0].SetActive(true);
        }
    }

    public void ChildClothes2()
    {
        ChildClothes.color = Colors[6];
    }
    public void ChildClothes2Buy()
    {
        if (ZirilionData >= 270)
        {
            ChildClothes.color = Colors[6];
            ClothesButton[1].SetActive(false);
            ClothesTicket[1].SetActive(false);
            PlayerPrefs.SetString("Child_Clothes2", Child_Clothes2);
            ZirilionData -= 270;
            PlayerPrefs.SetInt("Zirilion", ZirilionData);
            BuyPanel.SetActive(true);
            StartCoroutine(BuyController());
        }
        else
        {
            ErrorBuyPanel.SetActive(true);
            StartCoroutine(BuyController());
            ClothesButton[1].SetActive(true);
            ClothesTicket[1].SetActive(true);
        }
    }
    public void ChildClothes3()
    {
        ChildClothes.color = Colors[7];
    }
    public void ChildClothes3Buy()
    {
        if (ZirilionData >= 370)
        {
            ChildClothes.color = Colors[7];
            ClothesButton[2].SetActive(false);
            ClothesTicket[2].SetActive(false);
            PlayerPrefs.SetString("Child_Clothes3", Child_Clothes3);
            ZirilionData -= 370;
            PlayerPrefs.SetInt("Zirilion", ZirilionData);
            BuyPanel.SetActive(true);
            StartCoroutine(BuyController());
        }
        else
        {
            ErrorBuyPanel.SetActive(true);
            StartCoroutine(BuyController());
            ClothesButton[2].SetActive(true);
            ClothesTicket[2].SetActive(true);
        }
    }
    IEnumerator BuyController()
    {
        yield return new WaitForSeconds(2);
        BuyPanel.SetActive(false);
        ErrorBuyPanel.SetActive(false);
    }
    
}
