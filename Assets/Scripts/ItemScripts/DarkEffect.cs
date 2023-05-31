using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DarkEffect : MonoBehaviour
{
    float time;
    [SerializeField] Image effectImage;

    // Start is called before the first frame update
    void Start()
    {
        new Color(effectImage.color.r, effectImage.color.g, 0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log("aiueo");
        time += Time.deltaTime;

        const float sp = 0.01f;
        Color proColor = effectImage.color;

        if(time < 1.0f){
            proColor.a += sp*2f;
        }
        else if(time < 2.0f){
            proColor.a -= sp;
        }
        else if(time < 3f){
            proColor.a += sp;
        }
        else if(time < 4f){ 
            proColor.a -= sp;
        }
        else if(time < 5f){
            proColor.a += sp;
        }
        else if(time < 6f){
            proColor.a -= sp;
        }
        else if(time < 7f){
            proColor.a += sp;
        }
        else if(time < 8f){
            proColor.a -= sp;
        }

        effectImage.color = proColor;

    }
}
