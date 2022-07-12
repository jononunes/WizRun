using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wizard : MonoBehaviour
{

    public float jumpForce;
    public float moveSpeed;
    private float moveSpeedStore;
    public AdScript adManager;

    public float speedMultiplier;

    public float speedIncreaseMilestone;
    private float speedIncreaseMilestoneStore;

    private float speedMilestoneCount;
    private float speedMilestoneCountStore;

    private ScoreManager theScoreManager;

    public Swipe swipeControls;

    private bool isDead = false;

    public Text instructionText;

    private Rigidbody2D rb2d;
    private Animator anim;

    public bool isGrounded;
    public LayerMask whatIsGround;

    private CapsuleCollider2D myCollider;

    public DeathMenu theDeathScreen;

    public AudioSource jumpSound;
    public AudioSource deathSound;
    public AudioSource slideSound;
    public AudioSource swipeDownSound;
    public AudioSource menuSwooshSound;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator>();
        myCollider = GetComponent<CapsuleCollider2D>();
        speedMilestoneCount = speedIncreaseMilestone;

        moveSpeedStore = moveSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;

        theScoreManager = FindObjectOfType<ScoreManager>();

        adManager.showBanner();

        //adManager.instance.RequestBanner();

        
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        if(transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;

            moveSpeed = moveSpeed * speedMultiplier;
        }

        rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
        if (isDead == false)
        {
            if (swipeControls.SwipeUp)
            {
                if (isGrounded)
                {
                    jumpSound.Play();
                    rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
                    if (instructionText.gameObject.active == true)
                    {
                        instructionText.gameObject.SetActive(false);
                    }
                    
                }
            }

            if (swipeControls.SwipeDown)
            {
                if (isGrounded)
                {
                    
                    
                    if (instructionText.gameObject.active == true)
                    {
                        instructionText.gameObject.SetActive(false);
                    }




                }

                else
                {
                    swipeDownSound.Play();
                    rb2d.gravityScale = 4;
                    if (instructionText.gameObject.active == true)
                    {
                        instructionText.gameObject.SetActive(false);
                    }

                }
            }

            if (isGrounded)
            {
                rb2d.gravityScale = 1.5f;
            }
            anim.SetFloat("Speed", rb2d.velocity.x);
            anim.SetBool("Grounded", isGrounded);
            
          
        }
    }

    private IEnumerator DoAnimation ()
    {

        anim.SetTrigger("Dead");
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        theScoreManager.scoreText.gameObject.SetActive(false);
        theScoreManager.hiScoreText.gameObject.SetActive(false);
        if (instructionText.gameObject.active == true)
        {
            instructionText.gameObject.SetActive(false);
        }


    }



    
    

    void OnCollisionEnter2D (Collision2D other)
    {
        if(other.gameObject.tag == "killbox")
        {
            deathSound.Play();
            theScoreManager.scoreIncreasing = false;

            StartCoroutine(DoAnimation());

            
            
            moveSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;

            

            
            PlayerPrefs.SetFloat("TotalWizXP", theScoreManager.totalWizXPCount + theScoreManager.wizXPEarned);

            theDeathScreen.gameObject.SetActive(true);
            menuSwooshSound.Play();
            
            theDeathScreen.deathScoreText.text = theScoreManager.scoreText.text;
            theDeathScreen.deathHighScoreText.text = theScoreManager.hiScoreText.text;
            theDeathScreen.coinsText.text = "Wiz XP Earned: " + Mathf.Round(theScoreManager.wizXPEarned);
            
        }

        
    }


}
