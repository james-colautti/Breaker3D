using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
	
	private HardPhysics physics;
	
	void Start ()
	{
		
		physics = (HardPhysics)FindObjectOfType(typeof(HardPhysics));
		
	}
	
	void Update () {
	
	}
	
}
