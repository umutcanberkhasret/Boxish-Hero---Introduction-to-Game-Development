using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Shooter class is created for the later purposes; which is depending on the time
// we have, we can have different types of guns.
public class Shooter : MonoBehaviour
{
    [SerializeField] float rateOfFire;
    [SerializeField] Bullet bullet;

    [HideInInspector] public Transform muzzle;
    float nextFireAllowed;
    public bool canFire;

    private void Awake()
    {
        muzzle = transform.Find("Muzzle");
    }

    // Marking the weapon as virtual will allow us to override it from different classes.
    public virtual void Fire()
    {   /* By adding a boolean called canFire we will be able to adjust the rate of the
           fire, so it will be more realistic.
        */
        canFire = false;
        if (Time.time < nextFireAllowed)
        {
            return;
        }

        nextFireAllowed = Time.time + rateOfFire;
        // instantiating the bullet
        Instantiate(bullet, muzzle.position, muzzle.rotation);
        canFire = true;
    }
}
