using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

	public GameObject player;

	private Rigidbody2D rig2D;
	private PlayerController pControl;
	private float speedX;

	// Use this for initialization
	void Start () {
		rig2D = GetComponent<Rigidbody2D>();

		pControl = player.GetComponent<PlayerController>();

		speedX = pControl.speed;


		startPush(speedX);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if(pControl.dead){
			rig2D.velocity = Vector2.zero;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Player" && !pControl.dead){
			rig2D.velocity = Vector2.zero;
			pControl.dead = true;
		}
	}

	private void startPush(float speed){
		rig2D.AddForce(Vector2.right*speed, ForceMode2D.Force);
	}
}
