using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBulletScript : MonoBehaviour
{

    GameObject itemControl;
    GameObject creatorObj;
    ItemControlScript itemScript;

    bool onceDefence = false;

    bool isShocked = true;

    float time;



    void Start()
    {
        itemControl = GameObject.Find("ItemController");
        itemScript = itemControl.GetComponent<ItemControlScript>();
        creatorObj = transform.parent.gameObject;
    }

    void FixedUpdate()
    {
        if(!isShocked){
            time += Time.deltaTime;
            if(time < 2f){
                ShockedPlayer();
            }
            else{
                Destroy(transform.parent.gameObject);
            }

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(itemScript.isDefence) onceDefence = true;
        if(other.tag == "Player" || other.tag == "Enemy"){
            if(onceDefence){
                Debug.Log("まもれた");
                Destroy(transform.parent.gameObject);
            }
            else{
                //Destroy(this.gameObject);
                Debug.Log("まもれなかった");
                isShocked = false;
                time = 0;
                transform.parent.GetComponent<ThunderSpriteScript>().CreateShockPlayer();
            }
        }

    }


    void ShockedPlayer()
    {
        Rigidbody2D rb = transform.parent.GetComponent<ThunderSpriteScript>().targetObj.GetComponent<Rigidbody2D>();
        const float targetVelocity = 0;
        const float power =  50;
        //Rigidbody2D rb = transform.parent.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector3.right * ((targetVelocity - rb.velocity.x) * power), ForceMode2D.Force);
        rb.AddForce(Vector3.up * ((targetVelocity - rb.velocity.y) * power), ForceMode2D.Force);
    }
}
