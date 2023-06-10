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
    public void DecideItem(Racer racer)
    {

        if(racer.havingItem != Items.Nothing) {
            return;
        }

        //!他のクラスアイテムオーブかなに移行するかどうか、上の変数も
        // if(transform.parent.tag == "Player"){
        //     randomItemUI.SetActive(true);
        //     randomItemUI.GetComponent<ItemRandomDisplay>().determinItem = (int)determinItem; 
        // }

        // 列挙型のItemsの項目数の大きさ-1で初期化する。Items.Nothingがあるため。
        int[] itemProbabilities = new int[System.Enum.GetNames(typeof(Items)).Length-1];
        
        // 順位によってどのItemが使えるかの確率が変わる
        switch(RankManager.Instance.GetRank(racer.id)){
            case 1:
                itemProbabilities[(int)Items.Wind]    = 0;
                itemProbabilities[(int)Items.Dark]    = 0;
                itemProbabilities[(int)Items.Thunder] = 0;
                itemProbabilities[(int)Items.Fire]    = 2;
                itemProbabilities[(int)Items.Bubble]  = 1;
                itemProbabilities[(int)Items.Orb]     = 6;
                itemProbabilities[(int)Items.Freeze]  = 2;
                break;
            case 2:
                itemProbabilities[(int)Items.Wind]    = 1;
                itemProbabilities[(int)Items.Dark]    = 0;
                itemProbabilities[(int)Items.Thunder] = 0;
                itemProbabilities[(int)Items.Fire]    = 2;
                itemProbabilities[(int)Items.Bubble]  = 2;
                itemProbabilities[(int)Items.Orb]     = 5;
                itemProbabilities[(int)Items.Freeze]  = 2;
                break;
            case 3:
                itemProbabilities[(int)Items.Wind]    = 1;
                itemProbabilities[(int)Items.Dark]    = 0;
                itemProbabilities[(int)Items.Thunder] = 0;
                itemProbabilities[(int)Items.Fire]    = 3;
                itemProbabilities[(int)Items.Bubble]  = 2;
                itemProbabilities[(int)Items.Orb]     = 3;
                itemProbabilities[(int)Items.Freeze]  = 3;
                break;
            case 4:
                itemProbabilities[(int)Items.Wind]    = 2;
                itemProbabilities[(int)Items.Dark]    = 1;
                itemProbabilities[(int)Items.Thunder] = 1;
                itemProbabilities[(int)Items.Fire]    = 3;
                itemProbabilities[(int)Items.Bubble]  = 2;
                itemProbabilities[(int)Items.Orb]     = 2;
                itemProbabilities[(int)Items.Freeze]  = 3;
                break;
            case 5:
                itemProbabilities[(int)Items.Wind]    = 2;
                itemProbabilities[(int)Items.Dark]    = 2;
                itemProbabilities[(int)Items.Thunder] = 1;
                itemProbabilities[(int)Items.Fire]    = 2;
                itemProbabilities[(int)Items.Bubble]  = 2;
                itemProbabilities[(int)Items.Orb]     = 1;
                itemProbabilities[(int)Items.Freeze]  = 3;
                break;
            case 6:
                itemProbabilities[(int)Items.Wind]    = 3;
                itemProbabilities[(int)Items.Dark]    = 2;
                itemProbabilities[(int)Items.Thunder] = 2;
                itemProbabilities[(int)Items.Fire]    = 2;
                itemProbabilities[(int)Items.Bubble]  = 2;
                itemProbabilities[(int)Items.Orb]     = 1;
                itemProbabilities[(int)Items.Freeze]  = 3;
                break;
            case 7:
                itemProbabilities[(int)Items.Wind]    = 5;
                itemProbabilities[(int)Items.Dark]    = 2;
                itemProbabilities[(int)Items.Thunder] = 2;
                itemProbabilities[(int)Items.Fire]    = 2;
                itemProbabilities[(int)Items.Bubble]  = 1;
                itemProbabilities[(int)Items.Orb]     = 0;
                itemProbabilities[(int)Items.Freeze]  = 3;
                break;    
            default:
                itemProbabilities[(int)Items.Wind]    = 4;
                itemProbabilities[(int)Items.Dark]    = 2;
                itemProbabilities[(int)Items.Thunder] = 3;
                itemProbabilities[(int)Items.Fire]    = 2;
                itemProbabilities[(int)Items.Bubble]  = 0;
                itemProbabilities[(int)Items.Orb]     = 0;
                itemProbabilities[(int)Items.Freeze]  = 2;
                break;                                                                                           
        }


        // 0から配列の確率の合計値までの範囲でランダムな数値を生成する
        int randNumber = Random.Range(0,itemProbabilities.Sum());

        // アイテムを選定する。Nothingを除いたItemsの項目数でfor文を回す
        for(int i=0, probability=0; i<itemProbabilities.Length; i++){

            probability += itemProbabilities[i];
            
            if(randNumber < probability){
                racer.havingItem =  (Items)i;
                return;
            }
        }
        racer.havingItem = 0;

    }
}
