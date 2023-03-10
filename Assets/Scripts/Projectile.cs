using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 1f;
    [SerializeField] private float damage = 11f;
    private Enemy[] enemies;
    private float distanceFromEnemy;
    private float currentDistanceFromPlayer;
    private Enemy selectedEnemy = null;

    
    void Start()
    {
        distanceFromEnemy = Mathf.Infinity;
        enemies = FindObjectsOfType<Enemy>();

        //if no enemies found destroys itself and returns
        if (enemies == null)
        {
            Destroy(gameObject);
            return;
        }

        foreach (Enemy enemy in enemies)
        {
                float currentDistanceFromPlayer = Vector3.Distance(transform.position, enemy.transform.position);
                bool isEnemySelectedAlready = enemy.GetSelectedStatus();

                if (currentDistanceFromPlayer < distanceFromEnemy && !isEnemySelectedAlready)
                {
                    enemy.SetSelectedState();
                    distanceFromEnemy = currentDistanceFromPlayer;
                    selectedEnemy = enemy;
                }
        }    
    }

    
    void Update()
    {
        if (selectedEnemy != null)
        {
            Vector3 dir = selectedEnemy.transform.position - transform.position;
            transform.position += dir * projectileSpeed * Time.deltaTime;

            distanceFromEnemy = Vector3.Distance(transform.position, selectedEnemy.transform.position);

            if (distanceFromEnemy <= 1f)
            {
                Debug.Log("damaged by " + selectedEnemy.name);
                selectedEnemy.GetDamage(damage);
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }

        
    }
}
