using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 1f;
    [SerializeField] private int damage = 11;
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

                if (currentDistanceFromPlayer < distanceFromEnemy)
                {
                    distanceFromEnemy = currentDistanceFromPlayer;
                    selectedEnemy = enemy;
                }
        }    
    }

    
    void Update()
    {
        if (selectedEnemy != null)
        {
            /*Vector3 dir = selectedEnemy.transform.position - transform.position;
            transform.position += dir * projectileSpeed * Time.deltaTime;*/

            transform.position = Vector3.MoveTowards(transform.position, selectedEnemy.transform.position, projectileSpeed * Time.deltaTime);

            distanceFromEnemy = Vector3.Distance(transform.position, selectedEnemy.transform.position);

            if (transform.position == selectedEnemy.transform.position)
            {
                Debug.Log("reached Player");
                selectedEnemy.GetDamage(damage);
                Debug.Log("sent a damage request");
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }

        
    }
}
