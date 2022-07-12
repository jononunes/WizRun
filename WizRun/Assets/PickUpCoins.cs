using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpCoins : MonoBehaviour
{
    public Text coinsText;

    public float coinsCount;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
        anim = GetComponent<Animator>();
        coinsText = GameObject.FindGameObjectWithTag("coinText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = "WizCoins: " + coinsCount;
        
    }


    private IEnumerator DoAnimation()
    {
        anim.SetTrigger("Collected");
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.name == "Wiz_0")
        {
            coinsCount = coinsCount + 10;
            StartCoroutine(DoAnimation());
        }


    }
}
