	using UnityEngine;

	[RequireComponent(typeof(MeshFilter))]
	public class OctahedronSphere : MonoBehaviour {

		public int subdivisions = 6;
		
		public float radius = 1f;
		
		private void Awake () {
			GetComponent<MeshFilter>().mesh = OctahedronSphereCreator.Create(subdivisions, radius);
		}
	}