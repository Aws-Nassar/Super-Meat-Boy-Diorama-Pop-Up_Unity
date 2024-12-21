using UnityEngine;

public class ScalingObjects : MonoBehaviour
{
    float minScale = 0f;
    float maxScale = 1.3f;

    float scaleChangeRate = 0.4f;

    public Transform[] objectsToScale;
    private Vector3[] initialScales;

    void Start()
    {
        initialScales = new Vector3[objectsToScale.Length];
        for (int i = 0; i < objectsToScale.Length; i++)
        {
            initialScales[i] = objectsToScale[i].localScale;
            objectsToScale[i].localScale = new Vector3(initialScales[i].x,0f, 0f);
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && BookRotate.isBookRotated > -1)
        {
            AdjustScale(-scaleChangeRate * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow)&& BookRotate.isBookRotated < 1)
        {
            AdjustScale(scaleChangeRate * Time.deltaTime);
        }
    }

void AdjustScale(float scaleDelta)
{
    for (int i = 0; i < objectsToScale.Length; i++)
    {
        if( i == 6)
        {
            objectsToScale[i].Translate(Vector3.up * scaleDelta * 2.5f, Space.Self);
        }

        var obj = objectsToScale[i];
        Vector3 currentScale = obj.localScale;

        float adjustedDeltaY = scaleDelta;          
        float adjustedDeltaZ = scaleDelta * 0.1f;   

        float newScaleY = Mathf.Clamp(currentScale.y + adjustedDeltaY, minScale, maxScale);

        float maxZ = initialScales[i].z;
        float newScaleZ = Mathf.Clamp(currentScale.z + adjustedDeltaZ, 0f, maxZ);

        obj.localScale = new Vector3(currentScale.x, newScaleY, newScaleZ);
    }
}

}