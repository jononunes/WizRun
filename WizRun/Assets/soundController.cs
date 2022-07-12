using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundController : MonoBehaviour
{
    public Button muteSoundsFalse;
    public Button muteSoundsTrue;
    public Button muteMusicFalse;
    public Button muteMusicTrue;
    public AudioSource[] bgMusic;
    public int musicSelector;

    // Start is called before the first frame update
    void Start()
    {

        musicSelector = Random.Range(0, 4);
        


        if (PlayerPrefs.HasKey("MuteAllSounds"))
        {
            if(PlayerPrefs.GetInt("MuteAllSounds") == 1)
            {
                AudioListener.pause = true;
                muteSoundsTrue.gameObject.SetActive(true);
                muteSoundsFalse.gameObject.SetActive(false);
                
            }
            else if (PlayerPrefs.GetInt("MuteAllSounds") == 0)
            {
                AudioListener.pause = false;
                muteSoundsTrue.gameObject.SetActive(false);
                muteSoundsFalse.gameObject.SetActive(true);
                
            }
        }


        if (PlayerPrefs.HasKey("MuteAllMusic"))
        {
            if(PlayerPrefs.GetInt("MuteAllMusic") == 1)
            {
                bgMusic[musicSelector].Pause();
                muteMusicTrue.gameObject.SetActive(true);
                muteMusicFalse.gameObject.SetActive(false);
            }
            else
            {
                bgMusic[musicSelector].Play();
                muteMusicTrue.gameObject.SetActive(false);
                muteMusicFalse.gameObject.SetActive(true);
            }
        }
        else
        {
            bgMusic[musicSelector].Play();
        }




        

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("MuteAllSounds") == 1)
        {
            AudioListener.pause = true;
            

        }
        else if (PlayerPrefs.GetInt("MuteAllSounds") == 0)
        {
            AudioListener.pause = false;
            

        }

        if(PlayerPrefs.GetInt("MuteAllMusic") == 1)
        {
            bgMusic[musicSelector].Pause();
        }
        

    }


    public void muteMusic()
    {
        bgMusic[musicSelector].Pause();
        muteMusicTrue.gameObject.SetActive(true);
        muteMusicFalse.gameObject.SetActive(false);
        PlayerPrefs.SetInt("MuteAllMusic", 1);
    }

    public void unmuteMusic()
    {
        bgMusic[musicSelector].Play();
        muteMusicTrue.gameObject.SetActive(false);
        muteMusicFalse.gameObject.SetActive(true);
        PlayerPrefs.SetInt("MuteAllMusic", 0);
    }

    public void muteSounds()
    {
        AudioListener.pause = true;
        muteSoundsTrue.gameObject.SetActive(true);
        muteSoundsFalse.gameObject.SetActive(false);
        PlayerPrefs.SetInt("MuteAllSounds", 1);
    }

    public void unmuteSounds()
    {
        AudioListener.pause = true;
        muteSoundsTrue.gameObject.SetActive(false);
        muteSoundsFalse.gameObject.SetActive(true);
        PlayerPrefs.SetInt("MuteAllSounds", 0);
    }
}
