using System.Collections;
using System.Collections.Generic;
using KanKikuchi.AudioManager;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageScreen : MonoBehaviour
{
    [System.Serializable]
    private struct StageSelect
    {
        public string name;
        public Button button;
    }
    
    [SerializeField] private Button returnButton;
    [SerializeField] private StageSelect[] stageSelects;
    
    private static IEnumerator MoveScene(string sceneName)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
    }
    
    
    private void Start()
    {
        returnButton.onClick.AddListener(() =>
        {
            StartCoroutine(MoveScene("Title"));
        });
        foreach (var stageSelect in stageSelects)
        {
            stageSelect.button.onClick.AddListener(() =>
            {
                BGMManager.Instance.Stop();
                StartCoroutine(MoveScene(stageSelect.name));
            });
        }
    }
    
}
