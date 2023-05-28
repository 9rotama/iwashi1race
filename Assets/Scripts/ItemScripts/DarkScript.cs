using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DarkScript : CollisionStayObject
{
    [System.NonSerialized] public int targetRank;

    public override void OnTriggerStayCPUPlayer(GameObject cpuPlayer)
    {
        var cpuPlayerControl = cpuPlayer.GetComponent<CPUplayerControl>();
        cpuPlayerControl.WindStay(UnityEngine.Random.Range(-600,600) / targetRank);
    }

    public override void OnTriggerStayPlayer(GameObject player)
    {
        var playerControl = player.GetComponent<CPUplayerControl>();
        playerControl.WindStay(UnityEngine.Random.Range(-600,600)/targetRank);
    }

    

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5.0f);
    }


 
}
