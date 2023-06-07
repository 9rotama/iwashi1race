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
        var velocity = _racer.GetVelocity();
        if(velocity >= 0 && velocity < 100f)
        {
            _spriteRenderer.sprite = spriteSpeed0;
        }
        else if (velocity >= 100f && velocity < 200f)
        {
            _spriteRenderer.sprite = spriteSpeed1;
        }
        else
        {
            _spriteRenderer.sprite = spriteSpeed2;
        }
    }
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = spriteSpeed0;
        var racerObj = transform.parent.gameObject;
        _racer = racerObj.GetComponent<Racer>();
    }
}
