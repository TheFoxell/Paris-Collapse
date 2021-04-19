using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.AI;

public class Car : MonoBehaviour
{
     NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = GetDestination();
    }
    
    void Update()
    {
        if (agent.remainingDistance < 1)
        {
            agent.destination = GetDestination();
        }
    }

    public Vector3 GetDestination()
    {
        int dest = Random.Range(1, 3);
        return GameObject.Find("point" + dest).transform.position;
    }
}
