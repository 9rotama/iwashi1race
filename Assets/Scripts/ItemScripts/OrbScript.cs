using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbScript : MonoBehaviour
{
    GameObject parant;
    float theta;
    
    // Start is called before the first frame update
    void Start()
    {
        parant = transform.parent.gameObject;
        transform.parent = null;

        if(parant.tag == "Player"){
            parant.GetComponent<PlayerControl>().MagicOrbEnter();
        }
        else {
            parant.GetComponent<CPUplayerControl>().MagicOrbEnter();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        theta += 0.1f; 
        Vector3 tmp =  parant.transform.position;
        tmp.y += Mathf.Sin(theta)*15f;
        transform.position = tmp;
        if(theta > Mathf.PI){
            Destroy(gameObject);
        }

    }
}
