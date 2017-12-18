using UnityEngine;
using System.Collections;


public class HardPhysics : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Vector3 getReboundVector(Vector3 dirA, Vector3 normal)
	{
		
		Vector3 dirB = dirA - 2 * normal * Vector3.Dot(normal, dirA);
		return dirB;
		
	}
	
}