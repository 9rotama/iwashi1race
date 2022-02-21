using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicOrbControl : MonoBehaviour
{
    private PlayerControl playerControl;
    private CPUplayerControl cpuPlayerControl;
    private OrbSpawner orbSpawner;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" )
        {
            playerControl = other.GetComponent<PlayerControl>();
            playerControl.MagicOrbEnter();
            orbSpawner.OrbDestroyed();
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "Enemy")
        { 
            cpuPlayerControl = other.GetComponent<CPUplayerControl>();
            cpuPlayerControl.MagicOrbEnter();
            orbSpawner.OrbDestroyed();
            Destroy(this.gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
