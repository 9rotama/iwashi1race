using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollisionEnterObject : MonoBehaviour, IPlayerCollisionEnterer, ICPUPlayerCollisionEnterer
{
   public int birtherId;
   public abstract void OnTriggerEnterCPUPlayer(GameObject cpuPlayer);

   public abstract void OnTriggerEnterPlayer(GameObject player);
}
