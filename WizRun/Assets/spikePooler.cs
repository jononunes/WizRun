using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikePooler : MonoBehaviour
{
    public GameObject pooledObject2;

    public int pooledAmount2;

    List<GameObject> pooledObjects2;


   
    // Start is called before the first frame update
    void Start()
    {
        pooledObjects2 = new List<GameObject>();

        for(int i = 0; i < pooledAmount2; i++)
        {
            GameObject obj2 = (GameObject) Instantiate(pooledObject2);
            obj2.SetActive(false);
            pooledObjects2.Add(obj2);
        }
    }

    public GameObject GetPooledObject2()
    {
        for(int i = 0; i < pooledObjects2.Count; i++)
        {
            if (!pooledObjects2[i].activeInHierarchy)
            {
                return pooledObjects2[i];
            }
        }

        GameObject obj2 = (GameObject)Instantiate(pooledObject2);
        obj2.SetActive(false);
        pooledObjects2.Add(obj2);

        return obj2;

    }
}
