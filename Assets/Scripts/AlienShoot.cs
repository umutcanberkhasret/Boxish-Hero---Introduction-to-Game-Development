using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShoot : MonoBehaviour
{
    [SerializeField] Bullet alienBullet;
    [SerializeField] float rateOfFire;
    public bool canFire;
    float counter = 0f;


    [HideInInspector] public Transform muzzle;
    float nextFireAllowed;

    // Start is called before the first frame update
    void Start()
    {
        muzzle = transform.Find("Muzzle");
    }

    // Update is called once per frame
    void Update()
    {
        counter++;

        if (counter == 50f)
        {
            counter = 0f;
            Shooting();
        }

    }

    void Shooting()
    {
        canFire = false;
        if (Time.time < nextFireAllowed)
        {
            return;
        }

        nextFireAllowed = Time.time + rateOfFire;

        Instantiate(alienBullet, muzzle.position, muzzle.rotation);
        canFire = true;

    }
    /* void ShootingMech()
     {
         for (counter = 0; counter <= 10; counter++)
         {
             if (counter == 10)
             {
                 Shooting();
                 counter = 0;
             }
         }
     }*/

}
