using UnityEngine;
using System.Collections;

public class GroundSide : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Player" && other.transform.position.y - .5F < transform.position.y + .5F){
			other.gameObject.GetComponent<PlayerController>().dead = true;
		}
	}
}
