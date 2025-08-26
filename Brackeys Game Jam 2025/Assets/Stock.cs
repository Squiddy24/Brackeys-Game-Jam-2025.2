using UnityEngine;
using TMPro;

public class Stock : MonoBehaviour
{
    public float[] pricePoints;
    public float maxValue;
    public UILineRenderer lineRenderer;

    public RectTransform bounds;
    public RectTransform valueText;
    public TextMeshProUGUI text;


    void Start()
    {
        lineRenderer.points = new Vector2[pricePoints.Length];
        for (int point = 0; point < pricePoints.Length; point++)
        {
            lineRenderer.points[point] = new Vector2(bounds.rect.width / pricePoints.Length * point, bounds.rect.height * (pricePoints[point] / maxValue));
        }

        valueText.position = new Vector3(bounds.position.x - (bounds.rect.width / 2) + bounds.rect.width / pricePoints.Length * (pricePoints.Length - 1) + 30,
        bounds.position.y - (bounds.rect.height / 2) + bounds.rect.height * (pricePoints[pricePoints.Length - 1] / maxValue));
        
        text.text = pricePoints[pricePoints.Length - 1].ToString();
    }

}
