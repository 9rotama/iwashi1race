using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireScript : MonoBehaviour, IItemInitializer, IRacerCollisionEnterer, IPhysicalDamageable
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip fireSe;
    [SerializeField] private AudioClip damageSe;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float playerStopDur = 1.0f;
    [SerializeField] private int lostMagicOrbNum = 10;
    [SerializeField] private float speed = 500.0f;
    private Vector3 shotForward;
    private int birtherId;

    // public void ItemInitializeOfCPUPlayer(int id, Vector3 birtherPos, GameObject racer) 
    // {

    //     Vector3 targetPos = RankManager.Instance.GetOneRankHigherRacer(id).transform.position;
    //     shotForward = Vector3.Scale((targetPos - birtherPos), new Vector3(1, 1, 0)).normalized;
        
    //     // 三秒後に消える
    //     Destroy(this.gameObject, 3.0f);
    // }

    public void ItemInitialize(Racer racer)
    {
        AudioSource.PlayClipAtPoint(fireSe, transform.position);
        Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        shotForward = Vector3.Scale((targetPos - racer.transform.position), new Vector3(1, 1, 0)).normalized;

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
        rb.velocity = shotForward * speed;
    }

    private bool IsPhysicalDamageable(Racer racer)
    {
        if(racer.id == birtherId) {
            return false;
        }

        if(racer.isInvincible == true) {
            return false;
        }

        racer.isInvincible = false;
        return true;
    }
}
