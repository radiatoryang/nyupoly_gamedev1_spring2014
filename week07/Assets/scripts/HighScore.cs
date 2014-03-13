using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour {

	// a STATIC variable lives in memory, in the type itself
	// in Unity, this lets us persist data between new level loads
	public static int score = 0;
	
	// Update is called once per frame
	void Update () {
		// a great game mechanic
		if (Input.GetKeyDown (KeyCode.Space))
			score++;
			
		// a simple restart button
		if (Input.GetKeyDown (KeyCode.R))
			Application.LoadLevel (2);
			
		// display my current score
		GetComponent<TextMesh>().text = score.ToString();
	}
}
