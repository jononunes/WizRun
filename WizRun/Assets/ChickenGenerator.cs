using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenGenerator : MonoBehaviour
{
    public GameObject chicken;
    public Transform generationPoint;
    public float distanceBetween2;

    private float chickenWidth;

    public float distanceBetweenMin2;
    public float distanceBetweenMax2;

    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        chickenWidth = (chicken.GetComponent<CircleCollider2D>().radius)*2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < generationPoint.position.x)
        {

            distanceBetween2 = Random.Range(distanceBetweenMin2, distanceBetweenMax2);

            transform.position = new Vector3(transform.position.x + chickenWidth + distanceBetween2, transform.position.y, transform.position.z);

            Instantiate(chicken, transform.position, transform.rotation);

            
            
        }
    }
}
