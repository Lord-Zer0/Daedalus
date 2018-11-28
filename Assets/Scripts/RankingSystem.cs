using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingSystem : MonoBehaviour {

	private static RankingSystem instance = null;
	public static RankingSystem Instance { get { return instance; } }
	static int maxRank = 10;
	public class Rank {
		public float score;
		public string name;
	}

	void Awake() {
		// if instance is not yet set, set it and make it persistent between scenes
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else {
            // if instance is already set and this is not the same object, destroy it
            if (this != instance) { Destroy(gameObject); }
        }
	}

	public void TestLeaderboard() {
		SaveHighScore("CON", 219.4f);
	}

	public void SaveHighScore(string name, float score) {
		List<Rank> rankings = new List<Rank>();

		

		int i = 1;
		while (i <= maxRank && PlayerPrefs.HasKey("Rank" + i + "score")) {
			Rank temp = new Rank();
            temp.score = PlayerPrefs.GetFloat("Rank" + i + "score");
            temp.name = PlayerPrefs.GetString("Rank" + i + "name");
            rankings.Add(temp);
            i++;
        }
		if (rankings.Count == 0) {
			Rank _temp = new Rank();
			_temp.name = name;
			_temp.score = score;
			rankings.Add(_temp);
		} else {
			for (i = 1; i <= rankings.Count && i <= maxRank; i++) {
				if (score < rankings[i - 1].score) {
					// If a score is higher than an existing score
					Rank _temp = new Rank();
					_temp.name = name;
					_temp.score = score;
					rankings.Insert(i - 1, _temp);
					break;
				}
				if (i == rankings.Count && i < maxRank) {
					// If there is an open spot on the board
					Rank _temp = new Rank();
					_temp.name = name;
					_temp.score = score;
					rankings.Add(_temp);
					break;
				}
			}
		}

		i = 1;
		while( i <= maxRank && i <= rankings.Count) {
			// Store data in player prefs for persistent scoring
            PlayerPrefs.SetString ("Rank" + i + "name", rankings [i - 1].name);
            PlayerPrefs.SetFloat ("Rank" + i + "score", rankings [i - 1].score);
            i++;
        }
	}

	public List<Rank> GetLeaderboard() {
		List<Rank> leaderboard = new List<Rank>();

		int i = 1;
		while (i <= maxRank && PlayerPrefs.HasKey("Rank" + i + "score")) {
            Rank temp = new Rank();
            temp.score = PlayerPrefs.GetFloat ("Rank" + i + "score");
            temp.name = PlayerPrefs.GetString ("Rank" + i + "name");
            leaderboard.Add (temp);
            i++;
        }
 
        return leaderboard;
	}

	public void ClearLeaderboard() {
		List<Rank> leaderboard = instance.GetLeaderboard();
		for(int i = 1; i <= leaderboard.Count; i++) {
            PlayerPrefs.DeleteKey("Rank" + i + "name");
            PlayerPrefs.DeleteKey("Rank" + i + "score");
        }
	}

	void OnApplicationQuit() {
        PlayerPrefs.Save();
    }
	
}
