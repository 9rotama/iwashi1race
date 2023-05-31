using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// レーサーが使うアイテムの列挙型
/// </summary>
public enum Items {
    Wind,
    Dark,
    Thunder,
    Fire,
    Bubble,
    Orb,
    Freeze,
    Nothing,
};

/// <summary>
/// アイテムを生成するクラス
/// </summary>
public class ItemCreator : MonoBehaviour
{
    // 生成するアイテム保持する配列
    [SerializeField] private GameObject[] itemObjects;

    //!Playerクラスに移行するかどうか
    // [SerializeField] GameObject randomItemUI;

    /// <summary>
    /// 与えた座標にアイテムを生成する
    /// </summary>
    /// <param name="position">アイテム生成位置</param>
    /// <param name="racer">レーサー</param>
    public void CreateItemGameObject(GameObject racerObject, Racer racer) { 

        // デバッグ
        racer.havingItem = Items.Dark;
        Debug.Log(racer.havingItem);

        if(racer.havingItem == Items.Nothing) {
            return;
        }

        GameObject itemObj = (GameObject)Instantiate(
                itemObjects[(int)racer.havingItem], 
                racerObject.transform.position,
                Quaternion.identity
            );
        
        // itemObjを作った生みの親(レーサー)のIDを保持する
        // itemObj.GetComponent<CollisionEnterObject>().birtherId = racer.id;

        // レーサーの派生クラスによって初期化を変える
        if(racer is CPUplayerControl){
            itemObj.GetComponent<IItemInitializerOfCPUPlayer>().ItemInitializeOfCPUPlayer(racer.id, racerObject.transform.position, racerObject);
        }
        else if(racer is PlayerControl){
            itemObj.GetComponent<IItemInitializerOfPlayer>().ItemInitializeOfPlayer(racer.id, racerObject.transform.position, racerObject);
        }
        else {
            //何もしない
        }


        if(racer.havingItem == Items.Bubble) {
            itemObj.transform.SetParent(racer.transform);
        } 
        else {
            // 何もしない
        }

        // 所持アイテムをなくす
        racer.havingItem = Items.Nothing;

        //!Playerクラスに移行するかどうか↓
        // randomItemUI.SetActive(false);

    }






}
