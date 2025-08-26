using UnityEngine;

public class Stock : MonoBehaviour
{
    public float[] pricePoints;
    public float maxValue;
    public UILineRenderer lineRenderer;

    public RectTransform bounds;

    void Start()
    {
        lineRenderer.points = new Vector2[pricePoints.Length];
        for (int point = 0; point < pricePoints.Length; point++)
        {
            lineRenderer.points[point] = new Vector2(bounds.rect.width / pricePoints.Length * point, bounds.rect.height * (pricePoints[point] / maxValue));
        }
    }

}
