using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SkinSettingsScreen : MonoBehaviour
{
    [SerializeField] private Button returnButton;
    [SerializeField] private Slider hairSlider, clothesSlider, shoesSlider;
    [SerializeField] private RacerSpriteColorController hair, clothes, shoes;


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

    private void SetHairPreviewFromSliderValue(float value)
    {
        hair.SetMaterialHue(hairSlider.value);
    }
    
    private void SetClothesPreviewFromSliderValue(float value)
    {
        clothes.SetMaterialHue(clothesSlider.value);
    }
    
    private void SetShoesPreviewFromSliderValue(float value)
    {
        shoes.SetMaterialHue(shoesSlider.value);
    }

    private void ReturnTitle()
    {
        SceneManager.LoadScene("Title");
    }

    private void Start()
    {
        hairSlider.onValueChanged.AddListener(SetHairPreviewFromSliderValue);
        clothesSlider.onValueChanged.AddListener(SetClothesPreviewFromSliderValue);
        shoesSlider.onValueChanged.AddListener(SetShoesPreviewFromSliderValue);
        SetSliderValueFromPrefs();
        returnButton.onClick.AddListener(() =>
        {
            Invoke(nameof(ReturnTitle), 0.5f);
        });
        
    }
}
