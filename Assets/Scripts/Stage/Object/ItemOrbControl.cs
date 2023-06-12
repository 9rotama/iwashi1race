using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 触れたレーサーのアイテムを決めるクラス
/// </summary>
public class ItemOrbControl : MonoBehaviour, IRacerCollisionEnterer
{

    private static ItemDecider itemDecider;
    private OrbSpawner _parentOrbSpawner;

    public void OnTriggerEnterRacer(Racer racer)
    {
        itemDecider?.DecideItem(racer);
        _parentOrbSpawner.OrbDestroyed();
        Destroy(this.gameObject);
    }
    
    private void Start() 
    {
        _parentOrbSpawner = transform.parent.GetComponent<OrbSpawner>();

        if(itemDecider != null) return;
        
        var obj = GameObject.Find("ItemManager");
        if(obj == null) return; 

        itemDecider = obj.GetComponent<ItemDecider>();
    }

}
