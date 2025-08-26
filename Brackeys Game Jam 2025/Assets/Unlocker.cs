using UnityEngine;

public class Unlocker : MonoBehaviour
{
    [SerializeField] private GameObject stock1;
    [SerializeField] private GameObject stock2;
    [SerializeField] private GameObject stock3;

    [SerializeField] private GameObject buyStock1;
    [SerializeField] private GameObject buyStock2;
    [SerializeField] private GameObject buyStock3;

    public void UnlockStock1()
    {
        stock1.SetActive(true);
        buyStock1.SetActive(false);
    }

    public void UnlockStock2()
    {
        stock2.SetActive(true);
        buyStock2.SetActive(false);
    }

    public void UnlockStock3()
    {
        stock3.SetActive(true);
        buyStock3.SetActive(false);
    }
}