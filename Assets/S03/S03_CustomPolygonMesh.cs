using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class S03_CustomPolygonMesh : MonoBehaviour
{
    void Start()
    {
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0f, 3f, 0f),
            new Vector3(3f, 1f, 0f),
            new Vector3(2f, -3f, 0f),
            new Vector3(-2f, -3f, 0f),
            new Vector3(-3f, 1f, 0f)
        };
        int[] triangles = new int[]
        {

        };
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));

    }
}
