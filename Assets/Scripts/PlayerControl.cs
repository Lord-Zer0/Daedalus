using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	//private Rigidbody rb;
	public List<GameObject> gates;
	//public InventoryManager inventory;
	public List<GameObject> keys;
	
	// Use this for initialization
	void Start () {
		//rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Key")) {
			// When a key is reached, determine which one it is by the type
			other.gameObject.SetActive(false);
			
		} else if (other.gameObject.CompareTag("Gate Trigger")) {
			if (other.name.Contains("Red") && !keys[0].activeSelf)
				gates[0].SetActive(false);
			if (other.name.Contains("Green") && !keys[1].activeSelf)
				gates[1].SetActive(false);
			if (other.name.Contains("Blue") && !keys[2].activeSelf)
				gates[2].SetActive(false);
			if (other.name.Contains("Yellow") && !keys[3].activeSelf)
				gates[3].SetActive(false);
			

		} else if (other.gameObject.CompareTag("Finish")) {
			print("goal reached");
			MazeController.victoryStatus = true;
		}
	}
}
