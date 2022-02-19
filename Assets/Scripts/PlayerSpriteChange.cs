using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteChange : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite spriteSpeed0;
    public Sprite spriteSpeed1;
    public Sprite spriteSpeed2;

    private Vector3 prevPosition;
    
    void Start()
    {
        prevPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        var velocityVec2 = (transform.position - prevPosition) / Time.deltaTime;
        var velocity = Math.Sqrt(Math.Pow(velocityVec2.x, 2) + Math.Pow(velocityVec2.y, 2));
        prevPosition = transform.position;
        // 移動速度計算

    }
}
