using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	public static int score = 0;
	public static int highScore;
	private Text myText;

	void Start(){
		myText = GetComponent<Text> ();
		highScore = PlayerPrefs.GetInt ("highScore", 0);

	}


	public void Score(int points){
		score += points;
		myText.text = score.ToString ();

		if (score > highScore) {
			highScore = score;
			PlayerPrefs.SetInt ("highScore", highScore);
			
			
		}
	}

	public static void Reset(){
		score = 0;

	}


}
