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
    protected bool _isStopped = false;
    protected int _magicOrbNum;
    protected const int MaxMagicOrb = 50;
    protected Vector2 _velocityVec2;
    protected float _velocity = 0f;
    [SerializeField] protected Rigidbody2D _rb2D;
    protected static Vector3 ForwardVec = Vector3.right;
    [SerializeField] protected float moveSpeed = 1000f;
    protected const float MaxRateOfBoostByMagicOrb = 20f;
    protected Vector3 _prevPosition;
    protected GameManagerControl _gameManagerCtrl;

    /// <summary>
    /// レーサーがアイテムを使用するための手続き
    /// </summary>
    
    protected void UseItem()
    {
        itemCreator.CreateItemGameObject(this);
    }


    /// <summary>
	/// プレイヤーの速度を返す
	/// </summary>
	/// <returns>速度</returns>
	public float GetVelocity()
    {
        return _velocity; 
    }

    /// <summary>
	/// プレイヤーの速度x成分,y成分(Vector2)を返す
	/// </summary>
	/// <returns>速度のVector2</returns>
	public Vector2 GetVelocityVec2()
    {
        return _velocityVec2; 
    }


    /// <summary>
	/// プレイヤーのマジックオーブの所持量を増やす
	/// ゲージに反映する
	/// </summary>
	/// <param name="num">マジックオーブの増加量</param>
	public virtual void MagicOrbEnter(int num){
		_magicOrbNum += num; 
		if(_magicOrbNum > MaxMagicOrb) _magicOrbNum = MaxMagicOrb;
	}

    /// <summary>
	/// プレイヤーにベクトルの方向に力を加える
	/// </summary>
	/// <param name="multiplier">力の強さの係数</param>
	public void AddForce(float multiplier, Vector3 vector){
		_rb2D.AddForce(vector * multiplier); 
	}

    /// <summary>
	/// 障害物にぶつかったときにプレイヤーをスタン状態にし、マジックオーブを没収する
	/// </summary>
	/// <param name="duration">スタン状態の長さ</param>
	/// <param name="lostMagicOrbNum">没収するマジックオーブの数</param>
    public virtual void StopperEnter(float duration, int lostMagicOrbNum)
	{
		StartCoroutine(StopperBump(duration));
		
		_magicOrbNum -= lostMagicOrbNum;
		if(_magicOrbNum < 0) _magicOrbNum = 0;
	}


   	/// <summary>
	/// 障害物にぶつかったときにレーサーをスタン状態にし、マジックオーブを没収する
	/// </summary>
	/// <param name="duration">スタン状態の長さ</param>
	protected IEnumerator StopperBump(float duration)
	{
		_isStopped = true;
		yield return new WaitForSeconds(duration);
		_isStopped = false;
	}

	protected void OnTriggerEnter2D(Collider2D other)
	{
		var racerCollision = other.gameObject.GetComponent<IRacerCollisionEnterer>();
        if(racerCollision != null) {
            racerCollision.OnTriggerEnterRacer(this);
        }
	}

	protected void OnTriggerStay2D(Collider2D other) 
	{
        var racerCollision = other.gameObject.GetComponent<IRacerCollisionStayer>();
        if(racerCollision != null) {
            racerCollision.OnTriggerStayRacer(this);
        }
	}

}
