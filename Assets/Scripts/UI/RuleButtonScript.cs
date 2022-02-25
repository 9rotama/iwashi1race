using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RuleButtonScript : MonoBehaviour
{
    [SerializeField] Sprite[] image;

    public void OnClick()
    {
        GetComponent<Image>().sprite = image[2];

        if (gameObject.name == "ReturnButton")
        {
            Invoke("ChangeScene", 0.5f);
        }
        else if (gameObject.name == "BackButton")
        {
            Invoke("ChangePage", 0.5f);
        }
        else if (gameObject.name == "NextButton")
        {
            Invoke("ChangePage", 0.5f);
        }
    }

    public void MouseOver()
    {
        GetComponent<Image>().sprite = image[1];
    }

    public void MouseExit()
    {
        GetComponent<Image>().sprite = image[0];
    }

    public void ChangeScene()
    {
        if (gameObject.name == "ReturnButton")
        {
            SceneManager.LoadScene("Title");
        }

    }
    public void ChangePage()
    {
        if (gameObject.name == "BackButton")
        {
            
        }
        else if (gameObject.name == "NextButton")
        {
            
        }
        
    }
}
