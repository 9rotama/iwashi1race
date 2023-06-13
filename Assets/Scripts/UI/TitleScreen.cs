using System;
using System.Collections;
using System.Collections.Generic;
using KanKikuchi.AudioManager;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TitleScreen : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button skinButton;
    [SerializeField] private Button ruleButton;

    private void MoveStageSelect()
    {
        SceneManager.LoadScene("Stage");
    }

    private void MoveSkinSetting()
    {
        SceneManager.LoadScene("Skin");
    }
    
    private void MoveRule()
    {
        SceneManager.LoadScene("Rule");
    }
    
    private void Start()
    {
        startButton.onClick.AddListener(() =>
        {
            Invoke(nameof(MoveStageSelect), 0.5f);
        });
        skinButton.onClick.AddListener(() =>
        {
            Invoke(nameof(MoveSkinSetting), 0.5f);
        });
        ruleButton.onClick.AddListener(() =>
        {
            Invoke(nameof(MoveRule), 0.5f);
        });
        var currentBGMNames = BGMManager.Instance.GetCurrentAudioNames();
        if(!currentBGMNames.Contains("title")) BGMManager.Instance.Play(BGMPath.TITLE);
    }
}
