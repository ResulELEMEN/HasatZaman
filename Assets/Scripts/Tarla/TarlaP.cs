using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TarlaP : MonoBehaviour
{
    public bool lockBool;
    public Transform lockSprite;
    public Transform cost;
    public int cashCost;
    public SpriteRenderer toprak;
    public TarlaManager manager;
    public TextMeshPro costTMP;
    public ClockTarla clockTarlaScrpt;
    public MeyvePanel meyvePanel;
    //saat

    // Start is called before the first frame update
    void Start()
    {
        lockBool = PlayerPrefs.GetInt("lockBool" + clockTarlaScrpt.TarlaNo, 0) == 0 ? false : true;
        ToprakSpriteCheck();
        LockCheckFast();
        WriteCostToTMP();
    }
    void ToprakSpriteCheck()
    {
        int no= PlayerPrefs.GetInt("TarlaSpritesNo" + clockTarlaScrpt.TarlaNo,1);
        toprak.sprite = manager.tarlaSpirites[no];
    }
    public void ToprakSpriteChange(int tarlaSpritesNo)
    {
        toprak.sprite = manager.tarlaSpirites[tarlaSpritesNo];
        PlayerPrefs.SetInt("TarlaSpritesNo" + clockTarlaScrpt.TarlaNo, tarlaSpritesNo);
    }
    void LockCheckFast()
    {
        if (!lockBool)
        {
            toprak.sprite = manager.tarlaSpirites[0];
            lockSprite.DOScale(Vector3.one * 2, 0f);
            cost.DOScale(Vector3.one, 0f);
        }
    }
    void LockCheck()
    {
        if (!lockBool)
        {
            toprak.sprite = manager.tarlaSpirites[0];
            lockSprite.DOScale(Vector3.one*2, 0.3f);
            cost.DOScale(Vector3.one, 0.3f);
        }
    }
    public void WriteCostToTMP()
    {
        costTMP.text = cashCost.ToString();
    }
    public void PayCost()
    {
        if (Coin.Instance.totalCoin >= cashCost)
        {
            Coin.Instance.CoinMinus(cashCost);
            lockBool = true;
            PlayerPrefs.SetInt("lockBool" + clockTarlaScrpt.TarlaNo.ToString(), lockBool ? 1 : 0);
            LockCheck();
            meyvePanel.PanelGecisAnim();
            cost.gameObject.GetComponent<Collider2D>().enabled = false;
            toprak.sprite = manager.tarlaSpirites[1];
            lockSprite.DOScale(Vector3.zero, 0.3f);
            cost.DOScale(Vector3.zero, 0.3f);
        }
        else
        {
            DOTween.Kill(cost.transform);
            cost.transform.DOShakePosition(0.3f, 0.25f, 15, 15f).SetId(cost.transform);
        }

    }
    public void StartTime(int Second, int getiri)
    {
        clockTarlaScrpt.LessTimeVoid(Second,getiri);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
