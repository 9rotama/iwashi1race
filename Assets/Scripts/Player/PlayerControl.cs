using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerControl : Racer
{
    [SerializeField] private float moveSpeed = 1000f;
    [SerializeField] private GameObject itemOrbSePrefab;
    [SerializeField] private GameObject magicOrbSePrefab;
	
    private const int MaxMagicOrb = 50;
    private const float MaxRateOfBoostByMagicOrb = 20f;

    private static Vector3 ForwardVec => new Vector3(1.0f, 0f, 0f);

    private static Vector3 UpVec => new Vector3(0f, 1.0f, 0f);

    private Rigidbody2D _rb2D;
    private GameObject _goal; 
	private bool _isInGoal;
	private bool _isStopped = false;
	private Vector3 _prevPosition;
    private Vector2 _velocityVec2;
    private float _velocity = 0f;
    
    private MagicOrbMeterControl _magicOrbMeterControl;
    private int _magicOrbNum;
    
	private AudioSource _audioSource;
	
	private GameManagerControl _gameManagerCtrl;
	
	/// <summary>
	/// プレイヤーの速度を返す
	/// </summary>
	/// <returns>速度</returns>
	public override float GetVelocity()
    {
        return _velocity; 
    }

	/// <summary>
	/// プレイヤーの速度x成分,y成分(Vector2)を返す
	/// </summary>
	/// <returns>速度のVector2</returns>
	public override Vector2 GetVelocityVec2()
    {
        return _velocityVec2; 
    }

	/// <summary>
	/// 魔法オーブの取得数をゲージに反映
	/// </summary>
	private void SetMagicOrbMeter(){
		_magicOrbMeterControl.SetMeter(_magicOrbNum);
	}

	/// <summary>
	/// 追い風,向かい風に侵入している間プレイヤーに風力を加える
	/// 風のコントローラ側から呼び出される
	/// </summary>
	/// <param name="multiplier">風の強さの係数</param>
	public override void WindStay(float multiplier){
		_rb2D.AddForce(ForwardVec * Time.deltaTime * multiplier); 
	}

	/// <summary>
	/// プレイヤーのマジックオーブの所持量を増やす
	/// ゲージに反映する
	/// </summary>
	/// <param name="num">マジックオーブの増加量</param>
	public void MagicOrbEnter(int num){
		_magicOrbNum += num; 
		if(_magicOrbNum > MaxMagicOrb) _magicOrbNum = MaxMagicOrb;
		SetMagicOrbMeter();
		
		//音のプレハブを作成して再生後削除する
		var sound = Instantiate(magicOrbSePrefab);
		var endTime = sound.GetComponent<AudioSource>().clip.length;
		Destroy(sound, endTime);
	}

	/// <summary>
	/// 障害物にぶつかったときにプレイヤーをスタン状態にし、マジックオーブを没収する
	/// </summary>
	/// <param name="duration">スタン状態の長さ</param>
	/// <param name="lostMagicOrbNum">没収するマジックオーブの数</param>
	public override void StopperEnter(float duration, int lostMagicOrbNum)
	{
		StartCoroutine(StopperBump(duration));
		
		_magicOrbNum -= lostMagicOrbNum;
		if(_magicOrbNum < 0) _magicOrbNum = 0;
		SetMagicOrbMeter();
		_audioSource.Play();
	}

	/// <summary>
	/// 障害物にぶつかったときにプレイヤーをスタン状態にし、マジックオーブを没収する
	/// </summary>
	/// <param name="duration">スタン状態の長さ</param>
	protected override IEnumerator StopperBump(float duration)
	{
		_isStopped = true;
		yield return new WaitForSeconds(duration);
		_isStopped = false;
	}


	protected override void OnTriggerEnter2D(Collider2D other)
	{
		var playerCollision = other.gameObject.GetComponent<IPlayerCollisionEnterer>();
 		playerCollision?.OnTriggerEnterPlayer(gameObject);
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

	private void Update()
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
        var orbBoost = (orbNum / MaxMagicOrb) * moveSpeed / MaxRateOfBoostByMagicOrb;

        if (Input.GetKey(KeyCode.D))
        {
            _rb2D.AddForce(ForwardVec * (moveSpeed * Time.deltaTime * 16 + orbBoost)); 
        }
        //アクセル
        
        if (Input.GetKey(KeyCode.A))
        {
            _rb2D.AddForce(-ForwardVec * (moveSpeed * Time.deltaTime * 16 + orbBoost)); 
        }
        //ブレーキ
        
        if (Input.GetKey(KeyCode.W))
        {
            _rb2D.AddForce(UpVec * (moveSpeed * Time.deltaTime * 16 + orbBoost)); 
        }
        //上向き
        
        if (Input.GetKey(KeyCode.S))
        {
            _rb2D.AddForce(-UpVec * (moveSpeed * Time.deltaTime * 16 + orbBoost)); 
        }
        //下向き
        

        if (!(this.transform.position.x >= _goal.transform.position.x) || _isInGoal) return;
        
        _gameManagerCtrl.PlayerGoal();
		_isInGoal = true;

    }
}
