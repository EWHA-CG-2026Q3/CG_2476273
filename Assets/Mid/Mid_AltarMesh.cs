using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Mid_AltarMesh : MonoBehaviour
{
    public int segments = 24;
    public float radius = 1.2f;
    public float height = 0.25f;

    void OnEnable()
    {
        CreateMesh();
    }

    void CreateMesh()
    {
        Mesh mesh = new Mesh();
        mesh.name = "Mid_Altar";

        Vector3[] vertices = new Vector3[segments * 2 + 2];
        Vector2[] uv = new Vector2[vertices.Length];

        int bottomCenter = segments * 2;
        int topCenter = segments * 2 + 1;

        vertices[bottomCenter] = Vector3.zero;
        vertices[topCenter] = new Vector3(0, height, 0);

        uv[bottomCenter] = new Vector2(0.5f, 0.5f);
        uv[topCenter] = new Vector2(0.5f, 0.5f);

        for (int i = 0; i < segments; i++)
        {
            float angle = 2f * Mathf.PI * i / segments;

            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;

            vertices[i] = new Vector3(x, 0, z);
            vertices[i + segments] = new Vector3(x, height, z);

            float u = (x / radius + 1f) * 0.5f;
            float v = (z / radius + 1f) * 0.5f;

            uv[i] = new Vector2(u, v);
            uv[i + segments] = new Vector2(u, v);
        }

        int[] triangles = new int[segments * 12];
        int t = 0;

        for (int i = 0; i < segments; i++)
        {
            int next = (i + 1) % segments;

            triangles[t++] = bottomCenter;
            triangles[t++] = next;
            triangles[t++] = i;

            triangles[t++] = topCenter;
            triangles[t++] = i + segments;
            triangles[t++] = next + segments;

            triangles[t++] = i;
            triangles[t++] = next;
            triangles[t++] = next + segments;

            triangles[t++] = i;
            triangles[t++] = next + segments;
            triangles[t++] = i + segments;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        GetComponent<MeshFilter>().sharedMesh = mesh;
    }
}