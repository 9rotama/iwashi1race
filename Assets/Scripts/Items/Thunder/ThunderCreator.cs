using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

/// <summary>
/// アイテムのサンダーを作るクラス
/// </summary>
public class ThunderCreator : MonoBehaviour, IItemInitializer
{
    [SerializeField] private Thunder thunder;
    [SerializeField] private Animator thunderAnimator;

    public void ItemInitialize(Racer racer) {

        // サンダーの落雷するまでのアニメーションの時間を取得する
        float timeUntilStrike = 0;
        foreach(var clip in thunderAnimator.runtimeAnimatorController.animationClips) {
            timeUntilStrike += clip.length;
        }

        var targets = RankManager.Instance.GetSortedRacers();

        for(int i=0; i<targets.Length; i++)
        {
            if(racer.id != targets[i].id){
                Instantiate(
                    thunder, 
                    targets[i].transform.position + Vector3.up * 25,  
                    Quaternion.identity
                ).Initialize(targets[i], i+1, timeUntilStrike);
            }
        }

        SEManager.Instance.Play(audioPath: SEPath.SHOCK, volumeRate: 0.1f, delay: timeUntilStrike);

        Destroy(this.gameObject);
    }

    
}
