using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownControl : MonoBehaviour
{
    private Image _renderer;
    [SerializeField] private Sprite three, two, one, go;

    // Start is called before the first frame update

    public void SetSprite(int n)
    {
        switch (n)
        {
            case 0:
                this.gameObject.SetActive(false);
                break;
            case 1:
                this.gameObject.SetActive(true);
                _renderer.sprite = one;
                break;
            case 2:
                this.gameObject.SetActive(true);
                _renderer.sprite = two;
                break;
            case 3:
                this.gameObject.SetActive(true);
                _renderer.sprite = three;
                break;
            case 4:
                this.gameObject.SetActive(true);
                _renderer.sprite = go;
                break;
        }
    }

    private void Awake()
    {
        _renderer = GetComponent<Image>();
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
