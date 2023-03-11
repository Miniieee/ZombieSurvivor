using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillsProjectile : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float timeBetweenShots;

    private void Start() {
        StartCoroutine(SpawnProjectile());
    }

    IEnumerator SpawnProjectile(){
        while (true)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenShots);
        }
    }
}
