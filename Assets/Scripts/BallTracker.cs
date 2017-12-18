using UnityEngine;
using System.Collections;

public class BallTracker : MonoBehaviour
{
	
	GameObject ball;
	Vector3 prevPos;
	Quaternion rot;
	Ball bscript;
	bool active;
	ArrayList weapons;
	
	// Use this for initialization
	void Start ()
	{
		
		active = false;
		GetComponent<Camera>().enabled = false;
		weapons = new ArrayList();
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (GameObject.FindGameObjectWithTag("Weapon") != null && (Ball)FindObjectOfType(typeof(Ball)) != null)
		{
			StopAllCoroutines();
			GetComponent<Camera>().enabled = true;
		}
		else StartCoroutine(disableCam());//camera.enabled = false;
		if (GetComponent<Camera>().enabled == true)
		{
			GameObject[] temp = GameObject.FindGameObjectsWithTag("Weapon");
			/*foreach (GameObject x in temp)
			{
				//weapons.Add(x);
			}*/
			//ball = GameObject.FindGameObjectWithTag("Weapon");
			if (temp[0] != null) ball = (GameObject)temp[0];
			bscript = (Ball)ball.transform.GetComponent(typeof(Ball));
			//if (Mathf.Abs((ball.transform.position - transform.position).magnitude) > 2)
			//{
				transform.position = ball.transform.position - bscript.getFinDir().normalized * 2 + ball.transform.up;	
			//}
			if (bscript.getFinDir() != Vector3.zero)
				transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(bscript.getFinDir()), bscript.getFinDir().magnitude * 10);
		}
		//if (transform.rotation != Quaternion.LookRotation(ball.transform.position))
		//{
		//	transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(ball.transform.position), 5);
		//}
		/*Vector3 pos = ball.transform.position;
		
		if (prevPos != null)
		{
			//print(rot + " " + prevPos + " " + pos + " " + (pos - prevPos));
			if (pos - prevPos != new Vector3(0, 0, 0))
				rot = Quaternion.LookRotation(pos - prevPos);
			transform.position = prevPos - (pos - prevPos) * 20;
			transform.rotation = rot;
		}
		prevPos = pos;*/
		
	}
	
	void SetActive()
	{
		
		active = true;
		
	}
	
	void SetInactive()
	{
		
		active = false;
		
	}
	
	IEnumerator disableCam()
	{
		
		StartCoroutine(backupCam());
		yield return new WaitForSeconds(1);
		GetComponent<Camera>().enabled = false;
		
	}
	
	IEnumerator backupCam()
	{
		
		while (GetComponent<Camera>().enabled == true)
		{
			transform.position -= transform.forward * 0.001F;
			yield return new WaitForSeconds(0.01F);	
		}
		
	}
	
	/*public void removeWep(GameObject x)
	{
		
		weapons.Remove(x);
		
	}*/
}
