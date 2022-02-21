using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerControl : MonoBehaviour
{
    
    private int gameState = 0; //0...カウントダウン中 1...プレイ中 2...ゴール

    public AudioClip countdownSE,BGM;

    public GameObject CountdownUI;
    public GameObject ResultUI;
    public GameObject RankingUI;

    private Text rText;
    private CountdownControl countdownControl;
    private RankingControl rankingControl;
    private AudioSource audioSource;
    // Start is called before the first frame update

    private float totalTime;

    public int GetGameState()
    {
        return gameState;
    }

    public void PlayerGoal()
    {
        ResultUI.SetActive(true);
        var ranking = rankingControl.GetRanking();
        rText.text = "position: " + ranking.ToString()
                                  + "\ntime: "+ totalTime.ToString();
        gameState = 2;
    }

    void Start()
    {
        totalTime = 0;
        audioSource = gameObject.GetComponent<AudioSource>();
        countdownControl = CountdownUI.GetComponent<CountdownControl>();
        rankingControl = RankingUI.GetComponent<RankingControl>();
        rText = ResultUI.transform.GetChild(0).GetComponent<Text>();
        ResultUI.SetActive(false);
        StartCoroutine ("BeforeStart");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == 1)
        {
            totalTime += Time.deltaTime;
            Debug.Log("計測中： " + (totalTime).ToString());
        }

        if (gameState == 2 && Input.GetMouseButtonDown (0))
        {
            SceneManager.LoadScene ("TitleScene");
        }
    }

    IEnumerator BeforeStart()
    {
        while (true)
        {
            gameState = 0;
            
            countdownControl.setSprite(0);
            yield return new WaitForSeconds(1);
            
            countdownControl.setSprite(3);
            audioSource.clip = countdownSE;
            audioSource.Play();
            
            yield return new WaitForSeconds(1);
            
            countdownControl.setSprite(2);
            
            yield return new WaitForSeconds(1);
            
            countdownControl.setSprite(1);
            
            yield return new WaitForSeconds(1);
            
            countdownControl.setSprite(0);
            gameState = 1;
            
            yield return new WaitForSeconds(0.5f);
            
            audioSource.clip = BGM;
            audioSource.Play();
            
            yield break;
        }
    }
}
