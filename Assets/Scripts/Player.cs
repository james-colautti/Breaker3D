using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	
	private bool gameActive;
	GameObject ball, cam;
	Ball bscript;
	ArrayList weapons;
	private int score;
	private int newScore;
	private float newScoreDisplayTimer;

	void Start ()
	{
		
		gameActive = false;
		weapons = new ArrayList();
		cam = GameObject.FindGameObjectWithTag("MainCamera");
		
	}
	
	void Update ()
	{
		
		if (gameActive == true)
		{
			GameObject[] temp = GameObject.FindGameObjectsWithTag("Weapon");
			foreach (GameObject x in temp)
			{
				if (x.transform.parent == transform)
					bscript = (Ball)x.transform.GetComponent(typeof(Ball));
				//weapons.Add(x);
				
				//ball = GameObject.FindGameObjectWithTag("Weapon");
				//bscript = (Ball)FindObjectOfType(typeof(Ball));
			}
			/*foreach (GameObject x in weapons)
			{
				if (x.transform.parent == transform)
					bscript = (Ball)x.transform.GetComponent(typeof(Ball));
			}*/
				
			if(Input.GetMouseButtonDown(0) || Input.GetButtonDown("Jump"))
			{
				if (bscript.getBallActive() == false)
				{
					
					bscript.fire();
				}
				else
				{
					//Destroy(ball);
					//ball = (GameObject)Instantiate(Resources.Load("Ball"), transform.position, Quaternion.identity);
					//bscript = (Ball)FindObjectOfType(typeof(Ball));
					
					//bscript.reset();
					
					//ball = (GameObject)Instantiate(Resources.Load("Ball"), Vector3.zero, Quaternion.identity);
					//bscript = (Ball)ball.GetComponent(typeof(Ball));
					ball = (GameObject)Instantiate(Resources.Load("Ball"), new Vector3(100, 100, 100), Quaternion.identity);
					bscript = (Ball)ball.transform.GetComponent(typeof(Ball));
					//weapons.Add(ball);
					bscript.reset();
					
				}
				
			}
			
			if(Input.GetKey(KeyCode.Q) && bscript.getSpeed() > 0)//For Testing
			{
				bscript.addToSpeed(-1);
			}
			if(Input.GetKey(KeyCode.E))//For Testing
			{
				bscript.addToSpeed(1);
			}
			
			cam.transform.position += transform.forward * Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 100;
			cam.transform.position -= transform.forward * Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 100;
			
		}
		
	}
	
	void OnGUI()
	{
		
		GUI.Label(new Rect(Screen.width - 200, Screen.height - 30, 200, 20), "Breaker3D Alpha 1.0");
		//if (bscript != null)
		//	GUI.Label(new Rect(10, 10, 200, 20), "Launch Speed: " + bscript.getSpeed());
		var scoreShadowStyle = new GUIStyle(GUI.skin.GetStyle("Label"));
		scoreShadowStyle.alignment = TextAnchor.MiddleLeft;
		scoreShadowStyle.fontSize = 24;
		scoreShadowStyle.normal.textColor = Color.black;
		var scoreStyle = new GUIStyle(GUI.skin.GetStyle("Label"));
		scoreStyle.alignment = TextAnchor.MiddleLeft;
		scoreStyle.fontSize = 24;
		scoreStyle.normal.textColor = Color.white;
		GUI.Label(new Rect(11, 11, 100, 40), "Score: ", scoreShadowStyle);
		GUI.Label(new Rect(10, 10, 100, 40), "Score: ", scoreStyle);
		GUI.Label(new Rect(121, 11, 400, 40), "" + score, scoreShadowStyle);
		GUI.Label(new Rect(120, 10, 400, 40), "" + score, scoreStyle);
		if (newScore != 0 && newScoreDisplayTimer > 0)
		{
			if (newScore > 0)
			{
				GUI.Label(new Rect(121, 56, 200, 40), "+" + newScore, scoreShadowStyle);
				GUI.Label(new Rect(120, 55, 200, 40), "+" + newScore, scoreStyle);
			}
			else
			{
				GUI.Label(new Rect(121, 56, 200, 40), "" + newScore, scoreShadowStyle);
				GUI.Label(new Rect(120, 55, 200, 40), "" + newScore, scoreStyle);
			}
			newScoreDisplayTimer -= Time.deltaTime;
		}
		
	}
	
	public void SetGameActive()
	{
		
		gameActive = true;
		
	}
	
	public void SetGameInactive()
	{
		
		gameActive = false;
		
	}
	
	public bool GetGameActive()
	{
		
		return gameActive;
		
	}

	public void AddScore(int val)
	{
		newScore = val;
		score += newScore;
		if (score < 0)
		{
			score = 0;
		}
		newScoreDisplayTimer = 2;
	}
	
	/*public void removeWep(GameObject x)
	{
		
		weapons.Remove(x);
		
	}*/
	
	/*
	public int GetShootForce()
	{
		
		return shootForce;
		
	}
	
	public void AddToShootForce(int addition)
	{
		
		shootForce += addition;
		
	}
	
	void OnCollisionEnter (Collision other)
	{
		velocity = 0;
	}
	*/
	
}
