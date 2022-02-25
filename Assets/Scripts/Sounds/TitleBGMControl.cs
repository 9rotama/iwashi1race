using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBGMControl : MonoBehaviour
{
	void Awake() {
		int numMusicPlayers = GameObject.FindGameObjectsWithTag("BGM").Length;
   	 	if (numMusicPlayers > 1)
   		{
  	 		Destroy(gameObject);
    	}
    	else
    	{
     		DontDestroyOnLoad(gameObject);
    	}
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
