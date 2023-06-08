using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacerSpriteColorController : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private readonly int _hue = Shader.PropertyToID("_Hue");

    
    /// <summary>
    /// 特定のスプライトの色相を変更する
    /// </summary>
    /// <param name="h">色相(0.0~1.0)</param>
    public void SetMaterialHue(float h)
    {
        _spriteRenderer.material.SetFloat(_hue, h);
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

}
