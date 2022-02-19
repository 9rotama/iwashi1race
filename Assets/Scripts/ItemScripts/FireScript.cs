using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 shotForward;
    GameObject otherObj;
    public GameObject creatorObj;
    bool isCollision;
    float time;
    const float sp = 400.0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        shotForward = Vector3.Scale((mouseWorldPos - transform.parent.position), new Vector3(1, 1, 0)).normalized;
        creatorObj = transform.parent.gameObject;
        transform.parent = null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = shotForward * sp;
        if(isCollision){
            time += Time.deltaTime;
            if(time < 1.0f){
                Rigidbody2D rb = otherObj.GetComponent<Rigidbody2D>();
                rb.AddForce(Vector3.right * ((0 - rb.velocity.x) * 30), ForceMode2D.Force);
                rb.AddForce(Vector3.up * ((0 - rb.velocity.y) * 30), ForceMode2D.Force);
            }
            else{
                Destroy(this.gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if((other.tag == "Player" || other.tag == "Enemy") && other.gameObject != creatorObj){
            Debug.Log(other.gameObject);
            isCollision = true;
            otherObj = other.gameObject;
            transform.position = new Vector3(-1000, -1000, 0);
        }
    }
}
