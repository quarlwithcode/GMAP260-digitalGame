using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextScroll : MonoBehaviour {

	//delays start of scrolling
	public float delayScrollStart = .5F;
	//actual speed of scrolling
	public float scrollSpeed = .5F;
	//text that will be scrolled
	public string scrollingText;
	public float delayLoad;
	//level to be loaded
	public string levelToLoad;


	//placeholder for text component
	private Text text;
	//counter for letters in scrollingText
	private int letter;
	private bool done;
	private float resetDelayLoad;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();			//getting text component
		letter = 1;								//start of substring
		resetDelayLoad = delayLoad;
		scrollingText = scrollingText.Replace("NEWLINE", "\n");				//replaces NEWLINE with an actual new line
		scrollingText = scrollingText.Replace("TAB", "\t");					//replaces TAB with an actual tab

		Invoke("startScrollText", delayScrollStart);						//adds another delay to scrolling
	}

	//starts the scrolling of text after delay
	void startScrollText(){
		InvokeRepeating("scrollText", delayScrollStart, scrollSpeed);		//continuously makes text scroll
	}

	//scrolls the text
	void scrollText(){
		text.text = scrollingText.Substring(0,letter);			//updates the text on screen

		//checks to make sure substrings stay in bounds of text
		if(letter < scrollingText.Length)
			letter++;

		if(letter == scrollingText.Length){
			delayedLoadLevel();
		}
	}

	void delayedLoadLevel(){
		delayLoad -= scrollSpeed;
		if(delayLoad <= 0){
			delayLoad = resetDelayLoad;
			Application.LoadLevel(levelToLoad);
		}
	}


	

}
