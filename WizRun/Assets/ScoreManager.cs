using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text hiScoreText;

    public float scoreCount;
    public float hiScoreCount;
    public float wizXPEarned;

    public float totalWizXPCount;

    public float pointsPerSecond;
    public float wizXPPerSecond;
    public bool scoreIncreasing;
    
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("HighScore"))
        {
            hiScoreCount = PlayerPrefs.GetFloat("HighScore");
        }

        if (PlayerPrefs.HasKey("TotalWizXP"))
        {
            totalWizXPCount = PlayerPrefs.GetFloat("TotalWizXP");
        }
    }

    // Update is called once per frame




    void Update()
    {
        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
            wizXPEarned += wizXPPerSecond * Time.deltaTime;
            
        }
        

        if(scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", hiScoreCount);
            
            hiScoreText.color = Color.yellow;
        }

        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        hiScoreText.text = "High Score: " + Mathf.Round(hiScoreCount);
    }
}
