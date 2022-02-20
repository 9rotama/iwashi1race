using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ThunderScript : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject thunderSprite;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
        Array.Resize(ref targets, targets.Length + 1);
        targets[targets.Length - 1] = GameObject.FindGameObjectWithTag("Player");

        for(int i=0; i<targets.Length; i++){
            if(targets[i] != transform.parent.gameObject){
                GameObject obj = (GameObject)Instantiate(
                    thunderSprite, 
                    targets[i].transform.position + Vector3.up * 25,  
                    Quaternion.identity
                );
                //obj.transform.parent = transform.parent;
                obj.transform.parent = targets[i].transform;
            }
        }

        Destroy(this.gameObject);

    }
}
