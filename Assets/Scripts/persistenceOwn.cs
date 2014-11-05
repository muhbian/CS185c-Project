using UnityEngine; 
using System.Collections; 
using System.Xml; 
using System.Xml.Serialization; 
using System.IO; 
using System.Text; 

public class persistenceOwn: MonoBehaviour { 

	// copied from http://wiki.unity3d.com/index.php/Save_and_Load_from_XML


	// An example where the encoding can be found is at 
	// http://www.eggheadcafe.com/articles/system.xml.xmlserialization.asp 
	// We will just use the KISS method and cheat a little and use 
	// the examples from the web page since they are fully described 
	
	// This is our local private members 
	Rect _Save, _Load, _SaveMSG, _LoadMSG; 
	bool _ShouldSave, _ShouldLoad,_SwitchSave,_SwitchLoad; 
	string _FileLocation,_FileName; 
	public player _Player; 
	UserData myData; 
	string _data; 

	public int highscore;
	public int score;

	Vector3 VPosition; 
	
	// When the EGO is instansiated the Start will trigger 
	// so we setup our initial values for our local members 
	void Start () { 
		// We setup our rectangles for our messages 
		_Save=new Rect(10,80,100,20); 
		_Load=new Rect(10,100,100,20); 
		_SaveMSG=new Rect(10,120,400,40); 
		_LoadMSG=new Rect(10,140,400,40); 
		
		// Where we want to save and load to and from 
		_FileLocation=Application.dataPath; 
		_FileName="SaveData.xml"; 

		
		// we need soemthing to store the information into 
		myData=new UserData(); 
	} 
	
	void Update () {} 

	void loadPlayer() {
		
		GUI.Label(_LoadMSG,"Loading from: "+_FileLocation); 
		// Load our UserData into myData 
		LoadXML(); 
		if(_data.ToString() != "") 
		{ 
			// notice how I use a reference to type (UserData) here, you need this 
			// so that the returned object is converted into the correct type 
			myData = (UserData)DeserializeObject(_data);

			_Player.score = myData._iUser.score;
			this.score = myData._iUser.score;
			_Player.ammunition = myData._iUser.ammo;
			_Player.lives = myData._iUser.lives;
			_Player.highscore = myData._iUser.highscore;
			this.highscore = myData._iUser.highscore;


		} 
		
	}

	void loadHighScore() {
	//	GUI.Label(_LoadMSG,"Loading from: "+_FileLocation); 
		// Load our UserData into myData 
		LoadXML(); 
		if(_data.ToString() != "") 
		{ 
			// notice how I use a reference to type (UserData) here, you need this 
			// so that the returned object is converted into the correct type 
			myData = (UserData)DeserializeObject(_data);

			_Player.highscore = myData._iUser.highscore;
			this.highscore = myData._iUser.highscore;
			
		} 
		}

	void savePlayer() {

	//	GUI.Label(_SaveMSG,"Saving to: "+_FileLocation); 
		myData._iUser.score = _Player.score; 
		myData._iUser.ammo= _Player.ammunition; 
		myData._iUser.lives=_Player.lives; 
		if (myData._iUser.highscore < _Player.score) {
			myData._iUser.highscore = _Player.score;
		}
		    
		
		// Time to creat our XML! 
		_data = SerializeObject(myData); 
		// This is the final resulting XML from the serialization process 
		CreateXML(); 
		Debug.Log(_data); 
	}

	void OnGUI() 
	{    

		
	} 
	
	/* The following metods came from the referenced URL */ 
	string UTF8ByteArrayToString(byte[] characters) 
	{      
		UTF8Encoding encoding = new UTF8Encoding(); 
		string constructedString = encoding.GetString(characters); 
		return (constructedString); 
	} 
	
	byte[] StringToUTF8ByteArray(string pXmlString) 
	{ 
		UTF8Encoding encoding = new UTF8Encoding(); 
		byte[] byteArray = encoding.GetBytes(pXmlString); 
		return byteArray; 
	} 
	
	// Here we serialize our UserData object of myData 
	string SerializeObject(object pObject) 
	{ 
		string XmlizedString = null; 
		MemoryStream memoryStream = new MemoryStream(); 
		XmlSerializer xs = new XmlSerializer(typeof(UserData)); 
		XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8); 
		xs.Serialize(xmlTextWriter, pObject); 
		memoryStream = (MemoryStream)xmlTextWriter.BaseStream; 
		XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray()); 
		return XmlizedString; 
	} 
	
	// Here we deserialize it back into its original form 
	object DeserializeObject(string pXmlizedString) 
	{ 
		XmlSerializer xs = new XmlSerializer(typeof(UserData)); 
		MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(pXmlizedString)); 
		XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8); 
		return xs.Deserialize(memoryStream); 
	} 
	
	// Finally our save and load methods for the file itself 
	void CreateXML() 
	{ 
		StreamWriter writer; 
		FileInfo t = new FileInfo(_FileLocation+"/"+ _FileName); 
		if(!t.Exists) 
		{ 
			writer = t.CreateText(); 
		} 
		else 
		{ 
			t.Delete(); 
			writer = t.CreateText(); 
		} 
		writer.Write(_data); 
		writer.Close(); 
		Debug.Log("File written."); 
	} 
	
	void LoadXML() 
	{ 
		StreamReader r = File.OpenText(_FileLocation+"/"+ _FileName); 
		string _info = r.ReadToEnd(); 
		r.Close(); 
		_data=_info; 
		Debug.Log("File Read"); 
	} 
} 



// UserData is our custom class that holds our defined objects we want to store in XML format 
public class UserData 
{ 
	// We have to define a default instance of the structure 
	public DemoData _iUser; 
	// Default constructor doesn't really do anything at the moment 
	public UserData() { } 
	
	// Anything we want to store in the XML file, we define it here 
	public struct DemoData 
	{ 
		public int score; 
		public int ammo;
		public int lives;
		public int highscore;
	} 
}