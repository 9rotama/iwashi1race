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

        foreach (var t in targets)
        {
            if(racer.id != t.id){
                Instantiate(
                    thunder, 
                    t.transform.position + Vector3.up * 25,  
                    Quaternion.identity
                ).Initialize(t);
            }
        }

        Destroy(this.gameObject);
    }

    
}
