using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public void PauseGame()
    {
        
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
       // adManager.instance.ShowFullScreenAd();
    }

    public void ResumeGame()
    {
        
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
}
