using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DarkAlpha : MonoBehaviour
{
    float time;
    Image render;
    // Start is called before the first frame update
    void Start()
    {
        render = gameObject.GetComponent<Image>();
        Color proColor = render.color;
        proColor.a = 0f;
        render.color = proColor;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;

        const float sp = 0.01f;
        Color proColor = render.color;

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
        else{
            proColor.a -= sp;
            if(render.color.a <= 0){
                Destroy(transform.parent.parent.gameObject);
            }
        }
        render.color = proColor;

    }
}
