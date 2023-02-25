using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemeies : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private SpawnHelper[] spawnPoints;

    private void Start() {
        spawnPoints = GetComponentsInChildren<SpawnHelper>();
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies(){
        while (true)
        {
            for (int i = 0; i < spawnPoints.Length-1; i++)
            {
                Instantiate(enemy, spawnPoints[i].transform.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(10);
        }
        
    }
}
