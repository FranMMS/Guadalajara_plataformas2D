using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    //WeaponScript weaponScript;

    public GameObject canvasLifeScript;
    PlayerLifeScript playerLifeScript;
    [SerializeField] private float playerLife;

    public bool isFliped;

    //public int life;

    Animator anim;

    public float velocity;
    Rigidbody2D rb;

    //public int maxJumps;
    public float jumpForce;
    public float maxButtonHoldTime;
    public float holdForce;
    public float distanceToCollider;
    public float maxJumpSpeed;
    public float maxFallSpeed;
    public float fallSpeed;
    public float gravityMultiplier;
    //public LayerMask collisionLayer;

    bool jumpPressed;
    bool jumpHeld;
    float buttonHoldTime;
    //float originalGravity;
    //int numberOfJumpsLeft;

    public bool isJumping;
    public bool jumpCan;
    public bool canMove;

    
    float entradaX;

    // Start is called before the first frame update
    void Start()
    {
        //weaponScript = GetComponent<WeaponScript>();

        isFliped = false;
        playerLifeScript = canvasLifeScript.GetComponent<PlayerLifeScript>();
        playerLife = 3;

        buttonHoldTime = maxButtonHoldTime;
        //originalGravity = rb.gravityScale;
        //numberOfJumpsLeft = maxJumps;

        jumpCan = true;
        canMove = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        entradaX = Input.GetAxis("Horizontal");

        Movement();
        Jump();
    }
    
   public void Jump()
   {

       if (Input.GetKeyDown(KeyCode.W) && jumpCan)
       {
           anim.SetBool("isJumping", true);
           jumpCan = false;
           isJumping = true;
           //jumpTimeCounter = jumpTime;
           rb.velocity = Vector2.up * jumpForce;
       }

       /*
       if (Input.GetKey(KeyCode.W) && isJumping)
       {
           if (jumpTimeCounter > 0)
           {
               rb.velocity = Vector2.up * jumpForce;
               jumpTimeCounter -= Time.deltaTime;
           }
           else
           {
               isJumping = false;
           }
       }

       if (Input.GetKeyUp(KeyCode.W))
       {
           isJumping = false;
       }*/
   }
   
   /*
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            jumpPressed = true;
        }
        else
        {
            jumpPressed = false;
        }

        if (Input.GetKey(KeyCode.W))
        {
            jumpHeld = true;
        }
        else
        {
            jumpHeld = false;
        }
        IsJumping();
    }

    public void IsJumping()
    {
        if (jumpPressed)
        {
            Debug.Log("ahre");
            //rb.AddForce(Vector2.up * jumpForce);
            rb.velocity = Vector2.up * jumpForce;
            AdditionalAir();
        }
        
        if (rb.velocity.y > maxJumpSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxJumpSpeed);
        }
        Falling();
    }

    public void AdditionalAir()
    {
        if (jumpHeld)
        {
            buttonHoldTime -= Time.deltaTime;

            if (buttonHoldTime <= 0)
            {
                buttonHoldTime = 0;
                isJumping = false;
            }
            else
            {
                rb.AddForce(Vector2.up * holdForce);
            }
        }
        else
        {
            isJumping = false;
        }
    }
    public void Falling()
    {
        if (!isJumping && rb.velocity.y < fallSpeed)
        {
            rb.gravityScale = gravityMultiplier;
        }
        if (rb.velocity.y < maxFallSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxFallSpeed);
        }
    }
    */
    private void Movement()
    {
        Vector2 pos = transform.position;
        Flip();


        anim.SetBool("isWalking", true);
        if (Input.GetKey(KeyCode.D))
        {
            if (canMove)
            {
                pos.x += velocity * Time.deltaTime;
            }
            
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (canMove)
            {
                pos.x -= velocity * Time.deltaTime;
                //rb.MovePosition(new Vector2(transform.position.x + velocity * -1 * Time.deltaTime, transform.position.y));
                //rb.AddForce(-Vector2.right * velocity);
            }
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        Shooting(pos);

        transform.position = pos;
    }

    public bool isMoving()
    {
        return anim.GetBool("isWalking");
    }

    public void Shooting(Vector2 pos)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 || isJumping)
        {
            anim.SetBool("isShooting", false);
        }

        if (Input.GetKey(KeyCode.Mouse0) && !isJumping)
        {
            anim.SetBool("isShooting", true);
        }

    }

    private void Flip()
    {
        Vector2 pos = transform.localScale;

        if (Input.GetKey(KeyCode.D) && isFliped)
        {
            transform.Rotate(0, 180, 0);
            isFliped = false;
        }
        else if (Input.GetKey(KeyCode.A) && !isFliped)
        {
            //pos.x = -1;
            transform.Rotate(0, 180, 0);
            isFliped = true;
        }

        transform.localScale = pos;
    }
    public void SetDamage(float num)
    {
        ChangePlayerLife(-num);
    }

    public void SetLife(float num)
    {
        ChangePlayerLife(num);
    }

    void ChangePlayerLife(float num)
    {
        playerLife += num;

        //6, porque el array de vida va de 0 a 6
        //también podriamos haber puesto el array.length de la vida
        float cont = 6 - playerLife * 2;
        playerLifeScript.actualLifeImage.sprite = playerLifeScript.lifeImages[(int)cont];
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Ground")
        {
            jumpCan = true;
            isJumping = false;
            anim.SetBool("isJumping", false);
        }
        else if (col.transform.tag == "Enemy")
        {
            //RechargeThisScene();
            SetDamage(0.5f);
        }
        else if (col.transform.tag == "Enemy2")
        {
            //RechargeThisScene();
            SetLife(0.5f);
        }
    }


    public void RechargeThisScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
