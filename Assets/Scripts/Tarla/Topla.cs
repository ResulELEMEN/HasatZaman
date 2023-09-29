using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Topla : MonoBehaviour
{
    public ClockTarla tarlaClock;
    bool Open;
    public TextMeshPro coinTextt;
    public TarlaP tarlaParent;
    // Start is called before the first frame update
    void Start()
    {
        CheckOpen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CheckOpen()
    {
        Open = PlayerPrefs.GetInt("CoinTopla" + tarlaClock.TarlaNo, 0) == 0 ? false : true;
        if (Open)
        {
            int down = PlayerPrefs.GetInt("Birim" + tarlaClock.TarlaNo, 0);
            ToplaGorun(down);
        }
    }
    private void OnMouseDown()
    {
        int down= PlayerPrefs.GetInt("Birim" + tarlaClock.TarlaNo,0);
        ToplaSaklan(down);
        print("deneme");
        tarlaClock.ekili = false;
        PlayerPrefs.SetInt("ekili" + tarlaClock.TarlaNo.ToString(), tarlaClock.ekili ? 1 : 0);


    }
    public void ToplaGorun(int birim)
    {

        coinTextt.text = "+" + birim;
        PlayerPrefs.SetInt("Birim" + tarlaClock.TarlaNo, birim);
        transform.DOScale(Vector3.one, 0.3f);
        Open = true;
        PlayerPrefs.SetInt("CoinTopla" + tarlaClock.TarlaNo, Open ? 1 : 0);
    }
    public void ToplaSaklan(int birim)
    {
        tarlaParent.ToprakSpriteChange(1);
        Coin.Instance.CoinPlus(birim);
        coinTextt.text = "+" + birim;
        PlayerPrefs.SetInt("Birim" + tarlaClock.TarlaNo, birim);
        transform.DOScale(Vector3.zero, 0.3f);
        Open=false;
        PlayerPrefs.SetInt("CoinTopla" + tarlaClock.TarlaNo, Open ? 1 : 0);
    }

}
