using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public Image[] characterImage;
    public Text[] characterName;
    public Text[] characterCost;
    public int currentCharacterNumber;
    public float[] currentCharacterCost = {-1, 100, 150, 200, 250, 500, 750, 1000, 1250, 1500, 1750, 2000, 2250, 2500, 2750, 3000, 3500, 4000, 4500, 5000, 6000, 8000, 10000};
    public Button nextButton;
    public Button previousButton;
    public Button selectButton;

    public Sprite selectImage;
    public Sprite selectedImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(currentCharacterNumber == PlayerPrefs.GetInt("SelectedCharacter"))
        {
            selectButton.interactable = false;
            selectButton.GetComponent<Image>().sprite = selectedImage;
        }
        else
        {
            selectButton.interactable = true;
            selectButton.GetComponent<Image>().sprite = selectImage;
        }

        if(currentCharacterNumber == 0)
        {
            previousButton.interactable = false;
        }
        else
        {
            previousButton.interactable = true;
        }

        if(currentCharacterNumber == characterImage.Length - 1)
        {
            nextButton.interactable = false;
        }
        else
        {
            nextButton.interactable = true;
        }
    }


    public void nextCharacter()
    {
        characterImage[currentCharacterNumber].gameObject.SetActive(false);
        characterImage[currentCharacterNumber+1].gameObject.SetActive(true);

        characterName[currentCharacterNumber].gameObject.SetActive(false);
        characterName[currentCharacterNumber + 1].gameObject.SetActive(true);

        
        characterCost[currentCharacterNumber].gameObject.SetActive(false);
        if(currentCharacterCost[currentCharacterNumber + 1] >= PlayerPrefs.GetFloat("TotalWizXP"))
        {
            selectButton.gameObject.SetActive(false);
            characterCost[currentCharacterNumber + 1].gameObject.SetActive(true);
        }
        else
        {
            selectButton.gameObject.SetActive(true);
            characterCost[currentCharacterNumber + 1].gameObject.SetActive(false);
        }
        


        currentCharacterNumber += 1;
    }

    public void previousCharacter()
    {
        characterImage[currentCharacterNumber].gameObject.SetActive(false);
        characterImage[currentCharacterNumber - 1].gameObject.SetActive(true);

        characterName[currentCharacterNumber].gameObject.SetActive(false);
        characterName[currentCharacterNumber - 1].gameObject.SetActive(true);

        characterCost[currentCharacterNumber].gameObject.SetActive(false);
        if (currentCharacterCost[currentCharacterNumber - 1] >= PlayerPrefs.GetFloat("TotalWizXP"))
        {
            selectButton.gameObject.SetActive(false);
            characterCost[currentCharacterNumber - 1].gameObject.SetActive(true);
        }
        else
        {
            selectButton.gameObject.SetActive(true);
            characterCost[currentCharacterNumber - 1].gameObject.SetActive(false);
        }

        currentCharacterNumber += -1;
    }

    public void SelectCharacter()
    {
        PlayerPrefs.SetInt("SelectedCharacter", currentCharacterNumber);
        
    }
}
