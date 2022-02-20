using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Items {
    Wind,
    Dark,
    Thunder,
    Fire,
    Bubble,
    Orb,
};

public class ItemControlScript : MonoBehaviour
{
    [SerializeField] GameObject[] itemObjs;
    [SerializeField] GameObject rankObj;
    [SerializeField] GameObject itemUI;
    GameObject UI_Item;

    public bool isDefence;

    float time;

    float randNum;

    int determinItem = -1;

    public int GetdeterminItem()
    {
        return determinItem;
    }



    void Start()
    {
        isDefence = false;
        randNum = Random.Range(5f,10f);
        rankObj = GameObject.Find("Rank");
    }

    public void DeterminItem()
    {
        determinItem = (int)DecideItem();
        GameObject UI = GameObject.Find("UI");
        GameObject outside = UI.transform.Find("UI_Item_Oustside").gameObject;
        UI_Item = (GameObject)Instantiate(itemUI, outside.transform.position, Quaternion.identity);
        UI_Item.transform.parent = UI.transform;
        UI_Item.GetComponent<UI_ItemControl>().determinItem = (int)determinItem;      
    }

    void Update()
    {
        time += Time.deltaTime;
        if(determinItem != -1){
            if(Input.GetMouseButtonDown(0) && transform.parent.tag == "Player"){
                CreatePrefab((Items)determinItem);
                determinItem = -1;
                Destroy(UI_Item);
            }
            if(transform.parent.tag == "Enemy" && time > randNum){
                randNum = Random.Range(5f,10f);
                time = 0;
                CreatePrefab((Items)determinItem);
                determinItem = -1;
            }
        }

        // time += Time.deltaTime;
        // if(Input.GetMouseButtonDown(0) && transform.parent.tag == "Player"){
        //     Items decidedItem = DecideItem(); 
        //     CreatePrefab(decidedItem);
        // }

        // if(transform.parent.tag == "Enemy" && time > randNum){
        //     randNum = Random.Range(5f,10f);
        //     time = 0;
        //     Items decidedItem = DecideItem(); 
        //     CreatePrefab(decidedItem);
        // }
    }

    Items DecideItem()
    {
        int[] probItem = new int[System.Enum.GetNames(typeof(Items)).Length];
        Debug.Log(rankObj.GetComponent<RankSort>().GetRank(transform.parent.gameObject));
        switch(rankObj.GetComponent<RankSort>().GetRank(transform.parent.gameObject)){
            case 1:
                probItem[(int)Items.Wind]    = 1;
                probItem[(int)Items.Dark]    = 0;
                probItem[(int)Items.Thunder] = 0;
                probItem[(int)Items.Fire]    = 2;
                probItem[(int)Items.Bubble]  = 2;
                probItem[(int)Items.Orb]     = 6;
                break;
            case 2:
                probItem[(int)Items.Wind]    = 1;
                probItem[(int)Items.Dark]    = 0;
                probItem[(int)Items.Thunder] = 0;
                probItem[(int)Items.Fire]    = 2;
                probItem[(int)Items.Bubble]  = 2;
                probItem[(int)Items.Orb]     = 5;
                break;
            case 3:
                probItem[(int)Items.Wind]    = 1;
                probItem[(int)Items.Dark]    = 0;
                probItem[(int)Items.Thunder] = 0;
                probItem[(int)Items.Fire]    = 3;
                probItem[(int)Items.Bubble]  = 2;
                probItem[(int)Items.Orb]     = 4;
                break;
            case 4:
                probItem[(int)Items.Wind]    = 2;
                probItem[(int)Items.Dark]    = 0;
                probItem[(int)Items.Thunder] = 0;
                probItem[(int)Items.Fire]    = 3;
                probItem[(int)Items.Bubble]  = 2;
                probItem[(int)Items.Orb]     = 3;
                break;
            case 5:
                probItem[(int)Items.Wind]    = 2;
                probItem[(int)Items.Dark]    = 2;
                probItem[(int)Items.Thunder] = 1;
                probItem[(int)Items.Fire]    = 2;
                probItem[(int)Items.Bubble]  = 2;
                probItem[(int)Items.Orb]     = 2;
                break;
            case 6:
                probItem[(int)Items.Wind]    = 3;
                probItem[(int)Items.Dark]    = 2;
                probItem[(int)Items.Thunder] = 1;
                probItem[(int)Items.Fire]    = 2;
                probItem[(int)Items.Bubble]  = 2;
                probItem[(int)Items.Orb]     = 1;
                break;
            case 7:
                probItem[(int)Items.Wind]    = 5;
                probItem[(int)Items.Dark]    = 1;
                probItem[(int)Items.Thunder] = 1;
                probItem[(int)Items.Fire]    = 2;
                probItem[(int)Items.Bubble]  = 1;
                probItem[(int)Items.Orb]     = 0;
                break;    
            default:
                probItem[(int)Items.Wind]    = 5;
                probItem[(int)Items.Dark]    = 1;
                probItem[(int)Items.Thunder] = 1;
                probItem[(int)Items.Fire]    = 2;
                probItem[(int)Items.Bubble]  = 1;
                probItem[(int)Items.Orb]     = 0;
                break;                                                                                           
        }

        int sum = 0;
        for(int i=0; i<probItem.Length; i++){ sum += probItem[i];}

        int randValue = Random.Range(0,sum);
        int tmp=0;

        return Items.Thunder;

        for(int i=0; i<probItem.Length; i++){
            tmp += probItem[i];
            if(randValue < tmp){
                return (Items)i;
            }
        }
        return 0;

    }

    void CreatePrefab(Items num){
        GameObject obj = (GameObject)Instantiate(itemObjs[(int)num], transform.parent.position, Quaternion.identity);
        if(num == Items.Bubble) obj.transform.parent = transform;
        else obj.transform.parent = transform.parent;
    }





}
