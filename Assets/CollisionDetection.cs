using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private Enemy selectedEnemy;
    private int damage = 10;
    [SerializeField] float projectileSpeed = 0.5f;

    
    private void OnTriggerEnter2D(Collider2D other) {
       
        //selectedEnemy = other.GetComponent<Enemy>();
        //selectedEnemy.GetDemage(damage);
    }
}
