using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int health;
    [SerializeField] private EnemySO enemySO;
    private Player player;
    private SpriteRenderer enemySpriteRenderer;
    private TextMeshProUGUI damageText;
    private Vector3 newLocalScale;
    private int sumDamage = 0;

    void Start()
    {
        player = FindObjectOfType<Player>();
        enemySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        damageText = GetComponentInChildren<TextMeshProUGUI>();
        enemySpriteRenderer.sprite = enemySO.enemySprite;
        speed = enemySO.enemySpeed;
        health = enemySO.enemyHelath;
    }

    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        TurnSpriteToMovementDirection();
    }

    private void TurnSpriteToMovementDirection()
    {
        Vector3 dir = player.transform.position - transform.position;
        Vector3 dirNormalized = dir.normalized;
        newLocalScale = new Vector3(Mathf.Sign(dirNormalized.x), 1f, 1f);
        enemySpriteRenderer.transform.localScale = newLocalScale;
    }

    public void GetDamage(int _damage)
    {
        health -= _damage;
        sumDamage += _damage;
        damageText.text = sumDamage.ToString();
        Debug.Log("Damaged");
        CheckHealth();
    }

    private void CheckHealth()
    {
        Debug.Log("Started Checking health");
        if (health <= Mathf.Epsilon)
        {
            Debug.Log("Destroyed gameobject");
            Destroy(gameObject);
        }
    }
}
