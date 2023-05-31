using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WindScript : MonoBehaviour, IItemInitializer
{
    float time;
    [SerializeField] float addSpeed;
    [SerializeField] float addForceTime;
    [SerializeField] Sprite[] windEffectImages;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float[] imageLimitSpeeds = new float[2];
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
