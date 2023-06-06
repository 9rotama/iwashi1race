using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbScript : MonoBehaviour, IItemInitializer
{

    private float _theta;

    private const int OrbGainNum = 10;


    public void ItemInitialize(Racer racer)
    {
        transform.SetParent(racer.transform);

        racer.MagicOrbEnter(OrbGainNum);
    }

    private void FixedUpdate()
    {
        _theta += 0.1f; 
        transform.localPosition = Vector3.up * (Mathf.Sin(_theta) * 15f);


        if(_theta > Mathf.PI){
            Destroy(gameObject);
        }

    }
}
