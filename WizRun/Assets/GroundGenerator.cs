using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    
    public GameObject thePlatform;
    public Transform generationPoint;

    private int spikeSelector;
    

    private float platformWidth;

    public ObjectPooler theObjectPool;

    //private CoinGenerator theCoinGenerator;

    public float randomCoinThreshold;

    // Start is called before the first frame update
    void Start()
    {
        platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        //theCoinGenerator = FindObjectOfType<CoinGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth - 2, transform.position.y, transform.position.z);
            //Instantiate(thePlatform, transform.position, transform.rotation);
            GameObject newPlatform = theObjectPool.GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;

            newPlatform.SetActive(true);

            //if (Random.Range(0f, 100f) < randomCoinThreshold)
           // { 
               //theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z));
           // }
            
            
        }
    }
}
