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
    
    private void Update() 
    {
        SortRank();
    }
    

    /// <summary>
    /// 配列レーサーをx座標が大きい順(降順)にソートする。
    /// ランク順に並び替えられる
    /// </summary>
    private void SortRank() 
    {  
        Array.Sort(racers, (a, b) => (b.transform.position.x).CompareTo(a.transform.position.x));
    }


    /// <summary>
    /// 引数のidに基づいて現在の順位を返す。
    /// 引数のidが存在しない番号だったとき0を返す
    /// </summary>
    /// <param name="id">個体識別番号</param>
    /// <returns>順位</returns>
    public int GetRank(int id)
    {
        return Array.FindIndex(racers, a => a.id == id ) + 1;
    }


    /// <summary>
    /// ランク順(1,2,...)に並び替えたRacerクラスの配列を返す
    /// </summary>
    /// <returns>ソートされたRacer配列</returns>
    public Racer[] GetSortedRacers() 
    {
        return racers;
    }

    /// <summary>
    /// １つ順位が上のRacerを返す。
    /// １つ順位が上のRacerが無いとき、最下位を返す
    /// </summary>
    /// <param name="id">個体識別番号</param>
    /// <returns>順位がひとつ上のRacerクラス</returns>
    public Racer GetOneRankHigherRacer(int id) 
    {
        int rank = GetRank(id);
        int oneRankHigher = rank > 1 ? rank-1 : racer.Length-1;

        return racers[oneRankHigher-1];
    }

    /// <summary>
    /// 引数のIDを持つRacerを除くランク順(1,2,...)に並び替えたRacerクラスの配列を返す
    /// </summary>
    /// <param name="id">個体識別番号</param>
    /// <returns>Racerクラスの配列</returns>
    public Racer[] GetSortedRacersExceptSelf(int id) 
    {
        return racers.Where(a => a.id != id).ToArray();
    }
    
}
