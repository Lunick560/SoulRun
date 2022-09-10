using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float speedMultiplier;


   
    public float speedIncreaseMilestone;
    private float speedIncreasedMilestoneStore;
    private float speedMilestoneCount;
    private float speedMilestoneCountStore;
    private float speedStore;

    public float jumpTime;
    public float jumpTimeCounter;

    private bool stoppedJumping;
    private bool canDoubleJump;

    public bool onTheGround;
    public Transform GroundCheck;
    public float groundCheckRadius;
    public LayerMask checkGround;

    private Rigidbody2D rigibody;
    //private Collider2D collider;
    private Animator animator;

    public GameManager gameManager;

    public AudioSource jumpSound;
    public AudioSource deathSound;

    // Start is called before the first frame update
    void Start()
    {
        rigibody = GetComponent<Rigidbody2D>();
        // collider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();

        jumpTimeCounter = jumpTime;
        speedMilestoneCount = speedIncreaseMilestone;
        speedStore = speed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreasedMilestoneStore = speedIncreaseMilestone;

        stoppedJumping = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Check on ground
        onTheGround = Physics2D.OverlapCircle(GroundCheck.position,groundCheckRadius,checkGround);
        //Count when we will speed up
        if(transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;


            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            speed = speed*speedMultiplier;
        }

        //If no jumping we keep running
        rigibody.velocity = new Vector2(speed, rigibody.velocity.y);
        //Else we will jump



        //Press space or finger down
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)|| (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) {
            if (onTheGround)
            {
                rigibody.velocity = new Vector2(rigibody.velocity.x, jumpForce);
                stoppedJumping = false;
                jumpSound.Play();
            }
            //Double jump
            if (!onTheGround && canDoubleJump)
            {
                jumpTimeCounter = jumpTime;
                rigibody.velocity = new Vector2(rigibody.velocity.x, jumpForce);
                stoppedJumping = false;
                canDoubleJump = false;
                jumpSound.Play();
            }



        }
        //Press space or finger down
       
            if (Input.touchCount>0&&Input.GetTouch(0).phase == TouchPhase.Began&&!stoppedJumping)
            {
                if (jumpTimeCounter > 0)
                {
                    rigibody.velocity = new Vector2(rigibody.velocity.x, jumpForce);
                    jumpTimeCounter -= Time.deltaTime;
                }
            }

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                jumpTimeCounter = 0;
                stoppedJumping = true;
        }
        
        
        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && !stoppedJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rigibody.velocity = new Vector2(rigibody.velocity.x, jumpForce);
                jumpTimeCounter = jumpTimeCounter - Time.deltaTime;
            }
        }
        //Press space or finger up
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }
        

        if (onTheGround)
        {
            jumpTimeCounter = jumpTime;
            canDoubleJump = true;
        }

            //animatorSection
            animator.SetFloat("Running", rigibody.velocity.x);


        if (rigibody.velocity.y < -0.1)
        {
            animator.SetBool("Fall", true);
            animator.SetBool("Jump", false);
        }

        if (rigibody.velocity.y > 0)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Fall", false);
        }

        if(rigibody.velocity.y ==0)
        {
            animator.SetBool("Fall", false);
            animator.SetBool("Jump", false);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "DeathFall")
        {
            gameManager.RestartGames();
            speed = speedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreasedMilestoneStore;
            deathSound.Play();
        }
    }
}
