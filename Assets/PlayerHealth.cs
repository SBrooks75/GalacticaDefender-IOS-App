using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public int healthBar = 3;

	private Text myText;
	// Use this for initialization
	void Start () {

		myText = GetComponent<Text> ();
		myText.text = healthBar.ToString ();

	
	}

	public void HealthBar(){
		
		healthBar -= 1;
		myText.text = healthBar.ToString();
	}

	public void ResetHelthBar(){
		healthBar = 3;
	
	}


	
}
