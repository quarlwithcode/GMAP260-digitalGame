using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	public GameObject player;

	private PlayerController pControl;

	private GameObject[] pauseObjects, finishObjects;

	private bool onPlayLevel;
	// Use this for initialization
	void Start () {
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		finishObjects = GameObject.FindGameObjectsWithTag("ShowOnFinish");

		if(Application.loadedLevelName.Substring(0,5) == "Level"){
			onPlayLevel = true;
		} else {
			onPlayLevel = false;
		}

		if(onPlayLevel)
			pControl = player.GetComponent<PlayerController>();

		hidePaused();
		hideFinished();
	}
	
	// Update is called once per frame
	void Update () {

		
		if(onPlayLevel){
			//uses the p button to pause and unpause the game
			if(Input.GetKeyDown(KeyCode.P) && pControl.dead)
			{
				pauseControl();
			}
		}
	}
	
	
	//Reloads the Level
	public void Reload(){
		Application.LoadLevel(Application.loadedLevel);
	}
	
	//controls the pausing of the scene
	public void pauseControl(){
		if(Time.timeScale == 1)
		{
			Time.timeScale = 0;
			showPaused();
		} else if (Time.timeScale == 0){
			Time.timeScale = 1;
			hidePaused();
		}
	}
	
	//shows objects with ShowOnPause tag
	public void showPaused(){
		foreach(GameObject g in pauseObjects){
			g.SetActive(true);
		}
	}
	
	//hides objects with ShowOnPause tag
	public void hidePaused(){
		foreach(GameObject g in pauseObjects){
			g.SetActive(false);
		}
	}
	
	//shows objects with ShowOnFinish tag
	public void showFinished(){
		foreach(GameObject g in finishObjects){
			g.SetActive(true);
		}
	}
	
	//hides objects with ShowOnFinish tag
	public void hideFinished(){
		foreach(GameObject g in finishObjects){
			g.SetActive(false);
		}
	}
	
	//loads inputted level
	public void LoadLevel(string level){
		Application.LoadLevel(level);
	}
}
