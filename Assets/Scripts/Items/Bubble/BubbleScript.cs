using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour, IItemInitializer
{
    private Racer parentRacer;

    public void ItemInitialize(Racer racer) 
    {
        transform.parent = racer.transform;
        parentRacer = racer.GetComponent<Racer>();

        // isInvincibleが真のときbubbleをすでに持っているから破棄
        if(parentRacer.isInvincible) {
            Destroy(gameObject);
        }

        parentRacer.isInvincible = true;
    }

    void Update()
    {
        if(parentRacer != null && !parentRacer.isInvincible) {
            Destroy(gameObject);
        }
    }
}
