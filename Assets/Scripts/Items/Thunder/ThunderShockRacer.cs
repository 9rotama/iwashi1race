using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 雷を受けたレーサーを荒ぶらせるクラス
/// </summary>
public class ThunderShockRacer : MonoBehaviour
{
    private const float XRange = 6f;
    private const float YAbove= -3f;
    private const float YBelow = 4f;

    private void OnEnable() {
        StartCoroutine(TinglyMove());
    }

    /// <summary>
    /// 雷を受けたプレイヤーの画像を荒ぶらせる
    /// </summary>
    private IEnumerator TinglyMove() 
    {
        while(true) {
            yield return new WaitForSeconds(0.15f);
            transform.localPosition = new Vector2(Random.Range(-XRange, XRange), 
                                                  Random.Range(YAbove, YBelow));
        }
    }
}
