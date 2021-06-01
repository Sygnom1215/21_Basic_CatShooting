using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 4f;

    private Vector2 targetPosition = Vector2.zero;
    private GameManager gameManager = null;
    private SpriteRenderer spriteRenderer = null;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
}
