using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DarkEffect : MonoBehaviour
{
    private float _elapsedTime;
    private float _destroyTime;
    [SerializeField] private Image effectImage;
    [SerializeField] private float alphaChangeSpeed = 2;

    public void Initialize(float destroyTime)
    {
        _destroyTime = destroyTime;

        Color alphaZeroColor = effectImage.color;
        alphaZeroColor.a = 0; 
        effectImage.color = alphaZeroColor;
    }

    // Update is called once per frame
    // 経過時間に応じてDarkEffectの画像の透明度を変化させる
    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        // sinの値が-1/4〜1になるように調整
        float alphaChangeValue = (Mathf.Sin(_elapsedTime*alphaChangeSpeed) * 3 + 1) / 4 ;

        Color tmpColor = effectImage.color;
        tmpColor.a = alphaChangeValue;
        effectImage.color = tmpColor;

        if(_elapsedTime > _destroyTime && alphaChangeValue < 0) {
            Destroy(gameObject);
        }
    
    }
}
