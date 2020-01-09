using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    "Multiplayer Third Person Shooter E5: Shooter"							by Stevie ROF
    The tutorial is used to create main shooting mechanism. It is taken a guide to create  
    throwGrenade and automated alienShoot mechanisms.
     
*/

// Shooter class is created for the later purposes; which is depending on the time
// we have, we can have different types of guns.
public class Shooter : MonoBehaviour
{
    [SerializeField] float rateOfFire = 0.2f;
    [SerializeField] Bullet bullet;
    [SerializeField] Bomb grenade;

    public Transform muzzle;
    public Transform bombThrower;
    float nextFireAllowed;
    public bool canFire;
    public bool canThrow;

    private void Awake()
    {
        muzzle = transform.Find("Muzzle");
        bombThrower = transform.Find("BombThrower");
    }

    // Marking the weapon as virtual will allow us to override it from different classes.
    public virtual void Fire()
    {
        /* By adding a boolean called canFire we will be able to adjust the rate of the
           fire, so it will be more realistic.
        */
        canFire = false;
        // Both rate of fire and inventory check whether the player possess enough ammunation
        if (Time.time < nextFireAllowed || GameManager.remainingBullets == 0)
        {
            return;
        }

        nextFireAllowed = Time.time + rateOfFire;
        // instantiating the bullet
        Instantiate(bullet, muzzle.position, muzzle.rotation);
        GameManager.remainingBullets--;
        canFire = true;
    }

    public void throwGrenade()
    {
        canThrow = false;
        // Both rate of fire and inventory check whether the player possess enough ammunation
        if (Time.time < nextFireAllowed || GameManager.remainingBombs == 0)
        {
            return;
        }

        // the time interval will be wider for throwing a bomb
        nextFireAllowed = Time.time + (rateOfFire + 0.5f);
        Instantiate(grenade, bombThrower.position, bombThrower.rotation);
        GameManager.remainingBombs--;
        canThrow = true;

    }
}
