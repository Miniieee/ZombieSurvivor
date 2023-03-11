using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillsRadiusDamage : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float detectionRadius;
    [SerializeField] private int damage;

    private void Start() {
        StartCoroutine(PulsingDamage());
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, detectionRadius, enemyLayer);
    }

    IEnumerator PulsingDamage()
    {
        while (true)
        {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, detectionRadius, enemyLayer);

            if (enemies != null)
            {
                foreach (Collider2D enemy in enemies)
                {
                    enemy.gameObject.GetComponent<Enemy>().GetDamage(damage);
                }
            }
            
            yield return new WaitForSeconds(1f);
        }
    }
}
