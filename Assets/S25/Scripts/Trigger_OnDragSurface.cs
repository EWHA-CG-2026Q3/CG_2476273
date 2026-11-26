using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Trigger_OnDragSurface : MonoBehaviour
{
    public float spacing = 0.15f;
    public UnityEvent<Vector3> OnDrag;
    public UnityEvent OnDragEnd;

    Collider myCollider;
    bool dragging;
    bool hasLastPoint;
    Vector3 lastPoint;

    void Awake()
    {
        myCollider = GetComponent<Collider>();
    }

    void Update()
    {
        if (Pointer.current == null) return;

        if (Pointer.current.press.wasReleasedThisFrame && dragging)
        {
            dragging = false;
            hasLastPoint = false;
            OnDragEnd?.Invoke();
            return;
        }

        if (!Pointer.current.press.isPressed) return;

        Ray ray = Camera.main.ScreenPointToRay(Pointer.current.position.ReadValue());
        if (!Physics.Raycast(ray, out RaycastHit hit, 1000f)) return;
        if (hit.collider != myCollider) return;

        dragging = true;

        if (!hasLastPoint || Vector3.Distance(lastPoint, hit.point) >= spacing)
        {
            lastPoint = hit.point;
            hasLastPoint = true;
            OnDrag?.Invoke(hit.point);
        }
    }
}
