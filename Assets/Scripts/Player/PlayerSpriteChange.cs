using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteChange : MonoBehaviour
{
    [Range(0, 1.0f)] public float hue;
    
    public Sprite spriteSpeed0;
    public Sprite spriteSpeed1;
    public Sprite spriteSpeed2;

    private SpriteRenderer _spriteRenderer;
    private GameObject _parentObj;
    private PlayerControl _playerControl;
    private CPUplayerControl _cpuPlayerControl;
    private static readonly int Hue = Shader.PropertyToID("_Hue");


    public void SetMaterialHue(float h)
    {
        _spriteRenderer.material.SetFloat(Hue, h);
        var obj = gameObject;
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StartCoroutine(nameof(AfterStart));    
    }

    void Update()
    {
        
    }

    private IEnumerator AfterStart()
    {
        yield return new WaitForSeconds(0.1f);
        SetMaterialHue(hue);
        _parentObj = transform.parent.gameObject;

        switch (_parentObj.tag)
        {
            case "Player":
                _playerControl = _parentObj.GetComponent<PlayerControl>();
                StartCoroutine(nameof(ChangeByPlayerSpeed));
                break;
            case "Enemy":
                _cpuPlayerControl = _parentObj.GetComponent<CPUplayerControl>();
                StartCoroutine(nameof(ChangeByCPUSpeed));
                break;
        }
        yield break;
    }

    private IEnumerator ChangeByPlayerSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            var velocity = _playerControl.GetVelocity();
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

    private IEnumerator ChangeByCPUSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            var velocity = _cpuPlayerControl.GetVelocity();
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
}
