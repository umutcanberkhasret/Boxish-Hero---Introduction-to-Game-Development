using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour
{

    GameObject player;
    NavMeshAgent agent;
    //private Animator animator;


    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
      //  animator = GetComponentInChildren < Animator >();
        player = GameObject.FindGameObjectWithTag("Player");
    }


    // Update is called once per frame
    void FixedUpdate()
    {   
      // GoToPoint();
    }

    void GoToPoint()
    {   
        // Another way of moving towards to the player, used at LAB5
        
        /*agent.SetDestination(playerLocation.position);

        if (Vector3.Distance(playerLocation.position, transform.position) < 25f)
        {
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
        }*/

        agent.destination = player.transform.position;
    }


}
