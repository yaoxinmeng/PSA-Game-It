using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainChar2D : MonoBehaviour
{
    public AudioClip jumpSFX;
    public AudioClip landSFX;
    public AudioClip dieSFX;
    public AudioClip winSFX;

    private AudioSource jumpSource;
    private AudioSource landSource;
    private AudioSource dieSource;
    private AudioSource winSource;

    public AudioSource[] audioList;

    [Range(1, 10)]
    public float walkingSpeed;
    [Range(1, 10)]
    public float jumpHeight;
    [Range (0, 1)]
    public float invisibilityBufferTime;

    private Animator anim;
    private LevelManager levelManager;
    private Rigidbody2D rb;
    private Spriter2UnityDX.EntityRenderer ren;

    private float iniAlpha;
    private bool faceLeft = false;
    
    private bool isInvisible = false;

    [HideInInspector]
    public bool hitLWall = false;
    [HideInInspector]
    public bool hitRWall = false;
    [HideInInspector]
    public bool onCrane = false;

    void Awake()
    {
        
    }

    // Use this for initialization
    void Start()
    {
        ren = GetComponent<Spriter2UnityDX.EntityRenderer>();
        GetComponent<BoxCollider2D>().isTrigger = false;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        iniAlpha = ren.Color.a;

        jumpSource = gameObject.AddComponent<AudioSource>();
        jumpSource.clip = jumpSFX;
        landSource = gameObject.AddComponent<AudioSource>();
        landSource.clip = landSFX;
        dieSource = gameObject.AddComponent<AudioSource>();
        dieSource.clip = dieSFX;
        winSource = gameObject.AddComponent<AudioSource>();
        winSource.clip = winSFX;

        audioList = GetComponents<AudioSource>();
        foreach (AudioSource audio in audioList)
        {
            audio.volume = PlayerPrefs.GetFloat("SFXvolume");
            audio.playOnAwake = false;
        }
    }

    // Update is called once per frame
    void Update ()
	{
        if (!anim.GetBool("isDead"))
        {
            if (!UiController.playerDied)
            {
                //for sounds
                foreach (AudioSource audio in audioList)
                {
                    audio.volume = PlayerPrefs.GetFloat("SFXvolume");
                }

                //for animation
                if (GuiController.isTappedRight)
                {
                    anim.SetBool("isRunningRight", true);
                    hitLWall = false;
                    if (!hitRWall)
                        transform.Translate(Vector3.right * walkingSpeed * Time.deltaTime);
                }
                else
                {
                    anim.SetBool("isRunningRight", false);
                }

                if (GuiController.isTappedLeft)
                {
                    anim.SetBool("isRunningLeft", true);
                    hitRWall = false;
                    if (!hitLWall)
                        transform.Translate(Vector3.left * walkingSpeed * Time.deltaTime);
                }
                else
                {
                    anim.SetBool("isRunningLeft", false);
                }

                //for jump and drop
                if (GuiController.isJumping && GuiController.isGrounded)
                {
                    jumpSource.PlayOneShot(jumpSFX, 0.8f);
                    rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
                    anim.SetTrigger("isJumping");
                    GuiController.isJumping = false;
                }
                else
                    anim.SetBool("isJumping", false);

                if (GuiController.isDropping)
                {
                    GetComponent<BoxCollider2D>().isTrigger = true;
                    rb.velocity = new Vector2(rb.velocity.x, -0.5f * jumpHeight);
                }

                //for inivisble container
                if (isInvisible)
                {
                    ren.Color = new Vector4(ren.Color.r, ren.Color.g, ren.Color.b, 0.5f);
                    gameObject.layer = 12;
                }
                else
                {
                    ren.Color = new Vector4(ren.Color.r, ren.Color.g, ren.Color.b, iniAlpha);
                    gameObject.layer = 9;
                }
            }

            else
            {
                dieSource.PlayOneShot(dieSFX, 1);
                anim.SetBool("isDead", true);
            }
        }
        else
        {
            gameObject.layer = 12;
        }

        //establishes isTrigger based on direction of travel
        if (rb.velocity.y > 0)
        {
            if (!onCrane)
                GetComponent<BoxCollider2D>().isTrigger = true;
            GuiController.isGrounded = false;
            GuiController.onGround = false;
        }
        else if (rb.velocity.y < 0)
        {
            if (!GuiController.isDropping)
                GetComponent<BoxCollider2D>().isTrigger = false;
            GuiController.isGrounded = false;
            GuiController.onGround = false;
        }
        else
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;
        // Leave the method if not colliding with defender
        if (obj.tag == "GameController")
        {
            UiController.gameClear = true;
            winSource.PlayOneShot(winSFX, 0.8f);
        }
        if (obj.tag == "Enemy")
        {
            UiController.playerDied = true;
        }
        if (obj.tag == "Invisible Container")
            isInvisible = true;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject obj = col.gameObject;
        if (obj.tag == "Wall")
        {
            if (obj.transform.position.x < transform.position.x)
                hitLWall = true;
            else
                hitRWall = true;

            rb.velocity = new Vector3(0, rb.velocity.y);
        }
        if (obj.tag == "Ground" || obj.tag == "Container")
        {
            GuiController.isGrounded = true;
            landSource.PlayOneShot(landSFX, 0.5f);
        }
        if (obj.tag == "CraneContainer" && obj.transform.parent.Find("Crane").Find("Control Base").Find("Cable And Hook").GetComponent<Crane>().hasContainer)
        {
            landSource.PlayOneShot(landSFX, 0.5f);
            GuiController.isGrounded = false;
        }
        if (obj.tag == "Ground")
            GuiController.onGround = true;
        if (obj.tag == "Enemy")
        {
            UiController.playerDied = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Invisible Container")
            Invoke("becomeVisible", invisibilityBufferTime);
        if (obj.tag == "Wall")
        {
            if (obj.transform.position.x < transform.position.x)
                hitLWall = false;
            else
                hitRWall = false;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Wall")
        {
            if (obj.transform.position.x < transform.position.x)
                hitLWall = true;
            else
                hitRWall = true;

            rb.velocity = new Vector3(0, rb.velocity.y);
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        GameObject obj = col.gameObject;
        if (obj.tag == "Ground" || obj.tag == "Container")
        {
            onCrane = false;
            GuiController.isGrounded = true;
        }
        if (obj.tag == "Ground")
            GuiController.onGround = true;
        if (obj.tag == "CraneContainer")
        {
            if (obj.transform.parent.Find("Crane").Find("Control Base").Find("Cable And Hook").GetComponent<Crane>().hasContainer)
            {
                onCrane = true;
                GuiController.isGrounded = false;
                obj.transform.GetChild(0).GetComponent<CraneContainer>().hasPlayer = true;
            }
            else
            {
                GuiController.isGrounded = true;
                onCrane = false;
                obj.transform.GetChild(0).GetComponent<CraneContainer>().hasPlayer = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Wall")
        {
            if (obj.transform.position.x < transform.position.x)
                hitLWall = false;
            else
                hitRWall = false;
        }

        if (obj.tag == "CraneContainer")
        {
            if (rb.velocity.y > 0)
                rb.velocity = new Vector2(rb.velocity.x, 0);
            else
                rb.velocity = new Vector2(rb.velocity.x, -0.5f * jumpHeight);
        }
    }

    void becomeVisible()
    {
        isInvisible = false;
    }
}
