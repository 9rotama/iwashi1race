using System.Collections;
using System.Collections.Generic;
using KanKikuchi.AudioManager;
using UnityEngine;

/// <summary>
/// 等速に進むファイアのクラス
/// </summary>
public class FireScript : MonoBehaviour, IItemInitializer, IRacerCollisionEnterer, IPhysicalDamageable
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float playerStopDur = 1.0f;
    [SerializeField] private int lostMagicOrbNum = 10;
    [SerializeField] private float speed = 500.0f;
    private Vector3 _shotForward;
    private int _birtherId;

    public void ItemInitialize(Racer racer)
    {
        
        var targetPos = Vector3.zero;
        switch (racer)
        {
            case PlayerController:
                targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                SEManager.Instance.Play(SEPath.FIRE);
                break;
            case CpuController:
                targetPos = RankManager.Instance.GetOneRankHigherRacer(racer.id).transform.position;
                break;
        }
        _birtherId = racer.id;
        _shotForward = Vector3.Scale((targetPos - racer.transform.position), Vector2.one).normalized;
    
        // 三秒後に消える
        Destroy(this.gameObject, 3.0f);
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

        racer.StopperEnter(playerStopDur, lostMagicOrbNum);
        SEManager.Instance.Play(SEPath.DAMAGE);
    }
    

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.velocity = _shotForward * speed;
    }

}
