using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBulletScript : MonoBehaviour
{

    [SerializeField] GameObject bubbleObj;

    bool isBubble = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        //子オブジェクトの数によって、重くなる可能性

        for(int i=0; i<other.transform.childCount; i++){
            if(other.transform.GetChild(i).gameObject.name == bubbleObj.name){
                isBubble = true;
                break;
            }
        }

        if(!isBubble){
            Debug.Log("おけまる");
            Destroy(this.gameObject);
        }
        else{
            Destroy(this.gameObject);
        }


    }
}
