using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabCreator : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Transform referncepoint;
    [SerializeField] GameObject lastPlatformCreated;
    float lastPlatformWidth;

    // Start is called before the first frame update
    void Start()
    {
        //lastPlatformCreated = Instantiate(prefab, referncepoint.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (lastPlatformCreated.transform.position.x < referncepoint.position.x)
        {
            Vector3 targetCreationPoint = new Vector3(referncepoint.position.x + lastPlatformWidth, 0, 0);
            lastPlatformCreated = Instantiate(prefab, targetCreationPoint, Quaternion.identity);
            BoxCollider2D collider = lastPlatformCreated.GetComponent<BoxCollider2D>();
            lastPlatformWidth = collider.bounds.size.x;
        }
    }
}
