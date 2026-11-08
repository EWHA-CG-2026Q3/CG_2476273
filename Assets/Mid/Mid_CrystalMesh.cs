using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Mid_CrystalMesh : MonoBehaviour
{
    public int sides = 6;
    public float radius = 0.35f;
    public float height = 1.2f;

    void OnEnable()
    {
        CreateCrystal();
    }

    void CreateCrystal()
    {
        Mesh mesh = new Mesh();
        mesh.name = "Mid_Crystal";

        Vector3[] vertices = new Vector3[sides + 2];
        vertices[0] = new Vector3(0, height * 0.5f, 0);
        vertices[sides + 1] = new Vector3(0, -height * 0.5f, 0);

        for (int i = 0; i < sides; i++)
        {
            float angle = 2f * Mathf.PI * i / sides;
            vertices[i + 1] = new Vector3(
                Mathf.Cos(angle) * radius,
                0,
                Mathf.Sin(angle) * radius
            );
        }

        int[] triangles = new int[sides * 6];
        int t = 0;

        for (int i = 0; i < sides; i++)
        {
            int current = i + 1;
            int next = ((i + 1) % sides) + 1;

            triangles[t++] = 0;
            triangles[t++] = next;
            triangles[t++] = current;

            triangles[t++] = sides + 1;
            triangles[t++] = current;
            triangles[t++] = next;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        GetComponent<MeshFilter>().sharedMesh = mesh;
    }
}
