using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabCrow;
    [SerializeField] private float stageHeight;
    [SerializeField] private float spawnSpan = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine ("CrowSpawn");
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    IEnumerator CrowSpawn(){
        while (true) {
            yield return new WaitForSeconds (spawnSpan);
            var SpawnPosY = this.transform.position.y + (Random.value - 0.5f) * stageHeight;
            var SpawnPos = new Vector3(this.transform.position.x, SpawnPosY, this.transform.position.z);
            GameObject obj = Instantiate(prefabCrow, SpawnPos, Quaternion.identity);
        }
    }
}
