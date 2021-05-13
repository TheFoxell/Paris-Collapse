using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robots : MonoBehaviour
{
    private RaycastHit Hit;
    void Update()
    {
        transform.Translate(Vector3.forward * 4 * Time.deltaTime);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit, 1))
        {
            transform.Rotate(Vector3.up * Random.Range(50,200));
        }
    }
    
}
