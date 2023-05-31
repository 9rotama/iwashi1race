using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollisionEnterObject : MonoBehaviour, IPlayerCollisionEnterer, ICPUPlayerCollisionEnterer
{
   [System.NonSerialized] public int birtherId;
   
   [SerializeField] protected AudioSource audioSource;

   public abstract void OnTriggerEnterCPUPlayer(GameObject cpuPlayer);

   public abstract void OnTriggerEnterPlayer(GameObject player);
}
