using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RuleButtonScript : MonoBehaviour
{
    [SerializeField] Sprite[] image;

    public void MouseDown()
    {
        GetComponent<Image>().sprite = image[2];
    }

    public void MouseOver()
    {
        GetComponent<Image>().sprite = image[1];
    }

    public void MouseExit()
    {
        GetComponent<Image>().sprite = image[0];
    }
    
}
