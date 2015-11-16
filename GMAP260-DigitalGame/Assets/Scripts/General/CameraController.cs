using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private PlayerController pControl;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		pControl = player.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if(!pControl.dead)
			transform.position = new Vector3(player.transform.position.x+2, player.transform.position.y+1.5F, transform.position.z);
	}
}
