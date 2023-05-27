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
    /// レーサーの座標にアイテムを生成する
    /// </summary>
    /// <param name="racer">レーサークラスを持つGameObject</param>
    public void CreateItemGameObject(GameObject racer) {
        Items havingItem = racer.GetComponent<Racer>().havingItem;

        GameObject itemObj = (GameObject)Instantiate(
                itemObjects[(int)havingItem], 
                racer.transform.position, 
                Quaternion.identity
            );
        
        // itemObjを作った生みの親(レーサー)のIDを保持する
        itemObj.GetComponent<CollisionObject>().birtherId = racer.GetComponent<Racer>().id;

        if(havingItem == Items.Bubble) {
            itemObj.transform.SetParent(racer.transform);
        } 
        else {
            // 何もしない
        }

        // 所持アイテムをなくす
        racer.GetComponent<Racer>().havingItem = Items.Nothing;

        //!Playerクラスに移行するかどうか↓
        // randomItemUI.SetActive(false);

    }






}
