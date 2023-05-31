using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WindScript : MonoBehaviour, IItemInitializer
{
  
    [SerializeField] float addSpeed;
    [SerializeField] float addForceTime;
    private Racer parentRacer;

    public void ItemInitializeOfPlayer(int id, Vector3 birtherPos, GameObject racer) {
        transform.SetParent(racer.transform);
        parentRacer = racer.GetComponent<Racer>();
        Destroy(gameObject, addForceTime);
    }

    public void ItemInitializeOfCPUPlayer(int id, Vector3 birtherPos, GameObject racer) {
        transform.SetParent(racer.transform);
        parentRacer = racer.GetComponent<Racer>();
        Destroy(gameObject, addForceTime);
    }

    private void FixedUpdate() {
        parentRacer.WindStay(addSpeed);
    }

}
