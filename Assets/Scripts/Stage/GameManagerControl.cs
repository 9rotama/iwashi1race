using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerControl : MonoBehaviour
{
    
    private int gameState = 0; //0...カウントダウン中 1...プレイ中 2...ゴール

    public AudioClip countdownSE,goalSE,bgm;

    public GameObject countdownUI;
    public GameObject resultUI;
    public GameObject rankingUI;

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
        resultUI.SetActive(true); 
        var ranking = rankingControl.GetRanking();
        rText.text = "position: " + ranking.ToString()
                                  + "\ntime: "+ totalTime.ToString();

        audioSource.clip = goalSE;
        audioSource.loop = false;
        audioSource.Play();
        
        gameState = 2;
    }

    void Start()
    {
        
        audioSource = gameObject.GetComponent<AudioSource>();

        countdownControl = countdownUI.GetComponent<CountdownControl>();
        rankingControl = rankingUI.GetComponent<RankingControl>();
        rText = resultUI.transform.GetChild(0).GetComponent<Text>();

        totalTime = 0;
        resultUI.SetActive(false);
        StartCoroutine ("BeforeStart");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == 1)
        {
            totalTime += Time.deltaTime;
        }

        if (gameState == 2 && Input.GetMouseButtonDown (0))
        {
            SceneManager.LoadScene ("Title");
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
            
            gameState = 1;
            countdownControl.setSprite(4);
            
            yield return new WaitForSeconds(0.5f);
            
            audioSource.clip = bgm;
            audioSource.Play();
            audioSource.loop = true;
            
            countdownControl.setSprite(0);

            yield break;
        }
    }
}
