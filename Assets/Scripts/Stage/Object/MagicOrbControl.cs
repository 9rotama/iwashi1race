using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// マジックオーブの回収処理などを担当するクラス
/// マジックオーブのPrefab及びインスタンスにアタッチされる
/// </summary>
public class MagicOrbControl : CollisionEnterObject
{
    private OrbSpawner _parentOrbSpawner;

    /// <summary>
    /// マジックオーブがCPUと衝突したときCPU側のマジックオーブゲージを増やす関数を実行
    /// 自身は削除される
    /// </summary>
    /// <param name="cpuPlayer">cpuプレイヤーのGameObject</param>
    public override void OnTriggerEnterCPUPlayer(GameObject cpuPlayer)
    {
        var cpuPlayerControl = cpuPlayer.GetComponent<CPUplayerControl>();
        cpuPlayerControl.MagicOrbEnter(5);
        _parentOrbSpawner.OrbDestroyed();
        Destroy(this.gameObject);
    }
    
    /// <summary>
    /// マジックオーブがCPUと衝突したときプレイヤー側のマジックオーブゲージを増やす関数を実行
    /// 自身は削除される
    /// </summary>
    /// <param name="player">プレイヤーのGameObject</param>
    public override void OnTriggerEnterPlayer(GameObject player)
    {
        var playerControl = player.GetComponent<PlayerControl>();
        playerControl.MagicOrbEnter(5);
        _parentOrbSpawner.OrbDestroyed();
        Destroy(this.gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _parentOrbSpawner = transform.parent.GetComponent<OrbSpawner>();
    }
}
