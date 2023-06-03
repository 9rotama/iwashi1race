using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PlayerPrefsから設定をロードし、プレイヤーのスキンを適用するクラス
/// </summary>
public class PlayerSkinApplier : MonoBehaviour
{
    [SerializeField] private GameObject hairSprite;
    [SerializeField] private GameObject clothesSprite;
    [SerializeField] private GameObject shoesSprite;
    
    private void Start()
    {
        var spriteCtrl = hairSprite.GetComponent<RacerSpriteController>();
        spriteCtrl.SetMaterialHue(PlayerPrefs.GetFloat("hairHue", 0));
        
        spriteCtrl = clothesSprite.GetComponent<RacerSpriteController>();
        spriteCtrl.SetMaterialHue(PlayerPrefs.GetFloat("clothesHue",0));
        
        spriteCtrl = shoesSprite.GetComponent<RacerSpriteController>();
        spriteCtrl.SetMaterialHue(PlayerPrefs.GetFloat("shoesHue", 0));
    }
}
