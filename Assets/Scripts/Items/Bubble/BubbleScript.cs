using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour, IItemInitializer
{
    private Racer _parentRacer;

    public void ItemInitialize(Racer racer) 
    {
        transform.parent = racer.transform;
        _parentRacer = racer.GetComponent<Racer>();

        // isInvincibleが真のときbubbleをすでに持っているから破棄
        if(_parentRacer.isInvincible) {
            Destroy(gameObject);
        }

        _parentRacer.isInvincible = true;
    }

    private void Update()
    {
        if(_parentRacer != null && !_parentRacer.isInvincible) {
            Destroy(gameObject);
        }
    }
}
