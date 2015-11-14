using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

	public static GameControl control;

	public float health;
	public float experience;
	public float wood;
	public float water;
	public float fire;

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

		PlayerData data = new PlayerData (health,experience,wood,water,fire);

		bf.Serialize (file, data);
		file.Close();
	}

	public void load ()
	{
		if(File.Exists(Application.persistentDataPath + "/PlayerInfo.watermellon"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/PlayerInfo.watermellon", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize(file);
			file.Close();

			health = data.health;
			experience = data.experience;
			wood = data.wood;
			fire = data.fire;
			water = data.water;
		}
	}
}

[Serializable]
public class PlayerData
{
	public float health;
	public float experience;
	public float wood;
	public float water;
	public float fire;

	public PlayerData(float h, float e, float w, float wa, float f)
	{
		health = h;
		experience = e;
		wood = w;
		water = wa;
		fire = f;
	}
	

}