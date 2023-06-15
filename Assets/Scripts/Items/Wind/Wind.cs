using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// レーサーを加速させるクラス
/// </summary>
public class Wind : FirstItemCreated
{
  
    [SerializeField] private float addSpeed;
    [SerializeField] private float addForceTime;
    private Racer _parentRacer;

    public override void ItemInitialize(Racer racer) {
        transform.SetParent(racer.transform);
        _parentRacer = racer;
        Destroy(gameObject, addForceTime);
    }

    private void FixedUpdate() {
        _parentRacer.AddForce(addSpeed * Vector3.right);
    }

}
