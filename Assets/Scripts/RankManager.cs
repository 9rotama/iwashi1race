using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RankManager : MonoBehaviour
{

    
    /// <summary>
    /// Racerクラスをコンポーネントに持つGameObjetの配列。
    /// ランク順でソートされる
    /// </summary>
    [SerializeField] private GameObject[] _racers;

    // Start is called before the first frame update
    private void Start()
    {
        SortRank();
    }

    // Update is called once per frame
    private void Update()
    {
        SortRank();
    }

    /// <summary>
    /// 配列レーサーをx座標が大きい順(降順)にソートする。
    /// ランク順に並び替えられる
    /// </summary>
    private void SortRank() {
        Array.Sort(_racers,  (a, b) => (b.transform.position.x).CompareTo(a.transform.position.x));
    }


    /// <summary>
    /// 引数のidに基づいて現在の順位を返す。
    /// 引数のidが存在しない番号だったとき0を返す
    /// </summary>
    /// <param name="id">個体識別番号</param>
    /// <returns>順位</returns>
    public int GetRank(int id) {
        
        for(int i=0; i<_racers.Length; i++){
            if(id == _racers[i].GetComponent<Racer>().id) {
                return i+1;
            }
            else {
                // 何もしない
            }
        }

        //該当するものがないとき0を返す
        return 0;
    }


    /// <summary>
    /// ランク順(1,2,...)に並び替えたRacerクラスを持つGameObjectの配列を返す
    /// </summary>
    /// <returns>Racerクラスをコンポーネントに持つGameObjetの配列</returns>
    public GameObject[] GetSortedRacers() {
        return _racers;
    }

    /// <summary>
    /// １つ順位が上のRacerクラスを持つGameObjectを返す。
    /// １つ順位が上のGameObjectが無いとき、引数のidが指すGameObjectの順位を返す
    /// </summary>
    /// <param name="id">個体識別番号</param>
    /// <returns>Racerクラスをコンポーネントに持つGameObject</returns>
    public GameObject GetOneRankHigherRacer(int id) {
        int rank = GetRank(id);
        int oneRankHigher = rank > 1 ? rank-1 : rank;

        return _racers[rank-1];
    }

    
}
