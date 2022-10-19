using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Splash : MonoBehaviour
{
   [SerializeField]  Slider LoadingSlider;

    void Start()
    {
        StartCoroutine(Opening());
        StartCoroutine(TimerController());
        LoadingSlider.value = 0.5f;
    }

    void Update()
    {   

      TimerController();
    
    }

    IEnumerator Opening()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("MainMenu");
        LoadingSlider.value += 0.25f;
    }
    IEnumerator TimerController()
    {
        yield return new WaitForSeconds(2);
        LoadingSlider.value += 0.25f; 
    }
    
}
