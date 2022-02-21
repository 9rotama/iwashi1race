using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ThunderScript : MonoBehaviour
{
    [SerializeField] GameObject thunderSprite;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
        Array.Resize(ref targets, targets.Length + 1);
        targets[targets.Length - 1] = GameObject.FindGameObjectWithTag("Player");

        for(int i=0; i<targets.Length; i++){
            for(int j=targets.Length-1; j>i; j--){
                if(targets[j].transform.position.x > targets[j-1].transform.position.x){
                    GameObject tmp = targets[j];
                    targets[j] = targets[j-1];
                    targets[j-1] = tmp;
                }
            }
        }

        for(int i=0; i<targets.Length; i++){
            if(targets[i] != transform.parent.gameObject){
                GameObject obj = (GameObject)Instantiate(
                    thunderSprite, 
                    targets[i].transform.position + Vector3.up * 25,  
                    Quaternion.identity
                );
                obj.GetComponent<ThunderSpriteScript>().rank = i+1;
                obj.transform.parent = targets[i].transform;
            }
        }

        

        Destroy(this.gameObject);

    }
}
