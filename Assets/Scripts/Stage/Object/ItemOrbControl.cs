using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOrbControl : MonoBehaviour, IRacerCollisionEnterer
{
    [SerializeField] ItemDecider itemDecider;

    public void OnTriggerEnterRacer(Racer racer)
    {
        itemDecider.DecideItem(racer);
        Destroy(this.gameObject);
    }

}
