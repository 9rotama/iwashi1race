using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject itemOrbSePrefab;
    [SerializeField] private GameObject magicOrbSePrefab;
	
	private GameObject _goal; 
	private bool _isInGoal;

	private bool _hitCrow = false;
    
    private Rigidbody2D _rb2D;

    private Vector3 _forwardVec, _upVec;

	private Vector3 _prevPosition;
    private Vector2 _velocityVec2;
    private float _velocity = 0f;

    private const float MaxRateOfBoostByMagicOrb = 20f;
    private const int MaxMagicOrb = 50;
    
	private AudioSource _audioSource;
	
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




	private GameObject _magicOrbMeter;
	private MagicOrbMeterControl _magicOrbMeterControl;
	private int _magicOrbNum;
	
	private void SetMagicOrbNum(){
		_magicOrbMeterControl = _magicOrbMeter.GetComponent<MagicOrbMeterControl>();
		_magicOrbMeterControl.SetMeter(_magicOrbNum);
	}
	//魔法オーブの取得数を返す

	public void MagicOrbEnter(int num){
		_magicOrbNum += num; 
		if(_magicOrbNum > 50) _magicOrbNum = 50;
		SetMagicOrbNum();
		
		var sound = Instantiate(magicOrbSePrefab);
		var endTime = sound.GetComponent<AudioSource>().clip.length;
		Destroy(sound, endTime);	//音のプレハブを作成して再生後削除する
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
	
	
	
	

	public void CrowEnter(float multiplier)
	{
		StartCoroutine(nameof(CrowBump));
		
		_magicOrbNum -= 10;
		if(_magicOrbNum < 0) _magicOrbNum = 0;
		SetMagicOrbNum();
		_audioSource.Play();
	}

	private IEnumerator CrowBump()
	{
		_hitCrow = true;
		yield return new WaitForSeconds(1f);
		_hitCrow = false;
	}
	
	
	
	
	
	
	private void Start()
    {
        _rb2D = this.GetComponent<Rigidbody2D>();
		_audioSource = GetComponent<AudioSource>();

		_forwardVec = new Vector3(1.0f, 0f, 0f);
        _upVec = new Vector3(0f, 1.0f, 0f);

		_prevPosition = transform.position;

		_goal = GameObject.FindGameObjectWithTag("Goal");
		_isInGoal = false;

		/*-----------*/
		_gameManager = GameObject.FindGameObjectWithTag("GameManager");
		_gameManagerCtrl = _gameManager.GetComponent<GameManagerControl>();
		/*-----------*/
		_magicOrbMeter = GameObject.Find("MagicOrbMeter");
    }

	private void Update()
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
        // 移動速度計算

        var orbNum = (float) _magicOrbNum;
        var orbBoost = (orbNum / MaxMagicOrb) * moveSpeed / MaxRateOfBoostByMagicOrb;

        if (Input.GetKey(KeyCode.D))
        {
            _rb2D.AddForce(_forwardVec * (moveSpeed + orbBoost)); 
        }
        //アクセル
        
        if (Input.GetKey(KeyCode.A))
        {
            _rb2D.AddForce(-_forwardVec * (moveSpeed + orbBoost)); 
        }
        //ブレーキ
        
        if (Input.GetKey(KeyCode.W))
        {
            _rb2D.AddForce(_upVec * (moveSpeed + orbBoost)); 
        }
        //上向き
        
        if (Input.GetKey(KeyCode.S))
        {
            _rb2D.AddForce(-_upVec * (moveSpeed + orbBoost)); 
        }
        //下向き
        

        if (!(this.transform.position.x >= _goal.transform.position.x) || _isInGoal) return;
        
        _gameManagerCtrl.PlayerGoal();
		_isInGoal = true;

    }
}
