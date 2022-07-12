using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using System;

public class authenticateUser : MonoBehaviour
{
    public string mainMenuLevel;
    // Start is called before the first frame update
    void Start()
    {
        AuthenticateUser();
    }

    // Update is called once per frame
    void AuthenticateUser()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) =>
        {
            if (success == true)
            {
                Debug.Log("Logged in to Google Play Games Services");
                Application.LoadLevel(mainMenuLevel);
            }
            else
            {
                Debug.LogError("Unable to sign in to Google Play Games Services");
                Application.LoadLevel(mainMenuLevel);
            }
        });
    } 
}
