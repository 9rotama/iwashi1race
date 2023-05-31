using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ThunderScript : MonoBehaviour, IItemInitializer
{
    [SerializeField] private GameObject thunderSprite;



    public void ItemInitializeOfPlayer(int id, Vector3 birtherPos, GameObject racer) {
        var targets = RankManager.Instance.GetSortedRacers();

        for(int i=0; i<targets.Length; i++){
            if(id != targets[i].GetComponent<Racer>().id){
                GameObject obj = (GameObject)Instantiate(
                    thunderSprite, 
                    targets[i].transform.position + Vector3.up * 25,  
                    Quaternion.identity
                );
                obj.GetComponent<ThunderSpriteScript>().rank = i+1;
                obj.transform.parent = targets[i].transform;
            }
        }

         Destroy(this.gameObject);
    }

    public void ItemInitializeOfCPUPlayer(int id, Vector3 birtherPos, GameObject racer) {
        var targets =  RankManager.Instance.GetSortedRacers();
        
        for(int i=0; i<targets.Length; i++){
            if(id != targets[i].GetComponent<Racer>().id){
                GameObject obj = (GameObject)Instantiate(
                    thunderSprite, 
                    targets[i].transform.position + Vector3.up * 25,  
                    Quaternion.identity
                );
                obj.GetComponent<ThunderSpriteScript>().rank = i+1;
                obj.transform.parent = targets[i].transform;
            }
        }

         Destroy(this.gameObject);
    }


    
}
