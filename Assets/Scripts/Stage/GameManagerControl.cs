using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using KanKikuchi.AudioManager;


/// <summary>
/// ゲームの状態（スタート前、レース中、ゴール）やそれに応じたUI・音の操作を担当するクラス
/// </summary>
public class GameManagerControl : MonoBehaviour
{
    private GameState _gameState; //0...カウントダウン中 1...プレイ中 2...ゴール
    
    public GameObject countdownUI;
    public GameObject resultUI;

    private Text _rText;
    private CountdownControl _countdownControl;

    private float _totalTime;

    public GameState GetGameState()
    {
        return _gameState;
    }

    private void SetGameState(GameState gameState)
    {
        _gameState = gameState;
    }

    public void PlayerGoal()
    {
        resultUI.SetActive(true); 
        var rank = RankManager.Instance.GetRank(0);
        _rText.text = "position: " + rank + "\ntime: "+ _totalTime;

        BGMManager.Instance.Stop();
        SEManager.Instance.Play(SEPath.GOAL);
        
       SetGameState(GameState.Goal);
    }

    private void Start()
    {
        _countdownControl = countdownUI.GetComponent<CountdownControl>();
        _rText = resultUI.transform.GetChild(0).GetComponent<Text>();

        _totalTime = 0;
        resultUI.SetActive(false);
        StartCoroutine (CountDown());
    }

    // Update is called once per frame
    private void Update()
    {
        switch (_gameState)
        {
            case GameState.Race:
                _totalTime += Time.deltaTime;
                break;
            case GameState.Goal when Input.GetMouseButtonDown (0):
                SceneManager.LoadScene ("Title");
                break;
            case GameState.Idle:
                break;
        }
    }

    private IEnumerator CountDown()
    {
        while (true)
        {
            _gameState = 0;
            
            _countdownControl.SetSprite(0);
            yield return new WaitForSeconds(3);
            
            _countdownControl.SetSprite(3);
            SEManager.Instance.Play(SEPath.COUNTDOWN);
            
            yield return new WaitForSeconds(1);
            
            _countdownControl.SetSprite(2);
            
            yield return new WaitForSeconds(1);
            
            _countdownControl.SetSprite(1);
            
            yield return new WaitForSeconds(1);

            SetGameState(GameState.Race);
            _countdownControl.SetSprite(4);
            
            yield return new WaitForSeconds(0.5f);
            
            BGMManager.Instance.Play(BGMPath.STAGE_MEADOW);
            
            _countdownControl.SetSprite(0);

            yield break;
        }
    }
}
