using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class OrbScript : MonoBehaviour, IItemInitializer
{

    private float _theta;
    private const int OrbGainNum = 10;
    [SerializeField] private float _angleSpeed = 0.1f;
    [SerializeField] private float _movingWidth = 15f;


    public void ItemInitialize(Racer racer)
    {
        transform.SetParent(racer.transform);

        racer.MagicOrbEnter(OrbGainNum);
    }

    private void FixedUpdate()
    {
        _theta += _angleSpeed; 
        transform.localPosition = Vector3.up * (Mathf.Sin(_theta) * _movingWidth);


        if(_theta > Mathf.PI){
            Destroy(gameObject);
        }

    }
}
