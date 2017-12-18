using UnityEngine;
using System.Collections;

public class TrailDestruct : MonoBehaviour
{

	void Start () 
	{
		
		transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
		Destroy(gameObject, 2);
		
	}
	
	void Update () 
	{
		
		if (transform.localScale.x >= 0)
			transform.localScale = transform.localScale - new Vector3(0.1f, 0.1f, 0.1f) * Time.deltaTime;
		
	}
	
}
