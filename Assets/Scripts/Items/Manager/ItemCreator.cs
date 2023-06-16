using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// アイテムを生成するクラス
/// </summary>
public class ItemCreator : MonoBehaviour
{
    // 生成するアイテム保持する配列
    [SerializeField] private FirstItemCreated[] firstItemsCreated;

    /// <summary>
    /// 与えた座標にアイテムを生成する
    /// </summary>
    /// <param name="position">アイテム生成位置</param>
    /// <param name="racer">レーサー</param>
    public void CreateItemGameObject(Racer racer) { 

        // デバッグ
        // if(racer.CompareTag(Tag.CPU)){
        //     racer.havingItem = Items.Freeze;
        //     Debug.Log(racer.havingItem);
        // }
        //

        if(racer.havingItem == Items.Nothing) {
            return;
        }

        // アイテムの生成と初期化
        Instantiate(
            firstItemsCreated[(int)racer.havingItem], 
            racer.transform.position,
            Quaternion.identity
        ).ItemInitialize(racer);

        // 所持アイテムをなくす
        racer.havingItem = Items.Nothing;

    }
}

