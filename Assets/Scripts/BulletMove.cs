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

    //private void CatPosition()
    //{
    //    if (transform.position.x > gameManager.maxPosition.x + 2f)
    //    {
    //        Destroy(gameObject);
    //    }
    //}
    private void CatPosition()
    {
        if (transform.position.y > gameManager.maxPosition.y + 2f)
        {
            Despawn();
        }
        if (transform.position.y < gameManager.minPosition.y - 2f)
        {
            Despawn();
        }
        if (transform.position.x > gameManager.maxPosition.x + 2f)
        {
            Despawn();
        }
        if (transform.position.x < gameManager.minPosition.x - 2f)
        {
            Despawn();
        }
    }

    public void Despawn()
    {
        transform.SetParent(gameManager.poolManager.transform, false);
        gameObject.SetActive(false);
    }
}
