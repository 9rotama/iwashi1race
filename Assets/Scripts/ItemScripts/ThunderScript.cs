using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ThunderScript : MonoBehaviour, IItemInitializer
{
    [SerializeField] private GameObject thunderSprite;

    public void ItemInitialize(Racer racer) {
        var targets = RankManager.Instance.GetSortedRacers();

        for(int i=0; i<targets.Length; i++){
            if(racer.id != targets[i].id){
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
