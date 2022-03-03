using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinSetInvoker : MonoBehaviour
{
    private GameObject _skinValueHolder;
    private PlayerSkinValue _playerSkinValue;
    
    // Start is called before the first frame update
    private void Start()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Skin":
                _skinValueHolder = GameObject.FindGameObjectWithTag("SkinValueHolder");
                _playerSkinValue = _skinValueHolder.GetComponent<PlayerSkinValue>();
                
                _playerSkinValue.SetValueToSlider();
                _playerSkinValue.SetValueToPlayer();
                break;
            case "Title":
                break;
            case "Rule":
                break;
            case "Setting":
                break;
            case "StageSelect":
                break;
            case "Meadow":
                _skinValueHolder = GameObject.FindGameObjectWithTag("SkinValueHolder");
                _playerSkinValue = _skinValueHolder.GetComponent<PlayerSkinValue>();
                
                _playerSkinValue.SetValueToPlayer();
                break;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
