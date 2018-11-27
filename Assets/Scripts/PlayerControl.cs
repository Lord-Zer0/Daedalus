using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	private Rigidbody rb;

	private bool[] m_keychain;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Key")) {
			// When a key is reached, determine which one it is by the type
			other.gameObject.SetActive(false);
			
		} else if (other.gameObject.CompareTag("Gate Trigger")) {


		}else if (other.gameObject.CompareTag("Goal")) {

		}
	}
}
