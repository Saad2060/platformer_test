using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;
    [SerializeField] float thrust = 20f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, thrust), ForceMode2D.Impulse);
        }
    }
}
