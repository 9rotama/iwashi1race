using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// レーサーの服や髪などのスプライトの見た目を操作するクラス
/// </summary>
public class RacerSpriteSpeedController : MonoBehaviour
{
    [SerializeField] private Sprite spriteSpeed0;
    [SerializeField] private Sprite spriteSpeed1;
    [SerializeField] private Sprite spriteSpeed2;

    private SpriteRenderer _spriteRenderer;
    private Racer _racer;
    
    private void Update()
    {
        var velocity = _racer.GetVelocityVec2();
        _spriteRenderer.sprite = velocity.x switch
        {
            < 100f => spriteSpeed0,
            >= 100f and < 200f => spriteSpeed1,
            _ => spriteSpeed2
        };
    }
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = spriteSpeed0;
        var racerObj = transform.parent.gameObject;
        _racer = racerObj.GetComponent<Racer>();
    }
}
