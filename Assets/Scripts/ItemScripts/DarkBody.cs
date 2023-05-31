using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkBody : MonoBehaviour
{
    private int _targetRank;

    private float _destroyTime;

    private Racer _targetRacer;
    
    [SerializeField] private float baseAddedForce = 1000;

    public void initialize(Racer target, int rank, float destroyTime)
    {
        _targetRacer = target;
        _targetRank = rank;
        _destroyTime = destroyTime;
        transform.SetParent(target.transform);
    }    

    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, _destroyTime);
    }

    private void FixedUpdate() 
    {
        float AddedForce = Random.Range(-baseAddedForce, baseAddedForce) / ((float)_targetRank);
        _targetRacer.WindStay(AddedForce);
    }

 
}
