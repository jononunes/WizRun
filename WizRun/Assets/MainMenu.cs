using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using System;

public class MainMenu : MonoBehaviour
{

    public string playGameLevel;
    public Animator anim;
    
    public Text wizxp;
    public Text highScore;

    private long scoreToPost;

    

    private void Start()
    {

        
        
        PlayGamesPlatform.Activate();
        //AuthenticateUser();
        scoreToPost = Convert.ToInt64(PlayerPrefs.GetFloat("HighScore"));
        wizxp.text = "Wiz XP: " + Mathf.Round(PlayerPrefs.GetFloat("TotalWizXP"));
        highScore.text = "High Score: " + Mathf.Round(PlayerPrefs.GetFloat("HighScore"));
        postToLeaderboard(scoreToPost);
        
        
    }


   /* void AuthenticateUser()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) =>
        {
            if (success == true)
            {
                Debug.Log("Logged in to Google Play Games Services");
            }
            else
            {
                Debug.LogError("Unable to sign in to Google Play Games Services");
            }
        });
    } */

    public void PlayGame()
    {
        StartCoroutine(PlayGameAnim());
    }


    public void ShowLeaderboardUI()
    {
        
        Social.ShowLeaderboardUI();
    }

    public void postToLeaderboard(long newScore)
    {
        Social.ReportScore(newScore, "CgkIqNbeguAQEAIQAQ", success1 => {

        });
    }

    private IEnumerator PlayGameAnim()
    {
        anim.SetTrigger("fadeOut");
        
        yield return new WaitForSeconds(2f);
        Application.LoadLevel(playGameLevel);
    }




   
    
}
