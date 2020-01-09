using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShoot : MonoBehaviour
{
    public Bullet alienBullet;
    public float rateOfFire;
    public bool canFire;


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
        Shooting();
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
    

}
