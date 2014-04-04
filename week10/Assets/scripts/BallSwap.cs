using UnityEngine;
using System.Collections;

public class BallSwap : MonoBehaviour {

	public Transform ball1, ball2; // assign in Inspector

	// Use this for initialization
	void Start () {
		// DO NOT DO THIS: BallCoroutine ();
		StartCoroutine( BallCoroutine() );
		// StartCoroutine ( "BallCoroutine" );
	}
	
	IEnumerator BallCoroutine () {
		Debug.Log ( "coroutine started" );
		yield return null; // wait one frame, then continue
		Debug.Log ( "one frame elapsed" );
		yield return 0;
		yield return 0;
		Debug.Log ( "two frames elapsed" );
		yield return new WaitForSeconds(2.5f); // pause for 2.5 sec.
		Debug.Log ( "2.5 seconds elapsed" );
		
		while (true) {
			float time = 0f;
			Vector3 originalBall1Pos = ball1.position;
			Vector3 originalBall2Pos = ball2.position;
			bool didWePlayTheSoundAlready = false;
			while ( time < 1f ) {
				time += Time.deltaTime; // increment time variable
				ball1.position = Vector3.Lerp (originalBall1Pos, originalBall2Pos, time );
				ball2.position = Vector3.Lerp (originalBall2Pos, originalBall1Pos, time );
				if ( time >= 0.49f && time <= 0.51f && didWePlayTheSoundAlready == false) {
					audio.Play ();
					StartCoroutine ( ScreenShake() );
					didWePlayTheSoundAlready = true;	
				}
				yield return 0; // wait a frame
			}
		}
	}
	
	IEnumerator ScreenShake () {
		float time = 0.25f;
		Vector3 originalPosition = transform.position;
		while ( time > 0f ) {
			time -= Time.deltaTime;
			transform.position = originalPosition +
								 transform.up * Mathf.Sin (Time.time * 100f) +
								 transform.right * Mathf.Sin ( Time.time * 113f) ;
			yield return 0; // wait a frame
		}
		transform.position = originalPosition;
	}
	
	
	
	
}





