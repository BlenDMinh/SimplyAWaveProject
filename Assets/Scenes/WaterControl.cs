using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterControl : MonoBehaviour {
    void Start() {
        Mesh mesh = MeshHelper.CreateMesh(10, 10);
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
}
