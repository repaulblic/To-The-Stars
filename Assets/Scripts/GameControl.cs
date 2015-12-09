using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

	public static GameControl control;

	public int experience;
	public int metal;
	public int ice;
	public int wood;
	public int water;
	public int fire;
	public int seed;
	public string seedString;

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
		FileStream file = File.Create (Application.persistentDataPath + "/PlayerInfo.watermellon");

		PlayerData data = new PlayerData (experience,metal,ice,wood,water,fire,seed);

		bf.Serialize (file, data);
		file.Close();
		Debug.Log("File Saved");
	}

	public void load ()
	{
		if(File.Exists(Application.persistentDataPath + "/PlayerInfo.watermellon"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/PlayerInfo.watermellon", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize(file);
			file.Close();

			experience = data.experience;
			metal = data.metal;
			ice = data.ice;
			wood = data.wood;
			fire = data.fire;
			water = data.water;
			seed = data.seed;
			UnityEngine.Random.seed=seed;
			//Debug.Log("File Loaded");
		}
	}
}

[Serializable]
public class PlayerData
{
	public int experience;
	public int metal;
	public int ice;
	public int wood;
	public int water;
	public int fire;
	public int seed;

	public PlayerData(int e, int m, int i, int w, int wa, int f,int s)
	{
		metal = m;
		ice = i;
		experience = e;
		wood = w;
		water = wa;
		fire = f;
		seed = s;
	}
	

}