using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CPUplayerControl : MonoBehaviour
{
    public Transform target;

    public float moveSpeed;
    public float nextWaypointDistance;

    private Path path;
    private int currentWaypoint;

    private bool reachedEndOfPath;

    private Seeker seeker;
    private Rigidbody2D rb2D;
    
    private float scX, scY;
    public float scatterFac = 0.1f;

	private Vector3 forwardVec = new Vector3(1.0f, 0f, 0f);

	private Vector3 prevPosition;
    private Vector2 velocityVec2;
    private float velocity = 0f;

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



	private int magicOrbNum;

	public void MagicOrbEnter(){
		magicOrbNum += 10; 
		if(magicOrbNum > 50) magicOrbNum = 50;
	}
	//魔法オーブ(大)

	public void SmallMagicOrbEnter(){
		magicOrbNum++; 
		if(magicOrbNum > 50) magicOrbNum = 50;
	}
	//魔法オーブの取得数を返す

	public void CrowEnter(){
		magicOrbNum -= 10;
		if(magicOrbNum < 0) magicOrbNum = 0;
	}
    


    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb2D = GetComponent<Rigidbody2D>();

        seeker.StartPath(rb2D.position, target.position, OnPathComplete);
        
        scX = UnityEngine.Random.value - 0.5f;
        scY = UnityEngine.Random.value - 0.5f;

		prevPosition = transform.position;

		/*-----------*/
		gameManager = GameObject.FindGameObjectWithTag("GameManager");
		gameManagerCtrl = gameManager.GetComponent<GameManagerControl>();
		/*-----------*/
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void Update()
    {
		/*-----------*/
		if(gameManagerCtrl.GetGameState() == 0) return;
		/*-----------*/

		velocityVec2 = (transform.position - prevPosition) / Time.deltaTime;
        velocity = (float)Math.Sqrt(Math.Pow(velocityVec2.x,2)+Math.Pow(velocityVec2.y,2));
        prevPosition = transform.position;		


        if (path == null) return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 scatterVec = new Vector2(scX, scY);
        
        Vector2 direction = ((Vector2) path.vectorPath[currentWaypoint] - rb2D.position + scatterVec * scatterFac).normalized;
        Vector2 force = direction * (moveSpeed + magicOrbNum / 50 * moveSpeed / 10) / 1.7f;

        rb2D.AddForce(force);

        //this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(0, 0, Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg - 90), Time.deltaTime);
        
        float distance = Vector2.Distance(rb2D.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
            scX = UnityEngine.Random.value - 0.5f;
            scY = UnityEngine.Random.value - 0.5f;
        }
    }
}
