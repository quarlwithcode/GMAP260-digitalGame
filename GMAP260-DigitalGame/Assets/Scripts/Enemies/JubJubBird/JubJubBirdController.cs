using UnityEngine;
using System.Collections;

public class JubJubBirdController : MonoBehaviour {

	public int activateDistance;
	public float counter;
	public float rSpeedX;
	public float rSpeedY;
	public float lSpeedX;
	public float lSpeedY;
	public float decreaseAmount;

	private GameObject player;
	private Rigidbody2D rig2D;
	private bool subtractSpeed;
	private bool alive;
	private bool playerInDistance;
	private float actualVelocity;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		rig2D = GetComponent<Rigidbody2D>();
		alive = false;
		playerInDistance = false;
		actualVelocity = Mathf.Sqrt((Mathf.Pow(rig2D.velocity.x,2)+Mathf.Pow(rig2D.velocity.y,2)));
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate(){
		actualVelocity = Mathf.Sqrt((Mathf.Pow(rig2D.velocity.x,2)+Mathf.Pow(rig2D.velocity.y,2)));


		distanceCheck(activateDistance);
		lowerPlayerSpeed();
	}

	void OnTriggerStay2D(Collider2D other){
		if(other.gameObject.tag == "Player"){
			subtractSpeed = true;
		}

	}

	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.tag == "Player"){
			subtractSpeed = false;
		}
		
	}




	void distanceCheck(int maxDistance){
		float distance = Mathf.Sqrt(Mathf.Pow(transform.position.x - player.transform.position.x, 2)
		                          + Mathf.Pow(transform.position.y - player.transform.position.y, 2));
		if(distance <= maxDistance){
			playerInDistance = true;
			alive = true;
			move ();
		} else {
			playerInDistance = false;
		}
	}

	void move(){
		if(player.transform.position.x > transform.position.x){
			rig2D.velocity = new Vector2(rSpeedX, rig2D.velocity.y);
		}
		if(player.transform.position.x < transform.position.x){
			rig2D.velocity = new Vector2(-rSpeedX, rig2D.velocity.y);
		}
		if(player.transform.position.y > transform.position.y){
			rig2D.velocity = new Vector2(rig2D.velocity.x, rSpeedY);
		}
		if(player.transform.position.y < transform.position.y){
			rig2D.velocity = new Vector2(rig2D.velocity.x, -rSpeedY);
		}
	}

	void lowerPlayerSpeed(){
		if(subtractSpeed == true){
			player.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-decreaseAmount,0));
			decreaseCounter();
		}
	}

	void checkAlive(){
		if(alive && !playerInDistance){
			Destroy (this.gameObject);
		}
	}

	void decreaseCounter(){
		counter -= Time.deltaTime;
		if(counter <= 0){
			Destroy(this.gameObject);
		}
	}
}
