using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;
    [SerializeField] float thrust = 20f;
    [SerializeField] Transform raycastOrigin;
    [SerializeField] bool isGrounded;
    bool jump;
    [SerializeField] Animator anim;
    float lastYPos;

    private void Start()
    {
        lastYPos = transform.position.y;
    }


    private void Update()
    {
        CheckForInput();
        if(transform.position.y < lastYPos)
        {
            anim.SetBool("Falling", true);
        }
        else
        {
            anim.SetBool("Falling", false); 
        }
        lastYPos = transform.position.y;
    }


    void FixedUpdate()
    {
        CheckForGrounded();
        if(jump == true)
        {
            jump = false;
            rb.AddForce(new Vector2(0, thrust), ForceMode2D.Impulse);
        }


    }

    void CheckForInput()
    {
        if (isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
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
            if (hit.distance < .01f)
            {
                isGrounded = true;
                anim.SetBool("IsGrounded", true);
            }
            else
            {
                isGrounded = false;
                anim.SetBool("IsGrounded", false);
            }


            Debug.Log(hit.transform.name);
            Debug.DrawRay(raycastOrigin.position, Vector2.down, Color.blue);
        }
    }
}
