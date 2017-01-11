using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {
    private Goto avance;

	// Use this for initialization
	void Start () {
        avance = GetComponent<Goto>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Z)) {
            avance.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            avance.enabled = false;
        }
    }
}
