using UnityEngine;

public class Mid_Orbit : MonoBehaviour
{
    public float speed = 35f;

    void Update()
    {
        transform.Rotate(0f, speed * Time.deltaTime, 0f, Space.Self);
    }
}
