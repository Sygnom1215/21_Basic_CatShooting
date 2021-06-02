using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    private GameManager gameManager = null;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        CatPosition();
    }

    private void CatPosition()
    {
        if (transform.position.x > gameManager.maxPosition.x + 2f)
        {
            Destroy(gameObject);
        }
    }
}
