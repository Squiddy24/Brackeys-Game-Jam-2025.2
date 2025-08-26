using UnityEngine;
using TMPro;

public class StockCount : MonoBehaviour
{
    public int count;
    public TextMeshProUGUI text;
    public void Increse()
    {
        count++;
        text.text = count.ToString();
    }
    public void Decrese()
    {
        if (count > 0)
        {
            count--;
            text.text = count.ToString();
        }
    }
}
