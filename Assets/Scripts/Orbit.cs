using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour
{
	
	GameObject ball, player;
	Ball bscript;
	Player pscript;
	BallTracker btscript;

	void Start ()
	{
		
		
		
	}
	
	void Update ()
	{
		
	}
	
	public void GetPlayer()
	{
		
		player = GameObject.FindGameObjectWithTag("Player");
		pscript = (Player)player.GetComponent(typeof(Player));
		btscript = (BallTracker)FindObjectOfType(typeof(BallTracker));
		
	}
	
	void OnTriggerEnter (Collider other)
	{
		/*if (other.gameObject.tag == "Weapon")
		{
			//bscript = (Ball)other.transform.GetComponent(typeof(Ball));
    		//pscript.removeWep(other.gameObject);
			//btscript.removeWep(other.gameObject);
			Destroy(other.gameObject);
			//ball = (GameObject)Instantiate(Resources.Load("Ball"), Vector3.zero, Quaternion.identity);
			//ball.transform.rotation = player.transform.rotation;
			//ball.transform.parent = player.transform;
			//ball.transform.localPosition = new Vector3 (0, 0, 1);
			//bscript.reset();
		}*/
	}
}
