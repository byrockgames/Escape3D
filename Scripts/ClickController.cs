using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ClickController : MonoBehaviour
{
    [SerializeField] private int HighScoreData;

    void Start()
    {
        HighScoreData = PlayerPrefs.GetInt("HighScore");
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    // LeaderBoard
    public void LeaderBoardPanel()
    {
        CloudOnceServices.instance.SubmitScoreLeaderBoard(HighScoreData);
    }
    // Hospital 1 Play Again
    public void PlayAgainHostipal1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Hospital");
    }
    // Hospital 2 Play Again
    public void PlayAgainHostipal2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Hospital2");
    }
    // Hospital 2 Play Again
    public void PlayAgainHostipal3()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Hospital3");
    }
    
    // School 1 Play Again
    public void PlayAgainSchool()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("School");
    }

    // School 2 Play Again
    public void PlayAgainSchool2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("School2");
    }

    // School 3 Play Again
    public void PlayAgainSchool3()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("School3");
    }
    
    // Street 1 Play Again
    public void PlayAgainStreet1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Street");
    }

    // Street 2 Play Again
    public void PlayAgainStreet2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Street2");
    }

    // Office 1 Play Again
    public void PlayAgainOffice1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Office");
    }

    // Office 2 Play Again
    public void PlayAgainOffice2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Office2");
    }


}
