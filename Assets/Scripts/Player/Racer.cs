using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CPU,プレイヤー含めたレーサー（レース選手）を指すクラス
/// </summary>

public abstract class Racer : MonoBehaviour
{
    /// <summary> 識別固有番号 </summary>
    [field: SerializeField] public int id { get; private set;}

    /// <summary> 所持しているアイテム </summary>
    [System.NonSerialized] public Items havingItem = Items.Nothing;

    /// <summary> 無敵状態か否か保持する </summary>
    [System.NonSerialized] public bool isInvincible = false;

    [SerializeField] private ItemCreator itemCreator;

    /// <summary>
    /// レーサーがアイテムを使用するための手続き
    /// </summary>
    
    protected void UseItem()
    {
        itemCreator.CreateItemGameObject(this.gameObject, this);
    }

    
    /// <summary>
    /// 指定したIDのレーサーの順位を返す関数
    /// </summary>
    /// <returns>順位の数値</returns>


    public abstract float GetVelocity();

    public abstract Vector2 GetVelocityVec2();
    public abstract void MagicOrbEnter(int num);
    public abstract void WindStay(float multiplier);

    public abstract void StopperEnter(float duration, int lostMagicOrbNum);

    protected abstract IEnumerator StopperBump(float duration);

    protected abstract void OnTriggerEnter2D(Collider2D other);

    protected abstract void OnTriggerStay2D(Collider2D other);

}
