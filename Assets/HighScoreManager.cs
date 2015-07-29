using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour {

	public int highScore;

	// Use this for initialization
	void Start () {
		Text text = GetComponent<Text> ();
		highScore = PlayerPrefs.GetInt ("highScore");
		text.text = highScore.ToString();




	
	}
}