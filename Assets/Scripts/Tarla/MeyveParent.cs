using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MeyveParent : MonoBehaviour
{
    public int meyveNo;
    public int time_MP;
    public int tohum_mp;
    public int getiri_MP;
    public int kilitCost_MP;
    public TextMeshProUGUI time_TMP;
    public TextMeshProUGUI tohum_TMP;
    public TextMeshProUGUI getiri_TMP;
    public TextMeshProUGUI kilitCost_TMP;
    public bool Kilitli;
    public Button MeyveButton;
    public Button buyButton;
    public GameObject blackEfect;
    public TarlaManager tarlaManager;
    public Button PanelButton;
    // Start is called before the first frame update
    private void Awake()
    {
        GoText();
    }
    void Start()
    {
        KilitCheck();
    }
    void GoText()
    {
        time_TMP.text = time_MP.ToString() + "dk";
        tohum_TMP.text = "-" + tohum_mp.ToString();
        getiri_TMP.text = "+" + getiri_MP.ToString();
        kilitCost_TMP.text = kilitCost_MP.ToString();
    }
    void KilitCheck()
    {
        Kilitli = PlayerPrefs.GetInt("MeyveKilit" + meyveNo.ToString(), 1) == 0 ? false : true;
        if (Kilitli)
        {
            MeyveButton.interactable = false;
            blackEfect.SetActive(true);
            buyButton.gameObject.SetActive(true);
        }
        else
        {
            MeyveButton.interactable = true;
            blackEfect.SetActive(false);
            buyButton.gameObject.SetActive(false);
        }
    }
    public void BuyFruit()
    {
        Coin.Instance.CoinMinus(kilitCost_MP);
        Kilitli = false;
        PlayerPrefs.SetInt("MeyveKilit" + meyveNo.ToString(), Kilitli ? 1 : 0);
        KilitCheck();
    }
    //PlayerPrefs.GetInt("lockBool" + clockTarlaScrpt.TarlaNo, 0) == 0 ? false : true;
    //  PlayerPrefs.SetInt("lockBool" + clockTarlaScrpt.TarlaNo.ToString(), lockBool? 1 : 0);
    // Update is called once per frame
    public void Ekim()
    {
        PanelButton.onClick.Invoke();
        int currentTarla = LevelManeger.Instance.currentLevel;
        if (Tohum.Instance.totalTohum > tohum_mp)
        {
            tarlaManager.TarlaEk(currentTarla, time_MP, getiri_MP, tohum_mp);
        }
        else
        {
            Tohum.Instance.Shake();
        }
    }
    void Update()
    {

    }
}
