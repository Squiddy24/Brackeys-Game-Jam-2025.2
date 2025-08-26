using UnityEngine;
using TMPro;

public class StockCount : MonoBehaviour
{
    public int count;
    public TextMeshProUGUI text;
    public Stock stock;
    public CoinCount coincount;
    public void Increse()
    {
        if (coincount.coins >= stock.pricePoints[stock.pricePoints.Length - 1])
        {
            count++;
            text.text = count.ToString();
            coincount.subCoins(stock.pricePoints[stock.pricePoints.Length - 1]);
        }
    }
    public void Decrese()
    {
        if (count > 0)
        {
            count--;
            text.text = count.ToString();
            coincount.addCoins(stock.pricePoints[stock.pricePoints.Length - 1]);
        }
    }
}
