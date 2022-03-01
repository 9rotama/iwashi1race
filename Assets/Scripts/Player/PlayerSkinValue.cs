using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerSkinValue : MonoBehaviour
{
    public float hairHue, clothesHue, shoesHue;
    public int hairLong;

    public void SetValueFromSlider()
    {
        Slider slider;
        var hairSlider = GameObject.Find("HairSlider");
        var clothesSlider = GameObject.Find("ClothesSlider");
        var shoesSlider = GameObject.Find("ShoesSlider");

        slider = hairSlider.GetComponent<Slider>();
        hairHue = slider.value;
        slider = clothesSlider.GetComponent<Slider>();
        clothesHue = slider.value;
        slider = shoesSlider.GetComponent<Slider>();
        shoesHue = slider.value;
    }
    
    public void SetValueToSlider()
    {
        Slider slider;
        var hairSlider = GameObject.Find("HairSlider");
        var clothesSlider = GameObject.Find("ClothesSlider");
        var shoesSlider = GameObject.Find("ShoesSlider");

        slider = hairSlider.GetComponent<Slider>();
        slider.value = hairHue;
        slider = clothesSlider.GetComponent<Slider>();
        slider.value = clothesHue;
        slider = shoesSlider.GetComponent<Slider>();
        slider.value = shoesHue;
    }

    public void SetValueToPlayer()
    {
        PlayerSpriteChange playerSpriteChange;

        var player = GameObject.Find("Player");
        
        var hairSprite = player.transform.Find("Hair").gameObject;
        playerSpriteChange = hairSprite.GetComponent<PlayerSpriteChange>();
        playerSpriteChange.hue = hairHue;
        var clothesSprite = player.transform.Find("Clothes").gameObject;
        playerSpriteChange = clothesSprite.GetComponent<PlayerSpriteChange>();
        playerSpriteChange.hue = clothesHue;
        var shoesSprite = player.transform.Find("Shoes").gameObject;
        playerSpriteChange = shoesSprite.GetComponent<PlayerSpriteChange>();
        playerSpriteChange.hue = shoesHue;

    }

    void Awake() {
        var numSkinValues = GameObject.FindGameObjectsWithTag("SkinValueHolder").Length;
        if (numSkinValues > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
