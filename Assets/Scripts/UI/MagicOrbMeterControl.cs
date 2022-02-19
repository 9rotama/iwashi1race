using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicOrbMeterControl : MonoBehaviour
{
    private RectMask2D _rectMask2D;

    public void SetMeter(int magicOrbNum)
    {
        _rectMask2D.padding = new Vector4(0, 0, 50.5f - (float)magicOrbNum, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        _rectMask2D = GetComponent<RectMask2D>();
        _rectMask2D.padding = new Vector4(0, 0, 50.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
