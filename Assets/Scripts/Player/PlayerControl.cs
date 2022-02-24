using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float handleSpeed;
	
	private GameObject goal; 
	private bool isInGoal;
    
    private Rigidbody2D rb2D;
    private Quaternion forwardRot, upRot, downRot;
    
    private Vector3 forwardVec, upVec;

	private Vector3 prevPosition;
    private Vector2 velocityVec2;
    private float velocity = 0f;

	private AudioSource audioSource;

	[SerializeField] private GameObject itemOrbSEPrefab, magicOrbSEPrefab;

	/*-----------*/
	private GameObject gameManager;
	private GameManagerControl gameManagerCtrl;
	/*-----------*/
	
	public float GetVelocity()
    {
        return velocity; 
    }
	//速度(float)を返す

	public Vector2 GetVelocityVec2()
    {
        return velocityVec2; 
    }
	//速度x成分,y成分(Vector2)を返す

	public void WindEnter(float multiplier){
		rb2D.AddForce(forwardVec * moveSpeed * multiplier); 
	}
	//追い風,向かい風に接触したとき風側から呼び出される




	private GameObject magicOrbMeter;
	private MagicOrbMeterControl magicOrbMeterControl;
	private int magicOrbNum;
	
	private void SetMagicOrbNum(){
		magicOrbMeterControl = magicOrbMeter.GetComponent<MagicOrbMeterControl>();
		magicOrbMeterControl.SetMeter(magicOrbNum);
	}
	//魔法オーブの取得数を返す

	public void MagicOrbEnter(){
		magicOrbNum += 10; 
		if(magicOrbNum > 50) magicOrbNum = 50;
		SetMagicOrbNum();
		
		GameObject sound = Instantiate(magicOrbSEPrefab);
		float endTime = sound.GetComponent<AudioSource>().clip.length;
		Destroy(sound, endTime);	//音のプレハブを作成して再生後削除する
	}
	//魔法オーブ(大)

	public void SmallMagicOrbEnter(){
		magicOrbNum++; 
		if(magicOrbNum > 50) magicOrbNum = 50;
		SetMagicOrbNum();
		
		GameObject sound = Instantiate(magicOrbSEPrefab);
		float endTime = sound.GetComponent<AudioSource>().clip.length;
		Destroy(sound, endTime);	//音のプレハブを作成して再生後削除する
	}
	//魔法オーブの取得数を返す
   	
	public void CrowEnter(){
		magicOrbNum -= 10;
		if(magicOrbNum < 0) magicOrbNum = 0;
		SetMagicOrbNum();
		audioSource.Play();
	}



    void Start()
    {
        rb2D = this.GetComponent<Rigidbody2D>();
		audioSource = GetComponent<AudioSource>();
        
        forwardRot = Quaternion.Euler(0f, 0f, 0f);
        upRot = Quaternion.Euler(0f, 0f, 60.0f);
        downRot = Quaternion.Euler(0f, 0f, -60.0f);

        forwardVec = new Vector3(1.0f, 0f, 0f);
        upVec = new Vector3(0f, 1.0f, 0f);

		prevPosition = transform.position;

		goal = GameObject.FindGameObjectWithTag("Goal");
		isInGoal = false;

		/*-----------*/
		gameManager = GameObject.FindGameObjectWithTag("GameManager");
		gameManagerCtrl = gameManager.GetComponent<GameManagerControl>();
		/*-----------*/
		magicOrbMeter = GameObject.Find("MagicOrbMeter");
    }

    void Update()
    {
		/*-----------*/
		if(gameManagerCtrl.GetGameState() == 0) return;
		/*-----------*/
		
		velocityVec2 = (transform.position - prevPosition) / Time.deltaTime;
        velocity = (float)Math.Sqrt(Math.Pow(velocityVec2.x,2)+Math.Pow(velocityVec2.y,2));
        prevPosition = transform.position;
        // 移動速度計算		

        if (Input.GetKey(KeyCode.D))
        {
            rb2D.AddForce(forwardVec * (moveSpeed + magicOrbNum / 50 * moveSpeed / 10)); 
        }
        //アクセル
        
        if (Input.GetKey(KeyCode.A))
        {
            rb2D.AddForce(-forwardVec * (moveSpeed + magicOrbNum / 50 * moveSpeed / 10)); 
        }
        //ブレーキ
        
        if (Input.GetKey(KeyCode.W))
        {
            rb2D.AddForce(upVec * (moveSpeed + magicOrbNum / 50 * moveSpeed / 10)); 
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, upRot, Time.deltaTime * handleSpeed);
        }
        //上向き
        
        if (Input.GetKey(KeyCode.S))
        {
            rb2D.AddForce(-upVec * (moveSpeed + magicOrbNum / 50 * moveSpeed / 10)); 
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, downRot, Time.deltaTime * handleSpeed);
        }
        //下向き
        
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, forwardRot, Time.deltaTime * handleSpeed);
        }

		if(this.transform.position.x >= goal.transform.position.x && isInGoal == false){
			gameManagerCtrl.PlayerGoal();
			isInGoal = true;
		}

    }
}
