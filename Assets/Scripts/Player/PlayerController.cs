using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using KanKikuchi.AudioManager;

public class PlayerController : Racer
{
	private GameObject _goal; 
	private bool _isInGoal;
	
    [SerializeField] private MagicOrbMeterControl magicOrbMeterControl;

    [SerializeField] private ItemRandomDisplay itemRandomDisplay;

	
	/// <summary>
	/// 魔法オーブの取得数をゲージに反映
	/// </summary>
	private void SetMagicOrbMeter(){
		magicOrbMeterControl.SetMeter(_magicOrbNum);
	}

	protected override void UseItem(){
		if(!itemRandomDisplay.isItemUsable) return;
		base.UseItem();
		itemRandomDisplay.enabled = false;
	}
	
	/// <summary>
	/// プレイヤーのマジックオーブの所持量を増やす
	/// ゲージに反映する
	/// </summary>
	/// <param name="num">マジックオーブの増加量</param>
	public override void MagicOrbEnter(int num){
		base.MagicOrbEnter(num);
		SetMagicOrbMeter();
		
		SEManager.Instance.Play(SEPath.MAGIC_ORB);
	}

	/// <summary>
	/// 障害物にぶつかったときにレーサーをスタン状態にし、マジックオーブを没収する
	/// ぶつかった際のSEを再生する
	/// </summary>
	/// <param name="duration">スタン状態の長さ</param>
	/// <param name="lostMagicOrbNum">没収するマジックオーブの数</param>

	public override void StopperEnter(float duration, int lostMagicOrbNum)
	{
		base.StopperEnter(duration, lostMagicOrbNum);
		SetMagicOrbMeter();
	}


	private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
		
		_prevPosition = transform.position;

		_goal = GameObject.FindGameObjectWithTag("Goal");
		_isInGoal = false;

		var gameManager = GameObject.FindGameObjectWithTag("GameManager");
		_gameManagerCtrl = gameManager.GetComponent<GameManagerControl>();
    }
	
	private void FixedUpdate()
    {
		if(_gameManagerCtrl.GetGameState() == GameState.Idle) return;

		CalcVelocity();

		
		if (isStopped)
		{
			StopRb();
			return;
		}
		

        var orbNum = (float) _magicOrbNum;
        var orbBoost = orbNum * MoveSpeed * MaxRateOfBoostByMagicOrb / MaxMagicOrb;

        if (Input.GetKey(KeyCode.D))
        {
            AddForce( (MoveSpeed + orbBoost) * Vector3.right); 
        }
        //アクセル
        
        if (Input.GetKey(KeyCode.A))
        {
            AddForce( (MoveSpeed + orbBoost) * -Vector3.right); 
        }
        //ブレーキ
        
        if (Input.GetKey(KeyCode.W))
        {
            AddForce( (MoveSpeed + orbBoost) * Vector3.up); 
        }
        //上向き
        
        if (Input.GetKey(KeyCode.S))
        {
            AddForce( (MoveSpeed + orbBoost) * -Vector3.up); 
        }
        //下向き
        

        if (!(this.transform.position.x >= _goal.transform.position.x) || _isInGoal) return;
        
        _gameManagerCtrl.PlayerGoal();
		_isInGoal = true;

    }

	private void Update() 
	{
		if (Input.GetMouseButtonDown(0))
		{
			UseItem();
		}
		//アイテムを使う
	}
}
