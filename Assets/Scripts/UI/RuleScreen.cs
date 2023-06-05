using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class RuleScreen : MonoBehaviour
{
    [SerializeField] private Button returnButton;
    [SerializeField] private GameObject[] pages;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button prevButton;

    private int _currentPage;
    
    private void NextPage()
    {
        pages[_currentPage].SetActive(false);
        
        _currentPage++;
        if (_currentPage > (pages.Length - 1)) _currentPage = 0;
        
        pages[_currentPage].SetActive(true);
    }

    private void PrevPage() 
    {
        pages[_currentPage].SetActive(false);
        
        _currentPage--;
        if (_currentPage < 0) _currentPage = pages.Length - 1;
        
        pages[_currentPage].SetActive(true);
    }
    
    private void ReturnTitle()
    {
        SceneManager.LoadScene("Title");
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        _currentPage = 0;
        pages[_currentPage].SetActive(true);
        for (var i = 1; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
        }

        nextButton.onClick.AddListener(NextPage);
        prevButton.onClick.AddListener(PrevPage);
        
        returnButton.onClick.AddListener(() =>
        {
            Invoke(nameof(ReturnTitle), 0.5f);
        });
    }
}
