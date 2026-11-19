using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class S23_BilinearPatch_Finish : MonoBehaviour
{
    public Transform corner00;
    public Transform corner10;
    public Transform corner01;
    public Transform corner11;

    [Range(1, 20)] public int uSegments = 10;
    [Range(1, 20)] public int vSegments = 10;

    private Mesh mesh;

    void OnEnable()
    {
        EnsureMesh();
        BuildMesh();
    }

    void OnValidate()
    {
        EnsureMesh();
        BuildMesh();
    }

    void EnsureMesh()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();

        if (mesh == null)
        {
            mesh = new Mesh();
            mesh.name = "S23_BilinearPatch";
        }

        meshFilter.sharedMesh = mesh;
    }

    void BuildMesh()
    {
        if (corner00 == null || corner10 == null ||
            corner01 == null || corner11 == null)
            return;

        int uCount = uSegments + 1;
        int vCount = vSegments + 1;

        Vector3[] vertices = new Vector3[uCount * vCount];
        Vector2[] uv = new Vector2[vertices.Length];

        for (int j = 0; j < vCount; j++)
        {
            float v = (float)j / vSegments;

            for (int i = 0; i < uCount; i++)
            {
                float u = (float)i / uSegments;
                int index = j * uCount + i;

                Vector3 worldPos =
                    (1f - u) * (1f - v) * corner00.position +
                    u * (1f - v) * corner10.position +
                    (1f - u) * v * corner01.position +
                    u * v * corner11.position;

                vertices[index] = transform.InverseTransformPoint(worldPos);
                uv[index] = new Vector2(u, v);
            }
        }

        int[] triangles = new int[uSegments * vSegments * 6];
        int t = 0;

        for (int j = 0; j < vSegments; j++)
        {
            for (int i = 0; i < uSegments; i++)
            {
                int a = j * uCount + i;
                int b = a + 1;
                int c = a + uCount;
                int d = c + 1;

                triangles[t++] = a;
                triangles[t++] = c;
                triangles[t++] = b;

                triangles[t++] = b;
                triangles[t++] = c;
                triangles[t++] = d;
            }
        }

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }
    void Update()
    {
        BuildMesh();
    }
}
