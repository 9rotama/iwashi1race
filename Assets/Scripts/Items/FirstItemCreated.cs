using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ItemCreator経由で最初にインスタンス化されるアイテム
/// </summary>
public abstract class FirstItemCreated : MonoBehaviour
{
    /// <summary>
    /// アイテムの初期化
    /// </summary>
    public abstract void ItemInitialize(Racer racer);
}
