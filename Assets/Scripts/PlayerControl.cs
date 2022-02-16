using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 20.0f;
    [SerializeField] private float handleSpeed = 3.0f;
    private Rigidbody2D rb2D;
    private Quaternion forwardRot, upRot, downRot;
    
    void Start()
    {
        rb2D = this.GetComponent<Rigidbody2D>();
        forwardRot = Quaternion.Euler(0f, 0f, 0f);
        upRot = Quaternion.Euler(0f, 0f, 60.0f);
        downRot = Quaternion.Euler(0f, 0f, -60.0f);
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.D))
        {
            rb2D.AddForce(transform.right * moveSpeed); 
        }
        //アクセル
        
        if (Input.GetKey(KeyCode.A))
        {
            rb2D.AddForce(-transform.right * moveSpeed * 0.3f); 
        }
        //ブレーキ
        
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, upRot, Time.deltaTime * handleSpeed);
        }
        //上向き
        
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, downRot, Time.deltaTime * handleSpeed);
        }
        //下向き
        
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, forwardRot, Time.deltaTime * handleSpeed);
        }
    }
}