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

    public bool isDefence;

    float time;


    void Start()
    {
        isDefence = false;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(Input.GetMouseButtonDown(0) && transform.parent.tag == "Player"){
            Items decidedItem = DecideItem(); 
            CreatePrefab(decidedItem);
        }

        if(transform.parent.tag == "Enemy" && time > 5.0f){
            time = 0;
            Items decidedItem = DecideItem(); 
            CreatePrefab(decidedItem);
        }
    }

    Items DecideItem()
    {
        int len =  System.Enum.GetNames(typeof(Items)).Length;
        Items value = (Items)(Random.Range(0,len));

        if(value == Items.Thunder) value = Items.Bubble;

        return value;
    }

    void CreatePrefab(Items num){
        GameObject obj = (GameObject)Instantiate(itemObjs[(int)num], transform.parent.position, Quaternion.identity);
        obj.transform.parent = transform.parent;
    }


}
