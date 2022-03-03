using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMagicOrbControl : MonoBehaviour
{
    
    private PlayerControl _playerControl;
    private CPUplayerControl _cpuPlayerControl;
    private OrbSpawner _orbSpawner;

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerControl = other.GetComponent<PlayerControl>();
            _playerControl.MagicOrbEnter(1);
            _orbSpawner.OrbDestroyed();
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        { 
            _cpuPlayerControl = other.GetComponent<CPUplayerControl>();
            _cpuPlayerControl.MagicOrbEnter(1);
            _orbSpawner.OrbDestroyed();
            Destroy(this.gameObject);
        }
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        _orbSpawner = transform.parent.GetComponent<OrbSpawner>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
