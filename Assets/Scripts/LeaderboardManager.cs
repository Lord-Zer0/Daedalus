using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LeaderboardManager : MonoBehaviour {
	private static LeaderboardManager m_instance;
	private const int LeaderboardLength = 10;

	public class Scores {
		public float score;
		public string name;
	}

	public static LeaderboardManager _instance {
		get {
			if (m_instance == null) {
				m_instance = new GameObject("LeaderboardManager").AddComponent<LeaderboardManager>();
			}
			return m_instance;
		}
	}

	void Awake() {
		if (m_instance == null) {
			m_instance = this;
		} else if (m_instance != this) {
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}

	public void SaveHighScore(string name, float score) {
		List<Scores> HighScores = new List<Scores>();

		Scores temp = new Scores();

		int i = 1;
		while (i <= LeaderboardLength && PlayerPrefs.HasKey("HighScore" + i + "score")) {
            
            temp.score = PlayerPrefs.GetInt("HighScore" + i + "score");
            temp.name = PlayerPrefs.GetString("HighScore" + i + "name");
            HighScores.Add(temp);
            i++;
        }

		if (HighScores.Count == 0) {
			temp.name = name;
			temp.score = score;
			HighScores.Add(temp);
		} else {
			for (i = 1; i <= HighScores.Count && i <= LeaderboardLength; i++) {
				if (score > HighScores[i - 1].score) {
					// If a score is higher than an existing score
					temp.name = name;
					temp.score = score;
					HighScores.Insert(i - 1, temp);
					break;
				}
				if (i == HighScores.Count && i < LeaderboardLength) {
					// If there is an open spot on the board
					temp.name = name;
					temp.score = score;
					HighScores.Add(temp);
					break;
				}
			}
		}

		i = 1;
		while( i <= LeaderboardLength && i <= HighScores.Count) {
			// Store data in player prefs for persistent scoring
            PlayerPrefs.SetString ("HighScore" + i + "name", HighScores [i - 1].name);
            PlayerPrefs.SetFloat ("HighScore" + i + "score", HighScores [i - 1].score);
            i++;
        }
	}

	public List<Scores> GetLeaderboard() {
		List<Scores> HighScores = new List<Scores>();

		int i = 1;
		while (i <= LeaderboardLength && PlayerPrefs.HasKey("HighScore" + i + "score")) {
            Scores temp = new Scores ();
            temp.score = PlayerPrefs.GetInt ("HighScore" + i + "score");
            temp.name = PlayerPrefs.GetString ("HighScore" + i + "name");
            HighScores.Add (temp);
            i++;
        }
 
        return HighScores;
	}

	public void ClearLeaderboard() {
		List<Scores> HighScores = GetLeaderboard();

		for(int i = 1; i <= HighScores.Count; i++) {
            PlayerPrefs.DeleteKey("HighScore" + i + "name");
            PlayerPrefs.DeleteKey("HighScore" + i + "score");
        }
	}

	void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
}
