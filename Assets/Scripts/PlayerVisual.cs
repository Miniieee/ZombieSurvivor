using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private void Start() {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update() {
        Vector2 movementVectorNormalized = playerMovement.GetInputVectorNormalized();

        bool hasHorizontalspeed = Mathf.Abs(movementVectorNormalized.x) > Mathf.Epsilon;

        if (hasHorizontalspeed)
        {
            // flip sprite
            transform.localScale = new Vector3(Mathf.Sign(movementVectorNormalized.x), 1f, 1f);
        }
        
        
        
    }
}
