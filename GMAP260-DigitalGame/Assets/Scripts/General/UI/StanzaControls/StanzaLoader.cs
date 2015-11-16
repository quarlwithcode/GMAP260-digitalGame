using UnityEngine;
using System.Collections;

public class StanzaLoader : MonoBehaviour {

	public float delayTime = 5;
	public bool done = false;
	
	private float timer;
	
	// Use this for initialization
	void Start () {
		timer = delayTime;
		
		//StartCoroutine("SomeFunction");
	}
	
	// Update is called once per frame
	void Update () {
		
		if(done){
			Application.LoadLevel("MainMenu");
		}
	}
}
