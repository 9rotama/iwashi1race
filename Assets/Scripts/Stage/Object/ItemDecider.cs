using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// レーサーが使うアイテムを決めるクラス
/// </summary>
public class ItemDecider : MonoBehaviour
{
    // [SerializeField] private GameObject randomItemUI;

    /// <summary>
    /// レーサーのアイテムを決める関数
    /// </summary>
    void DecideItem(Racer racer)
    {
        //!他のクラスアイテムオーブかなに移行するかどうか、上の変数も
        // if(transform.parent.tag == "Player"){
        //     randomItemUI.SetActive(true);
        //     randomItemUI.GetComponent<ItemRandomDisplay>().determinItem = (int)determinItem; 
        // }

        // 列挙型のItemsの項目数の大きさ-1で初期化する。Items.Nothingがあるため。
        int[] ItemProbabilities = new int[System.Enum.GetNames(typeof(Items)).Length-1];
        
        // 順位によってどのItemが使えるかの確率が変わる
        switch(racer.GetRank()){
            case 1:
                ItemProbabilities[(int)Items.Wind]    = 0;
                ItemProbabilities[(int)Items.Dark]    = 0;
                ItemProbabilities[(int)Items.Thunder] = 0;
                ItemProbabilities[(int)Items.Fire]    = 2;
                ItemProbabilities[(int)Items.Bubble]  = 1;
                ItemProbabilities[(int)Items.Orb]     = 6;
                ItemProbabilities[(int)Items.Freeze]  = 2;
                break;
            case 2:
                ItemProbabilities[(int)Items.Wind]    = 1;
                ItemProbabilities[(int)Items.Dark]    = 0;
                ItemProbabilities[(int)Items.Thunder] = 0;
                ItemProbabilities[(int)Items.Fire]    = 2;
                ItemProbabilities[(int)Items.Bubble]  = 2;
                ItemProbabilities[(int)Items.Orb]     = 5;
                ItemProbabilities[(int)Items.Freeze]  = 2;
                break;
            case 3:
                ItemProbabilities[(int)Items.Wind]    = 1;
                ItemProbabilities[(int)Items.Dark]    = 0;
                ItemProbabilities[(int)Items.Thunder] = 0;
                ItemProbabilities[(int)Items.Fire]    = 3;
                ItemProbabilities[(int)Items.Bubble]  = 2;
                ItemProbabilities[(int)Items.Orb]     = 3;
                ItemProbabilities[(int)Items.Freeze]  = 3;
                break;
            case 4:
                ItemProbabilities[(int)Items.Wind]    = 2;
                ItemProbabilities[(int)Items.Dark]    = 1;
                ItemProbabilities[(int)Items.Thunder] = 1;
                ItemProbabilities[(int)Items.Fire]    = 3;
                ItemProbabilities[(int)Items.Bubble]  = 2;
                ItemProbabilities[(int)Items.Orb]     = 2;
                ItemProbabilities[(int)Items.Freeze]  = 3;
                break;
            case 5:
                ItemProbabilities[(int)Items.Wind]    = 2;
                ItemProbabilities[(int)Items.Dark]    = 2;
                ItemProbabilities[(int)Items.Thunder] = 1;
                ItemProbabilities[(int)Items.Fire]    = 2;
                ItemProbabilities[(int)Items.Bubble]  = 2;
                ItemProbabilities[(int)Items.Orb]     = 1;
                ItemProbabilities[(int)Items.Freeze]  = 3;
                break;
            case 6:
                ItemProbabilities[(int)Items.Wind]    = 3;
                ItemProbabilities[(int)Items.Dark]    = 2;
                ItemProbabilities[(int)Items.Thunder] = 2;
                ItemProbabilities[(int)Items.Fire]    = 2;
                ItemProbabilities[(int)Items.Bubble]  = 2;
                ItemProbabilities[(int)Items.Orb]     = 1;
                ItemProbabilities[(int)Items.Freeze]  = 3;
                break;
            case 7:
                ItemProbabilities[(int)Items.Wind]    = 5;
                ItemProbabilities[(int)Items.Dark]    = 2;
                ItemProbabilities[(int)Items.Thunder] = 2;
                ItemProbabilities[(int)Items.Fire]    = 2;
                ItemProbabilities[(int)Items.Bubble]  = 1;
                ItemProbabilities[(int)Items.Orb]     = 0;
                ItemProbabilities[(int)Items.Freeze]  = 3;
                break;    
            default:
                ItemProbabilities[(int)Items.Wind]    = 4;
                ItemProbabilities[(int)Items.Dark]    = 2;
                ItemProbabilities[(int)Items.Thunder] = 3;
                ItemProbabilities[(int)Items.Fire]    = 2;
                ItemProbabilities[(int)Items.Bubble]  = 0;
                ItemProbabilities[(int)Items.Orb]     = 0;
                ItemProbabilities[(int)Items.Freeze]  = 2;
                break;                                                                                           
        }


        // 0から配列の確率の合計値までの範囲でランダムな数値を生成する
        int randNumber = Random.Range(0,ItemProbabilities.Sum());

        // アイテムを選定する。Itemsの項目数の大きさ-1でfor文を回す
        for(int i=0, probability=0; i<ItemProbabilities.Length-1; i++){

            probability += ItemProbabilities[i];
            
            if(randNumber < probability){
                racer.havingItem =  (Items)i;
                return;
            }
        }
        racer.havingItem = 0;

    }
}
