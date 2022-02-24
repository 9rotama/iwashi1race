using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleButtonScript : MonoBehaviour
{
    [SerializeField] Sprite[] image;

    public void OnClick()
    {
        GetComponent<Image>().sprite = image[2];

        if (gameObject.name == "StartButton")
        {
            Debug.Log("StartButton");
        }
        else if (gameObject.name == "SkinButton")
        {
            Debug.Log("SkinButton");
        }
        else if (gameObject.name == "RuleButton")
        {
            Debug.Log("RuleButton");
        }
        else if (gameObject.name == "SettingButton")
        {
            Debug.Log("SettingButton");
        }

		var audioSource = GetComponent<AudioSource>();
		audioSource.Play();

        Invoke("ChangeScene",0.5f);
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
        if (gameObject.name == "StartButton")
        {
            var bgm = GameObject.FindGameObjectWithTag("BGM");
			Destroy(bgm);

			SceneManager.LoadScene("Meadow");
        }
        else if (gameObject.name == "SkinButton")
        {
            
        }
        else if (gameObject.name == "RuleButton")
        {
            SceneManager.LoadScene("Rule");
        }
        else if (gameObject.name == "SettingButton")
        {
            
        }
    }
}
