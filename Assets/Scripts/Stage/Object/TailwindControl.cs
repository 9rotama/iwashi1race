using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーと追い風の接触した際の処理を担当するクラス
/// </summary>
public class TailwindControl : CollisionStayObject
{
    [SerializeField] private float strength = 20f;
    
    /// <summary>
    /// CPUが風内にいるときCPU側の風の力を加える関数を実行する
    /// </summary>
    /// <param name="cpuPlayer">cpuプレイヤーのGameObject</param>
    public override void OnTriggerStayCPUPlayer(GameObject cpuPlayer)
    {
        var playerControl = cpuPlayer.GetComponent<PlayerControl>();
        playerControl.WindStay(strength);
    }
    
    /// <summary>
    ///  CPUが風内にいるときCPU側の風の力を加える関数を実行する
    /// </summary>
    /// <param name="player">プレイヤーのGameObject</param>
    public override void OnTriggerStayPlayer(GameObject player)
    {
        var cpuPlayerControl = player.GetComponent<CPUplayerControl>();
        cpuPlayerControl.WindStay(strength);
    }
}
