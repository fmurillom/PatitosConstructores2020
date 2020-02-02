﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnObjects : MonoBehaviour
{
    Mesh navMesh;
    public GameObject[] objects;


    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        navMesh = ExportMesh();
        InvokeRepeating("CreateBoulder", 0f, 3f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        
    }
    private Mesh ExportMesh()
     {
         NavMeshTriangulation triangulatedNavMesh = NavMesh.CalculateTriangulation();
 
         Mesh mesh = new Mesh();
         mesh.name = "ExportedNavMesh";
         mesh.vertices = triangulatedNavMesh.vertices;
         mesh.triangles = triangulatedNavMesh.indices;
         return mesh;
     }
    public Vector3 RandomPoint()
    {
        return GenerateRandomPoint(navMesh);
    }
    private Vector3 GenerateRandomPoint(Mesh mesh)
     {
         // 1 - Calculate Surface Areas
         float[] triangleSurfaceAreas = CalculateSurfaceAreas(mesh);
 
         // 2 - Normalize area weights
         float[] normalizedAreaWeights = NormalizeAreaWeights(triangleSurfaceAreas);
 
         // 3 - Generate 'triangle selection' random #
         float triangleSelectionValue = Random.value;
 
         // 4 - Walk through the list of weights to select the proper triangle
         int triangleIndex = SelectRandomTriangle(normalizedAreaWeights, triangleSelectionValue);
 
         // 5 - Generate a random barycentric coordinate
         Vector3 randomBarycentricCoordinates = GenerateRandomBarycentricCoordinates();
 
         // 6 - Using the selected barycentric coordinate and the selected mesh triangle, convert
         //     this point to world space.
         return ConvertToLocalSpace(randomBarycentricCoordinates, triangleIndex, mesh);
     }
 
     private float[] CalculateSurfaceAreas(Mesh mesh)
     {
         int triangleCount = mesh.triangles.Length / 3;
 
         float[] surfaceAreas = new float[triangleCount];
 
 
         for (int triangleIndex = 0; triangleIndex < triangleCount; triangleIndex++)
         {
             Vector3[] points = new Vector3[3];
             points[0] = mesh.vertices[mesh.triangles[triangleIndex * 3 + 0]];
             points[1] = mesh.vertices[mesh.triangles[triangleIndex * 3 + 1]];
             points[2] = mesh.vertices[mesh.triangles[triangleIndex * 3 + 2]];
 
             // calculate the three sidelengths and use those to determine the area of the triangle
             // http://www.wikihow.com/Sample/Area-of-a-Triangle-Side-Length
             float a = (points[0] - points[1]).magnitude;
             float b = (points[0] - points[2]).magnitude;
             float c = (points[1] - points[2]).magnitude;
 
             float s = (a + b + c) / 2;
 
             surfaceAreas[triangleIndex] = Mathf.Sqrt(s*(s - a)*(s - b)*(s - c));
         }
 
         return surfaceAreas;
     }
 
     private float[] NormalizeAreaWeights(float[] surfaceAreas)
     {
         float[] normalizedAreaWeights = new float[surfaceAreas.Length];
 
         float totalSurfaceArea = 0;
         foreach (float surfaceArea in surfaceAreas)
         {
             totalSurfaceArea += surfaceArea;
         }
 
         for (int i = 0; i < normalizedAreaWeights.Length; i++)
         {
             normalizedAreaWeights[i] = surfaceAreas[i] / totalSurfaceArea;
         }
 
         return normalizedAreaWeights;
     }
 
     private int SelectRandomTriangle(float[] normalizedAreaWeights, float triangleSelectionValue)
     {
         float accumulated = 0;
 
         for (int i = 0; i < normalizedAreaWeights.Length; i++)
         {
             accumulated += normalizedAreaWeights[i];
 
             if (accumulated >= triangleSelectionValue)
             {
                 return i;
             }
         }
 
         // unless we were handed malformed normalizedAreaWeights, we should have returned from this already.
         throw new System.ArgumentException("Normalized Area Weights were not normalized properly, or triangle selection value was not [0, 1]");
     }
 
     private Vector3 GenerateRandomBarycentricCoordinates()
     {
         Vector3 barycentric = new Vector3(Random.value, Random.value, Random.value);
 
         while (barycentric == Vector3.zero)
         {
             // seems unlikely, but just in case...
             barycentric = new Vector3(Random.value, Random.value, Random.value);
         }
 
         // normalize the barycentric coordinates. These are normalized such that x + y + z = 1, as opposed to
         // normal vectors which are normalized such that Sqrt(x^2 + y^2 + z^2) = 1. See:
         // http://en.wikipedia.org/wiki/Barycentric_coordinate_system
         float sum = barycentric.x + barycentric.y + barycentric.z;
 
         return barycentric / sum;
     }
 
     private Vector3 ConvertToLocalSpace(Vector3 barycentric, int triangleIndex, Mesh mesh)
     {
         Vector3[] points = new Vector3[3];
         points[0] = mesh.vertices[mesh.triangles[triangleIndex * 3 + 0]];
         points[1] = mesh.vertices[mesh.triangles[triangleIndex * 3 + 1]];
         points[2] = mesh.vertices[mesh.triangles[triangleIndex * 3 + 2]];
 
         return (points[0] * barycentric.x + points[1] * barycentric.y + points[2] * barycentric.z);
     }
    void CreateBoulder()
    {
        Vector3 position = RandomPoint();
        GameObject Boulder = objects[Random.Range(0, 2)];
        GameObject instance = Instantiate(Boulder, new Vector3(transform.position.x, transform.position.y + 2.0f, transform.position.z) + position, transform.rotation);
        Destroy(instance, 10f);
    }
}
