using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WindScript : MonoBehaviour, IItemInitializer
{
  
    [SerializeField] float addSpeed;
    [SerializeField] float addForceTime;
    private Racer parentRacer;

    public void ItemInitialize(Racer racer) {
        transform.SetParent(racer.transform);
        parentRacer = racer.GetComponent<Racer>();
        Destroy(gameObject, addForceTime);
    }

    private void FixedUpdate() {
        parentRacer.AddForce(addSpeed, Vector3.right);
    }

}
