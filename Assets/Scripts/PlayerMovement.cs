using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private InputActions inputActions;
    private Vector2 inputVector;

    private void Awake() {
        inputActions = new InputActions();
        inputActions.Enable();
        
    }

    public Vector2 GetInputVectorNormalized(){
        inputVector = inputActions.Player.Move.ReadValue<Vector2>();
        Vector2 inputVectorNormailzed = inputVector.normalized;
        return inputVectorNormailzed;
    }
}
