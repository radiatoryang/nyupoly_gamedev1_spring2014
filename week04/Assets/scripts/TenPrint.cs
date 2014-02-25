using UnityEngine;
using System.Collections;

public class TenPrint : MonoBehaviour {

	int counter = 0;
	
	// Update is called once per frame
	void Update () {
	
		// CORE OF TENPRINT:
		// 1) generate a random number ( Random.Range() )
		int randomNumber = Random.Range (0, 10);

		// 2) if that random number is ___, do X (print a "/")
		// 3) else if that random number is ___, do Y (print a "\\")
		if ( randomNumber > 5 )
		{
			GetComponent<TextMesh>().text += "/";
		}
		else 
		{
			GetComponent<TextMesh>().text += "\\";
		}

		// have we printed enough of these characters? if so, start a new line
		counter += 1;

		if ( counter > 20) 
		{
			GetComponent<TextMesh>().text += "\n";
			counter = 0;
		}
	}
}
