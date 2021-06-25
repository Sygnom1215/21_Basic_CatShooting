using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlackCat : EnemyMove
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float bulletDelay = 0.5f;

    private float timer = 0f;
    private Vector3 diff = Vector3.zero;
    private float rotationZ = 0f;

    private GameObject newBullet = null;
    private PlayerMove player = null;

    protected override void Start()
    {
        base.Start();
        player = FindObjectOfType<PlayerMove>();
    }


    protected override void Update() 
    {
        if (isDead) return;
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        timer += Time.deltaTime;
        if (timer >= bulletDelay)
        {
            timer = 0f; 
            newBullet = Instantiate(bulletPrefab, transform);
            newBullet.transform.SetParent(null);

            //플레이어 조준
            diff = transform.position - player.transform.position;
            diff.Normalize(); 

            rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            newBullet.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + 90f);
        }

        if (transform.position.x < gameManager.maxPosition.x - 16f)
        {
            Destroy(gameObject);
        }
    }
}
