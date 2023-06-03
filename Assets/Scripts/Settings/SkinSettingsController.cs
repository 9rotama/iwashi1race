using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SkinSettingsController : MonoBehaviour
{

    [SerializeField] private Slider hairSlider;
    [SerializeField] private Slider clothesSlider;
    [SerializeField] private Slider shoesSlider;


    /// <summary>
    /// スライダーの値を読み取ってPlayerPrefsにセット
    /// </summary>
    public void SetPrefsFromSliderValue()
    {
        PlayerPrefs.SetFloat("hairHue", hairSlider.value);
        PlayerPrefs.SetFloat("clothesHue", clothesSlider.value);
        PlayerPrefs.SetFloat("shoesHue", shoesSlider.value);
    }
    
    /// <summary>
    /// PlayerPrefsの値を読み込んでスライダーにセット
    /// </summary>
    private void SetSliderValueFromPrefs()
    {
        hairSlider.value = PlayerPrefs.GetFloat("hairHue", 0);
        clothesSlider.value = PlayerPrefs.GetFloat("clothesHue",0);
        shoesSlider.value = PlayerPrefs.GetFloat("shoesHue", 0);
    }

    private void Start()
    {
        SetSliderValueFromPrefs();
    }
}
