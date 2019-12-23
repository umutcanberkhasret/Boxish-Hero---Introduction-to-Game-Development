using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBullet : Bullet
{   
    private void OnTriggerEnter(Collider other)
    {
        GameObject smt = other.gameObject;

        if (smt != null &&  smt.tag == "Player")
        {
            other.gameObject.GetComponent<Health>().takeDamage(Damage);
        }
        else
        {
            Debug.Log("Hit" + other.gameObject.name);

        }
        Destroy(gameObject);
    }

}
