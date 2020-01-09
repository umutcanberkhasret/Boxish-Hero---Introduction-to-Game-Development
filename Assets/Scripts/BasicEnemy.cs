using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour
{

    GameObject player;
    NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }


    // Update is called once per frame
    void FixedUpdate()
    {   
      GoToPoint();
    }

    void GoToPoint()
    {   
        // Another way of moving towards to the player, used at LAB5
        
        agent.SetDestination(player.transform.position);

        if (Vector3.Distance(player.transform.position, transform.position) < 5f)
        {
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
        }

        
    }


}
