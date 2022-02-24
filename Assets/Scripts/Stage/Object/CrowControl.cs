using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float DestroyPosX;
    
    private PlayerControl playerControl;
    private CPUplayerControl cpuPlayerControl;
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" )
        {
            playerControl = other.GetComponent<PlayerControl>();
            playerControl.CrowEnter();
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "Enemy")
        { 
            cpuPlayerControl = other.GetComponent<CPUplayerControl>();
            cpuPlayerControl.CrowEnter();
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x - moveSpeed, this.transform.position.y,
            this.transform.position.z);
        if (this.transform.position.x <= DestroyPosX)
            Destroy(this.gameObject);
    }
}
