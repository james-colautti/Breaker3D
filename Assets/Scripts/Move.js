var moveSpeed:float;
var turnSpeed:float;
function Start ()
{
	
	Screen.lockCursor = true;
	
}
function Update ()
{

	transform.position += transform.forward * moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
	transform.position += transform.right * moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
	transform.eulerAngles.x += -turnSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime;
	transform.eulerAngles.y += turnSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
	//if (Input.GetButtonDown("LockCursor"))
	//{
	//	if (Screen.lockCursor == true)
	//	{
	//		Screen.lockCursor = false;
	//	}
	//	else
	//	{
	//		Screen.lockCursor = true;
	//	}
	//}
	
}