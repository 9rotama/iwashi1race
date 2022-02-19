using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBulletScript : MonoBehaviour
{

    GameObject itemControl;
    GameObject targetObj;
    ItemControlScript itemScript;
    public GameObject spreiteObj;
    bool onceDefence = false;

    bool isShocked = true;

    float time;
    
    AudioClip audioClip;

    AudioSource audioSource;


    void Start()
    {

        targetObj = transform.parent.gameObject;
        itemControl = targetObj.transform.Find("ItemController").gameObject;
        itemScript = itemControl.GetComponent<ItemControlScript>();
        Debug.Log(targetObj);
        transform.parent = spreiteObj.transform;

        audioSource = GetComponent<AudioSource>();
        audioClip = audioSource.clip;
    }

    void FixedUpdate()
    {
        Debug.Log(time);
        time += Time.deltaTime;
        if(!isShocked){
            if(time < 3f){
                ShockedPlayer();
            }
            else{
                Destroy(transform.parent.gameObject);
            }

        }
        if(time > 2.0f) Destroy(transform.parent.gameObject);

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
                if(other.tag == "Player") audioSource.PlayOneShot(audioClip);
                isShocked = false;
                time = 0;
                spreiteObj.GetComponent<ThunderSpriteScript>().CreateShockPlayer();
            }
        }

    }


    void ShockedPlayer()
    {
        Rigidbody2D rb = targetObj.GetComponent<Rigidbody2D>();
        const float targetVelocity = 0;
        const float power =  50;
        //Rigidbody2D rb = transform.parent.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector3.right * ((targetVelocity - rb.velocity.x) * power), ForceMode2D.Force);
        rb.AddForce(Vector3.up * ((targetVelocity - rb.velocity.y) * power), ForceMode2D.Force);
    }
}
