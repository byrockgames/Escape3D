using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextController : MonoBehaviour
{

    public float Delay;
    public string Text;
    [Multiline]
    Text ByRockName;
   
    void Start()
    {
        ByRockName = GetComponent<Text>();
        StartCoroutine(TypeWrite());

    }

    IEnumerator TypeWrite()
    {
        foreach(char i in Text)
        {
            ByRockName.text += i.ToString();

            if (i.ToString() == ".") { yield return new WaitForSeconds(1); }
            else { yield return new WaitForSeconds(Delay); }
        }
    }

    void Update()
    {
        
    }
}
