using UnityEngine;
using System.Collections;

public class SceneLoad : MonoBehaviour {

	public int index=0;


	public void NextLevelButton(int index)
	{
		Application.LoadLevel(index);
	}
}
