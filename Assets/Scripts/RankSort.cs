using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class RankSort : MonoBehaviour
{

    struct Players{
        public GameObject obj;
        public int rank;
    };

    [SerializeField] Players[] targets;
    [SerializeField] GameObject[] tmp;

    // Start is called before the first frame update
    void Start()
    {
        // GameObject[] tmp = GameObject.FindGameObjectsWithTag("Enemy");
        // Array.Resize(ref targets, targets.Length + 1);
        // tmp[targets.Length - 1] = GameObject.FindGameObjectWithTag("Player");
        targets = new Players[tmp.Length];
        for(int i=0; i<targets.Length; i++){
            targets[i].obj = tmp[i];
        }
        Debug.Log("aaaaaaaaaaaaaaaaaaaa");
        InsertionSort();
    }

    // Update is called once per frame
    void Update()
    {
        InsertionSort();
        // for(int i=0; i<targets.Length; i++){
        //     Debug.Log(targets[i].rank + " " + targets[i].obj);
        // }
    }

    void InsertionSort()
    {
        Players v;
        int j;

        for(int i=1; i<targets.Length; i++){
            v = targets[i];
            j = i-1;
            while(j>=0 && targets[j].obj.transform.position.x < v.obj.transform.position.x){
                targets[j+1] = targets[j];
                j--;
            }
            targets[j+1] = v;
        }

        for(int i=0; i<targets.Length; i++){
            targets[i].rank = i+1;
        }
    }

    public int GetRank(GameObject obj)
    {
        Debug.Log(obj);
        for(int i=0; i<targets.Length; i++){
            //Debug.Log(targets[i].obj.gameObject);
            if(obj.gameObject == targets[i].obj.gameObject){
                return targets[i].rank;
            }
        }
        Debug.Log(obj.gameObject);
        return 0;
    }
}

