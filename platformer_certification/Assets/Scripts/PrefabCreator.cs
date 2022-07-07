using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabCreator : MonoBehaviour
{
    [SerializeField] GameObject[] prefab;
    [SerializeField] Transform referncepoint;
    [SerializeField] GameObject lastPlatformCreated;
    [SerializeField] float spaceBetweenPlatforms= 2;
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
            Vector3 targetCreationPoint = new Vector3(referncepoint.position.x + lastPlatformWidth + spaceBetweenPlatforms, 0, 0);
            int randomPlatform = Random.Range(0, prefab.Length);
            lastPlatformCreated = Instantiate(prefab[randomPlatform], targetCreationPoint, Quaternion.identity);
            BoxCollider2D collider = lastPlatformCreated.GetComponent<BoxCollider2D>();
            lastPlatformWidth = collider.bounds.size.x;
        }
    }
}
