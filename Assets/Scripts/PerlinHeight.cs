﻿
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using System.IO;


public class PerlinHeight: MonoBehaviour {

	[Range(0.0f, 100.0f)]
	public float scale = 0.25f;// 0.4f;
	[Range(0.0f, 5.0f)]
	public float multi = 3f;
	[Range(0.0f, 100.0f)]
	public float scale2 = 0.25f;// 0.4f;
	[Range(0.0f, 5.0f)]
	public float multi2 = 3f;


//	private Vector2 v2SampleStart = new Vector2(0, 0);	
//	public int size = 1;
//	public float power = 1;
//	public float radius = 1;

	
	
	void Start(){
		
		/*
             Mesh mesh = transform.GetComponent<MeshFilter>().mesh;
             Vector3[] vertices = mesh.vertices;
             
             for(int i = 0; i < vertices.Length; i++){
                 vertices[i] = vertices[i].normalized * radius;
             }
             
             mesh.vertices = vertices;
             mesh.RecalculateNormals();
             mesh.RecalculateBounds();
            */

		SetHeights();
		multi = multi2;
		scale = scale2;
		SetHeights ();

		multi = multi * 0.1f;
		scale = scale * 0.1f;
		SetHeights ();
		GetComponent<MeshCollider> ().sharedMesh = GetComponent<MeshFilter> ().mesh;

		//AssetDatabase.CreateAsset (GetComponent<MeshFilter> ().mesh);
		
		
		//Mesh meshToSave = (makeNewInstance) ? Object.Instantiate(mesh) as Mesh : mesh;
		
	}
	
	void Update(){
		/*
         if(Input.GetKeyUp(KeyCode.Space)){
             v2SampleStart = new Vector2(Random.Range(0, 100), Random.Range(0, 100));
             SetHeights();
         }
          */
	}
	
	void SetHeights(){



		Mesh mesh = transform.GetComponent<MeshFilter>().mesh;
		Vector3[] vertices = mesh.vertices;
		Vector2 offset1 = new Vector2(Random.Range(0, 100), Random.Range(0, 100));
		Vector2 offset2 = new Vector2(Random.Range(0, 100), Random.Range(0, 100));
		Vector2 offset3 = new Vector2(Random.Range(0, 100), Random.Range(0, 100));
		
		for (int i = 0; i < vertices.Length; i++) {    
			//float xCoord = v2SampleStart.x + vertices[i].x  * scale;
			//float yCoord = v2SampleStart.y + vertices[i].z  * scale;
			vertices[i].x = vertices[i].x * (1 + Mathf.PerlinNoise(vertices[i].y  * multi + offset1.x, vertices[i].z * multi + offset1.y) * scale);
			vertices[i].y = vertices[i].y * (1 + Mathf.PerlinNoise(vertices[i].z * multi + offset2.x, vertices[i].x * multi + offset2.y) * scale);
			vertices[i].z = vertices[i].z * (1 + Mathf.PerlinNoise(vertices[i].x * multi + offset3.x, vertices[i].y * multi + offset3.y) * scale); 


		}
		mesh.vertices = vertices;
		mesh.RecalculateBounds();
		mesh.RecalculateNormals();
	}
}