using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    GameObject itemControl;
    ItemControlScript itemScript;

    void Start()
    {
        itemControl = GameObject.Find("ItemController");
        itemScript = itemControl.GetComponent<ItemControlScript>();
        itemScript.isDefence = true;
    }

    void Update()
    {
        itemScript.isDefence = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.name.Contains("Fire")){
            if(other.GetComponent<FireScript>().creatorObj != transform.parent.gameObject){
                Destroy(this.gameObject);
                Destroy(other.gameObject);
                itemScript.isDefence = false;
            }
        }
        else if((other.tag == "Obstacle" || other.tag == "Item")
            && other.gameObject.transform.parent != transform.parent 
            && other.gameObject.name != this.gameObject.name){
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            itemScript.isDefence = false;
        }

    }
}
