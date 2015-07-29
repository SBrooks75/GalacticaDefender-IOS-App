using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {


	public float jumpHeight;

	public float moveSpeed;

	private float moveVelocity;

	public GameObject projectile;

	public float projectileSpeed;





	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (Input.GetKeyDown (KeyCode.Space)) {

			Firing();
		
		}

			
		#if UNITY_STANDALONE || UNITY_WEBPLAYER
		Move (Input.GetAxisRaw ("Horizontal"));
		#endif
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);


	}



	public void Move(float moveInput){

		moveVelocity = (moveSpeed *Time.deltaTime) * moveInput;

	
	}

	public void Firing(){
		GameObject beam = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);

	
	}



}