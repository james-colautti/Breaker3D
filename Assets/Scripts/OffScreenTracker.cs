using UnityEngine;
using System.Collections;

public class OffScreenTracker : MonoBehaviour
{
	
	Transform left, right, top, bottom;
	GameObject ball;
	
	// Use this for initialization
	void Start ()
	{
		
		foreach (Transform child in gameObject.transform){
		//for (int i = 0, i < transform.GetChildCount, i++)
		//{
			
        	if (child.name == "GUIArrow Left") left = child;
			else if (child.name == "GUIArrow Right") right = child;
			else if (child.name == "GUIArrow Top") top = child;
			else if (child.name == "GUIArrow Bottom") bottom = child;
			ball = GameObject.FindGameObjectWithTag("Weapon");
			
		}

    }
	
	// Update is called once per frame
	void Update ()
	{
		
		left.GetComponent<GUITexture>().enabled = false;
		right.GetComponent<GUITexture>().enabled = false;
		top.GetComponent<GUITexture>().enabled = false;
		bottom.GetComponent<GUITexture>().enabled = false;
		
	}
	
}
