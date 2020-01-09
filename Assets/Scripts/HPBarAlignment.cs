using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
   "Unity Tutorial - How to make Enemy Healthbars"							by Dapper Dino
    With this tutorial, the logic of the creation of healthbar is grasped and as the name suggests; Player & Enemy
    healthbars are created.
*/

public class HPBarAlignment : MonoBehaviour
{
    [SerializeField]
    Transform humanoidObject;
    
    // Update is called once per frame
    void Update()
    {
        transform.position = humanoidObject.position;
  
    }
}
