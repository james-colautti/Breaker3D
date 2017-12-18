using UnityEngine;
using System.Collections;

public class TrigSphere : MonoBehaviour {
	
	GameObject stabilizer;
	// Use this for initialization
	void Start ()
	{
		stabilizer = GameObject.Find("Stabilizer");
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		//transform.RotateAround(new Vector3(0, 0, 0) , transform.right, 20 * Input.GetAxis("Horizontal") * Time.deltaTime);
		//transform.RotateAround(new Vector3(0, transform.position.y, 0), transform.up, 20 * Input.GetAxis("Vertical") * Time.deltaTime);
		
		transform.RotateAround(Vector3.zero, transform.right * -1, 20 * Input.GetAxis("Vertical") * Time.deltaTime);
		stabilizer.transform.position = transform.position;
		stabilizer.transform.RotateAround(Vector3.zero, transform.up, 20 * Input.GetAxis("Horizontal") * Time.deltaTime);
		transform.position = stabilizer.transform.position;
		transform.LookAt(transform.position * 2);// Rotate(Vector3.up, 20 * Input.GetAxis("Horizontal"));
		
	}
}
