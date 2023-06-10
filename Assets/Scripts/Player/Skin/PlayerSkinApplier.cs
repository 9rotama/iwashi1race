using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PlayerPrefsから設定をロードし、プレイヤーのスキンを適用するクラス
/// プレイヤーにアタッチされる
/// </summary>
public class PlayerSkinApplier : MonoBehaviour
{
    [SerializeField] private GameObject hairSprite, clothesSprite, shoesSprite;

    private void Start()
    {
        var spriteColCtrl = hairSprite.GetComponent<RacerSpriteColorController>();
        spriteColCtrl.SetMaterialHue(PlayerPrefs.GetFloat("hairHue", 0));
        
        spriteColCtrl = clothesSprite.GetComponent<RacerSpriteColorController>();
        spriteColCtrl.SetMaterialHue(PlayerPrefs.GetFloat("clothesHue",0));
        
        spriteColCtrl = shoesSprite.GetComponent<RacerSpriteColorController>();
        spriteColCtrl.SetMaterialHue(PlayerPrefs.GetFloat("shoesHue", 0));
    }
}
