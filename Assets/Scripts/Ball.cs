using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
	
	//int gravityForce = 500;
	private GameObject player;
	private HardPhysics physics;
	public AudioClip paddle, glass;
	private Vector3 moveDir, gravDir, gravHead, finDir;
	private float speed, grav, gravDist, gravInc;
	private bool ballActive;
	private float stretchTimer;
	private int stretchSwitcher;
	private Player pScript;

	void Start ()
	{
		
		player = GameObject.FindGameObjectWithTag("Player");
		pScript = (Player)player.GetComponent(typeof(Player));
		physics = (HardPhysics)FindObjectOfType(typeof(HardPhysics));
		speed = 10;
		grav = 0;
		gravInc = 0.1f;
		ballActive = false;
		reset();
		
	}
	
	void Update ()
	{
		
		if (ballActive == true)
		{
			if (grav <= 1)
			{
				grav += gravInc * Time.deltaTime;
			}
			else grav = 1;
			gravHead = Vector3.zero - transform.position;
			gravDist = gravHead.magnitude;
			gravDir = gravHead / gravDist;
			finDir = (moveDir * (1 - grav)) + (gravDir * grav);
			transform.position += finDir * speed * Time.deltaTime;
			//transform.position += gravDir * grav * Time.deltaTime;
			//print (((moveDir * (1 - grav)) + (gravDir * grav)));
			Instantiate(Resources.Load("Trail"), transform.position, transform.rotation);
			
		}
		else
		{
			grav = 0;
		}
		
		if (transform.position.magnitude >= 30)
		{
			speed = 0;
		}
		
	}
	
	void OnCollisionEnter (Collision other)
	{
		
		if (ballActive)
		{
			Vector3 normal = new  Vector3(0, 0, 0);
			Vector3 point = new Vector3(0, 0, 0);
			foreach (ContactPoint contact in other.contacts)
			{
				normal += contact.normal;
				point += contact.point;
				Debug.DrawRay(contact.point, contact.normal, Color.red, 30);
			}
			normal = normal / other.contacts.Length;
			point = point / other.contacts.Length;
			
			Debug.DrawRay(point, finDir, Color.black, 30);
			moveDir = physics.getReboundVector(finDir.normalized, normal);
			GameObject hit = (GameObject)Instantiate(Resources.Load("Hit Effect"), point, Quaternion.LookRotation(normal));
			Debug.DrawRay(point, normal, Color.blue, 30);
			Debug.DrawRay(point, moveDir, Color.green, 30);
			//other.transform.audio.Play();
			
			if (other.gameObject.tag == ("Enemy"))
			{
				GetComponent<AudioSource>().PlayOneShot(glass);
				Destroy(other.gameObject);//, glass.length);
				//speed += 0.5f;
				//gravInc += 0.005f;
				pScript.AddScore(1000);
			}
			else if (other.gameObject.tag == ("Player"))
			{
				GetComponent<AudioSource>().PlayOneShot(paddle);//(AudioClip)Resources.Load("paddle crash.wav"));
				grav = 0;
			}
			else if (other.gameObject.tag == ("Orbit"))
			{
				GetComponent<AudioSource>().PlayOneShot(paddle);
				Destroy(gameObject);
				pScript.AddScore(-5000);
			}
			else GetComponent<AudioSource>().PlayOneShot(paddle);
			StartCoroutine(stretch());
			print(grav);
		}
		
	}
	
	public void fire()
	{
		
		transform.parent = null;
		moveDir = player.transform.forward;
		ballActive = true;
		
	}
	
	public void reset()
	{
		
		ballActive = false;
		transform.parent = player.transform;
		transform.rotation = player.transform.rotation;
		transform.GetChild(0).rotation = transform.rotation;
		transform.localPosition = new Vector3 (0, 0, 1);
		
	}
	
	public float getSpeed()
	{
		
		return speed;
		
	}
	
	public void addToSpeed(float amount)
	{
		
		speed += amount;
		
	}
	
	public Vector3 getMoveDir()
	{
		
		return moveDir;
		
	}
	
	public Vector3 getFinDir()
	{
		
		return finDir;
		
	}
	
	public bool getBallActive()
	{
		
		return ballActive;
		
	}
	
	IEnumerator stretch()
	{
		
		stretchTimer = 0.2F;
		stretchSwitcher = 0;
		
		
		while (stretchSwitcher != 2)
		{
			
			transform.localScale = new Vector3(0.5F, 0.5F, 0.5F) + new Vector3 (0.5F, 0.5F, 0.5F) * stretchTimer;
			
			if (stretchSwitcher == 0)
			{
				stretchTimer = stretchTimer + 0.2F;
			}
			else if (stretchSwitcher == 1)
			{
				stretchTimer = stretchTimer - 0.2F;
			}
			if (stretchTimer >= 1)
			{
				stretchSwitcher = 1;
			}
			if (stretchTimer <= 0)
			{
				stretchSwitcher = 2;
			}
			yield return new WaitForSeconds(0.01F);
			
		}
	}
	
}
