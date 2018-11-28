using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeController : MonoBehaviour {
	private float timer;
	private double seconds; 
	public GameObject timeDisplayUI;
	public Text playerName;
	public GameObject button;
	public static bool victoryStatus;
	public GameObject victoryScreenUI;
	
	void Start() {
		timer = 0.0f;
		seconds = 0.0;
		victoryStatus = false;
		victoryScreenUI.SetActive(false);
		Time.timeScale = 1f;
		//leaderboard = GameObject.FindWithTag("LeaderboardUI").GetComponent<RankingSystem>();
	}

	void Update() {
		timer += Time.deltaTime;
		//print(Time.deltaTime);
		seconds = System.Math.Round(timer, 1);
		//print(seconds);
		timeDisplayUI.GetComponent<Text>().text = string.Format("{0:F1}", seconds);

		if (victoryStatus) {
			EndGame();
		}
	}

	public float GetTimer() {
		return timer;
	}

	public void Submit() {
		if (playerName.text != null) {
			RankingSystem.Instance.SaveHighScore(playerName.text, (float)seconds);
		} else {
			print("Player Name cannot be empty");
		}
	}

	public void EndGame() {
		victoryScreenUI.SetActive(true);
		Time.timeScale = 0f;
	}
}
