function Awake()
{
	
	GetComponent.<Renderer>().material.color = Color.blue;
	
}

function OnMouseEnter()
{
	
	GetComponent.<Renderer>().material.color = Color.red;
	
}

function OnMouseExit()
{
	
	GetComponent.<Renderer>().material.color = Color.blue;
	
}

function OnMouseUp()
{
	
	Application.LoadLevel ("SongMenu");
	
}