using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyComponet : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(GetComponent<Animator>(),GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.length);
        Destroy(GetComponent<DestroyComponet>(), GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.length);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
