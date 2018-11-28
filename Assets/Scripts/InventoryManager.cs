using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

	public GameObject inventoryUI;
	public List<GameObject> keys;
	public List<GameObject> icons;

	void Start() {
		for (int i = 0; i < keys.Count; i++)
		{
			keys[i].SetActive(true);
			icons[i].SetActive(false);
		}
	}

	void Update() {
		for (int i = 0; i < keys.Count; i++)
		{
			if (!keys[i].activeSelf) {
				icons[i].SetActive(true);
			}
		}
	}

	public bool hasKeyWithIndex(int keyIndex) {
		if (keyIndex <= keys.Count) {
			return !keys[keyIndex].activeSelf;
		}
		return false;
	}
}
