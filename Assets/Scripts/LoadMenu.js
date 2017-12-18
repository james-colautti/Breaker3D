import  System.IO;


//var prefabTxtButton:Transform;
var txtButton : TextMesh;
var i : int;
static var currentPath : String;
static var toLoadPath : String;
var parentPath : String;
static var folderPaths : String[];
var audioPaths : String[];
static var preLoad : boolean = false;
static var toLoad : boolean = false;
var menuSbarValue : float;

function Update()
{
	
	//print (SystemInfo.operatingSystem);
	//if(Input.GetButtonDown("Jump"))
	//{
	if (toLoad == true)
	{
		preLoad = false;
		if ((Directory.GetParent(toLoadPath)) != null)
		{
			parentPath = (Directory.GetParent(toLoadPath)).ToString();
		}
		folderPaths = Directory.GetDirectories(toLoadPath);
		audioPaths = Directory.GetFiles(toLoadPath,"*.wav") + Directory.GetFiles(toLoadPath,"*.ogg");
		currentPath = toLoadPath;
		print (currentPath);
		
		if ((Directory.GetParent(toLoadPath)) != null)
		{
			txtButton.text = "<...";
			var boxCollider0 : BoxCollider;
			boxCollider0 = txtButton.gameObject.GetComponent(BoxCollider);
			//print (txtButton.text + " " + -(i - (filePaths.length / 2)));
			boxCollider0.size = Vector3((txtButton.text.length) / 2, 1, 1);
			boxCollider0.center = Vector3((txtButton.text.length) / 4, 0, 0);
			var instanceTxtButton0 = Instantiate(txtButton, Vector3(-6, 5, 0), Quaternion.identity);
		}
		
		for (i = 0; i < folderPaths.length; i++)
		{
			txtButton.text = Path.GetFileName(folderPaths[i]);
			var boxCollider1 : BoxCollider;
			boxCollider1 = txtButton.gameObject.GetComponent(BoxCollider);
			//print (txtButton.text + " " + -(i - (filePaths.length / 2)));
			boxCollider1.size = Vector3((txtButton.text.length) / 2, 1, 1);
			boxCollider1.center = Vector3((txtButton.text.length) / 4, 0, 0);
			var instanceTxtButton1 = Instantiate(txtButton, Vector3(-5, -(i - (folderPaths.length / 2) - 2.5), 0), Quaternion.identity);
		}
		
		for (i = 0; i < audioPaths.length; i++)
		{
			txtButton.text = Path.GetFileName(audioPaths[i]);
			var boxCollider2 : BoxCollider;
			boxCollider2 = txtButton.gameObject.GetComponent(BoxCollider);
			//print (txtButton.text + " " + -(i - (filePaths.length / 2)));
			boxCollider2.size = Vector3((txtButton.text.length) / 2, 1, 1);
			boxCollider2.center = Vector3((txtButton.text.length) / 4, 0, 0);
			var instanceTxtButton2 = Instantiate(txtButton, Vector3(0, -(i - (audioPaths.length / 2)), 0), Quaternion.identity);
		}
		
	}
	toLoad = false;
	
}

function Start()
{
	if ((Directory.GetParent(Application.dataPath)) != null)
	{
		parentPath = (Directory.GetParent(Application.dataPath)).ToString();
	}
	folderPaths = Directory.GetDirectories(Application.dataPath);
	audioPaths = Directory.GetFiles(Application.dataPath,"*.wav") + Directory.GetFiles(Application.dataPath,"*.ogg");
	currentPath = Application.dataPath;
	
	if ((Directory.GetParent(Application.dataPath)) != null)
	{
		txtButton.text = "<...";
		var boxCollider0 : BoxCollider;
		boxCollider0 = txtButton.gameObject.GetComponent(BoxCollider);
		//print (txtButton.text + " " + -(i - (filePaths.length / 2)));
		boxCollider0.size = Vector3((txtButton.text.length) / 2, 1, 1);
		boxCollider0.center = Vector3((txtButton.text.length) / 4, 0, 0);
		var instanceTxtButton0 = Instantiate(txtButton, Vector3(-6, 5, 0), Quaternion.identity);
	}
		
	for (i = 0; i < folderPaths.length; i++)
	{
		txtButton.text = Path.GetFileName(folderPaths[i]);
		var boxCollider1 : BoxCollider;
		boxCollider1 = txtButton.gameObject.GetComponent(BoxCollider);
		//print (txtButton.text + " " + -(i - (filePaths.length / 2)));
		boxCollider1.size = Vector3((txtButton.text.length) / 2, 1, 1);
		boxCollider1.center = Vector3((txtButton.text.length) / 4, 0, 0);
		var instanceTxtButton1 = Instantiate(txtButton, Vector3(-5, -(i - (folderPaths.length / 2) - 2.5), 0), Quaternion.identity);
	}
	
	for (i = 0; i < audioPaths.length; i++)
	{
		txtButton.text = Path.GetFileName(audioPaths[i]);
		var boxCollider2 : BoxCollider;
		boxCollider2 = txtButton.gameObject.GetComponent(BoxCollider);
		//print (txtButton.text + " " + -(i - (filePaths.length / 2)));
		boxCollider2.size = Vector3((txtButton.text.length) / 2, 1, 1);
		boxCollider2.center = Vector3((txtButton.text.length) / 4, 0, 0);
		var instanceTxtButton2 = Instantiate(txtButton, Vector3(0, -(i - (audioPaths.length / 2)), 0), Quaternion.identity);
	}

	
	
}

/*function OnGUI ()
{
	
	menuSbarValue = GUILayout.VerticalScrollbar(menuSbarValue, 0.0, 500.0, 0.0, GUILayout.Height(200));
	GUI.VerticalScrollbar(Rect((Screen.width - 30), 10, 100, 30));
	print (Screen.width + " & " + Screen.height);
}*/