using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ThunderCreator : MonoBehaviour, IItemInitializer
{
    [SerializeField] private Thunder thunder;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="racer"></param>
    public void ItemInitialize(Racer racer) {
        var targets = RankManager.Instance.GetSortedRacers();
        Debug.Log(targets);

        for(int i=0; i<targets.Length; i++){
            if(racer.id != targets[i].id){
                Instantiate(
                    thunder, 
                    targets[i].transform.position + Vector3.up * 25,  
                    Quaternion.identity
                ).Initialize(targets[i]);
            }
        }

         Destroy(this.gameObject);
    }

    
}
