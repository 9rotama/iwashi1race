using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOrbControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy")))
        {
            var itemCon = other.transform.Find("ItemController").gameObject;
            if(itemCon.GetComponent<ItemControlScript>().GetdeterminItem() == -1){
                itemCon.GetComponent<ItemControlScript>().DeterminItem();
            }
            Destroy(this.gameObject);
        }

    }
}
