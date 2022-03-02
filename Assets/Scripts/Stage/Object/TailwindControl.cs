using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailwindControl : MonoBehaviour
{
    private PlayerControl _playerControl;
    private CPUplayerControl _cpuPlayerControl;
    
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") )
        {
            _playerControl = other.GetComponent<PlayerControl>();
            _playerControl.WindEnter(2f);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        { 
            _cpuPlayerControl = other.GetComponent<CPUplayerControl>();
            _cpuPlayerControl.WindEnter(2f);
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
