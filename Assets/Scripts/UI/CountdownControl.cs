using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownControl : MonoBehaviour
{
    private Image renderer;
    public Sprite three;
    public Sprite two;
    public Sprite one;
    // Start is called before the first frame update

    public void setSprite(int n)
    {
        if (n == 0)
        {
            this.gameObject.SetActive(false);
        }
        else if (n == 1)
        {
            this.gameObject.SetActive(true);
            renderer.sprite = one;
        }
        else if (n == 2)
        {
            this.gameObject.SetActive(true);
            renderer.sprite = two;
        }
        else if (n == 3)
        {
            this.gameObject.SetActive(true);
            renderer.sprite = three;
        }
    }

    void Awake()
    {
        renderer = GetComponent<Image>();
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
