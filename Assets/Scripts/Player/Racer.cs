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

	/// <summary> 停止状態か否か保持する </summary>
	[System.NonSerialized] public bool isStopped  = false;
	
    [SerializeField] private ItemCreator itemCreator;
   
    protected const float MoveSpeed = 180f;
    protected int _magicOrbNum;
    protected const int MaxMagicOrb = 50;
    protected Vector2 _velocityVec2;
    protected float _velocity = 0f;
    protected Rigidbody2D _rb2D;
    protected const float MaxRateOfBoostByMagicOrb = 0.5f;
    protected Vector3 _prevPosition;
    protected GameManagerControl _gameManagerCtrl;

    /// <summary>
    /// レーサーがアイテムを使用するための手続き
    /// </summary>
    
    protected virtual void UseItem()
    {
		if(isStopped) return;
        itemCreator.CreateItemGameObject(this);
    }


    /// <summary>
	/// レーサーの速度を返す
	/// </summary>
	/// <returns>速度</returns>
	public float GetVelocity()
    {
        return _velocity; 
    }

    /// <summary>
	/// レーサーの速度x成分,y成分(Vector2)を返す
	/// </summary>
	/// <returns>速度のVector2</returns>
	public Vector2 GetVelocityVec2()
    {
        return _velocityVec2; 
    }


    /// <summary>
	/// レーサーのマジックオーブの所持量を増やす
	/// ゲージに反映する
	/// </summary>
	/// <param name="num">マジックオーブの増加量</param>
	public virtual void MagicOrbEnter(int num){
		_magicOrbNum += num; 
		if(_magicOrbNum > MaxMagicOrb) _magicOrbNum = MaxMagicOrb;
	}

    /// <summary>
	/// レーサーにベクトルの方向に力を加える
	/// </summary>
	/// <param name="force">力</param>
    public void AddForce(Vector2 force){
		_rb2D.AddForce(force); 
	}

    protected void StopRb()
    {
	    _rb2D.velocity = new Vector2(0, 0);
    }

    protected void CalcVelocity()
    {
	    var position = transform.position;
	    _velocityVec2 = (position - _prevPosition) / Time.deltaTime;
	    _velocity = (float)Math.Sqrt(Math.Pow(_velocityVec2.x,2)+Math.Pow(_velocityVec2.y,2));
	    _prevPosition = position;	
    }

    /// <summary>
	/// 障害物にぶつかったときにレーサーをスタン状態にし、マジックオーブを没収する
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
	/// 指定された時間レーサーをスタン状態にする
	/// </summary>
	/// <param name="duration">スタン状態の長さ</param>
	private IEnumerator StopperBump(float duration)
	{
		isStopped = true;
		yield return new WaitForSeconds(duration);
		isStopped = false;
	}

	protected void OnTriggerEnter2D(Collider2D other)
	{
		var racerCollision = other.gameObject.GetComponent<IRacerCollisionEnterer>();
		racerCollision?.OnTriggerEnterRacer(this);
	}

	protected void OnTriggerStay2D(Collider2D other) 
	{
        var racerCollision = other.gameObject.GetComponent<IRacerCollisionStayer>();
        racerCollision?.OnTriggerStayRacer(this);
	}

}
