using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{   // creating a InputController instance so that 
    InputController playerInput;
    private CharacterController characterController;
    private Animator animator;

    float speed = 500;
    float turnSpeed = 10f;

    /*[SerializeField] MouseInput MouseControl;

    [System.Serializable]
    public class MouseInput
    {
        public Vector2 Damping;
        public Vector2 Sensitivity;
    }*/



    private void Awake()
    {
        playerInput = GameManager.GetInstance.InputController;
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        #region movement
        var movement = new Vector3(playerInput.Horizontal, 0, playerInput.Vertical);

        characterController.SimpleMove((movement * speed) * Time.deltaTime);

        animator.SetFloat("Speed", movement.magnitude);

        if (movement.magnitude > 0)
        {
            Quaternion newDirection = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime * turnSpeed);
        }
        #endregion movement


        #region SimpleMoveFix
        // avoiding method SimpleMove to climb over objects.
        if (this.transform.position.y >= 1f)
        {
            Vector3 temp = new Vector3(transform.position.x - 1f, 0, transform.position.z -1f);
            transform.position = temp;
            
        }
        
        // If the player falls from the world by any chance, game will deduce a live and restart the current 
        if(transform.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
        #endregion



    }
}
