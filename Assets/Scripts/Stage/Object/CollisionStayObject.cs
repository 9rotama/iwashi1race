using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollisionStayObject : MonoBehaviour, IPlayerCollisionStayer, ICPUPlayerCollisionStayer
{
   public abstract void OnTriggerStayCPUPlayer(GameObject other);

   public abstract void OnTriggerStayPlayer(GameObject other);
}
