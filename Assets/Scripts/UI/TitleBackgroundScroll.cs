using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleBackgroundScroll : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private Material _material;
    private Vector2 _offset;

    private void Start()
    {
        _material = GetComponent<Image>().material;
        _offset = new Vector2(0, 0);
    }

    private void Update()
    {
        _offset = new Vector2(_offset.x + speed * Time.deltaTime * 0.5f, 0);

        _material.mainTextureOffset = _offset;
    }
}
