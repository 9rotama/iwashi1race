using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CpuController : Racer
{
	[SerializeField] private float nextWaypointDistance;
	[SerializeField] public float scatterFac = 0.1f;

    public Transform target; //targetに向かってCPUが動く
    private Path _path;
    private int _currentWaypoint;
    private Seeker _seeker;
    private float _scX, _scY;

	private void OnPathComplete(Path p)
	{
		if (p.error) return;
		_path = p;
		_currentWaypoint = 0;
	}

	
	private void Start()
    {
        _seeker = GetComponent<Seeker>();
        _rb2D = GetComponent<Rigidbody2D>();

        _seeker.StartPath(_rb2D.position, target.position, OnPathComplete);
        
        _scX = UnityEngine.Random.value - 0.5f;
        _scY = UnityEngine.Random.value - 0.5f;

		_prevPosition = transform.position;

		var gameManager = GameObject.FindGameObjectWithTag(Tag.GameManager);
		_gameManagerCtrl = gameManager.GetComponent<GameManagerControl>();
    }


	private void FixedUpdate()
    {
		if(UnityEngine.Random.Range(0,100) == 0) {
			UseItem();
		}
		//アイテム使用

		if(_gameManagerCtrl.GetGameState() == GameState.Idle || transform.position.x > target.position.x + 10) return;
		
		CalcVelocity();

		if (isStopped)
		{
			StopRb();
			return;
		}
		
        if (_path == null) return;

        if (_currentWaypoint >= _path.vectorPath.Count)
        {
            return;
        }

        var scatterVec = new Vector2(_scX, _scY);
        
        var direction = ((Vector2) _path.vectorPath[_currentWaypoint] - _rb2D.position + scatterVec * scatterFac).normalized;
        
        var orbNum = (float) _magicOrbNum;
        var orbBoost = orbNum * MoveSpeed * MaxRateOfBoostByMagicOrb / MaxMagicOrb;
        
        AddForce((MoveSpeed + orbBoost) * direction);
        
        var distance = Vector2.Distance(_rb2D.position, _path.vectorPath[_currentWaypoint]);

        if (!(distance < nextWaypointDistance)) return;
        _currentWaypoint++;
        _scX = UnityEngine.Random.value - 0.5f;
        _scY = UnityEngine.Random.value - 0.5f;

    }
}
