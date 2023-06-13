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

    private Racer _targetRacer;
    
    [SerializeField] private float baseAddedForce = 1000;

    public void Initialize(Racer target, int rank, float destroyTime)
    {
        _targetRacer = target;
        _targetRank = rank;
        transform.SetParent(target.transform);

        Destroy(gameObject, destroyTime);
    }    

    private void FixedUpdate() 
    {
        float AddedForce = Random.Range(-baseAddedForce, baseAddedForce) / ((float)_targetRank);
        _targetRacer.AddForce(AddedForce, new Vector3(1,1,0));
    }

 
}
