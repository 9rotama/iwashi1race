using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbScript : MonoBehaviour, IItemInitializer
{
    private GameObject _parant;
    private float _theta;

    private int orbGainNum = 10;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _parant = transform.parent.gameObject;
        transform.parent = null;

        if(_parant.CompareTag("Player")){
            _parant.GetComponent<PlayerControl>().MagicOrbEnter(orbGainNum);
        }
        else {
            _parant.GetComponent<CPUplayerControl>().MagicOrbEnter(orbGainNum);
        }
    }

    public void ItemInitializeOfCPUPlayer(int id, Vector3 birtherPos, GameObject racer) 
    {
        transform.SetParent(racer.transform);
        racer.GetComponent<Racer>().MagicOrbEnter(orbGainNum);
    }

    public void ItemInitializeOfPlayer(int id, Vector3 birtherPos, GameObject racer)
    {
        transform.SetParent(racer.transform);
        racer.GetComponent<Racer>().MagicOrbEnter(orbGainNum);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _theta += 0.1f; 
        Vector3 tmp =  _parant.transform.position;
        tmp.y += Mathf.Sin(_theta)*15f;
        transform.position = tmp;
        if(_theta > Mathf.PI){
            Destroy(gameObject);
        }

    }
}
