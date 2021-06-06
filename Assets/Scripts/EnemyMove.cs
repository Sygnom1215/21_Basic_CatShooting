using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private int score = 100;
    [SerializeField]
    private int hp = 2;
    [SerializeField]
    private float speed = 5f;

    private bool isDead = false;
    private bool isDamaged = false;

    private GameManager gameManager = null;
    private Animator animator = null;
    private Collider2D col = null;
    private SpriteRenderer spriteRenderer = null;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isDead) return;
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x < gameManager.minPosition.x - 1f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) return;

        if (collision.CompareTag("Bullet"))
        {
            if (isDamaged) return;

            hp--;
            Destroy(collision.gameObject);
            if (hp <= 0)
            {
                StartCoroutine(Dead());
                gameManager.AddScore(score);
            }
            StartCoroutine(Damaged());
        }
    }
    private IEnumerator Damaged()
    {
        hp--;
        spriteRenderer.material.SetColor("_Color", new Color(1f, 0f, 0f, 0f));
        yield return new WaitForSeconds(0.01f);
        spriteRenderer.material.SetColor("_Color", new Color(1f, 0f, 0f, 1f));
        isDamaged = false;
    }

    private IEnumerator Dead()
    {
        Destroy(gameObject);

        yield return new WaitForSeconds(0.5f);
    }
}
