using UnityEngine;

public class Mid_FloatRotate : MonoBehaviour
{
    public float floatHeight = 0.15f;
    public float floatSpeed = 2f;
    public float rotateSpeed = 40f;

    Vector3 startPosition;

    void Start()
    {
        startPosition = transform.localPosition;
    }

    void Update()
    {
        float y = Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.localPosition = startPosition + new Vector3(0f, y, 0f);
        transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f, Space.Self);
    }
}
