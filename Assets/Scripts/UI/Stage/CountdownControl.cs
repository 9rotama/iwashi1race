using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownControl : MonoBehaviour
{
    private Image _img;
    [SerializeField] private Sprite three, two, one, go;


    public void SetSprite(int n)
    {
        switch (n)
        {
            case 0:
                gameObject.SetActive(false);
                break;
            case 1:
                gameObject.SetActive(true);
                _img.sprite = one;
                break;
            case 2:
                gameObject.SetActive(true);
                _img.sprite = two;
                break;
            case 3:
                gameObject.SetActive(true);
                _img.sprite = three;
                break;
            case 4:
                gameObject.SetActive(true);
                _img.sprite = go;
                break;
        }
    }

    private void Awake()
    {
        _img = GetComponent<Image>();
        gameObject.SetActive(false);
    }

}
