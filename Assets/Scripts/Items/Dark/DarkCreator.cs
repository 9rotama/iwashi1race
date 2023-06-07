using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkCreator : MonoBehaviour, IItemInitializer
{
    [SerializeField] private DarkBody darkBody;
    [SerializeField] private DarkEffect darkEffect;
    [SerializeField] private float baseBodyDestroyTime = 5;

    public void ItemInitialize(Racer racer) {
        var targets = RankManager.Instance.GetSortedRacers();
        
        for(var i=0; i<targets.Length; i++){

            if(targets[i].id == racer.id) {
                continue;
            }

            var destroyTime = baseBodyDestroyTime / Mathf.Sqrt(i+1);

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
