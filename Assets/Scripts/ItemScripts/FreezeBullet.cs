using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBullet: MonoBehaviour, IItemInitializer, IRacerCollisionEnterer, IPhysicalDamageable
{
    [SerializeField] private Rigidbody2D rb;
    Vector3 shotForward;
    int birtherId;
    const float speed = 500.0f;
    [SerializeField] FreezeCondition freezeCondition;
    [SerializeField] private AudioSource audioSource;

    public void ItemInitialize(Racer racer) 
    {
        // AudioSource.PlayClipAtPoint(audioSource.clip, new Vector3(transform.position.x + 100, transform.position.y, -10));
        audioSource.Play();

        birtherId = racer.id;

        Vector3 targetPos = Vector3.zero;
        if(racer is PlayerControl) {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if(racer is CPUplayerControl) {
            targetPos = RankManager.Instance.GetOneRankHigherRacer(racer.id).transform.position;
        }
        shotForward = Vector3.Scale((targetPos - racer.transform.position), new Vector3(1, 1, 0)).normalized;

        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = shotForward * speed;
    }

    public void OnTriggerEnterRacer(Racer racer) 
    {
        if(!IsPhysicalDamageable(racer)) return;
        Instantiate(freezeCondition, racer.transform.position, Quaternion.identity).Initialize(racer);
        Destroy(gameObject);
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
