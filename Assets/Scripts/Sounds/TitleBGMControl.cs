using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBGMControl : MonoBehaviour
{
	private void Awake() {
		var numMusicPlayers = GameObject.FindGameObjectsWithTag("BGM").Length;
   	 	if (numMusicPlayers > 1)
   		{
  	 		Destroy(gameObject);
    	}
    	else
    	{
     		DontDestroyOnLoad(gameObject);
    	}
	}
}
