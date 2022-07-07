using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialPlatform : MonoBehaviour
{
        public float speed = 5f;


    void FixedUpdate()
    {

        transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        //One way of deleting items
        if (transform.position.x <= -17)
        {
            Destroy(gameObject);
        }

    }
}
