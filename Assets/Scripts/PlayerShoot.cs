using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] Shooter assaultRifle;

    // Script provides a Shoot mechanism to the Player.
    // The intention of creating this script is to make the gun system of player scalable.
    // In the future; while creating a better game this will be a reference for us to do a wider (in terms of gun options) game.
    private void Update()
    {
        if (GameManager.GetInstance.InputController.Fire1)
        {
            assaultRifle.Fire();
        }
       
        else if (GameManager.GetInstance.InputController.Fire2)
        {
            assaultRifle.throwGrenade();
        }
    }
}
