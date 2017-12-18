using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour
{
	
	public GameObject playerPrefab;
	private GameObject orbit, player, ball, block, barrier;
	private int coreRadius, barrierRadius;
	Orbit oScript;
	Player pScript;
	Ball bScript;
	Move move, moveP;
	int dir;
	float timer;
	
	void Start ()
	{
		
		coreRadius = 6;
		barrierRadius = 50;
		
		orbit = (GameObject)Instantiate(Resources.Load("Orbit"), Vector3.zero, Quaternion.identity);
		orbit.transform.localScale = new Vector3(coreRadius * 2, coreRadius * 2, coreRadius * 2);
		oScript = (Orbit)orbit.transform.GetComponent(typeof(Orbit));
		
		StartCoroutine(Build());
		dir = 0;
		timer = 0;
		
		move = (Move)transform.GetComponent(typeof(Move));
		move.isLevelGenerating = true;
	}
	
	void Update ()
	{
		
		print(Time.time / 10 + " " + (Time.time / 10) % 1);
		if (dir == 0)
		{
			//RenderSettings.ambientLight = Color.Lerp(Color.white, Color.grey, timer);
			timer += Time.deltaTime;
			if (timer >= 1)
			{
				dir = 1;
				timer = 0;
				//RenderSettings.ambientLight = Color.Lerp(Color.red, Color.blue, 0.1F);
			}
		}
		else if (dir == 1)
		{
			//RenderSettings.ambientLight = Color.Lerp(Color.grey, Color.white, timer);
			timer += Time.deltaTime;
			if (timer >= 1)
			{
				dir = 0;
				timer = 0;
				//RenderSettings.ambientLight = Color.Lerp(Color.blue, Color.red, 0.1F);
			}
		}
		
	}
	
	public IEnumerator Build()
	{
		
		int k = 0;
		while (k <= 4)
		{
			int i = 180 / 10;
			while (i < 180)
			{
				int j = 0;
				while (j < 360)
				{
					int rand = (int)Mathf.Ceil(Random.value * 4);
					if (rand == 1)
					{
						//GameObject block;
						Vector3 v = new Vector3(Mathf.Sin(j * Mathf.Deg2Rad) * (Mathf.Sin(i * Mathf.Deg2Rad) * (15 + k)), Mathf.Cos(i * Mathf.Deg2Rad) * -(15 + k), Mathf.Cos(j * Mathf.Deg2Rad) * (Mathf.Sin(i * Mathf.Deg2Rad) * (15 + k)));
						int randB = (int)Mathf.Ceil(Random.value * 3);
						if (randB == 1)
							block = (GameObject)Instantiate(Resources.Load("Block1"), v, Quaternion.identity);
						else if (randB == 2)
							block = (GameObject)Instantiate(Resources.Load("Block2"), v, Quaternion.identity);
						else
							block = (GameObject)Instantiate(Resources.Load("Block3"), v, Quaternion.identity);
						block.transform.LookAt(Vector3.zero);
						yield return new WaitForSeconds(0.02F);
					}
					j += 360 / 20;
				}
				i += 180 / 20;
			}
			k += 2;
		}
		
		barrier = (GameObject)Instantiate(Resources.Load("Barrier"), Vector3.zero, Quaternion.identity);
		
		while (barrier.transform.localScale.x < barrierRadius)
		{
			barrier.transform.localScale += new Vector3(1, 1, 1);
			yield return new WaitForSeconds(0.001F);
		}
		
		StartCoroutine(SetPosition());
		
	}
	
	public IEnumerator SetPosition()
	{
		move.LockMovement();

		float initialTime = Time.time;
		
		while ((int)transform.position.x != 0 || (int)transform.position.y != 0 || (int)transform.position.z != coreRadius)
		{
			Quaternion targetRotation = Quaternion.LookRotation(new Vector3(0, 0, coreRadius) - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.time - initialTime);
			
			transform.position += transform.forward;
		 	
			yield return new WaitForSeconds(0.01F);
		}
		transform.position = new Vector3(0, 0, coreRadius - 1);
		//transform.LookAt(new Vector3(0, 0, coreRadius + 1));
		while (transform.rotation.eulerAngles != Quaternion.LookRotation(new Vector3(0, 0, coreRadius + 1)).eulerAngles)
		{
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(new Vector3(0, 0, coreRadius + 1)), 4);
			yield return new WaitForSeconds(0.01F);
		}
		
		player = (GameObject)Instantiate(playerPrefab, new Vector3(0, 0, coreRadius + 0.5F), Quaternion.identity);
		oScript.GetPlayer();
		moveP = (Move)player.transform.GetComponent(typeof(Move));
		moveP.LockMovement();
		transform.parent = player.transform;
				moveP.cameraObj = gameObject;
		//player.transform.localPosition = new Vector3(0, 0, 1.5F);
		yield return new WaitForSeconds(1F);
		ball = (GameObject)Instantiate(Resources.Load("Ball"), new Vector3(100, 100, 100), Quaternion.identity);
		bScript = (Ball)ball.transform.GetComponent(typeof(Ball));
		//bScript.reset();
		//ball.transform.parent = player.transform;
		//ball.transform.localPosition = new Vector3 (0, 0, 1);
		moveP.UnlockMovement();
		move.isLevelGenerating = false;
		pScript = (Player)player.transform.GetComponent(typeof(Player));
		pScript.SetGameActive();
		
	}
	
}
