using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Serialization;

public class FreezeCondition : MonoBehaviour
{
    [SerializeField] private int requiredClickNumber = 100;

    //画像
    [FormerlySerializedAs("IceCrackSprites")] [SerializeField] private Sprite[] iceCrackSprites;
    [SerializeField] private SpriteRenderer spriteRenderer;

    //音声
    [SerializeField] private AudioSource audioSource;
    [FormerlySerializedAs("crackSE")] [SerializeField] private AudioClip crackSe;
    [FormerlySerializedAs("brokenSE")] [SerializeField] private AudioClip brokenSe;
    
    private int _clickedCount = 0;
    private Racer _target;

    
    /// <summary>
    /// FreezeConditionの初期化
    /// </summary>
    public void Initialize(Racer racer) 
    {
        transform.SetParent(racer.transform);
        _target = racer;
        StartCoroutine(RacerTryDestroyFreeze());
    }

    /// <summary>
    /// レーサーが氷状態を解除するためにクリック回数を増やす処理。コルーチン
    /// </summary>
    private IEnumerator RacerTryDestroyFreeze()
    {
        while(true) {
            if(_target is PlayerController) {
                yield return new WaitUntil(() => 
                    Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || 
                    Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)
                );
            }
            else if(_target is CpuController) {
                yield return new WaitForSeconds(Random.Range(0.0f, 0.2f));
            }
            
            audioSource.PlayOneShot(crackSe);
            _clickedCount++;
        }
    }


    // Update is called once per frame
    private void Update()
    {
        // 条件がなりつ立つ時。破壊音を出してこのオブジェクトを破棄する
        if(_clickedCount == requiredClickNumber){
            Vector3 cameraPos = Camera.main.gameObject.transform.position;
            AudioSource.PlayClipAtPoint(brokenSe, cameraPos - Vector3.back*5f);
            // AudioSource.PlayClipAtPoint(brokenSE, transform.position + new Vector3(100, 0, -10));
            Destroy(this.gameObject);
        }

        // クリック回数に応じてスプライトを変更する
        int length = iceCrackSprites.Length;
        spriteRenderer.sprite = iceCrackSprites[Mathf.FloorToInt((float)_clickedCount / (float)requiredClickNumber * length) % length];

    }

    private void FixedUpdate() 
    {
        _target.StopperEnter(0, 0);
    }


}
