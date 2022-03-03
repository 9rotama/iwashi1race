using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageButtonScript : MonoBehaviour
{
    [SerializeField] Sprite[] image;

    public void OnClick()
    {
        GetComponent<Image>().sprite = image[2];

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
        var bgm = GameObject.FindGameObjectWithTag("BGM");
        Destroy(bgm);
        switch (gameObject.name)
        {
            case "Meadow":
            {
                SceneManager.LoadScene("Meadow");
                break;
            }
            case "Night":
                SceneManager.LoadScene("Night");
                break;
            case "Desert":
                SceneManager.LoadScene("Desert");
                break;
            case "SettingButton":
                break;
        }
    }
}
