using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CPUplayerControl : Racer
{
	[SerializeField] private float moveSpeed = 1000f;
	[SerializeField] private float nextWaypointDistance;
	[SerializeField] public float scatterFac = 0.1f;

	
    private const float MaxRateOfBoostByMagicOrb = 20f;
    private const int MaxMagicOrb = 50;
    
    public Transform target; //targetに向かってCPUが動く

    private bool _isStopped = false;
    

    private Path _path;
    private int _currentWaypoint;
    
    private Seeker _seeker;
    private Rigidbody2D _rb2D;
    
    private float _scX, _scY;

	private readonly Vector3 _forwardVec = new Vector3(1.0f, 0f, 0f);

	private Vector3 _prevPosition;
    private Vector2 _velocityVec2;
    private float _velocity = 0f;
    
    private int _magicOrbNum;

    
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
	/// プレイヤーのマジックオーブの所持量を増やす
	/// ゲージに反映する
	/// </summary>
	/// <param name="num">マジックオーブの増加量</param>
	public override void MagicOrbEnter(int num){
		_magicOrbNum += num; 
		if(_magicOrbNum > 50) _magicOrbNum = 50;
	}
	
	/// <summary>
	/// 追い風,向かい風に侵入している間プレイヤーに風力を加える
	/// 風のコントローラ側から呼び出される
	/// </summary>
	/// <param name="multiplier">風の強さの係数</param>
	public override void WindStay(float multiplier){
		_rb2D.AddForce(_forwardVec * multiplier); 
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

	private void OnPathComplete(Path p)
	{
		if (p.error) return;
		_path = p;
		_currentWaypoint = 0;
	}

	protected override void OnTriggerEnter2D(Collider2D other)
	{
		var cpuPlayerCollision = other.gameObject.GetComponent<ICPUPlayerCollisionEnterer>();
		if(cpuPlayerCollision != null){
			cpuPlayerCollision.OnTriggerEnterCPUPlayer(gameObject);
		}
		
	}

	protected override void OnTriggerStay2D(Collider2D other) 
	{
		var cpuPlayerCollision = other.gameObject.GetComponent<ICPUPlayerCollisionStayer>();
		if(cpuPlayerCollision != null){
			cpuPlayerCollision.OnTriggerStayCPUPlayer(gameObject);
		}
	}
	
	private void Start()
    {
        _seeker = GetComponent<Seeker>();
        _rb2D = GetComponent<Rigidbody2D>();

        _seeker.StartPath(_rb2D.position, target.position, OnPathComplete);
        
        _scX = UnityEngine.Random.value - 0.5f;
        _scY = UnityEngine.Random.value - 0.5f;

		_prevPosition = transform.position;

		var gameManager = GameObject.FindGameObjectWithTag("GameManager");
		_gameManagerCtrl = gameManager.GetComponent<GameManagerControl>();
    }


	private void Update()
    {
		// if(UnityEngine.Random.Range(0,100) == 0) {
		// 	UseItem();
		// }
		//アイテム使用

		if(_gameManagerCtrl.GetGameState() == 0 || transform.position.x > target.position.x + 10) return;
		
		if (_isStopped)
		{
			_rb2D.velocity /= 5;
			return;
		}

		var position = transform.position;
		_velocityVec2 = (position - _prevPosition) / Time.deltaTime;
        _velocity = (float)Math.Sqrt(Math.Pow(_velocityVec2.x,2)+Math.Pow(_velocityVec2.y,2));
        _prevPosition = position;		


        if (_path == null) return;

        if (_currentWaypoint >= _path.vectorPath.Count)
        {
            return;
        }

        var scatterVec = new Vector2(_scX, _scY);
        
        var direction = ((Vector2) _path.vectorPath[_currentWaypoint] - _rb2D.position + scatterVec * scatterFac).normalized;
        
        var orbNum = (float) _magicOrbNum;
        var orbBoost = (orbNum / MaxMagicOrb) * moveSpeed / MaxRateOfBoostByMagicOrb;
        
        var force = direction * (moveSpeed * Time.deltaTime * 16 + orbBoost);
        _rb2D.AddForce(force);
        
        var distance = Vector2.Distance(_rb2D.position, _path.vectorPath[_currentWaypoint]);

        if (!(distance < nextWaypointDistance)) return;
        _currentWaypoint++;
        _scX = UnityEngine.Random.value - 0.5f;
        _scY = UnityEngine.Random.value - 0.5f;
    }
}
