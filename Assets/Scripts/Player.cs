using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMovement playerMovement;
    [SerializeField] private float playerSpeed;

    private void Start() {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update() {
        Vector2 movementVectorNormalized = playerMovement.GetInputVectorNormalized();
        Vector3 direction = new Vector3(movementVectorNormalized.x, movementVectorNormalized.y, 0f);
        transform.position += direction * Time.deltaTime * playerSpeed;
    }
}
