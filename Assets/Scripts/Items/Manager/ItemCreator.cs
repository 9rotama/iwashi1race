using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// アイテムを生成するクラス
/// </summary>
public class ItemCreator : MonoBehaviour
{
    // 生成するアイテム保持する配列
    [SerializeField] private GameObject[] itemObjects;

    /// <summary>
    /// 与えた座標にアイテムを生成する
    /// </summary>
    /// <param name="position">アイテム生成位置</param>
    /// <param name="racer">レーサー</param>
    public void CreateItemGameObject(Racer racer) { 

        // デバッグ
        // if(racer.CompareTag("CPU")){
        //     racer.havingItem = Items.Freeze;
        //     Debug.Log(racer.havingItem);
        // }
        //

        if(racer.havingItem == Items.Nothing) {
            return;
        }

        GameObject itemObj = (GameObject)Instantiate(
                itemObjects[(int)racer.havingItem], 
                racer.transform.position,
                Quaternion.identity
            );

        // アイテムの初期化
        var itemInitializer = itemObj.GetComponent<IItemInitializer>();
        itemInitializer?.ItemInitialize(racer);



        // 所持アイテムをなくす
        racer.havingItem = Items.Nothing;

    }
}

