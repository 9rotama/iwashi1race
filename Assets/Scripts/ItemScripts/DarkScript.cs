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
    static GameObject rankObj;

    float[] sqrtRank;

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

        if(rankObj == null) {rankObj = GameObject.Find("Rank");}
        sqrtRank = new float[targets.Length];
        for(int i=0; i<targets.Length; i++){
            sqrtRank[i] = rankObj.GetComponent<RankSort>().GetRank(targets[i]);
            sqrtRank[i] = Mathf.Sqrt(sqrtRank[i]);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        const float destroyTime = 5.0f;
        time += Time.deltaTime;

        for(int i=0; i<targets.Length; i++){
            if(targets[i] != parentObj){
                if(time < destroyTime/sqrtRank[i]){
                    Rigidbody2D rb = targets[i].GetComponent<Rigidbody2D>();
                    rb.AddForce(new Vector2(UnityEngine.Random.Range(-400,100) , 
                                UnityEngine.Random.Range(-400,400)));
                }
            }
        }

        if(time > destroyTime){
            Destroy(gameObject);
        }


        
    }
}
