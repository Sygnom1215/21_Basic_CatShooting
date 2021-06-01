using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab = null;
    [SerializeField]
    private Transform bulletPosition = null;
    [SerializeField]
    private float bulletDelay = 0.5f;

    private bool isDamaged = false;

    [SerializeField]
    private float speed = 4f;

    private Vector2 targetPosition = Vector2.zero;
    private GameManager gameManager = null;
    private SpriteRenderer spriteRenderer = null;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Curu());
    }

    void Update()
    {
        if (Input.GetMouseButton(0) == true) 
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.x = Mathf.Clamp(targetPosition.x, gameManager.minPosition.x, gameManager.maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, gameManager.minPosition.y, gameManager.maxPosition.y);
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, targetPosition, speed * Time.deltaTime);
        }
    }

    private IEnumerator Curu()
    {
        GameObject bullet;
        while (true)
        {
            bullet = Instantiate(bulletPrefab, bulletPosition);
            bullet.transform.SetParent(null);
            yield return new WaitForSeconds(bulletDelay);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDamaged) return;
        isDamaged = true;
    //    StartCoroutine(Dead());
    }

    //private IEnumerator Dead()
    //{
    //    gameManager.Dead();
    //    isDamaged = true;
    //    for (int i = 0; i < 5; i++)
    //    {
    //        spriteRenderer.enabled = false;
    //        yield return new WaitForSeconds(0.1f);
    //        spriteRenderer.enabled = true;
    //        yield return new WaitForSeconds(0.1f);
    //    }
    //    isDamaged = false;
    //}
}
