var prefabBullet:Transform;
var shootForce:float;

function Update ()
{
	if(Input.GetButtonDown("Jump"))
	{
		var instanceBullet = Instantiate(prefabBullet, transform.position, Quaternion.identity);
		instanceBullet.GetComponent.<Rigidbody>().AddForce(transform.forward *shootForce);
		instanceBullet.GetComponent.<Renderer>().material.color = Color.cyan;
	}
}