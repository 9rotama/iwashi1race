using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// アタッチされているオブジェクトを起点にカラスを生成するクラス
/// 右に動きながら指定された高さの範囲でランダムに生成する
/// </summary>
public class CrowSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabCrow;
    [SerializeField] private const float StageHeight = 270f;
    [SerializeField] private const float MoveSpeed = 10.0f;
    [SerializeField] private const float SpawnSpan = 1.0f;

    private bool _isCoroutineStarted;
    private GameObject _gameManager;
    private GameManagerControl _gameManagerCtrl;
    
    /// <summary>
    /// 指定したスパンでy座標ランダムにカラスをスポーンし続ける
    /// </summary>
    private IEnumerator CrowSpawn(){
        while (true) {
            yield return new WaitForSeconds (SpawnSpan);
            var position = transform.position;
            var spawnPosHeight = position.y + (Random.value - 0.5f) * StageHeight;
            var spawnPos = new Vector3(position.x, spawnPosHeight, position.z);
            Instantiate(prefabCrow, spawnPos, Quaternion.identity);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        _isCoroutineStarted = false;
        _gameManager = GameObject.FindGameObjectWithTag("GameManager");
        _gameManagerCtrl = _gameManager.GetComponent<GameManagerControl>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(_gameManagerCtrl.GetGameState() == 0) return;
        //レースがスタートしていなければ処理しない
        if (!_isCoroutineStarted)
        {
            StartCoroutine (nameof(CrowSpawn));
            _isCoroutineStarted = true;
        }
        //CrowSpawnのコルーチンを一度だけ実行
        //TODO: わざわざUpdateに書いている理由を突き止める

        var transform1 = transform;
        var position = transform1.position;
        position = new Vector3(position.x + MoveSpeed * Time.deltaTime, position.y, position.z);
        transform1.position = position;
        //スポナーを動かす
    }
}
