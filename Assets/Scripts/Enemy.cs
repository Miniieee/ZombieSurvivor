using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private EnemySO enemySO;
    private Player player;
    private SpriteRenderer enemySpriteRenderer;

    void Start()
    {
        player = FindObjectOfType<Player>();
        enemySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        enemySpriteRenderer.sprite = enemySO.enemySprite;
        speed = enemySO.enemySpeed;
    }

    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
