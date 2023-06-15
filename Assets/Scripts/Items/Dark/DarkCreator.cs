using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 呼び出したレーサー以外にDarkBodyを作るクラス
/// </summary>
public class DarkCreator : FirstItemCreated
{
    [SerializeField] private DarkBody darkBody;
    [SerializeField] private DarkEffect darkEffect;
    [SerializeField] private float baseBodyDestroyTime = 5;

    public override void ItemInitialize(Racer racer) {
        var targets = RankManager.Instance.GetSortedRacers();
        
        for(var i=0; i<targets.Length; i++){

            if(targets[i].id == racer.id) {
                continue;
            }

            var destroyTime = baseBodyDestroyTime / (i+1);

            var darkBodyInstance = Instantiate(
                darkBody,
                targets[i].transform.position,
                Quaternion.identity
            );
            darkBodyInstance.Initialize(targets[i], i+1, destroyTime);

            //プレイヤー用のエフェクトを適用
            if(targets[i] is PlayerController){
                Instantiate(darkEffect).Initialize(destroyTime);
            }

        }

        Destroy(this);
    }
}
