	using UnityEngine;

	[RequireComponent(typeof(MeshFilter))]
	public class OctahedronSphere : MonoBehaviour {

		public int subdivisions = 6;
		
		public float radius = 1f;
		
		private void Awake () {
		Mesh a = OctahedronSphereCreator.Create (subdivisions, radius);
		GetComponent<MeshFilter>().mesh = a ;
		//GetComponent<MeshCollider>().sharedMesh = a;
		}
	}