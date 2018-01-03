using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ChangeToMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ChangeToHelpScene()
    {
        SceneManager.LoadScene("HelpScene");
    }

    public void ChangeToGameScene(string str)
    {
        SceneManager.LoadScene(str);
    }

    public void ChangeToLevelScene()
    {
        SceneManager.LoadScene("LevelScene");
    }    
}
