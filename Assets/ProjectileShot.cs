using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShot : MonoBehaviour
{
    private Enemy[] enemies;
    private Enemy selectedEnemy = null;
    [SerializeField] float projectileSpeed = 0.5f;  
    private void Start() {
        enemies = FindObjectsOfType<Enemy>();
        float distanceFromEnemy = Mathf.Infinity;
        if (enemies != null)
        {
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
        
    
    
    }
    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, selectedEnemy.transform.position, projectileSpeed * Time.deltaTime);
        float distanceReduced = Vector3.Distance(transform.position, selectedEnemy.transform.position);
        if (distanceReduced <= Mathf.Infinity)
        {
            selectedEnemy.GetDemage(10);
            Debug.Log("halott");
            Destroy(gameObject);
        }
    }   



    

   
}
