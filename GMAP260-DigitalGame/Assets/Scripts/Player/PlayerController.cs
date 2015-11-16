using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public bool isGrounded;
	public bool dead;

	public float speed;
	
	public float jumpHeight;
	
	private Rigidbody2D rig2D;
	
	// Use this for initialization
	void Start () {
		rig2D = GetComponent<Rigidbody2D>();
		dead = false;

		startPush(speed);


		InvokeRepeating("increaseSpeed", 10F, 10F);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate(){
		if(isGrounded){
			if(Input.GetKey(KeyCode.UpArrow)){
				jump (jumpHeight);
			}
		}


		if(dead){
			died ();
		}
	}

	private void died(){

		GetComponent<Collider2D>().isTrigger = true;
		rig2D.velocity = Vector2.zero;
		rig2D.mass = 2;
		rig2D.gravityScale = 10;
	}

	private void startPush(float speed){
		rig2D.AddForce(Vector2.right*speed, ForceMode2D.Force);
	}

	private void jump(float jumpHeight){
		resetYVelocity();
		rig2D.AddForce(Vector2.up*jumpHeight, ForceMode2D.Impulse);
	}

	private void resetYVelocity(){
		rig2D.velocity = new Vector2(rig2D.velocity.x, 0);
	}

	public void increaseSpeed(){
		Debug.Log ("Faster");
		rig2D.AddForce(Vector2.right*(speed/3F), ForceMode2D.Force);
	}

}
