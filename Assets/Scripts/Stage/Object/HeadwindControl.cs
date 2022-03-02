using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadwindControl : MonoBehaviour
{
    private PlayerControl _playerControl;
    private CPUplayerControl _cpuPlayerControl;
    
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") )
        {
            _playerControl = other.GetComponent<PlayerControl>();
            _playerControl.WindEnter(-0.3f);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        { 
            _cpuPlayerControl = other.GetComponent<CPUplayerControl>();
            _cpuPlayerControl.WindEnter(-0.3f);
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
