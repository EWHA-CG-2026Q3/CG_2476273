using UnityEngine;

public class Actor_SetImpactProperty : MonoBehaviour
{
    public Renderer targetRenderer;
    public string positionProperty = "_ImpactPosition";
    public string timeProperty = "_ImpactTime";

    MaterialPropertyBlock block;

    void Awake()
    {
        if (targetRenderer == null) targetRenderer = GetComponent<Renderer>();
        block = new MaterialPropertyBlock();

        targetRenderer.GetPropertyBlock(block);
        block.SetFloat(timeProperty, -1000f);
        targetRenderer.SetPropertyBlock(block);
    }

    public void Actor_SetImpact(Vector3 worldPoint)
    {
        targetRenderer.GetPropertyBlock(block);
        block.SetVector(positionProperty, worldPoint);
        block.SetFloat(timeProperty, Time.timeSinceLevelLoad);
        targetRenderer.SetPropertyBlock(block);
    }
}
