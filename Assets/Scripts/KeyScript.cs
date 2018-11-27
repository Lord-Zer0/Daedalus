using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour {
	public float speed = 10f;

	private Material m_material;

	private string m_keyID;

	void Start () {
		// Fetch the material from the Renderer of the GameObject
		m_material = GetComponent<Renderer>().material;
		m_keyID = "Key:" + m_material.name;
		print(m_keyID);
	}

	void Update () {
		// Simple movement to help show the importance of the keys
		transform.Rotate(Vector3.up, speed * Time.deltaTime);
	}

}
