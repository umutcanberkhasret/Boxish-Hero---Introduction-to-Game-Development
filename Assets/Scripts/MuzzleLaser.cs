using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// -> "Simple laser in unity"													by Ba Duy
// Tutorial is used to create realistic muzzle laser. His work is not taken and placed as a whole. 
//Adjustments for this project were made

public class MuzzleLaser : MonoBehaviour
{
    [SerializeField]
    float laserRange;
    LineRenderer gunLaser;
    // Start is called before the first frame update
    void Start()
    {
        gunLaser = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        gunLaser.SetPosition(0, transform.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
            {
                gunLaser.SetPosition(1, hit.point);
            }
        }
        else
            gunLaser.SetPosition(1, transform.forward * laserRange);
    }
}
