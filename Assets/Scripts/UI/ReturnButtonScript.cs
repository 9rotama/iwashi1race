using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnButtonScript : MonoBehaviour
{
    [SerializeField] private Sprite[] image;

    [SerializeField] private GameObject returnSe;

    public void OnClick()
    {
        GetComponent<Image>().sprite = image[2];
        var sound = Instantiate(returnSe);
        var endTime = sound.GetComponent<AudioSource>().clip.length;
        Destroy(sound, endTime);
        switch (gameObject.name)
        {
            case "ReturnButton":
                Invoke(nameof(ChangeScene), 0.5f);
                break;
            case "BackButton":
            case "NextButton":
                Invoke(nameof(ChangePage), 0.5f);
                break;
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
