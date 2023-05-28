using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOrbControl : CollisionEnterObject
{
    [SerializeField] ItemDecider itemDecider;

    public override void OnTriggerEnterCPUPlayer(GameObject racerObject)
    {
        var racer = racerObject.GetComponent<Racer>();
        itemDecider.DecideItem(racer);
        Destroy(this.gameObject);
    }

    public override void OnTriggerEnterPlayer(GameObject racerObject)
    {
        var racer = racerObject.GetComponent<Racer>();
        itemDecider.DecideItem(racer);
        Destroy(this.gameObject);
    }

}
