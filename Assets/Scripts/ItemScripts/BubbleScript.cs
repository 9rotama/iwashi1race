using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    GameObject itemControl;
    ItemControlScript itemScript;

    void Start()
    {
        itemControl = transform.parent.gameObject;
        itemScript = itemControl.GetComponent<ItemControlScript>();
        itemScript.isDefence = true;
        int bubblesCnt = transform.parent.childCount;
        if(bubblesCnt >= 2) Destroy(gameObject);
    }

    void Update()
    {
        itemScript.isDefence = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name.Contains("Fire")){
            if(other.GetComponent<FireScript>().creatorObj != transform.parent.parent.gameObject){
                Destroy(this.gameObject);
                Destroy(other.gameObject);
                itemScript.isDefence = false;
            }
        }
        else if((other.tag == "Obstacle" || other.tag == "Item")
            && other.gameObject.transform.parent != transform.parent.parent 
            && other.gameObject.name != this.gameObject.name){
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            itemScript.isDefence = false;
        }

    }
}
