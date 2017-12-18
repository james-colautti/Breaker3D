using UnityEngine;
using System.Collections;



public class Move : MonoBehaviour
{
	private bool moveLock;
	private int moveSpeed;
	GameObject stabilizer;
	public bool isLevelGenerating;
	public GameObject cameraObj;
	public Vector3 cameraObjDefaultPos;
	private Animator animator;
	private float moveX, moveY;

	void Start ()
	{
		
		Screen.lockCursor = true;  //Should move
		moveLock = false;
		moveSpeed = 10;
		stabilizer = GameObject.Find("Stabilizer");
		cameraObjDefaultPos = cameraObj.transform.localPosition;
		animator = GetComponent<Animator>();
		
	}
	
	void Update ()
	{
		
		if (moveLock == false)
		{
			transform.RotateAround(Vector3.zero, transform.right * -1, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime * 0.16f);
			transform.RotateAround(Vector3.zero, transform.right * -1, moveSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime * 10);
			stabilizer.transform.position = transform.position;
			stabilizer.transform.RotateAround(Vector3.zero, transform.up, moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime * 0.8f);
			stabilizer.transform.RotateAround(Vector3.zero, transform.up, moveSpeed * Input.GetAxis("Mouse X") * Time.deltaTime * 10);
			transform.position = stabilizer.transform.position;

			if (isLevelGenerating)
			{
				transform.LookAt(transform.position * -2);
			}
			else
			{
				transform.LookAt(transform.position * 2);
			}

			moveX = Mathf.Lerp(moveX, Input.GetAxis("Mouse X"), Time.deltaTime * 2);
			moveY = Mathf.Lerp(moveY, Input.GetAxis("Mouse Y"), Time.deltaTime * 2);
						Debug.Log(Input.GetAxis("Mouse X") + " " + Input.GetAxis("Mouse X"));
			animator.SetFloat("MoveX", Input.GetAxis("Horizontal") + moveX);
			animator.SetFloat("MoveY", Input.GetAxis("Vertical") + moveY);
		}
		
	}
	
	public void LockMovement()
	{

		moveLock = true;
		
	}
	
	public void UnlockMovement()
	{
		
		moveLock = false;
		
	}
	
}
