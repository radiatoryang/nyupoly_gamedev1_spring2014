using UnityEngine;
using System.Collections;

public class HelloWorld : MonoBehaviour {

	// variables declared outside of Start() or Update() persist across frames
	// if it doesn't say "public", then the variable is assumed to be private
	string currentRoom = "Lobby";

	// Use this for initialization
	void Start () {
		// Debug.Log outputs to Console tab in Unity
		Debug.Log ( "Hello World!" );
	}
	
	// Update is called once per frame
	void Update () {
		// a "buffer" is a temporary place where we assemble data before displaying it, e.g. a graphics buffer
		string textBuffer = "TEXT ADVENTURE: You are in the " + currentRoom;

		if ( currentRoom == "Lobby" ) 
		{
			// remember, "\n" means "new line"
			textBuffer += "\nThe NYU Poly security guard stares at you.";
			textBuffer += "\nPress [W] to go to the elevators.";

			if ( Input.GetKeyDown (KeyCode.W) )
			{
				currentRoom = "Elevators";
			}
		} 
		else if ( currentRoom == "Elevators" )
		{
			textBuffer += "\nThere are SO MANY ELEVATORS. A safe monkey winks at you.";
		}

		// overwrite contents of "text" variable on the TextMesh component with contents of textBuffer variable
		GetComponent<TextMesh>().text = textBuffer;
	}
}
