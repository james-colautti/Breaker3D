using UnityEngine;
using System.Collections;

public class QuickGenerate : MonoBehaviour
{

	void Start ()
	{
		
	}
	
	void Update ()
	{
	
	}
	
	void OnMouseEnter()
	{
		
		GetComponent<Renderer>().material.color = Color.blue;
		
	}
	
	void OnMouseExit()
	{
		
		GetComponent<Renderer>().material.color = Color.white;
		
	}
	
	void OnMouseUp()
	{
		
		Application.LoadLevel ("Level Random");
		
	}
	
}