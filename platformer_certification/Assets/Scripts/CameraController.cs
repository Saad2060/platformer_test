using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform player;
    [SerializeField] Vector3 cameraVelocity;
    [SerializeField] float smoothTime = 1;
    [SerializeField] bool lookAtPlayer;

    // Update is called once per frame
    void Update()
    {
        // Making the camera follows the player
        //transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);

        // Anohter way of doing the following but smoother

        if (player.position.y > 1)
        {
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref cameraVelocity, smoothTime);

            if (lookAtPlayer == true)
            {
                transform.LookAt(player);
            }
        }

    }
}
