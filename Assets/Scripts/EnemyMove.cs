using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private int score = 1;
    [SerializeField]
    private int hp = 2;
    [SerializeField]
    protected float speed = 5f;

    protected bool isDead = false;
    private bool isDamaged = false;
    // private bool isSound = false; 이용해서 최초 피격시에만 소리 나게 하기

    protected GameManager gameManager = null;
    private Animator animator = null;
    private Collider2D col = null;
    private SpriteRenderer spriteRenderer = null;

    public AudioSource audioSource;

    protected virtual void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    protected virtual void Update()
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
            StartCoroutine(catMeow());
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
    private IEnumerator catMeow()
    {
        //if(isSound)
        audioSource.Play();
        yield return new WaitForSeconds(1f);

    }

    private IEnumerator Damaged()
    {
        hp--;
        spriteRenderer.material.SetColor("_Color", new Color(1f, 0f, 0f, 0f));
        yield return new WaitForSeconds(0.01f);
        spriteRenderer.material.SetColor("_Color", new Color(1f, 0f, 0f, 0.25f));
        isDamaged = false;
    }
    private IEnumerator Dead()
    {
        Destroy(gameObject);

        yield return new WaitForSeconds(0.5f);
    }
}
