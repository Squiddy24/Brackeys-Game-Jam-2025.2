using UnityEngine;
using TMPro;

public class CoinCount : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public int coins;

    public void Start()
    {
        updateText();
    }

    public void addCoins(float num)
    {
        coins += (int)num;
        updateText();
    }
    public void subCoins(float num)
    {
        coins -= (int)num;
        updateText();
    }

    public void updateText()
    {
        coinText.text = coins.ToString();
    }

}
