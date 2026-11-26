using UnityEngine;

public class Actor_SpawnDecal : MonoBehaviour
{
    public GameObject decalPrefab;
    public bool alignToPath = true;
    public float yOffset = 0.01f;

    bool hasPrevious;
    Vector3 previousPoint;

    public void SpawnAt(Vector3 worldPoint)
    {
        if (decalPrefab == null) return;

        Quaternion rotation = Quaternion.Euler(90f, 0f, 0f);

        if (alignToPath && hasPrevious)
        {
            Vector3 dir = worldPoint - previousPoint;
            dir.y = 0f;

            if (dir.sqrMagnitude > 0.0001f)
                rotation = Quaternion.Euler(90f, Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg, 0f);
        }

        Instantiate(decalPrefab, worldPoint + Vector3.up * yOffset, rotation);
        previousPoint = worldPoint;
        hasPrevious = true;
    }

    public void EndPath()
    {
        hasPrevious = false;
    }
}
