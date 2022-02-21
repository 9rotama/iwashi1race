using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerControl : MonoBehaviour
{
    
    private int gameState = 0; //0...カウントダウン中 1...プレイ中 2...ゴール

    public AudioClip countdownSE,BGM;

    public GameObject CountdownUI;
    private CountdownControl countdownControl;
    private AudioSource audioSource;
    // Start is called before the first frame update

    public int GetGameState()
    {
        return gameState;
    }

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        countdownControl = CountdownUI.GetComponent<CountdownControl>();
        StartCoroutine ("BeforeStart");
    }

    // Update is called once per frame
    void Update()
    {
        
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
