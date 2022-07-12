using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSelector : MonoBehaviour
{
    public GameObject[] backgrounds;
    public int bgSelector;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].SetActive(false);
        }

        bgSelector = Random.Range(0, backgrounds.Length);

        backgrounds[bgSelector].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
