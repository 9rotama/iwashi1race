using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeScript : MonoBehaviour, IItemInitializer
{
    [SerializeField] private Rigidbody2D rb;
    Vector3 shotForward;
    const float speed = 500.0f;

    [SerializeField] private int lostMagicOrbNum = 10;
    [SerializeField] GameObject stateFreeze;
    [SerializeField] private AudioSource audioSource;

    public void ItemInitialize(Racer racer) 
    {
        
    }

    // public void ItemInitializeOfPlayer(int id, Vector3 birtherPos, GameObject racer) {
    //     //発射音
    //     audioSource.Play();

    //     //発射方向指定
    //     Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //     shotForward = Vector3.Scale((mouseWorldPos - birtherPos), new Vector3(1, 1, 0)).normalized;
    // }

    // public void ItemInitializeOfCPUPlayer(int id, Vector3 birtherPos, GameObject racer) {

    //     //発射方向指定
    //     Vector3 targetPos = RankManager.Instance.GetOneRankHigherRacer(id).transform.position;
    //     shotForward = Vector3.Scale((targetPos - birtherPos), new Vector3(1, 1, 0)).normalized;
    // }

    // public override void OnTriggerEnterCPUPlayer(GameObject cpuPlayer)
    // {
    //     var cpuPlayerControl = cpuPlayer.GetComponent<PlayerControl>();
    //     cpuPlayerControl.StopperEnter(0, lostMagicOrbNum);
    //     GameObject obj = (GameObject)Instantiate(stateFreeze, cpuPlayer.transform.position, Quaternion.identity);
    //     obj.transform.SetParent(cpuPlayer.transform);
    //     Destroy(gameObject);
    // }

    // public override void OnTriggerEnterPlayer(GameObject player)
    // {
    //     var playerControl = player.GetComponent<Racer>();
        
    //     if(playerControl.isInvincible) {
    //         playerControl.isInvincible = false;
    //         Destroy(gameObject);
    //         return;
    //     }
    //     playerControl.StopperEnter(0, lostMagicOrbNum);
    //     GameObject obj = (GameObject)Instantiate(stateFreeze, player.transform.position, Quaternion.identity);
    //     obj.transform.SetParent(player.transform);
    //     Destroy(gameObject);
    // }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = shotForward * speed;
    }

}
