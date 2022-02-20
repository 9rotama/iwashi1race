using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSpawner : MonoBehaviour
{

    public GameObject prefabOrb;
    public float spawnSpan = 5.0f;

    public void OrbDestroyed()
    {
        StartCoroutine ("OrbSpawn");
    }

    IEnumerator OrbSpawn()
    {
        yield return new WaitForSeconds (spawnSpan);
        var childObj = Instantiate(prefabOrb, this.transform.position, Quaternion.identity);
        childObj.transform.parent = this.transform;
    }


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(prefabOrb, this.transform.position, Quaternion.identity, this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
