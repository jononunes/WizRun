using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{

    public GameObject spike;
    public Transform spikeGenPoint;
    public float distanceBetween;

    private float spikeWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;
    private float[] spikeWidths;

    //public GameObject[] spikes;


    private int spikeSelector;



   public spikePooler[] spikePools;


    // Start is called before the first frame update
    void Start()
    {
        //spikeWidth = spike.GetComponent<BoxCollider2D>().size.x; 

        spikeWidths = new float[spikePools.Length];

        for(int i = 0; i < spikePools.Length; i++)
        {
            spikeWidths[i] = spikePools[i].pooledObject2.GetComponent<BoxCollider2D>().size.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(transform.position.x < spikeGenPoint.position.x)
        {

            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            spikeSelector = Random.Range(0, spikePools.Length);

            transform.position = new Vector3(transform.position.x + (spikeWidths[spikeSelector]/2) + distanceBetween, transform.position.y, transform.position.z);

            

            //Instantiate(/*spike*/spikes[spikeSelector], transform.position, transform.rotation);
            
            GameObject newSpike = spikePools[spikeSelector].GetPooledObject2();

            newSpike.transform.position = transform.position;

            newSpike.transform.rotation = transform.rotation;

            newSpike.SetActive(true);

            transform.position = new Vector3(transform.position.x + (spikeWidths[spikeSelector] / 2), transform.position.y, transform.position.z);

        } 
    }
}
