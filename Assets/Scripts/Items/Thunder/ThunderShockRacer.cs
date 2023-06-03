using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderShockRacer : MonoBehaviour
{
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

            transform.localPosition = new Vector2(Random.Range(-6f, 6f), Random.Range(-3f, 4f));
        }
    }
}
