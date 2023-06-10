using System.Collections;
using System.Collections.Generic;
using KanKikuchi.AudioManager;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ItemRandomDisplay : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    private Image _image;
    private float _changeTime;
    private float _time;
    private int _spriteNum;
    [FormerlySerializedAs("determinItem")] public int determineItem;

    // Start is called before the first frame update
    private void Start()
    {
        _image = GetComponent<Image>();
        OnEnable();
    }

    private void OnEnable()
    {
        SEManager.Instance.Play(SEPath.ITEM_ORB);
        _time = 0;
        _changeTime = 0;
    }

    private void FixedUpdate()
    {
        _time += Time.deltaTime;
        _changeTime += Time.deltaTime;
        if(_time < 2.07f)
        {
            if (!(_changeTime > 0.08f)) return;
            _changeTime = 0;
            _image.sprite = sprites[_spriteNum++%sprites.Length];
        }
        else{
            if(determineItem == -1) _time = 0;
            _image.sprite = sprites[determineItem];
        }

        
    }
}
