using UnityEngine;
using System.Collections;

public class CollisionTest : MonoBehaviour
{
	
	Vector3 moveDir;

	// Use this for initialization
	void Start ()
	{
		
		float test = 3.232971E-05F;
		print(Mathf.Round(test));
		moveDir = toVector3(30, 0);
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if(Input.GetButton("Jump"))
		{
			transform.position += moveDir * 25 * Time.deltaTime;
		}
		
	}
	
	void OnCollisionEnter (Collision collision)
	{
		
		//Physics.IgnoreCollision(gameObject.collider, collision.collider);
		foreach (ContactPoint contact in collision.contacts)
		{
			
			print("moveDir Start: " + moveDir);
			print("    " + Vector3.Angle(moveDir, contact.normal));
			moveDir = moveDir - 2 * contact.normal * Vector3.Dot(contact.normal, moveDir);
			print("    moveDir Final: " + moveDir);
			
			//print("moveDir Start: " + moveDir);                                                        //Debug
			//float curAngleZ = toAngleZ(moveDir * -1);
			//float normAngleZ = toAngleZ(contact.normal);
			//float newAngleZ = normAngleZ + (normAngleZ - curAngleZ);
			//print("curAngleZ:" + curAngleZ + " normAngleZ:" + normAngleZ + " newAngleZ:" + newAngleZ); //Debug
			//float curAngleY = toAngleY(moveDir * -1);
			//float normAngleY = toAngleY(contact.normal);
			//float newAngleY = normAngleY + (normAngleY - curAngleY);
			//print("curAngleY:" + curAngleY + " normAngleY:" + normAngleY + " newAngleY:" + newAngleY); //Debug
			//moveDir = toVector3(newAngleZ, newAngleY);
			//print("moveDir Final: " + moveDir);                                                        //Debug
			
			Debug.DrawRay(contact.point, contact.normal, Color.red, 100);                              //Debug
			//print(contact.normal + " " + moveDir);                                                     //Debug
			//Vector3 initial = transform.forward * -1;
			//Vector3 normal = contact.normal;
			//Vector3 final;
			//final.x = Mathf.Sin(Mathf.Asin(initial.x) + 2 * Mathf.Asin(normal.x));
			//final.y = Mathf.Sin(Mathf.Asin(initial.y) + 2 * Mathf.Asin(normal.y));
			//final.z = Mathf.Sin(Mathf.Asin(initial.z) + 2 * Mathf.Asin(normal.z));
			//moveDir = final;
			
		}
		
	}
	
	float toAngleZ (Vector3 vec)
	{
		
		float angleA1 = Mathf.Rad2Deg * Mathf.Acos(vec.x);
		if (angleA1 < 0) angleA1 += 360;
		float angleA2 = 180 + (180 - angleA1);
		if (angleA2 < 0) angleA2 += 360;
		print ("for Z vec:" + vec);                         //Debug
		print ("    angleA1:" + angleA1 + " angleA2:" + angleA2);                   //Debug
		float angleB1 = Mathf.Rad2Deg * Mathf.Asin(vec.y);
		if (angleB1 < 0) angleB1 += 360;
		float angleB2 = 90 + (90 - angleB1);
		if (angleB2 < 0) angleB2 += 360;
		print ("    angleB1:" + angleB1 + " angleB2:" + angleB2);                   //Debug
		if (Mathf.Round(angleA1) == Mathf.Round(angleB1))
			return angleA1;
		else if (Mathf.Round(angleA1) == Mathf.Round(angleB2))
			return angleA1;
		else if (Mathf.Round(angleA2) == Mathf.Round(angleB1))
			return angleA2;
		else if (Mathf.Round(angleA2) == Mathf.Round(angleB2))
			return angleA2;
		else
			return 0;
		
	}
	
	float toAngleY (Vector3 vec)  //This isn't working
	{
		
		float angleA1 = Mathf.Rad2Deg * Mathf.Acos(vec.x);
		if (angleA1 < 0) angleA1 += 360;
		float angleA2 = 180 + (180 - angleA1);
		if (angleA2 < 0) angleA2 += 360;
		//print ("for Y vec:" + vec);                         //Debug
		//print ("    angleA:" + angleA);                   //Debug
		float angleB1 = Mathf.Rad2Deg * Mathf.Asin(vec.z);
		if (angleB1 < 0) angleB1 += 360;
		float angleB2 = 90 + (90 - angleB1);
		if (angleB2 < 0) angleB2 += 360;
		//print ("    angleB:" + angleB);                   //Debug
		if (Mathf.Round(angleA1) == Mathf.Round(angleB1))
			return angleA1;
		else if (Mathf.Round(angleA1) == Mathf.Round(angleB2))
			return angleA1;
		else if (Mathf.Round(angleA2) == Mathf.Round(angleB1))
			return angleA2;
		else if (Mathf.Round(angleA2) == Mathf.Round(angleB2))
			return angleA2;
		else
			return 0;
		
	}
	
	Vector3 toVector3(float angleZ, float angleY)
	{
		
		float radZ = Mathf.Deg2Rad * angleZ;
		float radY = Mathf.Deg2Rad * angleY;
		
		float x = Mathf.Cos(radZ);
		float y = Mathf.Sin(radZ);
		float z = Mathf.Sin(radY);
		
		return new Vector3(x, y, z);
		
	}
	
}
