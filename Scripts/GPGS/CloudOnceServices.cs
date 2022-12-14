using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudOnce;

public class CloudOnceServices : MonoBehaviour
{
    public static CloudOnceServices instance;
    
    void Awake() 
    {
        TestSingleton();
    }
    private void TestSingleton()
    {
        if (instance != null)
        {
           Destroy(gameObject);
           return;         
        }
        
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SubmitScoreLeaderBoard(int score)
    {
        Leaderboards.HighScore.SubmitScore(score);
    }
}
