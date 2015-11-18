using UnityEngine;
using System.Collections;
using System.Collections.Generic;

 
 public class PerlinHeight: MonoBehaviour {
     public float radius = 1;
     public int size = 1;
     //public GameObject cube;
     public float scale = 0.4f;
     public float power = 1;
     private Vector2 v2SampleStart = new Vector2(0, 0);
     
 
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
                 float xCoord = v2SampleStart.x + vertices[i].x  * scale;
                 float yCoord = v2SampleStart.y + vertices[i].z  * scale;
                 vertices[i].x = vertices[i].x * (1 + Mathf.PerlinNoise(vertices[i].y * 3f + offset1.x, vertices[i].z * 3f + offset1.y) * scale);
                 vertices[i].y = vertices[i].y * (1 + Mathf.PerlinNoise(vertices[i].z * 3f + offset2.x, vertices[i].x * 3f + offset2.y) * scale);
                 vertices[i].z = vertices[i].z * (1 + Mathf.PerlinNoise(vertices[i].x * 3f + offset3.x, vertices[i].y * 3f + offset3.y) * scale); 
             }
             mesh.vertices = vertices;
             mesh.RecalculateBounds();
             mesh.RecalculateNormals();
     }
 }
