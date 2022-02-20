using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailwindControl : MonoBehaviour
{
    private PlayerControl playerControl;
    private CPUplayerControl cpuPlayerControl;
    
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" )
        {
            playerControl = other.GetComponent<PlayerControl>();
            playerControl.WindEnter(2f);
        }
        else if (other.gameObject.tag == "Enemy")
        { 
            cpuPlayerControl = other.GetComponent<CPUplayerControl>();
            cpuPlayerControl.WindEnter(2f);
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
