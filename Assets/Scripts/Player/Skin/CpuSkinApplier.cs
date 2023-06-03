using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// CPUのスキンをランダムに適用するクラス
/// </summary>
public class CpuSkinApplier : MonoBehaviour
{
    [SerializeField] private GameObject hairSprite;
    [SerializeField] private GameObject clothesSprite;
    [SerializeField] private GameObject shoesSprite;
    
    private void Start()
    {
        var spriteCtrl = hairSprite.GetComponent<RacerSpriteController>();
        spriteCtrl.SetMaterialHue(Random.value);

        spriteCtrl = clothesSprite.GetComponent<RacerSpriteController>();
        spriteCtrl.SetMaterialHue(Random.value);

        spriteCtrl = shoesSprite.GetComponent<RacerSpriteController>();
        spriteCtrl.SetMaterialHue(Random.value);

    }
}
