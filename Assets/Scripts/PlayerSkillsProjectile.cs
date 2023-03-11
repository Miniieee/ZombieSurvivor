using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillsProjectile : MonoBehaviour
{
    [SerializeField] private Projectile projectile;

    private void Start() {
        StartCoroutine(SpawnProjectile());
    }

    IEnumerator SpawnProjectile(){
        while (true)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
}
