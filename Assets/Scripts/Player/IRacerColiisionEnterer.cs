using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// #error version
public interface IRacerCollisionEnterer {
   public void OnTriggerEnterRacer(Racer racer);
   // public bool IsPhysicalDamageable(Racer racer) {
   //    return true;
   // }
}
