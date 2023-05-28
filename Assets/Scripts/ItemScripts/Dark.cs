using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dark : MonoBehaviour, IItemInitializer
{
    [SerializeField] private GameObject darkBody;
    [SerializeField] private RankManager rankManager;

    public void ItemInitializeOfPlayer(int id, Vector3 birtherPos, GameObject racer) {
        var targets = rankManager.GetSortedRacers();
        
        for(int i=0; i<targets.Length; i++){
            GameObject obj = (GameObject)Instantiate(
                darkBody,
                targets[i].transform.position,
                Quaternion.identity
            );
            obj.GetComponent<DarkScript>().targetRank = i+1;

            //プレイヤー用のエフェクトを適用
            if(targets[i] != racer && targets[i].CompareTag("Player")){
                transform.GetChild(0).gameObject.SetActive(true);
            }
        }


    }

    public void ItemInitializeOfCPUPlayer(int id, Vector3 birtherPos, GameObject racer) {
        var targets = rankManager.GetSortedRacers();
        
        for(int i=0; i<targets.Length; i++){
            GameObject obj = (GameObject)Instantiate(
                darkBody,
                targets[i].transform.position,
                Quaternion.identity
            );
            obj.GetComponent<DarkScript>().targetRank = i+1;

            //プレイヤー用のエフェクトを適用
            if(targets[i] != racer && targets[i].CompareTag("Player")){
                transform.GetChild(0).gameObject.SetActive(true);
            }
        }

        //プレイヤー用のエフェクトを適用
        transform.GetChild(0).gameObject.SetActive(true);
                     

        
    }
}
