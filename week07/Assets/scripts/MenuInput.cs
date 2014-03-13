using UnityEngine;
using System.Collections;

public class MenuInput : MonoBehaviour {

	public KeyCode keyToPush; // assign in inspector
	public string levelToLoad; // assign in inspector
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (keyToPush)) {
			Application.LoadLevel ( levelToLoad );	
		}
		
		// this is accessing a PUBLIC STATIC variable from HighScore.cs
		Debug.Log (HighScore.score);
	}
}
