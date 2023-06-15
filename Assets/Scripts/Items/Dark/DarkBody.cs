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
    
    [SerializeField] private Vector2 baseForce = new Vector2(1000, 1500);


    public void Initialize(Racer target, int rank, float destroyTime)
    {
        _targetRacer = target;
        _targetRank = rank;
        transform.SetParent(target.transform);

        Destroy(gameObject, destroyTime);
    }    

    private void FixedUpdate() 
    {
        Vector2 force;
        force.x = Random.Range(-baseForce.x, baseForce.x) / ((float)_targetRank);
        force.y = Random.Range(-baseForce.y, baseForce.y) / ((float)_targetRank);
        _targetRacer.AddForce(force);
    }

 
}
