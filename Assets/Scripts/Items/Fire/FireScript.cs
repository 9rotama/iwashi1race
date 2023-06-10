using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 等速に進むファイアのクラス
/// </summary>
public class FireScript : MonoBehaviour, IItemInitializer, IRacerCollisionEnterer, IPhysicalDamageable
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip fireSe;
    [SerializeField] private AudioClip damageSe;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float playerStopDur = 1.0f;
    [SerializeField] private int lostMagicOrbNum = 10;
    [SerializeField] private float speed = 500.0f;
    private Vector3 _shotForward;
    private int _birtherId;

    public void ItemInitialize(Racer racer)
    {
        
        var targetPos = Vector3.zero;
        if(racer is PlayerController) {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             AudioSource.PlayClipAtPoint(fireSe, transform.position);
        }
        else if(racer is CpuController) {
            targetPos = RankManager.Instance.GetOneRankHigherRacer(racer.id).transform.position;
        }
        _birtherId = racer.id;
        _shotForward = Vector3.Scale((targetPos - racer.transform.position), Vector2.one).normalized;
    
        // 三秒後に消える
        Destroy(this.gameObject, 3.0f);
    }

    public void OnTriggerEnterRacer(Racer racer)
    {
        if(!IsPhysicalDamageable(racer)) return;

        racer.StopperEnter(playerStopDur, lostMagicOrbNum);
        audioSource.PlayOneShot(damageSe);
        Destroy(this.gameObject);
    }



    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.velocity = _shotForward * speed;
    }

    public bool IsPhysicalDamageable(Racer racer)
    {
        if(racer.id == _birtherId) {
            return false;
        }

        if(racer.isInvincible == true) {
            return false;
        }

        racer.isInvincible = false;
        return true;
    }
}
