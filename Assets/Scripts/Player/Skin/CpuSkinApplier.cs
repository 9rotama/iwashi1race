using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CpuSkinApplier : MonoBehaviour
{
    [SerializeField] private GameObject hairSprite;
    [SerializeField] private GameObject clothesSprite;
    [SerializeField] private GameObject shoesSprite;
    
    private void Start()
    {
        var spriteColCtrl = hairSprite.GetComponent<RacerSpriteColorController>();
        spriteColCtrl.SetMaterialHue(Random.value);

        spriteColCtrl = clothesSprite.GetComponent<RacerSpriteColorController>();
        spriteColCtrl.SetMaterialHue(Random.value);

        spriteColCtrl = shoesSprite.GetComponent<RacerSpriteColorController>();
        spriteColCtrl.SetMaterialHue(Random.value);

    }
}
