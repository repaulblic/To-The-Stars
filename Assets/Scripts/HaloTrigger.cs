using UnityEngine;
using System.Collections;

public class HaloTrigger : MonoBehaviour {
	
	void OnTriggerEnter(UnityEngine.Collider other) 
	{

		if (other.gameObject.CompareTag ("Planet"))
		{	
			Component halo = other.gameObject.GetComponent("Halo"); 
			halo.GetType().GetProperty("enabled").SetValue(halo,true,null);
		}

	}

	void OnTriggerExit(UnityEngine.Collider other){
	
		if (other.gameObject.CompareTag ("Planet"))
		{	
			Component halo = other.gameObject.GetComponent("Halo"); 
			halo.GetType().GetProperty("enabled").SetValue(halo,false,null);
		}

	}


}

 