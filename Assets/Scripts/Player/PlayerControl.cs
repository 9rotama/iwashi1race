using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerControl : Racer
{
    [SerializeField] private GameObject itemOrbSePrefab;
    [SerializeField] private GameObject magicOrbSePrefab;
    
    private GameObject _goal; 
	private bool _isInGoal;
	
    private MagicOrbMeterControl _magicOrbMeterControl;
	private AudioSource _audioSource;
	
	/// <summary>
	/// 魔法オーブの取得数をゲージに反映
	/// </summary>
	private void SetMagicOrbMeter(){
		_magicOrbMeterControl.SetMeter(_magicOrbNum);
	}
	
	/// <summary>
	/// プレイヤーのマジックオーブの所持量を増やす
	/// ゲージに反映する
	/// </summary>
	/// <param name="num">マジックオーブの増加量</param>
	public override void MagicOrbEnter(int num){
		base.MagicOrbEnter(num);
		SetMagicOrbMeter();
		
		//音のプレハブを作成して再生後削除する
		var sound = Instantiate(magicOrbSePrefab);
		var endTime = sound.GetComponent<AudioSource>().clip.length;
		Destroy(sound, endTime);
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
		_audioSource.Play();
	}


	private void Start()
    {
        _rb2D = this.GetComponent<Rigidbody2D>();
		_audioSource = GetComponent<AudioSource>();
		
		_prevPosition = transform.position;

		_goal = GameObject.FindGameObjectWithTag("Goal");
		_isInGoal = false;

		var gameManager = GameObject.FindGameObjectWithTag("GameManager");
		_gameManagerCtrl = gameManager.GetComponent<GameManagerControl>();
		var magicOrbMeter = GameObject.Find("MagicOrbMeter");
		_magicOrbMeterControl = magicOrbMeter.GetComponent<MagicOrbMeterControl>();

    }
	
	private void FixedUpdate()
    {
		if(_gameManagerCtrl.GetGameState() == 0) return;
		//レースがスタートしていなければ処理しない

		if (_isStopped)
		{
			_rb2D.velocity /= 5;
			return;
		}

		var position = transform.position;
		_velocityVec2 = (position - _prevPosition) / Time.deltaTime;
        _velocity = (float)Math.Sqrt(Math.Pow(_velocityVec2.x,2)+Math.Pow(_velocityVec2.y,2));
        _prevPosition = position;
        // 移動速度計算

        var orbNum = (float) _magicOrbNum;
        var orbBoost = orbNum * MoveSpeed * MaxRateOfBoostByMagicOrb / MaxMagicOrb;

        if (Input.GetKey(KeyCode.D))
        {
            AddForce( MoveSpeed + orbBoost, Vector3.right); 
        }
        //アクセル
        
        if (Input.GetKey(KeyCode.A))
        {
            AddForce( MoveSpeed + orbBoost, -Vector3.right); 
        }
        //ブレーキ
        
        if (Input.GetKey(KeyCode.W))
        {
            AddForce( MoveSpeed + orbBoost, Vector3.up); 
        }
        //上向き
        
        if (Input.GetKey(KeyCode.S))
        {
            AddForce( MoveSpeed + orbBoost, -Vector3.up); 
        }
        //下向き

		if (Input.GetMouseButtonDown(0))
		{
			UseItem();
		}
		//アイテムを使う
        

        if (!(this.transform.position.x >= _goal.transform.position.x) || _isInGoal) return;
        
        _gameManagerCtrl.PlayerGoal();
		_isInGoal = true;

    }
}
