using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーと向かい風の接触した際の処理を担当するクラス
/// 向かい風オブジェクトに直接アタッチされる
/// </summary>
public class HeadwindControl : CollisionStayObject
{
    [SerializeField] private const float Strength = -3f;
    
    /// <summary>
    /// CPUが風内にいるときCPU側の風の力を加える関数を実行する
    /// </summary>
    /// <param name="cpuPlayer">cpuプレイヤーのGameObject</param>
    public override void OnTriggerStayCPUPlayer(GameObject cpuPlayer)
    {
        var playerControl = cpuPlayer.GetComponent<PlayerControl>();
        playerControl.WindStay(Strength);
    }
    
    /// <summary>
    ///  CPUが風内にいるときCPU側の風の力を加える関数を実行する
    /// </summary>
    /// <param name="player">プレイヤーのGameObject</param>
    public override void OnTriggerStayPlayer(GameObject player)
    {
        var cpuPlayerControl = player.GetComponent<CPUplayerControl>();
        cpuPlayerControl.WindEnter(Strength);
    }
}
