using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacerSpriteController : MonoBehaviour
{
    [SerializeField] private Sprite spriteSpeed0;
    [SerializeField] private Sprite spriteSpeed1;
    [SerializeField] private Sprite spriteSpeed2;

    private SpriteRenderer _spriteRenderer;
    private Racer _racer;
    private readonly int _hue = Shader.PropertyToID("_Hue");


    public void SetMaterialHue(float h)
    {
        _spriteRenderer.material.SetFloat(_hue, h);
    }

    private IEnumerator AfterStart()
    {
        yield return new WaitForSeconds(0.01f);
        
        
        var racerObj = transform.parent.gameObject;
        _racer = racerObj.GetComponent<Racer>();
        StartCoroutine(nameof(ChangeBySpeed));
       
    }

    private IEnumerator ChangeBySpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
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
    }
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = spriteSpeed0;
        StartCoroutine(nameof(AfterStart));
    }
}
