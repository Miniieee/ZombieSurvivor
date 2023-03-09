using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMovement playerMovement;
    [SerializeField] private float playerSpeed;
    [SerializeField] private Projectile projectile;


    /*TODO
        - Get a collider
        - Enemies collides
        - Create health system
        - Create damage system
        - Level up system
        - Power ups
        - Drops
    */

    private void Start() {
        playerMovement = GetComponent<PlayerMovement>();
        StartCoroutine(SpawnProjectile());
    }

    private void Update() {
        Vector2 movementVectorNormalized = playerMovement.GetInputVectorNormalized();
        Vector3 direction = new Vector3(movementVectorNormalized.x, movementVectorNormalized.y, 0f);
        transform.position += direction * Time.deltaTime * playerSpeed;
    }

    //prototype functions
    IEnumerator SpawnProjectile(){
        while (true)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
    }
}
