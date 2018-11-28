using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour {

	bool rotate;

	public float speed = 15f;

	void Start() {
		rotate = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (rotate) {
			transform.Rotate(Vector3.up, speed * Time.deltaTime);
		}
	}
}
