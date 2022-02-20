using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DarkScript : MonoBehaviour
{
    float time;
    [SerializeField] GameObject darkImage;
    GameObject[] targets;
    GameObject parentObj;
    // Start is called before the first frame update
    void Start()
    {
        parentObj = transform.parent.gameObject;

        targets = GameObject.FindGameObjectsWithTag("Enemy");
        Array.Resize(ref targets, targets.Length + 1);
        targets[targets.Length - 1] = GameObject.FindGameObjectWithTag("Player");

        
        for(int i=0; i<targets.Length; i++){
            if(targets[i] != parentObj){
                if(targets[i].tag == "Player"){
                    transform.GetChild(0).gameObject.SetActive(true);
                }
            }
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        for(int i=0; i<targets.Length; i++){
            if(targets[i] != parentObj){
                Rigidbody2D rb = targets[i].GetComponent<Rigidbody2D>();
                rb.AddForce(new Vector2(UnityEngine.Random.Range(-100,100) , UnityEngine.Random.Range(-100,100)));
            }
        }
        
    }
}
