using UnityEngine;
using TMPro;
using static Unity.Burst.Intrinsics.X86.Avx;
using DG.Tweening;

public class Tohum : MonoBehaviour
{
    //private static Tohum _instance;
    public static Tohum Instance;

    public TextMeshProUGUI TohumTMP;
    public TextMeshProUGUI InGameTotalTmp;
    public int totalTohum;
    int InGameTotal;
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
        StartTohum();
    }
    void Start()
    {
        InGameTotal = 0;
    }
    void StartTohum()
    {
        totalTohum = PlayerPrefs.GetInt("TotalTohum", 0);
        TohumTMP.text = totalTohum.ToString();
    }
    void Update()
    {
    }
    public void TohumPlus(int unit)
    {
        totalTohum = PlayerPrefs.GetInt("TotalTohum");
        totalTohum += unit;
        TohumTMP.text = totalTohum.ToString();
        PlayerPrefs.SetInt("TotalTohum", totalTohum);
        InGameTotal++;
    }
    public void TohumMinus(int unit)
    {
        totalTohum = PlayerPrefs.GetInt("TotalTohum");
        totalTohum -= unit;
        TohumTMP.text = totalTohum.ToString();
        PlayerPrefs.SetInt("TotalTohum", totalTohum);
    }
    public void InGameTotalWrite()
    {
        InGameTotalTmp.text = "+" + InGameTotal;
    }
    public void Shake()
    {
        transform.DOShakePosition(0.3f, 15f, 15, 90f);
    }

}
