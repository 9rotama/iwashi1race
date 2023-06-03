using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public enum GameState
{
    Idle,
    Race,
    Goal
}

public class GameManagerControl : MonoBehaviour
{
    
    
    private GameState _gameState; //0...カウントダウン中 1...プレイ中 2...ゴール

    [SerializeField] private AudioClip countdownSe, goalSe,bgm;

    public GameObject countdownUI;
    public GameObject resultUI;
    public GameObject rankingUI;

    private Text _rText;
    private CountdownControl _countdownControl;
    private RankingControl _rankingControl;
    private AudioSource _audioSource;
    // Start is called before the first frame update

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

        _audioSource.clip = goalSe;
        _audioSource.loop = false;
        _audioSource.Play();
        
       SetGameState(GameState.Goal);
    }

    private void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();

        _countdownControl = countdownUI.GetComponent<CountdownControl>();
        _rankingControl = rankingUI.GetComponent<RankingControl>();
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
            _audioSource.clip = countdownSe;
            _audioSource.Play();
            
            yield return new WaitForSeconds(1);
            
            _countdownControl.SetSprite(2);
            
            yield return new WaitForSeconds(1);
            
            _countdownControl.SetSprite(1);
            
            yield return new WaitForSeconds(1);

            SetGameState(GameState.Race);
            _countdownControl.SetSprite(4);
            
            yield return new WaitForSeconds(0.5f);
            
            _audioSource.clip = bgm;
            _audioSource.Play();
            _audioSource.loop = true;
            
            _countdownControl.SetSprite(0);

            yield break;
        }
    }
}
