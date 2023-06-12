using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOrbControl : MonoBehaviour, IRacerCollisionEnterer
{
    [SerializeField] private ItemDecider itemDecider;
    private OrbSpawner _parentOrbSpawner;


    public void OnTriggerEnterRacer(Racer racer)
    {
        itemDecider.DecideItem(racer);
        _parentOrbSpawner.OrbDestroyed();
        Destroy(this.gameObject);
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        _parentOrbSpawner = transform.parent.GetComponent<OrbSpawner>();
    }

}
