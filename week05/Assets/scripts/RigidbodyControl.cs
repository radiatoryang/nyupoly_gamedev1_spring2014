using UnityEngine;
using System.Collections;

public class RigidbodyControl : MonoBehaviour {

	// If you use code to interface with physics, usually you will put it in FixedUpdate
	// because the physics engine runs at a different framerate than graphics / input / etc.
	// (like, if you kept calling AddForce in Update(), that might run 100 times before FixedUpdate() finally runs)

	// FixedUpdate is called every ___ seconds, as specified in Edit >> Project Settings >> Time >> Fixed Timestep
	void FixedUpdate () {

		// MOVEMENT
		if ( Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow) ) 
		{
			GetComponent<Rigidbody>().AddForce( GetComponent<Transform>().forward * 2f, ForceMode.VelocityChange );
		} 
		else 
		{
			GetComponent<Rigidbody>().velocity = Physics.gravity;
		}

		// TURNING
		if ( Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow) ) 
		{
			transform.Rotate ( new Vector3( 0f, -5f, 0f) );
		}
		if ( Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow) ) 
		{
			transform.Rotate ( new Vector3( 0f, 5f, 0f) );
		}

		// new problem: how do we limit jumping to happening ONLY when you're on the ground?
		// answer: Raycasts, which we'll cover on Thursday.
		Ray ray = new Ray( GetComponent<Transform>().position, -Vector3.up );
		
		// to know where and WHAT the raycast hit, we have store that impact info
		RaycastHit rayHit = new RaycastHit(); // blank container for info
		
		if ( Physics.Raycast (ray, out rayHit, 1.1f) ) 
		{
			// JUMPING, but only if raycast returns true
			if ( Input.GetKey (KeyCode.Space) ) 
			{
				GetComponent<Rigidbody>().AddForce ( new Vector3(0f, 5000f, 0f), ForceMode.Acceleration );
				Debug.Log ( rayHit.point ); // point, in worldspace, where the raycast hit
				// Destroy ( rayHit.collider.gameObject );
				rayHit.collider.renderer.material.color = Color.red;
			}
			
		}
		

	}

}
