using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Obstacle" || other.tag == "Item" && other.gameObject.transform.parent != transform.parent){
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
