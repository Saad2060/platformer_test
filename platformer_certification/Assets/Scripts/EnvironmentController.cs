using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    [SerializeField] GameObject[] environmentElement;
    [SerializeField] Transform referencePoint;

    void Start()
    {
        StartCoroutine(CreateEnvironmentelement());
    }

    IEnumerator CreateEnvironmentelement()
    {
        Vector3 offset = new Vector3(10, 0, 0);
        Instantiate(environmentElement[Random.Range(0, environmentElement.Length)], referencePoint.position + offset, Quaternion.identity);

        yield return new WaitForSeconds(Random.Range(3,6));
        StartCoroutine(CreateEnvironmentelement());
    }

}
