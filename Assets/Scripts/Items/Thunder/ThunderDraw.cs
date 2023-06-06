using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Thunder))]
public class ThunderDraw : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] thunderSprites;
    private Thunder _thunder;

    private void Start() 
    {
        var c = spriteRenderer.color;
        spriteRenderer.color = new Color(c.r, c.g, c.b, 0);
        _thunder = GetComponent<Thunder>();
    }

    private void Update()
    {
        // 時間が立つに連れて可視化されてていく
        var c = spriteRenderer.color;
        spriteRenderer.color = new Color(c.r, c.g, c.b, _thunder.GetCloudTimeRatio());

        // 時間が立つに連れて雷が落ちていくスプライトに変わっていく
        if(_thunder.GetStrikeTimeRatio() > 1) return;
        var length = thunderSprites.Length;
        spriteRenderer.sprite = thunderSprites[Mathf.FloorToInt(_thunder.GetStrikeTimeRatio() * length) % length];
    }
    
}
