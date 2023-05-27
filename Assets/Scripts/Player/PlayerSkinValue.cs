using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerSkinValue : MonoBehaviour
{
    public float hairHue, clothesHue, shoesHue;
    public int hairLong;

    private GameObject child;
    

    public void SetValueFromSlider()
    {
        var hairSlider = GameObject.Find("HairSlider");
        var clothesSlider = GameObject.Find("ClothesSlider");
        var shoesSlider = GameObject.Find("ShoesSlider");

        var slider = hairSlider.GetComponent<Slider>();
        hairHue = slider.value;
        slider = clothesSlider.GetComponent<Slider>();
        clothesHue = slider.value;
        slider = shoesSlider.GetComponent<Slider>();
        shoesHue = slider.value;
    }
    
    public void SetValueToSlider()
    {
        var hairSlider = GameObject.Find("HairSlider");
        var clothesSlider = GameObject.Find("ClothesSlider");
        var shoesSlider = GameObject.Find("ShoesSlider");

        var slider = hairSlider.GetComponent<Slider>();
        slider.value = hairHue;
        slider = clothesSlider.GetComponent<Slider>();
        slider.value = clothesHue;
        slider = shoesSlider.GetComponent<Slider>();
        slider.value = shoesHue;
    }

    public void SetValueToPlayer()
    {
        var player = GameObject.Find("Player");
        
        var hairSprite = player.transform.Find("Hair").gameObject;
        var playerSpriteChange = hairSprite.GetComponent<PlayerSpriteChange>();
        playerSpriteChange.hue = hairHue;
        
        var clothesSprite = player.transform.Find("Clothes").gameObject;
        playerSpriteChange = clothesSprite.GetComponent<PlayerSpriteChange>();
        playerSpriteChange.hue = clothesHue;
        
        var shoesSprite = player.transform.Find("Shoes").gameObject;
        playerSpriteChange = shoesSprite.GetComponent<PlayerSpriteChange>();
        playerSpriteChange.hue = shoesHue;


    }

    private void Awake() {
        child = transform.GetChild(0).gameObject;
        var numSkinValues = GameObject.FindGameObjectsWithTag("SkinValueHolder").Length;
        if (numSkinValues > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

        // if (!created)
        // {
        //     created = true;
        //     DontDestroyOnLoad(this.gameObject);
        //     DontDestroyOnLoad(IF_name.gameObject.transform.parent.gameObject);
        // }
        // else
        // {
        //     Destroy(this.gameObject);
        //     Destroy(IF_name.gameObject.transform.parent.gameObject);
        // }
    }
    
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Skin"){ 
            child.SetActive(true);
        }else{ 
            child.SetActive(false);
        }
    }
}
