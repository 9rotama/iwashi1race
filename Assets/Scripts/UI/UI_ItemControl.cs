using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ItemControl : MonoBehaviour
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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;
        changeTime += Time.deltaTime;
        if(time < 0.95f){
            if(changeTime > 0.08f ){
            changeTime = 0;
            image.sprite = sprites[spriteNum++%sprites.Length];
            }
        }
        else{
            image.sprite = sprites[determinItem];
        }

        
    }
}
