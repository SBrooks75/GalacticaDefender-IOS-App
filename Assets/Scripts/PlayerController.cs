using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 15.0f;
	public GameObject projectile;
	public float padding = 1f;
	public float projectileSpeed = 10;
	public float firingRate = .02f;
	public float health = 300f;
	public AudioClip firesound;

	public int superSpeed = 15;

	public float moveVelocity;

	public float firebullet = 0f;
	
	float xmin;
	float xmax;

	private PlayerHealth playerHealth;


	public void Die(){
	
		LevelManager man = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		man.LoadLevel("Win Screen 1");
		Destroy(gameObject);
	}
	
	void Start(){
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;



	}
	
	void Fire(){
		Vector3 offset = new Vector3 (0,1,0);
		GameObject beam = Instantiate(projectile, transform.position+offset, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
		AudioSource.PlayClipAtPoint (firesound, transform.position);
	
	}


	public void Move(){
		if(Input.GetKey(KeyCode.LeftArrow)){
			transform.position += Vector3.left * speed * Time.deltaTime;
		}else if (Input.GetKey(KeyCode.RightArrow)){
			transform.position += Vector3.right * speed * Time.deltaTime; 
		}
		
		// restrict the player to the gamespace
		float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}




	
	void Update () {

		#if UNITY_STANDALONE || UNITY_WEBPLAYER
		Firing ();
		Move (Input.GetAxisRaw("Horizontal");
		#endif
	
		if (moveVelocity < 0) {
			transform.position -= Vector3.right * superSpeed * Time.deltaTime;
			float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
			transform.position = new Vector3(newX, transform.position.y, transform.position.z);
		} else if (moveVelocity > 0) {
			transform.position += Vector3.right * superSpeed * Time.deltaTime;
			float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
			transform.position = new Vector3(newX, transform.position.y, transform.position.z);

		}

		if(firebullet == 1){
			InvokeRepeating ("Fire", 9f, .2f);

		}else if(firebullet == 0){
			CancelInvoke("Fire");
		}







	}

	void OnTriggerEnter2D(Collider2D collider){
		Projectile missile = collider.gameObject.GetComponent<Projectile> ();
		if (missile) {
			health -= missile.GetDamage ();
			missile.Hit ();
				playerHealth = GameObject.Find ("HealthBar").GetComponent<PlayerHealth>();
				playerHealth.HealthBar();
		}
			if (health <= 0){
				Destroy(gameObject);
				Die ();
			}
		
		
	}

	public void MoveMore(float moveInput){


		moveVelocity = speed * moveInput;
	}



	public void FireMore(float fireInput){

			firebullet = fireInput;
		
		}




	
	
	
}
