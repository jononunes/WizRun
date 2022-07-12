using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    public string mainMenuLevel;
    public Text deathScoreText;
    public Text deathHighScoreText;
    public Text coinsText;
    public Text highScore;
    public Text newWiz;
    public float newScoreForWiz;
    public ScoreManager theScoreManager;
    public AdScript adManage;

    private void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
        if (theScoreManager.hiScoreCount < theScoreManager.scoreCount)
        {
            highScore.gameObject.SetActive(true);
        }

        


    }

    public void QuitToMain()
    {
       // adManager.instance.hideBanner();
        Application.LoadLevel(mainMenuLevel);
    }


}
