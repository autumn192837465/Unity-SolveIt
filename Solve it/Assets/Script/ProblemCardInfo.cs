using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProblemCardInfo : MonoBehaviour {

    public bool CanPlace;
    public int[] Ans;
    public bool correct;


	// Use this for initialization
	void Start () {
        correct = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void CheckAns(int playerAns)
    {
        foreach(int a in Ans)
        {
            if (a == playerAns)
                correct = true;
        }
    }
}
