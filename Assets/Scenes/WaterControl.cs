using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterControl : MonoBehaviour {
    void Start() {
        Mesh mesh = MeshHelper.CreateMesh(10, 10);
        for(int i = 0; i < 3; i++)
            MeshHelper.Subdivide(mesh);
        GetComponent<MeshFilter>().mesh = mesh;
    }

    [SerializeField]
    private Text Width, Height, Subdivision;
    public void UpdateMesh() {
        int width = 0, height = 0, subTime = 0;
        if(Width.text != "")
            width = int.Parse(Width.text);
        if (Height.text != "")
            height = int.Parse(Height.text);
        if (Subdivision.text != "")
            subTime = int.Parse(Subdivision.text);
        Mesh mesh = MeshHelper.CreateMesh(width, height);
        while (subTime --> 0)
            MeshHelper.Subdivide(mesh);
        GetComponent<MeshFilter>().mesh = mesh;
    }

    private float distance(Vector3 p1, Vector3 p2) {
        return Mathf.Sqrt(Mathf.Pow(p1.x - p2.x, 2) + Mathf.Pow(p1.z - p2.z, 2));
    }

    float time = 0f;
    private void Update() {
        time += Time.deltaTime;
        Transform waterPlane = GetComponent<Transform>();
        Mesh waterMesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = waterMesh.vertices;
        for (int i = 0; i < vertices.Length; i++) {
            float y = 0;
            foreach (Transform wavesorces in waterPlane) {
                float f = 5f, v = 5f;
                y += 0.3f * Mathf.Cos(f * 2 * Mathf.PI * (time / 60) - 2 * Mathf.PI * distance(vertices[i], wavesorces.position) / (v / f));
            }
            vertices[i] = new Vector3(vertices[i].x, y, vertices[i].z);
        }
        waterMesh.vertices = vertices;
        waterMesh.RecalculateNormals();
        waterMesh.RecalculateTangents();
    }
}
