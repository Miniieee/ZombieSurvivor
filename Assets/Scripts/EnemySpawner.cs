using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Enemies spawned outside of camera
    // Keep a constant number of enemies at the same time
    // Add waves
    // Spawnpoints move with the player?
    [SerializeField] GameObject enemyPrefab;
    private SpawnHelper[] spawnPoints;


    private void Start() {
        spawnPoints = FindObjectsOfType<SpawnHelper>();
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner(){

        while (true)
        {
            for (int i = 0; i < spawnPoints.Length-1; i++)
            {
                Instantiate(enemyPrefab, spawnPoints[i].transform.position, Quaternion.identity);
            }
            
            yield return new WaitForSeconds(10f);
        }
        
    }
}
