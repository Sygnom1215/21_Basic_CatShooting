using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    public Vector2 minPosition { get; private set; }
    public Vector2 maxPosition { get; private set; }
    void Start()
    {
        minPosition = new Vector2(-7f, -12f);
        maxPosition = new Vector2(7f, 12f);
    }

    void Update()
    {
        
    }
}
