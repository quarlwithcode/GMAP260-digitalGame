using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {


	public PlayerController pControl;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Ground"){
			pControl.isGrounded = true;
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if(other.gameObject.tag == "Ground"){
			pControl.isGrounded = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.tag == "Ground"){
			pControl.isGrounded = false;
		}
	}
}
