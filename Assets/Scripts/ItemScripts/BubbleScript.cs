using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour, IItemInitializer
{
    GameObject itemControl;
    ItemControlScript itemScript;

    private Racer parentRacer;

    public void ItemInitializeOfPlayer(int id, Vector3 birtherPos, GameObject racer) {
        //発射音
     
    }

    public void ItemInitializeOfCPUPlayer(int id, Vector3 birtherPos, GameObject racer) {
        transform.parent = racer.transform;
        parentRacer = racer.GetComponent<Racer>();
        parentRacer.isInvincible = true;

        // レーサーオブジェクトの子オブジェクトにすでにBubbleがある場合破棄する
        for(int i=0; i<racer.transform.childCount; i++){
            if(racer.transform.GetChild(i).gameObject.name.Contains("Bubble")){
                Destroy(gameObject);
            };
        }
    }

    void Update()
    {
        if(parentRacer != null && !parentRacer.isInvincible) {
            Destroy(gameObject);
        }
    }
}
