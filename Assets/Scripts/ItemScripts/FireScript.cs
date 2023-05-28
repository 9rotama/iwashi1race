using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : CollisionEnterObject, IItemInitializer
{
    [SerializeField] AudioClip fireSe;
    [SerializeField] AudioClip damageSe;
    [SerializeField] RankManager rankManager;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private float playerStopDur = 1.0f;
    [SerializeField] private int lostMagicOrbNum = 10;
    [SerializeField] private float speed = 500.0f;
    private Vector3 shotForward;
    

    public override void OnTriggerEnterCPUPlayer(GameObject cpuPlayer)
    {
        var cpuPlayerControl = cpuPlayer.GetComponent<CPUplayerControl>();
        cpuPlayerControl.StopperEnter(playerStopDur, lostMagicOrbNum);
        audioSource.PlayOneShot(damageSe);
        Destroy(this.gameObject);
    }

    public override void OnTriggerEnterPlayer(GameObject player)
    {
        var playerControl = player.GetComponent<PlayerControl>();
        playerControl.StopperEnter(playerStopDur, lostMagicOrbNum);
        audioSource.PlayOneShot(damageSe);
        Destroy(this.gameObject);
    }

    public void ItemInitializeOfCPUPlayer(int id, Vector3 birtherPos, GameObject racer) 
    {
        audioSource.PlayOneShot(fireSe);
        Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        shotForward = Vector3.Scale((targetPos - birtherPos), new Vector3(1, 1, 0)).normalized;
        
        // 三秒後に消える
        Destroy(this.gameObject, 3.0f);
    }

    public void ItemInitializeOfPlayer(int id, Vector3 birtherPos, GameObject racer)
    {
        Vector3 targetPos = rankManager.GetOneRankHigherRacer(birtherId).transform.position;
        shotForward = Vector3.Scale((targetPos - birtherPos), new Vector3(1, 1, 0)).normalized;

        // 三秒後に消える
        Destroy(this.gameObject, 3.0f);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.velocity = shotForward * speed;
    }
}
