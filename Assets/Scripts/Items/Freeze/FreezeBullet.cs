using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

/// <summary>
/// 等速に進むフリーズのクラス
/// レーサーに当たると氷状態にする
/// </summary>
public class FreezeBullet: FirstItemCreated, IRacerCollisionEnterer, IPhysicalDamageable
{
    [SerializeField] private Rigidbody2D rb;
    private Vector3 _shotForward;
    private int _birtherId;
    private const float Speed = 500.0f;
    [SerializeField] private FreezeCondition freezeCondition;

    public override void ItemInitialize(Racer racer) 
    {
        StageSEManager.Play(racer, SEPath.FREEZE);
        
        _birtherId = racer.id;

        var targetPos = Vector3.zero;
        switch (racer)
        {
            case PlayerController:
                targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                break;
            case CpuController:
                targetPos = RankManager.Instance.GetOneRankHigherRacer(racer.id).transform.position;
                break;
        }
        _shotForward = Vector3.Scale((targetPos - racer.transform.position), new Vector3(1, 1, 0)).normalized;

        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.velocity = _shotForward * Speed;
    }

    public void OnTriggerEnterRacer(Racer racer) 
    {
        // アイテムを出したレーサーとIDが同じか
        if(racer.id == _birtherId) {
            return;
        }

        if(!IPhysicalDamageable.IsPhysicalDamageable(racer)) {
            Destroy(gameObject);
            return;
        }
        
        Instantiate(freezeCondition, racer.transform.position, Quaternion.identity).Initialize(racer);
        Destroy(gameObject);
    }

}
