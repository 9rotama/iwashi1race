using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
public interface IItemInitializerOfPlayer {
    public abstract void ItemInitializeOfPlayer(int id, Vector3 birtherPos, GameObject gameObject);
}


public interface IItemInitializerOfCPUPlayer {
    public abstract void ItemInitializeOfCPUPlayer(int id, Vector3 birtherPos, GameObject gameObject);
}

public interface IItemInitializer : IItemInitializerOfCPUPlayer, IItemInitializerOfPlayer  {

}
