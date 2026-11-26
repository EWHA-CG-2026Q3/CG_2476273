using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Trigger_OnClickSurface : MonoBehaviour
{
    public UnityEvent<Vector3> OnClick;
    Collider myCollider;

    void Awake()
    {
        myCollider = GetComponent<Collider>();
    }

    void Update()
    {
        if (Pointer.current == null || !Pointer.current.press.wasPressedThisFrame) return;

        Ray ray = Camera.main.ScreenPointToRay(Pointer.current.position.ReadValue());
        if (!Physics.Raycast(ray, out RaycastHit hit, 1000f)) return;
        if (hit.collider != myCollider) return;

        OnClick?.Invoke(hit.point);
    }
}
