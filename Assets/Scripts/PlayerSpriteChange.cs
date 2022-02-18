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
    private Vector2 velocityVec2;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }
}
