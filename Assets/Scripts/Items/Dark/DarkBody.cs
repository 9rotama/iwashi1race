using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// DarkCreatorから作られるアイテムダークの本体
/// レーサーにランダムに力を加え操作を難しくする
/// </summary>
public class DarkBody : MonoBehaviour
{
    private int _targetRank;

    private float _destroyTime;

    private Racer _targetRacer;
    
    [SerializeField] private float baseAddedForce = 1000;

    public void Initialize(Racer target, int rank, float destroyTime)
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
        _targetRacer.AddForce(AddedForce, new Vector3(1,1,0));
    }

 
}
