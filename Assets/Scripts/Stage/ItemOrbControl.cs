using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOrbControl : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy"))
        {
            GameObject itemCon = other.transform.Find("ItemController").gameObject;
            if(itemCon.GetComponent<ItemControlScript>().GetdeterminItem() == -1){
                itemCon.GetComponent<ItemControlScript>().DeterminItem();
            }
            Destroy(this.gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
