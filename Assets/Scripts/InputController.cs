using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// "Multiplayer Third Person Shooter E2: GameManager & Input Controller"	by Stevie ROF
// The tutorial is used as a guide to create gameManager and hierarchy. 
// His work is not taken and placed as a whole. Adjustments for this project were made


public class InputController : MonoBehaviour
{
    /*  We could have done this with how we did in the labs however according to the tutorial we had followed
        this way would provide a bigger flexibility later on if we wish to change how we should handle with
        incoming inputs.
        
        Fire2 which is used for throwing grenades is implemented with the flexibility that was provided.
    */

    public float Vertical;
    public float Horizontal;
    public Vector2 MouseInput;
    public bool Fire1;
    public bool Fire2;

    private void Update()
    {

        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        MouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Fire1 = Input.GetButton("Fire1");
        Fire2 = Input.GetButton("Fire2");
    }

}
