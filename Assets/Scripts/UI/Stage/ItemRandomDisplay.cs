using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemRandomDisplay : MonoBehaviour
{
    [SerializeField] Sprite[] sprites; 
    Image image;
    float changeTime;
    float time;
    int spriteNum;
    public int determinItem;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        OnEnable();
    }

    void OnEnable()
    {
        GetComponent<ItemRandomAudio>().PlayItemSound();
        time = 0;
        changeTime = 0;
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;
        changeTime += Time.deltaTime;
        if(time < 2.07f){
            if(changeTime > 0.08f ){
            changeTime = 0;
            image.sprite = sprites[spriteNum++%sprites.Length];
            }
        }
        else{
            if(determinItem == -1) time = 0;
            image.sprite = sprites[determinItem];
        }

        
    }
}
