using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

/// <summary>
/// レース中の順位を計測、管理するシングルトンのクラス
/// </summary>
public class RankManager : SingletonMonoBehaviour<RankManager>
{

    [SerializeField] private Racer[] racers;

    /// <summary>
    /// 配列レーサーをx座標が大きい順(降順)にソートする。
    /// ランク順に並び替えられる
    /// </summary>
    private void SortRank() {  
        Array.Sort(racers, (a, b) => (b.transform.position.x).CompareTo(a.transform.position.x));
    }


    /// <summary>
    /// 引数のidに基づいて現在の順位を返す。
    /// 引数のidが存在しない番号だったとき0を返す
    /// </summary>
    /// <param name="id">個体識別番号</param>
    /// <returns>順位</returns>
    public int GetRank(int id) {
        SortRank();

        return Array.FindIndex(racers, a => a.id == id ) + 1;
    }


    /// <summary>
    /// ランク順(1,2,...)に並び替えたRacerクラスを持つGameObjectの配列を返す
    /// </summary>
    /// <returns>Racerクラスをコンポーネントに持つGameObjetの配列</returns>
    public GameObject[] GetSortedRacers() {
        SortRank();

        return racers.Select(a => a.gameObject).ToArray();
    }

    /// <summary>
    /// １つ順位が上のRacerクラスを持つGameObjectを返す。
    /// １つ順位が上のGameObjectが無いとき、引数のidが指すGameObjectの順位を返す
    /// </summary>
    /// <param name="id">個体識別番号</param>
    /// <returns>Racerクラスをコンポーネントに持つGameObject</returns>
    public GameObject GetOneRankHigherRacer(int id) {
        SortRank();

        int rank = GetRank(id);
        int oneRankHigher = rank > 1 ? rank-1 : rank;

        return racers[rank-1].gameObject;
    }

    /// <summary>
    /// 引数のIDを持つRacerを除くランク順(1,2,...)に並び替えたRacerクラスを持つGameObjectの配列を返す
    /// </summary>
    /// <returns>Racerクラスをコンポーネントに持つGameObjetの配列</returns>
    public GameObject[] GetSortedRacersExceptSelf(int id) {
        SortRank();

        return racers.Where(a => a.id != id).Select(a => a.gameObject).ToArray();
    }



    
}
