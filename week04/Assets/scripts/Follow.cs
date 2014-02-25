using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	// public variables are exposed in the inspector
	public Transform sphereZombie; 
	public float speed = 0.1f; // will get overridden by value in inspector
	float stoppingDistance = 5f; // private variable, editable only in the code

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// calculate vector from cube to sphere
		if ( Vector3.Distance (sphereZombie.position, GetComponent<Transform>().position) > stoppingDistance) 
		{
			transform.position += speed * Vector3.Normalize(sphereZombie.position - transform.position) * Time.deltaTime;
		}
	}
}
