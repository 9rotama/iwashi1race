using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSpawner : MonoBehaviour
{

    public GameObject prefabOrb;
    public float spawnSpan = 5.0f;

    public void OrbDestroyed()
    {
        StartCoroutine (nameof(OrbSpawn));
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
        var transform1 = transform;
        Instantiate(prefabOrb, transform1.position, Quaternion.identity, transform1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
