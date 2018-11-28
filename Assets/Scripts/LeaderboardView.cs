using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardView : MonoBehaviour {
	public Text rankView;
	public Text nameView;
	public Text scoreView;

	void Start() {
		VisualizeRanks();
	}

	void Update() {
		VisualizeRanks();
	}

	public void VisualizeRanks() {
		ClearDisplay();

		List<RankingSystem.Rank> leaderboard = RankingSystem.Instance.GetLeaderboard();

		for (int i = 1; i <= leaderboard.Count; i++) {
			rankView.text += i + "\r\n";
			nameView.text += PlayerPrefs.GetString("Rank" + i + "name") + "\r\n";
			scoreView.text += string.Format("{0:F1}", PlayerPrefs.GetFloat("Rank" + i + "score")) + "\r\n";
		}	
	}

	public void ClearDisplay() {
		rankView.text = "";
		nameView.text = "";
		scoreView.text = "";
	}
}
