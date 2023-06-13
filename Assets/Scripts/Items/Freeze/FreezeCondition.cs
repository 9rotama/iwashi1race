using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using KanKikuchi.AudioManager;
using UnityEngine.Serialization;

/// <summary>
/// レーサーを氷状態にする
/// クリックされることで氷にヒビが入り割れる
/// </summary>
public class FreezeCondition : MonoBehaviour,  IPhysicalDamageable
{
    [SerializeField] private int requiredClickNumber = 100;

    //画像
    [FormerlySerializedAs("IceCrackSprites")] [SerializeField] private Sprite[] iceCrackSprites;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private int _clickedCount = 0;
    private Racer _target;

    
    /// <summary>
    /// FreezeConditionの初期化
    /// </summary>
    public void Initialize(Racer racer) 
    {
        transform.SetParent(racer.transform);
        _target = racer;
        _target.isStopped = true;
        StartCoroutine(RacerTryDestroyFreeze());
    }

    /// <summary>
    /// レーサーが氷状態を解除するためにクリック回数を増やす処理。コルーチン
    /// </summary>
    private IEnumerator RacerTryDestroyFreeze()
    {
        while(true) {
            switch (_target)
            {
                case PlayerController:
                    yield return new WaitUntil(() => 
                        Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || 
                        Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)
                    );
                    break;
                case CpuController:
                    yield return new WaitForSeconds(Random.Range(0.0f, 0.2f));
                    break;
            }
            
            SEManager.Instance.Play(SEPath.FREEZE_CRACK);
            _clickedCount++;
        }
    }


    // Update is called once per frame
    private void Update()
    {
        // 現時点のクリック回数が必要クリック数以上のとき、破壊音を出してこのオブジェクトを破棄する
        if(_clickedCount >= requiredClickNumber){
            /*Vector3 cameraPos = Camera.main.gameObject.transform.position;
            AudioSource.PlayClipAtPoint(brokenSe, cameraPos - Vector3.back*5f);*/
            SEManager.Instance.Play(SEPath.FREEZE_BROKEN);
            Destroy(this.gameObject);
        }

        // クリック回数に応じてスプライトを変更する
        int length = iceCrackSprites.Length;
        spriteRenderer.sprite = iceCrackSprites[Mathf.FloorToInt((float)_clickedCount / (float)requiredClickNumber * length) % length];

    }

    private void OnDestroy() 
    {
        _target.isStopped = false;
    }


}
