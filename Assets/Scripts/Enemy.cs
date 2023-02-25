using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float health;
    [SerializeField] private EnemySO enemySO;
    private Player player;
    private SpriteRenderer enemySpriteRenderer;

    void Start()
    {
        player = FindObjectOfType<Player>();
        enemySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        enemySpriteRenderer.sprite = enemySO.enemySprite;
        speed = enemySO.enemySpeed;
        health = enemySO.enemyHelath;
    }

    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        TurnSpriteToMovementDirection();
        CheckHealth();
    }

    private void TurnSpriteToMovementDirection()
    {
        Vector3 dir = player.transform.position - transform.position;
        Vector3 dirNormalized = dir.normalized;

        transform.localScale = new Vector3(Mathf.Sign(dirNormalized.x), 1f, 1f);
    }

    public void GetDemage(int _damage){
        health -= _damage;
    }

    private void CheckHealth(){
        if (health <= Mathf.Epsilon)
        {
            Destroy(gameObject);
        }
    }
}
