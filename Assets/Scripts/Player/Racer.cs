using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CPU,プレイヤー含めたレーサー（レース選手）を指すクラス
/// </summary>

public class Racer : MonoBehaviour
{
    /// <summary> 識別固有番号 </summary>
    public int id { get;}

    /// <summary> 所持しているアイテム </summary>
    public Items havingItem;

    [SerializeField] private RankManager rankManager;
    [SerializeField] private ItemCreator itemCreator;

    /// <summary>
    /// レーサーがアイテムを使用するための手続き
    /// </summary>
    
    private void UseItem()
    {
        itemCreator.CreateItemGameObject(gameObject);
    }

    
    /// <summary>
    /// 指定したIDのレーサーの順位を返す関数
    /// </summary>
    /// <returns>順位の数値</returns>

    public int GetRank()
    {
        return rankManager.GetRank(id);
    }

}
