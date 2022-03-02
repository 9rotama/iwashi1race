using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabCrow;
    [SerializeField] private float stageHeight;
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private float spawnSpan = 1.0f;

    private bool _isCoroutineStarted;
    
    /*-----------*/
    private GameObject _gameManager;
    private GameManagerControl _gameManagerCtrl;
    /*-----------*/


    // Start is called before the first frame update
    private void Start()
    {
        _isCoroutineStarted = false;
        /*-----------*/
        _gameManager = GameObject.FindGameObjectWithTag("GameManager");
        _gameManagerCtrl = _gameManager.GetComponent<GameManagerControl>();
        /*-----------*/
    }

    // Update is called once per frame
    private void Update()
    {
        /*-----------*/
        if(_gameManagerCtrl.GetGameState() == 0) return;
        /*-----------*/
        if (!_isCoroutineStarted)
        {
            StartCoroutine (nameof(CrowSpawn));
            _isCoroutineStarted = true;
        }

        var position = transform.position;
        position = new Vector3(position.x + moveSpeed, position.y, position.z);
        transform.position = position;
    }

    private IEnumerator CrowSpawn(){
        while (true) {
            yield return new WaitForSeconds (spawnSpan);
            var position = transform.position;
            var spawnPosHeight = position.y + (Random.value - 0.5f) * stageHeight;
            var spawnPos = new Vector3(position.x, spawnPosHeight, position.z);
            var obj = Instantiate(prefabCrow, spawnPos, Quaternion.identity);
        }
    }
}
