using System;
using System.Collections;
using UnityEditorInternal;
using UnityEngine;
/// <summary>
/// アタッチされているオブジェクトを起点にカラスを生成するクラス
/// 右に動きながら指定された高さの範囲でランダムに生成する
/// </summary>
public class CrowSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabCrow;
    [SerializeField] private float stageHeight = 270f;
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private float spawnSpan = 200.0f;
    [SerializeField] private GameObject stopper;
    
    private bool _isCoroutineStarted;
    private GameObject _gameManager;
    private GameManagerControl _gameManagerCtrl;
    private float _velocity = 0f;
    private float _crowMoveSpeed;
    private Vector3 _prevPosition;
    
    private void CalcVelocity()
    {
        var position = transform.position;
        var velocityVec2 = (position - _prevPosition) / Time.deltaTime;
        _velocity = (float)Math.Sqrt(Math.Pow(velocityVec2.x,2)+Math.Pow(velocityVec2.y,2));
        _prevPosition = position;
    }
    
    /// <summary>
    /// 指定したスパンでy座標ランダムにカラスをスポーンし続ける
    /// </summary>
    private IEnumerator CrowSpawn(){
        while (true) {
            var position = transform.position;
            var spawnPosHeight = position.y + (UnityEngine.Random.value - 0.5f) * stageHeight;
            var spawnPos = new Vector3(position.x, spawnPosHeight, position.z);
            Instantiate(prefabCrow, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds (spawnSpan / Mathf.Abs(-_velocity * Time.deltaTime - _crowMoveSpeed * Time.deltaTime));
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        _isCoroutineStarted = false;
        _gameManager = GameObject.FindGameObjectWithTag("GameManager");
        _gameManagerCtrl = _gameManager.GetComponent<GameManagerControl>();
        var crowCtrl = prefabCrow.GetComponent<CrowControl>();
        _crowMoveSpeed = crowCtrl.moveSpeed;
    }

    private void Update()
    {
        CalcVelocity();
        
        if(_gameManagerCtrl.GetGameState() == GameState.Idle) return;
        //レースがスタートしていなければ処理しない
        if (!_isCoroutineStarted)
        {
            StartCoroutine (nameof(CrowSpawn));
            _isCoroutineStarted = true;
        }
        //CrowSpawnのコルーチンを一度だけ実行

        if (transform.position.x > stopper.transform.position.x) return;
        
        var transform1 = transform;
        var position = transform1.position;
        position = new Vector3(position.x + moveSpeed * Time.deltaTime, position.y, position.z);
        transform1.position = position;
        //スポナーを動かす
    }
}
