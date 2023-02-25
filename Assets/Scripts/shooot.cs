using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class shooot : MonoBehaviour
{
    
    
    private InputActions inputActions;
    private Vector2 inputVector;
    
    // Start is called before the first frame update
    void Awake()
    {
        inputActions = new InputActions();
        inputActions.Enable();
    }
    
    

    // Update is called once per frame
    void Update()
    {

        if (inputActions.Player.Shoot.triggered)
        {
            // Get the position of the mouse in the world
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Calculate the direction from the player to the mouse position
            Vector3 direction = mousePosition - transform.position;

            // Create a red ray that starts from the player and goes in the direction of the mouse position
            Debug.DrawRay(transform.position, direction, Color.red);

            // You can also use a Raycast to detect if the ray hits something in the scene
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit))
            {
                Debug.Log("Hit object: " + hit.collider.gameObject.name);
            }
        }

        
        
    }


}
