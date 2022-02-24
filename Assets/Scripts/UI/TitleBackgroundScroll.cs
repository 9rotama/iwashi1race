using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleBackgroundScroll : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private Material material;
    private Vector2 offset;
    void Start()
    {
        material = GetComponent<Image>().material;
        offset = new Vector2(0, 0);
    }

    void Update()
    {
        offset = new Vector2(offset.x + speed * 0.005f, 0);

        material.mainTextureOffset = offset;
    }
}
