using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CPU,プレイヤー含めたレーサー（レース選手）を指すクラス
/// </summary>

public class Racer : MonoBehaviour
{
    public int id;

    [SerializeField] private RankManager _rankManager;
    [SerializeField] private ItemControlScript _itemControlScript;

    /// <summary>
    /// レーサーがアイテムを使用するための手続き
    /// </summary>
    
    private void UseItem()
    {
    }

    
    /// <summary>
    /// 指定したIDのレーサーの順位を返す関数
    /// </summary>
    /// <returns>順位の数値</returns>

    public int GetRank()
    {
        return _rankManager.GetRank(id);
    }

}
