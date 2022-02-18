using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float handleSpeed;
    
    private Rigidbody2D rb2D;
    private Quaternion forwardRot, upRot, downRot;
    
    private Vector3 forwardVec, upVec;
    
    void Start()
    {
        rb2D = this.GetComponent<Rigidbody2D>();
        
        
        forwardRot = Quaternion.Euler(0f, 0f, 0f);
        upRot = Quaternion.Euler(0f, 0f, 60.0f);
        downRot = Quaternion.Euler(0f, 0f, -60.0f);

        forwardVec = new Vector3(1.0f, 0f, 0f);
        upVec = new Vector3(0f, 1.0f, 0f);
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.D))
        {
            rb2D.AddForce(forwardVec * moveSpeed); 
        }
        //アクセル
        
        if (Input.GetKey(KeyCode.A))
        {
            rb2D.AddForce(-forwardVec * moveSpeed * 0.3f); 
        }
        //ブレーキ
        
        if (Input.GetKey(KeyCode.W))
        {
            rb2D.AddForce(upVec * moveSpeed); 
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, upRot, Time.deltaTime * handleSpeed);
        }
        //上向き
        
        if (Input.GetKey(KeyCode.S))
        {
            rb2D.AddForce(-upVec * moveSpeed); 
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, downRot, Time.deltaTime * handleSpeed);
        }
        //下向き
        
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, forwardRot, Time.deltaTime * handleSpeed);
        }
    }
}