using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 1f;
    private Enemy[] selectedEnemies;
    private float distance;
    private float distanceFromEnemy;
    private float currentDistance;
    private Enemy selectedEnemy;

    
    void Start()
    {
        distance = Mathf.Infinity;
        selectedEnemies = FindObjectsOfType<Enemy>();
        foreach (Enemy _enemy in selectedEnemies)
        {
            currentDistance = Vector3.Distance(transform.position, _enemy.transform.position);
            if (currentDistance < distance)
            {
                selectedEnemy = _enemy;
            }
        }
    }

    
    void Update()
    {
        Vector3 dir = selectedEnemy.transform.position - transform.position;
        transform.position += dir * projectileSpeed * Time.deltaTime;
        distanceFromEnemy = Vector3.Distance(transform.position, selectedEnemy.transform.position);

        if (distanceFromEnemy < Mathf.Epsilon)
        {
            Debug.Log("damaged by " + selectedEnemy.name);
        }
    }
}
