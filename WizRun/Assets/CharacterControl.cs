using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public GameObject[] characters;
    // Start is called before the first frame update
    void Start()
    {
        characters[PlayerPrefs.GetInt("SelectedCharacter")].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
