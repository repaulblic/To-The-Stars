using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlanetSave : MonoBehaviour {
	
	public static PlanetSave control;
	//public GameObject saveobject;

	
	void Awake(){
		if (control == null) 
		{
			DontDestroyOnLoad (gameObject);
			control = this;
		} 
		else if (control != this)
		{
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/PlayerInfo.dat");
		
		GameObject planet = GameObject.Find ("Planet");


		GO dd = new GO ();
		dd.saveobject = planet;
		
		bf.Serialize (file, dd);
		file.Close();
	}
	
	public void load ()
	{
		if(File.Exists(Application.persistentDataPath + "/PlayerInfo.watermellon"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/PlayerInfo.watermellon", FileMode.Open);
			GO data = (GO)bf.Deserialize(file);
			file.Close();
			

		}
	}
}

[Serializable]
class GO
{
	public GameObject saveobject;
}
