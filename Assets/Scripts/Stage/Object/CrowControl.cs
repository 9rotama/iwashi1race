using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CrowControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float destroyPosX;
    
    private PlayerControl _playerControl;
    private CPUplayerControl _cpuPlayerControl;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") )
        {
            _playerControl = other.GetComponent<PlayerControl>();
            _playerControl.CrowEnter(-2f);
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        { 
            _cpuPlayerControl = other.GetComponent<CPUplayerControl>();
            _cpuPlayerControl.CrowEnter(-2f);
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        var position = this.transform.position;
        position = new Vector3(position.x - moveSpeed, position.y, position.z);
        
        transform.position = position;
        if (this.transform.position.x <= destroyPosX)
            Destroy(this.gameObject);
    }
}
