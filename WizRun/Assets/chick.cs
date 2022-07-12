using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chick : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D rb2d;
    private CircleCollider2D myCollider;
    public AudioSource chickSound;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
        myCollider = GetComponent<CircleCollider2D>();

        chickSound = GameObject.Find("ChickSound").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            chickSound.Play();
        }
    }
}
