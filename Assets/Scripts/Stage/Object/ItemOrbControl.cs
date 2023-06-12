using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 触れたレーサーのアイテムを決めるクラス
/// </summary>
public class ItemOrbControl : MonoBehaviour, IRacerCollisionEnterer
{
    private static ItemDecider itemDecider;

    private void Start() 
    {
        if(itemDecider != null) return;

        var obj = GameObject.Find("ItemManager");
        if(obj == null) return; 

        itemDecider = obj.GetComponent<ItemDecider>();
    }

    public void OnTriggerEnterRacer(Racer racer)
    {
        itemDecider?.DecideItem(racer);
        Destroy(this.gameObject);
    }

}
