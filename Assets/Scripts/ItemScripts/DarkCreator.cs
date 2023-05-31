using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkCreator : MonoBehaviour, IItemInitializer
{
    [SerializeField] private DarkBody darkBody;
    [SerializeField] private DarkEffect darkEffect;
    [SerializeField] private float baseBodyDestroyTime = 5;

    public void ItemInitializeOfPlayer(int id, Vector3 birtherPos, GameObject racer) {
        var targets = RankManager.Instance.GetSortedRacers();
        
        for(int i=0; i<targets.Length; i++){

            if(targets[i].id == id) {
                continue;
            }

            var destroyTime = baseBodyDestroyTime / Mathf.Sqrt(i+1);

            var darkBodyInstance = Instantiate(
                darkBody,
                targets[i].transform.position,
                Quaternion.identity
            );
            darkBodyInstance.initialize(targets[i], i+1, destroyTime);

            //プレイヤー用のエフェクトを適用
            if(targets[i].CompareTag("Player")){
                Instantiate(darkEffect).initialize(destroyTime);
            }

        }

        Destroy(this);
    }

    public void ItemInitializeOfCPUPlayer(int id, Vector3 birtherPos, GameObject racer) {
        var targets = RankManager.Instance.GetSortedRacersExceptSelf(id);

        // for(int i=0; i<targets.Length; i++){
        //     GameObject obj = (GameObject)Instantiate(
        //         darkBody,
        //         targets[i].transform.position,
        //         Quaternion.identity
        //     );
        //     obj.GetComponent<DarkScript>().targetRank = i+1;

        //     //プレイヤー用のエフェクトを適用
        //     if(targets[i].CompareTag("Player")){
        //         transform.GetChild(0).gameObject.SetActive(true);
        //     }
        // }

        //プレイヤー用のエフェクトを適用
        transform.GetChild(0).gameObject.SetActive(true);
                     

        
    }
}
