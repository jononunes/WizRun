using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenDestroyer : MonoBehaviour
{

    public GameObject chickenDestructionPoint;

    // Start is called before the first frame update
    void Start()
    {
        chickenDestructionPoint = GameObject.Find("ChickenDestroyPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < chickenDestructionPoint.transform.position.x)
        {
            Destroy(gameObject);
            
        }
    }
}
