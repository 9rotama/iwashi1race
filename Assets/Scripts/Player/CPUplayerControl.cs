using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CPUplayerControl : MonoBehaviour
{
    public Transform target;

    private bool _hitCrow = false;
    
    public float moveSpeed;
    public float nextWaypointDistance;

    private Path _path;
    private int _currentWaypoint;

    private bool _reachedEndOfPath;

    private Seeker _seeker;
    private Rigidbody2D _rb2D;
    
    private float _scX, _scY;
    public float scatterFac = 0.1f;

	private readonly Vector3 _forwardVec = new Vector3(1.0f, 0f, 0f);

	private Vector3 _prevPosition;
    private Vector2 _velocityVec2;
    private float _velocity = 0f;
    
    private const float MaxRateOfBoostByMagicOrb = 20f;
    private const int MaxMagicOrb = 50;

	/*-----------*/
	private GameObject _gameManager;
	private GameManagerControl _gameManagerCtrl;
	/*-----------*/

	public float GetVelocity()
    {
        return _velocity; 
    }
	//速度(float)を返す

	public Vector2 GetVelocityVec2()
    {
        return _velocityVec2; 
    }
	//速度x成分,y成分(Vector2)を返す

	public void WindEnter(float multiplier){
		_rb2D.AddForce(_forwardVec * moveSpeed * multiplier); 
	}
	//追い風,向かい風に接触したとき風側から呼び出される



	private int _magicOrbNum;

	public void MagicOrbEnter(int num){
		_magicOrbNum += num; 
		if(_magicOrbNum > 50) _magicOrbNum = 50;
	}
	//魔法オーブ(大)
	
	/*
	 public void SmallMagicOrbEnter(){
		_magicOrbNum++; 
		if(_magicOrbNum > 50) _magicOrbNum = 50;
		SetMagicOrbNum();
		
		var sound = Instantiate(magicOrbSePrefab);
		var endTime = sound.GetComponent<AudioSource>().clip.length;
		Destroy(sound, endTime);	//音のプレハブを作成して再生後削除する
	}
	*/

	public void CrowEnter(float multiplier){
		StartCoroutine(nameof(CrowBump));
		
		_magicOrbNum -= 10;
		if(_magicOrbNum < 0) _magicOrbNum = 0;
	}

	private IEnumerator CrowBump()
	{
		_hitCrow = true;
		yield return new WaitForSeconds(1f);
		_hitCrow = false;
	}



	void Start()
    {
        _seeker = GetComponent<Seeker>();
        _rb2D = GetComponent<Rigidbody2D>();

        _seeker.StartPath(_rb2D.position, target.position, OnPathComplete);
        
        _scX = UnityEngine.Random.value - 0.5f;
        _scY = UnityEngine.Random.value - 0.5f;

		_prevPosition = transform.position;

		/*-----------*/
		_gameManager = GameObject.FindGameObjectWithTag("GameManager");
		_gameManagerCtrl = _gameManager.GetComponent<GameManagerControl>();
		/*-----------*/
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            _path = p;
            _currentWaypoint = 0;
        }
    }

    void Update()
    {
		/*-----------*/
		if(_gameManagerCtrl.GetGameState() == 0) return;
		/*-----------*/
		
		if (_hitCrow)
		{
			_rb2D.velocity /= 5;
			return;
		}

		_velocityVec2 = (transform.position - _prevPosition) / Time.deltaTime;
        _velocity = (float)Math.Sqrt(Math.Pow(_velocityVec2.x,2)+Math.Pow(_velocityVec2.y,2));
        _prevPosition = transform.position;		


        if (_path == null) return;

        if (_currentWaypoint >= _path.vectorPath.Count)
        {
            _reachedEndOfPath = true;
            return;
        }
        else
        {
            _reachedEndOfPath = false;
        }

        var scatterVec = new Vector2(_scX, _scY);
        
        var direction = ((Vector2) _path.vectorPath[_currentWaypoint] - _rb2D.position + scatterVec * scatterFac).normalized;
        
        var orbNum = (float) _magicOrbNum;
        var orbBoost = (orbNum / MaxMagicOrb) * moveSpeed / MaxRateOfBoostByMagicOrb;
        
        var force = direction * (moveSpeed + orbBoost);
		
        _rb2D.AddForce(force);

        //this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(0, 0, Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg - 90), Time.deltaTime);
        
        var distance = Vector2.Distance(_rb2D.position, _path.vectorPath[_currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            _currentWaypoint++;
            _scX = UnityEngine.Random.value - 0.5f;
            _scY = UnityEngine.Random.value - 0.5f;
        }
    }
}
