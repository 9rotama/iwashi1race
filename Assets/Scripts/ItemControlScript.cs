using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Items {
    Wind,
    Dark,
    Thunder,
    Fire,
    Bubble,
};

public class ItemControlScript : MonoBehaviour
{
    [SerializeField] GameObject[] itemObjs;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Items decidedItem = DecideItem(); 
            CreatePrefab(decidedItem);
        }
        
    }

    Items DecideItem()
    {
        int len =  System.Enum.GetNames(typeof(Items)).Length;
        Items value = (Items)(Random.Range(0,len));

        return value;
    }

    void CreatePrefab(Items num){
        GameObject obj = (GameObject)Instantiate(itemObjs[(int)num], transform.parent.position, Quaternion.identity);
        obj.transform.parent = transform.parent;
    }
}
