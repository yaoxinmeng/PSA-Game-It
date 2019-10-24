using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharMini : MonoBehaviour
{
    public AudioClip jumpSFX;
    public AudioClip landSFX;
    public AudioClip dieSFX;

    private AudioSource jumpSource;
    private AudioSource landSource;
    private AudioSource dieSource;

    [Range(1, 10)]
    public float walkingSpeed;
    [Range(1, 10)]
    public float jumpHeight;

    private Animator anim;
    private LevelManager levelManager;
    private Rigidbody2D rb;
    private Spriter2UnityDX.EntityRenderer ren;

    private float iniAlpha;
    private bool faceLeft = false;
    
    //[HideInInspector]
    public bool hitLWall = false;
    //[HideInInspector]
    public bool hitRWall = false;

    void Awake()
    {
        jumpSource = gameObject.AddComponent<AudioSource>();
        jumpSource.clip = jumpSFX;
        landSource = gameObject.AddComponent<AudioSource>();
        landSource.clip = landSFX;
        dieSource = gameObject.AddComponent<AudioSource>();
        dieSource.clip = dieSFX;
    }

    // Use this for initialization
    void Start()
    {
        ren = GetComponent<Spriter2UnityDX.EntityRenderer>();
        GetComponent<BoxCollider2D>().isTrigger = false;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        iniAlpha = ren.Color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (!anim.GetBool("isDead"))
        {
            if (!UiControllerMini.playerDied)
            {
                //for animation
                if (GuiController.isTappedRight && !hitRWall)
                {
                    anim.SetBool("isRunningRight", true);
                    transform.Translate(Vector3.right * walkingSpeed * Time.deltaTime);
                    hitLWall = false;
                }
                else
                    anim.SetBool("isRunningRight", false);

                if (GuiController.isTappedLeft)
                {
                    anim.SetBool("isRunningLeft", true);
                    if (!hitLWall)
                    {
                        transform.Translate(Vector3.left * walkingSpeed * Time.deltaTime);
                    }
                    hitRWall = false;
                }
                else
                {
                    anim.SetBool("isRunningLeft", false);
                    hitRWall = false;
                }

                //for jump and drop
                if (GuiController.isJumping && GuiController.isGrounded)
                {
                    jumpSource.PlayOneShot(jumpSFX, 0.8f);
                    anim.SetTrigger("isJumping");
                    rb.velocity = new Vector3(0, jumpHeight, 0);
                    GuiController.isJumping = false;
                }
                else
                    anim.SetBool("isJumping", false);

                if (GuiController.isDropping)
                {
                    gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                    rb.velocity = new Vector2(rb.velocity.x, -0.5f * jumpHeight);
                }
            }
            else
            {
                dieSource.PlayOneShot(dieSFX, 1);
                anim.SetBool("isDead", true);
            }
        }

        //establishes isTrigger based on direction of travel
        if (rb.velocity.y > 0)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            GuiController.isGrounded = false;
            GuiController.onGround = false;
        }
        else if (rb.velocity.y < 0)
        {
            if (!GuiController.isDropping)
                gameObject.GetComponent<BoxCollider2D>().isTrigger = false;

            GuiController.isGrounded = false;
            GuiController.onGround = false;
        }
        else
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;
        if (obj.tag == "Enemy")
            UiControllerMini.playerDied = true;

        if (obj.tag == "Wall")
        {
            if (obj.transform.position.x < transform.position.x)
            {
                transform.Translate(Vector3.right * obj.transform.parent.gameObject.GetComponent<Rigidbody2D>().velocity.x * Time.deltaTime);
                hitLWall = true;
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                hitRWall = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject obj = col.gameObject;
        
        if (obj.tag == "Ground" || obj.tag == "Container")
        {
            GuiController.isGrounded = true;
            landSource.PlayOneShot(landSFX, 0.5f);
        }
        if (obj.tag == "Ground")
            GuiController.onGround = true;
        if (obj.tag == "Enemy")
            UiControllerMini.playerDied = true;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Wall")
        {
            if (obj.transform.position.x < transform.position.x)
            {
                transform.Translate(Vector3.right * obj.transform.parent.gameObject.GetComponent<Rigidbody2D>().velocity.x * Time.deltaTime); 
                hitLWall = true;
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                hitRWall = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Wall")
        {
            hitRWall = false;
            hitLWall = false;
        }
    } 

    void OnCollisionStay2D(Collision2D col)
    {
        GameObject obj = col.gameObject;
        if (obj.tag == "Ground" || obj.tag == "Container")
            GuiController.isGrounded = true;
        if (obj.tag == "Ground")
            GuiController.onGround = true;
    }
}
