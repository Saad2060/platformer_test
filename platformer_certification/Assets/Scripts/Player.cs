using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;
    [SerializeField] float thrust = 20f;
    [SerializeField] Transform raycastOrigin;
    [SerializeField] bool isGrounded;
    bool jump;
    [SerializeField] Animator anim;
    float lastYPos;
    public float distanceTravelled;
    [SerializeField] UIController uiController;
    public int collectedCoins;
    bool airJump;
    bool shieldIsActive;
    [SerializeField] GameObject shield;
    [SerializeField] SFXManager sfxManager;
    bool playerIsFalling;



    private void Start()
    {
        lastYPos = transform.position.y;
    }


    private void Update()
    {
        distanceTravelled = distanceTravelled + Time.deltaTime;
        CheckForInput();
        CheckIfPlayerISFalling();

    }


    void FixedUpdate()
    {
        CheckForGrounded();
        CheckForJump();


    }

    void CheckForJump()
    {
        if (jump == true)
        {
            jump = false;
            
            rb.AddForce(new Vector2(0, thrust), ForceMode2D.Impulse);
        }
    }
    
    void CheckIfPlayerISFalling()
    {
        if (transform.position.y < lastYPos)
        {
            anim.SetBool("Falling", true);
            playerIsFalling = true;
            
        }
        else
        {
            anim.SetBool("Falling", false);
            playerIsFalling = false;
        }
        lastYPos = transform.position.y;
    }


    void CheckForInput()
    {
        if (isGrounded == true || airJump == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(airJump == true && isGrounded == false)
                {
                    airJump = false;
                    sfxManager.PlaySFX("DoubleJump");
                }
                else
                {
                    sfxManager.PlaySFX("Jump");
                }
                jump = true;
                anim.SetTrigger(("Jump"));
                
            }
        }
    }

    void CheckForGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin.position, Vector2.down);

        if (hit.collider != null)
        {
            if (hit.distance < .1f)
            {
                isGrounded = true;
                anim.SetBool("IsGrounded", true);
                if (playerIsFalling == true)
                {
                    sfxManager.PlaySFX("Land");
                }
            }
            else
            {
                isGrounded = false;
            }



            Debug.Log(hit.transform.name);
            Debug.DrawRay(raycastOrigin.position, Vector2.down, Color.blue);
        }
        else
        {
            isGrounded = false;
            anim.SetBool("IsGrounded", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Obstacle"))
        {
            if(shieldIsActive == true)
            {
                shield.SetActive(false);
                shieldIsActive = false;
                sfxManager.PlaySFX("ShieldBreak");
                Destroy(collision.gameObject);
            }
            else
            {
                sfxManager.PlaySFX("GameOverHit");
                uiController.ShowGameOverScreen();
            }


        }
        if (collision.transform.CompareTag("DeathBox"))
        {
            uiController.ShowGameOverScreen();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            collectedCoins++;
            sfxManager.PlaySFX("Coin");
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("AirJump"))
        {
            airJump = true;
            sfxManager.PlaySFX("PowerupDoubleJump");
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Shield"))
        {
            shieldIsActive = true;
            shield.SetActive(true);
            sfxManager.PlaySFX("PowerupShield");
            Destroy(collision.gameObject);
        }
    }
}
