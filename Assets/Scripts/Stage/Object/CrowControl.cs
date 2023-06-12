using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using KanKikuchi.AudioManager;
/// <summary>
/// スポーンしたカラスの挙動を担当するクラス
/// カラスのPrefab及びインスタンスにアタッチされる
/// </summary>
public class CrowControl : MonoBehaviour, IRacerCollisionEnterer, IPhysicalDamageable
{
    [SerializeField] private float destroyPosX;
    [SerializeField] public float moveSpeed = 100f;
    [SerializeField] private float playerStopDur = 1.0f;
    [SerializeField] private int lostMagicOrbNum = 10;


    /// <summary>
    /// カラスがレーサーと衝突したときレーサー側を止まらせる処理を行う
    /// 自身は削除される
    /// </summary>
    /// <param name="racer">レーサーのクラス</param>
    public void OnTriggerEnterRacer(Racer racer)
    {
        if(!IPhysicalDamageable.IsPhysicalDamageable(racer)) {
            Destroy(this.gameObject);
            return;
        }
        
        racer.StopperEnter(playerStopDur, lostMagicOrbNum);
        SEManager.Instance.Play(SEPath.DAMAGE);

        Destroy(gameObject);
    }

    private void Update()
    {
        var transform1 = transform;
        var position = transform1.position;
        position = new Vector3(position.x - moveSpeed * Time.deltaTime, position.y, position.z);
        
        transform1.position = position;
        if (this.transform.position.x <= destroyPosX)
            Destroy(this.gameObject);
    }
}
