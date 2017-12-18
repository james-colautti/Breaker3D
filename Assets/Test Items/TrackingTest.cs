using UnityEngine;
using System.Collections;

public class TrackingTest : MonoBehaviour
{
	
	GameObject ball;
	
	// Use this for initialization
	void Start ()
	{
		
		ball = GameObject.Find("Sphere");
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		//if (transform.rotation != Quaternion.LookRotation(ball.transform.position))
		//{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(ball.transform.position), Time.deltaTime * 1);
		//}
		
	}
}
