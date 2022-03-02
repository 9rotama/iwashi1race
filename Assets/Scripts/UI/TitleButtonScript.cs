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

        switch (gameObject.name)
        {
            case "StartButton":
                Debug.Log("StartButton");
                break;
            case "SkinButton":
                Debug.Log("SkinButton");
                break;
            case "RuleButton":
                Debug.Log("RuleButton");
                break;
            case "SettingButton":
                Debug.Log("SettingButton");
                break;
        }

		var audioSource = GetComponent<AudioSource>();
		audioSource.Play();

        Invoke(nameof(ChangeScene),0.5f);
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
        switch (gameObject.name)
        {
            case "StartButton":
            {
                SceneManager.LoadScene("Stage");
                break;
            }
            case "SkinButton":
                SceneManager.LoadScene("Skin");
                break;
            case "RuleButton":
                SceneManager.LoadScene("Rule");
                break;
            case "SettingButton":
                break;
        }
    }
}
