using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 物理攻撃をするアイテムから身を守る
/// バブルを管理するクラス
/// </summary>
public class Bubble : FirstItemCreated
{
    private Racer _parentRacer;

    public override void ItemInitialize(Racer racer) 
    {
        transform.parent = racer.transform;
        _parentRacer = racer.GetComponent<Racer>();

        // isInvincibleが真のときbubbleをすでに持っているから破棄
        if(_parentRacer.isInvincible) {
            Destroy(gameObject);
        }

        _parentRacer.isInvincible = true;
    }

    private void Update()
    {
        if(_parentRacer != null && !_parentRacer.isInvincible) {
            Destroy(gameObject);
        }
    }
}
