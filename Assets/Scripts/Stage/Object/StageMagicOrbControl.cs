using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// マジックオーブの回収処理などを担当するクラス
/// マジックオーブのPrefab及びインスタンスにアタッチされる
/// </summary>
public class StageMagicOrbControl : MonoBehaviour, IRacerCollisionEnterer
{
    [SerializeField] private int increaseNum;
    private OrbSpawner _parentOrbSpawner;

    /// <summary>
    /// マジックオーブがレーサーと衝突したときレーサー側のマジックオーブゲージを増やす関数を実行
    /// 自身は削除される
    /// </summary>
    /// <param name="cpuPlayer">レーサーのクラス</param>
    public void OnTriggerEnterRacer(Racer racer)
    {
        racer.MagicOrbEnter(increaseNum);
        _parentOrbSpawner.OrbDestroyed();
        Destroy(this.gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _parentOrbSpawner = transform.parent.GetComponent<OrbSpawner>();
    }
}
