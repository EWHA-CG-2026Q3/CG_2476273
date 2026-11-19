using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class S23_VertexColorDiamond : MonoBehaviour
{
    void OnEnable()
    {
        BuildMesh();
    }

    void OnValidate()
    {
        BuildMesh();
    }

    void BuildMesh()
    {
        Vector3 top = new Vector3(0, 0.6f, 0);
        Vector3 bottom = new Vector3(0, -0.6f, 0);

        Vector3 front = new Vector3(0, 0, -0.5f);
        Vector3 right = new Vector3(0.5f, 0, 0);
        Vector3 back = new Vector3(0, 0, 0.5f);
        Vector3 left = new Vector3(-0.5f, 0, 0);

        Vector3[] vertices =
        {
            top, front, right,
            top, right, back,
            top, back, left,
            top, left, front,

            bottom, right, front,
            bottom, back, right,
            bottom, left, back,
            bottom, front, left
        };

        int[] triangles =
        {
            0, 2, 1,
            3, 5, 4,
            6, 8, 7,
            9, 11, 10,

            12, 14, 13,
            15, 17, 16,
            18, 20, 19,
            21, 23, 22
        };  

        Color c1 = new Color(0.3f, 0.7f, 1f);
        Color c2 = new Color(0.15f, 0.45f, 0.9f);

        Color[] colors =
        {
            c1, c1, c1,
            c1, c1, c1,
            c1, c1, c1,
            c1, c1, c1,

            c2, c2, c2,
            c2, c2, c2,
            c2, c2, c2,
            c2, c2, c2
        };

        Mesh mesh = new Mesh();
        mesh.name = "S23_VertexColorDiamond";

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.colors = colors;

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        GetComponent<MeshFilter>().sharedMesh = mesh;
    }
}