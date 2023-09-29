using UnityEngine;
using TMPro;
using static Unity.Burst.Intrinsics.X86.Avx;

public class Coin : MonoBehaviour
{
    public static Coin Instance;
    public TextMeshProUGUI CoinTMP;
    [HideInInspector]public int totalCoin;
    
    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
        StartCoin();
    }
    void Start()
    {
        //CoinPlus(5000);
    }
    void StartCoin()
    {
        totalCoin = PlayerPrefs.GetInt("TotalCoin", 0);
        CoinTMP.text = totalCoin.ToString();
    }
    void Update()
    {
    }
    public void CoinPlus(int unit)
    {
        totalCoin = PlayerPrefs.GetInt("TotalCoin");
        totalCoin += unit;
        CoinTMP.text = totalCoin.ToString();
        PlayerPrefs.SetInt("TotalCoin", totalCoin);
    }
    public void CoinMinus(int unit)
    {
        totalCoin = PlayerPrefs.GetInt("TotalCoin");
        totalCoin -= unit;
        CoinTMP.text = totalCoin.ToString();
        PlayerPrefs.SetInt("TotalCoin", totalCoin);
    }


}
