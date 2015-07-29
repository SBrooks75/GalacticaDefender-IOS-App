using UnityEngine;
using System.Collections;

public class TouchControls : MonoBehaviour {

	public PlayerController thePlayer;

	// Use this for initialization
	void Start () {

		thePlayer = FindObjectOfType<PlayerController> ();
	
	}

	public void LeftArrow(){
		thePlayer.MoveMore (-1f);

	}

	public void RightArrow(){
		thePlayer.MoveMore (1f);
		
	}

	public void UnpresedArrow(){
		thePlayer.MoveMore (0f);
	
	}


	public void Fire(){
		thePlayer.FireMore (1f);
		thePlayer.InvokeRepeating ("Fire", .0001f, .3f);
	}

	public void UnpressedFire(){
		thePlayer.FireMore(0f);
	}


	

}
