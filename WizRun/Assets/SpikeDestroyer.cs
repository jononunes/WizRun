using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDestroyer : MonoBehaviour
{
    public GameObject spikeDestructionPoint;
    // Start is called before the first frame update
    void Start()
    {
        spikeDestructionPoint = GameObject.Find("SpikeDestroyPoint"); 
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < spikeDestructionPoint.transform.position.x)
        {
            //Destroy(gameObject);

            gameObject.SetActive(false);
        }
    }
}
