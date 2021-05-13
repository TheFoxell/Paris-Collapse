using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facedé : MonoBehaviour
{
    Dé script;
    void Awake()
    {
        script = GameObject.Find("Dice").GetComponent<Dé>();
    }
    
    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "piste")
        {
            script.face = int.Parse(gameObject.name);
        }
    }
}
