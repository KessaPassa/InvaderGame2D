using UnityEngine;
using System.Collections;

public class ResizeByPixel : MonoBehaviour
{
    public int pixelSize;
    public float defaultSize = 1;

    void OnValidate()
    {
        defaultSize = Mathf.Max(0.0001f, defaultSize);

        if (pixelSize < 1)
            return;
        float rate = defaultSize / pixelSize;
        transform.localScale = new Vector3(rate, rate, rate);
    }
}