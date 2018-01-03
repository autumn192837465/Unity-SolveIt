using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLevel : MonoBehaviour {

    public string sceneName;
    public GameObject check;
	// Use this for initialization
	void Start () {
		if(PlayerPrefs.GetInt(sceneName, 0) == 1)
        {
            
            check.SetActive(true);

        }
        else
        {
            check.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
