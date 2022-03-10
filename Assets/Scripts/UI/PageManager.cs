using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    [SerializeField] private GameObject[] pages;

    private int _currentPage;
    
    public void NextPage()
    {
        pages[_currentPage].SetActive(false);
        
        _currentPage++;
        if (_currentPage > (pages.Length - 1)) _currentPage = 0;
        
        pages[_currentPage].SetActive(true);
    }

    public void PrevPage() 
    {
        pages[_currentPage].SetActive(false);
        
        _currentPage--;
        if (_currentPage < 0) _currentPage = pages.Length - 1;
        
        pages[_currentPage].SetActive(true);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _currentPage = 0;
        pages[_currentPage].SetActive(true);
        for (int i = 1; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
