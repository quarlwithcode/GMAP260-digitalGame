﻿using UnityEngine;
using System.Collections;

public class SideCheck : MonoBehaviour {

	public PlayerController pControl;
	private Transform player;
	// Use this for initialization
	void Start () {
		player = transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Ground" && !pControl.isGrounded && player.position.y -.4F < other.transform.position.y +.4F){
			pControl.dead = true;
		}
	}
}
